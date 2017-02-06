using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LollipopTimerScript : TimerTemplate {

	public override void BeginAction ()
	{
		blockManager.Elongate();
	}

	public override void OverAction()
	{
		//WHAT DO YOU DO WHEN IT'S OVER?
		blockManager.UnElongate();
	}

}
