using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeBarScript : TimerTemplate {

	[SerializeField]
	private GameObject player;

	private Player playerScript;

	// Use this for initialization
	void Start () {
		playerScript = player.GetComponent<Player>();
		TimerStart();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		fillValue -= timeSpeed / 100;
		FillerImage.fillAmount = fillValue;

		if (fillValue < 0) {
			OnTimeOver ();
		}
	}

	public override void OnTimeOver ()
	{
		playerScript.Jump();
		RestartTimer();
	}

	public override void BeginAction ()
	{
	}

	public override void OverAction(){

	}





}
