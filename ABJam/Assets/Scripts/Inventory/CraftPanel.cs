using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CraftPanel : MonoBehaviour, IDropHandler {
	[NonSerialized] public List<Item> items;

	[SerializeField] ItemType[] types;
	[SerializeField] Sprite[] images;

	[Header("Refs")]
	[SerializeField] TextMeshProUGUI craftText;

	private void Awake() {
		items = new List<Item>();
	}

	public void TryCraft() {
		Item crafted = Craft();

		if (crafted != null) {
			craftText.text = "Crafted!";
		}
		else {
			craftText.text = "Can't craft";
		}

		LeanTween.value(craftText.gameObject, craftText.alpha, 1.0f, 1.0f)
		.setOnUpdate((float a)=> {
			craftText.alpha = a;
		})
		.setOnComplete(() => {
			LeanTween.value(craftText.gameObject, craftText.alpha, 0.0f, 1.0f)
			.setOnUpdate((float a) => {
				craftText.alpha = a;
			})
			.setDelay(0.5f);
		});
	}

	public Item Craft() {
		Item crafted = null;

		if (CheckItem(ItemType.Sweater, ItemType.Paints)) { 
			crafted = CreateItem(ItemType.SatanSweater);
		}
		else if (CheckItem(ItemType.Bible, ItemType.Paints)) {
			crafted = CreateItem(ItemType.SatanBible);
		}
		else if (CheckItem(ItemType.Doll, ItemType.Paints)) {
			crafted = CreateItem(ItemType.DeamonDoll);
		}
		else if (CheckItem(ItemType.Candy, ItemType.Knife)) {
			crafted = CreateItem(ItemType.Impaler);
		}
		else if (CheckItem(ItemType.Doll, ItemType.Knife)) {
			crafted = CreateItem(ItemType.HeadlessDoll);
		}
		else if (CheckItem(ItemType.Soap, ItemType.Garland)) {
			crafted = CreateItem(ItemType.Noose);
		}

		else if (CheckItem(ItemType.Bones, ItemType.Sulfur, ItemType.Horns)) {
			crafted = CreateItem(ItemType.Scooter);
		}
		else if (CheckItem(ItemType.Pizza, ItemType.HumanHand, ItemType.PentagramPostcard)) {
			crafted = CreateItem(ItemType.Friend);
		}

		if (crafted != null) {
			foreach (var item in items) 
				Destroy(item.gameObject, 0.5f);
			items.Clear();

			items.Add(crafted);
		}

		return crafted;
	}

	public bool CheckItem(ItemType i1, ItemType i2) {
		for(int i = 0; i < items.Count; ++i) {
			if(items[i] == null) {
				items.RemoveAt(i);
				--i;
			}
		}
		if (items.Count != 2)
			return false;

		foreach (var item in items)
			if (
				item.type != i1 &&
				item.type != i2 
				)
				return false;

		return true;
	}

	public bool CheckItem(ItemType i1, ItemType i2, ItemType i3) {
		if (items.Count != 3)
			return false;

		foreach (var item in items) 
			if(
				item.type != i1 &&
				item.type != i2 &&
				item.type != i3
				)
				return false;

		return true;
	}

	public Item CreateItem(ItemType itemType) {
		Item.isCanDrag = true;

		Vector3 centrePos = Vector2.zero;
		foreach (var i in items) {
			centrePos += i.transform.position;
		}
		if(items.Count != 0)
			centrePos /= items.Count;
		else
			Item.isCanDrag = true;

		GameObject itemgo = Item.CreateDragItem(centrePos);
		Item item = itemgo.GetComponent<Item>();

		foreach (var i in items) {
			LeanTween.move(i.gameObject, centrePos, 0.5f)
			.setOnComplete(()=> { 
				Item.isCanDrag = true;
				if(item != null)
					item.Show();
			});
		}

		Item.SetDragItem(item, items.Count != 0 ? items[0] : null);

		item.type = itemType;

		item.SetImage(images[Array.IndexOf(types, itemType)]);
		item.SetCountForce(1);
		item.ActivateRaycast();
		item.Hide();
		return item;
	}

	public void OnDrop(PointerEventData eventData) {
		Item.isDragCatch = true;
		if(eventData.selectedObject != null && !items.Contains(eventData.selectedObject.GetComponent<Item>()))
			items.Add(eventData.selectedObject.GetComponent<Item>());
	}
}
