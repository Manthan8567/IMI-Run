using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform target;
    public float speed = 0.5f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desireposition = target.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, desireposition, speed);
        smoothposition.y = 0;
        transform.position = smoothposition;
    }
}
