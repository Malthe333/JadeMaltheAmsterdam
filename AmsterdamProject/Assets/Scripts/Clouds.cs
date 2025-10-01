using UnityEngine;

public class Clouds : MonoBehaviour
{

    public float minY = -5f;
    public float maxY = 30f;

    public SpriteRenderer cloudRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float currentAlpha = 1.0f-Mathf.Clamp01((transform.position.y - minY) / (maxY - minY));

        Color cloudColor = Color.white;
        cloudColor.a = currentAlpha;
        cloudRenderer.color = cloudColor;

    }
}
