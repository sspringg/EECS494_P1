﻿using UnityEngine;
using System.Collections;

public class AttackMove{

	public string moveName;
	public int pwr;
	public int acurcy;
	public int totPp;
	public int curPp;
	public pkmnType type;

	public static AttackMove getMove(string inputName){
		AttackMove atkmv = new AttackMove ();
		switch (inputName) {
		case "Tackle":
			atkmv.moveName = "Tackle";
			atkmv.pwr = 35;
			atkmv.acurcy = 95;
			atkmv.totPp = 35;
			atkmv.curPp = 35;
			atkmv.type = pkmnType.normal;
			break;
		case "Scratch":
			atkmv.moveName = "Scratch";
			atkmv.pwr = 40;
			atkmv.acurcy = 100;
			atkmv.totPp = 35;
			atkmv.curPp = 35;
			atkmv.type = pkmnType.normal;
			break;
		default:
			atkmv.moveName = "None";
			atkmv.pwr = 0;
			atkmv.acurcy = 0;
			atkmv.totPp = 0;
			atkmv.curPp = 0;
			atkmv.type = pkmnType.none;
			break;
		}
		return atkmv;
	}
}
