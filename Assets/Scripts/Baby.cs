using UnityEngine;

public class Baby : MonoBehaviour
{
    public int HP = 32;

    private void Awake()
    {
        IOC.Register(this);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}