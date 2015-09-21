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
			pkmn.move2 = AttackMove.getMove("None");
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
			pkmn.move2 = AttackMove.getMove("None");
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
			pkmn.move2 = AttackMove.getMove("None");
			pkmn.move3 = AttackMove.getMove("None");
			pkmn.move4 = AttackMove.getMove("None");
			break;
		}
		return pkmn;
	}

	public void takeHit(AttackMove atkMove, PokemonObject attacker){
		double modifier1 = 1;
		double modifier2 = 1;
		/*Dictionary<pkmnType, double> result;
		if (modifierTable.TryGetValue (atkMove.type, out result)) {
			result.TryGetValue (type1, out modifier1);
			result.TryGetValue (type2, out modifier2);
		}*/
		curHp -= (int)Math.Floor((((2.0 * (attacker.level + 10.0) / 250.0) * (attacker.atk / def) * atkMove.pwr) + 2.0) * modifier1 * modifier2);
	}
}

/*
 Dictionary<pkmnType, double> tmpTable = new Dictionary<pkmnType, double>();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 1);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 1);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 1);
		tmpTable.Add (pkmnType.ground, 1);
		tmpTable.Add (pkmnType.flying, 1);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 1);
		tmpTable.Add (pkmnType.rock, 0.5);
		tmpTable.Add (pkmnType.ghost, 0);
		tmpTable.Add (pkmnType.dragon, 1);
		tmpTable.Add (pkmnType.none, 1);

		modifierTable.Add (pkmnType.normal, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 0.5);
		tmpTable.Add (pkmnType.water, 0.5);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 2);
		tmpTable.Add (pkmnType.ice, 2);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 1);
		tmpTable.Add (pkmnType.ground, 1);
		tmpTable.Add (pkmnType.flying, 1);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 2);
		tmpTable.Add (pkmnType.rock, 0.5);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 0.5);
		tmpTable.Add (pkmnType.none, 1);

		modifierTable.Add (pkmnType.fire, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 2);
		tmpTable.Add (pkmnType.water, 0.5);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 0.5);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 1);
		tmpTable.Add (pkmnType.ground, 2);
		tmpTable.Add (pkmnType.flying, 1);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 1);
		tmpTable.Add (pkmnType.rock, 2);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 0.5);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.water, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 1);
		tmpTable.Add (pkmnType.water, 2);
		tmpTable.Add (pkmnType.electric, 0.5);
		tmpTable.Add (pkmnType.grass, 0.5);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 1);
		tmpTable.Add (pkmnType.ground, 0);
		tmpTable.Add (pkmnType.flying, 2);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 1);
		tmpTable.Add (pkmnType.rock, 1);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 0.5);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.electric, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 0.5);
		tmpTable.Add (pkmnType.water, 2);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 0.5);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 0.5);
		tmpTable.Add (pkmnType.ground, 2);
		tmpTable.Add (pkmnType.flying, 0.5);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 0.5);
		tmpTable.Add (pkmnType.rock, 2);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 0.5);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.grass, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 1);
		tmpTable.Add (pkmnType.water, 0.5);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 2);
		tmpTable.Add (pkmnType.ice, 0.5);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 1);
		tmpTable.Add (pkmnType.ground, 2);
		tmpTable.Add (pkmnType.flying, 2);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 1);
		tmpTable.Add (pkmnType.rock, 1);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 2);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.ice, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 2);
		tmpTable.Add (pkmnType.fire, 1);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 1);
		tmpTable.Add (pkmnType.ice, 2);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 0.5);
		tmpTable.Add (pkmnType.ground, 1);
		tmpTable.Add (pkmnType.flying, 0.5);
		tmpTable.Add (pkmnType.psychic, 0.5);
		tmpTable.Add (pkmnType.bug, 0.5);
		tmpTable.Add (pkmnType.rock, 2);
		tmpTable.Add (pkmnType.ghost, 0);
		tmpTable.Add (pkmnType.dragon, 1);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.fighting, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 1);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 2);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 0.5);
		tmpTable.Add (pkmnType.ground, 0.5);
		tmpTable.Add (pkmnType.flying, 1);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 2);
		tmpTable.Add (pkmnType.rock, 0.5);
		tmpTable.Add (pkmnType.ghost, 0.5);
		tmpTable.Add (pkmnType.dragon, 1);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.poision, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 2);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 2);
		tmpTable.Add (pkmnType.grass, 0.5);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 2);
		tmpTable.Add (pkmnType.ground, 1);
		tmpTable.Add (pkmnType.flying, 0);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 0.5);
		tmpTable.Add (pkmnType.rock, 2);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 1);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.ground, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 1);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 0.5);
		tmpTable.Add (pkmnType.grass, 2);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 2);
		tmpTable.Add (pkmnType.poision, 1);
		tmpTable.Add (pkmnType.ground, 1);
		tmpTable.Add (pkmnType.flying, 1);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 2);
		tmpTable.Add (pkmnType.rock, 0.5);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 1);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.flying, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 1);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 1);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 2);
		tmpTable.Add (pkmnType.poision, 2);
		tmpTable.Add (pkmnType.ground, 1);
		tmpTable.Add (pkmnType.flying, 1);
		tmpTable.Add (pkmnType.psychic, 0.5);
		tmpTable.Add (pkmnType.bug, 1);
		tmpTable.Add (pkmnType.rock, 1);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 1);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.psychic, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 0.5);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 2);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 0.5);
		tmpTable.Add (pkmnType.poision, 2);
		tmpTable.Add (pkmnType.ground, 1);
		tmpTable.Add (pkmnType.flying, 0.5);
		tmpTable.Add (pkmnType.psychic, 2);
		tmpTable.Add (pkmnType.bug, 1);
		tmpTable.Add (pkmnType.rock, 1);
		tmpTable.Add (pkmnType.ghost, 0.5);
		tmpTable.Add (pkmnType.dragon, 1);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.bug, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 2);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 1);
		tmpTable.Add (pkmnType.ice, 2);
		tmpTable.Add (pkmnType.fighting, 0.5);
		tmpTable.Add (pkmnType.poision, 1);
		tmpTable.Add (pkmnType.ground, 0.5);
		tmpTable.Add (pkmnType.flying, 2);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 2);
		tmpTable.Add (pkmnType.rock, 1);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 1);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.rock, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 0);
		tmpTable.Add (pkmnType.fire, 1);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 1);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 1);
		tmpTable.Add (pkmnType.ground, 1);
		tmpTable.Add (pkmnType.flying, 1);
		tmpTable.Add (pkmnType.psychic, 0);
		tmpTable.Add (pkmnType.bug, 1);
		tmpTable.Add (pkmnType.rock, 1);
		tmpTable.Add (pkmnType.ghost, 2);
		tmpTable.Add (pkmnType.dragon, 1);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.ghost, tmpTable);
		tmpTable.Clear ();

		tmpTable.Add (pkmnType.normal, 1);
		tmpTable.Add (pkmnType.fire, 1);
		tmpTable.Add (pkmnType.water, 1);
		tmpTable.Add (pkmnType.electric, 1);
		tmpTable.Add (pkmnType.grass, 1);
		tmpTable.Add (pkmnType.ice, 1);
		tmpTable.Add (pkmnType.fighting, 1);
		tmpTable.Add (pkmnType.poision, 1);
		tmpTable.Add (pkmnType.ground, 1);
		tmpTable.Add (pkmnType.flying, 1);
		tmpTable.Add (pkmnType.psychic, 1);
		tmpTable.Add (pkmnType.bug, 1);
		tmpTable.Add (pkmnType.rock, 1);
		tmpTable.Add (pkmnType.ghost, 1);
		tmpTable.Add (pkmnType.dragon, 2);
		tmpTable.Add (pkmnType.none, 1);
		
		modifierTable.Add (pkmnType.dragon, tmpTable);
		tmpTable.Clear ();
		*/
