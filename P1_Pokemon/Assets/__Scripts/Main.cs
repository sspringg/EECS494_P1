﻿using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {


	static public Main S;
	
	public bool inDialog = false;
	public bool paused = false;
	
	void Awake(){
		S = this;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!inDialog && Input.GetKeyDown(KeyCode.Space)){
			Menu.S.gameObject.SetActive(true);
			
			paused = true;
		}
	}
}
