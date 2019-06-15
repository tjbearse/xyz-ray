using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : BaseClickable {
	public ClickableObject clickableSO;
	public Console console;

	override public void Click() {
		if (this.console) {
			this.console.SendText(this.clickableSO.consoleText);
		} else {
			Debug.LogWarning("no console to write to");
		}
		// TODO more triggers?
	}
}
