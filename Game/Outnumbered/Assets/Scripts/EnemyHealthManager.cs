using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int health;
    private int currentHealth;

    public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            enemyController.animator.SetBool("dead", true);
            enemyController.move = false;
            //Destroy(gameObject);
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
    }
}
