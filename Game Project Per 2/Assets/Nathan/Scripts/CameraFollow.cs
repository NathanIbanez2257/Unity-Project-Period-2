using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Vector3 offset = new Vector3(0f, 0f, -10f);
    //public float smoothTime = .25f;
    private Vector3 velocity = Vector3.zero;
    public float offsetY = 0f;

    [SerializeField] private Transform target;
    
    // Update is called once per frame
    void Update()
    {
        //Vector3 tagetPosition = target.position + offset;
        //transform.position = Vector3(transform.position, tagetPosition, ref velocity, smoothTime);

        transform.position = new Vector3(target.position.x, offsetY, target.position.z - 10);
    }
}
