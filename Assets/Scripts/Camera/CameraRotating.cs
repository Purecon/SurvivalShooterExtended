using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotating : MonoBehaviour
{
    public float oscillationHeight = 0.5f;
    public float oscillationSpeed = 2.0f;
    public float rotationSpeed = 90.0f;
    // The starting position of the object.
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = startPosition + (Vector3.up * oscillationHeight * Mathf.Cos(Time.timeSinceLevelLoad * oscillationSpeed));
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
