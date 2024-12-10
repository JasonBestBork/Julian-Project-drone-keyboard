using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    public GameObject platformPrefab; // Prefab of the platform
    public static int score = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            score += 1;

            Debug.Log("Current Score: " + score);
            Debug.Log("Drone has landed on the platform!");
           
            StartCoroutine(DestroyAndRespawn(0.5f));
        }
    }

    IEnumerator DestroyAndRespawn(float delay)
    {
        yield return new WaitForSeconds(delay);

        
        Destroy(platformPrefab);
        Debug.Log("Platform destroyed!");


        Vector3 randomPosition = new Vector3(
           Random.Range(-4.0f, 4.0f), // Random x position
           0.22f, // Random y position
           Random.Range(-1.5f, 4.0f)  // Random z position
       );


        Instantiate(platformPrefab, randomPosition, Quaternion.identity);
        Debug.Log("Platform respawned at: " + randomPosition);
    }
}
