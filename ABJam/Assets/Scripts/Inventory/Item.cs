using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Item : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	static public Inventory inventory;
	static public bool isDragCatch;

	public byte Count {
		get => count;
		set {
			if (count == 255) {
				countText.text = "∞";
				return;
			}
			count = value;
			countText.text = count.ToString();

		}
	}


	[Header("Data")]
	public ItemType type;
	[SerializeField] byte count;

	[Header("Refs")]
	[SerializeField] Image img;
	[SerializeField] TextMeshProUGUI countText;

	Item dragItem;
	bool isCreateByDrag;

	private void Awake() {
		isCreateByDrag = false;
		Count = count;
	}

	public void OnBeginDrag(PointerEventData eventData) {
		isDragCatch = false;
		--Count;

		GameObject dragObject;

		if (isCreateByDrag) {
			dragObject = gameObject;
		}
		else {
			dragObject = Instantiate(inventory.dragItemSlot, transform.position, Quaternion.identity, inventory.dragParent);
		}

		dragItem = dragObject.GetComponent<Item>();
		dragItem.SetFromItem(this);
		dragItem.Count = 1;
		dragItem.isCreateByDrag = true;

		dragItem.img.raycastTarget = false;

		dragItem.countText.alpha = 0.0f;
		dragItem.countText.raycastTarget = false;

		eventData.selectedObject = dragItem.gameObject;
	}

	public void OnDrag(PointerEventData eventData) {
		dragItem.transform.position += (Vector3)eventData.delta;
	}

	public void OnEndDrag(PointerEventData eventData) {
		dragItem.img.raycastTarget = true;

		if (!isDragCatch) {
			inventory.AddItem(dragItem);
			Destroy(dragItem.gameObject);
		}

		if(Count == 0) {
			inventory.items.Remove(this);
			Destroy(gameObject);
		}

		dragItem = null;
	}

	public void SetFromItem(Item item) {
		type = item.type;
		Count = item.Count;

		img.sprite = item.img.sprite;
		img.rectTransform.sizeDelta = item.img.rectTransform.sizeDelta;
	}
}
