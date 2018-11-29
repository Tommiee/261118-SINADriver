using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class aj_BusCollision : MonoBehaviour {

	BoxCollider2D collider;

	void Start() {
		collider = GetComponent<BoxCollider2D>();
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Battery") {
			//Battery has collided with the bus!
			print("Battery collision!");
			Destroy(col.gameObject);
		}
    }
}
