using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fl_DriveBatteryDecrease : MonoBehaviour {

    [SerializeField] private float decreaseBy = .1f;

    [SerializeField] private BatteryAmount batteryAmount;
    private tw_InputManager tw_InputManager;

	void Start () {
        tw_InputManager = GetComponent<tw_InputManager>();
    }
	
	void Update () {
        if(tw_InputManager.Up() || tw_InputManager.Down()) {
            batteryAmount.AddAmount(-decreaseBy);
        }
	}
}
