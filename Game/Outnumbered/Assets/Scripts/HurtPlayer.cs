using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    public int timeOfAttack = 2;
    private int time;

    public EnemyController enemyController;
    void Start()
    {
    }

    void Update()
    {
        time = (int)Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            time = (int)Time.deltaTime;
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AttackPlayer(2, other);
            enemyController.animator.SetBool("attack", true);
            enemyController.move = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemyController.move = true;
            enemyController.animator.SetBool("attack", false);
        }
    }


    private void AttackPlayer(float t, Collider other)
    {
        other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
    }
}
