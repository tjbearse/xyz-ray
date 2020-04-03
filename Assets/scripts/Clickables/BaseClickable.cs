using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseClickable : MonoBehaviour {
	public abstract void Click();
	private Animator anim;
	private int hoverReset = 0;

	void Start() {
	 this.anim = this.GetComponent<Animator>();
	}

	void Update() {
		if (hoverReset > 0) {
			hoverReset--;
		} else if (hoverReset == 0) {
			this.anim.SetBool("Hover", false);
			hoverReset--;
		}
	}

	public void Highlight() {
		if (this.anim) {
			this.anim.SetBool("Hover", true);
			hoverReset = 10;
		}
	}

	/*
	void OnMouseEnter() {
		if (this.anim) {
			this.anim.SetBool("Hover", true);
		}
	}

	void OnMouseExit() {
		if (this.anim) {
			this.anim.SetBool("Hover", false);
		}
	}
	*/

}
