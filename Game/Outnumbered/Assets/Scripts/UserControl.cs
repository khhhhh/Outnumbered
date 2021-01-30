using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Invector.vCharacterController
{
    public class UserControl : MonoBehaviour
    {
        private Rigidbody m_Character;
        public float moveSpeed;
        private Vector3 m_Move;
        private Vector3 m_CamForward;
        private Vector3 moveInput;
        private Vector3 moveVelocity;
        private Transform m_Cam;
        private Camera mainCamera;
        Animator animator;

        public GunController gun;

        // Start is called before the first frame update
        void Start()
        {
            m_Character = GetComponent<Rigidbody>();
            mainCamera = FindObjectOfType<Camera>();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput.normalized * moveSpeed;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, transform.position);
            //Plane groundPlane = new Plane(new Vector3(-49.54f, 0f, 0f), transform.position);

            if (moveVelocity != Vector3.zero)
                animator.SetBool("Walk", true);
            else
                animator.SetBool("Walk", false);

            m_Character.velocity = moveVelocity;

            float hitdist = 0.0f;
            if (groundPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100 * Time.deltaTime);
            }


            if (Input.GetMouseButtonDown(0))
                gun.isFiring = true;

            if (Input.GetMouseButtonUp(0))
                gun.isFiring = false;
        }

        private void FixedUpdate()
        {

            // read inputs
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
            m_Move = v * transform.forward + h * transform.right;


        }
    }
}