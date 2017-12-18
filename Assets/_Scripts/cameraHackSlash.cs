using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraHackSlash : MonoBehaviour {

	public GameObject Player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int distAwat = 10;
		Vector3 POS = Player.transform.position;
		GameObject.Find ("Main Camera").transform.position = new Vector3 (POS.x-10, POS.y+5, POS.z);
	}
}
