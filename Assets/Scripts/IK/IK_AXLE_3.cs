using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK_AXLE_3 : IK_AXLE_BASE {

    
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
        A.m03 = a * cos(sita);

        A.m10 = sin(sita);
        A.m11 = 0;
        A.m12 = cos(sita);
        A.m13 = a * sin(sita);

        A.m20 = 0;
        A.m21 = -1;
        A.m22 = 0;
        A.m23 = d;

        A.m30 = 0;
        A.m31 = 0;
        A.m32 = 0;
        A.m33 = 1;
        a = 1.28f;
        d = 0;

        initEuler = -5;
    }

    public override void calculateSita()
    {
        //  base.calculateSita();
        //  float k = (px * px + py * py + pz * pz -
        //      square(getAxle(3).a) -
        //      square(getAxle(4).a) -
        //      square(getAxle(2).d -
        //      square(getAxle(4).d))) / (2 * getAxle(3).a);
        //  Debug.Log(k);
        //  float tb1 = Mathf.Atan2(getAxle(4).a, getAxle(4).d)*Mathf.Rad2Deg;
        // 
        // 
        //  float tb2 = Mathf.Atan2(k, Mathf.Sqrt(square(getAxle(4).a) +
        //      square(getAxle(4).d) - square(k))) * Mathf.Rad2Deg;
        // 
        //  sita = tb1 - tb2;
        // 
        //  this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, -sita , this.transform.localEulerAngles.z);
        //
        //  Debug.Log("IK3 = " + (sita - initEuler));
        //

        //sita = Mathf.Atan2(sin(getSita(3)), cos(getSita(3)));

        float ts1 = px * cos(getSita(1)) + py * sin(getSita(1)) - cos(getSita(2)) * cos(getSita(3)) * cos(getSita(4))*get_a(4);
        float ts2 = square(ts1);
        float ts3 = pz - sin(getSita(2)) * sin(getSita(3)) * sin(getSita(4)) * get_a(4);
        float ts4 = square(ts3) - square(get_a(2))-square(get_a(3));
        float ts5 = 2 * get_a(2) * get_a(3);

        float ts6 = ts4 / ts5;

        float ts7 = Mathf.Sqrt(1 - square(ts6));

        sita = ts7 / ts6;
        Debug.Log("IK3:" + sita);




    }
}
