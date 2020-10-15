using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public FloatVariable ringRadius;
    public FloatRuntimeVariable playerSpeed;
    public GameEvent endGame;

    public float zTurnTilt = 15;
    public float turnSpeed = 2f;

    Camera cam;
    Vector3 newPos;
    
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
        }
    }

    void Move ()
    {
#if UNITY_EDITOR
        
#endif
        if (Input.touchCount > 0)
        {
            Vector3 mousePosRaw = Input.GetTouch(0).position;
            mousePosRaw.z = -cam.transform.position.z;
            Vector2 mousePos = cam.ScreenToWorldPoint(mousePosRaw);
            newPos = mousePos.normalized * ringRadius.Value;
        }

        if (newPos != Vector3.zero && Vector3.Distance(newPos, transform.position) > 0.25f)
        {
            transform.position = Vector3.Slerp(transform.position, newPos, playerSpeed.RuntimeValue * Time.deltaTime);

            var xDiff = (newPos - transform.position).x;

            if (xDiff < 0)
            {
                transform.DORotate(new Vector3(0, 0, zTurnTilt), 2f);
            }
            else if (xDiff > 0)
            {
                transform.DORotate(new Vector3(0, 0, -zTurnTilt), 2f);
            }
        }
        else
        {
            transform.DORotate(Vector3.zero, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            endGame.Raise();
            OnEndGame();
        }
    }

    public void OnEndGame()
    {
        alive = false;
    }
}
