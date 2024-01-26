using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace HomeRun.Parts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Bat : MonoBehaviour
    {
        [SerializeField] private float scaleDuration = 1f;
        [SerializeField] private Ease easeGrow = Ease.InQuad;
        [SerializeField] private Ease easeShrink = Ease.OutQuad;

        [SerializeField] [Range(0f, 1f)] private float threshold = 0.8f; 
        [SerializeField] private Color canBatColor = Color.green;
        [SerializeField] private Color cantBatColor = Color.red;

        [SerializeField] private UnityEvent<bool> release;
        
        private SpriteRenderer sprite;
        
        private float originalScaleX;
        private Sequence sequence;

        void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            
            var localScale = transform.localScale;
            originalScaleX = localScale.x;
            localScale = new Vector3(0,localScale.y,localScale.z);
            transform.localScale = localScale;

            sequence = DOTween.Sequence();
            sequence.Append(transform.DOScaleX(originalScaleX, scaleDuration/2f).SetEase(easeGrow));
            sequence.Append(transform.DOScaleX(0f, scaleDuration/2f).SetEase(easeShrink));
            sequence.SetLoops(-1);
        }

        private void OnDisable()
        {
            sequence.Pause();
        }

        private void Update()
        {
            bool pastThreshold = (transform.localScale.x / originalScaleX) > threshold;
            
            sprite.color = pastThreshold ? canBatColor : cantBatColor;

            if (Input.GetKey(KeyCode.Space))
            {
                sequence.Play();
            }
            else
            {
                sequence.Pause();
            }
            
            if (Input.GetKeyUp(KeyCode.Space))
            {
                release?.Invoke(pastThreshold);
                var localScale = transform.localScale;
                localScale = new Vector3(0,localScale.y,localScale.z);
                transform.localScale = localScale;
                sequence.Restart();
            }
        }
    }
}