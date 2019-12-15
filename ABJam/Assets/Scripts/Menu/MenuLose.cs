using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLose : MenuBase {
	[SerializeField] AudioSource mainTheme;
	
	public void ToMainMenu() {
		Application.LoadLevel(Application.loadedLevel);
	}

	protected override void OnEnter() {
		StartCoroutine(FadeOut(mainTheme, 1.0f));
	}

	public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime) {
		float startVolume = audioSource.volume;

		while (audioSource.volume > 0) {
			audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

			yield return null;
		}

		audioSource.Stop();
		audioSource.volume = startVolume;
	}
}
