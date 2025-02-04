using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Speed of rotation
    public float rotationSpeed = 100.0f;


    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);


    }
}
