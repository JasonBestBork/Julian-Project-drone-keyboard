using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlledSpawner : MonoBehaviour
{
    // Left-to-right spawns (Easy)
    public Transform[] leftSpawnPoints;
    // Right-to-left spawns (Easy)
    public Transform[] rightSpawnPoints;
    // Diagonal spawns (Medium)
    public Transform[] diagonalSpawnPoints;

    public GameObject objectPrefab; // Prefab of the object to spawn

    // Target areas
    public Transform leftTargetArea;
    public Transform rightTargetArea;
    public Transform diagonalTargetArea;

    public float spawnInterval = 2f;
    public float minSpeed = 1f;
    public float maxSpeed = 5f;
    public float minSize = 0.5f;
    public float maxSize = 2f;

    private void Start()
    {
        // Start spawning objects based on the current scene
        StartCoroutine(SpawnObjects());
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        // Check the current scene name and set the spawning behavior accordingly
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName.Contains("Easy"))
        {
            // Easy Level: spawn objects left-to-right and right-to-left
            while (true)
            {
                SpawnFromSide(leftSpawnPoints, leftTargetArea, "left");
                yield return new WaitForSeconds(spawnInterval);

                SpawnFromSide(rightSpawnPoints, rightTargetArea, "right");
                yield return new WaitForSeconds(spawnInterval);
            }
        }
        else if (currentSceneName.Contains("Medium"))
        {
            // Medium Level: spawn objects diagonally
            while (true)
            {
                SpawnFromSide(diagonalSpawnPoints, diagonalTargetArea, "diagonal");
                yield return new WaitForSeconds(spawnInterval);
            }
        }
        else if (currentSceneName.Contains("Hard"))
        {
            // Hard Level: spawn objects with more complex behavior (e.g., random movement or additional features)
            while (true)
            {
                SpawnFromSide(leftSpawnPoints, leftTargetArea, "left");
                yield return new WaitForSeconds(spawnInterval);

                SpawnFromSide(rightSpawnPoints, rightTargetArea, "right");
                yield return new WaitForSeconds(spawnInterval);

                // Add additional complex spawning behavior for Hard level if needed
                // You can make it spawn random directions, faster speed, etc.
            }
        }
    }

    private void SpawnFromSide(Transform[] spawnPoints, Transform targetArea, string direction)
    {
        // Pick a random spawn point from the side
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[spawnIndex];

        // Instantiate the object at the selected spawn point
        GameObject obj = Instantiate(objectPrefab, selectedSpawnPoint.position, Quaternion.identity);

        // Randomize size
        float randomSize = Random.Range(minSize, maxSize);
        obj.transform.localScale = Vector3.one * randomSize;

        // Randomize speed
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // If the direction is "diagonal", handle diagonal movement
        if (direction == "diagonal")
        {
            // Move the object diagonally
            StartCoroutine(MoveObjectDiagonally(obj, selectedSpawnPoint.position, targetArea.position, randomSpeed));
        }
        else
        {
            // Otherwise, use horizontal movement (left or right)
            StartCoroutine(MoveObjectToTarget(obj, selectedSpawnPoint.position, targetArea.position, randomSpeed, direction));
        }
    }

    private System.Collections.IEnumerator MoveObjectToTarget(GameObject obj, Vector3 start, Vector3 end, float speed, string direction)
    {
        Vector3 startPosition = new Vector3(start.x, obj.transform.position.y, obj.transform.position.z);
        Vector3 endPosition = new Vector3(end.x, obj.transform.position.y, obj.transform.position.z);

        float distance = Vector3.Distance(startPosition, endPosition);
        float travelTime = distance / speed;
        float elapsedTime = 0f;

        while (elapsedTime < travelTime)
        {
            obj.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / travelTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(obj);
    }

    // Method for diagonal movement
    private System.Collections.IEnumerator MoveObjectDiagonally(GameObject obj, Vector3 start, Vector3 end, float speed)
    {
        Vector3 startPosition = start;
        Vector3 endPosition = end;

        float distance = Vector3.Distance(startPosition, endPosition);
        float travelTime = distance / speed;
        float elapsedTime = 0f;

        // Move object diagonally (along X and Y axes)
        while (elapsedTime < travelTime)
        {
            obj.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / travelTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(obj);
    }
}
