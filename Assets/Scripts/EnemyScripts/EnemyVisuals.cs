using System.Collections;
using UnityEngine;

public class EnemyVisuals : MonoBehaviour
{
    public Renderer enemyRenderer;
    public Color damageColor = Color.red;
    public float flashDuration = 0.2f;

    private Color originalColor;

    void Start()
    {
        originalColor = enemyRenderer.material.color;
    }

    public void FlashOnDamage()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        enemyRenderer.material.color = damageColor;
        yield return new WaitForSeconds(flashDuration);
        enemyRenderer.material.color = originalColor;
    }
}
