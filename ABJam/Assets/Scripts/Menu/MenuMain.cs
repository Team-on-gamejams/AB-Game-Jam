using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMain : MenuBase {
	public void Play() {
		MenuManager.TransitTo(MenuManager.GetNeededMenu<MenuGame>());
	}
}
