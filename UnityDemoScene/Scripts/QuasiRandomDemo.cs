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
    protected override void Apply()
    {
        _random.SetState(seed);
        var points = GetPoints(count);
        float2 halfSize = new float2(1, 1) * size / 2f;
        for (int i = 0; i < count; i++)
        {
            var point = points[i];
            float2 r = (float2)_random.NextLong2() * size - halfSize;
            point.transform.localPosition = new Vector3(r.x, r.y, 0);
            point.color = gradient.Evaluate((float)i / count);
            point.sortingOrder = i;
        }
    }
}
