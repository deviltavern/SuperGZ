using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShapeXMainFuncBar : MonoBehaviour,IViewer,StrategyMaster {

    public Button exportSingleLayer;
    public Button exportLayer;
    public Button importLayer;
    public Button insCarrayBox;
    public Button hideAllLayerBtn;
    public Button beginSimulink;

    public Button beginSimulinkSuper;
    public bool request = false;

    public Strategy selectStrategy;


    public Dropdown layerDataSelect;
    private void Awake()
    {
        exportSingleLayer = this.transform.Find("exportSingleLayer").GetComponent<Button>();
        exportLayer = this.transform.Find("exportLayer").GetComponent<Button>();

        importLayer = this.transform.Find("importLayer").GetComponent<Button>();
        importLayer.GetComponent<Button>().onClick.AddListener(func_importLayer);
        exportSingleLayer.onClick.AddListener(func_exportSingleLayer);

        insCarrayBox = this.transform.Find("insCarrayBox").GetComponent<Button>();

        insCarrayBox.onClick.AddListener(func_selectInsBoxAim);
        beginSimulink = this.transform.Find("beginSimulink").GetComponent<Button>();
        hideAllLayerBtn = this.transform.Find("hideAllLayer").GetComponent<Button>();
        beginSimulinkSuper = this.transform.Find("beginSimulinkSuper").GetComponent<Button>();



        hideAllLayerBtn.onClick.AddListener(hideAllLayer);
        beginSimulink.onClick.AddListener(func_beginSimulink);
        beginSimulinkSuper.onClick.AddListener(onClickBeginSimulinkSuper);

        layerDataSelect = this.transform.Find("layerDataSelect").GetComponent<Dropdown>();
        List<string> strList = new List<string>();
        strList.Add("默认选项");
        strList.Add("第0层");
        strList.Add("第1层");
        strList.Add("第2层");
        strList.Add("第3层");
        layerDataSelect.AddOptions(strList);
        layerDataSelect.onValueChanged.AddListener(onCliclLayerDataSelect);

    }
    public void onClickBeginSimulinkSuper()
    {
        Debug.Log("点击了啥！！！！！！");
        
        CIKDir.Instance.simulinkBeginWithSuper();
    }
    public void onCliclLayerDataSelect(int type)
    {


        foreach (BoxData data in LayerStructrueDataCache.g2boxDataDic.Values)
        {
            if (data.layer == (type-1))
            {
                data.Cube.gameObject.SetActive(true);
            }
        }
    }

    public void hideAllLayer()
    {
        foreach (BoxData data in LayerStructrueDataCache.g2boxDataDic.Values)
        {
            
                data.Cube.gameObject.SetActive(false);
            
        }
    }
    void Start()
    {
        FileViewer.Instance.addViewer(this);
    }
    public void func_exportSingleLayer()
    {
        Debug.Log("打开文件！");
        request = true;
        FileViewer.Instance.show();
        FileViewer.Instance.fresh();
        FileViewer.Instance.activateInputFunc();

    }
    public void func_importLayer()
    {
        request = true;
        FileViewer.Instance.show();
        FileViewer.Instance.fresh();
    }

    /// <summary>
    /// 选择目标
    /// </summary>
    public void func_selectInsBoxAim()
    {
        selectStrategy = new ShapeXSelectFunc(this);


    }

    int simulinkStatu = 0;
    public void func_beginSimulink()
    {

        if (simulinkStatu % 2 == 0)
        {
            //  ShapeXManager.Instance.gameObject.SetActive(false);
            //  CIKDir.Instance.enabled = true;
            //  LayerStructrueDataCache.Instance.changeWorkColor();

            CIKDir.Instance.enabled = true;


            CIKDir.Instance.initSimulinkFromList(LayerStructrueDataCache.Instance.orderObjList(),

                LayerStructrueDataCache.Instance.carryList);
          //
          //  for (int i = 0; i < 200; i++)
          //  {
          //
          //      Debug.Log("运行！");
          //      CIKDir.Instance.moveStrategy.doSomthing();
          //  }
        }
        else
        {
            ShapeXManager.Instance.gameObject.SetActive(true);
            CIKDir.Instance.enabled = false;

        }
        simulinkStatu++;

    }

    void Update()
    {
        if (selectStrategy != null)
        {
            selectStrategy.doSomthing();

        }
    }
    public void update(ViewInfo info)
    {

        if (request == false)
            return;

        else
            request = false;

        
        switch (info.arg1) {

            case "cancel":

                FileViewer.Instance.hide();
                Debug.Log("cancel");

                break;

            case "confirm":
                LayerStructrueDataCache.Instance.insJsonData(info.arg2);

                FileViewer.Instance.fresh();

                FileViewer.Instance.hide();
                Debug.Log("confirm");
                break;

            default:

                break;
        }
    }

    public void endStrategy()
    {
        this.selectStrategy = null;
    }

    public void endStrategy(Strategy strategy)
    {
        throw new System.NotImplementedException();
    }

    public void changeStrategy(Strategy strategy)
    {
        throw new System.NotImplementedException();
    }

    public void getStretegyRevalue(ViewInfo info)
    {

        switch (info.arg1)
        {
            case "select":

               

                Debug.Log("选择完毕！");
                break;

            default:

                break;
        }


    }
}
