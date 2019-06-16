using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


[CreateAssetMenu(fileName = "MenuDialogNode", menuName = "ScriptableObjects/Dialog/Menu", order = 1)]
public class MenuDialogNode : BaseDialogNode {
	[Multiline]
	public string startText;
	public MenuOption[] options;

	void Start() {
		if (this.options.Length == 0) {
			Debug.LogWarning("not initialized", this);
		}
	}

	override public string StartText() {
        StringBuilder sb = new StringBuilder(this.startText);
		for (var i = 0; i < this.options.Length; i++) {
			var o = this.options[i];
			sb.Append(string.Format("\n{0}) {1}", i, o.prompt));
		}
		return sb.ToString();
	}

	override public (string response, BaseDialogNode next) RecieveText(string answer) {
		try {
			int choice = Int32.Parse(answer);
			var o = this.options[choice];
			return (response: o.response, next: o.next);
		}
		catch {
			return (response: "Unrecognized option", next: this);
		}
	}
}

[System.Serializable]
public class MenuOption {
	[Multiline]
	public string prompt;
	[Multiline]
	public string response;
	public BaseDialogNode next;
}
