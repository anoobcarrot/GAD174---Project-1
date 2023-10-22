using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    private bool isTriggered = false;
    private UIManager uiManager; // Reference to the UIManager.
    public UIManager UIManagerReference;

    private void Start()
    {
        uiManager = UIManagerReference;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isTriggered)
            {
                if (uiManager != null && uiManager.HasItems("Ham", "Cheese"))
                {
                    Debug.Log("Ham and Cheese Sandwich! Complete!");
                }
                else
                {
                    Debug.Log("Incorrect, try again.");
                }

                isTriggered = true; // Mark as triggered to prevent multiple checks.
            }
        }
    }
}

