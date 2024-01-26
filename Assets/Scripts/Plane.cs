using UnityEngine;

public class Plane : MonoBehaviour
{
    public Transform targetPosition;
    public Difficulty Difficulty;

    private Baby baby;

    private float movementSpeed
    {
        get { return Difficulty.PlaneSpeed; }
    }

    private void Start()
    {
        baby = IOC.Get<Baby>();
        SetTargetPosition(baby.transform);
    }

    private void Update()
    {
        if (targetPosition == null)
        {
            Debug.Log("Target position not set!");
            return;
        }

        transform.up = targetPosition.position - transform.position;
        Vector3 movement = transform.up.normalized * (Time.deltaTime * movementSpeed);
        transform.position += movement;

        if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f)
        {
            baby.PlaneHit();
            Destroy(gameObject);
        }
    }

    public void SetTargetPosition(Transform position)
    {
        targetPosition = position;
    }
}