using UnityEngine;
using DefaultRandom = System.Random;

public class UnityRandomDemo : MonoBehaviour
{
    public SpriteRenderer pointPrefab;
    public int count = 100;
    public Gradient gradient;
    public float size;
    public int seed;
    public bool autoSeed = true;

    private DefaultRandom _random;

    private void Awake()
    {
        if (autoSeed)
            _random = new DefaultRandom();
        else
            _random = new DefaultRandom(seed);
    }

    private void OnEnable()
    {
        Transform transform = this.transform;
        Vector2 halfSize = Vector2.one * size / 2f;
        for (int i = 0; i < count; i++)
        {
            SpriteRenderer point = Instantiate(pointPrefab, transform);
            point.transform.localPosition = new Vector2((float)_random.NextDouble(), (float)_random.NextDouble()) * size - halfSize;
            point.color = gradient.Evaluate((float)i / count);
            point.sortingOrder = i;
        }
    }
}
