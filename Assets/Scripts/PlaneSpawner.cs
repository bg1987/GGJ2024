using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRadius = 5f; // Radius of the spawn area
    public float arcAngle = 360f; // Angle of the arc in degrees
    public AnimationCurve spawnFrequencyCurve;
    private float spawnFrequency;

    private float timer = 0f;

    private void Start()
    {
        SetSpawnFrequency();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnFrequency)
        {
            SpawnPrefab();
            timer = 0f;
            SetSpawnFrequency();
        }
    }

    private void SpawnPrefab()
    {
        // Calculate the random angle within the arc
        float randomAngle = Random.Range(-arcAngle / 2f, arcAngle / 2f);

        // Convert the angle to radians
        float radians = randomAngle * Mathf.Deg2Rad;

        // Calculate the position around the object in the spawn radius
        Vector3 spawnPosition =
            transform.position + new Vector3(Mathf.Sin(radians), 0f, Mathf.Cos(radians)) * spawnRadius;

        // Spawn the prefab at the calculated position
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    private void SetSpawnFrequency()
    {
        spawnFrequency = spawnFrequencyCurve.Evaluate(Time.time);
    }
}