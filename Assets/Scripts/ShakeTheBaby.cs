using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class ShakeTheBaby : MonoBehaviour
{
    [SerializeField] private Baby babyToShake;

    [SerializeField] private float durationSeconds = 1f;
    [SerializeField] private float strength = 1f;
    [SerializeField] private int   vibrato = 10;
    [SerializeField] [Range(0f,180f)] private float randomness = 90f;

    private void Awake() => ShakeLoop().Forget();

    private async UniTaskVoid ShakeLoop()
    {
        var ct = this.GetCancellationTokenOnDestroy();

        var difficulty = IOC.Get<Difficulty>();
        
        while (!ct.IsCancellationRequested)
        {

            var multiplier = (1f - (MathF.Max(0f, babyToShake.HP / difficulty.maxHp)));
            await transform.DOShakeScale(durationSeconds, multiplier*strength, vibrato, randomness, false);
        }
    }
}
