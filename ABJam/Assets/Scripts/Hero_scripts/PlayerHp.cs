using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour {
	public Action OnLose;
		
	[SerializeField] sbyte maxHp;
	public sbyte CurrHp {
		get => currHp;
		set {
			currHp = value;
			if (currHp <= 0)
				OnLose?.Invoke();
			if (currHp > maxHp)
				currHp = maxHp;
			SetHpUI();
		}
	}
	sbyte currHp;

	[SerializeField] Image[] hpUi;

	private void Awake() {
		CurrHp = maxHp;
	}

	public void SetHpUI() {
		for(byte i = 0; i < hpUi.Length; ++i) {
			Image img = hpUi[i];
			LeanTween.value(img.gameObject, img.color.a, i < CurrHp ? 1.0f : 0.0f, 0.5f)
			.setOnUpdate((float a)=> {
				Color c = img.color;
				c.a = a;
				img.color = c;
			});
		}
	}
}
