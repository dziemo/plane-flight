using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class PlayerController : MonoBehaviour
{
    public FloatRuntimeVariable playerSpeed;

    public float zTurnTilt = 15;
    public float turnSpeed = 2f;

    Camera cam;
    Vector3 newPos;

    public FloatVariable ringRadius;

    bool alive;

    private void Start()
    {
        cam = Camera.main;
        transform.position = new Vector3(ringRadius.Value, 0, 0);
        newPos = transform.position;
        alive = true;
    }
    
    void Update()
    {
        if (alive)
        {
            Move();
        } else
        {
            transform.position = Vector3.Slerp(transform.position, newPos, playerSpeed.RuntimeValue/4 * Time.deltaTime);
        }
    }

    void Move ()
    {
        if (Input.touchCount > 0)
        {
            Vector3 mousePosRaw = Input.GetTouch(0).position;
            mousePosRaw.z = -cam.transform.position.z;
            Vector2 mousePos = cam.ScreenToWorldPoint(mousePosRaw);
            newPos = mousePos.normalized * ringRadius.Value;
        }

        if (newPos != Vector3.zero && newPos != transform.position)
        {
            transform.position = Vector3.Slerp(transform.position, newPos, playerSpeed.RuntimeValue * Time.deltaTime);

            var xDiff = (newPos - transform.position).x;

            if (xDiff < 0)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, zTurnTilt), turnSpeed * Time.deltaTime);
            } else if (xDiff > 0)
            {
                transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0, 0, -zTurnTilt), turnSpeed * Time.deltaTime);
            }
        } else
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.identity, turnSpeed * Time.deltaTime);
        }
    }

    public void OnEndGame()
    {
        alive = false;
        newPos = new Vector3(0, -10, 5);
    }
}
