using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 horzontal = new Vector3(Input.GetAxis("Horizontal"),0.0f,0.0f);
        transform.position = transform.position + horzontal *Time.deltaTime* speed;
    }
}
