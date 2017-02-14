using UnityEngine;
using System.Collections;

public class BlockCollisionScript : MonoBehaviour {

	[SerializeField]
	private BlockTemplate blockTemplate;

	private Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		
		if (col.gameObject.tag == "GameBound") { //if it hits the edge of screen, then change direction.
			blockTemplate.toggleMovingRight();
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{

		//what to do when player hits the specific block?
		if (col.gameObject.tag == "Player") {
			transform.parent.GetComponent<BounceScript>().StartBouncing();
		}

	}

	public void playElongateAnimation(){
		animator.SetTrigger("elongate");
		transform.localScale = new Vector3 (1.4f, 1, 1);
	}

	public void playUnElongateAnimation(){
		animator.SetTrigger("unElongate");
	}


}
