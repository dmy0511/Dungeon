using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float smoothSpeed = 2;

    private Transform target;
    
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
            new Vector3(target.position.x, target.position.y, -10),
            smoothSpeed * Time.deltaTime);
    }
}
