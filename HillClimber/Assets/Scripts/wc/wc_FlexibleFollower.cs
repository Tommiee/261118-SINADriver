// 										   \\
// Written by Wesley Cats on 10 March 2018 \\
//										   \\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follower class with some basic selectable options like;
/// Follow target, look at target, follow from start position or from manual chosen distance
/// </summary>
public class wc_FlexibleFollower : MonoBehaviour
{

	[Tooltip("If the object needs to follow from the local position where it was at the start of the session.")]
	[SerializeField] private bool startPosition = true;
	[Tooltip("The wanted distance from the target in the world space.")]
	[SerializeField] private Vector3 wantedDistance;

	public bool follow = true;
	public bool lookAt = true;
	public float moveSpeed;
	public float minMoveSpeed = 2;
	public string defaultTargetTag = "Player";
	public GameObject target;

	private Vector3 wantedPos;
	private Vector3 targetPos;
	private Vector3 startPos;

	// Use this for initialization
	void Start()
	{
		startPos = transform.position;
		if (startPosition) wantedDistance = startPos - target.transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		CheckDefaults();

		if (!target) {
			return;
		}

		targetPos = target.transform.position;
		wantedPos = targetPos + wantedDistance;
		if (lookAt) transform.LookAt(target.transform);
		if (follow) Move();
	}

	private void Move()
	{
		if (transform.position != wantedPos)
		{
			float step = moveSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, wantedPos, step);
		}
	}

	private void CheckDefaults()
	{
		if (moveSpeed <= 0) moveSpeed = minMoveSpeed;

		if (target == null) target = GameObject.FindGameObjectWithTag(defaultTargetTag);
	}
}
