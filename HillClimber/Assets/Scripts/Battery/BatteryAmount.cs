using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BatteryAmount : MonoBehaviour {

	Slider slider;
	GameManager gameManager;

	public Image sliderImage;
	public float decreaseAmount = 1f;
	public float waitTime = 0.1f;
	public float batteryAmount = 100f;
	public float maxBatteryAmount = 100f;
	public Hotkeys hotkeys;

	public delegate void FuelIsEmpty();
	public event FuelIsEmpty fuelIsEmptyEvent;

	private void Awake()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	void Start() {
		slider = GetComponent<Slider>();
		slider.value = ClampAmount(batteryAmount, 0, 1);
		StartCoroutine(DecreaseBatteryAmount(decreaseAmount, waitTime));
	}

	void Update() {
		LerpColor();
	}

	IEnumerator DecreaseBatteryAmount(float decreaseAmount, float waitTime) {
		while(batteryAmount > 0) {
			
			if (!hotkeys.godmode) ChangeSliderValue(decreaseAmount);

			yield return new WaitForSeconds(waitTime);
		}
		// LOSE
		gameManager.ActivateSwitch(gameManager.losePanel.gameObject);
		Time.timeScale = 0;
		CallEvent();
		yield return null;
	}

	public void ChangeSliderValue(float value) {
		batteryAmount = batteryAmount - value;
		slider.value = batteryAmount / maxBatteryAmount;
	}

	public void AddAmount(float value) {
		batteryAmount += value;
		if(batteryAmount > 100) {
			batteryAmount = 100f;
		}
		slider.value = batteryAmount / 100f;
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
