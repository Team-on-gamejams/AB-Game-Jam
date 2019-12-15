using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogPlayer : MonoBehaviour {
	string[] dialogs = new string[] {
		"Санта! Я ЗАДОВБАВСЯ вигадувати подарунки для всього пекВа!",
		"Ти вигадав свято, а подаВунків нам не приносиш.",
		"І кожного року я бігаю в пошуках ідей для кожного ДОВБАНОГО біса!",
		"До БІСА кожного бігаю!!!!!",
		"Тепер твоя черга, ти був поганим цього року і потВапвяєш до...",
		"ПEKBA!!!!!",
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
