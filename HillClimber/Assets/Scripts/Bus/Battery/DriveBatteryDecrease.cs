using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveBatteryDecrease : MonoBehaviour {

    [SerializeField] private float decreaseBy = .01f;
    [SerializeField] private BatteryAmount batteryAmount;
	[SerializeField] private Hotkeys hotkeys;

    private InputManager InputManager;

	void Start () {
        InputManager = FindObjectOfType<InputManager>();
    }
	
	void Update () {
        if(InputManager.Up() || InputManager.Down()) {

			if (hotkeys.godmode) return;

			batteryAmount.AddAmount(-decreaseBy);
        }
	}
}
