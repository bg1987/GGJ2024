using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] [Range(0.0f,1.0f)] private float movementScale = 0.01f;
    
    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        var newX =  -1f * movementScale * parent.position.x;
        transform.position = new Vector3(newX, position.y, position.z);
    }
}
