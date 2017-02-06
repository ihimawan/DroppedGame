using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {

	[SerializeField]
	private GameObject timeBar;

	//distance per block
	public float distancePerBlock;

	//determine where the position of the first block
	public Vector2 positionOfFirstBlock;

	//how many blocks you want available?
	public int blockAmountOnScreen;

	//the blocks that are available
	public GameObject[] blockTemplates;

	//the puff that appears when the block disappears.
	public GameObject blockPuff;

	//how fast do you want the block to move up?
	public float moveUpSpeed = 15;

	//other things that keep the moveup state
	private bool moveUp = false; //<- better to put move up to a different script
	private float distanceLeft;
	private Vector3 previousBlockGroupPosition;

	private TimeBarScript timeBarScript;

	private bool elongated = false;
	private bool slowedDown = false;

	public void Elongate(){
		Debug.Log("Elongate!");
	}

	public void UnElongate(){
		Debug.Log("UnElongate!");
	}

	public void SlowDown(){
		Debug.Log("SlowDown!");
	}

	public void UnSlowDown(){
		Debug.Log("UnSlowDown!");
	}

	void Start(){
		timeBarScript = timeBar.GetComponent<TimeBarScript>();
		distanceLeft = distancePerBlock;
		InitializeBlocks();
		SetBlockToAvailable(1); //set the second block (the first is the starting block), to be a good block.
	}

	void InitializeBlocks ()
	{

		Vector2 currentPosition = positionOfFirstBlock;

		Debug.Log(positionOfFirstBlock);

		//create starting block
		GameObject startBlock = (GameObject)Instantiate (blockTemplates [0]);
		startBlock.transform.parent = transform;
		startBlock.transform.position = currentPosition;
	
		//create the rest of the blocks
		for (int i = 0; i < blockAmountOnScreen - 1; i++) {

			//shift to next position
			currentPosition -= new Vector2 (0, distancePerBlock);

			//select random existing block
			int blockType = Random.Range (1, blockTemplates.Length);

			//create that type of block and place it
			GameObject block = (GameObject)Instantiate (blockTemplates [blockType]);
			block.transform.parent = transform;
			block.transform.position = currentPosition;
		}

	}

	void Update ()
	{
		if (moveUp) { //if it is supposed to move up

			Vector3 oldPosition = transform.position;
			transform.Translate(0,moveUpSpeed * Time.deltaTime,0);
			distanceLeft -= Vector3.Distance(oldPosition, transform.position);

			if (distanceLeft <= 0) {
				transform.position = new Vector3(0,previousBlockGroupPosition.y + distancePerBlock);
				moveUp=false;
			}
		}
	}

	//actions taken upon block after player has jumped.
	public void PlayerJumped () 
	{
		timeBarScript.RestartTimer(); //restart the timer
		DestroyBlock(); //destroy the first block (the block in which the user has jumped from)
		CreateBlock(); //create another block

	}

	public void PlayerLanded ()
	{
		Invoke("MoveGroupUp", 0.05f);
		SetBlockToAvailable(1); //set the third block to be available
	}

	public void DestroyBlock(){

		//the first block will always be destroyed.
		Transform currentBlock = transform.GetChild(0);
		CreatePuff(currentBlock);

		Destroy(currentBlock.gameObject);
	}

	void SetBlockToAvailable(int childIndex){
//		Debug.Log("the tag " + childIndex + " gameobject is " + transform.GetChild(childIndex) + " tag = " + transform.GetChild(childIndex).tag);
		transform.GetChild(childIndex).GetComponent<BlockTemplate>().SetToGoodBlock();
	}


	public void CreateBlock ()
	{
		//where to put the block
		Vector2 position = new Vector2(0, positionOfFirstBlock.y + (-distancePerBlock * (blockAmountOnScreen)));

//		Debug.Log("Position of new block: " + position);

		//select random existing block
		int blockType = Random.Range(1, blockTemplates.Length);

		//create that type of block and place it
		GameObject block = (GameObject) Instantiate(blockTemplates[blockType]);
		block.transform.parent = transform;
		block.transform.position = position;

	}

	public void MoveGroupUp(){
		previousBlockGroupPosition = transform.position;
		distanceLeft = distancePerBlock;
		moveUp=true;
	}

	void CreatePuff (Transform blockTransform)
	{
		GameObject puffObject = (GameObject)Instantiate (blockPuff, blockTransform.position, Quaternion.identity);
	}


}
