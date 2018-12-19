using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {

    public InputManager inputManager;
    public UpgradeData upgradeData;
	public BoostAmount boostAmountScript;

	private Rigidbody2D busFrame;
	
    public float boostForce;
    public float boostAmount;
    public float maxBoostAmount;
	public float boostDelay;
	public float boostDecreaseAmount = 0.5f;

    private void Start() {
        busFrame = GetComponent<Rigidbody2D>();
		boostAmount = maxBoostAmount;
    }

    private void Update() {

        if(inputManager.Space() && upgradeData.boostLevel && boostAmount > 0)
		{
			busFrame.AddForce(transform.right * boostForce);
			boostAmount -= boostDecreaseAmount;
			boostAmountScript.ChangeSliderValue();
		}
    }
}
