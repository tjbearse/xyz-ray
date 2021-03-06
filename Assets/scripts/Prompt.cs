﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Prompt : MonoBehaviour {
	public InputField inputText;
	public Console prompt;
	public BaseDialogNode dialogNode;
	public NodePresented onNodePresented;
	public NodeAnswered onNodeAnswered;

	public void Awake() {
		if (this.onNodePresented == null) {
			this.onNodePresented = new NodePresented();
		}
		if (this.onNodeAnswered == null) {
			this.onNodeAnswered = new NodeAnswered();
		}
	}

	public void OnEnable() {
		if (this.dialogNode == null) {
			Debug.LogError("started prompt w/o dialog", this);
		}
		this.ProcessNode();
        this.inputText.ActivateInputField();
	}

	private IEnumerator ProcessNodeDelay() {
		yield return new WaitForSeconds(.5f);
		this.ProcessNode();
	}

	private void ProcessNode() {
		this.onNodePresented.Invoke(this.dialogNode);
		this.prompt.SendText("\n" + this.dialogNode.StartText());
        this.inputText.ActivateInputField();
	}

	private void Update() {
		this.inputText.ActivateInputField();
	}

	public void RelayMessage() {
		if(Input.GetButtonDown("Submit")){
			string text = inputText.text;
			inputText.text = "";
			(string response, BaseDialogNode next) = this.dialogNode.RecieveText(text);
			this.onNodeAnswered.Invoke(this.dialogNode, text);
			if (response != "") {
				this.prompt.SendText(response);
			}
			if (next != null) {
				this.dialogNode = next;
			}

			StartCoroutine(this.ProcessNodeDelay());
		}
	}
}
[System.Serializable]
public class NodePresented: UnityEvent<BaseDialogNode> {}
public class NodeAnswered: UnityEvent<BaseDialogNode, string> {}
