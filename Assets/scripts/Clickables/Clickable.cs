using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : BaseClickable {
	public ClickableObject clickableSO;
	public Console console;
	public UnityEvent events;

	override public void Click() {
		if (this.console) {
			this.console.SendText(this.clickableSO.consoleText);
		} else if (this.clickableSO) {
			Debug.LogWarning("no console to write to");
		}
		this.events.Invoke();
	}
}
