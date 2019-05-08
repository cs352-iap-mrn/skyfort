using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public Transform target;
    public Transform bullet;

    private Vector3 storedPos;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            storedPos = target.position;
            if (Vector3.Distance(transform.position, target.position) > 0.75)
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
                target.SendMessageUpwards("AddHealth", -damage);

                Destroy(gameObject);
            }
        } else
        {
            if (Vector3.Distance(transform.position, storedPos) > 0.75)
            {
                Rigidbody rigidBody = GetComponent<Rigidbody>();
                if (rigidBody != null)
                {
                    rigidBody.velocity = Vector3.Normalize(storedPos - transform.position) * 45.0f;
                    if (bullet != null)
                    {
                        bullet.LookAt(target);
                    }
                }
            } else
            {
                Destroy(gameObject);
            }
        }
    }
}
