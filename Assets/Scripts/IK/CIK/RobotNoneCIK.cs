using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotNoneCIK : MonoBehaviour {

    public GameObject p0;
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;

    public Vector3 initEuler_p0;
    public Vector3 initEuler_p1;
    public Vector3 initEuler_p2;
    public Vector3 initEuler_p3;
    public Vector3 initEuler_p4;
    public Vector3 initEuler_p5;

    public float p0_p1;
    public float p1_p2;
    public float p2_p3;
    public float p3_p4;
    public float p4_p5;
    

    void Start () {
        initEuler_p0=     p0.transform.localEulerAngles    ;
        initEuler_p1=     p1.transform.localEulerAngles    ;
        initEuler_p2=     p2.transform.localEulerAngles    ;
        initEuler_p3=     p3.transform.localEulerAngles    ;
        initEuler_p4=     p4.transform.localEulerAngles    ;
        initEuler_p5 =    p5.transform.localEulerAngles;


        p0_p1 = Vector3.Distance(p0.transform.position, p1.transform.position);
        p1_p2 = Vector3.Distance(p1.transform.position, p2.transform.position);
        p2_p3 = Vector3.Distance(p2.transform.position, p3.transform.position);
        p3_p4 = Vector3.Distance(p3.transform.position, p4.transform.position);
        p4_p5 = Vector3.Distance(p4.transform.position, p5.transform.position);
      

    }
	
	// Update is called once per frame
	void Update () {
        p0.transform.localEulerAngles = new Vector3(initEuler_p0.x, -CIK_JMatrix.Instance.dth1, initEuler_p0.z);
        p1.transform.localEulerAngles = new Vector3(CIK_JMatrix.Instance.dth2, initEuler_p1.y, initEuler_p1.z);
        p2.transform.localEulerAngles = new Vector3(CIK_JMatrix.Instance.dth3, initEuler_p2.y, initEuler_p2.z);
        p3.transform.localEulerAngles = new Vector3(initEuler_p3.x, CIK_JMatrix.Instance.dth6, initEuler_p3.z);

        p4.transform.localEulerAngles = new Vector3(CIK_JMatrix.Instance.dth5, initEuler_p4.y, initEuler_p4.z);
        p5.transform.localEulerAngles = new Vector3(initEuler_p5.x, CIK_JMatrix.Instance.dth6, initEuler_p5.z);
        // p5.transform.localEulerAngles = new Vector3(p5.transform.localEulerAngles.x, p5.transform.localEulerAngles.y, p5.transform.localEulerAngles.z);

     //   Debug.Log(CIK_JMatrix.Instance.dth1 + ":" +
     //       CIK_JMatrix.Instance.dth2 + ":" +
     //       CIK_JMatrix.Instance.dth3 + ":" +
     //       CIK_JMatrix.Instance.dth4 + ":" +
     //       CIK_JMatrix.Instance.dth5 + ":" +
     //       CIK_JMatrix.Instance.dth6 + ":"
     //
     //
     //       );

    }


  
}
