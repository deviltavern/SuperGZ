using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIK_J4 : CIK_J_BASE {
    public override void initParameter()
    {
        // dz = 650;
        dz = 0;
        alf = 0;
       // dx =145;
        // dz = 1730;

        
        zVec = new Vector3(0, 0, 1);

      
    }


    public Dictionary<float, float> clawAngleDic = new Dictionary<float, float>();

    public bool allowAdjust;

    public void onUpdate()
    {
        this.transform.localEulerAngles = new Vector3(0, getCIK_J(3).transform.localEulerAngles.y, getCIK_J(3).transform.localEulerAngles.z);
        getCIK_J(5).updateLocalEuler();
        getCIK_J(5).rot();
        getCIK_J(6).updateLocalEuler();
       
        getCIK_J(6).rot();


    }
    float cik5R_right;
    float cik6R_up;
    float init_cik5R_right;
    float init_cik6R_up;


    public float getMin(Dictionary<float, float> dic) {


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

  //  public void adjustPose2()
  //  {
  //
  //
  //      CIK_J5 cik5 = (CIK_J5)getCIK_J(5);
  //      CIK_J6 cik6 = (CIK_J6)getCIK_J(6);
  //
  //      cik5R_right = cik5.R_right;
  //      cik6R_up = cik6.R_up;
  //      clawAngleDic.Clear();
  //
  //
  //
  //      init_cik5R_right = cik5.R_right;
  //      init_cik6R_up = cik6.R_up;
  //      for (int i = 0; i < 100; i++)
  //      {
  //          cik6.R_up = cik6R_up;
  //          cik6.R_up += -50 + 1f * i;
  //          onUpdate();
  //          clawAngleDic.Add(cik6.R_up, cik6.countClawVale()[0]);
  //
  //      }
  //      float R_upValue = getMin(clawAngleDic);
  //      cik6R_up = R_upValue;
  //      cik6.R_up = init_cik6R_up;
  //
  //      onUpdate();
  //
  //      clawAngleDic.Clear();
  //      for (int i = 0; i < 100; i++)
  //      {
  //          cik5.R_right = cik5R_right;
  //          cik5.R_right += -50 + 1f * i;
  //          onUpdate();
  //          clawAngleDic.Add(cik5.R_right, cik6.countClawVale());
  //
  //      }
  //      float R_rightValue = getMin(clawAngleDic);
  //      cik5.R_right = init_cik5R_right;
  //      cik5R_right = R_rightValue;
  //      onUpdate();
  //      Debug.Log("调整姿态！");
  //
  //  }
    public void adjustPose()
    {
       

        CIK_J5 cik5 = (CIK_J5)getCIK_J(5);
        CIK_J6 cik6 = (CIK_J6)getCIK_J(6);

        cik5R_right = cik5.R_right;
        cik6R_up = cik6.R_up;
        clawAngleDic.Clear();



        init_cik5R_right = cik5.R_right;
        init_cik6R_up = cik6.R_up;
        for (int i = 0; i < 100; i++)
        {
            cik6.R_up = cik6R_up;
            cik6.R_up += -50 + 1f * i;
            onUpdate();
            clawAngleDic.Add(cik6.R_up, cik6.countClawVale()[0]);

        }
        float R_upValue = getMin(clawAngleDic);
        cik6R_up = R_upValue;
        cik6.R_up = R_upValue;

        onUpdate();

        clawAngleDic.Clear();
        for (int i = 0; i < 100; i++)
        {
            cik5.R_right = cik5R_right;
            cik5.R_right += -50 + 1f * i;
            onUpdate();
            clawAngleDic.Add(cik5.R_right, cik6.countClawVale()[1]);

        }
        float R_rightValue = getMin(clawAngleDic);
        cik5.R_right = R_rightValue;
        cik5R_right = R_rightValue;
        onUpdate();
        Debug.Log("调整姿态！");

    }
    int code = 0;


    public bool status;
    public override void updateTh()
    {
        onUpdate();

        if (Input.GetKeyDown(KeyCode.H))
        {

            adjustPose();

        }
        if (allowAdjust == false)
            return;

        if (getCIK_J(5).R_right != cik5R_right)
        {

            float dir = (cik5R_right - getCIK_J(5).R_right) / Mathf.Abs(cik5R_right - getCIK_J(5).R_right);


            float distance5 = Mathf.Abs(cik5R_right - getCIK_J(5).R_right);
            if (distance5 < 0.11f)
            {
               
                getCIK_J(5).R_right = cik5R_right;


            }
            else
            {
                getCIK_J(5).R_right += dir * Time.deltaTime * 30;
                Debug.Log(Mathf.Abs(getCIK_J(5).R_right));
            }

        }



        if (getCIK_J(6).R_up != cik6R_up)
        {

            float dir = (cik6R_up - getCIK_J(6).R_up) / Mathf.Abs(cik6R_up - getCIK_J(6).R_up);

            float distance6 = (cik6R_up - getCIK_J(6).R_up);
           
            if (Mathf.Abs(distance6) < 0.11f)
            {
                getCIK_J(6).R_up = cik6R_up;


            }
            else
            {
                getCIK_J(6).R_up += dir * Time.deltaTime * 30;

                Debug.Log(Mathf.Abs(getCIK_J(6).R_up)+"=六");
            }



        }

    }
       
    



}
