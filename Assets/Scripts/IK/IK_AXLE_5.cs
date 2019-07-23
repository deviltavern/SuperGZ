using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_AXLE_5 : IK_AXLE_BASE {

    public override void initParameter()
    {
        base.initParameter();
        iKCoordinateSys.Center = IK_AXLE_4.IK_AXLE_4Vec;

        iKCoordinateSys.vecx = Vector3.left;
        iKCoordinateSys.vecy = Vector3.forward;
        iKCoordinateSys.vecz = Vector3.down;



        A.m00 = cos(sita);
        A.m01 = 0;
        A.m02 = -sin(sita);
        A.m03 = 0;

        A.m10 = sin(sita);
        A.m11 = 0;
        A.m12 = cos(sita);
        A.m13 = 0;

        A.m20 = 0;
        A.m21 = -1;
        A.m22 = 0;
        A.m23 = 0;

        A.m30 = 0;
        A.m31 = 0;
        A.m32 = 0;
        A.m33 = 1;


        Debug.Log(Mathf.Atan2(10, 20)*Mathf.Rad2Deg);
    }
}
