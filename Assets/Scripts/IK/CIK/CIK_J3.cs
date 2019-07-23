using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIK_J3 : CIK_J_BASE {
    public GameObject point;

    public override void initParameter()
    {
      
        dx = 0;
        alf = 0;
        dz = 0;
        zVec = new Vector3(0, 0, 1);
        alf =-90;
        dx = 110;

        preZr = this.th;
        lastZr = this.th;
    }

    public float yoffset;

    public float lastZr;
    public float preZr;
   
    public float deltaZr;

    public static bool allowAdjust = true;
    public float lastYr;
    public float preYr;

    public float deltaYr;
    public override void updateTh()
    {
        // this.transform.localEulerAngles = new Vector3(0, initTh, 0) + new Vector3(0, th, 0);
        if (allowAdjust == true)
        {

            Debug.Log("J3的自动调整！！！！！！！！");
            float dir = getCIK_J(3).th - 90;
            dir = dir / Mathf.Abs(dir);

            Vector3 cik5Prez = Vector3.Normalize(new Vector3((float)getCIK_J(5).preZ.GetElement(0, 0),
                (float)getCIK_J(5).preZ.GetElement(1, 0),
                (float)getCIK_J(5).preZ.GetElement(2, 0)


                ));
            Vector3 prez = Vector3.Normalize(new Vector3((float)getCIK_J(3).preZ.GetElement(0, 0),
                (float)getCIK_J(3).preZ.GetElement(1, 0),
                (float)getCIK_J(3).preZ.GetElement(2, 0)


                ));
            this.zzAxle = Vector3.Angle(new Vector3(cik5Prez.x, 0, cik5Prez.y),
                new Vector3(prez.x, 0, prez.z)
                );



            preZr = this.th;

            if (preZr != lastZr)
            {
                deltaZr = preZr - lastZr;

                lastZr = preZr;
            }

            preYr = getCIK_J(1).th;


            if (preYr != lastYr)
            {
                deltaYr = preYr - lastYr;

                lastYr = preYr;
            }
            // this.transform.localEulerAngles = new Vector3(0, getCIK_J(1).th, -this.th - (getCIK_J(2).th + 90)+ deltaZr);

            if (CIKDir.preDir.y != 0)
            {

                this.transform.localEulerAngles = new Vector3(0, getCIK_J(1).th, -this.th - (getCIK_J(2).th + 90) + deltaZr);


            }

            if (CIKDir.preDir.x != 0)
            {

                this.transform.localEulerAngles = new Vector3(0, getCIK_J(1).th, -this.th - (getCIK_J(2).th + 90));
            }

            if (CIKDir.preDir.z != 0)
            {

                this.transform.localEulerAngles = new Vector3(0, getCIK_J(1).th - deltaYr, -this.th - (getCIK_J(2).th + 90));
            }

        }
        else
        {
            this.transform.localEulerAngles = new Vector3(0, getCIK_J(1).th, -this.th - (getCIK_J(2).th + 90));

        }


    }




}
