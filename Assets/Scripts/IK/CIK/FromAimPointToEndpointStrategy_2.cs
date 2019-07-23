using CSharpAlgorithm.Algorithm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromAimPointToEndpointStrategy_2 : MoveToAimPointStrategy
{
    Transform parent;
    public FromAimPointToEndpointStrategy_2(GameObject endPoint, GameObject aimHit, GameObject claw, float speed, StrategyMaster master, GameObject originPoint) : base(endPoint, aimHit, claw, speed, master, originPoint)
    {
        parent = aimHit.transform.parent;
    }
    CIK_J5 cik5;
    List<float> orList;


    bool allowSelfadjust;

    bool jump;
    //z:左右，x：前后，y：上下

    Vector3 insertVec;

    float frameTime = 0;

    int PZ1;
    int PZ2;
    int PZ3;
    float PZ123Dir;

    int PX1;
    int PX2;
    float PX12Dir;


    int PZ4;
    int PX3;

    int PY1;
    int PY2;
    int PY3;

    float PY123Dir;

    int stepIndex;
    List<Vector3> tp           ;
                               
                               
      List<Quaternion> tr      ;
      List<Matrix> tA          ;
    List<float> th;
    public int subAbs(float x, float y)
    {
        return (int)(Mathf.Abs(x) - Mathf.Abs(y));
    }
    public override void doSomthing()
    {

        //if (frameTime > 2f)
        //{
        //    cik5.adjustPoseByPreRPValue();
        //
        //    frameTime = 0;
        //}
        frameTime += Time.deltaTime;

        Debug.Log("执行策略：" + code);
        switch (code)
        {
            case 0:

                CIK_J3.allowAdjust = false;
                cik5 = (CIK_J5)CIK_J5.getCIK_J(5);
                countOffset(endPoint, aimHit);

                y += 10;
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

              tp  = CIK_J_BASE.getPosList();

              tr = CIK_J_BASE.getRotList();
              tA  = CIK_J_BASE.getMatrixList();
              th      = CIK_J_BASE.getThList();
              PZ1 =     (int)Mathf.Abs(TEMPSUBVEC.z / 100);


                Debug.Log("执行开始的AIMhIT" + aimHit.transform.position);

                for (int i = 0; i < PZ1; i++)
                {
                    CIKDir.move(z_dir * CIKDir.right * 10);
                }

                PZ2 = (int)Mathf.Abs((Mathf.Abs(TEMPSUBVEC.z) - Mathf.Abs(PZ1 * 100)) / 10);

                PZ123Dir = z_dir;
                PX12Dir = x_dir;

                for (int i = 0; i < PZ2; i++)
                {
                    CIKDir.move(z_dir * CIKDir.right);
                }
                PZ3 = (int)Mathf.Abs((Mathf.Abs(TEMPSUBVEC.z) - (Mathf.Abs(PZ1 * 100) + Mathf.Abs(PZ2 * 10))));


                for (int i = 0; i < PZ3; i++)
                {
                    CIKDir.move(z_dir * CIKDir.right * 0.1f);
                }

                PX1 = (int)Mathf.Abs((Mathf.Abs(TEMPSUBVEC.x)) / 10);



                for (int i = 0; i < PX1; i++)
                {
                    CIKDir.move(x_dir * CIKDir.forward);
                }



                PX2 = (int)Mathf.Abs((Mathf.Abs(TEMPSUBVEC.x) - Mathf.Abs(PX1 * 10)));



                for (int i = 0; i < PX2; i++)
                {
                    CIKDir.move(x_dir * CIKDir.forward*0.1f);
                }
                
                Debug.Log("执行完后的AIMhIT" + aimHit.transform.position);

                PY1 = subAbs(TEMPSUBVEC.y, 0) / 10 ;
                PY123Dir = y_dir;

                for (int i = 0; i < PY1; i++)
                {
                    CIKDir.move(PY123Dir * CIKDir.up);
                }

                PY2 = subAbs(TEMPSUBVEC.y, PY1*10);
              

                for (int i = 0; i < PY1; i++)
                {
                    CIKDir.move(PY123Dir * CIKDir.up*0.1f);
                }


                originSumValueList = cik5.adjustPose();
           //  cik5.R_p5 = originSumValueList[0];
           //
           //  cik5.R_p6 = originSumValueList[1];
           //  cik5.R_p7 = originSumValueList[2];
           //  countOffset(endPoint, aimHit);
           //
               

              
                PZ4 = subAbs(TEMPSUBVEC.z, 0);
                Debug.Log("需要再次运行：" + PZ4);
               //for (int i = 0; i < PZ4; i++)
               //{
               //    CIKDir.move(z_dir * CIKDir.right * 0.1f);
               //}
                Debug.Log("需要再次运行：" + PX3);
                PX3 = subAbs(TEMPSUBVEC.x, 0);


                PZ4 = subAbs(TEMPSUBVEC.z, 0);
                Debug.Log("需要再次运行：" + PZ4);
                //for (int i = 0; i < PZ4; i++)
                //{
                //    CIKDir.move(z_dir * CIKDir.right * 0.1f);
                //}
                Debug.Log("需要再次运行：" + PX3);
                PX3 = subAbs(TEMPSUBVEC.x, 0);
             

                //  for (int i = 0; i < PX3; i++)
                //  {
                //      CIKDir.move(x_dir * CIKDir.forward * 0.1f);
                //  }
                //
                //originSumValueList = cik5.adjustPose();

                insertVec = new Vector3(originSumValueList[0], originSumValueList[1], originSumValueList[2]);

                 countOffset(endPoint, aimHit);

                //
                //    CIK_J_BASE.setThList(th);
                //    CIK_J_BASE.setMatrixList(tA);
                //    CIK_J_BASE.setPosList(tp);
                //    CIK_J_BASE.setRotList(tr);
                //
                //    CIKDir.move(new Vector3());
                //  PZ3 = (int)Mathf.Abs((Mathf.Abs(TEMPSUBVEC.z) - (Mathf.Abs(PZ1 * 100) + Mathf.Abs(PZ2 * 10))));
                //
                //
                //  for (int i = 0; i < PZ3; i++)
                //  {
                //      CIKDir.move(-CIKDir.right * 0.1f);
                //  }

               //
               CIK_J_BASE.setThList(th);
               CIK_J_BASE.setMatrixList(tA);
               CIK_J_BASE.setPosList(tp);
               CIK_J_BASE.setRotList(tr);
               CIKDir.move(new Vector3());
               
                code  = 1;
               
                code =1998;

                //code = 233;
                break;
            case 1998:


                if (stepIndex < (LayerStructrueDataCache.g2boxDataDic[endPoint].layer+1)*25)
                {
                    CIKDir.move( CIKDir.up);
                    stepIndex++;
                }
                else
                {
                    stepIndex = 0;

                    CIK_J3.allowAdjust = true;
                    code=2;
                }

            
                break;

            case 1:

                if (stepIndex < PZ1)
                {
                    CIKDir.move(PZ123Dir * CIKDir.right * 10);
                    stepIndex++;
                } else
                {
                    stepIndex = 0;
                    code++;
                }
        
                break;

            case 2:
                if (stepIndex < PZ2+(PZ1-1)*10)
                {
                    CIKDir.move(PZ123Dir * CIKDir.right );
                    stepIndex++;
                }
                else
                {
                    stepIndex = 0;
                    code++;
                }

                break;

            case 3:
                if (stepIndex < PZ3)
                {
                    CIKDir.move(PZ123Dir * CIKDir.right*0.1f);
                    stepIndex++;
                }
                else
                {
                    stepIndex = 0;
                    code++;
                }

                break;

            case 4:
                if (stepIndex < PX1)
                {
                    CIKDir.move(PX12Dir*CIKDir.forward);
                    stepIndex++;
                }
                else
                {
                    stepIndex = 0;
                    code++;
                }
                break;

            case 5:
                if (stepIndex < PX2)
                {
                    CIKDir.move(PX12Dir * CIKDir.forward*0.1f);
                    stepIndex++;
                }
                else
                {
                    stepIndex = 0;
                    code = 789;
                }
                break;

            case 789:
                countOffsetTiny(endPoint, aimHit);
                code++;
                break;

            case 790:
           

                jump = tinyMoveX_ZDir(4);

                if (jump == true)
                {
                    code = 6;
                }
                break;

            case 6:

                if (stepIndex < 26)
                {
                   // CIKDir.move(CIKDir.down);

                    downMove(1,1);
                    stepIndex++;
                }
                else
                {
                    stepIndex = 0;
                    code = 7;
                }
               
                break;

            case 7:
                countOffsetTiny(endPoint, aimHit);
                code++;
               
                break;
            case 8:
                jump = tinyMoveAllDir();

                if (jump == true)
                {
                    code = 9;
                }
                break;


            case 9:
                countOffsetTiny(endPoint, aimHit);
                code++;

                break;
            case 10:
                jump = tinyMoveAllDir();

                if (jump == true)
                {
                    code = 300;
                }
                break;


            case 3000:
                
               
                break;


      // case 9:
      //     countOffset(endPoint, aimHit);
      //     PZ1 = subAbs(TEMPSUBVEC.z, 0)/10;
      //     PZ2 = subAbs(TEMPSUBVEC.z, PZ2 * 10);
      //
      //
      //     PX1 = subAbs(TEMPSUBVEC.x, 0) / 10;
      //     PX2 = subAbs(TEMPSUBVEC.x, PX1*10);
      //     Debug.Log(PZ1 + "<>" + PZ2 + "<>" + PX1 + "<>" + PX2);
      //
      //     code = 999;
      //     break;
      // case 10:
      //
      //     if (stepIndex < PZ1)
      //     {
      //         CIKDir.move(z_dir * CIKDir.right );
      //         stepIndex++;
      //     }
      //     else
      //     {
      //         stepIndex = 0;
      //         code++;
      //     }
      //     break;
            case 11:

                if (stepIndex < PZ2)
                {
                    CIKDir.move(z_dir * CIKDir.right*0.1f);
                    stepIndex++;
                }
                else
                {
                    stepIndex = 0;
                    code++;
                }
                break;

            case 12:

                if (stepIndex < PX1)
                {
                    CIKDir.move(x_dir * CIKDir.forward);
                    stepIndex++;
                }
                else
                {
                    stepIndex = 0;
                    code++;
                }
                break;

            case 13:

                if (stepIndex < PX2)
                {
                    CIKDir.move(x_dir * CIKDir.forward*0.1f);
                    stepIndex++;
                }
                else
                {
                    stepIndex = 0;
                    code = 300;
                }

                break;

            case 33:
                countOffsetTiny(endPoint, aimHit);
                code++;
                break;
            case 34:
                tinyMove(x, CIKDir.forward, x_dir);
                break;


            case 35:
                tinyMove(z, CIKDir.right, z_dir);
                break;

            case 36:
                tinyMove(y, CIKDir.up, y_dir);

                break;

            case 37:

                break;

















            case 300:

                StandardPoint.saveFromList();
                cik5 = (CIK_J5)CIK_J5.getCIK_J(5);
                // cik5.R_p5 = 0;
                // cik5.R_p6 = 0;
                // cik5.R_p7 = 0;
               
                aimHit.transform.SetParent(null);

              //  aimHit.GetComponent<ShapeItemRotRecover>().allowAdjust = true;
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



                // aimHit.GetComponent<ShapeItemRotRecover>().allowAdjust = true;
                //
                //Rigidbody rig = aimHit.AddComponent<Rigidbody>();
                //rig.mass = 100;
                //rig.angularDrag = 0;
                //rig.drag = 0;
                //aimHit.GetComponent<Collider>().enabled = true;
                //aimHit.GetComponent<Collider>().isTrigger = false;
                //rig.constraints = RigidbodyConstraints.FreezePositionX;
                //master.endStrategy();
                //master.changeStrategy(new RecoverToOriginStatuStrategy(endPoint, aimHit, claw, speed, master, originPoint));
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


            cik5.interOptimize2(insertVec.x,
              insertVec.y,
            insertVec.z, 60);

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
