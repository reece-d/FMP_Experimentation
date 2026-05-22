using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class EnemySound : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip deathSound;       // Assign in Inspector
    public float deathSoundVolume = 1f;

    [Header("Enemy Settings")]
    public int health = 100;

    private bool isDead = false;

    // Call this method when the enemy takes damage
    public void TakeDamage(int damage)
    {
        if (isDead) return; // Prevent multiple death triggers

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        if (deathSound != null)
        {
            // Create a temporary audio object so sound plays even after enemy is destroyed
            GameObject audioObj = new GameObject("DeathSound");
            AudioSource audioSource = audioObj.AddComponent<AudioSource>();
            audioSource.clip = deathSound;
            audioSource.volume = Mathf.Clamp01(deathSoundVolume);
            audioSource.Play();

            // Destroy the temporary object after the clip finishes
            Destroy(audioObj, deathSound.length);
        }

        // Destroy enemy object
        Destroy(gameObject);
    }
}


