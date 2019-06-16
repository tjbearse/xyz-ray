using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Prompt))]
public class PromptEvents : MonoBehaviour {
	public List<NodeEventEntry> eventList;
	public Dictionary<BaseDialogNode, UnityEvent> eventMap;
    void Start() {
		var p = this.GetComponent<Prompt>();
		p.onNodePresented.AddListener(ReactToNode);
		this.eventMap = new Dictionary<BaseDialogNode, UnityEvent>();

		foreach(var t in this.eventList) {
			this.eventMap[t.node] = t.e;
		}
    }

	void ReactToNode(BaseDialogNode n) {
		Debug.Log("reacting to a node");
		if (this.eventMap.ContainsKey(n)) {
			this.eventMap[n].Invoke();
		}
	}
}

[Serializable]
public class NodeEventEntry {
	public BaseDialogNode node;
	public UnityEvent e;
}
