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
	private float batteryAmountMax;

	public delegate void FuelIsEmpty();
	public event FuelIsEmpty fuelIsEmptyEvent;

	void Start() {
		batteryAmountMax = batteryAmount;
		slider = GetComponent<Slider>();
		sliderValue = batteryAmount / batteryAmountMax;
		StartCoroutine(DecreaseBatteryAmount());
	}

	void Update() {
		slider.value = sliderValue / 100;
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

	public void ChangeSliderValue(float value) {
		batteryAmount -= batteryAmount / 100 - value;
		sliderValue = batteryAmount;
	}

	private void CallEvent() {
		if(fuelIsEmptyEvent != null) {
			fuelIsEmptyEvent();
		}
	}

	public void AddAmount(float value) {
		batteryAmount += value;
		if(batteryAmount > 100f) {
			batteryAmount = 100f;
		}
		sliderValue = batteryAmount;
	}
}
