using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpSlider : MonoBehaviour {
	[SerializeField] Slider[] sliders;

	public void Init(float min, float max) {
		foreach (var slider in sliders) {
			slider.minValue = min;
			slider.maxValue = max;
			slider.value = max;
		}
	}

	public void UpdateValue(float currFill) {
		foreach (var slider in sliders) {
			LeanTween.cancel(gameObject, false);
			LeanTween.value(slider.value, currFill, 0.5f)
				.setOnUpdate((float fill)=> {
					slider.value = fill;
				});
		}
	}
}
