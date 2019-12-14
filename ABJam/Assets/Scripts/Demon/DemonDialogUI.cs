using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DemonDialogUI : MonoBehaviour {
	public DemonDialog demon;

	[SerializeField] CanvasGroup canvasGroup;
	[SerializeField] Image image;
	[SerializeField] TextMeshProUGUI dialogText;

	private void Awake() {
		canvasGroup.interactable = canvasGroup.blocksRaycasts = false;
		canvasGroup.alpha = 0.0f;

		//DEBUG ONLY
		ShowDialog();
	}

	public void ShowDialog() {
		canvasGroup.interactable = canvasGroup.blocksRaycasts = true;
		canvasGroup.alpha = 1.0f;

		image.sprite = demon.sprite;
		dialogText.text = demon.dialogText;
	}

	public void CorrectGift() {

	}

	public void WrongGift() {

	}
}
