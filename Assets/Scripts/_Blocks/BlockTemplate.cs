using UnityEngine;
using System.Collections;

public abstract class BlockTemplate : MonoBehaviour {

	public float speed; //the speed of the block moving
	public int length;

	public Sprite goodBlockSprite;
	public Sprite badBlockSprite;

	public GameObject itemObject;
	public ItemOptions itemOptions;

	[SerializeField]
	private GameObject blockImg;

	private bool movingRight;

	void Awake ()
	{

		itemOptions = GameObject.Find ("ItemOptions").GetComponent<ItemOptions> ();

		int direction = Random.Range (0, 2);

		if (direction == 0) {
			movingRight = true;
		} else {
			movingRight = false;
		}

		speed = Random.Range (4, 9);

		//first, set the block as a bad block.
		if (transform.tag != "StartingBlock") {
			SetToBadBlock();
		}

//		Debug.Log("block has been created. with tag = " + transform.tag);

	}

	void SetToBadBlock(){
		transform.tag = "BadBlock";
		blockImg.GetComponent<SpriteRenderer>().sprite = badBlockSprite;
	}

	public void SetToGoodBlock(){

//		Debug.Log("Bad block converted to good block.");
		SetItem();
		transform.tag = "GoodBlock";
		blockImg.GetComponent<SpriteRenderer>().sprite = goodBlockSprite;
	}

	void SetItem ()
	{
		itemObject = itemOptions.getRandomItemInstance(transform);
		itemObject.transform.SetAsFirstSibling();
	}

	void Update ()
	{
		move ();
	}

	public void move ()
	{
		if (movingRight) { //if the block is supposed to move Right
			moveRight();
		} else { //if the block is supposed to move Left
			moveLeft();
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		
		if (col.gameObject.tag == "GameBound") { //if it hits the edge of screen, then change direction.
			movingRight = movingRight ? false : true;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{

		//what to do when player hits the specific block?
		if (col.gameObject.tag == "Player") {

			transform.GetComponent<BounceScript>().StartBouncing();
		}

	}

	public abstract void moveRight(); //how do you want to move right?
	public abstract void moveLeft(); //how do you want to move left?

}