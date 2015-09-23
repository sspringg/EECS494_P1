using UnityEngine;
using System.Collections;

public class BattleScreen : MonoBehaviour {

	public static BattleScreen S;
	public static PokemonObject playerPokemon;
	public static PokemonObject opponentPokemon;

	void Awake(){
		S = this;
	}

	// Use this for initialization
	void Start () {
		updatePokemon (true, Player.S.pokemon_list[0]);
		updatePokemon (false, PokemonObject.getPokemon ("Charmander"));
	}
	
	// Update is called once per frame
	void Update () {
		if (playerPokemon.curHp <= 0 || opponentPokemon.curHp <= 0) {
			Destroy (GameObject.Find ("BattleScene"));
		}
		GUIText myText;
		myText = GameObject.Find ("HPVal1").GetComponent<GUIText> ();
		myText.text = playerPokemon.curHp.ToString () + '/' + playerPokemon.totHp.ToString();
		myText = GameObject.Find ("HPVal2").GetComponent<GUIText>();
		myText.text = opponentPokemon.curHp.ToString () + '/' + opponentPokemon.totHp.ToString();
	}

	public static void updatePokemon (bool isPlayer, PokemonObject curPkmn){
		GUIText myText;
		if (isPlayer) {
			BattleScreen.playerPokemon = curPkmn;
			myText = GameObject.Find ("NameVal1").GetComponent<GUIText> ();
			myText.text = curPkmn.pkmnName;
			
			myText = GameObject.Find ("LevelVal1").GetComponent<GUIText> ();
			myText.text = curPkmn.level.ToString ();
			
			myText = GameObject.Find ("HPVal1").GetComponent<GUIText> ();
			myText.text = curPkmn.curHp.ToString () + '/' + curPkmn.totHp.ToString();
		} else {
			BattleScreen.opponentPokemon = curPkmn;
			myText = GameObject.Find ("NameVal2").GetComponent<GUIText>();
			myText.text = curPkmn.pkmnName;
			
			myText = GameObject.Find ("LevelVal2").GetComponent<GUIText>();
			myText.text = curPkmn.level.ToString();
			
			myText = GameObject.Find ("HPVal2").GetComponent<GUIText>();
			myText.text = curPkmn.curHp.ToString () + '/' + curPkmn.totHp.ToString();
		}
	}
}
