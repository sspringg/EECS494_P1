using UnityEngine;
using System.Collections;

public class Grass_Shield : MonoBehaviour {
	private string get_Pokemon_Message;
	// Use this for initialization
	void Start () {
		get_Pokemon_Message = "See Professor Oak in his lab before you enter the long grass. Dangerous Pokemon live in there";
	}
	
	void OnTriggerEnter(Collider coll){
		if(Player.S.chosenPokemon)
			gameObject.SetActive(false);
		else{
			Dialog.S.gameObject.SetActive(true);
			Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
			noAlpha.a = 255;
			GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
			Dialog.S.ShowMessage(get_Pokemon_Message);
		}
	}
}
