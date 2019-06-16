using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;


[CreateAssetMenu(fileName = "RegexDialogNode", menuName = "ScriptableObjects/Dialog/Regex", order = 1)]
public class RegexMapDialogOption : BaseDialogNode {
	[Multiline]
	public string startText;
	public RegexOption[] options;

	void Start() {
		if (this.options.Length == 0) {
			Debug.LogWarning("not initialized", this);
		}
	}
	override public string StartText() {
		return startText;
	}

	override public (string response, BaseDialogNode next) RecieveText(string answer) {
		foreach(var o in this.options) {
			if (Regex.IsMatch(answer, o.regex, RegexOptions.IgnoreCase)) {
				return (response: o.response, next: o.next);
			}
		}
		return (response: "response unrecognized", next: this);
	}
}

[System.Serializable]
public class RegexOption {
	public string regex;
	public string response;
	public BaseDialogNode next;
}
