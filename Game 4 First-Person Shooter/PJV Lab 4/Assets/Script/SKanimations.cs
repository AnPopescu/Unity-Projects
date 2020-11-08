using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKanimations : MonoBehaviour
{
    public Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void skIdle ()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("Run", false);
		animator.SetBool ("Enemy", false);
        animator.SetBool ("IsHit",false);
	}

	public void skWalk ()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", true);
		animator.SetBool ("Run", false);
		animator.SetBool ("Enemy", false);
        animator.SetBool ("IsHit",false);
	}

	public void skRun()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("Run", true);
		animator.SetBool ("Enemy", false);
        animator.SetBool ("IsHit",false);
	}

	public void skAttack()
	{
		animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("Run", true);
		animator.SetBool ("Enemy", true);
        animator.SetBool ("IsHit",false);
	}
    public void skDmg()
    {
        animator = GetComponent<Animator>();
		animator.SetBool ("Walk", false);
		animator.SetBool ("Run", false);
		animator.SetBool ("Enemy", false);
        animator.SetBool ("IsHit",true);
    }
}


