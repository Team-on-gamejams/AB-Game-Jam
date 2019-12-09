using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShowOnMouseOver : MonoBehaviour, IPointerEnterHandler {
	static GameObject curr;

	[SerializeField] GameObject go;

	public void OnPointerEnter(PointerEventData eventData) {
		curr?.SetActive(false);
		(curr = go)?.SetActive(true);
	}
}
