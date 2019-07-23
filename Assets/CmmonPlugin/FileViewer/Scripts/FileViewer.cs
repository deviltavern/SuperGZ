using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class FileViewer : ObviewerTemplates,IViewer {

    public RectTransform main;
    public RectTransform Viewport;
    public RectTransform Content;
    public List<GameObject> fileList = new List<GameObject>();

    public Dictionary<string, string> fileInfoDic = new Dictionary<string, string>();
    public GameObject fileViewer_FileItem;
    public static FileViewer Instance;

    public Button Cancel;
    public Button Confirm;
    public InputField inputBox;
    public Text txt;
    private void Awake()
    {
        main = this.GetComponent<RectTransform>();
        Viewport = main.transform.Find("Viewport").GetComponent<RectTransform>();
        Content = Viewport.transform.Find("Content").GetComponent<RectTransform>();

        fileViewer_FileItem = Resources.Load<GameObject>("fileViewer_FileItem");

        addFileListFromDirectory(Application.streamingAssetsPath + "/LayerStructure");
        Instance = this;
        Cancel = this.transform.Find("Cancel").GetComponent<Button>();
        Confirm = this.transform.Find("Confirm").GetComponent<Button>();
        hide();
        inputBox = this.transform.Find("inputBox").GetComponent<InputField>();
        Cancel.onClick.AddListener(cancelEvent);
        Confirm.onClick.AddListener(confirmEvent);

       // txt = this.transform.Find("textValue").GetComponent<Text>();

        

        inactivateInputFunc();

       
        
    }
    public void down() {

    }
    public void activateEvent()
    {

        Cancel.gameObject.SetActive(true);
        Confirm.gameObject.SetActive(true);

    }
    public void activateInputFunc()
    {
        Cancel.gameObject.SetActive(true);
            Confirm.gameObject.SetActive(true);
        inputBox.gameObject.SetActive(true);
    }

    public void inactivateInputFunc()
    {

        Cancel.gameObject.SetActive(false);
        Confirm.gameObject.SetActive(false);
        inputBox.gameObject.SetActive(false);
    }
    public void cancelEvent()
    {
        ViewInfo info = new ViewInfo();

        info.arg1 = "cancel";
       
        broadCast(info);
        Debug.Log("confirm");
    }

    public void confirmEvent()
    {
        ViewInfo info = new ViewInfo();

        info.arg1 = "confirm";
        info.arg2 = inputBox.text;

        broadCast(info);

        Debug.Log("confirm");
    }

    public void deleteFile(string path)
    {

        File.Delete(path);
        fresh();

    }
    public void show()
    {
        this.gameObject.SetActive(true);
    }

    public void hide()
    {
        this.gameObject.SetActive(false);

    }
    public void fresh()
    {
        addFileListFromDirectory(Application.streamingAssetsPath + "/LayerStructure");

    }

    /// <summary>
    /// 按钮点击事件！
    /// </summary>
    /// <param name="g"></param>
    public void onClickItem(GameObject g)
    {

        ViewInfo info = new ViewInfo();
        info.arg1 = "select";
        info.arg2 = g.GetComponent<FileViewerFileItem>().valuePath;

       // txt.text = "value =\n"+ info.arg2;

        broadCast(info);

        hide();

    }
    public void clear()
    {
        fileInfoDic.Clear();
        fresh();
    }



    public void addFile(string path) {

        GameObject item =  GameObject.Instantiate(fileViewer_FileItem, main);

        item.GetComponent<RectTransform>().localPosition = new Vector3(0, 200 - fileList.Count * 40, 0);

        item.transform.SetParent(Content);
        string[] pathArray = path.Split('\\');

        string endStr = pathArray[pathArray.Length - 1];
        string[] endStrArray = endStr.Split('.');
        if (endStrArray[endStrArray.Length - 1] == "txt")
        {
            //item.transform.Find("Text").GetComponent<Text>().text = pathArray[pathArray.Length - 1];

            item.transform.Find("Text").GetComponent<Text>().text = endStr;
            item.GetComponent<FileViewerFileItem>().valuePath = Application.streamingAssetsPath + "/LayerStructure/"+ endStr;
           // fileInfoDic.Add(item.transform.Find("Text").GetComponent<Text>().text, path);
        }
        item.GetComponent<Button>().onClick.AddListener(delegate() {
            onClickItem(item);

        });
        DelegateForDelete deleteEvent = item.AddComponent<DelegateForDelete>();

        deleteEvent.path = path;


        fileList.Add(item);
    }


    public void addFileListFromDirectory(string path)
    {
        fileInfoDic.Clear();
        foreach (GameObject g in fileList) {

            GameObject.Destroy(g);
        }

        fileList.Clear();
        DelegateForDelete.clear();
        List<string> fileStrList = getFolderContent(path);

        foreach (string value in fileStrList)
        {

            string[] endStrArray = value.Split('.');
            if (endStrArray[endStrArray.Length - 1] == "txt")
            {
                addFile(value);
            }
           
        }
     }

    public List<string> getFolderContent(string path)
    {

        DirectoryInfo Dir = new DirectoryInfo(path);



        List<string> listValue = new List<string>();


        foreach (FileInfo info in Dir.GetFiles())
        {
            listValue.Add(info.ToString());
        }
        return listValue;
    }

    public void update(ViewInfo info)
    {

        switch (info.arg1)
        {
            case "delete":
                activateInputFunc();

                

                break;
        }

    }
}
