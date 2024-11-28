using DCFApixels;
using System;
using Unity.Mathematics;
using UnityEngine;

public abstract class RandomDemoBase : MonoBehaviour
{
    public SpriteRenderer pointPrefab;
    [Range(0, 5000)]
    public int count = 100;
    public Gradient gradient;
    public float size;
    public int seed;
    public bool autoSeed = true;

    private SpriteRenderer[] _pool = new SpriteRenderer[0];
    protected ReadOnlySpan<SpriteRenderer> GetPoints(int count)
    {
        if (_pool == null || _pool.Length < count)
        {
            int startIndex = 0;
            if (_pool == null)
            {
                _pool = new SpriteRenderer[count];
            }
            else
            {
                startIndex = _pool.Length;
                Array.Resize(ref _pool, count);
            }
            for (int i = startIndex; i < count; i++)
            {
                var inst = Instantiate(pointPrefab, transform);
                inst.sortingOrder = i;
                _pool[i] = inst;
            }
        }
        for (int i = 0; i < _pool.Length; i++)
        {
            _pool[i].gameObject.SetActive(i < count);
        }
        return new ReadOnlySpan<SpriteRenderer>(_pool, 0, count);
    }

    private bool _isApply = false;
    private void OnEnable()
    {
        _isApply = true;
    }
    private void Update()
    {
        if (_isApply)
        {
            Apply();
            _isApply = false;
        }
    }
    private void OnValidate()
    {
        if (Application.isPlaying)
        {
            _isApply = true;
        }
    }

    protected abstract void Apply();
}

public class QuasiRandomDemo : RandomDemoBase
{
    private QuasiRandom _random;

    private void Awake()
    {
        if (autoSeed)
        {
            _random = QuasiRandom.AutoSeed();
            seed = (int)_random.GetState();
        }
        else
        {
            _random = new QuasiRandom(seed);
        }
    }
    public enum Method
    {
        NextInt,
        NextUInt,
        NextLong,
        NextULong,
        NextFloat,
        NextDouble,
    }
    private enum Args
    {
        None,
        Max,
        MinMax,
    }
    public Method method;
    public long min = 0;
    public long max = 1000;
    public double range = 1000;
    protected override void Apply()
    {
        Args args = Args.None;
        if(max != 0)
        {
            if (min == 0)
            {
                args = Args.Max;
            }
            else
            {
                args = Args.MinMax;
            }
        }
        Debug.Log(args);

        _random.SetState(seed);
        var points = GetPoints(count);
        double2 halfSize = new double2(1, 1) * size / 2f;
        for (int i = 0; i < count; i++)
        {
            var point = points[i];
            double2 r = default;
            switch (method)
            {
                case Method.NextInt:
                    {
                        switch (args)
                        {
                            case Args.None:
                                r = (double2)_random.NextInt2();
                                r /= int.MaxValue;
                                r = r * size - halfSize;
                                break;
                            case Args.Max:
                                r = (double2)_random.NextInt2((int)max);
                                r /= range;
                                r = r * size - halfSize;
                                break;
                            case Args.MinMax:
                                r = (double2)_random.NextInt2((int)min, (int)max);
                                r /= range;
                                r = r * size - halfSize;
                                break;
                        }
                    }
                    break;
                case Method.NextUInt:
                    {
                        switch (args)
                        {
                            case Args.None:
                                r = (double2)_random.NextUInt2();
                                r /= uint.MaxValue;
                                r = r * size - halfSize;
                                break;
                            case Args.Max:
                                r = (double2)_random.NextUInt2((uint)max);
                                r /= range;
                                r = r * size - halfSize;
                                break;
                            case Args.MinMax:
                                r = (double2)_random.NextUInt2((uint)min, (uint)max);
                                r /= range;
                                r = r * size - halfSize;
                                break;
                        }
                    }
                    break;
                case Method.NextLong:
                    {
                        switch (args)
                        {
                            case Args.None:
                                r = (double2)_random.NextLong2();
                                r /= long.MaxValue;
                                r = r * size - halfSize;
                                break;
                            case Args.Max:
                                r = (double2)_random.NextLong2((long)max);
                                r /= range;
                                r = r * size - halfSize;
                                break;
                            case Args.MinMax:
                                r = (double2)_random.NextLong2((long)min, (long)max);
                                r /= range;
                                r = r * size - halfSize;
                                break;
                        }
                    }
                    break;
                case Method.NextULong:
                    {
                        switch (args)
                        {
                            case Args.None:
                                r = (double2)_random.NextULong2();
                                r /= ulong.MaxValue;
                                r = r * size - halfSize;
                                break;
                            case Args.Max:
                                r = (double2)_random.NextULong2((ulong)max);
                                r /= range;
                                r = r * size - halfSize;
                                break;
                            case Args.MinMax:
                                r = (double2)_random.NextULong2((ulong)min, (ulong)max);
                                r /= range;
                                r = r * size - halfSize;
                                break;
                        }
                    }
                    break;
                case Method.NextFloat:
                    r = (double2)_random.NextFloat2() * size - halfSize;
                    break;
                case Method.NextDouble:
                    r = (double2)_random.NextDouble2() * size - halfSize;
                    break;
            }
            if(math.any(math.isnan(r)) == false)
            {
                point.transform.localPosition = new Vector3((float)r.x, (float)r.y, 0);
            }
            point.color = gradient.Evaluate((float)i / count);
            point.sortingOrder = i;
        }
    }
}
