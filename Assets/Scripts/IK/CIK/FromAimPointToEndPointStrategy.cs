using CSharpAlgorithm.Algorithm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromAimPointToEndPointStrategy : MoveToAimPointStrategy
{
    Transform parent;
    public FromAimPointToEndPointStrategy(GameObject endPoint, GameObject aimHit, GameObject claw, float speed, StrategyMaster master, GameObject originPoint) : base(endPoint, aimHit, claw, speed, master, originPoint)
    {
        parent = aimHit.transform.parent;
    }
    CIK_J5 cik5;
    List<float> orList;


    bool allowSelfadjust;

    bool jump;
    //z:左右，x：前后，y：上下



    float frameTime = 0;

    Vector3 insertVec = new Vector3();

    GameObject rol;
    public override void doSomthing()
    {

      //if (frameTime > 2f)
      //{
      //    cik5.adjustPoseByPreRPValue();
      //
      //    frameTime = 0;
      //}
        frameTime += Time.deltaTime;
     
        //Debug.Log("执行策略：" + code);
        switch (code)
        {
            case 0:
                cik5 = (CIK_J5)CIK_J5.getCIK_J(5);
                countOffset(endPoint, aimHit);
               
                y += 20;
                //x += 5;
                code += 1;

                code = 1997;
                break;

            case 1997:
                // SpecialTool.Instance.updatePR();
                // SpecialTool.Instance.aimObj = endPoint;
                // SpecialTool.Instance.transform.SetParent(null);
                // cik5.SpecialTool.transform.position = endPoint.transform.position + new Vector3(0, 200, 0);
                //  Debug.Log(TEMPSUBVEC.z);

                List<Vector3> tp = CIK_J_BASE.getPosList();

                List<Quaternion> tr = CIK_J_BASE.getRotList();
                List<Matrix> tA = CIK_J_BASE.getMatrixList();
                List<float> th = CIK_J_BASE.getThList();
                int pZ1 = (int)Mathf.Abs(TEMPSUBVEC.z / 100);

             
                for (int i = 0; i < pZ1; i++)
                 {
                     CIKDir.move(z_dir* CIKDir.right*10);
                 }

                int  pZ2 = (int)Mathf.Abs((Mathf.Abs(TEMPSUBVEC.z) -Mathf.Abs(pZ1 * 100))/10);
                
                
               
                for (int i = 0; i < pZ2; i++)
                {
                    CIKDir.move(z_dir * CIKDir.right);
                }
                int pz3 = (int)Mathf.Abs((Mathf.Abs(TEMPSUBVEC.z) - (Mathf.Abs(pZ1 * 100)+ Mathf.Abs(pZ2 * 10))));


                for (int i = 0; i < pz3; i++)
                {
                    CIKDir.move(z_dir * CIKDir.right*0.1f);
                }
                originSumValueList = cik5.adjustPose();


                insertVec = new Vector3(originSumValueList[0], originSumValueList[1], originSumValueList[2]);
               

               // countOffset(endPoint, aimHit);



                //  CIK_J_BASE.setThList(th);
                //  CIK_J_BASE.setMatrixList(tA);
                //  CIK_J_BASE.setPosList(tp);
                //  CIK_J_BASE.setRotList(tr);
                //  CIKDir.move(new Vector3());

                code++;
                    break;

            case 1998:
                Debug.Log("重置完成！");
                break;
            case 1:

                onMove(y, CIKDir.up,y_dir);

               
                break;


           

            case 2:
                onMove(z, CIKDir.right, z_dir);
                break;


            case 3:
                onMove(x, CIKDir.forward, x_dir);
                
                break;

            case 4:
                code=6;
                break;

        //    case 4:
        //        //onMove(y, CIKDir.up, -1);
        //        countOffset(endPoint, aimHit);
        //        code=101;
        //        break;
        //
        //    case 101:
        //
        //        onMove(y, CIKDir.up, y_dir);
        //
        //        break;
        //
        //    case 102:
        //        code = 5;
        //        break;
        //
        //
        //    case 5:
        //        onMove(20, CIKDir.up, 1);
        //
        //        break;
        //
        
                

            case 6:

              
                


                originSumValueList = cik5.adjustPose();

                code = 222;             
           
                break;

            case 222:
                int statu = cik5.interOptimize2(originSumValueList[0],
                  originSumValueList[1],
                  originSumValueList[2],

                  30
                  );
                if (statu == 3)
                {
                    code++;
                }
                break;

            case 223:
                //onMove(30, CIKDir.down, 1);
                code++;
                break;

            case 224:
                code = 7;
                break;


            case 7:
          //  countOffset(endPoint, aimHit);
          //
          //   Debug.Log("x=" + x + ":" + "y=" + y + ":" + "z=" + z + ":" + "endpoint:" + endPoint.transform.position + ":"
          //  
          //       + aimHit.transform.position
          //       );
          //
          //  onMove(z, CIKDir.right, z_dir);

               code++;
                break;

            case 8:
              
               // aimHit.transform.SetParent(cik5.p7.transform);
                code++;
                
                break;

            case 9:
                code++;
                // onMove(x, CIKDir.forward, x_dir);
                break;

            case 10:
                // onMove(20, CIKDir.up, 1);
                code++;
                break;

            case 11:
                //countOffsetTiny(endPoint.transform.Find("tinyPoint").gameObject, aimHit.transform.Find("tinyPoint").gameObject);
               
                countOffsetTiny(endPoint, aimHit);
                cik5.adjustPoseByPreRPValue();

                this.allowSelfadjust = true;
                code++;
                break;

            case 12:
                jump = tinyMoveAllDir(10);

                if (jump == true)
                {
                    code = 15;
                }

                break;


         //case 12:
         //    tinyMove(x, CIKDir.forward, x_dir);
         //    break;
         //
         //case 13:
         //    tinyMove(z, CIKDir.right, z_dir);
         //    break;
         //
         //case 14:
         //    tinyMove(y, CIKDir.up, y_dir);
         //
         //    break;


            case 15:
                countOffsetTiny(endPoint, aimHit);

               // cik5.adjustPoseByPreRPValue();

                this.allowSelfadjust = true;

                code++;
                break;

            case 16:

                bool isOver = tinyMoveAllDir();

                if (isOver == true)
                {

                    code = 19;

                }

                break;
         //   case 16:
         //       tinyMove(x, CIKDir.forward, x_dir);
         //       break;
         //
         //   case 17:
         //       tinyMove(z, CIKDir.right, z_dir);
         //       break;
         //
         //   case 18:
         //       tinyMove(y, CIKDir.up, y_dir);
         //
         //       
         //       break;

            case 19:
                cik5 = (CIK_J5)CIK_J5.getCIK_J(5);


                orList = cik5.adjustPoseByPreRPValue();
                code++;
                break;

            case 20:

                int statu_20 = cik5.interOptimize2(orList[0],
                orList[1],
                orList[2],

                30
                );
                if (statu_20 == 3)
                {
                    code++;
                }
                break;


            case 21:

                countOffsetTiny(endPoint, aimHit);
                code++;

                break;


            case 22:

                jump = tinyMoveAllDir();

                if (jump == true)
                {

                    code = 25;
                }

                break;
          // case 22:
          //     tinyMove(x, CIKDir.forward, x_dir);
          //     break;
          //
          //
          // case 23:
          //     tinyMove(z, CIKDir.right, z_dir);
          //     break;
          //
          // case 24:
          //     tinyMove(y, CIKDir.up, y_dir);
          //
          //     break;


            case 25:
                orList = cik5.adjustPoseByPreRPValue();




                code++;
                break;

            case 26:

                int statu_26 = cik5.interOptimize2(orList[0],
                orList[1],
                orList[2],

                30
                );
                if (statu_26 == 3)
                {
                    code++;
                }


                break;

            case 27:


                StandardPoint point = new StandardPoint(new Vector3(cik5.R_p5,
                        cik5.R_p6,
                        cik5.R_p7
                        ),

                        CIK_J5.Instance.transform.position
                        );
                StandardPoint.list.Add(point);
                code = 300;
                break;
            case 300:

                StandardPoint.saveFromList();
                cik5 = (CIK_J5)CIK_J5.getCIK_J(5);
              // cik5.R_p5 = 0;
              // cik5.R_p6 = 0;
              // cik5.R_p7 = 0;

                aimHit.transform.SetParent(null);

                aimHit.GetComponent<ShapeItemRotRecover>().allowAdjust = true;
              //
              //Rigidbody rig = aimHit.AddComponent<Rigidbody>();
              //rig.mass = 100;
              //rig.angularDrag = 0;
              //rig.drag = 0;
              //aimHit.GetComponent<Collider>().enabled = true;
              //aimHit.GetComponent<Collider>().isTrigger = false;
              //rig.constraints = RigidbodyConstraints.FreezePositionX;
              //master.endStrategy();
                master.changeStrategy(new RecoverToOriginStatuStrategy(endPoint, aimHit, claw, speed, master, originPoint));
                break;

      //    case 8:
      //  
      //        Debug.Log("move:"+x);
      //        onMove(x, CIKDir.forward, x_dir);
      //        break;
      //  
      //  
      //    case 9:
      //        onMove(1, CIKDir.forward, 1);
      //        break;
      //  
      //    case 10:
      //        cik5 = (CIK_J5)CIK_J5.getCIK_J(5);
      //        cik5.R_p5 = 0;
      //        cik5.R_p6 = 0;
      //        cik5.R_p7 = 0;
      //  
      //        aimHit.transform.SetParent(null);
      //        // master.endStrategy();
      //        master.changeStrategy(new RecoverToOriginStatuStrategy(endPoint, aimHit, claw, speed, master, originPoint));
      //        break;
        }
        if (cik5 != null)
        {
            bool banAdjust = false;
            Debug.Log("当执行该策略时一直......................................");

            
            cik5.interOptimize2(CIK_J5.originalRPValue.x,
               CIK_J5.originalRPValue.y,
             CIK_J5.originalRPValue.z, 20, this.allowSelfadjust,out banAdjust);

            if (banAdjust == true)
            {
                this.allowSelfadjust = false;

            }
        }


    }




    public override void onEnd()
    {
        base.onEnd();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override void waitting()
    {
        base.waitting();
    }
}
