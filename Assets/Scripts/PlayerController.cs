using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 playerPos;
    private Rigidbody rd;
    [SerializeField]
    private float speed;
    private float forwardSpeed = 20f;

    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
        //AlwaysGoForward();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        playerPos.x = Input.GetAxisRaw("Horizontal");
        playerPos.z = Input.GetAxisRaw("Vertical");

        rd.velocity = playerPos * speed;
    }

    private void AlwaysGoForward()
    {
        rd.AddForce(Vector3.forward * forwardSpeed);
    }
}
