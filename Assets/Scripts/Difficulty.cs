using UnityEngine;

[CreateAssetMenu(fileName = "New DifficultyCurve", menuName = "Difficulty")]
public class Difficulty : ScriptableObject
{
    [SerializeField] private float gameLength;

    [SerializeField] private Vector2 wantsChangeFrequencyValues;
    [SerializeField] private AnimationCurve wantsChangeFrequency;

    [SerializeField] private Vector2 planeSpeedValues;
    [SerializeField] private AnimationCurve planeSpeed;

    [SerializeField] private Vector2 planeSpawnFrequencyValues;
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
        get { return Mathf.Lerp(planeSpeedValues.x, planeSpeedValues.y, planeSpeed.Evaluate(Time.time / gameLength)); }
    }

    public float PlaneSpawnFrequency
    {
        get
        {
            return Mathf.Lerp(planeSpawnFrequencyValues.x, planeSpeedValues.y,
                planeSpawnFrequency.Evaluate(Time.time / gameLength));
        }
    }

    public float WantsChangeFrequency
    {
        get
        {
            return Mathf.Lerp(wantsChangeFrequencyValues.x, wantsChangeFrequencyValues.y,
                wantsChangeFrequency.Evaluate(Time.time / gameLength));
        }
    }
}