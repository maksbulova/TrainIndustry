using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Text energyLabel;
    public static int energyLevel;

    private void Awake()
    {
        energyLabel = GetComponent<Text>();
        energyLevel = 0;
    }

    private void Update()
    {
        energyLabel.text = "energy Level: " + energyLevel;
    }
}
