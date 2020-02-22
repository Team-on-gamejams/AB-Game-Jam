using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGame : MenuBase {
	[SerializeField] PlayerHp hp;
	[SerializeField] CanvasGroup androidControlls;

	protected override void Awake() {
		base.Awake();
		hp.OnLose += OnLose;
	}

	private void OnDestroy() {
		hp.OnLose -= OnLose;
	}

	void OnLose() {
		MenuManager.TransitTo(MenuManager.GetNeededMenu<MenuLose>());
	}

	protected override void OnEnter() {
		androidControlls.alpha = 1.0f;
	}

	protected override void OnExit() {
		base.OnExit();
		androidControlls.alpha = 0.0f;
	}

	public void OnWin() {
		MenuManager.TransitTo(MenuManager.GetNeededMenu<MenuWin>());
	}
}
