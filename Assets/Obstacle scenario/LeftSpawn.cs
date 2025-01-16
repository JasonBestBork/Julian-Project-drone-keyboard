using UnityEngine;

public class ControlledSpawner : MonoBehaviour
{
    // Left-to-right spawns
    public Transform[] leftSpawnPoints; // Attach left spawn points here
    // Right-to-left spawns
    public Transform[] rightSpawnPoints; // Attach right spawn points here
    public GameObject objectPrefab; // Prefab of the object to spawn

    // Two separate target areas: one for left-to-right and one for right-to-left
    public Transform leftTargetArea; // Target area for left-to-right objects
    public Transform rightTargetArea; // Target area for right-to-left objects

    public float spawnInterval = 2f; // Interval between spawns
    public float minSpeed = 1f; // Minimum movement speed
    public float maxSpeed = 5f; // Maximum movement speed
    public float minSize = 0.5f; // Minimum object size
    public float maxSize = 2f; // Maximum object size

    private void Start()
    {
        // Start spawning objects from both sides
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        while (true)
        {
            // Spawn object from left side
            SpawnFromSide(leftSpawnPoints, leftTargetArea, "left");
            // Wait for the object to be destroyed before spawning the next one
            yield return new WaitForSeconds(spawnInterval);

            // Spawn object from right side
            SpawnFromSide(rightSpawnPoints, rightTargetArea, "right");
            // Wait for the object to be destroyed before spawning the next one
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnFromSide(Transform[] spawnPoints, Transform targetArea, string direction)
    {
        // Pick a random spawn point from the side
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[spawnIndex];

        // Instantiate the object at the selected spawn point with appropriate rotation
        GameObject obj = Instantiate(objectPrefab, selectedSpawnPoint.position, Quaternion.Euler(0, 0, direction == "left" ? 90 : -90));

        // Randomize size
        float randomSize = Random.Range(minSize, maxSize);
        obj.transform.localScale = Vector3.one * randomSize;

        // Randomize speed
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // Move the object towards the target area
        StartCoroutine(MoveObjectToTarget(obj, selectedSpawnPoint.position, targetArea.position, randomSpeed, direction));
    }

    private System.Collections.IEnumerator MoveObjectToTarget(GameObject obj, Vector3 start, Vector3 end, float speed, string direction)
    {
        // Correct start and end positions for horizontal movement, using Y and Z as constants
        Vector3 startPosition = new Vector3(start.x, obj.transform.position.y, obj.transform.position.z);
        Vector3 endPosition = new Vector3(end.x, obj.transform.position.y, obj.transform.position.z);

        // Calculate the distance between start and end positions
        float distance = Vector3.Distance(startPosition, endPosition);
        float travelTime = distance / speed;
        float elapsedTime = 0f;

        // Move the object smoothly from start to end position
        while (elapsedTime < travelTime)
        {
            obj.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / travelTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Destroy the object after reaching the target
        Destroy(obj);
    }
}
