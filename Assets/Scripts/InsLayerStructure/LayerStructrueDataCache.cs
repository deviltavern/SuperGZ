using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LayerStructrueDataCache : MonoBehaviour,IViewer {


    public List<GameObject> boxItemList = new List<GameObject>();

    public static Dictionary<GameObject, BoxData> g2boxDataDic = new Dictionary<GameObject, BoxData>();


    public List<BoxData> getNewBoxDataFromBoxItemList()
    {
        List<BoxData> gList = new List<BoxData>();

        return gList;


    }

    public List<GameObject> carryList = new List<GameObject>();




    public static LayerStructrueDataCache Instance;
    
    public Transform layerParent;
    public GameObject baseBoard;

    public GameObject pointBox;

    /// <summary>
    /// 生成的缓存
    /// </summary>
    GameObject tempObj;

    public string openPath;

    public float pointBox_pos_x;
    public float pointBox_pos_y;
    public float pointBox_pos_z;
    public float pointBox_rot_x;
    public float pointBox_rot_y;
    public float pointBox_rot_z;
    public float pointBox_scale_x;
    public float pointBox_scale_y;
    public float pointBox_scale_z;

    public int pointBox_index;


    public void addNewBox(GameObject box)
    {
       
       

       
    }
    public void removeBox(GameObject box)
    {
        if(box!= null)
        if (g2boxDataDic.ContainsKey(box) == true)
        {
              
            boxItemList.Remove(box);
            g2boxDataDic.Remove(box);
                Destroy(box);
            }
     
    }
    public void insNewShapeBox()
    {
        GameObject box = GameObject.Instantiate(LayerStructrueDataCache.Instance.pointBox, LayerStructrueDataCache.Instance.pointBox.transform.parent);
        LayerStructrueDataCache.Instance.pointBox.transform.localPosition += new Vector3(LayerStructrueDataCache.Instance.pointBox.transform.localScale.x, 0, 0);

        BoxData data = g2boxDataDic[LayerStructrueDataCache.Instance.pointBox].getCopyData();
        Debug.Log("执行生成策略");
        data.Cube = box;
        box.transform.GetComponent<Collider>().enabled = true;

        LayerStructrueDataCache.Instance.boxItemList.Add(box);
        LayerStructrueDataCache.Instance.onSelect(box);    
        g2boxDataDic.Add(box, data);


    }
    public GameObject insNewShapeBox(Vector3 offset)
    {
        GameObject box = GameObject.Instantiate(LayerStructrueDataCache.Instance.pointBox, LayerStructrueDataCache.Instance.pointBox.transform.parent);
        box.transform.localPosition = pointBox.transform.localPosition + offset;

        BoxData data = g2boxDataDic[LayerStructrueDataCache.Instance.pointBox].getCopyData();
        Debug.Log("执行生成策略");
        data.Cube = box;
        box.transform.GetComponent<Collider>().enabled = true;

        Instance.boxItemList.Add(box);
        g2boxDataDic.Add(box, BoxData.getCopyData(box, new BoxData(box)));

        // LayerStructrueDataCache.Instance.onSelect(box);


        return box;

    }
    public void updatePointBoxCacheInfo()
    {
        if (pointBox != null)
        {
            pointBox_pos_x = pointBox.transform.localPosition.x;
            pointBox_pos_y = pointBox.transform.localPosition.y;
            pointBox_pos_z = pointBox.transform.localPosition.z;
            pointBox_rot_x = pointBox.transform.localEulerAngles.x;
            pointBox_rot_y = pointBox.transform.localEulerAngles.y;
            pointBox_rot_z = pointBox.transform.localEulerAngles.z;


            pointBox_scale_x = pointBox.transform.localScale.x;
            pointBox_scale_y = pointBox.transform.localScale.y;
            pointBox_scale_z = pointBox.transform.localScale.z;


            if(g2boxDataDic.ContainsKey(pointBox) == true)
            pointBox_index = g2boxDataDic[pointBox].index;


        }
    }
    void Update()
    {
        updatePointBoxCacheInfo();
    }
    public void onDestroyPointBox()
    {
        
        boxItemList.Remove(pointBox);
        g2boxDataDic.Remove(pointBox);
        Destroy(pointBox);
    }

    public void clear()
    {
        foreach (GameObject g in boxItemList)
        {
            Destroy(g);
        }
        boxItemList.Clear();
    }

    /// <summary>
    /// 生成搬运的box，生成后，会自动聚焦到这个box
    /// </summary>
    /// <param name="aimg"></param>
    /// <returns></returns>
    public GameObject insCarryBox(GameObject aimg)
    {
        if (LayerStructureInputManager.Instance == null)
            return null;

        GameObject box = GameObject.Instantiate(aimg, LayerStructrueDataCache.Instance.layerParent);
       // LayerStructrueDataCache.Instance.pointBox.transform.localPosition += new Vector3(LayerStructrueDataCache.Instance.pointBox.transform.localScale.x, 0, 0);
       
        Debug.Log("执行生成策略");

        box.transform.GetComponent<Collider>().enabled = true;

        LayerStructrueDataCache.Instance.boxItemList.Add(box);

        //  LayerStructrueDataCache.Instance.onSelect(box);

        box.GetComponent<Collider>().isTrigger = false;
        LayerStructureInputManager.Instance.selectAimObjToDoMoveStrategy(box);
        carryList.Add(box);
        return box;
    }

    public void recover(string path)
    {

        clear();
        StreamReader sr = new StreamReader(path);
        openPath = path;
        g2boxDataDic.Clear();
        string[] value = sr.ReadToEnd().Split('&');
        for (int i = 0; i < value.Length - 1; i++)
        {
            BoxData data = JsonUtility.FromJson<BoxData>(value[i]);

            GameObject g = data.insCube(layerParent);

            g.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic["NoneOutline"];
            g.transform.localPosition = new
                Vector3(g.transform.localPosition.x, -1.4f+data.layer, g.transform.localPosition.z);
            g.GetComponent<Collider>().isTrigger = true;
            boxItemList.Add(g);

            g2boxDataDic.Add(g, data);
        }


        CIKDir.Instance.carryIndex = 0;
        CIK_J5.originalRPSetOK = false;
        foreach (GameObject g in carryList)
        {
            Destroy(g);
        }
        carryList.Clear();




    }

    public void insCubeFromLayerData(LayerData data)
    {
        foreach (BoxData boxData in data.boxDataList)
        {

            boxItemList.Add(boxData.insCube(layerParent));
            
        }

    }

    public void changeWorkColor()
    {
        foreach (GameObject g in boxItemList)
        {
            g.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic["transparency"];
        }
        foreach (GameObject g in carryList)
        {
            g.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic["Outline"];
        }
    }


    public void onSelect(GameObject _pointBox)
    {


        if (_pointBox != null)
        {
            if (boxItemList.Contains(_pointBox) == false)
            {
                boxItemList.Add(_pointBox);
            }

            foreach (GameObject g in boxItemList)
            {
                
                g.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic["NoneOutline"];
            }


            _pointBox.GetComponent<MeshRenderer>().material = ResourcesManager.materialDic["Outline"];
            this.pointBox = _pointBox;
        }
        
      
    }



   
    private void Awake()
    {


        Instance = this;


    }
    private void Start()
    {

        FileViewer.Instance.addViewer(this);
        SPKeyBoard.Instance.addViewer(this);
        NumSelector.Instance.addViewer(this);
    }
    public void DestroyAllLayerItem() {


        foreach (GameObject g in boxItemList)
        {
            Destroy(g);
        }

        boxItemList.Clear();
        Destroy(pointBox);

    }

    public string insJsonData(string layerName)
    {

        string value = "";

     
        foreach (GameObject g in boxItemList)
        {
            BoxData boxData = new BoxData(g,g.name);


            string ranID = "";

            for (int i = 0; i < 10; i++)
            {
                ranID += Random.Range(0, 9) + "";

            }

            boxData.id = ranID;


            value += boxData.ToString() + "&";

         
        }
        Debug.Log(value);
        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath+ "/LayerStructure/"+ layerName+".txt");
        sw.Write(value);
        sw.Flush();
        sw.Close();
        return value;

    }

    public string updateJsonData(string layerName)
    {
        string value = "";
        foreach (BoxData data in g2boxDataDic.Values)
        {

            data.coverOriginData();
            value += data.ToString() + "&";
          
        }
        StreamWriter sw = new StreamWriter(layerName);
        sw.Write(value);
        sw.Flush();
        sw.Close();

        return value;

    }

    public void updateJsonData()
    {
        
        File.Delete(openPath);
        updateJsonData(openPath);
        
    }


    public void addBoxData(Vector3 localScanle)
    {

        BoxData boxData = new BoxData();
        boxData.len = (int)localScanle.x*1000;
        boxData.width = (int)localScanle.z*1000;
        boxData.height = (int)localScanle.y*1000;

    }


    public List<GameObject> orderObjList()
    {
        List<int> tempList = new List<int>();


        int maxIndex = 0;

        foreach (BoxData data in g2boxDataDic.Values)
        {
            if (maxIndex < data.index)
            {
                maxIndex = data.index;
            }


        }

        for (int i = 0; i <= maxIndex; i++)
        {
            tempList.Add(i);


        }

        List<GameObject> gList = new List<GameObject>();
        foreach (int i in tempList)
        {
            foreach (BoxData data in g2boxDataDic.Values)
            {

                if (data.index == i)
                {
                    gList.Add(data.Cube);
                }


            }
        }
        return gList;
      


    }


    public GameObject getObjFromBoxDataInDic(string id)
    {
        foreach (BoxData data in g2boxDataDic.Values)
        {
            if (data.id == id)
                return data.Cube;
        }

        return null;
    }
    public void update(ViewInfo info)
    {
        switch (info.arg1)
        {
            case "select":
                recover(info.arg2);

                Debug.Log("选择恢复！");
                break;

            case "change_index":

                int index = (int)info.arg3;
                g2boxDataDic[pointBox].index = index;

                pointBox_index = g2boxDataDic[pointBox].index;
                Debug.Log("修改图片数据");

                updateJsonData();


                break;

            case "change_layer":

                Debug.Log("修改layer");
                int layer = (int)info.arg3;
                g2boxDataDic[pointBox].layer = layer;



                updateJsonData();

                recover(openPath);

                pointBox = getObjFromBoxDataInDic(info.arg2);
                break;

            default:

                break;
        }

            switch (info.opArg)
            {
                case SPKeyField.open_for_copy:

                if (info.arg1 == SPKeyField.over)
                {
                    Debug.Log("将box添加到缓存层");


                    tempObj = null;
                }
                else
                {
                    LayerStructrueDataCache.Instance.removeBox(tempObj);
                    switch (info.arg1)
                    {
                        case SPKeyField.back:
                            tempObj = LayerStructrueDataCache.Instance.insNewShapeBox(new Vector3(1, 0, 0));

                            break;

                        case SPKeyField.forward:
                            tempObj = LayerStructrueDataCache.Instance.insNewShapeBox(new Vector3(0, 1, 0));
                            break;

                        case SPKeyField.right:
                            tempObj = LayerStructrueDataCache.Instance.insNewShapeBox(new Vector3(0, 0, 1));
                            break;

                        case SPKeyField.left:
                            tempObj = LayerStructrueDataCache.Instance.insNewShapeBox(new Vector3(-1, 0, 0));
                            break;

                        case SPKeyField.up:
                            tempObj = LayerStructrueDataCache.Instance.insNewShapeBox(new Vector3(0, -1, 0));
                            break;

                        case SPKeyField.down:
                            tempObj = LayerStructrueDataCache.Instance.insNewShapeBox(new Vector3(0, 0, -1));
                            break;


                    }

                }
              
                    break;

            case MenuField.carry_index:

                Debug.Log("设置搬运索引："+info.arg1);
                g2boxDataDic[pointBox].index = int.Parse(info.arg1);

                updateJsonData();

                recover(openPath);
                break;


            case MenuField.carry_layer:

                Debug.Log("设置搬运层索引：" + info.arg1);
                g2boxDataDic[pointBox].layer = int.Parse(info.arg1);

                updateJsonData();

                recover(openPath);
                break;

               
         


            }

        
    }
}
