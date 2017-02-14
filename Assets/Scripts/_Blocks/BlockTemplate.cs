using UnityEngine;
using System.Collections;

public abstract class BlockTemplate : MonoBehaviour {

	public float speed; //the speed of the block moving
	public int length;

	protected static float speedFactor = 1f;
	protected static float lengthFactor = 0.2f;

	public Sprite goodBlockSprite;
	public Sprite badBlockSprite;

	public GameObject itemObject;
	public ItemOptions itemOptions;

	[SerializeField]
	private GameObject blockImg;

	private bool movingRight;

	public Transform getBlockImg ()
	{
		return blockImg.transform;
	}

	public static float getLengthFactor ()
	{
		return lengthFactor;
	}

	void Awake ()
	{

		itemOptions = GameObject.Find ("ItemOptions").GetComponent<ItemOptions> ();

		int direction = Random.Range (0, 2);

		if (direction == 0) {
			movingRight = true;
		} else {
			movingRight = false;
		}

		speed = Random.Range (4, 9) * speedFactor;

		//first, set the block as a bad block.
		if (transform.tag != "StartingBlock") {
			SetToBadBlock();
		}

	}

	public void Elongate ()
	{
		Debug.Log("Block:: Elongate!");

		//????? FIX HERE!!! somehow after the scale is changed, it goes back to normal.
		//transform.localScale = ... works fine. 
		//Turns out it's because objects with animators cannot have its scale changed.

		blockImg.transform.localScale += new Vector3(0.2f, 0, 0);
	}

	public void UnElongate(){
		Debug.Log("Block:: UnElongate!");
		blockImg.transform.localScale -= new Vector3(0.2f, 0, 0);

		//play the animation of blockImg
		//and scale the blockImg
	}

	public static void SlowDown (float slowDownPercentage)
	{
		Debug.Log("Block:: SlowDown by " + slowDownPercentage + "!");
		//make speed lower by percentage.
		speedFactor *= slowDownPercentage;

	}

	public static void UnSlowDown(float slowDownPercentage){
		Debug.Log("Block:: UnSlowDown!");
		//return speed to normal.
		speedFactor /= slowDownPercentage;
	}

	void SetToBadBlock(){
		transform.tag = "BadBlock";
		blockImg.GetComponent<SpriteRenderer>().sprite = badBlockSprite;
	}

	public void SetToGoodBlock(){

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

	public void toggleMovingRight ()
	{
		movingRight = movingRight ? false : true;
	}

	public abstract void moveRight(); //how do you want to move right?
	public abstract void moveLeft(); //how do you want to move left?

}