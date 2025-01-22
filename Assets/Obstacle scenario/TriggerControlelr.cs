using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] private GameObject finalCanvas;
    [SerializeField] private GameObject monitoredObject;
    [SerializeField] private GameObject objectToInstantiate;
    [SerializeField] private Transform spawnLocation;

    [SerializeField] private GameObject enemyToEnable; // Existing enemy object to enable

    private bool hasInstantiated = false;

    void Start()
    {
        if (finalCanvas != null)
        {
            finalCanvas.SetActive(false);
        }

        if (monitoredObject == null)
        {
            Debug.LogWarning("No object assigned to monitor!");
        }

        if (objectToInstantiate == null)
        {
            Debug.LogWarning("No object assigned to instantiate!");
        }

        if (enemyToEnable == null)
        {
            Debug.LogWarning("No enemy object assigned to enable!");
        }
    }

    void Update()
    {
        if (monitoredObject == null && !hasInstantiated)
        {
            Debug.Log("Monitored object is destroyed. Activating final canvas.");
            EnableFinalCanvas();

            // Instantiate the main object
            if (objectToInstantiate != null && spawnLocation != null)
            {
                Instantiate(objectToInstantiate, spawnLocation.position, spawnLocation.rotation);
                Debug.Log("Instantiated the main object with 4 3D objects.");
            }

            // Enable the enemy object
            if (enemyToEnable != null)
            {
                enemyToEnable.SetActive(true);
                Debug.Log("Enabled the enemy object.");
            }

            hasInstantiated = true;
        }
    }

    public void EnableFinalCanvas()
    {
        if (finalCanvas != null)
        {
            finalCanvas.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Final canvas is not assigned!");
        }
    }
}
