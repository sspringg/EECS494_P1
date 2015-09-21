using UnityEngine;
using System.Collections;

public class Gym_Locked : MonoBehaviour {
	private string	gym_locked_message;
	void Start () {
		gym_locked_message = "You're not strong enough to compete with the big time trainers yet.";
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.S.chosenPokemon)
			gameObject.SetActive(false);
	}
	void OnTriggerEnter(Collider coll){
		Dialog.S.gameObject.SetActive(true);
		Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
		noAlpha.a = 255;
		GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
		Dialog.S.ShowMessage(gym_locked_message);
	}
}
