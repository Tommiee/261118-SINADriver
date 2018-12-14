using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BusCollision : MonoBehaviour {

	[SerializeField] private LayerMask layerMask;
	[SerializeField] private int moneyPerPoor = 10;

	public UpgradeData upgradeData;

	BoxCollider2D collider;
	GameManager gameManager;
	BatteryAmount battery;

	void Start() {
		collider = GetComponent<BoxCollider2D>();
		battery = FindObjectOfType<BatteryAmount>();
		gameManager = FindObjectOfType<GameManager>();
	}

	private void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 5, layerMask);

		Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 5);

		if (hit.collider != null)
		{
			gameManager.ActivateSwitch(gameManager.losePanel.gameObject);
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
			upgradeData.moneyAmount += moneyPerPoor;
			Destroy(col.gameObject);
		}

		if (col.gameObject.tag == "Finish")
		{
			gameManager.ActivateSwitch(gameManager.winPanel.gameObject);
			Time.timeScale = 0f;
		}
	}
}
