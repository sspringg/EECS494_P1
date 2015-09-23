using UnityEngine;
using System.Collections;

public class TurnActionViewer : MonoBehaviour {

	public static TurnActionViewer S;

	void Awake () {
		S = this;
	}

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.A)) {
			gameObject.SetActive (false);
			BottomMenu.S.gameObject.SetActive(true);
		}
	}

	public static void printMessage(string inMsg){
		GUIText myText;
		
		myText = GameObject.Find ("TurnText").GetComponent<GUIText> ();
		myText.text = inMsg;
	}
}
