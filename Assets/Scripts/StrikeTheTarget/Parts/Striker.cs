using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

namespace StrikeTheTarget.Parts
{
    public class Striker : MonoBehaviour
    {
        [SerializeField] private Transform lBumper;
        [SerializeField] private Transform rBumper;
        [SerializeField] private float initialDuration = 1f;
        [SerializeField] private Collider2D target;

        [SerializeField] private Ease ease;

        [SerializeField] private UnityEvent successfulStrike;
        [SerializeField] private UnityEvent failedStrike;
        
        private bool onTarget = false;

        private void Awake()
        {
            transform.SetPositionAndRotation(lBumper.position,lBumper.rotation);
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOMove(rBumper.position, initialDuration).SetEase(ease));
            sequence.Append(transform.DOMove(lBumper.position, initialDuration).SetEase(ease));
            sequence.SetLoops(-1);
            sequence.Play();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == target)
            {
                onTarget = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other == target)
            {
                onTarget = false;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Strike " + (onTarget? "SUCCESS!" : "FAILED!"));
                
                (onTarget ? successfulStrike : failedStrike)?.Invoke();
            }
        }
    }
}