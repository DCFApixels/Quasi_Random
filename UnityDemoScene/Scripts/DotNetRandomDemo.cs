using System;
using UnityEngine;
using DotNetRandom = System.Random;

public class DotNetRandomDemo : RandomDemoBase
{
    private DotNetRandom _random;

    private void Awake()
    {
        if (autoSeed)
        {
            seed = (int)DateTime.Now.Ticks;
        }
        _random = new DotNetRandom(seed);
    }
    protected override void Apply()
    {
        _random = new DotNetRandom(seed);
        var points = GetPoints(count);
        Vector2 halfSize = Vector2.one * size / 2f;
        for (int i = 0; i < count; i++)
        {
            var point = points[i];
            point.transform.localPosition = new Vector2((float)_random.NextDouble(), (float)_random.NextDouble()) * size - halfSize;
            point.color = gradient.Evaluate((float)i / count);
            point.sortingOrder = i;
        }
    }
}
