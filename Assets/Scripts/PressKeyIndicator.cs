using UnityEngine;

public class PressKeyIndicator : MonoBehaviour
{
    public SpriteRenderer mySprite;

    private void Awake()
    {
        IOC.Register(this);
    }

    public void onShouldTap(bool shouldTap)
    {
        mySprite.enabled = shouldTap;
    }
}