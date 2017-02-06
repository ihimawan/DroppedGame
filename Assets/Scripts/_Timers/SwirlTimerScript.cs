using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SwirlTimerScript : TimerTemplate {

	public override void BeginAction ()
	{
		blockManager.SlowDown();
	}

	public override void OverAction()
	{
		//WHAT DO YOU DO WHEN IT'S OVER?
		blockManager.UnSlowDown();
	}

}
