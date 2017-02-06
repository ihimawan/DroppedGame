using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public BlockManager blockManager;
	public ObtainedPowerUps obtainedPowerUps;

	public GameObject puff;

	private bool landed; //is the player standing on a block?

	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.transform.tag == "GoodBlock" || col.transform.tag == "StartingBlock") {
			transform.parent = col.gameObject.transform;

			if (col.transform.tag == "GoodBlock") {
				CreateLandingPuff ();
				ObtainItem();
				transform.GetComponent<VerticalWedgingScript>().StartWedging();
				blockManager.PlayerLanded (); //what is done to the blockmanager when player lands.
			}

			landed=true;
		}

		if (col.transform.tag == "BadBlock") {
			Debug.Log("You lost!!!");

			//if lost, then do not collide with any other blocks.
			transform.GetComponent<BoxCollider2D>().isTrigger = true;
		}

	}

	void CreateLandingPuff ()
	{
		// find a good puff sprite
	}

	//obtain item from block
	void ObtainItem(){

		ItemTemplate item = transform.parent.GetChild(0).GetComponent<ItemTemplate>();
		GameObject itemTimerPrefab = item.ItemTaken();

		obtainedPowerUps.PlacePowerUp(itemTimerPrefab);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (landed) {
			if (Input.GetKeyDown ("space")) {
				Jump ();
			}
		}
	}

	public void Jump ()
	{
		transform.parent=null;
		blockManager.PlayerJumped();
		landed=false;
	}

}
