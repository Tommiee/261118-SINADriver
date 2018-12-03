using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class jv_moneycount : MonoBehaviour {
    public TextMeshProUGUI money;
    public int MoneyAmount
    {
        get{return moneyAmount;}
        set { moneyAmount = value; }
    }
    private int moneyAmount;
    private string zero = ": 0";

    /*
     * public var GetterSetterVar { get; set; }
     * 
     * private var privateVarForGetterSetter;
     * public var AlsoGetterSetter {
     *      get {
     *          return privateVarForGetterSetter;
     *      }
     *      set {
     *          privateVarForGetterSetter = value; // value will automatically be determined by the getter/setter
     *      }
     * }
     */
    
	// Use this for initialization

    void Start()
    {
        
        DontDestroyOnLoad(this.gameObject);
        
    }
    
    public void AddMoney(int value)
    {
        moneyAmount += value;
        if(moneyAmount >=  10)
        {
            zero = ": ";
        }
        money.text = zero + moneyAmount;

    }

}
