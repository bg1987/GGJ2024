using System;
using UnityEngine;

public abstract class StationBase : MonoBehaviour
{
    public Color stationColor;
    public Sprite stationIcon;
    protected Baby baby;
    protected Difficulty gameDifficulty;
    protected float HPPerHit;
    protected bool isVisited;


    protected Parent parent;
    protected PressKeyIndicator shouldTap;

    protected void Awake()
    {
    }

    protected void OnEnable()
    {
        baby = IOC.Get<Baby>();
        baby.AddWant(this);
    }

    protected virtual void Start()
    {
        parent = IOC.Get<Parent>();
        gameDifficulty = IOC.Get<Difficulty>();
        shouldTap = IOC.Get<PressKeyIndicator>();

        HPPerHit = gameDifficulty.defaultHpPerStationHit;
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