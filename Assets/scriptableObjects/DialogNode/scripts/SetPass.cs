
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


[CreateAssetMenu(fileName = "SetPass", menuName = "ScriptableObjects/Dialog/SetPass", order = 1)]
public class SetPass : BaseDialogNode {
	public BaseDialogNode next;

	override public string StartText() {
		return "Enter password";
	}

	override public (string response, BaseDialogNode next) RecieveText(string answer) {
		PasswordStore.password = answer;
		return (response: "password set", next: this.next);
	}
}
