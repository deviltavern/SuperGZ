using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateJ5_R_RIGHT : Strategy {

    CIK_J6 cik6;
    CIK_J5 cik5;
    public float speed;
    public float lastAngle;
    public float thresholdValue;
    public UpdateJ5_R_RIGHT(CIK_J6 CIK,CIK_J_BASE _cik5)
    {
        cik6 = CIK;
        cik5 = (CIK_J5)_cik5;

        lastAngle = cik6.clawAngle - 0.01f;
        CIK.up5 = this;
        speed = 1;
        thresholdValue = 0.5f;
    }


    int index = 0;
    public override void doSomthing()
    {

        if (index % 3 == 0)
        {
            cik5.R_right -= 0.1f* speed;
            
        }


        if(index %3 == 1)
        {
            cik6.clawAngle = Vector3.Angle(Vector3.Normalize(cik6.clawR.transform.position + cik6.clawR.transform.forward * 2000), Vector3.Normalize(CIKDir.aimHit.transform.position - CIKDir.aimHit.transform.right * 2000));

            if (lastAngle > cik6.clawAngle)
            {
                Debug.Log("优化成功！");
                lastAngle = cik6.clawAngle;
                speed = 1;
            }
            else
            {
                cik5.R_right += 0.2f * speed;

           

               
            }
        }
        if (index % 3 == 2)
        {
            cik6.clawAngle = Vector3.Angle(Vector3.Normalize(cik6.clawR.transform.position + cik6.clawR.transform.forward * 2000), Vector3.Normalize(CIKDir.aimHit.transform.position - CIKDir.aimHit.transform.right * 2000));

            if (lastAngle > cik6.clawAngle)
            {
                Debug.Log("优化成功！");
                lastAngle = cik6.clawAngle;
                speed = 1;
            }
            else
            {
                Debug.Log("优化失败2！:" + (lastAngle - cik6.clawAngle));
                cik5.R_right -= 0.1f * speed;

                if (Mathf.Abs((lastAngle - cik6.clawAngle)) < thresholdValue)
                {
                    Debug.Log("减小值过小，重新计算");

                    speed += 5;
                    index = -1;
                    return;
                }



                if (cik6.clawAngle < 0.5f)
                {
                    cik6.updateClawAngleStrategy = null;
                }
                else
                {

                    if (cik6.up6 != null)
                    {
                        cik6.updateClawAngleStrategy = cik6.up6;
                    }
                }


            }
        }

        index++;
  
    }

    public override void onEnd()
    {
        throw new System.NotImplementedException();
    }

    public override void waitting()
    {
        throw new System.NotImplementedException();
    }

   
}
