using UnityEngine;
using UnityEngine.UI;

public class ButtonClickAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    private void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>(); // Find all Button components in the scene.

        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => PlayAudio());
        }
    }

    private void PlayAudio()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
