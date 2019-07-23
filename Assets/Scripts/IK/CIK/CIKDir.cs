using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CIKDir : MonoBehaviour,StrategyMaster {

    public static Vector3 right;
    public static Vector3 up;
    public static Vector3 down;
    public static Vector3 left;
    public static Vector3 back;
    public static Vector3 forward;
    public static float speed = 10;
    public Vector3 ClawInitPose;
    public GameObject claw;
    public static GameObject aimHit;
    public static GameObject endPoint;
    public float rspeed;
    public static Vector3 preDir;
    public static GameObject originPoint;
    Ray ray;
    RaycastHit hit;
    public bool adjustPose;
    public Vector3 subVec;

    int traceTimes = 0;
    int traceOnTime = 0;
    bool allowTrace;
    public static CIKDir Instance;

    public Strategy moveStrategy;

    public Strategy superSimulink;
    private void Awake()
    {

        Instance = this;
        right = new Vector3(0,0,1);
        left = new Vector3(0, 0, -1);

        up = new Vector3(0,1,0);
        down = new Vector3(0, -1, 0);

        forward = new Vector3(1, 0, 0);
        back = new Vector3(-1, 0, 0);

        rspeed = 1;
        adjustPose = true;

        originPoint = GameObject.Find("OriginPoint");
    }

    private void Start()
    {
        claw = CIK_J_BASE.getCIK_J(6).gameObject;

        StartCoroutine(IEInit());
    }


    IEnumerator IEInit()
    {
        yield return new WaitForSeconds(Time.deltaTime*2);

        move(forward);
        this.enabled = (false);
    }
    public static void move(Vector3 vec)
    {
        CIK_JMatrix.Instance.updateClawPos(vec*speed);
        preDir = vec;

    }

    public static void rot(Vector3 euler)
    {
        CIK_JMatrix.Instance.updateClawRot(euler/20);


    }
   float x;
   float x_time;
    float x_dir;
   float y;
   float y_time;
    float y_dir;
   float z;
   float z_time;
    float z_dir;

    float y_offset;

    int selectOperator;
    private void Updat2e()
    {
        if (Input.GetKey(KeyCode.A))
        {
            move(left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            move(right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            move(up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move(down);
        }
        if (Input.GetKey(KeyCode.F))
        {
            move(forward);
        }
        if (Input.GetKey(KeyCode.B))
        {
            move(back);
        }


    }

    
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


    private void Update()
    {
        if (superSimulink != null)
        {

            Debug.Log("执行策略！");
            superSimulink.doSomthing();
        }

        if(this.moveStrategy!= null)
        {

            this.moveStrategy.doSomthing();

            Debug.Log("执行策略！");
        }
        if (Input.GetKey(KeyCode.A))
        {
            move(left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            move(right);
        }
        if (Input.GetKey(KeyCode.W))
        {
            move(up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            move(down);
        }
        if (Input.GetKey(KeyCode.F))
        {
            move(forward);
        }
        if (Input.GetKey(KeyCode.B))
        {
            move(back);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            //CIK_J_BASE.getCIK_J(5).R_right += 0.1f* rspeed;

            rot(up);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {


            //CIK_J_BASE.getCIK_J(5).R_right -= 0.1f * rspeed;
            rot(down );
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // CIK_J_BASE.getCIK_J(6).R_up += 0.1f * rspeed;
           rot(left );

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rot(right);

          
        }
        if (Input.GetKey(KeyCode.M))
        {

            rot(forward);


        }

        if (Input.GetKey(KeyCode.N))
        {


            rot(back);

        }

        if (CheckGuiRaycastObjects() == true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool istouch = Physics.Raycast(ray, out hit);

            if (istouch == true)
            {

                switch (selectOperator)
                {
                    case 0:
                        aimHit = hit.collider.gameObject;
                        selectOperator++;
                        break;

                    case 1:
                        endPoint = hit.collider.gameObject;
                        this.moveStrategy = new MoveToAimPointStrategy(endPoint, aimHit, claw, speed, this,originPoint);



                        selectOperator = 0;
                        break;

                    default:

                        break;
                }
                
               
              
            }
        }

  

    }

    List<GameObject> toList = new List<GameObject>();



    List<GameObject> fromList = new List<GameObject>();

    public  int carryIndex = 0;

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="toList">要搬运到的地方</param>
    /// <param name="fromList">搬运源</param>
    public void initSimulinkFromList(List<GameObject> toList,List<GameObject> fromList)
    {
        this.toList = toList;
        this.fromList = fromList;
        simulinkBegin();
    }

    public GameObject fromObj;
    public GameObject toObj;
    public void simulinkBegin()
    {
        if (carryIndex >= toList.Count)
            return;
        toObj = toList[carryIndex];
        fromObj = fromList[carryIndex];

        aimHit = fromObj;
        endPoint = toObj;
        this.moveStrategy = new MoveToAimPointStrategy(endPoint, aimHit, claw, speed, this, originPoint);
        carryIndex++;
    }


    public void simulinkBeginWithSuper()
    {

        this.superSimulink = new ToOriginBox(LayerStructrueDataCache.Instance.carryList[0], LayerStructrueDataCache.Instance.orderObjList()[0]);
        this.enabled = true;
    }
    public void endStrategy()
    {
        this.moveStrategy = null;
    }

    public void endStrategy(Strategy strategy)
    {
        throw new System.NotImplementedException();
    }

    public void changeStrategy(Strategy strategy)
    {
        this.moveStrategy = strategy;
    }

    public void getStretegyRevalue(ViewInfo info)
    {
        switch (info.arg1)
        {
            case "next":
                simulinkBegin();
                break;
        }
      
    }
}
