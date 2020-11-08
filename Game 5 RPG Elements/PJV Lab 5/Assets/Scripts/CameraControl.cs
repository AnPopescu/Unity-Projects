using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform targetToFollow;
    public Vector3 offset;
    public float pitch;
    public float yawSpeed = 100f;
    private float yawInput = 0f;


    private float currentZoom = 10f;
    void LateUpdate(){

        transform.position = targetToFollow.position - offset * currentZoom;
        transform.LookAt(targetToFollow.position + Vector3.up * pitch);
        transform.RotateAround(targetToFollow.position, Vector3.up ,yawInput);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yawInput -= Input.GetAxis("Horizontal")*yawSpeed *Time.deltaTime;
    }
}
