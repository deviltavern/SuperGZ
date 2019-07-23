using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CSharpAlgorithm.Algorithm;
public abstract class CIK_J_BASE : MonoBehaviour {

    public static Dictionary<string, CIK_J_BASE> dataDic = new Dictionary<string, CIK_J_BASE>();
    public abstract void initParameter();

    public static Matrix J;
    public string s_p;
    public string s_r;
    public string s_z;
    public float s_th;
    public string s_prez;
    public float initTh;

    public float m_px;
    public float m_py;
    public float m_pz;

    public Vector3 mp;

    public float r_x;
    public float r_y;
    public float r_z;


    public Vector3 initEuler;
    public float vitualAngle;
    public Vector3 zVec;

    public Vector3 dir;

    public Vector3 endRotation;

    public Matrix preZ;

    public Matrix ax;
    public Matrix ax_n;
    public Matrix ay;
    public Matrix ay_n;

    public Vector3 nextDir;
    public float ath;
    public float countAngle;
    public float zzAxle;
    
    public Matrix coordinateSys;

    public Vector3 eulerOffset;

    public float R_up;
    public float R_right;
    public float R_foward;
    public virtual void onStart()
    {

    }

    public void add(string k, CIK_J_BASE V) {

        if (dataDic.ContainsKey(k) == false)
        {
            // dataDic.Add(this.GetType().Name, this);
            dataDic.Add( k, V);
        }
    }
    public void Awake()
    {
        initParameter();

        add(this.GetType().Name, this);
        az = new Matrix(3, 1);
        n = new Matrix(4, 1);
        o = new Matrix(4, 1);
        a = new Matrix(4, 1);
        p = new Matrix(4, 1);
        R = new Matrix(3, 3);
        A = new Matrix(4, 4);
        az = new Matrix(3, 1, new double[] { 0, 0, 1 });
        rotations = new Matrix(3, 1);
        initEuler = this.transform.localEulerAngles;
        preZ = new Matrix(3, 1);

        ax_n = new Matrix(3, 1);
        ay_n = new Matrix(3, 1);
        coordinateSys = new Matrix(3, 3, new double[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 });
        randomColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));


    }
    public void Start()
    {
        onStart();
       
    }
    public virtual void rot() {
      

       
            this.transform.Rotate(Vector3.up, R_up, Space.Self);
            this.transform.Rotate(Vector3.forward, R_foward, Space.Self);
            this.transform.Rotate(Vector3.right, R_right, Space.Self);
    
       
    }

    public virtual void updateLocalEuler()
    {

    }
    public static CIK_J_BASE getCIK_J(int i)
    {
        string value = "CIK_J" + i;

        return dataDic[value];
    }

    public string id;
    public float th;
    public float dz;
    public float dx;
    public float alf;
    public Matrix az;
    public Matrix n;
    public Matrix o;
    public Matrix a;
    public Matrix p { get; set; }
    public Matrix R;
    public Matrix A;

   public Color randomColor;

    public abstract void updateTh();
    public Matrix rotations;

    public static List<float> getThList()
    {
        List<float> list = new List<float>();
        list.Add(getCIK_J(0).th);
        list.Add(getCIK_J(1).th);
        list.Add(getCIK_J(2).th);
        list.Add(getCIK_J(3).th);
        list.Add(getCIK_J(4).th);
        list.Add(getCIK_J(5).th);
        list.Add(getCIK_J(6).th);
        return list;

    }
    public static void setThList(List<float> list) 
    {
       
       getCIK_J(0).th  = list[0];
       getCIK_J(1).th  = list[1];
       getCIK_J(2).th  = list[2];
       getCIK_J(3).th  = list[3];
       getCIK_J(4).th  = list[4];
       getCIK_J(5).th  = list[5];
       getCIK_J(6).th  = list[6];
      

    }

    public static List<Quaternion> getRotList()
    {
        List<Quaternion> list = new List<Quaternion>();
        list.Add(getCIK_J(0).transform.localRotation);
        list.Add(getCIK_J(1).transform.localRotation);
        list.Add(getCIK_J(2).transform.localRotation);
        list.Add(getCIK_J(3).transform.localRotation);

        Debug.Log("压入的3值为：" + getCIK_J(3).transform.localRotation );
        list.Add(getCIK_J(4).transform.localRotation);
        list.Add(getCIK_J(5).transform.localRotation);
        list.Add(getCIK_J(6).transform.localRotation);
        return list;

    }

    public static List<Matrix> getMatrixList()
    {
        List<Matrix> list = new List<Matrix>();
      
        list.Add(Matrix.clone(getCIK_J(0).A));
        list.Add(Matrix.clone(getCIK_J(1).A));
        list.Add(Matrix.clone(getCIK_J(2).A));
        list.Add(Matrix.clone(getCIK_J(3).A));
        list.Add(Matrix.clone(getCIK_J(4).A));
        list.Add(Matrix.clone(getCIK_J(5).A));
        list.Add(Matrix.clone(getCIK_J(6).A));

        return list;

    }


    public static void setMatrixList(List<Matrix> list)
    {
       
         getCIK_J(0).A =  list[0];
         getCIK_J(1).A =  list[1];
         getCIK_J(2).A =  list[2];
         getCIK_J(3).A =  list[3];
         getCIK_J(4).A =  list[4];
         getCIK_J(5).A =  list[5];
         getCIK_J(6).A =  list[6];
    }
    public static void setRotList(List<Quaternion> list)
    {

        getCIK_J(0).transform.localRotation = list[0];
        getCIK_J(1).transform.localRotation = list[1];
        getCIK_J(2).transform.localRotation = list[2];
        getCIK_J(3).transform.localRotation = list[3];

        Debug.Log("取出来的3值为：" + getCIK_J(3).transform.localRotation);
        getCIK_J(4).transform.localRotation = list[4];
        getCIK_J(5).transform.localRotation = list[5];
        getCIK_J(6).transform.localRotation = list[6];


    }
    public static List<Vector3> getPosList()
    {
        List<Vector3> list = new List<Vector3>();
        list.Add(getCIK_J(0).transform.localPosition);
        list.Add(getCIK_J(1).transform.localPosition);
        list.Add(getCIK_J(2).transform.localPosition);
        list.Add(getCIK_J(3).transform.localPosition);
        list.Add(getCIK_J(4).transform.localPosition);
        list.Add(getCIK_J(5).transform.localPosition);
        list.Add(getCIK_J(6).transform.localPosition);
        return list;

    }
    public static void setPosList(List<Vector3> list)
    {

        getCIK_J(0).transform.localPosition = list[0];
        getCIK_J(1).transform.localPosition = list[1];
        getCIK_J(2).transform.localPosition = list[2];
        getCIK_J(3).transform.localPosition = list[3];
        getCIK_J(4).transform.localPosition = list[4];
        getCIK_J(5).transform.localPosition = list[5];
        getCIK_J(6).transform.localPosition = list[6];


    }

    public void updatePos()
    {
        this.transform.position = new Vector3((float)p.GetElement(0, 0), (float)p.GetElement(1, 0), (float)p.GetElement(2, 0));

    }
    private void Update()
    {
        updateTh();
        s_p = p.GetElement(0, 0).ToString("F4") + ":" + p.GetElement(1, 0).ToString("F4") + ":" + p.GetElement(2, 0).ToString("F4") + ":";      
        this.transform.position = new Vector3((float)p.GetElement(0, 0), (float)p.GetElement(1, 0), (float)p.GetElement(2, 0));


        s_r = ((rotations.GetElement(0, 0)*Mathf.Rad2Deg)%180).ToString("F4") +
            ":" + ((rotations.GetElement(1, 0) * Mathf.Rad2Deg) % 180).ToString("F4") +
            ":" + ((rotations.GetElement(2, 0) * Mathf.Rad2Deg) % 180).ToString("F4") + ":";

        s_z = az.GetElement(0, 0).ToString("F4") + ":" + az.GetElement(1, 0).ToString("F4") + ":" + az.GetElement(2, 0).ToString("F4") + ":";
        s_prez = preZ.GetElement(0, 0).ToString("F4") + ":" + preZ.GetElement(1, 0).ToString("F4") + ":" + preZ.GetElement(2, 0).ToString("F4") + ":";

        // Debug.Log(DrawLineForRobot)

        countAngle = Vector3.Angle(matrix2Vector3(preZ), Vector3.up);
  //  Debug.DrawLine(this.transform.position, this.transform.position + matrix2Vector3(preZ) * 5000, randomColor);
  //
  //  Debug.DrawLine(this.transform.position, this.transform.position + matrix2Vector3(ax_n) * 5000, Color.red);
  //
  //  Debug.DrawLine(this.transform.position, this.transform.position + matrix2Vector3(ay_n) * 5000, Color.yellow);
   //

        r_x = (float)(rotations.GetElement(0, 0) * Mathf.Rad2Deg) % 360;
        r_y = (float)(rotations.GetElement(1, 0) * Mathf.Rad2Deg) % 360;
        r_z = (float)(rotations.GetElement(2, 0) * Mathf.Rad2Deg) % 360;

        m_px = (float)(p.GetElement(0, 0) * Mathf.Rad2Deg) ;
        m_py = (float)(p.GetElement(1, 0) * Mathf.Rad2Deg) ;
        m_pz = (float)(p.GetElement(2, 0) * Mathf.Rad2Deg) ;

        mp = new Vector3(m_px, m_py, m_pz);
        this.transform.localEulerAngles += eulerOffset;
        s_th = th % 180;
        //   Debug.DrawLine(this.transform.position, this.transform.position +this.transform.forward*500, Color.red);
        // Debug.DrawLine(this.transform.position, this.transform.position + nextDir * 500, Color.green);

       

        
    }

    public Matrix vec2Matrix(Vector3 vec)
    {
        Matrix mat = new Matrix(3, 1, new double[] { vec.x, vec.y, vec.z });

        return mat;

    }

    public Vector3 matrix2Vector3(Matrix m)
    {

        if (m == null)
        {
            return new Vector3();
        }
        Vector3 vec = new Vector3((float)m.GetElement(0, 0), (float)m.GetElement(1, 0),(float)m.GetElement(2, 0));

        return vec;

    }
    /// <summary>
    /// 输入th值
    /// </summary>
    void inputTh(List<float> thList)
    {
        for (int i = 1; i <= thList.Count; i++)
        {
            getCIK_J(i).th = thList[i - 1];

        }


    }


    /// <summary>
    /// 通过输入的th去计算相应的n,o,a,p
    /// </summary>
    /// <param name="CIK"></param>
    void Matrix_DH_Ln(CIK_J_BASE CIK) {

        float C = cos(CIK.th);
        float S = sin(CIK.th);
        float Ca = cos(CIK.alf);
        float Sa = sin(CIK.alf);
        float a = CIK.dx;
        float d = CIK.dz;

        CIK.n.SetData(new double[] {C,S,0,0 });
        CIK.o.SetData(new double[] { -1 * S * Ca, C * Ca, Sa, 0 });
        CIK.a.SetData(new double[] { S * Sa, -1 * C * Sa, Ca, 0 });
        CIK.p.SetData(new double[] { a * C, a * S, d, 1 });

        CIK.R.SetElement( 0, 0, CIK.n.GetElement(0, 0));
        CIK.R.SetElement( 1, 0, CIK.n.GetElement(1, 0));
        CIK.R.SetElement( 2, 0, CIK.n.GetElement(2, 0));


        CIK.R.SetElement(0, 1, CIK.o.GetElement(0, 0));
        CIK.R.SetElement(1, 1, CIK.o.GetElement(1, 0));
        CIK.R.SetElement(2, 1, CIK.o.GetElement(2, 0));

        CIK.R.SetElement(0, 2, CIK.a.GetElement(0, 0));
        CIK.R.SetElement(1, 2, CIK.a.GetElement(1, 0));
        CIK.R.SetElement(2, 2, CIK.a.GetElement(2, 0));

        CIK.A.SetElement(0, 0, CIK.n.GetElement(0, 0));
        CIK.A.SetElement(1, 0, CIK.n.GetElement(1, 0));
        CIK.A.SetElement(2, 0, CIK.n.GetElement(2, 0));
        CIK.A.SetElement(3, 0, CIK.n.GetElement(3, 0));

        CIK.A.SetElement(0, 1, CIK.o.GetElement(0, 0));
        CIK.A.SetElement(1, 1, CIK.o.GetElement(1, 0));
        CIK.A.SetElement(2, 1, CIK.o.GetElement(2, 0));
        CIK.A.SetElement(3, 1, CIK.o.GetElement(3, 0));

        CIK.A.SetElement(0, 2, CIK.a.GetElement(0, 0));
        CIK.A.SetElement(1, 2, CIK.a.GetElement(1, 0));
        CIK.A.SetElement(2, 2, CIK.a.GetElement(2, 0));
        CIK.A.SetElement(3, 2, CIK.a.GetElement(3, 0));

        CIK.A.SetElement(0, 3, CIK.p.GetElement(0, 0));
        CIK.A.SetElement(1, 3, CIK.p.GetElement(1, 0));
        CIK.A.SetElement(2, 3, CIK.p.GetElement(2, 0));
        CIK.A.SetElement(3, 3, CIK.p.GetElement(3, 0));



    }
    
    void ForwardKinematics(List<CIK_J_BASE> dataList)
    {
      
        for (int i = 1; i < 7; i++)
        {
            
            dataList[i].A = dataList[i - 1].A * dataList[i].A;

            dataList[i].p.SetElement(0, 0, dataList[i].A.GetElement(3, 0));
            dataList[i].p.SetElement(1, 0, dataList[i].A.GetElement(3, 1));
            dataList[i].p.SetElement(2, 0, dataList[i].A.GetElement(3, 2));
            dataList[i].p.SetElement(3, 0, dataList[i].A.GetElement(3, 3));

            dataList[i].n.SetElement(0, 0, dataList[i].A.GetElement(0, 0));
            dataList[i].n.SetElement(1, 0, dataList[i].A.GetElement(0, 1));
            dataList[i].n.SetElement(2, 0, dataList[i].A.GetElement(0, 2));
            dataList[i].n.SetElement(3, 0, dataList[i].A.GetElement(0, 3));

            dataList[i].o.SetElement(0, 0, dataList[i].A.GetElement(1, 0));
            dataList[i].o.SetElement(1, 0, dataList[i].A.GetElement(1, 1));
            dataList[i].o.SetElement(2, 0, dataList[i].A.GetElement(1, 2));
            dataList[i].o.SetElement(3, 0, dataList[i].A.GetElement(1, 3));

            dataList[i].a.SetElement(0, 0, dataList[i].A.GetElement(2, 0));
            dataList[i].a.SetElement(1, 0, dataList[i].A.GetElement(2, 1));
            dataList[i].a.SetElement(2, 0, dataList[i].A.GetElement(2, 2));
            dataList[i].a.SetElement(3, 0, dataList[i].A.GetElement(2, 3));

            dataList[i].R.SetElement(0, 0, dataList[i].n.GetElement(0, 0));
            dataList[i].R.SetElement(1, 0, dataList[i].n.GetElement(1, 0));
            dataList[i].R.SetElement(2, 0, dataList[i].n.GetElement(2, 0));


            dataList[i].R.SetElement(0, 1, dataList[i].o.GetElement(0, 0));
            dataList[i].R.SetElement(1, 1, dataList[i].o.GetElement(1, 0));
            dataList[i].R.SetElement(2, 1, dataList[i].o.GetElement(2, 0));

            dataList[i].R.SetElement(0, 2, dataList[i].a.GetElement(0, 0));
            dataList[i].R.SetElement(1, 2, dataList[i].a.GetElement(1, 0));
            dataList[i].R.SetElement(2, 2, dataList[i].a.GetElement(2, 0));

        }




        
    }


    public float cos(float angle)
    {
        return Mathf.Cos(angle * Mathf.PI / 180f);
    }


    public float sin(float angle)
    {
        return Mathf.Sin(angle * Mathf.PI / 180f);
    }

}
