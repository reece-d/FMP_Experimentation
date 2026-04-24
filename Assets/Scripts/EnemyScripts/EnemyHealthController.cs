using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Generic health controller that can be used for enemies, players, or objects.
/// </summary>
public class EnemyHealthController : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private float _currentHealth = 100f;
    [SerializeField] private float _maximumHealth = 100f;

    public float RemainingHealthPercentage => _currentHealth / _maximumHealth;
    public bool IsInvincible { get; set; }

    [Header("Events")]
    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;

    /// <summary>
    /// Apply damage to the enemy.
    /// </summary>
    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth <= 0 || IsInvincible) return;

        _currentHealth -= damageAmount;
        OnHealthChanged?.Invoke();

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDied?.Invoke();
        }
        else
        {
            OnDamaged?.Invoke();
        }
    }

    /// <summary>
    /// Heal the enemy.
    /// </summary>
    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth >= _maximumHealth) return;

        _currentHealth += amountToAdd;
        OnHealthChanged?.Invoke();

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }

    /// <summary>
    /// Reset health to maximum.
    /// </summary>
    public void ResetHealth()
    {
        _currentHealth = _maximumHealth;
        OnHealthChanged?.Invoke();
    }
    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}