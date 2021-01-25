using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    private int currnetHealth;
    public bool isDead;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currnetHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currnetHealth <= 0)
        {
            gameObject.SetActive(false);
            isDead = true;
        }
    }

    public void HurtPlayer(int damage)
    {
        currnetHealth -= damage;
        healthBar.SetHealth(currnetHealth);
    }
}
