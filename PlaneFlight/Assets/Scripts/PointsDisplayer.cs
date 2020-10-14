using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsDisplayer : MonoBehaviour
{
    public IntRuntimeVariable variable;
    public TextMeshProUGUI textDisplayer;

    public void OnPointCollected ()
    {
        textDisplayer.text = variable.RuntimeValue.ToString();
    }
}
