using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public bool isInvincible = false;
    public SpriteRenderer graphics;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
            
    }

    public void TakeDamage (int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());            
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        float delay = .3f;
        while(isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(delay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(delay);
            delay -= .1f;
            if (delay < .1f) isInvincible = false;
        }
    }
}
