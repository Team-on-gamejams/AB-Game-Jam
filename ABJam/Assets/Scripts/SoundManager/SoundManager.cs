using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {
	[Header("Music")]
	[SerializeField] AudioSource mainThemeSource;
	[SerializeField] Slider mainThemeVolumeSlider;

	[Header("Sound")]
	[SerializeField] AudioSource soundsSource;
	[SerializeField] Slider soundsSourceVolumeSlider;

	private void Awake() {
		mainThemeVolumeSlider.value = mainThemeSource.volume;
		soundsSourceVolumeSlider.value = soundsSource.volume;
	}

	public void SetNewMusicVolume() {
		mainThemeSource.volume = mainThemeVolumeSlider.value;
	}

	public void SetNewSoundVolume() {
		soundsSource.volume = soundsSourceVolumeSlider.value;
	}
}
