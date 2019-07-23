using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAimPointStrategy : Strategy {

    public MoveToAimPointStrategy() { }
    public GameObject aimHit;
    public GameObject claw;
    public GameObject endPoint;
    public int code;
    public float speed;
    public StrategyMaster master;

    public GameObject originPoint;

    
    public MoveToAimPointStrategy(GameObject endPoint, GameObject aimHit, GameObject claw, float speed, StrategyMaster master, GameObject originPoint)
    {

        this.aimHit = aimHit;
        this.claw = claw;
        this.speed = speed;

        this.master = master;
        this.endPoint = endPoint;
        this.originPoint = originPoint;
        code = 0;
    }

    public Vector3 subVec;
    public float x;
    public float dValue;
    public float y;
    public float z;
    public float x_dir;
    public float y_dir;
    public float z_dir;


    public void countOffset()
    {
        countOffset(aimHit);



    }
    public void countOffset(GameObject toObj)
    {
        subVec = new Vector3(toObj.transform.position.x, toObj.transform.position.y + 250, toObj.transform.position.z) - claw.transform.position;
        subVec /= speed;

        x = (int)subVec.x;
        y = (int)subVec.y;
        z = (int)subVec.z;
        x_dir = 1;
        y_dir = 1;
        z_dir = 1;

        if (x != 0)
        {
            x_dir = x / Mathf.Abs(x);
        }
        if (y != 0)
        {
            y_dir = y / Mathf.Abs(y);
        }
        if (z != 0)
        {
            z_dir = z / Mathf.Abs(z);

        }


        x = Mathf.Abs(x);
        y = Mathf.Abs(y);
        z = Mathf.Abs(z);


    }
    public Vector3 TEMPSUBVEC;

    public void countOffset(GameObject toObj, GameObject fromObj)
    {

        subVec = toObj.transform.position - fromObj.transform.position;
        TEMPSUBVEC = subVec;

        subVec /= speed;

        x = (int)subVec.x;
        y = (int)subVec.y;
        z = (int)subVec.z;
        x_dir = 1;
        y_dir = 1;
        z_dir = 1;

        if (x != 0)
        {
            x_dir = x / Mathf.Abs(x);
        }
        if (y != 0)
        {
            y_dir = y / Mathf.Abs(y);
        }
        if (z != 0)
        {
            z_dir = z / Mathf.Abs(z);

        }


        x = Mathf.Abs(x);
        y = Mathf.Abs(y);
        z = Mathf.Abs(z);

      

    }

    public void countOffset(Vector3 toVector3, GameObject fromObj)
    {

        subVec = toVector3 - fromObj.transform.position;


        subVec /= speed;

        x = (int)subVec.x;
        y = (int)subVec.y;
        z = (int)subVec.z;
        x_dir = 1;
        y_dir = 1;
        z_dir = 1;

        if (x != 0)
        {
            x_dir = x / Mathf.Abs(x);
        }
        if (y != 0)
        {
            y_dir = y / Mathf.Abs(y);
        }
        if (z != 0)
        {
            z_dir = z / Mathf.Abs(z);

        }


        x = Mathf.Abs(x);
        y = Mathf.Abs(y);
        z = Mathf.Abs(z);

        Debug.Log(x + "<>" + y + "<>"+z);

    }
    public void countOffset(Vector3 toVector3, Vector3 fromVec)
    {

        subVec = toVector3 - fromVec;


        subVec /= speed;

        x = (int)subVec.x;
        y = (int)subVec.y;
        z = (int)subVec.z;
        x_dir = 1;
        y_dir = 1;
        z_dir = 1;

        if (x != 0)
        {
            x_dir = x / Mathf.Abs(x);
        }
        if (y != 0)
        {
            y_dir = y / Mathf.Abs(y);
        }
        if (z != 0)
        {
            z_dir = z / Mathf.Abs(z);

        }


        x = Mathf.Abs(x);
        y = Mathf.Abs(y);
        z = Mathf.Abs(z);



    }
    public void countOffsetTiny(GameObject toObj, GameObject fromObj)
    {

        subVec = toObj.transform.position - fromObj.transform.position;

        x_time = 0;
        y_time = 0;
        z_time = 0;




        x = (int)subVec.x;
        y = (int)subVec.y;
        z = (int)subVec.z;
        x_dir = 1;
        y_dir = 1;
        z_dir = 1;

        if (x != 0)
        {
            x_dir = x / Mathf.Abs(x);
        }
        if (y != 0)
        {
            y_dir = y / Mathf.Abs(y);
        }
        if (z != 0)
        {
            z_dir = z / Mathf.Abs(z);

        }


        x = Mathf.Abs(x);
        y = Mathf.Abs(y);
        z = Mathf.Abs(z);


    }
    public List<float> countOffsetTinyWithoutChange(GameObject toObj, GameObject fromObj)
    {
        List<float> flList = new List<float>();
        float preX = x;
        float preY = y;
        float preZ = z;


        flList.Add(x);
        flList.Add(y);
        flList.Add(z);

        return flList;
    }
    public void countOffsetTiny(GameObject toObj,Vector3 toOffset, GameObject fromObj)
    {

        subVec = toObj.transform.position+ toOffset - fromObj.transform.position;

        x_time = 0;
        y_time = 0;
        z_time = 0;




        x = (int)subVec.x;
        y = (int)subVec.y;
        z = (int)subVec.z;
        x_dir = 1;
        y_dir = 1;
        z_dir = 1;

        if (x != 0)
        {
            x_dir = x / Mathf.Abs(x);
        }
        if (y != 0)
        {
            y_dir = y / Mathf.Abs(y);
        }
        if (z != 0)
        {
            z_dir = z / Mathf.Abs(z);

        }


        x = Mathf.Abs(x);
        y = Mathf.Abs(y);
        z = Mathf.Abs(z);


    }
    public void countOffsetTiny(Vector3 toVec, GameObject fromObj)
    {

        subVec = toVec - fromObj.transform.position;

        x_time = 0;
        y_time = 0;
        z_time = 0;




        x = (int)subVec.x;
        y = (int)subVec.y;
        z = (int)subVec.z;
        x_dir = 1;
        y_dir = 1;
        z_dir = 1;

        if (x != 0)
        {
            x_dir = x / Mathf.Abs(x);
        }
        if (y != 0)
        {
            y_dir = y / Mathf.Abs(y);
        }
        if (z != 0)
        {
            z_dir = z / Mathf.Abs(z);

        }


        x = Mathf.Abs(x);
        y = Mathf.Abs(y);
        z = Mathf.Abs(z);


    }

    int x_time;
    int y_time;
    int z_time;

    int x_over_code;
    int y_over_code;
    int z_over_code;

    public bool tinyMoveAllDir()
    {
        float tiny_speed = 0.1f;

        int multiple = 1;
        x_over_code = 0;
        y_over_code = 0;
        z_over_code = 0;



        for (int i = 0; i < 3; i++)
        {

            switch (i)
            {
                case 0:
                    if (x_time < x)
                    {
                        CIKDir.move(x_dir * CIKDir.forward * tiny_speed* multiple);
                        x_time +=multiple;

                        x_over_code = 0;
                    }
                    else
                    {
                        Debug.Log("运行结束！");
                        x_over_code = 1;
                    }


                    break;

                case 1:
                    if (y_time < y)
                    {
                        CIKDir.move(y_dir * CIKDir.up * tiny_speed * multiple);
                        y_time += multiple;
                        y_over_code = 0;
                    }
                    else
                    {

                        y_over_code = 1;
                    }
                    break;

                case 2:
                    if (z_time <= z)
                    {

                        CIKDir.move(z_dir * CIKDir.right * tiny_speed * multiple);
                        z_time += multiple;
                        z_over_code = 0;
                    }
                    else
                    { 
                        z_over_code = 1;
                    }
                    break;

                default:

                    break;
            }


            if (x_over_code == 1 && y_over_code == 1 && z_over_code == 1)
            {

                return true;

            }

          


        }



        return false;


    }

    public void downMove(float dir,float speed)
    {
        CIKDir.move(dir * CIKDir.down *speed);
      countOffsetTiny(endPoint, aimHit);
      //  Debug.Log("偏移x = " + fl[0] + "<>" + fl[1] + "<>" + fl[2]);
      for (int i = 0; i < x; i++)
      {
          CIKDir.move(x_dir * CIKDir.forward * speed*0.1f);
      }
      for (int i = 0; i < z; i++)
      {
          CIKDir.move(z_dir * CIKDir.right * speed * 0.1f);
      }



    }
    public bool tinyMoveX_ZDir()
    {
        float tiny_speed = 0.1f;

        int multiple = 1;
        x_over_code = 0;
       
        z_over_code = 0;



        for (int i = 0; i < 2; i++)
        {

            switch (i)
            {
                case 0:
                    if (x_time < x)
                    {
                        CIKDir.move(x_dir * CIKDir.forward * tiny_speed * multiple);
                        x_time += multiple;

                        x_over_code = 0;
                    }
                    else
                    {
                        Debug.Log("运行结束！");
                        x_over_code = 1;
                    }


                    break;

                case 1:
                    if (z_time <= z)
                    {

                        CIKDir.move(z_dir * CIKDir.right * tiny_speed * multiple);
                        z_time += multiple;
                        z_over_code = 0;
                    }
                    else
                    {
                        z_over_code = 1;
                    }
                    break;

                default:

                    break;
            }


            if (x_over_code == 1  && z_over_code == 1)
            {

                return true;

            }




        }



        return false;


    }
    public bool tinyMoveX_ZDir(float speed)
    {
        float tiny_speed = 0.1f;

        int multiple = 1;
        x_over_code = 0;

        z_over_code = 0;



        for (int i = 0; i < 2; i++)
        {

            switch (i)
            {
                case 0:
                    if (x_time < x/speed)
                    {
                        CIKDir.move(x_dir * CIKDir.forward * tiny_speed * multiple*speed);
                        x_time += multiple;

                        x_over_code = 0;
                    }
                    else
                    {
                        Debug.Log("运行结束！");
                        x_over_code = 1;
                    }


                    break;

                case 1:
                    if (z_time <= z / speed)
                    {

                        CIKDir.move(z_dir * CIKDir.right * tiny_speed * multiple*speed);
                        z_time += multiple;
                        z_over_code = 0;
                    }
                    else
                    {
                        z_over_code = 1;
                    }
                    break;

                default:

                    break;
            }


            if (x_over_code == 1 && z_over_code == 1)
            {

                return true;

            }




        }



        return false;


    }

    public bool tinyMoveAllDir(int mulValue)
    {
        float tiny_speed = 0.1f;

        int multiple = mulValue;
        x_over_code = 0;
        y_over_code = 0;
        z_over_code = 0;



        for (int i = 0; i < 3; i++)
        {

            switch (i)
            {
                case 0:
                    if (x_time < x)
                    {
                        CIKDir.move(x_dir * CIKDir.forward * tiny_speed * multiple);
                        x_time += multiple;

                        x_over_code = 0;
                    }
                    else
                    {
                        Debug.Log("运行结束！");
                        x_over_code = 1;
                    }


                    break;

                case 1:
                    if (y_time < y)
                    {
                        CIKDir.move(y_dir * CIKDir.up * tiny_speed * multiple);
                        y_time += multiple;
                        y_over_code = 0;
                    }
                    else
                    {

                        y_over_code = 1;
                    }
                    break;

                case 2:
                    if (z_time <= z)
                    {

                        CIKDir.move(z_dir * CIKDir.right * tiny_speed * multiple);
                        z_time += multiple;
                        z_over_code = 0;
                    }
                    else
                    {
                        z_over_code = 1;
                    }
                    break;

                default:

                    break;
            }


            if (x_over_code == 1 && y_over_code == 1 && z_over_code == 1)
            {

                return true;

            }




        }



        return false;


    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mulValue"></param>
    /// <param name="jumpCode">0->忽略forward，1->忽略up,2->忽略right</param>
    /// <returns></returns>
    public bool tinyMoveAllDir(int mulValue,int jumpCode)
    {
        float tiny_speed = 0.1f;

        int multiple = mulValue;
        x_over_code = 0;
        y_over_code = 0;
        z_over_code = 0;



        for (int i = 0; i < 3; i++)
        {
            if (jumpCode == i)
            {
                continue;
            }

            switch (i)
            {
                case 0:
                    if (x_time < x)
                    {
                        CIKDir.move(x_dir * CIKDir.forward * tiny_speed * multiple);
                        x_time += multiple;

                        x_over_code = 0;
                    }
                    else
                    {
                        Debug.Log("运行结束！");
                        x_over_code = 1;
                    }


                    break;

                case 1:
                    if (y_time < y)
                    {
                        CIKDir.move(y_dir * CIKDir.up * tiny_speed * multiple);
                        y_time += multiple;
                        y_over_code = 0;
                    }
                    else
                    {

                        y_over_code = 1;
                    }
                    break;

                case 2:
                    if (z_time <= z)
                    {

                        CIKDir.move(z_dir * CIKDir.right * tiny_speed * multiple);
                        z_time += multiple;
                        z_over_code = 0;
                    }
                    else
                    {
                        z_over_code = 1;
                    }
                    break;

                default:

                    break;
            }


            if (x_over_code == 1 && z_over_code == 1)
            {

                return true;

            }




        }



        return false;


    }
    public void tinyMove(float times,Vector3 dir,float pn_dir)
    {
        if (dValue <= times)
        {
            CIKDir.move(dir * pn_dir*0.1f);
            dValue += 1;
        }
        else
        {
            dValue = 0;

            code++;

        }
    }
    public void onMove(float times, Vector3 dir, float pn_dir)
    {
        if (dValue <= times)
        {
            CIKDir.move(dir * pn_dir);
            dValue += 1;
        }
        else
        {
            dValue = 0;

            code++;

        }

    }

    public void onMove(float times, Vector3 dir, float pn_dir,int _code)
    {
        if (dValue <= times)
        {
            CIKDir.move(dir * pn_dir);
            dValue += 1;
        }
        else
        {
            dValue = 0;

            code = _code;

        }

    }
    CIK_J5 cik5;

    public List<float> originSumValueList;
    public override void doSomthing()
    {

        
        switch (code)
        {
            case 0:
                cik5 = (CIK_J5)CIK_J5.getCIK_J(5);
                countOffset();
                code += 1;
                y -= 15;
                break;


            case 1:
                //走
                onMove(z, CIKDir.right, z_dir);




                break;

         

            case 2:
                if (dValue < x)
                {
                    CIKDir.move(CIKDir.forward * x_dir);
                    dValue += 1;
                }
                else
                {
                    dValue = 0;

                    code = 3;

                }
                break;


            case 3:
                if (dValue < y)
                {
                    CIKDir.move(CIKDir.up * y_dir);
                    dValue += 1;
                }
                else
                {
                    dValue = 0;

                    code = 4;

                }
                break;


            case 4://抓取

                cik5.aimCube = aimHit;
                cik5.endCube = aimHit;
                if (CIK_J5.originalRPSetOK == false)
                {


                    originSumValueList = cik5.adjustOriginPose();


                    code++;

                    countOffset(aimHit, cik5.originItem);
                    CIK_J5.originalRPValue = new Vector3(originSumValueList[0], originSumValueList[1], originSumValueList[2]);
                    CIK_J5.originalRPSetOK = true;

                    Debug.Log("x=" + x + ":" + "y=" + y + ":" + "z=" + z + ":" + "endpoint:" + endPoint.transform.position + ":");


                    StandardPoint point = new StandardPoint(CIK_J5.Instance.claw.transform.position, new Vector3(originSumValueList[0],
                        originSumValueList[1],
                        originSumValueList[2]

                        )
                       
                        
                        );
                    StandardPoint.list.Add(point);
                }
                else {
                    code++;
                }
                

                break;

                

            case 5:

                
                      int statu = cik5.interOptimize(CIK_J5.originalRPValue.x,
                 CIK_J5.originalRPValue.y,
                 CIK_J5.originalRPValue.z,
                
                 30
                 );
                      if (statu == 3)
                      {
                          code++;
                      }
                
                
                //code++;
             // onMove(z, CIKDir.right, z_dir);
             // // master.changeStrategy(new FromAimPointToEndPointStrategy(endPoint, aimHit, claw, speed, master,originPoint));
             // code++;

                break;

            case 6:
                onMove(8, CIKDir.down, 1);

                break;

            case 7:
                countOffset(aimHit, cik5.originItem);


                code++;
                break;


            case 8:

                onMove(z, CIKDir.right, z_dir);


                break;


            case 9:

                aimHit.transform.SetParent(cik5.p7.transform);

                
                code++;
               
                break;

            case 10:

                cik5.endCube = endPoint;


                aimHit.GetComponent<ShapeItemRotRecover>().aimBox = endPoint;
                //master.changeStrategy(new FromAimPointToEndPointStrategy(endPoint, aimHit, claw, speed, master, originPoint));
                master.changeStrategy(new FromAimPointToEndpointStrategy_2(endPoint, aimHit, claw, speed, master, originPoint));

                break;


            default:


                break;
        }

        if (CIK_J5.originalRPSetOK == true)
        {

            cik5.interOptimize2(CIK_J5.originalRPValue.x,
             CIK_J5.originalRPValue.y,
           CIK_J5.originalRPValue.z, 40);
        }



    }

    public override void onEnd()
    {
        
    }

    public override void waitting()
    {
        
    }

    
}
