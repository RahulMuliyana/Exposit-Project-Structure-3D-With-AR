using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Array to hold the objects
    public GameObject[] objects;

    // Function to turn on one object by name and turn off the others
    public void OnThisUI(string name)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                obj.SetActive(obj.name == name);
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

}
