using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ButtonSound : MonoBehaviour
{
    [Header("UI Button to Attach")]
    public Button targetButton;

    [Header("Sound Clip to Play")]
    public AudioClip clickSound;

    private AudioSource audioSource;

    void Awake()
    {
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false; // Prevent auto-play
    }

    void Start()
    {
        // Validate references
        if (targetButton == null)
        {
            Debug.LogError("ButtonSound: No targetButton assigned.");
            return;
        }
        if (clickSound == null)
        {
            Debug.LogError("ButtonSound: No clickSound assigned.");
            return;
        }

        // Add listener to button click event
        targetButton.onClick.AddListener(PlayClickSound);
    }

    void PlayClickSound()
    {
        // Play the sound once
        audioSource.PlayOneShot(clickSound);
    }
}