using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BusCollision : MonoBehaviour {

	BoxCollider2D collider;
	GameManager gameManager;
	Data data;

	BatteryAmount battery;
	[SerializeField] private LayerMask layerMask;

	void Start() {
		collider = GetComponent<BoxCollider2D>();
		battery = FindObjectOfType<BatteryAmount>();
		gameManager = FindObjectOfType<GameManager>();
		data = FindObjectOfType<Data>();
	}

	private void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 5, layerMask);

		//Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 5);

		if (hit.collider != null)
		{
			gameManager.ActivateSwitch(gameManager.loseText.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Battery") {
			battery.batteryAmount = battery.maxBatteryAmount;
			Destroy(col.gameObject);
		}

		if (col.gameObject.tag == "Poor")
		{
			data.AddMoney(5);
			Destroy(col.gameObject);
		}

		if (col.gameObject.tag == "Finish")
		{
			gameManager.ActivateSwitch(gameManager.winText.gameObject);
		}
	}
}
