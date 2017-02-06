using UnityEngine;
using System.Collections;

public class VerticalWedgingScript : MonoBehaviour {

	public float shrinkscale = 0.8f;
	public float wedgeSpeed = 15f;

	private bool shrink = false;
	private bool unshrink = false;
	private float scaleleft = 0;
	private float shrinkReduceBy;
	private Vector3 originalScale;

	void Start(){
		originalScale = transform.localScale;
		shrinkReduceBy = 1 - transform.localScale.y * shrinkscale;
	}

	public void StartWedging ()
	{
		shrink=true;
		scaleleft = shrinkReduceBy;
	}

	// Update is called once per frame
	void Update ()
	{
		if (shrink) { //if need to shrink
			if (scaleleft > 0) { //if still need to shrink

				Vector3 oldScale = transform.localScale;
				transform.localScale += Vector3.down * wedgeSpeed * Time.deltaTime;
				scaleleft -= Vector3.Distance(oldScale, transform.localScale);

			} else {
				
				shrink=false;
				unshrink=true;
				scaleleft = shrinkReduceBy;
//				Debug.Log(scaleleft);
			}

		} else if (unshrink) { //if need to unshrink

			if (scaleleft > 0) { //if still need to unshrink

				Vector3 oldScale = transform.localScale;
				transform.localScale += Vector3.up * wedgeSpeed * Time.deltaTime;
				scaleleft -= Vector3.Distance(oldScale, transform.localScale);

			} else {
				unshrink=false;
				scaleleft=0;

				transform.localScale = originalScale; //set to original scale due to percision
			}
		}
	}
}
