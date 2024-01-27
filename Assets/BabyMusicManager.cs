using System;
using UnityEngine;

public class BabyMusicManager : MonoBehaviour
{
    [SerializeField] private Baby baby;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AnimationCurve pitch;
    
    private Difficulty difficulty;

    private void Awake()
    {
        difficulty = IOC.Get<Difficulty>();
    }

    // Update is called once per frame
    void Update()
    {
        audio.pitch = pitch.Evaluate(1.0f - (baby.HP / difficulty.maxHp));
    }
}
