using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void GoToLoseScene(){
		Invoke("LoseSceneLoad", 0.5f);
	}

	public void LoseSceneLoad ()
	{
		SceneManager.LoadScene("03 Restart");
	}

	public void GoToGameRestart ()
	{
		SceneManager.LoadScene("02 Game");
	}

}
