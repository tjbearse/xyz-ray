using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


[CreateAssetMenu(fileName = "SingleDialogNode", menuName = "ScriptableObjects/Dialog/Single", order = 1)]
public class SingleAnswer : BaseDialogNode {
	public string startText;
	public string answer;
	public string goodResponse;
	public string badResponse;
	public BaseDialogNode next;

	override public string StartText() {
		return startText;
	}

	override public (string response, BaseDialogNode next) RecieveText(string answer) {
		if (answer == this.answer) {
			return (response: this.goodResponse, next: this.next);
		} else {
			return (response: this.badResponse, next: this);
		}
	}
}
