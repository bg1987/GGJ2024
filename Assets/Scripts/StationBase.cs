using UnityEngine;

public abstract class StationBase : MonoBehaviour
{
    public Color stationColor;
    public float HPPerHit = 10f; 
    
    
    private Parent parent;
    protected Baby baby;
    protected bool isVisited;
    
    
    private void Start()
    {
        parent = IOC.Get<Parent>();
        baby = IOC.Get<Baby>();
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