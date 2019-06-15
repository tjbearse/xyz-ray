using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class BaseClickable : MonoBehaviour {
	public abstract void Click();
	private Animator anim;
	void Start() {
	 this.anim = this.GetComponent<Animator>();
	}

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

}
