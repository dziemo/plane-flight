using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceDisplayer : MonoBehaviour
{
    public FloatRuntimeVariable distance;
    public TextMeshProUGUI distanceText;

    private void Update()
    {
        distanceText.text = (int)distance.RuntimeValue + "m"; 
    }
}
