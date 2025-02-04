using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnColorChanger : MonoBehaviour
{
    public Button[] buttons; // Array of buttons to manage
    public GameObject[] Models;
    private Color[] originalColors;
    private Image[] buttonImages;
    public Color targetColor; // The color you want to change to


    void Start()
    {
        // Initialize arrays
        originalColors = new Color[buttons.Length];
        buttonImages = new Image[buttons.Length];
       

        // Store the original colors and Image components
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != null)
            {
                buttonImages[i] = buttons[i].GetComponent<Image>();
                if (buttonImages[i] != null)
                {
                    originalColors[i] = buttonImages[i].color; // Store the original color
                    int index = i; // Capture the correct index for the lambda expression
                    buttons[i].onClick.AddListener(() => OnButtonClick(index)); // Add listener to button click event
                }
                else
                {
                    Debug.LogError("Button " + buttons[i].name + " does not have an Image component.");
                }
            }
        
        }
    }


    void OnButtonClick(int index)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttonImages[i] != null)
            {
                if (i == index)
                {
                    buttonImages[i].color = targetColor; // Change the clicked button color
                }
                else
                {
                    buttonImages[i].color = originalColors[i]; // Reset other buttons to their original color
                }
            }
        }
        for (int j = 0; j < Models.Length; j++)
        {
            if (Models[j] != null)
            {
                if (j == index)
                {
                    Models[j].SetActive(true); // Change to the selected model
                }
                else
                {
                    Models[j].SetActive(false);// Reset other model 
                }
            }
        }
    }
    
}
