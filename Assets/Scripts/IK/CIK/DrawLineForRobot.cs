using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineForRobot : MonoBehaviour {

    // Use this for initialization

    public static DrawLineForRobot Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    List<GameObject> itemList = new List<GameObject>();

    GameObject preInsItem;

    public void drawLine(List<CIK_J_BASE> cikList) {

        Destroy(preInsItem);
        GameObject insLineItem = GameObject.Instantiate(ResourcesManager.prefabDic["robotLine"], cikList[0].gameObject.transform.position, Quaternion.identity);
        preInsItem = insLineItem;
        Vector3 dir = Vector3.Normalize(cikList[1].gameObject.transform.position - cikList[0].gameObject.transform.position);

        insLineItem.transform.position = cikList[0].gameObject.transform.position + dir * 20;

        insLineItem.transform.position = cikList[1].gameObject.transform.position;

        insLineItem.transform.position = cikList[2].gameObject.transform.position;

        insLineItem.transform.position = cikList[3].gameObject.transform.position;

        insLineItem.transform.position = cikList[4].gameObject.transform.position;

        insLineItem.transform.position = cikList[5].gameObject.transform.position;

        insLineItem.transform.position = cikList[6].gameObject.transform.position;

    }

    GameObject viewLineItem;


    public void drawLine(Vector3 vec)
    {
   //  
   // if (viewLineItem == null)
   // {
   //     viewLineItem = GameObject.Instantiate(ResourcesManager.prefabDic["robotLine"], vec, Quaternion.identity);
   // }
   // else
   // {
   //     viewLineItem.transform.position = vec;
   // }

    }
    public IEnumerator draw(List<CIK_J_BASE> cikList)
    {
        if (preInsItem != null)
        {


            Destroy(preInsItem);
           
        }
        yield return new WaitForSeconds(Time.deltaTime);
     
    }

    

}
