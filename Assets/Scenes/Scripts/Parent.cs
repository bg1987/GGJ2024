using UnityEngine;

public class Parent : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float leftLimit = -5f;
    public float rightLimit = 5f;
    public SpriteRenderer mySprite;

    private void Awake()
    {
        IOC.Register(this);
    }

    void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate new position
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);

        // Restrict the position within the limits
        newPosition.x = Mathf.Clamp(newPosition.x, leftLimit, rightLimit);

        // Move the character
        transform.position = newPosition;
    }

    void OnDrawGizmos()
    {
        // Draw gizmos to visualize the movement limits
        Gizmos.color = Color.blue;

        // Draw left limit
        Gizmos.DrawLine(new Vector3(leftLimit, transform.position.y, transform.position.z),
            new Vector3(leftLimit, transform.position.y + 1f, transform.position.z));

        // Draw right limit
        Gizmos.DrawLine(new Vector3(rightLimit, transform.position.y, transform.position.z),
            new Vector3(rightLimit, transform.position.y + 1f, transform.position.z));
    }

    public void ChangeColor(Color c)
    {
        mySprite.color = c;
    }
}