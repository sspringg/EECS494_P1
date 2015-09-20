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
	public RaycastHit	hitInfo;
	public bool		moving = false;
	public Vector3	targetPos;
	public Direction direction;
	public Vector3	moveVec;

	void Awake(){
		S = this;
	}
	
	void Start(){
		sprend = gameObject.GetComponent<SpriteRenderer>();
		pokemon_list = new Pokemon[4];
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
			//min 25
			//ray cast sends out a ray in any direction for however long 
			//we want to see if there is an immovable object within 1 tile of dir we face
			if(Physics.Raycast(GetRay(), out hitInfo, 1f, GetLayerMask(new string[] {"Immovable", "NPC", "Professor_Oak", "Poke_Ball"}))){
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
			npc.Play_POak_Dialog();
		}
		else if(Physics.Raycast(GetRay(), out hitInfo, 2f, GetLayerMask(new string[] {"Poke_Ball"}))){
			print("poke");
			if(!chosenPokemon){
				chosenPokemon = true;
				NPC npc = hitInfo.collider.gameObject.GetComponent<NPC>();
				npc.Play_Choose_Poke();
			}
		}
	}
	
	Ray GetRay(){
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
	int GetLayerMask(string[] layerNames){
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
