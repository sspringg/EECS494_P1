using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	public string	speech;
	public string POak_Opening_dialog;
	public string POak_dialog;
	public string Choose_Pokemon_Dialog;
	public	Sprite	upSprite;
	public	Sprite	downSprite;
	public	Sprite	leftSprite;
	public	Sprite	rightSprite;
	
	public SpriteRenderer	sprend;
	// Use this for initialization
	void Start () {
		sprend = gameObject.GetComponent<SpriteRenderer>();
		POak_Opening_dialog = "Hello, Red! Welcome to my lab. I have a couple pokemon leftover from my training days, "
		+ "Choose one to get started";
		POak_dialog = "I study pokemon! You have chosen, ";// + Player.S.pokeChoice;
		Choose_Pokemon_Dialog = "Choose your first Pokemon between 	Squirttle, Bulbasaur, and Charmander";
	}
	public void Play_POak_Dialog(){
		Dialog.S.gameObject.SetActive(true);
		Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
		noAlpha.a = 255;
		GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
		if(!Player.S.chosenPokemon){
			Dialog.S.ShowMessage(POak_Opening_dialog);
		}
		else
			Dialog.S.ShowMessage(POak_dialog);
	}
	public void Play_Choose_Poke(){
		Dialog.S.gameObject.SetActive(true);
		Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
		noAlpha.a = 255;
		GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
		Dialog.S.ShowMessage(Choose_Pokemon_Dialog);
		Player.S.ChoosingPokemon = true;
	}
	public void FacePlayer(Direction playerDir){
		switch(playerDir){
			case Direction.down:
				sprend.sprite = upSprite;
				break;
			case Direction.up:
				sprend.sprite = downSprite;
				break;
			case Direction.left:
				sprend.sprite = rightSprite;
				break;
			case Direction.right:
				sprend.sprite = leftSprite;
				break;
		}
	}
}
