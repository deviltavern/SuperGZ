using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleViewer : MonoBehaviour {
    public Scrollbar A0;
    public Scrollbar A1;
    public Scrollbar A2;
    public Scrollbar A3;
    public Scrollbar A4;
    public Scrollbar A5;
    public Scrollbar A6;

    public Text A0Text;
    public Text A1Text;
    public Text A2Text;
    public Text A3Text;
    public Text A4Text;
    public Text A5Text;
    public Text A6Text;

    private void Awake()
    {
        A0 = this.transform.Find("A0").GetComponent<Scrollbar>();
        A1 = this.transform.Find("A1").GetComponent<Scrollbar>();
        A2 = this.transform.Find("A2").GetComponent<Scrollbar>();
        A3 = this.transform.Find("A3").GetComponent<Scrollbar>();
        A4 = this.transform.Find("A4").GetComponent<Scrollbar>();
        A5 = this.transform.Find("A5").GetComponent<Scrollbar>();
        A6 = this.transform.Find("A6").GetComponent<Scrollbar>();

        A0Text   =    this.transform.Find("A0Text").GetComponent<Text>();
        A1Text   =    this.transform.Find("A1Text").GetComponent<Text>();
        A2Text   =    this.transform.Find("A2Text").GetComponent<Text>();
        A3Text   =    this.transform.Find("A3Text").GetComponent<Text>();
        A4Text   =    this.transform.Find("A4Text").GetComponent<Text>();
        A5Text   =    this.transform.Find("A5Text").GetComponent<Text>();
        A6Text =      this.transform.Find("A6Text").GetComponent<Text>();
    }

    private void Update()
    {
        A0.value = 0.5f+ CIK_J_BASE.getCIK_J(0).th/360;
        A1.value = 0.5f + CIK_J_BASE.getCIK_J(1).th/ 360;
        A2.value = 0.5f + CIK_J_BASE.getCIK_J(2).th/ 360;
        A3.value = 0.5f + CIK_J_BASE.getCIK_J(3).th/ 360;
        
        A4.value = 0.5f + CIK_J_BASE.getCIK_J(4).th / 360;
        A5.value = 0.5f + CIK_J_BASE.getCIK_J(5).th / 360;
        A6.value = 0.5f + CIK_J_BASE.getCIK_J(6).th / 360;


         A0Text .text  =  ""+ (int)CIK_J_BASE.getCIK_J(0).th;
         A1Text .text  =  ""+ (int)CIK_J_BASE.getCIK_J(1).th;
         A2Text.text  =  ""+ (int)CIK_J_BASE.getCIK_J(2).th;
         A3Text.text  =  ""+ (int)CIK_J_BASE.getCIK_J(3).th;

         A4.value =0.5f + CIK_J5.Instance.p5.transform.localRotation.x/2;
         A5.value = 0.5f + CIK_J5.Instance.p6.transform.localRotation.y / 2;

         A6.value = 0.5f + CIK_J5.Instance.p7.transform.localRotation.x / 2;

        A4Text.text = "" + (int)(CIK_J5.Instance.p5.transform.localRotation.x * 180);
        A5Text.text = "" + (int)(CIK_J5.Instance.p6.transform.localRotation.y * 180);
        A6Text.text = "" + (int)(CIK_J5.Instance.p7.transform.localRotation.x * 180);


      

    }



}
