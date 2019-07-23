using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_AXLE_1 : IK_AXLE_BASE {

    // Use this for initialization

    public override void initParameter()
    {
        base.initParameter();
     //   Mathf.Atan2();
        iKCoordinateSys.vecx = Vector3.left;
        iKCoordinateSys.vecy = Vector3.down;
        iKCoordinateSys.vecz = Vector3.back;
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

      
        d = 0;

        initEuler = 180;
    }

    public override void calculateSita()
    {
        base.calculateSita();

        sita = Mathf.Atan2(py, px)*Mathf.Rad2Deg - Mathf.Atan2(d,Mathf.Sqrt(1-d*d)) * Mathf.Rad2Deg;
      

        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, sita - initEuler);
    }
    void Start () {

        Debug.Log(Mathf.Cos(60 * Mathf.PI / 180f));

    }

    public override void drawCoordinateSys()
    {
        base.drawCoordinateSys();

    }
}
