using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PrecisionManager : MonoBehaviour
{
    public static PrecisionManager Instance; // Singleton instance for global access
    public TextMeshProUGUI precisionText; // Text element to display the precision
    private float precision = 100f; // Initial precision score

    private void Awake()
    {
        // Ensure there's only one instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdatePrecisionDisplay();
    }

    // Public method to reduce precision
    public void ReducePrecision(float amount)
    {
        precision -= amount;
        precision = Mathf.Max(precision, 0); // Clamp to 0
        UpdatePrecisionDisplay();

        if (precision <= 0)
        {
            Debug.Log("Precision reached 0%. Game over or resetting the level.");
            ResetLevel(); // Call method to reset the level
        }
    }

    // Public method to get the current precision score
    public float GetPrecision()
    {
        return precision;
    }

    // Update the precision display text
    private void UpdatePrecisionDisplay()
    {
        precisionText.text = "Precision: " + precision.ToString("F0") + "%";
    }

    // Method to reset the level (reload the current scene)
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }
}
