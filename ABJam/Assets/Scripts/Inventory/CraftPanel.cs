using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CraftPanel : MonoBehaviour, IDropHandler {
	[NonSerialized] public List<Item> items;

	private void Awake() {
		items = new List<Item>();
	}

	public bool CanCraft(params Item[] items) {
		return false;
	}

	public Item Craft(params Item[] items) {
		return null;
	}

	public void OnDrop(PointerEventData eventData) {
		Item.isDragCatch = true;
		if(!items.Contains(eventData.selectedObject.GetComponent<Item>()))
			items.Add(eventData.selectedObject.GetComponent<Item>());
	}
}
