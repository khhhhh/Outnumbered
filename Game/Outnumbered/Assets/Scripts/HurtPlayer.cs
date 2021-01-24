using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive;
    private int timeOfAttack = 5;
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
            enemyController.animator.SetBool("attack", true);
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToGive);
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
}
