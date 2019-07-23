using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIK_J0 : CIK_J_BASE {

    public GameObject point;
    public GameObject point2;
    public override void initParameter()
    {
        zVec = new Vector3(0, 0, 1);
        alf = -90;

    }

    public override void updateTh()
    {


        // point.transform.LookAt(this.transform.position + Vector3.Normalize(
        //     new Vector3(getCIK_J(1).transform.position.x, 0, getCIK_J(1).transform.position.z) -
        //     new Vector3(this.transform.position.x, 0, this.transform.position.z)
        //     )*200);
        //
        // point2.transform.LookAt(point2.transform.position + Vector3.Normalize(
        //     new Vector3(0, getCIK_J(1).transform.position.y, getCIK_J(1).transform.position.z) -
        //     new Vector3(0, point2.transform.position.y, point2.transform.position.z)
        //     ) * 200);
    

        Debug.DrawLine(this.transform.position, this.transform.position + Vector3.up * 500, Color.blue);

        Debug.DrawLine(this.transform.position, this.transform.position + Vector3.right * 500, Color.red);

        Debug.DrawLine(this.transform.position, this.transform.position + Vector3.forward * 500, Color.green);
        Vector3 dir = Vector3.Normalize(new Vector3(0, getCIK_J(2).transform.position.y - getCIK_J(1).transform.position.y, 0));

        this.transform.localEulerAngles = new Vector3(0, (90 + getCIK_J(1).th) * dir.y, 0);

    }


}
