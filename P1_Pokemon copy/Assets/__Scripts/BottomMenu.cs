﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum bMenuItem {
	fight,
	pkmn,
	item,
	run
}

public class BottomMenu : MonoBehaviour {

	public static BottomMenu S;

	public int activeItem;
	public List<GameObject> menuItems;
	
	void Awake(){
		S = this;
	}
	// Use this for initialization
	void Start () {
		bool first = true;
		activeItem = 0;
		
		foreach (Transform child in transform) {
			menuItems.Add (child.gameObject);
		}
		menuItems = menuItems.OrderByDescending(m => m.transform.position.y).ToList();
		
		foreach (GameObject go in menuItems) {
			GUIText itemText = go.GetComponent<GUIText> ();
			if (first)
				itemText.color = Color.red;
			first = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			switch(activeItem){
			case(int)bMenuItem.fight:
				print("Fight selected");
				FightMenuSelected();
				break;
			case(int)bMenuItem.pkmn:
				print("Pkmn selected");
				break;
			case(int)bMenuItem.item:
				print("Item selected");
				break;
			case(int)bMenuItem.run:
				print("Run selected");
				break;
			}
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			MoveDownMenu();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow)){
			MoveUpMenu();
		}
	}
	public void MoveDownMenu(){
		menuItems[activeItem].GetComponent<GUIText>().color = Color.black;
		activeItem = activeItem == menuItems.Count - 1 ? 0: ++activeItem;
		menuItems[activeItem].GetComponent<GUIText>().color = Color.red;	
	}
	public void MoveUpMenu(){
		menuItems[activeItem].GetComponent<GUIText>().color = Color.black;
		activeItem = activeItem == 0 ? menuItems.Count - 1: --activeItem;
		menuItems[activeItem].GetComponent<GUIText>().color = Color.red;	
	}

	public void FightMenuSelected(){
		gameObject.SetActive (false);
		AttackMenu.S.gameObject.SetActive (true);
		AttackMoveView.S.gameObject.SetActive (true);
	}

}
