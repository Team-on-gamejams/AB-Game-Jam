using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeinMenuAnimationSequence : MonoBehaviour {
	[SerializeField] MenuMain MenuMain;
	[SerializeField] Animator MainMenuAnimator;

	public void OnMenuAnimationEnd() {
		MainMenuAnimator.enabled = false;
		LeanTween.delayedCall(0.5f, MenuMain.ToSinematic);
	}
}
