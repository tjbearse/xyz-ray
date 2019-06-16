using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour {
	[SerializeField] public Vector3? target;
	public float speed = 1f;
    void Update() {
		if (this.target.HasValue) {
			this.transform.position = Vector3.MoveTowards(this.transform.position, this.target.Value, this.speed);
			if (this.transform.position == this.target.Value) {
				this.target = null;
			}
		}
        
    }
}
