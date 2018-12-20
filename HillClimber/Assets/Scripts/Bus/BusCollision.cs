using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BusCollision : MonoBehaviour {

	public UpgradeData upgradeData;
	public Sprite happyPoorPerson;

	[SerializeField] private LayerMask layerMask;
	[SerializeField] private int moneyPerPoor = 10;

	BoxCollider2D collider;
	GameManager gameManager;
	BatteryAmount battery;

	void Start() {
		collider = GetComponent<BoxCollider2D>();
		battery = FindObjectOfType<BatteryAmount>();
		gameManager = FindObjectOfType<GameManager>();

		if (upgradeData.currencyLevel == 0) return;
		moneyPerPoor = PlayerPrefs.GetInt("Currency", 10);
	}

	private void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 5, layerMask);

		Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 5);

		if (hit.collider != null)
		{
			Time.timeScale = 0;
			if (upgradeData.triesLeft > 1)
			{
				gameManager.ActivateSwitch(gameManager.losePanel);
			}
			else
			{
				gameManager.ActivateSwitch(gameManager.gameOverPanel);
			}
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
			col.GetComponent<BoxCollider2D>().enabled = false;
			col.GetComponent<SpriteRenderer>().sprite = happyPoorPerson;
		}

		if (col.gameObject.tag == "Finish")
		{
			gameManager.ActivateSwitch(gameManager.winPanel.gameObject);
			Time.timeScale = 0f;
		}
	}
}
