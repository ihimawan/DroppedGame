using UnityEngine;
using System.Collections;


public class BasicBlock : BlockTemplate {

	public override void moveRight(){ //how do you want to move right?
		transform.position += Vector3.right * speed * Time.deltaTime;
	}

	public override void moveLeft(){ //how do you want to move left?
		transform.position += Vector3.left * speed * Time.deltaTime;
	}



}