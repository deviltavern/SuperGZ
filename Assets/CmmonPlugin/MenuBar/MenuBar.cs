using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBar : ObviewerTemplates {

    public Button copyBtn;
    public Button rotBtn;
    public Button moveBtn;
    public Button saveBtn;
    public Button scale_change;

    public Button carryIndex;
    public Button carryLayer;
    public Button deleteBtn;




    public string opValue = "";


    public static MenuBar Instance;


    private void Awake()
    {

        Instance = this;

        scale_change = this.transform.Find("scale_change").GetComponent<Button>();
        copyBtn = this.transform.Find("copyBtn").GetComponent<Button>();
        rotBtn  = this.transform.Find("rotBtn") .GetComponent<Button>();
        moveBtn = this.transform.Find("moveBtn").GetComponent<Button>();
        saveBtn = this.transform.Find("saveBtn").GetComponent<Button>();
        carryIndex = this.transform.Find("carryIndex").GetComponent<Button>();
        carryLayer = this.transform.Find("carryLayer").GetComponent<Button>();
        deleteBtn = this.transform.Find("deleteBtn").GetComponent<Button>();


        copyBtn.onClick.AddListener(onClickCopyBtn);
        rotBtn.onClick.AddListener(onClickRotBtn);
        moveBtn.onClick.AddListener(onClickMoveBtn);
        saveBtn.onClick.AddListener(onClickSaveBtn);
        scale_change.onClick.AddListener(onClickScaleChange);

        carryIndex.onClick.AddListener(onClickCarryIndex);

        carryLayer.onClick.AddListener(onClickCarryLayer);
        deleteBtn.onClick.AddListener(onClickDeleteBtn);
        this.gameObject.SetActive(false);
        

    }

   

    public void request(string _opValue)
    {
        this.opValue = _opValue;
        activateMenuBar();


    }

    public void activateMenuBar()
    {
        this.gameObject.SetActive(true);
        this.gameObject.transform.GetComponent<RectTransform>().localPosition = Input.mousePosition + new Vector3(-400,-380);
    }

    void onClickDeleteBtn()
    {

        ViewInfo info = new ViewInfo();
        info.opArg = opValue;

        info.arg1 = MenuField.delete;
        broadCast(info);
        opValue = "";
        this.gameObject.SetActive(false);

    }

    void onClickCarryIndex()
    {


        NumSelector.Instance.request(MenuField.carry_index);


        this.gameObject.SetActive(false);



    }
    void onClickCarryLayer()
    {
        NumSelector.Instance.request(MenuField.carry_layer);

        this.gameObject.SetActive(false);
    }

    void onClickScaleChange()
    {


        ViewInfo info = new ViewInfo();
        info.opArg = opValue;

        info.arg1 = MenuField.scale_change;
        broadCast(info);

        opValue = "";

        this.gameObject.SetActive(false);


    }
    void onClickCopyBtn()
    {

        ViewInfo info = new ViewInfo();
        info.opArg = opValue;

        info.arg1 = MenuField.copy;
        broadCast(info);

        opValue = "";

        this.gameObject.SetActive(false);
    }

    void onClickRotBtn()
    {

        ViewInfo info = new ViewInfo();
        info.opArg = opValue;

        info.arg1 = MenuField.rot;
        broadCast(info);
        opValue = "";

        this.gameObject.SetActive(false);
    }
    void onClickSaveBtn()
    {
        ViewInfo info = new ViewInfo();
        info.opArg = opValue;

        info.arg1 = MenuField.save;
        broadCast(info);
        opValue = "";
        this.gameObject.SetActive(false);
    }

    void onClickMoveBtn()
    {
        ViewInfo info = new ViewInfo();
        info.opArg = opValue;

        info.arg1 = MenuField.move;
        broadCast(info);

        opValue = "";

        this.gameObject.SetActive(false);
    }


}
