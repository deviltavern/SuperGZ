using CSharpAlgorithm.Algorithm;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 该类表示刚体
/// </summary>
public class CIK_J6 : CIK_J_BASE {

    public GameObject claw;
    public GameObject clawR;


    public GameObject clawP1;
    public GameObject clawP2;
    public GameObject clawP3;
    public GameObject clawP4;
    public List<float> clawValueList = new List<float>();
    public override void initParameter()
    {
        dz = 0;
        dx = 0;
        
        zVec = new Vector3(0, 0, 1);
        allowOptimize = false;
       
    }


    public float clawTh;
    public Strategy updateClawAngleStrategy;


    public Strategy up6;
    public Strategy up5;


    public override void onStart()
    {
        base.onStart();

        p.SetData(new double[] { 110.7576f, 276.5956f, 230.8148f });
        lastClawAngle = 1000;
    }
    public float clawAngle;

    int code;

    public float lastClawAngle;


    public bool allowOptimize;
    public void updateClaw6()
    {
         this.transform.localEulerAngles = new Vector3(getCIK_J(5).transform.localEulerAngles.x, getCIK_J(5).transform.localEulerAngles.y, getCIK_J(5).transform.localEulerAngles.z);

         clawR.transform.localEulerAngles = this.transform.eulerAngles + claw.transform.localEulerAngles;
         clawR.transform.position = claw.transform.position;

    }
    public override void updateLocalEuler()
    {
        base.updateLocalEuler();
        this.transform.localEulerAngles = new Vector3(getCIK_J(5).transform.localEulerAngles.x, getCIK_J(5).transform.localEulerAngles.y, getCIK_J(5).transform.localEulerAngles.z);

    }
    public override void rot()
    {
        base.rot();
        clawR.transform.localEulerAngles = this.transform.eulerAngles + claw.transform.localEulerAngles;

        clawR.transform.position = claw.transform.position;

    }

    public float anglexxxxxxxxxxxxxxxxxxxxx;
 // public List<float> countClawVale()
 // {
 //     float dir1 = CIKDir.aimHit.gameObject.transform.position.z - getCIK_J(0).transform.position.z;
 //
 //
 //     float dir = -dir1 / Mathf.Abs(dir1);
 //
 //
 //     //return Vector3.Angle(Vector3.Normalize(this.clawR.transform.position + this.clawR.transform.forward * 2000), Vector3.Normalize(CIKDir.aimHit.transform.position + CIKDir.aimHit.transform.up * 2000));
 //     //  return Vector3.Angle(Vector3.Normalize(this.clawR.transform.position + this.clawR.transform.forward * 2000), Vector3.Normalize(clawR.transform.position + CIKDir.aimHit.transform.right * 2000));
 //     return Vector3.Angle((Vector3.Normalize(clawP2.transform.position - clawP1.transform.position)), -Vector3.Normalize(CIKDir.aimHit.transform.position + CIKDir.aimHit.transform.up * 2000)); ;
 // }
    public List<float> countClawVale()
    {
        List<float> list = new List<float>();
        Vector3 dir_up = Vector3.Normalize(clawP2.transform.position - clawP1.transform.position);
        Vector3 dir_right = Vector3.Normalize(clawP3.transform.position - clawP1.transform.position);
        Vector3 dir_forward = Vector3.Normalize(clawP4.transform.position - clawP1.transform.position);

        float angle1 = Vector3.Angle(-dir_up, CIKDir.aimHit.transform.up);
        float angle2 = Vector3.Angle(dir_right, CIKDir.aimHit.transform.right);

        float angle3 = Vector3.Angle(dir_forward, CIKDir.aimHit.transform.forward);

        list.Add(angle1);
        list.Add(angle2);
        list.Add(angle3);
        //return Vector3.Angle(Vector3.Normalize(this.clawR.transform.position + this.clawR.transform.forward * 2000), Vector3.Normalize(CIKDir.aimHit.transform.position + CIKDir.aimHit.transform.up * 2000));
        //  return Vector3.Angle(Vector3.Normalize(this.clawR.transform.position + this.clawR.transform.forward * 2000), Vector3.Normalize(clawR.transform.position + CIKDir.aimHit.transform.right * 2000));
        return list;
    }

    public float countClawVale2()
    {
        return Vector3.Angle(Vector3.Normalize(this.clawR.transform.position + this.clawR.transform.right * 2000), Vector3.Normalize(clawR.transform.position +CIKDir.aimHit.transform.right  * 2000));

    }

   public Vector3 aimhit_up;
   public Vector3 aimhit_right;
   public Vector3 aimhit_forward;

    public Vector3 aimhit_pos;
    public override void updateTh()
    {

       


        if (CIKDir.aimHit != null)
        {
          
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                CIKDir.aimHit.transform.SetParent(this.transform.parent);
                aimhit_pos = CIKDir.aimHit.transform.position;
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                CIKDir.aimHit.transform.parent = this.transform;
            }



            // Debug.DrawLine(clawR.transform.position, clawR.transform.position + clawR.transform.up * 2000, Color.gray);
            // Debug.DrawLine(clawR.transform.position, clawR.transform.position + clawR.transform.right * 2000, Color.yellow);
            // Debug.DrawLine(clawR.transform.position, clawR.transform.position + clawR.transform.forward * 2000, Color.red);
            //


            //

            if (CIKDir.endPoint != null)
            {
                aimhit_up = CIKDir.endPoint.transform.up;
                aimhit_right = CIKDir.endPoint.transform.right;
                aimhit_forward = CIKDir.endPoint.transform.forward;
            }
           


           

            Vector3 dir_up = Vector3.Normalize(clawP2.transform.position - clawP1.transform.position);
            Vector3 dir_right = Vector3.Normalize(clawP3.transform.position - clawP1.transform.position);
            Vector3 dir_forward = Vector3.Normalize(clawP4.transform.position - clawP1.transform.position);

            float angle1 = Vector3.Angle(-dir_up, CIKDir.aimHit.transform.up);
            float angle2 = Vector3.Angle(dir_right, CIKDir.aimHit.transform.right);

            float angle3 = Vector3.Angle(dir_forward, CIKDir.aimHit.transform.forward);


            anglexxxxxxxxxxxxxxxxxxxxx = Vector3.Angle(CIKDir.endPoint.transform.up, CIKDir.aimHit.transform.up);
      //
      //    Debug.DrawLine(clawP1.transform.position, clawP1.transform.position + dir_up * 2000, Color.cyan);
      //    Debug.DrawLine(clawP1.transform.position, clawP1.transform.position + dir_right * 2000, Color.cyan);
      //    Debug.DrawLine(clawP1.transform.position, clawP1.transform.position + dir_forward * 2000, Color.cyan);
      //
      //先更新J6的R_up;


            if (allowOptimize == true)
            {
                if (updateClawAngleStrategy != null)
                {
                    updateClawAngleStrategy.doSomthing();


                }
                else
                {

                    if (clawAngle > 0.5f)
                    {
                        if (up6 != null)
                        {
                            updateClawAngleStrategy = up6;
                        }
                        else
                        {

                            updateClawAngleStrategy = new UpdateJ6_R_UP(this);

                            Debug.Log("生成优化策略！");
                        }

                    }
                }

            }
            else
            {

            }


            rot();

            this.clawAngle = Vector3.Angle(Vector3.Normalize(this.clawR.transform.position + this.clawR.transform.forward * 2000), Vector3.Normalize(CIKDir.aimHit.transform.position - CIKDir.aimHit.transform.right * 2000));
            clawTh = Vector3.Angle(Vector3.Normalize(this.transform.position + this.transform.right), Vector3.Normalize(CIKDir.aimHit.transform.position + CIKDir.aimHit.transform.up));
           // claw.transform.localEulerAngles = new Vector3(0, 0, -clawTh);
          
          
          
          


        }
    }

   
}
