
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyrmHealth : MonoBehaviour
{
    public GameObject Wrym;
    public int maxHealth = 100;
    public int currentHealth;
    public SkinnedMeshRenderer[] bodyParts;
    public Material red;

    private bool isRed = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {   
        // Check if the enemy is defeated
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(Wrym);
    }

    public bool checkIfRed()
    {
        return isRed;
    }

    public IEnumerator FlashRed()
    {
        
        isRed = true;
        List<Material> OGMats = new();
        foreach (var bodyPart in bodyParts)
        {
            if(bodyPart)
            {
                OGMats.Add(bodyPart.material);
                bodyPart.material = red;
            }
        }
        yield return new WaitForSeconds(0.5f);
        for(int i = 0; i < bodyParts.Length; i++)
        {
            if(bodyParts[i] != null)
            {
                bodyParts[i].material = OGMats[i];
            }
        }
        isRed = false;
    }
}