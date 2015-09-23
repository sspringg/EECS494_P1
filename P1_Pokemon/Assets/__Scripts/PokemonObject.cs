using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum pkmnType
{
	bug,
	dragon,
	ice,
	fighting,
	fire,
	flying,
	grass,
	ghost,
	ground,
	electric,
	normal,
	poision,
	psychic,
	rock,
	water,
	none
}

public class PokemonObject{

	public string pkmnName;
	public pkmnType type1;
	public pkmnType type2;
	public int totHp;
	public int curHp;
	public int atk;
	public int def;
	public int spAtk;
	public int spDef;
	public int speed;
	public int level;
	public int exp;

	public AttackMove move1;
	public AttackMove move2;
	public AttackMove move3;
	public AttackMove move4;

	public static Dictionary<pkmnType, Dictionary<pkmnType, double>> modifierTable;

	void start(){
	}

	public static PokemonObject getPokemon(string inputName){
		PokemonObject pkmn = new PokemonObject ();
		pkmn.level = 5;
		pkmn.exp = 5 * 5 * 5;
		switch (inputName) {
		case "Bulbasaur":
			pkmn.pkmnName = "Bulbasaur";
			pkmn.type1 = pkmnType.grass;
			pkmn.type2 = pkmnType.poision;
			pkmn.totHp = 45;
			pkmn.curHp = 45;
			pkmn.atk = 49;
			pkmn.def = 49;
			pkmn.spAtk = 65;
			pkmn.spDef = 65;
			pkmn.speed = 45;
			pkmn.move1 = AttackMove.getMove("Tackle");
			pkmn.move2 = AttackMove.getMove("None");
			pkmn.move3 = AttackMove.getMove("None");
			pkmn.move4 = AttackMove.getMove("None");
			break;
		case "Charmander":
			pkmn.pkmnName = "Charmander";
			pkmn.type1 = pkmnType.fire;
			pkmn.type2 = pkmnType.none;
			pkmn.totHp = 39;
			pkmn.curHp = 39;
			pkmn.atk = 52;
			pkmn.def = 43;
			pkmn.spAtk = 60;
			pkmn.spDef = 50;
			pkmn.speed = 65;
			pkmn.move1 = AttackMove.getMove("Scratch");
			pkmn.move2 = AttackMove.getMove("Tackle");
			pkmn.move3 = AttackMove.getMove("None");
			pkmn.move4 = AttackMove.getMove("None");
			break;
		case "Squirtle":
			pkmn.pkmnName = "Squirtle";
			pkmn.type1 = pkmnType.water;
			pkmn.type2 = pkmnType.none;
			pkmn.totHp = 44;
			pkmn.curHp = 44;
			pkmn.atk = 48;
			pkmn.def = 65;
			pkmn.spAtk = 50;
			pkmn.spDef = 64;
			pkmn.speed = 43;
			pkmn.move1 = AttackMove.getMove("Tackle");
			pkmn.move2 = AttackMove.getMove("Scratch");
			pkmn.move3 = AttackMove.getMove("None");
			pkmn.move4 = AttackMove.getMove("None");
			break;
		case "Pikachu":
			pkmn.pkmnName = "Pikachu";
			pkmn.type1 = pkmnType.electric;
			pkmn.type2 = pkmnType.none;
			pkmn.totHp = 35;
			pkmn.curHp = 35;
			pkmn.atk = 55;
			pkmn.def = 40;
			pkmn.spAtk = 50;
			pkmn.spDef = 50;
			pkmn.speed = 90;
			pkmn.move1 = AttackMove.getMove("Thunder Shock");
			pkmn.move2 = AttackMove.getMove("Tackle");
			pkmn.move3 = AttackMove.getMove("None");
			pkmn.move4 = AttackMove.getMove("None");
			break;
		default :
			pkmn.pkmnName = "None";
			pkmn.type1 = pkmnType.none;
			pkmn.type2 = pkmnType.none;
			pkmn.totHp = 0;
			pkmn.curHp = 0;
			pkmn.atk = 0;
			pkmn.def = 0;
			pkmn.spAtk = 0;
			pkmn.spDef = 0;
			pkmn.speed = 0;
			pkmn.move1 = AttackMove.getMove("None");
			pkmn.move2 = AttackMove.getMove("None");
			pkmn.move3 = AttackMove.getMove("None");
			pkmn.move4 = AttackMove.getMove("None");
			break;
		}
		return pkmn;
	}

	public void takeHit(AttackMove atkMove, PokemonObject attacker){
		if (atkMove.moveName == "None")
			return;
		double modifier1 = 1;
		double modifier2 = 1;
		--atkMove.curPp;
		curHp -= (int)Math.Floor((((2.0 * (attacker.level + 10.0) / 250.0) * (attacker.atk / def) * atkMove.pwr) + 2.0) * modifier1 * modifier2);
	}
}
