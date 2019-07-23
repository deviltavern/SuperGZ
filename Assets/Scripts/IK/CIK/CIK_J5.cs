using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIK_J5 : CIK_J_BASE {
    public override void initParameter()
    {
        dx = 0;
        dz = 610.5f;
        alf = -90;
        Instance = this;
        ob_up = 1;
        ob_right = 1;
        ob_forward = 1;



    }
    public static CIK_J5 Instance;

    public GameObject SpecialTool;

    public static bool originalRPSetOK = false;

    public float roteAngle;


    public float deltaJZ;


    public GameObject p5;
    public GameObject p6;
    public GameObject p7;

    public static Vector3 originalRPValue;


    public static float media_RP5;
    public static float media_RP6;
    public static float media_RP7;

    public float R_p5;
    public float R_p6;
    public float R_p7;

    public float A_P5;
    public float A_P6;
    public float A_P7;


    public float ob_up;
    public float ob_right;
    public float ob_forward;



    public Vector3 originWorldPos;
    public GameObject originItem;
    public GameObject origin_dir_item_up;
    public GameObject origin_dir_item_right;
    public GameObject origin_dir_item_forward;


    public Vector3 origin_DIr_up;
    public Vector3 origin_DIr_right;
    public Vector3 origin_DIr_forward;


    public float A_originPoint_5;
    public float A_originPoint_6;
    public float A_originPoint_7;
    public float sumOrinPointA;

    public GameObject aimCube;
    public GameObject endCube;

    public GameObject a_up;
    public GameObject a_right;
    public GameObject a_forward;


    public GameObject claw;
    public Vector3 dir_up;
    public Vector3 dir_right;
    public Vector3 dir_forward;


    public Dictionary<float, float> clawAngleDic = new Dictionary<float, float>();
    public List<float> valueList = new List<float>();

    /// <summary>
    /// 计算最接近的坐标基的方向
    /// </summary>
    public void calculateOB()
    {
        List<float> minList = new List<float>();

        ob_up = 1;
        ob_right = 1;
        ob_forward = 1;
        minList.Add(updateAValue());

        ob_up = 1;
        ob_right = -1;
        ob_forward = 1;
        minList.Add(updateAValue());

        ob_up = -1;
        ob_right = -1;
        ob_forward = 1;
        minList.Add(updateAValue());

        ob_up = -1;
        ob_right = 1;
        ob_forward = 1;
        minList.Add(updateAValue());

        float min = minList[0];
        for (int i = 0; i < minList.Count; i++)
        {
            if (min > minList[i])
            {
                min = minList[i];
            }

        }
        int index = 0;
        for (int i = 0; i < minList.Count; i++)
        {
            if (min == minList[i])
            {
                index = i;
            }

        }

        switch (index)
        {
            case 0:

                ob_up = 1;
                ob_right = 1;
                ob_forward = 1;
                break;

            case 1:
                ob_up = 1;
                ob_right = -1;
                ob_forward = 1;
                break;

            case 2:

                ob_up = -1;
                ob_right = 1;
                ob_forward = 1;
                break;

            case 3:
                ob_up = -1;
                ob_right = 1;
                ob_forward = 1;

                break;
        }

    }
    public float getMin(Dictionary<float, float> dic)
    {


        float min = 10000;
        float thValue = 0;

        foreach (float key in dic.Keys)
        {

            if (min > dic[key])
            {
                min = dic[key];
                thValue = key;
            }
        }



        return thValue;
    }


    public void addDic(float input, float output)
    {
        if (clawAngleDic.ContainsKey(input) == true)
        {
            Debug.Log("异常数据：" + input);
            return;
        }
        clawAngleDic.Add(input, output);

    }

    /// <summary>
    /// 根据当前的RP值去获得最优解
    /// </summary>
    public List<float> adjustPoseByPreRPValue()
    {

        float initRP5 = R_p5;
        float initRP6 = R_p6;
        float initRP7 = R_p7;
        List<float> reList = new List<float>();
        updateR_P5ByPreRPValue();
        updateR_P7ByPreRPValue();
        updateR_P6ByPreRPValue();


       
        reList.Add(R_p5);
        reList.Add(R_p6);
        reList.Add(R_p7);

        media_RP5 = R_p5;
        media_RP6 = R_p6;
        media_RP7 = R_p7;
        originalRPValue = new Vector3(media_RP5, media_RP6, media_RP7);
        R_p5 = initRP5   ;
        R_p6 = initRP6   ;
        R_p7 = initRP7;
        return reList;
        

    }

    public void updateR_P7ByPreRPValue()
    {
        clawAngleDic.Clear();


        float preRPValue = R_p7;
        for (int i = 0; i < 180; i++)
        {

            R_p7 = preRPValue + (-90 + i);


            updateAValue();


            addDic(R_p7, sumValue);
            //sDebug.Log("优化结果：" + R_p7 + ":" + sumValue);

        }
        R_p7 = getMin(clawAngleDic);

        updateAValue();

    }

    public void updateR_P6ByPreRPValue()
    {
        clawAngleDic.Clear();


        float preRPValue = R_p6;
        for (int i = 0; i < 180; i++)
        {

            R_p6 = preRPValue + (-90 + i);

            updateAValue();

            addDic(R_p6, sumValue);
            //sDebug.Log("优化结果：" + R_p7 + ":" + sumValue);

        }
        R_p6 = getMin(clawAngleDic);

        updateAValue();

    }

    public void updateR_P5ByPreRPValue()
    {
        clawAngleDic.Clear();


        float preRPValue = R_p5;
        for (int i = 0; i < 180; i++)
        {

            R_p5 = preRPValue + (-90 + i);


            updateAValue();


            addDic(R_p5, sumValue);
            //sDebug.Log("优化结果：" + R_p7 + ":" + sumValue);

        }
        R_p5 = getMin(clawAngleDic);

        updateAValue();

    }
    public void updateR_P7()
    {
        clawAngleDic.Clear();



        for (int i = 0; i < 360; i++)
        {

            R_p7 = -180 + 1f * i;


            updateAValue();


            addDic(R_p7, sumValue);
            //sDebug.Log("优化结果：" + R_p7 + ":" + sumValue);

        }
        R_p7 = getMin(clawAngleDic);

        updateAValue();

    }

    public void updateR_P5()
    {
        clawAngleDic.Clear();



        for (int i = 0; i < 360; i++)
        {

            R_p5 = -180 + 1f * i;


            updateAValue();


            addDic(R_p5, sumValue);



        }
        R_p5 = getMin(clawAngleDic);

        updateAValue();


    }

    public void updateR_P6()
    {

        clawAngleDic.Clear();



        for (int i = 0; i < 360; i++)
        {

            R_p6 = -180 + 1f * i;


            updateAValue();


            addDic(R_p6, sumValue);

        }
        R_p6 = getMin(clawAngleDic);

        updateAValue();
    }

    public List<float> upList_fromOrigin2Aim = new List<float>();
    public List<float> adjustPose()
    {

        calculateOB();
        float initR_p5 = R_p5;
        float initR_p6 = R_p6;
        float initR_p7 = R_p7;

        List<float> reList = new List<float>();

        upList_fromOrigin2Aim = reList;
        while (true)
        {

            Debug.Log("产生一次随机数！");
            R_p5 += Random.Range(-90, 90f);
            R_p6 += Random.Range(-90, 90f);
            R_p7 += Random.Range(-90, 90f);

            updateR_P5();
            updateR_P7();
            updateR_P6();


            sumValue = A_P5 + A_P6 + A_P7;

            if (sumValue < 3)
            {

                R_p5 %= 180;
                R_p6 %= 180;
                R_p7 %= 180;

                Debug.Log(R_p5 + "-" + R_p6 + "-" + R_p7);
                reList.Add(R_p5);
                reList.Add(R_p6);
                reList.Add(R_p7);
                R_p5 = initR_p5;
                R_p6 = initR_p6;
                R_p7 = initR_p7;

                media_RP5 = R_p5 ;
                media_RP6 =R_p6  ;
                media_RP7 = R_p7;
                return reList;
            }

            R_p5 = initR_p5;
            R_p6 = initR_p6;
            R_p7 = initR_p7;
        }


        //  return sumValue;


    }


    public int interOptimize(float p5,float p6,float p7,float speed)
    {

        int statu = 0;
        if (Mathf.Abs(Mathf.Abs(this.R_p5) - Mathf.Abs(p5)) > 0.1f)
        {
            float dir = ((p5 - R_p5)/Mathf.Abs(p5 - R_p5)) * Time.deltaTime * speed;

            this.R_p5 += dir;
        }
        else
        {
            statu += 1;
            this.R_p5 = p5;
        }

        if (Mathf.Abs(Mathf.Abs(this.R_p6) - Mathf.Abs(p6)) > 0.1f)
        {
            float dir = ((p6 - R_p6) / Mathf.Abs(p6- R_p6)) * Time.deltaTime * speed;

            this.R_p6 += dir;
        }
        else
        {
            this.R_p6 = p6;
            statu ++;
        }

        if (Mathf.Abs(Mathf.Abs(this.R_p7) - Mathf.Abs(p7)) > 0.1f)
        {
            float dir = ((p7 - R_p7) / Mathf.Abs(p7 - R_p7)) * Time.deltaTime * speed;

            this.R_p7 += dir;
        }
        else
        {
            this.R_p7 = p7;
            statu ++;
        }
        return statu;
    }



    public int interOptimize2(float p5, float p6, float p7, float speed)
    {


    
            Vector3 vec = new Vector3(p5, p6, p7);
        Vector3 vec2 = new Vector3(R_p5, R_p6,R_p7);
        Vector3 dir = Vector3.Normalize(vec - vec2);


        if (Vector3.Distance(vec, vec2) > 3f)
        {
            Vector3 revec = vec2 + dir * Time.deltaTime * speed;
            R_p5 = revec.x;
            R_p6 = revec.y;
            R_p7 = revec.z;

        }
        else
        {

            Vector3 revec = vec2 + dir * Time.deltaTime * speed*0.1f;
            R_p5 = revec.x;
            R_p6 = revec.y;
            R_p7 = revec.z;
            if (Vector3.Distance(vec, vec2) < 0.1f)
            {
                R_p5 = p5;
                R_p6 = p6;
                R_p7 = p7;

                return 3;
            }
        }




       
        return 0;
       
       
 
       
    }

    public int interOptimize2(Vector3 rot, float speed)
    {



        Vector3 vec = rot;
        Vector3 vec2 = new Vector3(R_p5, R_p6, R_p7);
        Vector3 dir = Vector3.Normalize(vec - vec2);
        Vector3 revec = vec2 + dir * Time.deltaTime * speed;


        R_p5 = revec.x;
        R_p6 = revec.y;
        R_p7 = revec.z;

        if (Vector3.Distance(vec, vec2) < 0.1f)
        {
            R_p5 = vec.x;
            R_p6 = vec.y;
            R_p7 = vec.z;

            return 3;
        }
        return 0;




    }
    public int interOptimize2(float p5, float p6, float p7, float speed, bool allow,out bool allowAnswer)
    {



        if (allow == true)
        {
            Debug.Log("调整状态！！！！！！！！！！！！！！！！！！！！！！！！！！！！");
            Vector3 vec = new Vector3(p5, p6, p7);
            Vector3 vec2 = new Vector3(R_p5, R_p6, R_p7);
            Vector3 dir = Vector3.Normalize(vec - vec2);
            Vector3 revec = vec2 + dir * Time.deltaTime * speed;


            R_p5 = revec.x;
            R_p6 = revec.y;
            R_p7 = revec.z;
            allowAnswer = true;
            if (Vector3.Distance(vec, vec2) < 0.1f)
            {
                R_p5 = p5;
                R_p6 = p6;
                R_p7 = p7;
                allowAnswer = false;
                return 3;
            }

        }

        allowAnswer = true;


        return 0;




    }


    public List<float> adjustOriginPose()
    {
       

        float initR_p5 = R_p5;
        float initR_p6 = R_p6;
        float initR_p7 = R_p7;

        List<float> reList = new List<float>();
        while (true)
        {

            //  R_p5 = Random.Range(-180f, 180f);
            //  R_p6 = Random.Range(-180f, 180f);
            //  R_p7 = Random.Range(-180f, 180f);
            //
            R_p5 += Random.Range(-90, 90f);
            R_p6 += Random.Range(-90, 90f);
            R_p7 += Random.Range(-90, 90f);



            updateR_P5ForOrigin();
            updateR_P7ForOrigin();
            updateR_P6ForOrigin();


            updateOriginAngleValue();

            if (sumOrinPointA < 10&& sumOrinPointA>5)
            {
                R_p5 %= 180;
                R_p6 %= 180;
                R_p7 %= 180;
                reList.Add(R_p5);
                reList.Add(R_p6);
                reList.Add(R_p7);

                 originalRPValue = new Vector3(R_p5, R_p6, R_p7);
                 R_p5 =initR_p5;
                 R_p6 =initR_p6;
                 R_p7 =initR_p7;

              
                Debug.Log("优化结束！="+sumOrinPointA);
                return reList;
            }
            R_p5 = initR_p5;
            R_p6 = initR_p6;
            R_p7 = initR_p7;
        }

        

        //return sumOrinPointA;


    }
    public void updateR_P5ForOrigin()
    {
        clawAngleDic.Clear();



        for (int i = 0; i < 360; i++)
        {

            R_p5 = -180 + 1f * i;


            updateOriginAngleValue();


            addDic(R_p5, sumOrinPointA);
           // Debug.Log("优化结果：" + R_p5 + ":" + sumOrinPointA);

        }
        R_p5 = getMin(clawAngleDic);

        updateOriginAngleValue();
    }

    public void updateR_P6ForOrigin()
    {
        clawAngleDic.Clear();



        for (int i = 0; i < 360; i++)
        {

            R_p6 = -180 + 1f * i;


            updateOriginAngleValue();


            addDic(R_p6, sumOrinPointA);
            //sDebug.Log("优化结果：" + R_p7 + ":" + sumValue);

        }
        R_p6 = getMin(clawAngleDic);

        updateOriginAngleValue();
    }

    public void updateR_P7ForOrigin()
    {
        clawAngleDic.Clear();



        for (int i = 0; i < 360; i++)
        {

            R_p7 = -180 + 1f * i;


            updateOriginAngleValue();


            addDic(R_p7, sumOrinPointA);
            //sDebug.Log("优化结果：" + R_p7 + ":" + sumValue);

        }
        R_p7 = getMin(clawAngleDic);

        updateOriginAngleValue();
    }
    public void updateOriginAngleValue()
    {

        p5.transform.localEulerAngles = new Vector3(R_p5, 0, 0);
        p6.transform.localEulerAngles = new Vector3(0, R_p6, 0);
        p7.transform.localEulerAngles = new Vector3(R_p7, 0, 0);

        origin_DIr_up = Vector3.Normalize(origin_dir_item_up.transform.position - originItem.transform.position);
        origin_DIr_forward = Vector3.Normalize(origin_dir_item_forward.transform.position - originItem.transform.position);
        origin_DIr_right = Vector3.Normalize(origin_dir_item_right.transform.position - originItem.transform.position);

        //
        //  A_originPoint_5 = Vector3.Angle(origin_DIr_up, CIKDir.endPoint.transform.forward);
        //
        //  A_originPoint_6 = Vector3.Angle(-origin_DIr_forward, CIKDir.endPoint.transform.up);
        //
        //  A_originPoint_7 = Vector3.Angle(origin_DIr_right, -CIKDir.endPoint.transform.right);
        //


        A_originPoint_5 = Vector3.Angle(origin_DIr_up, CIKDir.aimHit.transform.forward);

        A_originPoint_6 = Vector3.Angle(-origin_DIr_forward, CIKDir.aimHit.transform.up);

        A_originPoint_7 = Vector3.Angle(origin_DIr_right, -CIKDir.aimHit.transform.right);
        sumOrinPointA = A_originPoint_5 + A_originPoint_6 + A_originPoint_7;
    }
    public float updateAValue()
    {

        a_up = aimCube.transform.Find("up").gameObject;
        a_right = aimCube.transform.Find("right").gameObject;
        a_forward = aimCube.transform.Find("forward").gameObject;

        p5.transform.localEulerAngles = new Vector3(R_p5, 0, 0);
        p6.transform.localEulerAngles = new Vector3(0, R_p6, 0);
        p7.transform.localEulerAngles = new Vector3(R_p7, 0, 0);

        dir_up = Vector3.Normalize(a_up.transform.position - aimCube.transform.position) * ob_right;
        dir_right = Vector3.Normalize(a_right.transform.position - aimCube.transform.position) * ob_right;
        dir_forward = Vector3.Normalize(a_forward.transform.position - aimCube.transform.position) * ob_forward;

        A_P5 = Vector3.Angle(dir_up, endCube.transform.up);
        A_P6 = Vector3.Angle(dir_forward, endCube.transform.right);
        //  A_P7 = Vector3.Angle(-dir_forward, endCube.transform.forward);

        A_P7 = Vector3.Angle(dir_right, endCube.transform.forward);

        sumValue = A_P5 + A_P6 + A_P7;
        return sumValue;
    }
  public  float sumValue;
    public override void updateTh()
    {
        // this.transform.localEulerAngles = initEuler + new Vector3();
        this.ax_n = getCIK_J(4).preZ;
        this.ay_n = vec2Matrix(Vector3.Cross(
            matrix2Vector3(this.ax_n),matrix2Vector3(this.preZ)));


        p5.transform.localEulerAngles = new Vector3(R_p5, 0, 0);
        p6.transform.localEulerAngles = new Vector3(0, R_p6, 0);
        p7.transform.localEulerAngles = new Vector3(R_p7, 0, 0);
      
        if (aimCube != null)
        {
            //  updateAValue();
            a_up = aimCube.transform.Find("up").gameObject;
            a_right = aimCube.transform.Find("right").gameObject;
            a_forward = aimCube.transform.Find("forward").gameObject;

            dir_up = Vector3.Normalize(a_up.transform.position - aimCube.transform.position)*ob_up;
            dir_right = Vector3.Normalize(a_right.transform.position - aimCube.transform.position) * ob_right;
            dir_forward = Vector3.Normalize(a_forward.transform.position - aimCube.transform.position) * ob_forward;

            A_P5 = Vector3.Angle(dir_up, endCube.transform.up);
            A_P6 = Vector3.Angle(dir_forward, endCube.transform.right);
            A_P7 = Vector3.Angle(dir_right, endCube.transform.forward);
            sumValue = A_P5 + A_P6 + A_P7;

            origin_DIr_up = Vector3.Normalize(origin_dir_item_up.transform.position - originItem.transform.position);
            origin_DIr_forward = Vector3.Normalize(origin_dir_item_forward.transform.position - originItem.transform.position);
            origin_DIr_right = Vector3.Normalize(origin_dir_item_right.transform.position - originItem.transform.position);
            originWorldPos = originItem.transform.position;


            // 
            // 
            // 
            // 

            Debug.DrawLine(CIKDir.endPoint.transform.position, CIKDir.endPoint.transform.position + CIKDir.endPoint.transform.up * 2000, Color.gray);
            Debug.DrawLine(CIKDir.endPoint.transform.position, CIKDir.endPoint.transform.position - CIKDir.endPoint.transform.right * 2000, Color.green);
            Debug.DrawLine(CIKDir.endPoint.transform.position, CIKDir.endPoint.transform.position + CIKDir.endPoint.transform.forward * 2000, Color.red);

            Debug.DrawLine(endCube.transform.position, endCube.transform.position + dir_up * 2000, Color.gray);
            Debug.DrawLine(endCube.transform.position, endCube.transform.position - dir_forward * 2000, Color.green);
            Debug.DrawLine(endCube.transform.position, endCube.transform.position + dir_right * 2000, Color.red);



         // Debug.DrawLine(aimCube.transform.position, aimCube.transform.position - claw.transform.up * 2000, Color.gray);
         // Debug.DrawLine(aimCube.transform.position, aimCube.transform.position + claw.transform.right*2000, Color.green);
         // Debug.DrawLine(aimCube.transform.position, aimCube.transform.position - claw.transform.forward*2000, Color.red);


            Debug.DrawLine(claw.transform.position, claw.transform.position + origin_DIr_up * 2000, Color.gray);
            Debug.DrawLine(claw.transform.position, claw.transform.position - origin_DIr_forward * 2000, Color.green);
            Debug.DrawLine(claw.transform.position, claw.transform.position + origin_DIr_right * 2000, Color.red);

            //gray-red,green-gray,red-green
            //
            //  A_originPoint_5 = Vector3.Angle(origin_DIr_up, CIKDir.endPoint.transform.forward);
            //
            //  A_originPoint_6 = Vector3.Angle(-origin_DIr_forward, CIKDir.endPoint.transform.up);
            //
            //  A_originPoint_7 = Vector3.Angle(origin_DIr_right, -CIKDir.endPoint.transform.right);

            //aimHit

            A_originPoint_5 = Vector3.Angle(origin_DIr_up, CIKDir.aimHit.transform.forward);

            A_originPoint_6 = Vector3.Angle(-origin_DIr_forward, CIKDir.aimHit.transform.up);

            A_originPoint_7 = Vector3.Angle(origin_DIr_right, -CIKDir.aimHit.transform.right);
            sumOrinPointA = A_originPoint_5 + A_originPoint_6 + A_originPoint_7;

            // Debug.DrawLine(aimCube.transform.position, aimCube.transform.position + dir_up * 2000, Color.gray);
            // Debug.DrawLine(aimCube.transform.position, aimCube.transform.position - dir_right * 2000, Color.green);
            // Debug.DrawLine(aimCube.transform.position, aimCube.transform.position - dir_forward * 2000, Color.red);
            //

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                this.adjustOriginPose();
            }
        }

    }

    
    public override void updateLocalEuler()
    {
        base.updateLocalEuler();
        this.transform.localEulerAngles = new Vector3(getCIK_J(4).transform.localEulerAngles.x
          , getCIK_J(4).transform.localEulerAngles.y, getCIK_J(4).transform.localEulerAngles.z);


      

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {

            adjustPose();

        }
    }
  //  public override void rot()
  //  {
  //
  //      this.transform.Rotate(Vector3.up, R_up, Space.Self);
  //      this.transform.Rotate(Vector3.forward, R_foward, Space.Self);
  //      this.transform.Rotate(Vector3.right, R_right, Space.Self);
  //  }
	

}
