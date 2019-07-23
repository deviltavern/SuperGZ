using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumSelector : ObviewerTemplates {

    RectTransform Viewport;
    RectTransform Content;
    List<Button> numBtnList = new List<Button>();
    GameObject res_numItem;
    public static NumSelector Instance;


   

    public string opValue;

    public void request(string _opValue)
    {

        this.opValue = _opValue;
        this.gameObject.SetActive(true);

    }
    private void Awake()
    {
        Instance = this;
        res_numItem = Resources.Load<GameObject>("NumItem").gameObject;

        Viewport = this.transform.Find("Viewport").GetComponent<RectTransform>();

        Content = Viewport.transform.Find("Content").GetComponent<RectTransform>();
    }
    private void Start()
    {

        
        for (int i = 0; i < 100; i++)
        {
            GameObject g = GameObject.Instantiate(res_numItem,this.transform);

            g.transform.Find("Text").GetComponent<Text>().text = i + "";
            g.transform.localPosition -= new Vector3(0,40 * i);

            g.transform.SetParent(Content);

            g.GetComponent<Button>().onClick.AddListener(delegate {
                onClickBtn(int.Parse(g.GetComponent<Button>().transform.Find("Text").GetComponent<Text>().text));

            });


        }

        this.gameObject.SetActive(false);

    }


    
    public void onClickBtn(int index)
    {
        ViewInfo info = new ViewInfo();

        info.opArg = this.opValue;

        info.arg1 = index + "";

        broadCast(info);

        this.gameObject.SetActive(false);
    }

    





}
