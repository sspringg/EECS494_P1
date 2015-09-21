using UnityEngine;
using System.Collections;

public enum Direction{
	down,
	left,
	up,
	right
}
public enum Pokemon{
	Squirttle,
	Bulbasaur,
	Charmander
}
public class Player : MonoBehaviour {

	public static Player S;
	public Pokemon[] pokemon_list;
	public float 	moveSpeed;
	public int		tileSize;
	//public Pokemon pokeChoice;
	public	Sprite	upSprite;
	public	Sprite	downSprite;
	public	Sprite	leftSprite;
	public	Sprite	rightSprite;
	
	public SpriteRenderer	sprend;
	public bool ChoosingPokemon = false;
	public bool		_______;
	public bool		chosenPokemon = false;
	public bool		fought_BC = false;
	public bool		fought_Lass = false;
	public bool		fought_YS = false;
	public bool		BC_move = false;
	public bool		Lass_move = false;
	public bool		Youngster_move = false;
	public RaycastHit	hitInfo;
	public bool		moving = false;
	public Vector3	targetPos;
	public Direction direction;
	public Vector3	moveVec;
	
	public string POak_Opening_dialog;
	public string POak_dialog;
	public string Choose_Pokemon_Dialog;
	public string Couch_Potatoe_Dialog;
	public string Store_Clerk;
	public string Red_House;
	public string Blue_House;
	void Awake(){
		S = this;
	}
	
	void Start(){
		sprend = gameObject.GetComponent<SpriteRenderer>();
		pokemon_list = new Pokemon[4];
		POak_Opening_dialog = "Hello, Red! Welcome to my lab. I have a couple pokemon leftover from my training days, "
			+ "Choose one to get started";
		POak_dialog = "I study pokemon! You have chosen, " + Player.S.pokemon_list[0]; // + Player.S.pokeChoice;
		Choose_Pokemon_Dialog = "Choose your first Pokemon between 	Squirttle, Bulbasaur, and Charmander";
		Couch_Potatoe_Dialog = "Pokemon centers heal your tired, hurt, or fainted Pokemon!";
		Store_Clerk = "Say hi to Professor Oak for me!";
		Red_House = "Red House";
		Blue_House = "Blue  House";
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
			//these actions need to come before arrows become they need to happen even if trying to move 
			else if(Physics.Raycast(gameObject.transform.position, Vector3.left, out hitInfo, 6f, GetLayerMask(new string[] {"Bug_Catcher"})) && !fought_BC){
				fought_BC = true;
				NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
				npc.Play_Dialog("Not so fast Rookie! It's time to teach you a lesson");
				moving = false;
				direction = Direction.left;
				sprend.sprite = leftSprite;
				BC_move = true;		
				
			}
			else if(Physics.Raycast(gameObject.transform.position, Vector3.right, out hitInfo, 10f, GetLayerMask(new string[] {"Lass"})) && !fought_Lass){
				fought_Lass = true;
				NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
				npc.Play_Dialog("You may have beaten Bug Catcher but you will be no match for me");
				moving = false;
				direction = Direction.right;
				sprend.sprite = rightSprite;
				Lass_move = true;		
				
			}
			else if(Physics.Raycast(gameObject.transform.position, Vector3.left, out hitInfo, 8f, GetLayerMask(new string[] {"Youngster"})) && !fought_YS){
				fought_YS = true;
				NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
				npc.Play_Dialog("Impressive I must say. Now it is time for me to teach you what being a Pokemon trainer is really about");
				moving = false;
				direction = Direction.left;
				sprend.sprite = leftSprite;
				Youngster_move = true;
			}
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
			else if(BC_move){
				if((transform.position.x - 64f) > .1){
					sprend.sprite = leftSprite;
					transform.position += Vector3.left * (Time.deltaTime * 4);
				}
				else{
					direction = Direction.down;
					sprend.sprite = downSprite;
					BC_move = false;
					//call fight scene here
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
					//call new scene here
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
					//call fight scene here
				}
			}
			else{
				moveVec = Vector3.zero;
				moving = false;
			}
			//min 25
			//ray cast sends out a ray in any direction for however long 
			//we want to see if there is an immovable object within 1 tile of dir we face
			if(Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] {"Immovable", "NPC", "Professor_Oak", "Poke_Ball", "CouchPotatoe",
				"Store_Front", "Lass", "Youngster", "Bug_Catcher"}))){
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
		//print(Physics.Raycast(Vector3.up, Vector3.up, 2f, GetLayerMask(new string[] {"Poke_Ball"})));
		//Debug.DrawRay(Vector3.up, Vector3.up, Color.black, 50, false);
		if(Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] {"Professor_Oak"}))){
			NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
			npc.FacePlayer(direction);
			if(!chosenPokemon)
				npc.Play_Dialog(POak_Opening_dialog);
			else
				npc.Play_Dialog(POak_dialog);
		}
		else if(Physics.Raycast(GetRay(), out hitInfo, 2f, GetLayerMask(new string[] {"Poke_Ball"}))){
			if(!chosenPokemon){
				ChoosingPokemon = true;
				NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
				npc.Play_Dialog(Choose_Pokemon_Dialog);
			}
		}
		else if(Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] {"CouchPotatoe"}))){
			NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
			npc.Play_Dialog(Couch_Potatoe_Dialog);
		}
		else if(Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] {"Store_Front"}))){
			NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
			npc.Play_Dialog(Store_Clerk);
		}
		else if(Physics.Raycast(GetRay(), out hitInfo, 2f, GetLayerMask(new string[] {"Red_House"}))){
			print("Red");
			NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
			npc.Play_Dialog(Red_House);
		}
		else if(Physics.Raycast(GetRay(), out hitInfo, 2f, GetLayerMask(new string[] {"Blue_House"}))){
			NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
			npc.Play_Dialog(Blue_House);
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
