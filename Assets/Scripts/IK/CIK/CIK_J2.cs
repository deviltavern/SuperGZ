using CSharpAlgorithm.Algorithm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIK_J2 : CIK_J_BASE {
    public override void initParameter()
    {
        dz =0;
        //   dx = 1160;
        dx = 620;
        alf = 0;
        zVec = new Vector3(0, 0, 1);
    }

    public override void updateTh()
    {
        this.transform.localEulerAngles = new Vector3(0, 0, -getCIK_J(1).r_x);

        Matrix mtrix = getCIK_J(0).R * new Matrix(3, 1, new double[] { this.transform.position.x,
            this.transform.position.y,this.transform.position.z
        });
        mtrix.SetElement(0,0, mtrix.GetElement( 0, 0) % 180);
        mtrix.SetElement(1, 0, mtrix.GetElement(1, 0) % 180);
        mtrix.SetElement(2, 0, mtrix.GetElement(2, 0) % 180);
       
        //getCIK_J(2).th
       // this.transform.localEulerAngles = new Vector3(getCIK_J(2).th,0, 0);
    }


}
