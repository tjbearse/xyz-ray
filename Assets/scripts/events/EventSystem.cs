using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventSystem : MonoBehaviour {
	void Start() {
		StartCoroutine(this.gameStart.InvokeWithDelay(.2f));
	}

	public OneTimeEvent gameStart;

	public void ActivateEmergencySystem() {
		StartCoroutine(this.activateEmergencySystem.InvokeWithDelay(3));
	}
	public OneTimeEvent activateEmergencySystem;

	public void ActivateInvestigation() => this.activateInvestigation.Invoke();
	public OneTimeEvent activateInvestigation;

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
