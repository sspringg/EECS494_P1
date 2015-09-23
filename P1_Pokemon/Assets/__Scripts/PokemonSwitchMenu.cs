using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum sMenuItem {
	Pokemon1,
	Pokemon2,
	Pokemon3,
	Pokemon4,
	Pokemon5,
	Pokemon6
}

public class PokemonSwitchMenu : MonoBehaviour {

	public static PokemonSwitchMenu S;

	public int activeItem;
	public List<GameObject> menuItems;

	void Awake () {
		S = this;
	}

	// Use this for initialization
	void Start () {
		bool first = true;
		activeItem = 0;
		
		foreach (Transform child in transform) {
			menuItems.Add (child.gameObject);
		}
		menuItems = menuItems.OrderByDescending (m => m.transform.position.y).ToList ();
		
		foreach (GameObject go in menuItems) {
			GUIText itemText = go.GetComponent<GUIText> ();
			if (first)
				itemText.color = Color.red;
			first = false;
			gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			switch(activeItem){
			case(int)sMenuItem.Pokemon1:
				print("Pk1 selected");
				if (Player.S.pokemon_list[0].pkmnName == "None" || Player.S.pokemon_list[0].curHp <= 0){
					print("this pkmn cannot be selected");
				}
				else {
					BattleScreen.updatePokemon(true, Player.S.pokemon_list[0]);
				}
				break;
			case(int)sMenuItem.Pokemon2:
				print("Pk2 selected");
				if (Player.S.pokemon_list[1].pkmnName == "None" || Player.S.pokemon_list[1].curHp <= 0){
					print("this pkmn cannot be selected");
				}
				else {
					BattleScreen.updatePokemon(true, Player.S.pokemon_list[1]);
				}
				break;
			case(int)sMenuItem.Pokemon3:
				print("Pk3 selected");
				if (Player.S.pokemon_list[2].pkmnName == "None" || Player.S.pokemon_list[2].curHp <= 0){
					print("this pkmn cannot be selected");
				}
				else {
					BattleScreen.updatePokemon(true, Player.S.pokemon_list[2]);
				}
				break;
			case(int)sMenuItem.Pokemon4:
				print("Pk4 selected");
				if (Player.S.pokemon_list[3].pkmnName == "None" || Player.S.pokemon_list[3].curHp <= 0){
					print("this pkmn cannot be selected");
				}
				else {
					BattleScreen.updatePokemon(true, Player.S.pokemon_list[3]);
				}
				break;
			case(int)sMenuItem.Pokemon5:
				print("Pk5 selected");
				if (Player.S.pokemon_list[4].pkmnName == "None" || Player.S.pokemon_list[4].curHp <= 0){
					print("this pkmn cannot be selected");
				}
				else {
					BattleScreen.updatePokemon(true, Player.S.pokemon_list[4]);
				}
				break;
			case(int)sMenuItem.Pokemon6:
				print("Pk6 selected");
				if (Player.S.pokemon_list[5].pkmnName == "None" || Player.S.pokemon_list[5].curHp <= 0){
					print("this pkmn cannot be selected");
				}
				else {
					BattleScreen.updatePokemon(true, Player.S.pokemon_list[5]);
				}
				break;
			}
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			MoveDownMenu();
		}
		else if (Input.GetKeyDown(KeyCode.UpArrow)){
			MoveUpMenu();
		}
		else if (Input.GetKeyDown(KeyCode.X))
		{
			gameObject.SetActive(false);
			HPSwitchTxt.S.gameObject.SetActive(false);
			BottomMenu.S.gameObject.SetActive(true);
			BattleScreen.S.gameObject.SetActive(true);
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

	public static void UpdateSwitchMenu(){
		GUIText mytext;
		
		mytext = GameObject.Find ("Pokemon1").GetComponent<GUIText> ();
		mytext.text = BattleScreen.playerPokemon.pkmnName; //Player.S.pokemon_list [0];
		/*mytext = GameObject.Find ("Pokemon2").GetComponent<GUIText> ();
		mytext.text = Player.S.pokemon_list [1];
		mytext = GameObject.Find ("Pokemon3").GetComponent<GUIText> ();
		mytext.text = Player.S.pokemon_list [2];
		mytext = GameObject.Find ("Pokemon4").GetComponent<GUIText> ();
		mytext.text = Player.S.pokemon_list [3];
		mytext = GameObject.Find ("Pokemon5").GetComponent<GUIText> ();
		mytext.text = Player.S.pokemon_list [4];
		mytext = GameObject.Find ("Pokemon6").GetComponent<GUIText> ();
		mytext.text = Player.S.pokemon_list [5];*/
	}
}
