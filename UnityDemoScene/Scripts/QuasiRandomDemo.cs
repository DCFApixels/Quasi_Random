using DCFApixels;
using UnityEngine;

public class QuasiRandomDemo : MonoBehaviour
{
    public SpriteRenderer pointPrefab;
    public int count = 100;
    public Gradient gradient;
    public float size;
    public int seed;
    public bool autoSeed = true;

    private QuasiRandom _random;

    private void Awake()
    {
        if (autoSeed)
            _random = QuasiRandom.AutoSeed();
        else
            _random = new QuasiRandom(seed);
    }

    private void OnEnable()
    {
        Transform transform = this.transform;
        Vector2 halfSize = Vector2.one * size / 2f;
        for (int i = 0; i < count; i++)
        {
            SpriteRenderer point = Instantiate(pointPrefab, transform);
            point.transform.localPosition = _random.NextUnityVector2() * size - halfSize;
            point.color = gradient.Evaluate((float)i / count);
            point.sortingOrder = i;
        }
    }
}
