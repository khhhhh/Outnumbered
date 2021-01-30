using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    private int currnetHealth;
    public bool isDead;
    Animator animator;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currnetHealth = startingHealth;
        healthBar.SetMaxHealth(startingHealth);
        isDead = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currnetHealth <= 0)
        {
            isDead = true;
            
            //gameObject.SetActive(false);
            SceneManager.LoadScene(5);
        }
    }

    public void HurtPlayer(int damage)
    {
        currnetHealth -= damage;
        healthBar.SetHealth(currnetHealth);
    }
}
