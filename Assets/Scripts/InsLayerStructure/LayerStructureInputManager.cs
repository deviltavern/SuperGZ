using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LayerStructureInputManager : ObviewerTemplates, StrategyMaster,IViewer
{
    Vector3 dirTypeObtain;
    Vector3 posBallfrom;
    Vector3 posBallto;
    Vector3 initCirclePos;
    // Use this for initialization
    Vector3 initCircleDir;
    public bool ButtonOk = false;
    Vector3 p1;
    Vector3 p5;

    public static LayerStructureInputManager Instance;
    bool isTouch;
    Ray ray;
    RaycastHit hit;
    public GameObject ball;
    public static Dictionary<int, Vector3> dirType = new Dictionary<int, Vector3>();
    public MouseBallAction mouseBall;
    public AngleBallAction mouseAngle;
    public MouseLabelAction mouseLabel;
    

    /// <summary>
    /// 声明策略
    /// </summary>
    public Strategy strategy { get; set; }
    public Strategy strategyMagnetism { get; set; }


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        dirType.Add(0, Vector3.forward);
        dirType.Add(1, Vector3.back);
        dirType.Add(2, Vector3.left);
        dirType.Add(3, Vector3.right);
        insStrategy = new InputStrategy_InsBox();
        CameraStrategy = new InputStrategy_Camera(this);
        DeleteStategy = new InputStrategy_Delete(this);
        inputStrategy_Save = new InputStrategy_Save();

        addViewer(ShapeXFuncBar.Instance);

        MenuBar.Instance.addViewer(this);
    }


    // 定义两个向量 lastVec、preVec
    Vector3 lastVec;
    Vector3 preVec;
    Vector3 dir;
    Vector3 initBall_pos;
    // Update is called once per frame

    float frameTime = 0;
    float frameTime2 = 0;
    float dis;
    GameObject Cube;
    public GameObject initBall;
    public GameObject getBall;
    public GameObject getCircle;
    public GameObject getAngleLabel;
    public Text initAngleLabel;



    private Strategy strechStrategy;
    private Strategy boxMoveStrategy;

    private Strategy boxRotateStrategy;

    private InputStrategy_InsBox insStrategy;

    private Strategy CameraStrategy;

    private InputStrategy_Delete DeleteStategy;
    private Strategy inputStrategy_Save;


    public Dictionary<int, Vector3> cubeFaceDic = new Dictionary<int, Vector3>();


    int selectAimObjToDoMoveStrategyCountTime = 0;

    public void selectAimObjToDoMoveStrategy(GameObject g)
    {

        LayerStructrueDataCache.Instance.onSelect(g);
        StartCoroutine(IEselectAimObjToDoMoveStrategy());

    }
    IEnumerator IEselectAimObjToDoMoveStrategy()
    {
        yield return new WaitForSeconds(Time.deltaTime * 3);
       
        endStrategy();
        boxMoveStrategy = new LayerStructureStrategy_Move(LayerStructrueDataCache.Instance.pointBox, this);
        boxRotateStrategy = new InputStrategy_Rotate(LayerStructrueDataCache.Instance.pointBox);
    }
    /// <summary>
    /// 得到鼠标点位到箱子的具体方向
    /// </summary>
    /// <returns></returns>

    bool CheckGuiRaycastObjects()
    {
        
        PointerEventData eventData = new PointerEventData(MainEvent.Instance.eventSystem);
        eventData.pressPosition = Input.mousePosition;
        eventData.position = Input.mousePosition;

        List<RaycastResult> list = new List<RaycastResult>();
        MainEvent.Instance.grap.Raycast(eventData, list);
        //Debug.Log(list.Count);
        return list.Count > 0;
    }

    void Update()
    {
        bool checkTouchUI = CheckGuiRaycastObjects();
        if (checkTouchUI == true)
        {
            return;

        }
            

        if (strechStrategy != null)
        {
            strechStrategy.doSomthing();
        }

        if (boxMoveStrategy != null)
        {
            boxMoveStrategy.doSomthing();
        }

        if (boxRotateStrategy != null)
        {

            boxRotateStrategy.doSomthing();
        }
        if (strategy != null)
        {
            strategy.doSomthing();
            Debug.Log("执行策略");
            //画三角形的策略
        }

        if (strategyMagnetism != null)
        {
            strategyMagnetism.doSomthing();
            Debug.Log("执行策略");
        }

        if (insStrategy != null)
        {
            insStrategy.doSomthing();
        }
        if (CameraStrategy != null)
        {
            CameraStrategy.doSomthing();
        }

        if (DeleteStategy != null)
        {

            DeleteStategy.doSomthing();
        }

        if (inputStrategy_Save != null)
        {
            inputStrategy_Save.doSomthing();
        }
        if (Input.GetMouseButtonDown(0))
        {




            lastVec = getInputPosition();
            posBallfrom = hit.point;

            //按下左键后，获取相机拍摄下的鼠标点击的位置，
            //lastVec与preVec的位置，y取消，用来计算方向。

            if (isTouch == true)
            {


                if (hit.collider.tag == "Box")
                {
                    //     hit.collider.gameObject.transform.position += dirTypeObtain * Time.deltaTime * 30;
                    Cube = hit.collider.gameObject;
                    //hit检测碰撞到的物体（tag标记为Box）,Cube
                   // LayerStructrueDataCache.Instance.pointBox = Cube;

                    LayerStructrueDataCache.Instance.onSelect(Cube);

                    ViewInfo info = new ViewInfo();
                    info.aimObje = Cube;
                    info.code = 0;

                    broadCast(info);
                }
            }
        }


        if (Cube != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
               // endStrategy();
               // strechStrategy = new InputStrategy_Stretch(LayerStructrueDataCache.Instance.pointBox);
             

            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("执行move策略");

                endStrategy();
                // boxMoveStrategy = new LayerStructureStrategy_Move(LayerStructrueDataCache.Instance.pointBox, this);
                // boxRotateStrategy = new InputStrategy_Rotate(LayerStructrueDataCache.Instance.pointBox);

                MenuBar.Instance.request(IKActionType.reqeust_activate_menubar);
                

            }


            if (Input.GetMouseButton(0))
            {
                //实时时间frameTime箱子时间
                frameTime += Time.deltaTime;
                preVec = getInputPosition();

                if (frameTime > Time.deltaTime * 50)
                {
                    //Time.deltaTime渲染时间 ，鼠标移动时间记录，5帧
                    frameTime = 0;
                    dir = (preVec - lastVec);
                    preVec = lastVec;
                    //计算方向dir(鼠标方向)后，重设preVec

                    dirTypeObtain = getDir(dir);

                    //计算方向dirTypeObtain(四正方向)后，重设preVec

                }


                frameTime2 += Time.deltaTime;
         
            }





            //

            //旋转



        }






        if (Input.GetMouseButtonUp(0))
        {


            posBallto = hit.point;
            //    this.strategy = new LayerMoveStrategy(preVec, lastVec, Cube, dirTypeObtain, ball, posBallfrom,posBallto);

            
        }



    }


    public Vector3 getStandard(Vector3 pos)
    {
        return new Vector3(pos.x, 0, pos.z);


    }
    public GameObject initGetBall(GameObject _initBall, Vector3 _posBallfrom)
    {
        //生成球---第0帧
        _initBall = GameObject.Instantiate(LayerStructureItem.Instance.InsLayerball, LayerStructureItem.Instance.transform);
        _initBall.transform.position = _posBallfrom;
        return _initBall;

    }
    public Text initGetLable(Text _initAngelLable, Vector3 _p5)
    {
        //生成球---第0帧
        _initAngelLable = GameObject.Instantiate(LayerStructureItem.Instance.InsAngelLabel, CanvasManager.canvas.transform);
        _initAngelLable.transform.position = _p5;
        return _initAngelLable;

    }



    public int getMatchDirType(List<float> list)
    {

        float value = getMin(list);//得到最小值
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == value)
            {
                return i;
            }
        }

        return 0;

    }
    public float getMin(List<float> list)
    {

        float min = list[0];
        foreach (float num in list)
        {
            if (min > num)
            {
                min = num;
            }
        }
        return min;
    }

    /// <summary>
    /// 得到一个方向，这个方向从SourceDir只想当前鼠标
    /// </summary>
    /// <param name="sourceDir"></param>
    /// <returns></returns>
    public Vector3 getOnTimeMousePointFromSourceDir(Vector3 sourceDir)
    {
        Vector3 dir = Vector3.Normalize(getStandard(getInputPosition()) - getStandard(sourceDir));

        return dir;

    }
    /// <summary>
    /// 得到一个长度，这个长度从SourceDir指向鼠标Point
    /// </summary>
    /// <param name="sourceDir"></param>
    /// <returns></returns>
    public float getOnTimeMouseLenthFromSourceDir(Vector3 sourceDir)
    {
        float dir = Vector3.Distance(getStandard(getInputPosition()), getStandard(sourceDir));

        return dir;

    }
    public Vector3 getDir(Vector3 from, Vector3 to)
    {
        Vector3 inputDir = Vector3.Normalize(to - from);

        return getDir(inputDir);
    }

    public Vector3 getDir(Vector3 inputDir)
    {
        //  Debug.Log(inputDir);
        float front = Vector3.Angle(inputDir, Vector3.forward);
        float back = Vector3.Angle(inputDir, Vector3.back);
        float left = Vector3.Angle(inputDir, Vector3.left);
        float right = Vector3.Angle(inputDir, Vector3.right);

        // Debug.Log("getDir = " + front + ":" + back + ":" + left + ":" + right);
        List<float> dirList = new List<float>();
        dirList.Add(front);
        dirList.Add(back);
        dirList.Add(left);
        dirList.Add(right);
        int dirTypeInt = getMatchDirType(dirList);
        Vector3 dirTypes = LayerStructureInputManager.dirType[dirTypeInt];

        Debug.Log("方向值：" + dirTypeInt);
        return dirTypes;
    }

    /// <summary>
    /// getInputPosition  取消y的值，方便计算方向
    /// </summary>
    /// <returns></returns>
    public Vector3 getInputPosition()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        isTouch = Physics.Raycast(ray, out hit);
        if (isTouch == true)
        {
            Vector3 pos = hit.point;
            //  Debug.Log(pos);
            return new Vector3(pos.x, 0.5f, pos.z);
        }
        else
        {
            return new Vector3();
        }

    }

    public Vector3 getInputPosition(float y)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool isTouch = Physics.Raycast(ray, out hit);
        if (isTouch == true)
        {
            Vector3 pos = hit.point;
            //  Debug.Log(pos);
            return new Vector3(pos.x, y, pos.z);
        }
        else
        {
            return new Vector3();
        }

    }

    public void endStrategy()
    {

        Debug.Log("结束策略！");
        if (boxRotateStrategy != null)
        {
            boxRotateStrategy.onEnd();

            boxRotateStrategy = null;
        }
        if (boxMoveStrategy != null)
        {
            boxMoveStrategy.onEnd();

            boxMoveStrategy = null;
        }

        if (strechStrategy != null)
        {
            strechStrategy.onEnd();

            strechStrategy = null;
        }



    }

    public void endStrategy(Strategy strategy)
    {
        if (this.boxMoveStrategy == strategy)
        {
            boxMoveStrategy = null;

        }
    }

    public void changeStrategy(Strategy strategy)
    {
        throw new System.NotImplementedException();
    }

    public void getStretegyRevalue(ViewInfo info)
    {
        throw new System.NotImplementedException();
    }

    public void update(ViewInfo info)
    {
        switch (info.opArg)
        {
            case IKActionType.reqeust_activate_menubar:

                switch (info.arg1)
                {
                    case MenuField.move:

                        endStrategy();
                        boxMoveStrategy = new LayerStructureStrategy_Move(LayerStructrueDataCache.Instance.pointBox, this);
                       
                        break;

                    case MenuField.rot:
                        endStrategy();
                        boxRotateStrategy = new InputStrategy_Rotate(LayerStructrueDataCache.Instance.pointBox);

                        break;


                    case MenuField.copy:


                        SPKeyBoard.Instance.request(SPKeyField.open_for_copy);

                        break;

                    case MenuField.save:

                        LayerStructrueDataCache.Instance.updateJsonData();

                        break;

                    case MenuField.scale_change:

                        endStrategy();
                        strechStrategy = new InputStrategy_Stretch(LayerStructrueDataCache.Instance.pointBox);
                        Debug.Log("缩放！");


                        break;

                    case MenuField.delete:

                        LayerStructrueDataCache.Instance.onDestroyPointBox();

                        break;

                    default:

                        break;


                }
             
                break;

            default:

                break;

        }
    }
}
