using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IK_AXLE_BASE : MonoBehaviour {

    public IKCoordinateSys iKCoordinateSys;
    public Matrix4x4 A;
    public float alpha;
    public float a;
    public float sita;

    public static Dictionary<string, IK_AXLE_BASE> IK_AXLEDic = new Dictionary<string, IK_AXLE_BASE>();
    public static float px=0;
    public static float py=0;
    public static float pz=0;



    public float initEuler;
    public IK_AXLE_BASE getAxle(int i)
    {
        string key = "IK_AXLE_" + i;
        return IK_AXLEDic[key];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public float getSita(int i)
    {
        return getAxle(i).sita;
    }
    /// <summary>
    /// 得到的其实是i+1的a，也就是说a3是Angle_4的a
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public float get_a(int i)
    {
        return getAxle(i+1).a;
    }
    public float square(float value)
    {

        return value * value;

    }
    public string value;
    /// <summary>
    /// 臂长
    /// </summary>
    public float d;

    public float cos(float angle)
    {
        return Mathf.Cos(angle * Mathf.PI / 180f);
    }


    public float sin(float angle)
    {
        return Mathf.Sin(angle * Mathf.PI / 180f);
    }
    public virtual void initParameter()
    {

    }
    public void Awake()
    {
        iKCoordinateSys = new IKCoordinateSys();
        A = new Matrix4x4();
        initParameter();
        IK_AXLEDic.Add(this.GetType().Name, this);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	public void Update () {
        drawCoordinateSys();
        updatePValue();
        calculateSita();
        value = px + ":" + py + ":" + pz;
    }

    public virtual void updatePValue()
    {

    }
    public virtual void calculateSita()
    {
        

    }  
    public virtual void drawCoordinateSys()
    {

        Debug.DrawLine(this.transform.position, this.transform.position + iKCoordinateSys.vecz * 20, Color.blue);
        Debug.DrawLine(this.transform.position, this.transform.position + iKCoordinateSys.vecx * 20, Color.red);
        Debug.DrawLine(this.transform.position, this.transform.position + iKCoordinateSys.vecy * 20, Color.green);


    }
}
