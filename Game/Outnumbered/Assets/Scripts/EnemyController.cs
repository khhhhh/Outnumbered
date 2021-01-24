using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody myRB;
    public float moveSpeed;

    public Invector.vCharacterController.vThirdPersonController player;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody>();
        player = FindObjectOfType<Invector.vCharacterController.vThirdPersonController>();
    }
    void FixedUpdate()
    {
        myRB.velocity = (transform.forward * moveSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
    }
}
