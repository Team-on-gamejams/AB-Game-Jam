using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour {
	[SerializeField] DemonDialog[] demonDialogs;
	[SerializeField] TextMeshPro helpText;

	void Awake() {
		foreach (var i in demonDialogs) {
			i.OnGifted += CheckIsCanOpen;
		}
	}

	void OnDestroy() {
		foreach (var i in demonDialogs) {
			i.OnGifted -= CheckIsCanOpen;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player") {
			helpText.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.tag == "Player") {
			helpText.gameObject.SetActive(false);
		}
	}

	void CheckIsCanOpen() {
		bool findUngifted = false;
		foreach (var i in demonDialogs) {
			if (!i.isGifted) {
				findUngifted = true;
				break;
			}
		}

		if (!findUngifted)
			gameObject.SetActive(false);
	}
}
