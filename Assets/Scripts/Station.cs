using UnityEngine;

public class Station : MonoBehaviour
{
    public Color stationColor;

    private Parent parent;

    private void Start()
    {
        parent = IOC.Get<Parent>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Player")
        {
            parent.ChangeColor(stationColor);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            parent.ResetColor();
        }
    }
}