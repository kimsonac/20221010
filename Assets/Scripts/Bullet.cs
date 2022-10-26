using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rd;
    private float speed = 100f;

    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rd.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
