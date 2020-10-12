using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public bool startingRandomRotation = true;

    public bool rotating = false;
    public float rotationSpeed = 10f;

    private void Start()
    {
        if (startingRandomRotation)
        {
            transform.Rotate(transform.forward, Random.Range(0f, 360f), Space.World);
        }
    }

    private void Update()
    {
        if (rotating)
        {
            Rotate();
        }
    }

    public void Rotate()
    {
        transform.Rotate(transform.forward, rotationSpeed * Time.deltaTime, Space.World);
    }

}
