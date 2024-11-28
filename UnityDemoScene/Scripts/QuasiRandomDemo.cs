using DCFApixels;
using System;
using System.Security.Cryptography;
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
    public Method method;
    public long min = 0;
    public long max = 1000;
    public double range = 1000;
    protected override void Apply()
    {
        _random.SetState(seed);
        var points = GetPoints(count);
        double2 halfSize = new double2(1, 1) * size / 2f;
        for (int i = 0; i < count; i++)
        {
            var point = points[i];
            double2 r;
            switch (method)
            {
                case Method.NextInt:
                    r = (double2)_random.NextInt2((int)min, (int)max);
                    r /= range;
                    r = r * size - halfSize;
                    break;
                case Method.NextUInt:
                    r = (double2)_random.NextUInt2((uint)min, (uint)max);
                    r /= range;
                    r = r * size - halfSize;
                    break;
                case Method.NextLong:
                    r = (double2)_random.NextLong2((long)min, (long)max);
                    r /= range;
                    r = r * size - halfSize;
                    break;
                case Method.NextULong:
                    r = (double2)_random.NextULong2((ulong)min, (ulong)max);
                    r /= range;
                    r = r * size - halfSize;
                    break;
                case Method.NextFloat:
                    r = (double2)_random.NextFloat2() * size - halfSize;
                    break;
                case Method.NextDouble:
                    r = (double2)_random.NextDouble2() * size - halfSize;
                    break;
                default:
                    r = default;
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
