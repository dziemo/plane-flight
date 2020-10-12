using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float distanceMultiplier = 2f;
    
    public FloatRuntimeVariable distance;
    
    private void Update()
    {
        distance.RuntimeValue += Time.deltaTime * distanceMultiplier;
    }

    public void OnEndGame ()
    {
        SceneManager.LoadScene("UtilityScene");
    }
}
