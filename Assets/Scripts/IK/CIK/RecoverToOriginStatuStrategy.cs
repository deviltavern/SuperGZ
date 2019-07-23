using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverToOriginStatuStrategy : MoveToAimPointStrategy
{
    public RecoverToOriginStatuStrategy(GameObject endPoint, GameObject aimHit, GameObject claw, float speed, StrategyMaster master, GameObject originPoint) : base(endPoint, aimHit, claw, speed, master, originPoint)
    {
    }

    //z:左右，x：前后，y：上下
    public override void doSomthing()
    {
        switch (code)
        {
            case 0:

                countOffset(originPoint);

                y -= 25;
                x -= 20;
                code++;
                break;

            case 1:
                onMove(y, CIKDir.up, y_dir);

                break;

            case 2:
                onMove(x, CIKDir.forward, x_dir);
               

                break;

            case 3:
                onMove(z, CIKDir.right, z_dir);
                break;

            case 4:
                ViewInfo info = new ViewInfo();
                info.arg1 = "next";
                master.getStretegyRevalue(info);
                break;
        }


    }
}
