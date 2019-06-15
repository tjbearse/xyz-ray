using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour {
	[SerializeField] public Vector2? target;
	public float speed = 1f;
    void Update() {
		if (this.target.HasValue) {
			this.transform.position = Vector2.MoveTowards(this.transform.position, this.target.Value, this.speed);
			if ((Vector2) this.transform.position == this.target.Value) {
				this.target = null;
			}
		}
        
    }
}
