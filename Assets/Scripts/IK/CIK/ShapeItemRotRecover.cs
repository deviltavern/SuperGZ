using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeItemRotRecover : MonoBehaviour {

	// Use this for initialization
	void Start () {
        allowAdjust = false;

    }


    public GameObject aimBox;
   public bool allowAdjust = false;
	// Update is called once per frame
	void Update () {

        if (allowAdjust == true)
        {
            if (aimBox != null)
                if (Vector3.Distance(aimBox.transform.localEulerAngles, this.transform.localEulerAngles) < 0.03f)
                {

                    Vector3 dir = Vector3.Normalize(aimBox.transform.localEulerAngles - this.transform.localEulerAngles);

                    this.transform.localEulerAngles += dir * Time.deltaTime*0.01f;
                }
                else
                {

                    this.transform.localEulerAngles = aimBox.transform.localEulerAngles;

                }


        }
        //float dis =Vector3 .Distance(new Vector3())



    }
}
