using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DelegateForDelete:ObviewerTemplates, IPointerEnterHandler, IPointerExitHandler,IViewer
{

    public static List<DelegateForDelete> list = new List<DelegateForDelete>();

    public static void clear() {

        list.Clear();

    }

    public static void rebackNormal()
    {
        foreach (DelegateForDelete item in list)
        {
            item.request = false;
            item.onClick = false;
        }
    }

    
   public delegate void callBack();

   public bool onClick;
   public bool request;

    public string path;
    void Awake()
    {
        request = false;

    }
    void Start()
    {

        addViewer(FileViewer.Instance);

        FileViewer.Instance.addViewer(this);
    }

    
    private void Update()
    {

        if (onClick == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                rebackNormal();
                ViewInfo info = new ViewInfo();

                info.arg1 = "delete";
                info.arg2 = path;
                info.aimObje = this.gameObject;
                

                broadCast(info);
                request = true;
            }

        }

    }

   

    public void OnPointerEnter(PointerEventData eventData)
    {
        onClick = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onClick = false;
    }

    public void update(ViewInfo info)
    {

        if (request == false)
        {
            return;

        }
        switch (info.arg1)
        {
            case "confirm":
                Debug.Log("删除该文件！");
                FileViewer.Instance.deleteFile(this.path);
                FileViewer.Instance.inactivateInputFunc();
                break;
        }


    }
}
