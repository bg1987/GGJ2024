using UnityEngine;

[CreateAssetMenu(fileName = "New DifficultyCurve", menuName = "Difficulty")]
public class Difficulty : ScriptableObject
{
    [SerializeField] private AnimationCurve wantsChangeFrequency;

    [SerializeField] private AnimationCurve planeSpeed;

    [SerializeField] private AnimationCurve planeSpawnFrequency;

    public float wrongWantFactor = 2;
    public float startingHP = 100;
    public float maxHp = 150;
    public float hpDecay = 6.6f;

    public float happyHpMin = 100;
    public float planeDamage = 5;

    public float defaultHpPerStationHit = 5f;
    public float strikerHpPerHit = 20f;

    public float PlaneSpeed
    {
        get { return planeSpeed.Evaluate(Time.time); }
    }

    public float PlaneSpawnFrequency
    {
        get { return planeSpawnFrequency.Evaluate(Time.time); }
    }

    public float WantsChangeFrequency
    {
        get { return wantsChangeFrequency.Evaluate(Time.time); }
    }
}