using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEmergency : BaseClickable {
	public TargetMover emergencyPrompt;
	public Transform promptTarget;
	public Console console;

	override public void Click() {
		if (this.console) {
			this.console.SendText("Engaging Subject spaceship using emergency protocol");
		} else {
			Debug.LogWarning("no console to write to");
		}
		this.emergencyPrompt.target = this.promptTarget.position;
		this.enabled = false;
	}
}
