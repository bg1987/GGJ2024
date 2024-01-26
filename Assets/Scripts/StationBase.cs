using UnityEngine;

public abstract class StationBase : MonoBehaviour
{
    public Color stationColor;
    protected Baby baby;
    protected Difficulty gameDifficulty;
    protected float HPPerHit;
    protected bool isVisited;


    private Parent parent;


    protected virtual void Start()
    {
        parent = IOC.Get<Parent>();
        baby = IOC.Get<Baby>();
        gameDifficulty = IOC.Get<Difficulty>();

        HPPerHit = gameDifficulty.defaultHpPerStationHit;

        baby.AddWant(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            parent.ChangeColor(stationColor);
            isVisited = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            parent.ResetColor();
            isVisited = false;
        }
    }
}