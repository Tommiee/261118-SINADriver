using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FL_Battery : MonoBehaviour {
	
    public float Capacity {
        get; private set;
    }

    private void Start() {
        Capacity = 10;
    }

}
