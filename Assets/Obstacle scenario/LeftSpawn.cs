using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlledSpawner : MonoBehaviour
{
    public Transform[] leftSpawnPoints;
    public Transform[] rightSpawnPoints;
    public Transform[] diagonalSpawnPoints;

    public GameObject objectPrefab; 

    
    public Transform leftTargetArea;
    public Transform rightTargetArea;
    public Transform diagonalTargetArea;

    public float spawnInterval = 2f;

   
    public float easyMinSpeed = 1f;
    public float easyMaxSpeed = 3f;
    public float easyMinSize = 0.5f;
    public float easyMaxSize = 1.5f;

    public float mediumMinSpeed = 2f;
    public float mediumMaxSpeed = 5f;
    public float mediumMinSize = 6;
    public float mediumMaxSize = 9.5f;

    public float hardMinSpeed = 3f;
    public float hardMaxSpeed = 7f;
    public float hardMinSize = 1f;
    public float hardMaxSize = 3f;

    private float minSpeed;
    private float maxSpeed;
    private float minSize;
    private float maxSize;

    private void Start()
    {
        // Set difficulty-specific values based on the current scene
        SetDifficultySettings();

        // Start spawning objects based on the current scene
        StartCoroutine(SpawnObjects());
    }

    private void SetDifficultySettings()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName.Contains("Easy"))
        {
            minSpeed = easyMinSpeed;
            maxSpeed = easyMaxSpeed;
            minSize = easyMinSize;
            maxSize = easyMaxSize;
        }
        else if (currentSceneName.Contains("Medium"))
        {
            minSpeed = mediumMinSpeed;
            maxSpeed = mediumMaxSpeed;
            minSize = mediumMinSize;
            maxSize = mediumMaxSize;
        }
        else if (currentSceneName.Contains("Hard"))
        {
            minSpeed = hardMinSpeed;
            maxSpeed = hardMaxSpeed;
            minSize = hardMinSize;
            maxSize = hardMaxSize;
        }
    }

    private System.Collections.IEnumerator SpawnObjects()
    {
        // Check the current scene name and set the spawning behavior accordingly
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName.Contains("Easy"))
        {
          
            while (true)
            {
                SpawnFromSide(leftSpawnPoints, leftTargetArea, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);
                SpawnFromSide(rightSpawnPoints, rightTargetArea, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);

            }
        }
        else if (currentSceneName.Contains("Medium"))
        {
           
            while (true)
            {
                SpawnFromSide(leftSpawnPoints, leftTargetArea, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);

                SpawnFromSide(rightSpawnPoints, rightTargetArea, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);

                SpawnFromSide(diagonalSpawnPoints, diagonalTargetArea, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);
            }
        }
        else if (currentSceneName.Contains("Hard"))
        {
           
            while (true)
            {
          
            }
        }
    }

    private void SpawnFromSide(Transform[] spawnPoints, Transform limitPoint, float speed)
    {
        // Pick a random spawn point
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[spawnIndex];

        // Instantiate the object (cylinder)
        GameObject obj = Instantiate(objectPrefab, selectedSpawnPoint.position, Quaternion.identity);

        // Randomize size
        float randomSize = Random.Range(minSize, maxSize);
        obj.transform.localScale = new Vector3(randomSize, randomSize, randomSize);  // Keep the scale proportional

        // Calculate the direction to the limit point
        Vector3 directionToLimit = (limitPoint.position - selectedSpawnPoint.position).normalized;

        // Adjust the rotation so the X-axis faces the limit point
        obj.transform.rotation = Quaternion.LookRotation(directionToLimit);

        // Start moving the object toward the limit point
        StartCoroutine(MoveObjectToPoint(obj, limitPoint.position, speed));
    }




    private System.Collections.IEnumerator MoveObjectToPoint(GameObject obj, Vector3 targetPoint, float speed)
    {
        while (obj != null)
        {
            // Move the object toward the target point
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPoint, speed * Time.deltaTime);

            // Check if the object has reached the target point
            if (Vector3.Distance(obj.transform.position, targetPoint) < 0.1f)
            {
                Destroy(obj); // Destroy the object
                yield break;
            }

            yield return null;
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
