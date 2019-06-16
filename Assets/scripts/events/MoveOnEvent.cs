using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveOnEvent : TargetMover {
	public Transform intendedTarget;
	public void Move() {
		this.target = this.intendedTarget.position;
		this.gameObject.SetActive(true);
	}
}
