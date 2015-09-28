using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Pokemon_Menu : MonoBehaviour {
	public int activeItem;
	public static Pokemon_Menu S;
	public List<GameObject> Poke_lists;
	public List<GameObject>	Perm_Items; 
	string key, value;
	void Awake(){
		S = this;
	}
	void Start () {
		bool first = true;
		foreach(Transform child in transform){
			Poke_lists.Add(child.gameObject);
		}
		foreach(GameObject go in Poke_lists){
			GUIText itemText = go.GetComponent<GUIText>();
			if(first) itemText.color = Color.red;
			first = false;  
		}
		Perm_Items = Poke_lists;
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.S.pokemon_list.Length == 0){
			gameObject.SetActive(false);
			Menu.S.menuPaused = false;
			Menu.S.pokemon_menu_active = false;	
		}
		if (Menu.S.menuPaused){
			setPlayerItems();
			if(Input.GetKeyDown(KeyCode.DownArrow)){
				MoveDownMenu();
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)){
				MoveUpMenu();
			}
		}
	}
	private void MoveDownMenu(){
		Poke_lists[activeItem].GetComponent<GUIText>().color = Color.black;
		while(true){
			activeItem = activeItem == Poke_lists.Count - 1 ? 0: ++activeItem;
			if(Poke_lists[activeItem].GetComponent<GUIText>().text != ""){
				Poke_lists[activeItem].GetComponent<GUIText>().color = Color.red;	
				break;	
			}
		}
	}
	private void MoveUpMenu(){
		Poke_lists[activeItem].GetComponent<GUIText>().color = Color.black;
		while(true){
			activeItem = activeItem == 0 ? Poke_lists.Count - 1: --activeItem;
			if(Poke_lists[activeItem].GetComponent<GUIText>().text != ""){
				Poke_lists[activeItem].GetComponent<GUIText>().color = Color.red;	
				break;	
			}
		}
	}
	private void setPlayerItems(){
		Poke_lists = Perm_Items;
		int i = 0;
		foreach(PokemonObject entry in Player.S.pokemon_list){
			if(entry.pkmnName != "None")
				Poke_lists[i].GetComponent<GUIText>().text = entry.pkmnName + " " + entry.curHp + "/" + entry.totHp + " LVL: " + entry.level;
			else
				Poke_lists[i].GetComponent<GUIText>().text = entry.pkmnName;
			++i;
		}
	}
}