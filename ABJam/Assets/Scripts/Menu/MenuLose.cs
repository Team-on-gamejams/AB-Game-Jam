using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLose : MenuBase {
	public void ToMainMenu() {
		Application.LoadLevel(Application.loadedLevel);
	}
}
