using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Rigidbody rd;
    private Vector3 startPosition;
    private float speed = 100f;

    private void Awake()
    {
        startPosition = transform.position;
        rd = GetComponent<Rigidbody>();
        rd.mass = Random.Range(0.1f, 1);
    }
    private void Start()
    {
        rd.AddForce(-transform.forward * speed, ForceMode.Impulse);
    }

    private void Update()
    {
        if(transform.position.y <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        transform.position = startPosition;
    }

}
