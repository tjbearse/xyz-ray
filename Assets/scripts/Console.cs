using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Console : MonoBehaviour {
	private Text text;
	private Queue<char> textBuffer;
	public int maxLines = 4;
	private int lines = 0;

	void Start () {
		this.textBuffer = new Queue<char>();
		this.text = this.GetComponent<Text>();
	}

	public void SendText(string txt) {
		this.lines++;
		foreach (char c in txt) {
			this.textBuffer.Enqueue(c);
		}
		this.textBuffer.Enqueue('\n');
		if (this.lines > this.maxLines) {
			int i = this.text.text.IndexOf('\n');
			this.text.text = this.text.text.Substring(i+1);
		}
	}

	void Update() {
		if (this.textBuffer.Count > 0) {
			this.text.text += this.textBuffer.Dequeue();
		}
	}
}
