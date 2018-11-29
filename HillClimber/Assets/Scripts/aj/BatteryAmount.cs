using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BatteryAmount : MonoBehaviour {

	Slider slider;
	float sliderValue;

	public Image sliderImage;
	public float decreaseAmount = 0.01f;
	public float timeToDecrease = 0.1f;
	public float batteryAmount = 100f;

	public delegate void FuelIsEmpty();
	public event FuelIsEmpty fuelIsEmptyEvent;

	void Start() {
		slider = GetComponent<Slider>();
		sliderValue = batteryAmount / 100;
		StartCoroutine(DecreaseBatteryAmount());
	}

	void Update() {
		slider.value = sliderValue;
		sliderImage.color = Color.Lerp(Color.red, Color.white, sliderValue);
	}

	IEnumerator DecreaseBatteryAmount() {
		while(sliderValue > 0) {
			ChangeSliderValue(decreaseAmount);
			yield return new WaitForSeconds(timeToDecrease);
		}
		CallEvent();
		yield return null;
	}

	private void CallEvent() {
		if(fuelIsEmptyEvent != null)
			fuelIsEmptyEvent();
	}

	public void ChangeSliderValue(float value) {
		sliderValue -= value;
	}
}
