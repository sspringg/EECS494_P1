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
	string key, value;
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
		activeItem = ItemMenu_lists.Count - 1;
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Menu.S.menuPaused){
			setPlayerItems();
			if(Input.GetKeyDown(KeyCode.A)){
				if(ItemMenu_lists[activeItem].GetComponent<GUIText>().text == "CANCEL"){
						gameObject.SetActive(false);
						Menu.S.menuPaused = false;
						Menu.S.items_menu_active = false;	
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
			if(ItemMenu_lists[activeItem].GetComponent<GUIText>().text != ""){
				ItemMenu_lists[activeItem].GetComponent<GUIText>().color = Color.red;	
				break;	
			}
		}
	}
	private void MoveUpMenu(){
		ItemMenu_lists[activeItem].GetComponent<GUIText>().color = Color.black;
		while(true){
			activeItem = activeItem == 0 ? ItemMenu_lists.Count - 1: --activeItem;
			if(ItemMenu_lists[activeItem].GetComponent<GUIText>().text != ""){
				ItemMenu_lists[activeItem].GetComponent<GUIText>().color = Color.red;	
				break;	
			}
		}
	}
	private void setPlayerItems(){
		ItemMenu_lists = Perm_Items;
		int i = 0;
		foreach(KeyValuePair<string, int> entry in Player.S.itemsDictionary){
				ItemMenu_lists[i].GetComponent<GUIText>().text = entry.Key + " X " + entry.Value;
			++i;
		}
	}
}