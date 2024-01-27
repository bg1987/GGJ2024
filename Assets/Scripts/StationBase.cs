using UnityEngine;

public abstract class StationBase : MonoBehaviour
{
    public Color stationColor;
    public SpriteRenderer stationIcon;
    protected Baby baby;
    protected Difficulty gameDifficulty;
    protected float HPPerHit;
    protected bool isVisited;


    protected Parent parent;
    protected PressKeyIndicator shouldTap;

    protected virtual void Start()
    {
        parent = IOC.Get<Parent>();
        baby = IOC.Get<Baby>();
        gameDifficulty = IOC.Get<Difficulty>();
        shouldTap = IOC.Get<PressKeyIndicator>();

        HPPerHit = gameDifficulty.defaultHpPerStationHit;

        baby.AddWant(this);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isVisited = true;
            parent.ChangeColor(Color.clear);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            parent.ResetColor();
            isVisited = false;
            shouldTap.onShouldTap(false);
        }
    }
}