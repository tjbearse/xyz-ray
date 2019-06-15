using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// adapted from https://forum.unity.com/threads/c-object-on-top-with-highest-sortingorder-is-not-selected-first.244627/#post-1618354
// which had the right idea but was pretty buggy
public class RayClick : MonoBehaviour {
	public LayerMask layerMask = 0;
	private RaycastHit2D[] hits; // size of this array determines max amount of hits
	private float rayStart = -2;
	private float rayEnd = 5;
   
	void Start () {
		this.hits = new RaycastHit2D[10];
	}
   
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			var top = this.GetTopCollider();
			if (top != null) {
				var clickable = top.GetComponent<BaseClickable>();
				if (clickable != null) {
					clickable.Click();
				}
			}
		}
	}
   
	Collider2D GetTopCollider() {
		Vector3 clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		this.hits = Physics2D.LinecastAll(
			new Vector3(clickedPos.x, clickedPos.y, rayStart),
			new Vector3(clickedPos.x, clickedPos.y, rayEnd),
			layerMask
		);
	   
		if(hits.Length == 0) {
			return null;
		}

		SpriteRenderer current = hits[0].transform.GetComponent<SpriteRenderer>();
		int topHit = 0;
		int bestLayer = SortingLayer.GetLayerValueFromID(current.sortingLayerID);
		int bestOrder = current.sortingOrder;
		   
		for (int i=1; i < hits.Length; i++) {
			current = hits[i].transform.GetComponent<SpriteRenderer>();
			int curLayer = SortingLayer.GetLayerValueFromID(current.sortingLayerID);
			if (curLayer > bestLayer) {
				bestLayer = curLayer;
				topHit = i;
				bestOrder = current.sortingOrder;
			} else if (curLayer == bestLayer) {
				int curOrder = current.sortingOrder;
				if (curOrder > bestOrder) {
					topHit = i;
					bestOrder = current.sortingOrder;
				}
			}
		}
		return hits[topHit].collider;
	}
}
