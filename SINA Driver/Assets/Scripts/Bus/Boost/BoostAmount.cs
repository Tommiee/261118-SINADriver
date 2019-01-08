using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class BoostAmount : MonoBehaviour
{

	Slider slider;
	GameManager gameManager;

	public Image sliderImage;
	public float waitTime = 0.1f;
	public UpgradeData upgradeData;
	public Boost boost;

	public delegate void FuelIsEmpty();
	public event FuelIsEmpty fuelIsEmptyEvent;

	private void Awake()
	{
		gameManager = FindObjectOfType<GameManager>();
	}

	void Start()
	{
		slider = GetComponent<Slider>();
		slider.value = ClampAmount(boost.boostAmount, 0, 1);
	}

	void Update()
	{
		LerpColor();
	}

	public void ChangeSliderValue()
	{
		slider.value = boost.boostAmount / boost.maxBoostAmount;
	}

	private float ClampAmount(float amount, float min, float max)
	{
		return (amount - min) / (max - min);
	}

	private void LerpColor()
	{
		sliderImage.color = Color.Lerp(Color.red, Color.white, slider.value);
	}
}
