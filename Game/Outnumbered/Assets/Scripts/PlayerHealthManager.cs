using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int startingHealth;
    public int currnetHealth;

    // Start is called before the first frame update
    void Start()
    {
        currnetHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currnetHealth <= 0)
            gameObject.SetActive(false);
    }

    public void HurtPlayer(int damage)
    {
        currnetHealth -= damage;
    }
}
