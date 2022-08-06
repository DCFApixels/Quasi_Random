using DCFApixels;
using UnityEngine;

public class QuasiRandomDemo : MonoBehaviour
{
    public SpriteRenderer pointPrefab;
    public int count = 100;
    public Gradient gradient;
    public float size;

    private void OnEnable()
    {
        Quasi2DRandom random = new Quasi2DRandom();
        Transform transform = this.transform;
        Vector2 halfSize = Vector2.one * size / 2f;
        for (int i = 0; i < count; i++)
        {
            SpriteRenderer point = Instantiate(pointPrefab, transform);
            point.transform.localPosition = random.NextVector() * size - halfSize;
            point.color = gradient.Evaluate((float)i / count);
        }
    }
}
