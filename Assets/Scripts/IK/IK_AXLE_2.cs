using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_AXLE_2 : IK_AXLE_BASE {


   
    public override void initParameter()
    {
        base.initParameter();

        iKCoordinateSys.vecx = Vector3.right;
        iKCoordinateSys.vecy = Vector3.down;
        iKCoordinateSys.vecz = Vector3.back;

        A.m00 = cos(sita);
        A.m01 = -sin(sita);
        A.m02 = 0;
        A.m03 = a * cos(sita);

        A.m10 = sin(sita);
        A.m11 = cos(sita);
        A.m12 = 0;
        A.m13 = a * sin(sita);

        A.m20 = 0;
        A.m21 = 0;
        A.m22 = 0;
        A.m23 = d;

        A.m30 = 0;
        A.m31 = 0;
        A.m32 = 0;
        A.m33 = 1;

        d = 0.2f;
        a = 1.07f;

        initEuler = 26.3713f;
    }

    public override void calculateSita()
    {
        base.calculateSita();

        //  sita = Mathf.Atan2((-getAxle(4).a - getAxle(3).a * cos(getAxle(3).sita)) * pz +
        //       (cos(getAxle(1).sita * px + sin(getAxle(1).sita)*py)) *
        //      (getAxle(3).a * sin(getAxle(3).sita - getAxle(4).d)),
        //
        //      (-getAxle(4).d - getAxle(3).a * sin(getAxle(3).sita)) * pz - (cos(getAxle(1).sita) * px
        //      + sin(getAxle(1).sita * py)
        //      ) * (-getAxle(3).a * cos(getAxle(3).sita) - getAxle(4).a) - getAxle(3).sita
        //
        //      )*Mathf.Rad2Deg;
        //
        //
        //
        //  this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x,   initEuler - sita, this.transform.localEulerAngles.z);


        float ts1 = cos(getSita(3)) * get_a(3);
        float ts2 = pz - sin(getSita(2)) * sin(getSita(3)) * sin(getSita(4)) * get_a(4);

        float ts3 = ts1 * ts2;

        float ts4 = sin(getSita(3)) * get_a(3) * (px * cos(getSita(1) + py * sin(getSita(1)) - cos(getSita(2)) * cos(getSita(3)) * cos(getSita(4)) * get_a(4)));

        float ts5 = ts3 - ts4;

        float ts6 = cos(getSita(3)) * get_a(3);
        float ts7 = px*cos(getSita(1))+py*sin(getSita(1))- (cos(getSita(2)) * cos(getSita(3)) * cos(getSita(4)));

        float ts8 = ts6 * ts7;
        float ts9 = sin(getSita(3)) * get_a(3) * (pz - sin(getSita(2)) * sin(getSita(3)) * sin(getSita(4)));
        float ts10 = ts8 - ts9;
        float sita = (ts5 / ts10)*Mathf.Rad2Deg;
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, sita - initEuler, this.transform.localEulerAngles.z);

        Debug.Log("IK_ANGLE2:" + sita);
    }
}
