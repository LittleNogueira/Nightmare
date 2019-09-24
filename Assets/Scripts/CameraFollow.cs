using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;
    public float smoothing = 5;
    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        Vector3 targetCamPos = target.transform.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
