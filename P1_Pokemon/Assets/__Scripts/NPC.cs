﻿using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {
	public string	speech;
	
	public	Sprite	upSprite;
	public	Sprite	downSprite;
	public	Sprite	leftSprite;
	public	Sprite	rightSprite;
	
	public SpriteRenderer	sprend;
	// Use this for initialization
	void Start () {
		sprend = gameObject.GetComponent<SpriteRenderer>();
	}
	public void Play_Dialog(string message){
		Dialog.S.gameObject.SetActive(true);
		Color noAlpha = GameObject.Find("DialogBackground").GetComponent<GUITexture>().color;
		noAlpha.a = 255;
		GameObject.Find("DialogBackground").GetComponent<GUITexture>().color = noAlpha;
		Dialog.S.ShowMessage(message);
	}
	public void FacePlayer(Direction playerDir){
		switch(playerDir){
			case Direction.down:
				sprend.sprite = upSprite;
				break;
			case Direction.up:
				sprend.sprite = downSprite;
				break;
			case Direction.left:
				sprend.sprite = rightSprite;
				break;
			case Direction.right:
				sprend.sprite = leftSprite;
				break;
		}
	}
}
