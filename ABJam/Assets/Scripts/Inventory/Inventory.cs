using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IDropHandler {
	[Header("Refs")]
	public Transform dragParent;
	public Transform inventoryParent;
	public CraftPanel craftPanel;

	[Header("Prefabs")]
	public GameObject dragItemSlot;

	[NonSerialized] public List<Item> items;

	void Awake() {
		items = new List<Item>();
		GetComponentsInChildren<Item>(items);

		Item.inventory = this;
	}

	public void OnDrop(PointerEventData eventData) {
		Item.isDragCatch = true;
		Item dragItem = eventData.selectedObject.GetComponent<Item>();
		if (dragItem == null)
			return;

		AddItem(dragItem);

		if (craftPanel.items.Contains(dragItem))
			craftPanel.items.Remove(dragItem);

		Destroy(dragItem.gameObject);
	}

	public void AddItem(Item item) {
		bool isFind = false;
		foreach (var i in items) {
			if (i.type == item.type) {
				i.Count += item.Count;
				isFind = true;
				break;
			}
		}
		if (!isFind) {
			GameObject newItemGO = Instantiate(dragItemSlot, transform.position, Quaternion.identity, inventoryParent);
			items.Add(newItemGO.GetComponent<Item>());

			Item newItem = newItemGO.GetComponent<Item>();
			newItem.SetFromItem(item);
		}
	}
}
