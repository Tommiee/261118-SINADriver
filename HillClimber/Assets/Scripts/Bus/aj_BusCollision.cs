using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class aj_BusCollision : MonoBehaviour {

	BoxCollider2D collider;
	
	BatteryAmount battery;

	void Start() {
		collider = GetComponent<BoxCollider2D>();
		battery = FindObjectOfType<BatteryAmount>();
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Battery") {
			battery.batteryAmount = battery.maxBatteryAmount;
			Destroy(col.gameObject);
		}
    }
}
