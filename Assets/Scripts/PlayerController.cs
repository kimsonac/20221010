using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform shotPosition;
    [SerializeField] private GameObject VFX_Engine;
    [SerializeField] private GameObject bullet;

    [SerializeField] private float speed;
    [SerializeField] private float mouseSpeed;
    [SerializeField] private float boost;

    private Vector3 playerPos;
    private Vector3 camearaRot;
    private bool stop = true;
    private float curSpeed;


    private void Start()
    {
        curSpeed = speed;
        GameManager.gameManager.OnPlayerBoost += ChangeMovingSpeed;
        GameManager.gameManager.OnPlayerStop += MoveState;
    }

    private void Update()
    {
        if (!stop)
        {
            MouseRotation();
            Move();

            if (Input.GetButtonDown("Fire1"))
            {
                Shot();
            }

        }
        
    }

    public void MoveState(bool state)
    {
        stop = state;
    }
    public void ChangeMovingSpeed(float a)
    {
        curSpeed += boost;
        Debug.Log($"[ITEM BUFF] current speed: {curSpeed}");
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
        transform.position += playerPos * curSpeed * Time.deltaTime;
    }

    private void Shot()
    {
        var obj = Instantiate(bullet, shotPosition.position, transform.rotation);
        Destroy(obj, 3f);
    }


}
