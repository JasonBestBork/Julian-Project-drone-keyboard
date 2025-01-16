using UnityEngine;

public class DroneCollisionHandler : MonoBehaviour
{
    private bool isColliding = false; // To track if the drone is in contact with a bullet

    private void OnTriggerEnter(Collider other)
    {
        // Start decreasing precision if the drone collides with a bullet
        if (other.gameObject.CompareTag("bullet") && !isColliding)
        {
            Debug.Log("Drone started colliding with a bullet!");
            isColliding = true;
            StartCoroutine(DecreasePrecisionOverTime(0.45f, 1f)); // Cooldown of 0.7s, reduces by 1% each time
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Stop decreasing precision when the drone leaves the bullet
        if (other.gameObject.CompareTag("bullet") && isColliding)
        {
            Debug.Log("Drone stopped colliding with the bullet!");
            isColliding = false;
        }
    }

    private System.Collections.IEnumerator DecreasePrecisionOverTime(float cooldown, float decreaseAmount)
    {
        while (isColliding)
        {
            PrecisionManager.Instance?.ReducePrecision(decreaseAmount); // Reduce precision
            yield return new WaitForSeconds(cooldown); // Wait for the cooldown duration
        }
    }
}
