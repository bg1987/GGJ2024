using UnityEngine;

public class AnyKeyToStart : MonoBehaviour
{
    private GameLifecycle manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = IOC.Get<GameLifecycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            manager.StartGame();
        }
    }
}