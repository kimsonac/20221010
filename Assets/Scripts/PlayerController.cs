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
        camearaRot = transform.eulerAngles;
    }
    private void Update()
    {
        // Move();
        MouseRotation();
        Move2();
    }

    private void Move()
    {
        playerPos.x = Input.GetAxisRaw("Horizontal"); // 옆
        playerPos.z = Input.GetAxisRaw("Vertical"); // 앞뒤

        //TODO: 스페이스 누르면 위로 올라가기 > 슈팅2d
        //TODO: 회전값 조정...

        //Debug.Log(playerPos);
        rd.velocity = playerPos * speed;
        transform.GetChild(0).rotation = Quaternion.Euler(0.0f, 0.0f, rd.velocity.x * -tilt);
        
    }

    // https://bloodstrawberry.tistory.com/603
    private void MouseRotation()
    {
        camearaRot.y = -Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSpeed; // 마우스 위아래
        camearaRot.x = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSpeed; // 마우스 양옆

        camearaRot.x = transform.eulerAngles.x + camearaRot.x;
        camearaRot.y += camearaRot.y;

        yRot = Mathf.Clamp(-90, yRot, 90); // Clamp: 값의 범위를 제한하는 함수
        // -90도~90도로 방향 제한

        transform.eulerAngles = camearaRot;
    }

    // https://itadventure.tistory.com/390#:~:text=%EA%B7%B8%EB%9F%AC%EB%82%98%20%EB%82%B4%EA%B0%80%20%EB%B0%94%EB%9D%BC%EB%B3%B4%EB%8A%94%20%EB%B0%A9%ED%96%A5,%EC%9C%BC%EB%A1%9C%20%EC%9D%B4%EB%8F%99%ED%95%98%EB%8A%94%20%EA%B2%83%EC%9E%85%EB%8B%88%EB%8B%A4.&text=%EB%B0%94%EB%9D%BC%EB%B3%B4%EB%8A%94%20%EB%B0%A9%ED%96%A5%EA%B3%BC%20%EC%95%84%EC%A3%BC,%EC%9D%B4%EB%8F%99%ED%95%98%EB%8A%94%20%ED%82%A4%EB%A1%9C%20%EC%9D%B8%EC%8B%9D%ED%95%A9%EB%8B%88%EB%8B%A4.
    private void Move2()
    {
        playerPos = transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal");
        transform.position += playerPos * speed * Time.deltaTime;
    }
}
