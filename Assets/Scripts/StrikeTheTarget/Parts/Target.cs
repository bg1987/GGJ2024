using System;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StrikeTheTarget.Parts
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private Transform lBumper;
        [SerializeField] private Transform rBumper;
        [SerializeField] private float shakeStrength = 1f;
        [SerializeField] private int shakeVibrato = 10;
        [SerializeField] private float shakeRandomness = 90f;
        [SerializeField] private ShakeRandomnessMode shakeRandomnessMode = ShakeRandomnessMode.Full;

        private void OnEnable()
        {
            var lBumperPosition = lBumper.position;
            var delta = rBumper.position - lBumperPosition;
            var normalized = delta.normalized;
            var magnitude = delta.magnitude * Random.Range(0.25f,0.75f);

            transform.SetPositionAndRotation(lBumperPosition + (normalized * magnitude), transform.rotation);
        }

        public void OnStrike() => transform.DOShakePosition(0.1f, shakeStrength, shakeVibrato, shakeRandomness, false, false, shakeRandomnessMode);
    }
}