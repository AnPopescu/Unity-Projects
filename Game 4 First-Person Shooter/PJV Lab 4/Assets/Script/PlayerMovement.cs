using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public CharacterController controller;

    public Transform GrounCk;
    public float groundDistance = 0.4f;

    public LayerMask groundMask ;
    public bool isGrounded;
    public float jumpHeight =3f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        isGrounded = Physics.CheckSphere(GrounCk.position,groundDistance,groundMask);

        if(isGrounded&&velocity.y<0)
        {
            velocity.y=-2f;
        }

        Vector3 move = transform.right* x + transform.forward *z;
        if(Input.GetKeyDown("left shift"))
        {
            speed = 20f;
                } else if(Input.GetKeyUp("left shift")){
                speed = 12f;
                }
        controller.Move(move*speed*Time.deltaTime);
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*gravity);
            Debug.Log("Sare");
        }
        velocity.y+= gravity * Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);



    }
}
