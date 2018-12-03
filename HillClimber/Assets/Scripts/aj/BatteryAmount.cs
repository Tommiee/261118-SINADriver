using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BatteryAmount : MonoBehaviour {

	Slider slider;

	public Image sliderImage;
	public float decreaseAmount = 1f;
	public float timeToDecrease = 0.1f;
	public float batteryAmount = 100f;

	public delegate void FuelIsEmpty();
	public event FuelIsEmpty fuelIsEmptyEvent;

	void Start() {
		slider = GetComponent<Slider>();
		slider.value = ClampAmount(batteryAmount, 0, 1);
		StartCoroutine(DecreaseBatteryAmount());
	}

	void Update() {
		LerpColor();
	}

	IEnumerator DecreaseBatteryAmount() {
		while(batteryAmount > 0) {
			ChangeSliderValue(decreaseAmount);
			yield return new WaitForSeconds(timeToDecrease);
		}
		// LOSE
		GetComponent<tw_GameOver>().GameOver();
		CallEvent();
		yield return null;
	}

	public void ChangeSliderValue(float value) {
		batteryAmount = batteryAmount - value;
		slider.value = ClampAmount(batteryAmount, 0, 1);
	}

	public void AddAmount(float value) {
		batteryAmount += value;
		if(batteryAmount > 100) {
			batteryAmount = 100f;
		}
		slider.value = batteryAmount;
	}

	private float ClampAmount(float amount, float min, float max) {
		return (amount - min) / (max - min);
	}

	private void LerpColor() {
		sliderImage.color = Color.Lerp(Color.red, Color.white, slider.value);
	}

	private void CallEvent() {
		if(fuelIsEmptyEvent != null) {
			fuelIsEmptyEvent();
		}
	}
}
