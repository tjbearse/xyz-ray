using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prompt : MonoBehaviour {
	public InputField inputText;
	public Console prompt;
	public List<SecurityQuestion> questions;

	public void Start() {
		if (this.questions == null) {
			this.questions = new List<SecurityQuestion>();
		}
		if (this.questions.Count > 0) {
			this.prompt.SendText(this.questions[0].question);
		}
	}

	private void SendCurrent() {
		if (this.questions.Count > 0) {
			this.prompt.SendText(this.questions[0].question);
		}
	}

	public void RelayMessage() {
		if(Input.GetButtonDown("Submit")){
			string text = inputText.text;
			inputText.text = "";
			if (this.questions.Count == 0) {
				return;
			}
			if (text == this.questions[0].answer) {
				this.prompt.SendText(string.Format("{0} is correct!", text));
				this.questions.RemoveAt(0);
			} else {
				this.prompt.SendText(string.Format("{0} is incorrect", text));
			}
			this.SendCurrent();
		}
	}

	// TODO make a text buffer of lines
}

