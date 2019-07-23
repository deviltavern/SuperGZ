using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeXSelectFunc : Strategy {


    StrategyMaster master;

    public ShapeXSelectFunc(StrategyMaster master)
    {
        this.master = master;
    }
    RaycastHit hit;
    Ray ray;


    int code;
    GameObject tempG;
    public override void doSomthing()
    {
        Debug.Log("执行选择策略");

        switch (code)
        {
            case 0:
                if (Input.GetMouseButtonDown(0))
                {
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);


                    bool isTouch = Physics.Raycast(ray, out hit);

                    if (isTouch == true)
                    {
                        code++;
                    }

                    

                }
                break;

            case 1:
                tempG=  LayerStructrueDataCache.Instance.insCarryBox(hit.collider.gameObject);

                code++;
                break;


            case 2:

                if (Input.GetMouseButtonDown(0))
                {
                    for (int i = 0; i < LayerStructrueDataCache.g2boxDataDic.Count - 1;i++)
                    {
                        GameObject g =  GameObject.Instantiate(tempG, tempG.transform.parent);
                        g.transform.localPosition = tempG.transform.localPosition;

                        g.transform.localEulerAngles = tempG.transform.localEulerAngles;

                        LayerStructrueDataCache.Instance.carryList.Add(g);
                        Debug.Log("生成策略！");
                    }
                    master.endStrategy();
                }
                
               
                break;

            default:


                break;
        }
       
        
    }

    public override void onEnd()
    {
        throw new System.NotImplementedException();
    }

    public override void waitting()
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
