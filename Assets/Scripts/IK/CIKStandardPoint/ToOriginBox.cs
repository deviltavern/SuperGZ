using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToOriginBox : MoveToAimPointStrategy {


    public StrategyMaster master;

    public GameObject aimObj;
    public GameObject endObj;
    public void calculateSubValue(Vector3 aimVec)
    {
        //Vector3 subVec = aimVec - 

    }
    public ToOriginBox(GameObject aimObj,GameObject endObj)
    {

        code = 0;

        speed = 10;


        this.endObj = endObj;
        this.aimObj = aimObj;
    }
    int sListIndex;

    Vector3 clawObj;

    int ziTaiCode = 0;
    public override void doSomthing()
    {
        Debug.Log("ToOriginBox"+code);
        switch (code)
        {
            case 0:

                countOffset(StandardPointReader.sList[sListIndex].getPos(), CIK_J5.Instance.claw);

                code++;

                
                break;

            case 1:
                
                onMove(x, CIKDir.forward, x_dir);
                break;

            case 2:
                onMove(z, CIKDir.right, z_dir);
                break;

            case 3:

                onMove(y, CIKDir.up, y_dir);
               
                break;

                
            case 4:
                countOffsetTiny(StandardPointReader.sList[sListIndex].getPos(), CIK_J5.Instance.claw);
                Debug.Log(StandardPointReader.sList[sListIndex].getPos());
                code++;
                break;

            case 5:
              bool isOver =  tinyMoveAllDir(10);

                if (isOver == true)
                {

                     code++;

                  
                }
                break;

            case 100:

                countOffsetTiny(StandardPointReader.sList[sListIndex].getPos(), CIK_J5.Instance.claw);

                code++;
                break;

            case 101:

                tinyMoveAllDir(5);

                break;

             
            case 6:
               
               aimObj.transform.SetParent(CIK_J5.Instance.claw.transform);
               
               sListIndex++;
               code++;
             
                break;

            case 7:


                //countOffset(StandardPointReader.sList[sListIndex].getPos(), StandardPointReader.sList[sListIndex-1].getPos());
                countOffsetTiny(StandardPointReader.sList[sListIndex].getPos(), CIK_J5.Instance.claw);
                Debug.Log(StandardPointReader.sList[sListIndex].getPos()+"<>"+ CIK_J5.Instance.claw.transform.position);

                code++;
                break;

            case 8:



                bool isOver8 =   tinyMoveAllDir(20);
                if (isOver8 == true)
                {
                   

                    code++;
                }
                break;

            case 9:
                if (ziTaiCode == 3)
                {
                    //aimObj.transform.SetParent(null);
                    //
                    //aimObj.GetComponent<ShapeItemRotRecover>().aimBox = endObj;
                    //aimObj.GetComponent<ShapeItemRotRecover>().allowAdjust = true;
                    //
                    code++;
                }

                break;

            case 10:

                countOffsetTiny(endObj, aimObj);

                aimObj.transform.SetParent(null);
                aimObj.transform.GetComponent<ShapeItemRotRecover>().aimBox = endObj;
                aimObj.transform.GetComponent<ShapeItemRotRecover>().allowAdjust = true;
                break;


            case 11:

                bool jump = tinyMoveAllDir(1);

                if (jump == true)
                {

                    code++;
                }

                break;

            case 12:
             
                break;

            default:

                break;

        }

        ziTaiCode = CIK_J5.Instance.interOptimize2(StandardPointReader.sList[sListIndex].getRot(),50);



    }

}
