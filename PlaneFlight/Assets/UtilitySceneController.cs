using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UtilitySceneController : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("GameScene");
    }
}
