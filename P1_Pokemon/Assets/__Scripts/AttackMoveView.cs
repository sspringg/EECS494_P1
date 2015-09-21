using UnityEngine;
using System.Collections;

public class AttackMoveView : MonoBehaviour {

	public static AttackMoveView S;

	void Awake(){
		S = this;
	}

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void updateMoves(PokemonObject curPkmn){
		GUIText myText;
		
		myText = GameObject.Find ("Move1").GetComponent<GUIText>();
		myText.text = curPkmn.move1.moveName;
		myText = GameObject.Find ("Move2").GetComponent<GUIText>();
		myText.text = curPkmn.move2.moveName;
		myText = GameObject.Find ("Move3").GetComponent<GUIText>();
		myText.text = curPkmn.move3.moveName;
		myText = GameObject.Find ("Move4").GetComponent<GUIText>();
		myText.text = curPkmn.move4.moveName;
	}

	public static void updateMoveView(int moveNum, PokemonObject curPkmn){
		GUIText myText1;
		GUIText myText2;

		myText1 = GameObject.Find ("PPVal").GetComponent<GUIText>();
		myText2 = GameObject.Find ("TypeVal").GetComponent<GUIText>();
		switch (moveNum) {
		case 0:
			myText1.text = curPkmn.move1.curPp.ToString() + '/' + curPkmn.move1.totPp.ToString();
			myText2.text = curPkmn.move1.type.ToString();
			break;
		case 1:
			myText1.text = curPkmn.move2.curPp.ToString() + '/' + curPkmn.move2.totPp.ToString();
			myText2.text = curPkmn.move2.type.ToString();
			break;
		case 2:
			myText1.text = curPkmn.move3.curPp.ToString() + '/' + curPkmn.move3.totPp.ToString();
			myText2.text = curPkmn.move3.type.ToString();
			break;
		case 4:
			myText1.text = curPkmn.move4.curPp.ToString() + '/' + curPkmn.move4.totPp.ToString();
			myText2.text = curPkmn.move4.type.ToString();
			break;
		}
	}
}
