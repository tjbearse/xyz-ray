using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleClickable : BaseClickable {

	public BaseClickable[] clickables;
	public float delay;
	override public void Click() {
		if (delay > 0) {
			StartCoroutine(IterateWithDelay());
		} else {
			foreach(var c in this.clickables) {
				c.Click();
			}
		}
	}
	IEnumerator IterateWithDelay()
	{
		foreach(var c in this.clickables) {
			if (c.enabled) {
				c.Click();
				yield return new WaitForSeconds(this.delay);
			}
		}
	}
}
