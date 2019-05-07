﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Transform target;
    public Transform bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.position) > 0.25)
            {
                Rigidbody rigidBody = GetComponent<Rigidbody>();
                if (rigidBody != null)
                {
                    rigidBody.velocity = Vector3.Normalize(target.position - transform.position) * 45.0f;
                    if (bullet != null)
                    {
                        bullet.LookAt(target);
                    }
                }
            } else
            {
                Destroy(gameObject);
            }
        } else
        {
            Destroy(gameObject);
        }
    }
}