using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer curtain;
    [SerializeField] private Color curtainColor;
    
    // Start is called before the first frame update
    void Start()
    {
        var sequence = DOTween.Sequence();
        var particleSystems = GetComponentsInChildren<ParticleSystem>();
        
        
        sequence.AppendInterval(2f);
        sequence.AppendCallback(() =>
        {
            foreach (var particleSystem in particleSystems)
            {
                particleSystem.Play();
            }
        });
        sequence.AppendInterval(2f);
        sequence.Append(transform.DOScale(5,10));
        sequence.AppendInterval(1f);
        sequence.AppendCallback(() =>
        {
            SceneManager.LoadScene("Menu");
        });
        sequence.Play();

        curtain.DOColor(curtainColor, sequence.Duration());
    }
}
