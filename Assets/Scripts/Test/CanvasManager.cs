﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {

    public static RectTransform canvas;

    void Awake() {

        canvas = this.GetComponent<RectTransform>();
    
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
