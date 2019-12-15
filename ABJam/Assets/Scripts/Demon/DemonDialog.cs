using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDialog : MonoBehaviour {
	public bool isGifted;
	public ItemType neededItem;
	public ItemType givedItem;
	public Sprite sprite;
	public string dialogText;

	public Action OnGifted;

	[System.NonSerialized] public DemonWalking walking;

	void Awake() {
		isGifted = false;
		walking = GetComponent<DemonWalking>();
	}
}
