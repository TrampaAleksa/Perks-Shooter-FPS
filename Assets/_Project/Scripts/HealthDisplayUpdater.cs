using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayUpdater : MonoBehaviour
{
    public Text displayText;
    public Health playerHealth;

    private void Start()
    {
        displayText.text = playerHealth.CurrentHealth.ToString();
    }

    public void UpdateHealthDisplayValue(long value)
    {
        displayText.text = value.ToString();
    }
}
