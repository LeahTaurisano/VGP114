using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 playerPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, playerPosition, ref velocity, smoothSpeed);
    }
}
