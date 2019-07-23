using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_AXLE_0 : IK_AXLE_BASE {
    public override void initParameter()
    {
        base.initParameter();

        iKCoordinateSys.vecx = Vector3.left;
        iKCoordinateSys.vecy = Vector3.back;
        iKCoordinateSys.vecz = Vector3.up;
    }
}
