using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Chewing : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float duration = 1f/8f;

    // Start is called before the first frame update
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        var seq = DOTween.Sequence();
        foreach (var sprite in sprites)
        {
            seq.AppendCallback(() => spriteRenderer.sprite = sprite);
            seq.AppendInterval(duration);
        }
        seq.SetLoops(-1);
        seq.Play();
    }
}
