using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 playerPos;
    private Vector3 camearaRot;
    private Rigidbody rd;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float mouseSpeed;
    [SerializeField]
    private float boost;
    [SerializeField]
    private Transform startPosition;
    [SerializeField]
    private GameObject VFX_Engine;

    //[SerializeField]
    //private float positionPitchFactor = -2f;
    //[SerializeField]
    //private float positionYawFactor = 2f;
    //[SerializeField]
    //private float controlPitchFactor = -15f;
    //[SerializeField]
    //private float controlRollFactor = -20f;

    //private float pitch, yaw, roll;


    private void Awake()
    {
        rd = GetComponent<Rigidbody>();
        playerPos = transform.position;
    }
    private void Update()
    {
        MouseRotation();
        Move();

        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    private void MouseRotation()
    {
        camearaRot.x = -Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed; // 마우스 위아래
        //camearaRot.x += camearaRot.x;
        camearaRot.x = transform.eulerAngles.x + camearaRot.x;

        //camearaRot.x = Mathf.Clamp(camearaRot.x, -45, 45) * (-1); // Clamp: 값의 범위를 제한하는 함수 (변수, 최소, 최대)
        // -90도~90도로 방향 제한

        
        camearaRot.y = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed; // 마우스 좌우 > y
        
        camearaRot.y = transform.eulerAngles.y + camearaRot.y;

       

        //Debug.Log(camearaRot);
        transform.eulerAngles = camearaRot;
    }

    
    private void Move()
    {
        playerPos = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        transform.position += playerPos * speed * Time.deltaTime;
    }

    private void Shot()
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Debug.Log($"collision exit {collision.gameObject.tag}");
            transform.position = startPosition.position;
        }

        else if (collision.gameObject.CompareTag("Goal"))
        {
            VFX_Engine.SetActive(false);
        }
    }
}
