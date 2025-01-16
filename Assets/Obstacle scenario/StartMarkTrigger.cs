using UnityEngine;
using TMPro;

public class TriggerHandler : MonoBehaviour
{
    private TriggerController controller; 
    private bool isInside = false; 
    private float timeInside = 3.2f; 
    private float triggerTime = 3.2f; 
    private bool timerActive = false;

    [SerializeField] public static GameObject countdownCanvas;
    [SerializeField] private TextMeshProUGUI countdownText;

    void Start()
    {
        controller = GetComponentInParent<TriggerController>();
        if (controller == null)
        {
            Debug.LogWarning("No TriggerController found in parent!");
        }
        
        if (countdownCanvas != null)
        {
            countdownCanvas.SetActive(true);
        }

        if (countdownText != null)
        {
            countdownText.text = Mathf.FloorToInt(timeInside).ToString();
        }
    }

    void Update()
    {
        if (isInside && timerActive)
        {
            timeInside -= Time.deltaTime;

            if (timeInside < 0f)
            {
                timeInside = 0f;
            }
            
            if (countdownText != null)
            {
                countdownText.text = Mathf.FloorToInt(timeInside).ToString();
            }

            if (timeInside == 0f)
            {
                TriggerEvents();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            Debug.Log("Drone entered the trigger area!");
            isInside = true;

            timeInside = triggerTime;
            timerActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            Debug.Log("Drone left the trigger area!");
            isInside = false;

            timeInside = triggerTime;
            timerActive = false;

            if (countdownText != null)
            {
                countdownText.text = Mathf.FloorToInt(timeInside).ToString();
            }
        }
    }

    void TriggerEvents()
    {
       

        if (countdownCanvas != null)
        {
            countdownCanvas.SetActive(false);
        }
        Destroy(gameObject, 0.1f);
    }
}
