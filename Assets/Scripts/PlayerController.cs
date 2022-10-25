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
    private float tilt;
    [SerializeField]
    private float boost;
   
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
        // Move();
        MouseRotation();
        Move2();
    }

    private void Move()
    {
        playerPos.x = Input.GetAxisRaw("Horizontal"); // ��
        playerPos.z = Input.GetAxisRaw("Vertical"); // �յ�

        //TODO: �����̽� ������ ���� �ö󰡱� > ����2d
        //TODO: ȸ���� ����...

        //Debug.Log(playerPos);
        rd.velocity = playerPos * speed;
        transform.GetChild(0).rotation = Quaternion.Euler(0.0f, 0.0f, rd.velocity.x * -tilt);
        
    }

    
    private void MouseRotation()
    {
        camearaRot.x = -Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed; // ���콺 ���Ʒ�
        //camearaRot.x += camearaRot.x;
        camearaRot.x = transform.eulerAngles.x + camearaRot.x;

        //camearaRot.x = Mathf.Clamp(camearaRot.x, -45, 45) * (-1); // Clamp: ���� ������ �����ϴ� �Լ� (����, �ּ�, �ִ�)
        // -90��~90���� ���� ����

        
        camearaRot.y = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed; // ���콺 �¿� > y
        
        camearaRot.y = transform.eulerAngles.y + camearaRot.y;

       

        //Debug.Log(camearaRot);
        transform.eulerAngles = camearaRot;
    }

    
    private void Move2()
    {
        playerPos = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        transform.position += playerPos * speed * Time.deltaTime;
    }
}
