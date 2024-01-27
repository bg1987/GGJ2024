using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CircleMovement : MonoBehaviour
{
    public Transform centerPoint; // The center point of the circle
    public float radius; // The radius of the circle
    public float speed; // The speed of movement
    public float oscillationRange; // The range of oscillation towards the center and outwards
    private float angle; // The current angle around the circle

    private bool clockwise; // Flag to keep track of the current motion direction

    private void Start()
    {
        // Initialize the initial angle and randomize the initial motion direction
        angle = Random.Range(0f, 360f);
        clockwise = Random.value > 0.5f;

        // Start the movement coroutine
        StartCoroutine(MoveInCircle());
    }

    private IEnumerator MoveInCircle()
    {
        while (true)
        {
            // Calculate the current position on the circle using the angle and radius
            Vector3 pos = centerPoint.position +
                          Quaternion.AngleAxis(angle, Vector3.forward) * (Vector3.right * radius);

            // Calculate the oscillation offset based on the current radius
            float oscillationOffset = Mathf.PingPong(Time.time * speed, oscillationRange) - oscillationRange * 0.5f;

            // Apply the oscillation offset to the Y position
            pos.y += oscillationOffset;

            // Move the transform to the calculated position using DOTween
            transform.DOMove(pos, 0.1f);

            // Update the angle based on the motion direction
            angle += (clockwise ? 1f : -1f) * speed;

            yield return null;
        }
    }
}