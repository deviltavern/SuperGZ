using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainEvent : MonoBehaviour {


    public static MainEvent Instance;

    public EventSystem eventSystem;
    public GraphicRaycaster grap;

    private void Awake()
    {
        Instance = this;
        eventSystem = this.GetComponent<EventSystem>();
        
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
