using UnityEngine;

[CreateAssetMenu(fileName = "New EventBus", menuName = "EventBus")]
public class EventBus : ScriptableObject
{
    public GameObject shouldTapIcon;

    public void onShouldTap(bool shouldTap)
    {
        shouldTapIcon.SetActive(shouldTap);
    }
}