using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    public CharacterController2D controller;
    public float speed = 40f;
    float horizontalMove = 0f;
    bool Jump =  false;
    bool Crouch = false;
    public Animator animator;
    private Transform pos;
    // Start is called before the first fra me update    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal")*speed;
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
                Jump = true;
                animator.SetBool("isJumping",true);
        }
        if(Input.GetButtonDown("Crouch")){
            Crouch = true;
             Debug.Log("True");
        } else if (Input.GetButtonUp("Crouch")){
            Crouch = false;
            Debug.Log("False");
        }   
        if(Input.GetButtonDown("Fire1")){
            animator.SetBool("Atk",true);
            
        }else if (Input.GetButtonUp("Fire1")){
            
            animator.SetBool("Atk",false);
        }
        
    }
    public void OnLanding(){
        
        animator.SetBool("isJumping",false);
        
    }

    void FixedUpdate(){

        controller.Move(horizontalMove*Time.fixedDeltaTime,Crouch,Jump);
        
        Jump = false;
        

    }

    

   
}
