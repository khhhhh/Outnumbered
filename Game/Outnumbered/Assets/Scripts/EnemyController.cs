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
    public Invector.vCharacterController.vThirdPersonController player;
    // Start is called before the first frame update
    void Start()
    {
        //fixLook = new Vector3(0, 1f, 0);
        animator = GetComponent<Animator>();
        move = true;
        myRB = GetComponent<Rigidbody>();
        player = FindObjectOfType<Invector.vCharacterController.vThirdPersonController>();
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
        transform.LookAt(player.transform.position /*+ fixLook*/);
    }
}
