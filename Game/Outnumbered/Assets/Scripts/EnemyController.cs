using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRB;
    public float moveSpeed;
    public bool move;
    public Animator animator;
    //private Vector3 fixLook;
    public Invector.vCharacterController.UserControl player;
    public PlayerHealthManager playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        //fixLook = new Vector3(0, 1f, 0);
        animator = GetComponent<Animator>();
        move = true;
        myRB = GetComponent<Rigidbody>();
        player = FindObjectOfType<Invector.vCharacterController.UserControl>();
        playerHealth = FindObjectOfType<PlayerHealthManager>();
    }
    void FixedUpdate()
    {
        if (move)
        {
            myRB.velocity = (transform.forward * moveSpeed);
            animator.SetBool("seeEnemy", true);

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(move)
            transform.LookAt(player.transform.position /*+ fixLook*/);
        if (playerHealth.isDead)
            animator.SetBool("seeEnemy", false);
    }
}
