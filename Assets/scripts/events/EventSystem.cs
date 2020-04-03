using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventSystem : MonoBehaviour {
	public OneTimeEvent gameStart;
	public void StartGame() {
		this.gameStart.Invoke();
	}

	public void ActivateEmergencySystem() {
		StartCoroutine(this.activateEmergencySystem.InvokeWithDelay(3));
	}
	public OneTimeEvent activateEmergencySystem;

	public void ActivateInvestigation() => this.activateInvestigation.Invoke();
	public OneTimeEvent activateInvestigation;

	public OneTimeEvent gameOver;
	public void ActivateGameOver() => this.gameOver.Invoke();

}

[System.Serializable]
public class OneTimeEvent : UnityEvent {
	private bool invoked = false;
	new public void Invoke() {
		if (this.invoked) {
			return;
		}
		base.Invoke();
		this.invoked = true;
	}

	public IEnumerator InvokeWithDelay(float d) {
		yield return new WaitForSeconds(d);
		this.Invoke();
	}
}
