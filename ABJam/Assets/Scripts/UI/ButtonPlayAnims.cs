using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPlayAnims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
	[SerializeField] RectTransform rectBlood;
	[SerializeField] Animator mainMenuAnim;
	[SerializeField] float speed = 1.0f;

	public void OnPointerClick(PointerEventData eventData) {
		if(mainMenuAnim != null)
			mainMenuAnim.enabled = true;
	}

	public void OnPointerEnter(PointerEventData eventData) {
		rectBlood.gameObject.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData) {
		rectBlood.gameObject.SetActive(false);
	}

	void Update() {
		Vector3 vector = Random.insideUnitSphere * speed;
		vector.z = 0;
		rectBlood.anchoredPosition = vector;
	}
}
