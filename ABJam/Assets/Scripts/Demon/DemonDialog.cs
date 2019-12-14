using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonDialog : MonoBehaviour {
	public bool isGifted;
	public ItemType neededItem;
	public ItemType givedItem;
	public Sprite sprite;
	public string dialogText;

	void Awake() {
		isGifted = false;
	}
}
