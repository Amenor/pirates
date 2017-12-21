using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAnim : MonoBehaviour {


	Animator anim;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
	}
	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			anim.SetTrigger("Activate");
			Debug.Log ("Attack1 animation has played!");
		}
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		anim.SetTrigger("GunTrigger");
	//		Debug.Log ("Attack 2animation has played!");
	//	}
	}
}
