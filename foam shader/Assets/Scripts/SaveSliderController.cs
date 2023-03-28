using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSliderController : MonoBehaviour
{
    public Slider slider;
    public float speed = 0.5f;

    public Button saveButton;
   // public float boostValue = 10.0f;

    private float currentValue = 0.0f;
    private bool isSliderComplete = false;

    private void Start()
    {
        saveButton.interactable = false;
    }

    private void Update()
    {
        if (!isSliderComplete)
        {
            currentValue += Time.deltaTime * speed;
            slider.value = currentValue;

            if (currentValue >= 1.0f)
            {
                OnSliderComplete();
            }
        }
    }

    public void BoostSliderValue(float b)
    {
        if (!isSliderComplete)
        {
            currentValue = Mathf.Clamp01(currentValue + b / slider.maxValue);
            slider.value = currentValue;
        }
    }

    public void ResetSlider()
    {
        currentValue = 0.0f;
        slider.value = currentValue;
        isSliderComplete = false;
        saveButton.interactable = false;
    }

    private void OnSliderComplete()
    {
        isSliderComplete = true;
        Debug.Log("Slider is complete!");
        saveButton.interactable = true;
    }
}
