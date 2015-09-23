using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Direction{
	down,
	left,
	up,
	right
}
public enum Pokemon{
	Squirttle,
	Bulbasaur,
	Charmander,
	Pikachu,
	none
}
public class Player : MonoBehaviour {

//initilizing variable
	public static Player S;
	public PokemonObject[] pokemon_list;
	public float 	moveSpeed;
	public int		tileSize;
	
	public SpriteRenderer	sprend;
	public	Sprite	upSprite;
	public	Sprite	downSprite;
	public	Sprite	leftSprite;
	public	Sprite	rightSprite;
//////////////////////////////	
//State variables
	public bool ChosenPokemon = false;
	public bool ChoosingPokemon = false;
	public bool		_______;
	public bool		fought_BC = false;
	public bool		fought_Lass = false;
	public bool		fought_YS = false;
	public bool		BC_move = false;
	public bool		Lass_move = false;
	public bool		Youngster_move = false;
	public bool		Healing_Pokemon = false;
	public bool		Mart_Options = false;
	public bool		pokedexEnable = false;
	public RaycastHit	hitInfo;
	public bool		moving = false;
	public string	playerSpeaking = null;
	public int	money = 500;
	
	public Vector3	targetPos;
	public Direction direction;
	public Vector3	moveVec;
	
	public Dictionary<string, int> speakDictionary = new Dictionary<string, int>();
	public Dictionary<string, int> itemsDictionary = new Dictionary<string,int>();
	void Awake(){
		S = this;
	}
	
	void Start(){
		sprend = gameObject.GetComponent<SpriteRenderer>();
		pokemon_list = new PokemonObject[6];
		pokemon_list [0] = PokemonObject.getPokemon ("None");
		pokemon_list [1] = PokemonObject.getPokemon ("None");
		pokemon_list [2] = PokemonObject.getPokemon ("None");
		pokemon_list [3] = PokemonObject.getPokemon ("None");
		pokemon_list [4] = PokemonObject.getPokemon ("None");
		pokemon_list [5] = PokemonObject.getPokemon ("None");
	}
	
	new public Rigidbody rigidbody{
		get {return gameObject.GetComponent<Rigidbody>();}
	}
	public Vector3 pos{
		get {return transform.position;}
		set{transform.position = value;}
	}
	void FixedUpdate(){
		if(!moving && !Main.S.inDialog && !Main.S.paused){
			if(Input.GetKeyDown(KeyCode.Z)){ //min 40
				CheckForAction();
			}
			///ACTIONS IF PLAYER COMES INTO LINE OF SIGHT OF TRAINERS
			//these actions need to come before arrows become they need to happen even if trying to move 
			else if(Physics.Raycast(gameObject.transform.position, Vector3.left, out hitInfo, 6f, GetLayerMask(new string[] {"Bug_Catcher"})) && !fought_BC){
				fought_BC = true;
				NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
				npc.Play_Dialog("Bug_Catcher");
				moving = false;
				direction = Direction.left;
				sprend.sprite = leftSprite;
				BC_move = true;		
				
			}
			else if(Physics.Raycast(gameObject.transform.position, Vector3.right, out hitInfo, 10f, GetLayerMask(new string[] {"Lass"})) && !fought_Lass){
				fought_Lass = true;
				NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
				npc.Play_Dialog("Lass");
				moving = false;
				direction = Direction.right;
				sprend.sprite = rightSprite;
				Lass_move = true;		
				
			}
			else if(Physics.Raycast(gameObject.transform.position, Vector3.left, out hitInfo, 8f, GetLayerMask(new string[] {"Youngster"})) && !fought_YS){
				fought_YS = true;
				NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
				npc.Play_Dialog("Youngster");
				moving = false;
				direction = Direction.left;
				sprend.sprite = leftSprite;
				Youngster_move = true;
			}
///////////////////////////////////////////////////
//ACTIONS AFTER THE TRAINER SAW PLAYER AND PLAYER IS MOVING TOWARD THEM
			else if(BC_move){
				if((transform.position.x - 64f) > .1){
					sprend.sprite = leftSprite;
					transform.position += Vector3.left * (Time.deltaTime * 4);
				}
				else{
					direction = Direction.down;
					sprend.sprite = downSprite;
					BC_move = false;
					//Application.LoadLevelAdditive("_Scene_2");
				}
			}
			else if(Lass_move){
				//				print("lass: " + (transform.position.x - 70f));
				if((70f - transform.position.x) > .1){
					sprend.sprite = rightSprite;
					transform.position += Vector3.right * (Time.deltaTime * 4);
				}
				else{
					direction = Direction.down;
					sprend.sprite = downSprite;
					Lass_move = false;
					//Application.LoadLevelAdditive("_Scene_2");
				}
			}
			else if(Youngster_move){
				if((transform.position.x - 68f) > .1){
					sprend.sprite = leftSprite;
					transform.position += Vector3.left * (Time.deltaTime * 4);
				}
				else{
					direction = Direction.down;
					sprend.sprite = downSprite;
					Youngster_move = false;
					//Application.LoadLevelAdditive("_Scene_2");
				}
			}	
////////////////////////////////////
//ARROW KEYS		
			if(Input.GetKey(KeyCode.RightArrow)){
				moveVec = Vector3.right;
				direction = Direction.right;
				sprend.sprite = rightSprite;
				moving = true;
			}
			else if(Input.GetKey(KeyCode.LeftArrow)){
				moveVec = Vector3.left;
				direction = Direction.left;
				sprend.sprite = leftSprite;
				moving = true;
			}
			else if(Input.GetKey(KeyCode.UpArrow)){
				moveVec = Vector3.up;
				direction = Direction.up;
				sprend.sprite = upSprite;
				moving = true;
			}
			else if(Input.GetKey(KeyCode.DownArrow)){
				moveVec = Vector3.down;
				direction = Direction.down;
				sprend.sprite = downSprite;
				moving = true;
			}
	
			else{
				moveVec = Vector3.zero;
				moving = false;
			}
//////////////////////////////////////
			//min 25
			//ray cast sends out a ray in any direction for however long 
			//we want to see if there is an immovable object within 1 tile of dir we face
			if(Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] {"Immovable", "NPC", "Lass", "Youngster", "Bug_Catcher"}))){
				moveVec = Vector3.zero;
				moving = false;
			};
			targetPos = pos + moveVec;
		}
		else{
			if((targetPos - pos).magnitude < moveSpeed * Time.fixedDeltaTime){
				pos = targetPos; //around min 17
				moving = false;
			}
			else{
				pos += (targetPos - pos).normalized * moveSpeed * Time.fixedDeltaTime;
			}
		}
	}
	
	public void CheckForAction(){
		if(Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] {"NPC", "Bug_Catcher", "Lass", "Youngster"}))){
			NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
			npc.FacePlayer(direction);
			playerSpeaking = npc.name;
			npc.Play_Dialog(npc.name);
		}
	}
	
	public Ray GetRay(){
		switch(direction){
			case Direction.down:
				return new Ray (pos, Vector3.down);
			case Direction.up:
				return new Ray (pos, Vector3.up);
			case Direction.left:
				return new Ray (pos, Vector3.left);
			case Direction.right:
				return new Ray (pos, Vector3.right);
			default:
				return new Ray();	
		}
	}
	//each layer has a number
	public int GetLayerMask(string[] layerNames){
		int layerMask = 0;
		foreach(string layer in layerNames){
			layerMask = layerMask | (1 << LayerMask.NameToLayer(layer)); //looks up name in layermask table
		}
		return layerMask;
	}
	public void MoveThroughDoor(Vector3 doorLoc){
		if(doorLoc.z <= 0) 
			doorLoc.z = transform.position.z; //make sure player doesnt get put into same z plane as scene and get lost
		moving = false;
		moveVec = Vector3.zero;
		transform.position = doorLoc;
	}
}

