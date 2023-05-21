using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 _velocity = Vector3.zero;

    [Header("Camera Offset")]
    [SerializeField] float _offsetY = 0f;


    [Header("Camera Focus")]
    [SerializeField] private Transform _target;


    void Update()
    {
        transform.position = new Vector3(_target.position.x, _offsetY, _target.position.z - 10);
    }
}
