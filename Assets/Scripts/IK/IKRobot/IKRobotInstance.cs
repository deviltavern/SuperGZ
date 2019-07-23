using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKRobotInstance : MonoBehaviour {


    public static IKRobotInstance Instance;

    private void Awake()
    {
        Instance = this;
    }

}
