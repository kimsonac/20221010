using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;
    private Rigidbody rd;
    
    private void Start()
    {
        rd = GetComponent<Rigidbody>();

        rd.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

}
