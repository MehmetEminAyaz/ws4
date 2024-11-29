using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    public Image healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthbar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        healthBar.fillAmount = currentHealth / maxHealth;
        Debug.Log("Healthbar Updated: " + healthBar.fillAmount);
    }

    private void Die()
    {
        GameMaster.Instance.AddScore(10);
        Destroy(gameObject);
    }
}
