using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DynamicMaskRayClick : MonoBehaviour {
	public LayerMask baseLayerMask = 0;
	public LayerMask lensLayerMask = 0;
	private RaycastHit2D[] resultBuffer; // be careful with this, it is used twice
	private float rayStart = -2;
	private float rayEnd = 5;
	public int framesPerRay = 10;
	private int frameMarker = 0;

	void Start () {
		resultBuffer = new RaycastHit2D[30];
	}
   
	void Update () {
		this.frameMarker++;
		if (Input.GetMouseButtonDown(0)) {
			var top = this.GetTopClickable();
			if (top != null) {
				top.Click();
				top.Highlight();
			}
		} else if (this.frameMarker >= this.framesPerRay) {
			var top = this.GetTopClickable();
			if (top != null) {
				top.Highlight();
			}
			this.frameMarker = 0;
		}
	}

	private List<SpriteMask> GetMasks(Vector3 clickPos) {
		var hits = this.LinecastAll(clickPos, this.lensLayerMask);

		var spMasks = new List<SpriteMask>(hits.Count());
		foreach(var hit in hits) {
			var spMask = hit.transform.GetComponent<SpriteMask>();
			if (spMask) {
				spMasks.Add(spMask);
			}
		}
		return spMasks;
	}

	private IEnumerable<RaycastHit2D> LinecastAll(Vector3 pos, LayerMask mask) {
		var nHits = Physics2D.LinecastNonAlloc(
			new Vector3(pos.x, pos.y, rayStart),
			new Vector3(pos.x, pos.y, rayEnd),
			this.resultBuffer,
			mask
		);
		return this.resultBuffer.Take(nHits);
	}

	// don't really need to return collider
	Collider2D GetTopCollider() {
		Vector3 clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var masks = this.GetMasks(clickedPos);
		var hits = this.LinecastAll(clickedPos, this.baseLayerMask);
		// Debug.Log(string.Format("{0} hits", hits.Count()));

		var spriteRenderers = hits.Select(h => h.transform.GetComponent<SpriteRenderer>());

		SpriteEntry best = null;
		Collider2D collider = null;
		foreach(var r in spriteRenderers) {
			if (r == null) {
				continue;
			}
			var e = new SpriteEntry(r);
			if (
				r.maskInteraction != SpriteMaskInteraction.VisibleOutsideMask
				|| !e.IsFiltered(masks)
			) {
				// greater than means higher
				if (best == null || (e > best)) {
					/*
					if (best != null) {
						// Debug.Log(string.Format("{0} ({1}) is lower than {2} ({3})", collider.gameObject, best.layer, r.gameObject, e.layer));
					} else {
						Debug.Log(string.Format("only {0} ({1})", r.gameObject, e.layer));
					}
					*/
					best = e;
					collider = r.GetComponent<Collider2D>();
				} else {
					// Debug.Log(string.Format("{0} ({1}) is higher than {2} ({3})", collider.gameObject, best.layer, r.gameObject, e.layer));
				}
			} else {
				// Debug.Log(string.Format("filtered {0} ({1})", r.gameObject, e.layer));
			}
		}
		return collider;
	}

	private BaseClickable GetTopClickable() {
		var top = this.GetTopCollider();
		if (top != null) {
			var clickable = top.GetComponent<BaseClickable>();
			return clickable;
		}
		return null;
	}

	public class SpriteEntry {
		public int layer;
		public int order;
		public SpriteEntry(SpriteRenderer r) {
			this.order = r.sortingOrder;
			this.layer = SortingLayer.GetLayerValueFromID(r.sortingLayerID);
		}
		public SpriteEntry(int layerID, int order) {
			this.order = order;
			this.layer = SortingLayer.GetLayerValueFromID(layerID);
		}
		public bool IsFiltered(List<SpriteMask> masks) {
			foreach(var m in masks) {
				if (!m.isCustomRangeActive) {
					return true;
				}
				var maskStart = new SpriteEntry(m.backSortingLayerID, m.backSortingOrder);
				var maskEnd = new SpriteEntry(m.frontSortingLayerID, m.frontSortingOrder);
				if (!(this > maskEnd || maskStart > this)) {
					return true;
				}
			}
			return false;
		}
		public static bool operator >(SpriteEntry a, SpriteEntry b) {
			if (a.layer != b.layer) {
				return a.layer > b.layer;
			}
			return a.order > b.order;
		}
		public static bool operator <(SpriteEntry a, SpriteEntry b) {
			return b > a;
		}
	}

}
