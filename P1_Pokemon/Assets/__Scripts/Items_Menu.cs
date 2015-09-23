using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum ItemMenu_list{
	Pokeball,
	Antidote,
	Palyz_Heal,
	Burn_Heal,
	Cancel
}

public class Items_Menu : MonoBehaviour {
	public int activeItem;
	public static Items_Menu S;
	public List<GameObject> ItemMenu_lists;
	public List<GameObject>	Perm_Items; 
	
	void Awake(){
		S = this;
	}
	void Start () {
		activeItem = 4;
		foreach(Transform child in transform){
			ItemMenu_lists.Add(child.gameObject);
		}
		foreach(GameObject go in ItemMenu_lists){
			GUIText itemText = go.GetComponent<GUIText>();
			if(itemText.text == "CANCEL") itemText.color = Color.red; 
		}
		Perm_Items = ItemMenu_lists;
		
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Menu.S.menuPaused){
			setPlayerItems();
			if(Input.GetKeyDown(KeyCode.A)){
				print(activeItem);
				switch(activeItem){
					case 4:
						gameObject.SetActive(false);
						Menu.S.menuPaused = false;
						Menu.S.items_menu_active = false;	
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
	}
	private void MoveDownMenu(){
			ItemMenu_lists[activeItem].GetComponent<GUIText>().color = Color.black;
			while(true){
				activeItem = activeItem == ItemMenu_lists.Count - 1 ? 0: ++activeItem;
				if(Player.S.itemsDictionary.ContainsKey(ItemMenu_lists[activeItem].GetComponent<GUIText>().text) ||
			   		ItemMenu_lists[activeItem].GetComponent<GUIText>().text == "CANCEL"){
					ItemMenu_lists[activeItem].GetComponent<GUIText>().color = Color.red;
					break;	
				}
			}	
	}
	private void MoveUpMenu(){
		ItemMenu_lists[activeItem].GetComponent<GUIText>().color = Color.black;
		while(true){
			activeItem = activeItem == 0 ? ItemMenu_lists.Count - 1: --activeItem;	
			if(Player.S.itemsDictionary.ContainsKey(ItemMenu_lists[activeItem].GetComponent<GUIText>().text) ||
			   ItemMenu_lists[activeItem].GetComponent<GUIText>().text == "CANCEL"){
				ItemMenu_lists[activeItem].GetComponent<GUIText>().color = Color.red;
				break;	
			}
		}	
	}
	private void setPlayerItems(){
		ItemMenu_lists = Perm_Items;
		foreach(GameObject go in ItemMenu_lists){
			print("see: " + go.GetComponent<GUIText>().text);
			if(Player.S.itemsDictionary.ContainsKey(go.GetComponent<GUIText>().text)){
				print(go.GetComponent<GUIText>().text);
				go.GetComponent<GUIText>().text += " X " + Player.S.itemsDictionary[go.GetComponent<GUIText>().text];
				go.GetComponent<GUIText>().color = Color.black;	
			}
			else if(go.GetComponent<GUIText>().text == "CANCEL"){
				//empty on purpose
			}
			else {
				go.GetComponent<GUIText>().color = Color.white;
			}
		}
	
	}
}
//			Cur_Items.Clear();
//			Cur_Items.Add(transform.GetChild(4).gameObject);
//			foreach(Transform child in transform){
//				print(Player.S.itemsDictionary.ContainsKey(child.GetComponent<GUIText>().text));
//				if(Player.S.itemsDictionary.ContainsKey(child.GetComponent<GUIText>().text)){
//					Cur_Items.Add(child.gameObject);	
//				}
//			}
//			first = true;
//			foreach(GameObject go in Cur_Items){
//				print("COUNT:  " + Cur_Items.Count());
//				GUIText itemText = go.GetComponent<GUIText>();
//				if(itemText.text == "Cancel")
//					itemText.text = Player.S.itemsDictionary[itemText.text] + " X " + itemText.text;
//				print(itemText.text);
//				if(first) itemText.color = Color.red;
//				first = false; 
//			}