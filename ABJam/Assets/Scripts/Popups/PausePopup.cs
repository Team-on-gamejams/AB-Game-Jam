using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePopup : Popup {
	bool isShowed;

	private void Start() {
		isShowed = false;
	}

	public override void Show(bool isForce) {
		herowalking.isCanMove = false;
		DemonWalking.canDemonsMove = false;
		base.Show(isForce);
		isShowed = true;
	}

	public override void Hide(bool isForce) {
		base.Hide(isForce);
		herowalking.isCanMove = true;
		DemonWalking.canDemonsMove = true;
		isShowed = false;
	}

	public void OnContinueClick() {
		Hide(false);
	}

	public void OnExitClick() {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (isShowed)
				Hide(false);
			else
				Show(false);
		}
	}
}
