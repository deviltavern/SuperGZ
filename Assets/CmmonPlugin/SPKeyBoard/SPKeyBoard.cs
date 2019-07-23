
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPKeyBoard : ObviewerTemplates{


    public Button upBtn;
    public Button downBtn;
    public Button leftBtn;
    public Button rightBtn;
    public Button fowardBtn;
    public Button backBtn;

    public Button overBtn;
    public static SPKeyBoard Instance;

    public string opValue;
    private void Awake()
    {


        Instance = this;
        upBtn = this.transform.Find("up").GetComponent<Button>();

        upBtn.onClick.AddListener(onClickUpBtn);
        downBtn = this.transform.Find("down").GetComponent<Button>();
        downBtn.onClick.AddListener(onClickDownBtn);

        leftBtn = this.transform.Find("left").GetComponent<Button>();
        leftBtn.onClick.AddListener(onClickleftBtn);

        rightBtn = this.transform.Find("right").GetComponent<Button>();
        rightBtn.onClick.AddListener(onClickrightBtn);
        fowardBtn = this.transform.Find("foward").GetComponent<Button>();

        fowardBtn.onClick.AddListener(onClickfowardBtn);
        backBtn = this.transform.Find("back").GetComponent<Button>();
      

        backBtn.onClick.AddListener(onClickbackBtn);

        overBtn = this.transform.Find("overBtn").GetComponent<Button>();
        overBtn.onClick.AddListener(onClickOverBtn);
        hide();
    }


    
    public IObviewer request(string _opValue)
    {

        if (_opValue == SPKeyField.close)
        {
            this.gameObject.SetActive(false);
            this.opValue = "";
        }
        else{

            this.gameObject.SetActive(true);
            this.opValue = _opValue;

        }

        return this;
       


    }

    public void hide()
    {
        this.gameObject.SetActive(false);
        this.opValue = "";
    }
    public void onClickOverBtn()
    {
        ViewInfo info = new ViewInfo();
        info.opArg = this.opValue;

        info.arg1 = SPKeyField.over;

        
        broadCast(info);

        this.gameObject.SetActive(false);
    }

    public void onClickUpBtn()
    {
        ViewInfo info = new ViewInfo();
        info.opArg = this.opValue;

        info.arg1 = SPKeyField.up;

        broadCast(info);
        
    }


    public void onClickDownBtn() {
        ViewInfo info = new ViewInfo();
        info.opArg = this.opValue;

        info.arg1 = SPKeyField.down;

        broadCast(info);


    }

    public void onClickleftBtn()
    {

        ViewInfo info = new ViewInfo();
        info.opArg = this.opValue;

        info.arg1 = SPKeyField.left;

        broadCast(info);

    }


    public void onClickrightBtn()
    {
        ViewInfo info = new ViewInfo();
        info.opArg = this.opValue;

        info.arg1 = SPKeyField.right;

        broadCast(info);


    }


    public void onClickfowardBtn()
    {

        ViewInfo info = new ViewInfo();
        info.opArg = this.opValue;

        info.arg1 = SPKeyField.forward;

        broadCast(info);

    }


    public void onClickbackBtn()
    {

        ViewInfo info = new ViewInfo();
        info.opArg = this.opValue;

        info.arg1 = SPKeyField.back;

        broadCast(info);

    }


}
