using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {


	static public Main S;
	
	public bool inDialog = false;
	public bool printDialog = false;
	public bool paused = false;
	
	void Awake(){
		S = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(!inDialog && Input.GetKeyDown(KeyCode.Space)){
			Menu.S.gameObject.SetActive(true);
			paused = true;
		}
		else if(inDialog && Input.GetKeyDown(KeyCode.Z) && Player.S.ChoosingPokemon){
			Pokemon_Choose.S.gameObject.SetActive(true);
			Dialog.S.HideDialogBox();
			paused = true;
		}
		else if(inDialog && Input.GetKeyDown(KeyCode.Z) && Player.S.Healing_Pokemon){
			Heal_Pokemon.S.gameObject.SetActive(true);
			Dialog.S.HideDialogBox();
			paused = true;
		}
		else if(inDialog && Input.GetKeyDown(KeyCode.Z) && Player.S.Mart_Options){
			Mart_Options.S.gameObject.SetActive(true);
			Dialog.S.HideDialogBox();
			paused = true;
		}
	}
}
