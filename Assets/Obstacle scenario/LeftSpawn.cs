using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlledSpawner : MonoBehaviour
{
    public Transform[] leftSpawnPoints;
    public Transform[] rightSpawnPoints;
    public Transform[] diagonalSpawnPoints;

    public Transform[] leftObjectives;  
    public Transform[] rightObjectives; 
    public Transform[] diagonalObjectives; 

    public GameObject objectPrefab;

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
        SetDifficultySettings();
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
        string currentSceneName = SceneManager.GetActiveScene().name;

        while (true)
        {
            if (currentSceneName.Contains("Easy"))
            {
                // Spawn objects for Easy Level
                SpawnWithObjective(leftSpawnPoints, leftObjectives, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);

                SpawnWithObjective(rightSpawnPoints, rightObjectives, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);
            }
            else if (currentSceneName.Contains("Medium"))
            {
                // Spawn objects for Medium Level
                SpawnWithObjective(leftSpawnPoints, leftObjectives, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);

                SpawnWithObjective(rightSpawnPoints, rightObjectives, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);

                SpawnWithObjective(diagonalSpawnPoints, diagonalObjectives, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);
            }
            else if (currentSceneName.Contains("Hard"))
            {
                // Spawn objects for Hard Level
                SpawnWithObjective(leftSpawnPoints, leftObjectives, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);

                SpawnWithObjective(rightSpawnPoints, rightObjectives, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);

                SpawnWithObjective(diagonalSpawnPoints, diagonalObjectives, Random.Range(minSpeed, maxSpeed));
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    private void SpawnWithObjective(Transform[] spawnPoints, Transform[] objectives, float speed)
    {
        // Validate the arrays are matched
        if (spawnPoints.Length != objectives.Length)
        {
            Debug.LogError("Spawn points and objectives must have the same length!");
            return;
        }

        // Pick a random spawn point and its corresponding objective
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform selectedSpawnPoint = spawnPoints[spawnIndex];
        Transform targetObjective = objectives[spawnIndex];

        // Instantiate the object
        GameObject obj = Instantiate(objectPrefab, selectedSpawnPoint.position, Quaternion.identity);

        // Randomize size
        float randomSize = Random.Range(minSize, maxSize);
        obj.transform.localScale = new Vector3(randomSize, randomSize, randomSize);

        // Rotate the object to face the objective
        Vector3 directionToTarget = (targetObjective.position - selectedSpawnPoint.position).normalized;
        obj.transform.rotation = Quaternion.LookRotation(directionToTarget);

        // Move the object toward the objective
        StartCoroutine(MoveObjectToPoint(obj, targetObjective.position, speed));
    }

    private System.Collections.IEnumerator MoveObjectToPoint(GameObject obj, Vector3 targetPoint, float speed)
    {
        while (obj != null)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPoint, speed * Time.deltaTime);

            if (Vector3.Distance(obj.transform.position, targetPoint) < 0.1f)
            {
                Destroy(obj);
                yield break;
            }

            yield return null;
        }
    }
}
