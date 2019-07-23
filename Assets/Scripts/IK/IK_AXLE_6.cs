using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_AXLE_6 : IK_AXLE_BASE {

    public override void initParameter()
    {
        base.initParameter();

        iKCoordinateSys.vecx = Vector3.left;
        iKCoordinateSys.vecy = Vector3.forward;
        iKCoordinateSys.vecz = Vector3.down;

        A.m00 = cos(sita);
        A.m01 = -sin(sita);
        A.m02 = 0;
        A.m03 = 0;

        A.m10 = sin(sita);
        A.m11 = cos(sita);
        A.m12 = 0;
        A.m13 = 0;

        A.m20 = 0;
        A.m21 = 0;
        A.m22 = 1;
        A.m23 = 0;

        A.m30 = 0;
        A.m31 = 0;
        A.m32 = 0;
        A.m33 = 1;

        
    }

    public override void updatePValue()
    {
        base.updatePValue();

        px = this.transform.localPosition.x;
        py = this.transform.localPosition.y;
        pz = this.transform.localPosition.z;
    }
}
