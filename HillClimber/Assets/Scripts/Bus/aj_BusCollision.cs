using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class aj_BusCollision : MonoBehaviour {

	BoxCollider2D collider;
	
	BatteryAmount batteryAmount;

	void Start() {
		collider = GetComponent<BoxCollider2D>();
		batteryAmount = FindObjectOfType<BatteryAmount>();
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Battery") {
			batteryAmount.AddAmount(25f);
			Destroy(col.gameObject);
		}
    }
}
