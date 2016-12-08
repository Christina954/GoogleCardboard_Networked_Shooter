﻿using UnityEngine;
using System.Collections;

public class animationTest : MonoBehaviour {
	Animator anim;
	int shootHash = Animator.StringToHash("Shoot");
	int runStateHash = Animator.StringToHash("Base Layer.Run");



	void Start ()
	{
		anim = GetComponent<Animator>();
	}


	void Update ()
	{
		float move = Input.GetAxis ("Vertical");
		anim.SetFloat("Speed", move);

		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

		if(Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetTrigger (shootHash);
		}
	}
}