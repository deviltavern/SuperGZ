using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateJ6_R_UP : Strategy {
    CIK_J6 cik6;

    public float speed;
    public float thresholdValue;
    public UpdateJ6_R_UP(CIK_J6 CIK)
    {
        cik6 = CIK;
        CIK.up6 = this;
        lastAngle = cik6.clawAngle - 0.01f;
        speed = 1;
        thresholdValue = 0.5f;
    }

     float lastAngle;
  
    int index = 0;

    int count = 0;

    List<float> valueList = new List<float>();
    public override void doSomthing()
    {
        Debug.Log("执行优化策略6:");
        if (index % 3 == 0)
        {
            cik6.R_up -= 0.1f * speed;

        }


        if (index % 3 == 1)
        {
            cik6.clawAngle = Vector3.Angle(Vector3.Normalize(cik6.clawR.transform.position + cik6.clawR.transform.forward * 2000), Vector3.Normalize(CIKDir.aimHit.transform.position - CIKDir.aimHit.transform.right * 2000));

            if (lastAngle > cik6.clawAngle)
            {
                Debug.Log("优化成功！");
                lastAngle = cik6.clawAngle;
                speed = 1;
                count = 0;
            }
            else
            {
                Debug.Log("优化失败！");
                // Debug.Log("优化结果：" + lastAngle + ":" + cik6.clawAngle);
                   cik6.R_up += 0.2f * speed;
           //   if (Mathf.Abs((lastAngle - cik6.clawAngle)) < thresholdValue)
           //   {
           //       Debug.Log("6优化失败！:" + (lastAngle - cik6.clawAngle));
           //       cik6.R_up += 0.1f * speed;
           //       speed = 10;
           //       index = 0;
           //
           //
           //    
           //       return;
           //   }
           //
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
                count = 0;
            }
            else
            {
                Debug.Log("结束优化策略！");
                cik6.R_up -= 0.1f * speed;

                if (Mathf.Abs((lastAngle - cik6.clawAngle)) < thresholdValue)
                {
                    Debug.Log("减小值过小，重新计算");

                    speed =10;
                    index = -1;

                    count += 1;
                    return;
                }

                if (count > 10)
                {
                    if (cik6.clawAngle < 0.5f)
                    {
                        cik6.updateClawAngleStrategy = null;
                    }
                    else
                    {

                        if (cik6.up5 != null)
                        {
                            cik6.updateClawAngleStrategy = cik6.up5;
                        }
                        else
                        {

                            cik6.updateClawAngleStrategy = new UpdateJ5_R_RIGHT(cik6, CIK_J_BASE.getCIK_J(5));

                        }
                    }

                }


            }
        }


        index++;
    }

    public override void onEnd()
    {
        
    }

    public override void waitting()
    {
      
    }

  

}
