using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Prompt))]
public class PromptEvents : MonoBehaviour {
	public List<NodeEventEntry> eventList;
	public Dictionary<BaseDialogNode, UnityEvent> exposeEventMap;

	public List<NodeAnswerEventEntry> answerEventList;
	public Dictionary<BaseDialogNode, NodeAnswerEventEntry.AnswerEvent> answerEventMap;

	void Start() {
		var p = this.GetComponent<Prompt>();
		p.onNodePresented.AddListener(ReactToNode);
		p.onNodeAnswered.AddListener(ReactToNodeAnswer);

		this.exposeEventMap = new Dictionary<BaseDialogNode, UnityEvent>();
		this.answerEventMap = new Dictionary<BaseDialogNode, NodeAnswerEventEntry.AnswerEvent>();

		foreach(var t in this.eventList) {
			this.exposeEventMap[t.node] = t.e;
		}
		foreach(var t in this.answerEventList) {
			this.answerEventMap[t.node] = t.e;
		}
	}

	void ReactToNode(BaseDialogNode n) {
		if (this.exposeEventMap.ContainsKey(n)) {
			this.exposeEventMap[n].Invoke();
		}
	}
	void ReactToNodeAnswer(BaseDialogNode n, string text) {
		if (this.answerEventMap.ContainsKey(n)) {
			this.answerEventMap[n].Invoke(text);
		}
	}
}

[Serializable]
public class NodeEventEntry {
	public BaseDialogNode node;
	public UnityEvent e;
}

[Serializable]
public class NodeAnswerEventEntry {
	public BaseDialogNode node;
	public AnswerEvent e;
	[Serializable]
	public class AnswerEvent : UnityEvent<string> {};
}
