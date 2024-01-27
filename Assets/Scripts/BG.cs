using System;
using UnityEngine;

public class BG : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] [Range(0.0f, 1.0f)] private float movementScale = 0.01f;

    [SerializeField] private bool reverse;
    [SerializeField] private bool relative = false;

    private Vector3 originalPos;

    private void Awake()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var newX = (reverse ? 1f : -1f) * movementScale * parent.position.x;
        transform.position = new Vector3(originalPos.x + newX, originalPos.y, originalPos.z);
    }
}