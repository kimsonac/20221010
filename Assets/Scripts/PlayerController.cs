using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform shotPosition;
    [SerializeField] private GameObject VFX_Engine;
    [SerializeField] private GameObject VFX_Item;
    [SerializeField] private GameObject bullet;

    [SerializeField] private float speed;
    [SerializeField] private float mouseSpeed;
    [SerializeField] private float boost;

    private Vector3 playerPos;
    private Vector3 camearaRot;
    private bool stop = true;
    private float curSpeed;
    private bool enter = false;


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
        if (!enter)
        {
            enter = true;
            VFX_Item.SetActive(true);
            curSpeed += boost;
            Debug.Log($"[ITEM BUFF] current speed: {curSpeed}");
            StartCoroutine(_InactiveVFX());
        }
        
    }

    private IEnumerator _InactiveVFX()
    {
        yield return new WaitForSeconds(1f);
        VFX_Item.SetActive(false);
        enter = false;
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
