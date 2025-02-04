using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LabelManager : MonoBehaviour
{
    [Header("You Can use Text Or Button")]
    public GameObject[] ObjectLabel;
    public Button EnableLabelButton;
    public Button DisableLabelButton;


    public void Start()
    {
        EnableLabelButton.onClick.AddListener(() => EnableLabelClicked()); // Add listener to button click event
        DisableLabelButton.onClick.AddListener(() => disableLabelClicked()); // Add listener to button click event
        for (int i = 0; i < ObjectLabel.Length; i++)
        {
            if (ObjectLabel[i] != null)
            {
                ObjectLabel[i].gameObject.SetActive(false);
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            OnLabel();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            OffLabel();
        }
        for (int i = 0; i < ObjectLabel.Length; i++)
        {
            if (ObjectLabel[i] != null)
            {
                ObjectLabel[i].transform.LookAt(Camera.main.transform);
                ObjectLabel[i].transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
            }
        }
    }

    public void OnLabel()
    {
        // For On the All Label
        for (int i = 0; i < ObjectLabel.Length; i++)
        {
            if (ObjectLabel[i] != null)
            {
                ObjectLabel[i].gameObject.SetActive(true);
            }
        }
    }

    public void OffLabel()
    {
        // For Off the All Label
        for (int i = 0; i < ObjectLabel.Length; i++)
        {
            if (ObjectLabel[i] != null)
            {
                ObjectLabel[i].gameObject.SetActive(false);
            }
        }
    }
    public void EnableLabelClicked()
    {
        
        EnableLabelButton.gameObject.SetActive(false);
        DisableLabelButton.gameObject.SetActive(true);
        OnLabel();

    }
    public void disableLabelClicked()
    {
        
        EnableLabelButton.gameObject.SetActive(true);
        DisableLabelButton.gameObject.SetActive(false);
        OffLabel();
    }

}
