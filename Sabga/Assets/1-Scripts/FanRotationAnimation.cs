using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotationAnimation : MonoBehaviour
{
    // Public variable to control rotation speed
    public float rotationSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the Y-axis
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
