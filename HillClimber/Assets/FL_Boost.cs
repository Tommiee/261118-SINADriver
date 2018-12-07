using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FL_Boost : MonoBehaviour {

    private Rigidbody2D busFrame;
    private tw_InputManager tw_inputManager;

    public float boostForce;
    public int boostAmount;
    public float boostDelay;

    private void Start() {
        busFrame = GetComponent<Rigidbody2D>();
        tw_inputManager = GetComponent<tw_InputManager>();
    }

    private void Update() {

        if(tw_inputManager.Space()) {
            Debug.Log("Boost");
            StartCoroutine(Boost(boostAmount, boostDelay));
        }

        Debug.DrawRay(transform.position, transform.right * 10, Color.red);
    }

    IEnumerator Boost(int amount, float delay) {
        for(int i = 0; i < amount; i++) {
            busFrame.AddForce(transform.right * boostForce);
            yield return new WaitForSeconds(delay);
        }
    }

}
