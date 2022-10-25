using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float xRange = 20f;
    float yRange = 5f;

    [SerializeField]
    private float speed;
    //[SerializeField]
    //private float tilt;
    //[SerializeField]
    //private float boost;
    [SerializeField]
    private float positionPitchFactor = -2f;
    [SerializeField]
    private float positionYawFactor = 2f;
    [SerializeField]
    private float controlPitchFactor = -15f;
    [SerializeField]
    private float controlRollFactor = -20f;

    private float pitch, yaw, roll;
    private float xThrow, yThrow;

    private void Update()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        //ProcessPosition();
        ProcessRotation();
    }

    private void ProcessPosition()
    {
        float xOffset = xThrow * Time.deltaTime * speed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * speed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawXPos, -yRange, yRange);
    }
    private void ProcessRotation()
    {
        pitch = (transform.localPosition.y * positionPitchFactor) + (yThrow * controlPitchFactor);
        yaw = transform.localPosition.x * positionYawFactor;
        roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(0, yaw, roll);

    }

}
