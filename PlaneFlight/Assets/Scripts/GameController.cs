using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float distanceMultiplier = 2f;
    
    public FloatRuntimeVariable distance;

    bool gameInProgress = true;

    private void Update()
    {
        if (gameInProgress)
        {
            distance.RuntimeValue += Time.deltaTime * distanceMultiplier;
        }
    }

    public void OnEndGame ()
    {
        gameInProgress = false;
        SceneManager.LoadScene("UtilityScene");
    }
}
