using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivateEvent : BaseClickable {
	public UnityEvent e;

	override public void Click() {
		this.e.Invoke();
	}
}
