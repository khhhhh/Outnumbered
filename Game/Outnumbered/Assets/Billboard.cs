using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //public Transform cam;
    Camera m_MainCamera;

    void Start()
    {
        m_MainCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_MainCamera.transform.forward);
    }
}
