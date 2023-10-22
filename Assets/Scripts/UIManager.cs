using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text listText;
    public Text messageText;
    public Text triggerText;
    public GameObject uiPanel;

    private bool isUIOpen = false;

    private List<string> selectedWords = new List<string>();
    private string[] correctWords = { "ham", "cheese", "ketchup" };
    private bool isTriggerCompleted = false;

    private void Start()
    {
        LoadList();
        uiPanel.SetActive(false);
    }

    public void CheckTriggerCompletion()
    {
        if (!isTriggerCompleted)
        {
            bool isCorrect = true;

            // Check if the player has only "ham" and "cheese."
            if (selectedWords.Count != 2 || !selectedWords.Contains("ham") || !selectedWords.Contains("cheese"))
            {
                isCorrect = false;
            }

            if (isCorrect)
            {
                if (triggerText != null)
                {
                    triggerText.text = "Trigger: Complete";
                    StartCoroutine(ShowTriggerMessage("Complete!", 3.0f));
                    ResetList();
                }
                isTriggerCompleted = true;
            }
            else
            {
                if (triggerText != null)
                {
                    triggerText.text = "Trigger: Incorrect. Try again.";
                    StartCoroutine(ShowTriggerMessage("Incorrect, try again.", 3.0f));
                    ResetList();
                }
            }
        }
    }

    private IEnumerator ShowTriggerMessage(string message, float duration)
    {
        if (messageText != null)
        {
            messageText.text = message;
            yield return new WaitForSeconds(duration);
            messageText.text = "";
        }
    }

    public void ToggleUI()
    {
        isUIOpen = !isUIOpen;
        uiPanel.SetActive(isUIOpen);
    }

    public bool HasItems(params string[] itemsToCheck)
    {
        foreach (string item in itemsToCheck)
        {
            if (!selectedWords.Contains(item))
            {
                return false; 
            }
        }
        return true; 
    }

    public void ButtonClicked(string word)
    {
        AddToSelectedWords(word);
        SaveList();
    }

    void AddToSelectedWords(string word)
    {
        selectedWords.Add(word);
        listText.text = "List: " + string.Join(", ", selectedWords.ToArray());
    }

    public void SaveList()
    {
        // Save the list of selected words using PlayerPrefs
        string selectedWordsJson = JsonUtility.ToJson(selectedWords);
        PlayerPrefs.SetString("SelectedWords", selectedWordsJson);
        PlayerPrefs.Save();
    }

    public void LoadList()
    {
        if (PlayerPrefs.HasKey("SelectedWords"))
        {
            string selectedWordsJson = PlayerPrefs.GetString("SelectedWords");
            selectedWords = JsonUtility.FromJson<List<string>>(selectedWordsJson);
            listText.text = "List: " + string.Join(", ", selectedWords.ToArray());
        }
    }

    public void ResetList()
    {
        selectedWords.Clear();
        listText.text = "List: ";
        PlayerPrefs.DeleteKey("SelectedWords");
        if (triggerText != null)
        {
            triggerText.text = ""; 
        }
        isTriggerCompleted = false; 
    }
}
