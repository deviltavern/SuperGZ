using CSharpAlgorithm.Algorithm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIK_J1 : CIK_J_BASE {

    public GameObject point;
    public Vector3 offset;

   
    public override void initParameter()
    {
        //'dz', 450,  'dx', 155,  'alf',90 * ToRad, 
        dz = 0;
        dx = 200;
        alf = -90;

        zVec = new Vector3(0, 0, 1);
      
    }

    public override void updateTh()
    {
        // this.transform.localEulerAngles = new Vector3(initTh, 0, 0) + new Vector3(th, 0, 0);

        //this.transform.localEulerAngles =new Vector3(r_z, 0,th- 90 );

        //  point.transform.LookAt(offset+(getCIK_J(2).gameObject.transform.position));
        // Debug.Log("---------------------------------------"+ (float)rotations.GetElement(0, 0));
        // this.tra
        Vector3 dir =Vector3.Normalize( new Vector3(0, getCIK_J(2).transform.position.y - this.transform.position.y, 0));

        this.transform.localEulerAngles = new Vector3( getCIK_J(2).th, (90+this.th)*dir.y, 0 );
        //this.transform.localEulerAngles = new Vector3(getCIK_J(2).th, 90, 0);

    }

    // Use this for initialization
    void Start () {
		
	}
	

}
