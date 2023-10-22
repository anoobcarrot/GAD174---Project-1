using UnityEngine;

public class CharacterTrigger : MonoBehaviour
{
    public UIManager uiManager; // Reference to the UIManager script

    private bool inTriggerArea = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SilverTray"))
        {
            inTriggerArea = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("SilverTray"))
        {
            inTriggerArea = false;
        }
    }

    void Update()
    {
        if (inTriggerArea)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                uiManager.ToggleUI(); // Call the ToggleUI method on the UIManager
            }
        }
    }
}
