
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private GameManager GM;

    void Start()
    {
        currentHealth = maxHealth;
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check if the colliding object is on a certain layer
        if (collision.gameObject.layer == 6)
        {
            // Deduct health (you can adjust the amount)
            currentHealth -= 50;

            // Check if the enemy is defeated
            if (currentHealth <= 0)
            {
                Die();
            }
            Debug.Log(currentHealth);
        }
    }

    void Die()
    {
        // Handle death, such as playing an animation, spawning particles, etc.
        GM.FirstBatDead = true;
        Destroy(gameObject);
    }
}