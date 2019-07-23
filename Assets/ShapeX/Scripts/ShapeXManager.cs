using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeXManager : MonoBehaviour {

    public static ShapeXManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    
    
}
