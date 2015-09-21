using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum aMenuItem {
	move1,
	move2,
	move3,
	move4
}

public class AttackMenu : MonoBehaviour {
	
	public static AttackMenu S;
	
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
		gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		AttackMoveView.updateMoveView(activeItem, BattleScreen.S.playerPokemon);
		PokemonObject playerPkmn = BattleScreen.S.playerPokemon;
		PokemonObject oppoPkmn = BattleScreen.S.opponentPokemon;
		if(Input.GetKeyDown(KeyCode.Return)){
			switch(activeItem){
			case(int)aMenuItem.move1:
				print("Move1 selected");
				if (playerPkmn.speed >= oppoPkmn.speed){
					oppoPkmn.takeHit(playerPkmn.move1, playerPkmn);
					playerPkmn.takeHit(oppoPkmn.move1, oppoPkmn);
				} else{
					playerPkmn.takeHit(oppoPkmn.move1, oppoPkmn);
					oppoPkmn.takeHit(playerPkmn.move1, playerPkmn);
				}
				break;
			case(int)aMenuItem.move2:
				print("Move2 selected");
				if (playerPkmn.speed >= oppoPkmn.speed){
					oppoPkmn.takeHit(playerPkmn.move2, playerPkmn);
					playerPkmn.takeHit(oppoPkmn.move1, oppoPkmn);
				} else{
					playerPkmn.takeHit(oppoPkmn.move1, oppoPkmn);
					oppoPkmn.takeHit(playerPkmn.move2, playerPkmn);
				}
				break;
			case(int)aMenuItem.move3:
				print("Move3 selected");
				if (playerPkmn.speed >= oppoPkmn.speed){
					oppoPkmn.takeHit(playerPkmn.move3, playerPkmn);
					playerPkmn.takeHit(oppoPkmn.move1, oppoPkmn);
				} else{
					playerPkmn.takeHit(oppoPkmn.move1, oppoPkmn);
					oppoPkmn.takeHit(playerPkmn.move3, playerPkmn);
				}
				break;
			case(int)aMenuItem.move4:
				print("Move4 selected");
				if (playerPkmn.speed >= oppoPkmn.speed){
					oppoPkmn.takeHit(playerPkmn.move4, playerPkmn);
					playerPkmn.takeHit(oppoPkmn.move1, oppoPkmn);
				} else{
					playerPkmn.takeHit(oppoPkmn.move1, oppoPkmn);
					oppoPkmn.takeHit(playerPkmn.move4, playerPkmn);
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
}