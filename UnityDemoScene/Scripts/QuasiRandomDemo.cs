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
        QuasiRandom random = QuasiRandom.AutoSeed();

        Transform transform = this.transform;
        Vector2 halfSize = Vector2.one * size / 2f;
        for (int i = 0; i < count; i++)
        {
            SpriteRenderer point = Instantiate(pointPrefab, transform);
            point.transform.localPosition = random.NextUnityVector2() * size - halfSize;
            point.color = gradient.Evaluate((float)i / count);
        }
    }
}
