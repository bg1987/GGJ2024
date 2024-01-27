using UnityEngine;

public class TapStationAnimationController : MonoBehaviour
{
    public Sprite[] sprites; // Array of individual sprites
    public float threshold = 0.05f; // The threshold (in seconds) for frame skipping.

    public SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float timer = 0f;

    public bool visible { get; set; }

    private void Update()
    {
        spriteRenderer.enabled = visible;
        if (!visible)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= threshold)
        {
            timer = 0;
            currentFrame = 0;
            spriteRenderer.sprite = sprites[currentFrame];
        }
    }

    public void Step()
    {
        if (!visible)
        {
            return;
        }

        currentFrame = (currentFrame + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[currentFrame];
        timer = 0f;
    }
}