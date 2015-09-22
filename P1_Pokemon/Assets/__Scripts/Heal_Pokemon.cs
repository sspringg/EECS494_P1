﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum Heal_list{
	Heal,
	Cancel
}

public class Heal_Pokemon : MonoBehaviour {
	public int activeItem;
	public static Heal_Pokemon S;
	public List<GameObject> Heal_lists;
	
	void Awake(){
		S = this;
	}
	void Start () {
		GameObject.Find("Heal_Pokemon/POKeBALL").SetActive(false);
		bool first = true;
		activeItem = 0;
		
		foreach(Transform child in transform){
			Heal_lists.Add (child.gameObject);
		}
		foreach(GameObject go in Heal_lists){
			GUIText itemText = go.GetComponent<GUIText>();
			if(first) itemText.color = Color.red;
			first = false; 
		}
		
		gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {
		if (Main.S.paused){
			if(Input.GetKeyDown(KeyCode.Return)){
				print(activeItem);
				switch(activeItem){ 
				case(int)Heal_list.Heal:
					Player.S.speakDictionary["Forward_Clerk"] = 3;
					Player.S.Healing_Pokemon = false;
					break;
				case(int)Heal_list.Cancel:
					Player.S.speakDictionary["Forward_Clerk"] = 6;
					Player.S.Healing_Pokemon = false;
					break;
				}
				gameObject.SetActive(false);
				Main.S.paused = false;
				for(int i = 0; i < Player.S.pokemon_list.Length; ++i){
					PokemonObject po = Player.S.pokemon_list[i];
					if (po == null) continue;
					Player.S.pokemon_list[i].curHp = Player.S.pokemon_list[i].totHp;
				}
				
				Player.S.CheckForAction();
			}

			if(Input.GetKeyDown(KeyCode.DownArrow)){
				MoveDownMenu();
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)){
				MoveUpMenu();
			}
		}
	}
	public void MoveDownMenu(){
		Heal_lists[activeItem].GetComponent<GUIText>().color = Color.black;
		activeItem = activeItem == Heal_lists.Count - 1 ? 0: ++activeItem;
		Heal_lists[activeItem].GetComponent<GUIText>().color = Color.red;	
	}
	public void MoveUpMenu(){
		Heal_lists[activeItem].GetComponent<GUIText>().color = Color.black;
		activeItem = activeItem == 0 ? Heal_lists.Count - 1: --activeItem;
		Heal_lists[activeItem].GetComponent<GUIText>().color = Color.red;	
	}
}
