using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGame : MenuBase {
	[SerializeField] PlayerHp hp;
	[SerializeField] AudioSource mainTheme;

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
		mainTheme.Play();
	}
}
