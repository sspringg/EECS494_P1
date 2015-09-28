using UnityEngine;
using System.Collections;

public class Wild_Pokemon : MonoBehaviour {

	void OnTriggerEnter(Collider coll){
		Application.LoadLevelAdditive("_Scene_2");
	}
}
