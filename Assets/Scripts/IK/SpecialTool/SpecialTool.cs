using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialTool : MonoBehaviour {

    public static SpecialTool Instance;
    public GameObject p5;
    public GameObject p6;
    public GameObject p7;

    public GameObject forward;
    public GameObject up;
    public GameObject right;
    public GameObject center;

    public Vector3 dir_up;
    public Vector3 dir_forward;
    public Vector3 dir_right;

    public GameObject aimObj;
    private void Awake()
    {
        Instance = this;
    }

    public void updatePR()
    {
        p5.transform.rotation = CIK_J5.Instance.p5.transform.rotation;
        p6.transform.rotation = CIK_J5.Instance.p6.transform.rotation;
        p7.transform.rotation = CIK_J5.Instance.p7.transform.rotation;
    }


    private void Update()
    {
        dir_up = Vector3.Normalize(up.transform.position - center.transform.position);
        dir_forward = Vector3.Normalize(forward.transform.position - center.transform.position);

        dir_right = Vector3.Normalize(right.transform.position - center.transform.position);

        if (aimObj != null)
        {
            Debug.DrawLine(aimObj.transform.position, aimObj.transform.position + dir_up * 1000, Color.yellow);
            Debug.DrawLine(aimObj.transform.position, aimObj.transform.position + dir_forward * 1000, Color.yellow);
            Debug.DrawLine(aimObj.transform.position, aimObj.transform.position + dir_right * 1000, Color.yellow);
        }
     
    }
}
