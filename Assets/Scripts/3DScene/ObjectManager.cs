using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] Models;

    public void OnThisModel(string YourObject)
    {
        if(Models != null)
        {
            foreach(GameObject obj in Models)
            {
                obj.SetActive(obj.name == YourObject);
            }
        }
    }
}
