using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogPlayer : MonoBehaviour {
	string[] dialogs = new string[] {
		"SANTA! I'm tired of offering gifts for everyone in the Hell!",
		"You invented a holiday, but you never bring us gifts.",
		"And every year I run in search of ideas for gifts to every demon.",
		"Even for Horsemen of the Apocalypse!!!!!",
		"You was bad boi during this year, so you're going straight to...",
		"HELL!!!!!",
	};
	byte i = 0;

	public TextMeshProUGUI text;

	public void ShowDialog() {
		StartCoroutine(Show(dialogs[i++]));
	}

	public IEnumerator Show(string txt) {
		for(int i = 0; i < txt.Length; ++i) {
			text.text = txt.Substring(0, i);
			if(txt == dialogs[dialogs.Length - 1])
				yield return new WaitForSeconds(0.2f);
			else {
				yield return null;
				yield return null;
			}
		}
	}
}
