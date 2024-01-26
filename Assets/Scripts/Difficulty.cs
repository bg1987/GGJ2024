using UnityEngine;

[CreateAssetMenu(fileName = "New DifficultyCurve", menuName = "Difficulty")]
public class Difficulty : ScriptableObject
{
    public AnimationCurve curve;
}