using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstantiate; // Prefab with 4 3D objects
    [SerializeField] private Transform spawnLocation; // Spawn location for the object

    private bool isFinalCanvasEnabled = false; // Flag to track when the finalCanvas should trigger instantiation

    void Update()
    {
        // Check if the flag is set to true, meaning the finalCanvas has been enabled
        if (isFinalCanvasEnabled && objectToInstantiate != null && spawnLocation != null)
        {
            InstantiateObject();
            isFinalCanvasEnabled = false; // Prevent multiple instantiations
        }
    }

    public void EnableFinalCanvas()
    {
        // Trigger this method to enable the flag when finalCanvas should be shown
        isFinalCanvasEnabled = true;
        Debug.Log("Final canvas enabled, ready to instantiate object.");
    }

    private void InstantiateObject()
    {
        // Instantiate the prefab at the spawn location
        Instantiate(objectToInstantiate, spawnLocation.position, spawnLocation.rotation);
        Debug.Log("Object with 4 3D objects instantiated!");
    }
}
