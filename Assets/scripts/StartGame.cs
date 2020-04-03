using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
	private bool done = false;
	public EventSystem eventSystem;

    void Update() {
		if (!done && Input.GetMouseButtonDown(0)) {
			done = true;
			this.GetComponent<MoveOnEvent>().Move();
			StartCoroutine(this.TriggerStartGame());
		}
    }

	public IEnumerator TriggerStartGame() {
			yield return new WaitForSeconds(3f);
			if (this.eventSystem) {
				this.eventSystem.StartGame();
				Destroy(this.gameObject, 3f);
			}
	}
}
