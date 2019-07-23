using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CIKInfo : MonoBehaviour {

    // Use this for initialization

    public static Text txt;


    private void Awake()
    {
        txt = this.transform.GetComponent<Text>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
