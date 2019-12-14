using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GiftHandler : MonoBehaviour, IDropHandler {
	[SerializeField] DemonDialogUI demonDialog;

	public void OnDrop(PointerEventData eventData) {
		Item item = eventData.selectedObject.GetComponent<Item>();
		if (item == null)
			return;

		if (demonDialog.demon.neededItem == item.type) {
			Item.isDragCatch = true;
		}
		else {

		}


	}
}
