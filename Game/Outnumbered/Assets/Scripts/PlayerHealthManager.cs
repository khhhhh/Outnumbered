using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void HurtPlayer(int damage)
    {
        currnetHealth -= damage;
        healthBar.SetHealth(currnetHealth);
    }
}
