using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShapeXFuncBar : MonoBehaviour,IViewer {

    public InputField lenInput;
    public InputField widthInput;
    public InputField heightInput;

    
    public InputField xInput;
    public InputField yInput;
    public InputField zInput;

    public RectTransform indexInfo;
    public InputField indexInput;

    public Button indexInfoSaveBtn;


    public RectTransform property_size;
    public RectTransform property_pos;
    public RectTransform meshSelector;
    public RectTransform meshBackGround;
    public RectTransform Viewport;
    public RectTransform Content;

    public RectTransform mainViewport;
    public RectTransform mainContent;

    public RectTransform layerInfo;
    public InputField layerInput;


    public static ShapeXFuncBar Instance;

    public GameObject selectCube;
    private void Awake()
    {
        mainViewport = this.transform.Find("Viewport").GetComponent<RectTransform>();
        mainContent = mainViewport.Find("Content").GetComponent<RectTransform>();
        property_size = mainContent.transform.Find("property_size").GetComponent<RectTransform>();
        property_pos = mainContent.transform.Find("property_pos").GetComponent<RectTransform>();
        meshSelector = mainContent.transform.Find("meshSelector").GetComponent<RectTransform>();
        meshBackGround = meshSelector.transform.Find("backGround").GetComponent<RectTransform>();
        Viewport = meshBackGround.transform.Find("Viewport").GetComponent<RectTransform>();
        Content = Viewport.transform.Find("Content").GetComponent<RectTransform>();

        layerInfo = mainContent.transform.Find("layerInfo").GetComponent<RectTransform>();

        layerInput = layerInfo.transform.Find("layerInput").GetComponent<InputField>();
        indexInfo = mainContent.transform.Find("indexInfo").GetComponent<RectTransform>();
        indexInfoSaveBtn = indexInfo.transform.Find("save").GetComponent<Button>();
        indexInfoSaveBtn.onClick.AddListener(func_saveIndexInfo);
        indexInfoSaveBtn.gameObject.SetActive(false);

        indexInput = indexInfo.transform.Find("input").GetComponent<InputField>();
        lenInput = property_size.transform.Find("lenInput").GetComponent<InputField>();
        widthInput = property_size.transform.Find("widthInput").GetComponent<InputField>();
        heightInput = property_size.transform.Find("heightInput").GetComponent<InputField>();

        xInput = property_pos.transform.Find("xInput").GetComponent<InputField>();
        yInput = property_pos.transform.Find("yInput").GetComponent<InputField>();
        zInput = property_pos.transform.Find("zInput").GetComponent<InputField>();

        Instance = this;

    }

    public void setLen(float len)
    {
        lenInput.text = len+"";

    }
    private string lastIndexInputValue;
    private string preIndexInputValue;


    private string lastLayerValue;
    private string preLayerValue;

    /// <summary>
    /// 判断是否聚焦在input里面
    /// </summary>
    /// <returns></returns>
    private bool IsFocusOnIndexInputText()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
            return false;
        if (EventSystem.current.currentSelectedGameObject.GetComponent<InputField>() == indexInput)
            return true;
        return false;
    }
    private bool IsFocusOnIndexInputText(InputField input)
    {
        if (EventSystem.current.currentSelectedGameObject == null)
            return false;
        if (EventSystem.current.currentSelectedGameObject.GetComponent<InputField>() == input)
            return true;
        return false;
    }

    void Update()
    {

        if (IsFocusOnIndexInputText() == true)
        {
            Debug.Log("聚焦！index");
            indexInfoSaveBtn.gameObject.SetActive(true);

            preIndexInputValue = indexInput.text;
        }
        else
        {

            if (lastIndexInputValue != preIndexInputValue)
            {
                ViewInfo info = new ViewInfo();

                info.arg1 = "change_index";

                info.arg3 = int.Parse(preIndexInputValue);

                LayerStructrueDataCache.Instance.update(info);


                indexInfoSaveBtn.gameObject.SetActive(false);

                lastIndexInputValue = preIndexInputValue;

            }
           
            indexInput.text = LayerStructrueDataCache.Instance.pointBox_index + "";

        }


        if (IsFocusOnIndexInputText(layerInput) == true)
        {
            Debug.Log("聚焦！layer" + preLayerValue + ":" + lastLayerValue) ;
            preLayerValue = layerInput.text;
        
        }
        else
        {

            if (preLayerValue != lastLayerValue)
            {
                ViewInfo info = new ViewInfo();

                info.arg1 = "change_layer";

                info.arg3 = int.Parse(preLayerValue);

                info.arg2 = LayerStructrueDataCache.g2boxDataDic[LayerStructrueDataCache.Instance.pointBox].id;

                LayerStructrueDataCache.Instance.update(info);

                 preLayerValue = "";
                 lastLayerValue = preLayerValue + "";
               
            }

            if(LayerStructrueDataCache.g2boxDataDic.ContainsKey(LayerStructrueDataCache.Instance.pointBox))
              layerInput.text = LayerStructrueDataCache.g2boxDataDic[LayerStructrueDataCache.Instance.pointBox].layer + "";

        }


        if (selectCube != null)
        {
            setLen(LayerStructrueDataCache.Instance.pointBox_scale_x);
            setWidth(LayerStructrueDataCache.Instance.pointBox_scale_y);
            setHeight(LayerStructrueDataCache.Instance.pointBox_scale_z);

            setX(LayerStructrueDataCache.Instance.pointBox_pos_x);
            setY(LayerStructrueDataCache.Instance.pointBox_pos_y);
            setZ(LayerStructrueDataCache.Instance.pointBox_pos_z);



            

           // lastIndexInputValue = LayerStructrueDataCache.Instance.pointBox_index + "";
            Debug.Log(preIndexInputValue + ":" + lastIndexInputValue);

        }
        
        
     
        

    }

    public void func_saveIndexInfo()
    {



    }
    public void setWidth(float width)
    {
        widthInput.text = width + "";
        indexInfoSaveBtn.gameObject.SetActive(false);
    }

    public void setHeight(float height)
    {
        heightInput.text = height + "";

    }

    public void setX(float x)
    {
        xInput.text = x + "";

    }


    public void setY(float y)
    {
        yInput.text = y + "";

    }


    public void setZ(float z)
    {
        zInput.text = z + "";

    }

    public void update(ViewInfo info)
    {
        switch (info.code)
        {
            case 0:
                //更新size信息

                selectCube = info.aimObje;

                break;
            case 1:
                //更新pos信息


                break;
        }
    }
}
