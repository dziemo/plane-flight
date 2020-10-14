using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour
{
    public GameEvent onStarCollected;
    public IntRuntimeVariable playerStars;
    public int starsToCollect = 1;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerStars.RuntimeValue += starsToCollect;
            onStarCollected.Raise();
            Destroy(gameObject);
        }
    }
}
