using UnityEngine;

public class UnityRandomDemo : MonoBehaviour
{
    public SpriteRenderer pointPrefab;
    public int count = 100;
    public Gradient gradient;
    public float size;

    private void OnEnable()
    {
        Transform transform = this.transform;
        float halfSize = size / 2f;
        for (int i = 0; i < count; i++)
        {
            SpriteRenderer point = Instantiate(pointPrefab, transform);
            point.transform.localPosition = new Vector3(Random.value * size - halfSize, Random.value * size - halfSize, 0);
            point.color = gradient.Evaluate((float)i / count);
        }
    }
}
