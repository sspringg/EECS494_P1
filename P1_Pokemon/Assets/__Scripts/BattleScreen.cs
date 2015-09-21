using UnityEngine;
using System.Collections;

public class BattleScreen : MonoBehaviour {

	public static BattleScreen S;
	public PokemonObject playerPokemon;
	public PokemonObject opponentPokemon;

	void Awake(){
		S = this;
	}

	// Use this for initialization
	void Start () {
		playerPokemon = Player.S.pokemon_list [0];
		opponentPokemon = PokemonObject.getPokemon ("Bulbasaur");      //= getOpponentPokemon ();
		
		updatePokemon (true, playerPokemon);
		updatePokemon (false, opponentPokemon);

	}
	
	// Update is called once per frame
	void Update () {
		if (playerPokemon.curHp <= 0 || opponentPokemon.curHp <= 0) {
			Destroy(GameObject.Find("BattleScene"));
		}
		GUIText myText;
		myText = GameObject.Find ("HPVal1").GetComponent<GUIText> ();
		myText.text = playerPokemon.curHp.ToString () + '/' + playerPokemon.totHp.ToString();
		myText = GameObject.Find ("HPVal2").GetComponent<GUIText>();
		myText.text = opponentPokemon.curHp.ToString () + '/' + opponentPokemon.totHp.ToString();
	
	}

	void startBattle(){
		playerPokemon = Player.S.pokemon_list [0];
		opponentPokemon = PokemonObject.getPokemon ("Bulbasaur");      //= getOpponentPokemon ();
		
		updatePokemon (true, playerPokemon);
		updatePokemon (false, opponentPokemon);
	}

	public static void updatePokemon (bool isPlayer, PokemonObject curPkmn){
		GUIText myText;
		if (isPlayer) {
			myText = GameObject.Find ("NameVal1").GetComponent<GUIText> ();
			myText.text = curPkmn.pkmnName;
			
			myText = GameObject.Find ("LevelVal1").GetComponent<GUIText> ();
			myText.text = curPkmn.level.ToString ();
			
			myText = GameObject.Find ("HPVal1").GetComponent<GUIText> ();
			myText.text = curPkmn.curHp.ToString () + '/' + curPkmn.totHp.ToString();
			AttackMoveView.updateMoves(curPkmn);
		} else {
			myText = GameObject.Find ("NameVal2").GetComponent<GUIText>();
			myText.text = curPkmn.pkmnName;
			
			myText = GameObject.Find ("LevelVal2").GetComponent<GUIText>();
			myText.text = curPkmn.level.ToString();
			
			myText = GameObject.Find ("HPVal2").GetComponent<GUIText>();
			myText.text = curPkmn.curHp.ToString () + '/' + curPkmn.totHp.ToString();
		}
	}
}
