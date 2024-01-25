using UnityEngine;

public abstract class IOCRegister : MonoBehaviour
{
    private void Awake()
    {
        IOC.Register(this);
    }
}