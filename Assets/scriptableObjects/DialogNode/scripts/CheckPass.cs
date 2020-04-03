
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


[CreateAssetMenu(fileName = "CheckPassword", menuName = "ScriptableObjects/Dialog/PassCheck", order = 1)]
public class CheckPass : BaseDialogNode {
	public string startText;
	public string goodResponse;
	public BaseDialogNode goodNext;
	public string badResponse;
	public BaseDialogNode badNext;

	override public string StartText() {
		return startText;
	}

	override public (string response, BaseDialogNode next) RecieveText(string answer) {
		if (answer == PasswordStore.password) {
			return (response: this.goodResponse, next: this.goodNext);
		} else {
			return (response: this.badResponse, next: this.badNext);
		}
	}
}
