using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 playerPos;
    private Rigidbody rd;
    [SerializeField]
    private float speed;
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
    }
    private void Update()
    {
        Move();
        ProcessRotation();
    }

    private void Move()
    {
        playerPos.x = Input.GetAxisRaw("Horizontal");
        playerPos.z = Input.GetAxisRaw("Vertical");
        //TODO: 스페이스 누르면 위로 올라가기
        //TODO: 회전값 조정...

        //Debug.Log(playerPos);
        rd.velocity = playerPos * speed;
        transform.GetChild(0).rotation = Quaternion.Euler(0.0f, 0.0f, rd.velocity.x * -tilt);
        
    }

    private void ProcessRotation()
    {
        //pitch = (transform.position.z * positionPitchFactor) + (playerPos.z * controlPitchFactor);
        //yaw = transform.localPosition.x * positionYawFactor;
        //roll = playerPos.x * controlRollFactor;

        //transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

        
    }
}
