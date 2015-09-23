using UnityEngine;
using System.Collections;

public class HPSwitchTxt : MonoBehaviour {

	public static HPSwitchTxt S;

	void Awake () {
		S = this;
	}

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
