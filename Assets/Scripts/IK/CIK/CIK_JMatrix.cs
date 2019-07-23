using CSharpAlgorithm.Algorithm;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIK_JMatrix : MonoBehaviour {

    public static Matrix J;
    public string str;
    public static List<CIK_J_BASE> cikList = new List<CIK_J_BASE>();
   public float  th0 = 0;
   public float  th1 = 0;
   public float  th2 = -90;
   public float  th3 = 0;
   public float  th4 = 0;
   public float  th5 = 0;
   public float  th6 = 0;
    public float speed;


    public float dth0 = 0;
    public float dth1 = 0;
    public float dth2 = 0;
    public float dth3 = 0;
    public float dth4 = 0;
    public float dth5 = 0;
    public float dth6 = 0;

    public static CIK_JMatrix Instance;

    private void Awake()
    {
        J = new Matrix(6, 6);
        Instance = this;
        speed = 10;
    }


    public void Start()
    {
        cikList.Add(CIK_J_BASE.getCIK_J(0));
        cikList.Add(CIK_J_BASE.getCIK_J(1));
        cikList.Add(CIK_J_BASE.getCIK_J(2));
        cikList.Add(CIK_J_BASE.getCIK_J(3));
        cikList.Add(CIK_J_BASE.getCIK_J(4));
        cikList.Add(CIK_J_BASE.getCIK_J(5));
        cikList.Add(CIK_J_BASE.getCIK_J(6));

        cikList[0].th = th0;
        cikList[1].th = th1;
        cikList[2].th = th2;
        cikList[3].th = th3;
        cikList[4].th = th4;
        cikList[5].th = th5;

        cikList[0].initTh = cikList[0].th;
        cikList[1].initTh = cikList[1].th;
        cikList[2].initTh = cikList[2].th;
        cikList[3].initTh = cikList[3].th;
        cikList[4].initTh = cikList[4].th;
        cikList[5].initTh = cikList[5].th;

        //第一次更新sita值


    }



    public void updateClawPos(Vector3 vec)
    {
        updateJ(cikList);
        Matrix matrix = get_dth(J, vec);
        
        update_dth(matrix, cikList);

        DrawLineForRobot.Instance.drawLine(cikList);

        DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);


    }

    public void updateClawRot(Vector3 euler)
    {
        updateJ(cikList);
        Matrix matrix = get_dth(J, new Vector3(0, 0, 0), euler);

        update_dth(matrix, cikList);

        DrawLineForRobot.Instance.drawLine(cikList);
        DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);

    }
    private void Updat1e()
    {
        
        if (Input.GetKey(KeyCode.T))
        {

            Debug.Log("统计距离：\n"+
                "第1："+ Vector3.Distance(cikList[0].transform.position, cikList[1].transform.position)+"\n----------\n"+
                "第2：" + Vector3.Distance(cikList[1].transform.position, cikList[2].transform.position) + "\n----------\n" +
                "第3：" + Vector3.Distance(cikList[2].transform.position, cikList[3].transform.position) + "\n----------\n" +
                "第4：" + Vector3.Distance(cikList[3].transform.position, cikList[4].transform.position) + "\n----------\n" +
                "第5：" + Vector3.Distance(cikList[4].transform.position, cikList[5].transform.position) + "\n----------\n" +
                "第6：" + Vector3.Distance(cikList[5].transform.position, cikList[6].transform.position) + "\n----------\n" 

                );
        }
        if (Input.GetKey(KeyCode.S))
        {


            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(0, -speed, 0));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);

            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);


        }

        if (Input.GetKey(KeyCode.D))
        {


            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(-speed, 0, 0));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);

            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);
        }

        if (Input.GetKey(KeyCode.W))
        {


            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(0, speed, 0));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);
            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);

        }

        if (Input.GetKey(KeyCode.A))
        {


            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(speed, 0, 0));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);
            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);

        }

        if (Input.GetKey(KeyCode.F))
        {
            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(0, 0, speed));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);
            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);

        }

        if (Input.GetKey(KeyCode.B))
        {
            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(0, 0, -speed));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);
            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(0, 0, 0),new Vector3(speed / 1000f, 0,0));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);
            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(0, 0, 0), new Vector3(-speed/1000f, 0, 0));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);
            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(0, 0, 0), new Vector3(0, speed / 1000f, 0));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);
            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            updateJ(cikList);
            Matrix matrix = get_dth(J, new Vector3(0, 0, 0), new Vector3(0, -speed / 1000f, 0));

            update_dth(matrix, cikList);

            DrawLineForRobot.Instance.drawLine(cikList);
            DrawLineForRobot.Instance.drawLine(cikList[6].gameObject.transform.position);

        }
    }
    // public static Matrix updateJ(List<CIK_J_BASE> CIKList)
    // {
    //
    // }

    public static string matrix2str(Matrix matrix)
    {

       
        string value = "";

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {
                double vl = (double)matrix.GetElement(i, j);
                int  vl_int = (int)( vl);
                double sub = vl - vl_int;
                sub = Math.Abs(sub);

                 value += (int)matrix.GetElement(i, j)+"."+ (int)(sub *1000)+ "$";
            }

        }

        return value;

    }
    public static Matrix updateJ(
      

        
        List<CIK_J_BASE> CIKList
        )
    {
        J = new Matrix(6, 6);

       


        foreach (CIK_J_BASE CIK in CIKList)
        {
            Matrix_DH_Ln(CIK);
        }


        CIK_JMatrix.cikList = ForwardKinematics(CIKList);

        Matrix aimP = cikList[6].p;


        // J(:,n)=[cross(a,target-Link(n).p); a]
        for (int i = 0; i < 6; i++)
        {
            Matrix temp = new Matrix(6, 1);

            Matrix a = CIKList[i].R * CIKList[i].az;
          
            Vector3 v1 = new Vector3((float)a.GetElement(0, 0), (float)a.GetElement(1, 0), (float)a.GetElement(2, 0));


            Matrix tv2 = aimP - CIKList[i].p;


            Vector3 v2 = new Vector3((float)tv2.GetElement(0, 0), (float)tv2.GetElement(1, 0), (float)tv2.GetElement(2, 0));


            Vector3 ca = Vector3.Cross(v1,v2);


            temp.SetElement(0, 0, ca.x);
            temp.SetElement(1, 0, ca.y);
            temp.SetElement(2, 0, ca.z);
            temp.SetElement(3, 0, a.GetElement(0,0));
            temp.SetElement(4, 0, a.GetElement(1, 0));
            temp.SetElement(5, 0, a.GetElement(2, 0));

            J.SetElement(0, i, temp.GetElement(0, 0));
            J.SetElement(1, i, temp.GetElement(1, 0));
            J.SetElement(2, i, temp.GetElement(2, 0));
            J.SetElement(3, i, temp.GetElement(3, 0));
            J.SetElement(4, i, temp.GetElement(4, 0));
            J.SetElement(5, i, temp.GetElement(5, 0));

        }

        
        return J;

        
    }

    public Matrix update_dth(Matrix _J, Matrix _moveDIr,List<CIK_J_BASE> cikList)
    {
        List<float> tempList = new List<float>();


       

        Matrix J2 = Inverse(_J);
      
        Matrix dSpeedMatrix = J2 * _moveDIr;

        cikList[0].th += (float)dSpeedMatrix.GetElement(0,0);
        cikList[1].th += (float)dSpeedMatrix.GetElement(1, 0);
        cikList[2].th += (float)dSpeedMatrix.GetElement(2, 0);
        cikList[3].th += (float)dSpeedMatrix.GetElement(3, 0);
        cikList[4].th += (float)dSpeedMatrix.GetElement(4, 0);
        cikList[5].th += (float)dSpeedMatrix.GetElement(5, 0);

        this.th0 = cikList[0].th;
        this.th1 = cikList[1].th;
        this.th2 = cikList[2].th;
        this.th3 = cikList[3].th;
        this.th4 = cikList[4].th;
        this.th5 = cikList[5].th;


        return dSpeedMatrix;



    }

    public Matrix str2Matrix(string value)
    {
        string[] valueArray = value.Split('$');

        double[] dArray = new double[36];
        for (int i = 0; i < dArray.Length; i++)
        {
            dArray[i] = float.Parse(valueArray[i]);

        }

        return new Matrix(6, 6, dArray);

    }

    public void update_dth(Matrix dthMatrix, List<CIK_J_BASE> cikList)
    {
        Matrix contMx = new Matrix(6, 1);

        Matrix contMxrotations = new Matrix(3, 1);

        string rv = "";
        for (int cik = 0; cik < 6; cik++)
        {
            cikList[cik + 1].th += ((float)dthMatrix.GetElement(cik, 0) / (Mathf.PI)) * 180;

            contMx.SetElement(cik, 0, cikList[cik].th);
          

           
        }
        dth0 =    cikList  [0] .th;
        dth1 =    cikList  [1] .th;
        dth2 =    cikList  [2] .th;
        dth3 =    cikList  [3] .th;
        dth4 =    cikList  [4] .th;
        dth5 =    cikList  [5] .th;
        dth6 =    cikList  [6] .th;

        for (int cik = 0; cik < 6; cik++)
        {
            cikList[cik + 1].updateTh();
                
                
        }
//
//        cikList[0].dir =Vector3.Normalize( new Vector3(cikList[1].transform.position.x,0, cikList[1].transform.position.z)
//
//
//        -new Vector3(cikList[0].transform.position.x, 0, cikList[0].transform.position.z));
//
//        cikList[0].vitualAngle = Vector3.Angle(cikList[0].zVec, cikList[0].dir);
//
//
//        cikList[1].dir = Vector3.Normalize(new Vector3(0, cikList[2].transform.position.y, cikList[2].transform.position.z)
//
//
//     - new Vector3(0, cikList[1].transform.position.y, cikList[1].transform.position.z));
//
//        cikList[1].vitualAngle = Vector3.Angle(cikList[1].zVec, cikList[1].dir);
//        Vector3 SdIR = Vector3.Normalize(new Vector3(0, cikList[2].transform.position.y - cikList[1].transform.position.y, 0));
//
//
//
//        cikList[1].vitualAngle = cikList[1].vitualAngle * SdIR.y * (-1);
//
//        cikList[1].endRotation = new Vector3(cikList[2].th, 0, 0);
//
//
//        cikList[3].endRotation = new Vector3(cikList[3].th - 90+ cikList[2].th, 0, 0);
//        //--------------------CIK2-------------------------------
//
//        cikList[2].dir = Vector3.Normalize(new Vector3(0, cikList[3].transform.position.y, cikList[3].transform.position.z)
//
//
// - new Vector3(0, cikList[2].transform.position.y, cikList[2].transform.position.z));
//
//
//
//        cikList[2].vitualAngle = Vector3.Angle(cikList[2].zVec, cikList[2].dir);
//
//
//        SdIR = Vector3.Normalize(new Vector3(0, cikList[3].transform.position.y - cikList[2].transform.position.y, 0));
//
//
//
//        cikList[2].vitualAngle = cikList[2].vitualAngle * SdIR.y * (-1);
//
//        cikList[2].endRotation = new Vector3(cikList[2].vitualAngle, 0, 0);
//
//
//        //--------------------CIK2-------------------------------
//
//
//        Vector3 tempVecAz = new Vector3();
//        Vector3 tempVecAz0 = new Vector3();
//        for (int cik = 1; cik <= 6; cik++)
//        {
//
//
//            cikList[cik-1].preZ = cikList[cik-1].R * cikList[cik].az;
//
//
//
//            tempVecAz =Vector3.Normalize( new Vector3((float)cikList[cik - 1].preZ.GetElement(0,0), (float)cikList[cik - 1].preZ.GetElement(1, 0), (float)cikList[cik - 1].preZ.GetElement(2, 0)));
//
//
//            tempVecAz0 = new Vector3(0, 0, 1);
//
//
//            Vector3 ax = Vector3.Cross(tempVecAz0, tempVecAz);
//            Vector3 ax_n = Vector3.Normalize(ax);
//
//            cikList[cik - 1].ax_n = vector2Matrix(ax_n);
//            float sum_fan = 0;
//
//            sum_fan = ax_n.x + ax_n.y + ax_n.z;
//            Matrix rot = new Matrix(3, 3);
//           
//            Vector3 tempVecAy = Vector3.Cross(tempVecAz, ax_n);
//
//            // cikList[cik - 1].ax_n = vector2Matrix( Vector3.Cross(matrix2Vector(cikList[cik - 1].preZ),matrix2Vector(cikList[cik].preZ)));
//            //
//            // cikList[cik - 1].ay_n = vector2Matrix(Vector3.Cross(matrix2Vector(cikList[cik - 1].ax_n), matrix2Vector(cikList[cik-1].preZ)));
//          
//            //    if (sum_fan == 0)
//            //    {
//            rot.SetElement(0, 0,1);
//                   rot.SetElement(1, 0, 0);
//                   rot.SetElement(2, 0, 0);
//            
//                   rot.SetElement(0, 1, 0);
//                   rot.SetElement(1, 1, 1);
//                   rot.SetElement(2, 1, 0);
//            
//                   rot.SetElement(0, 2, 0);
//                   rot.SetElement(1, 2, 0);
//                   rot.SetElement(2, 2, 1);
//            
//          //     }
//          //     else
//          //     {
//          //  rot.SetElement(0, 0, ax_n.x);
//          //      rot.SetElement(1, 0, ax_n.y);
//          //      rot.SetElement(2, 0, ax_n.z);
//          //
//          //      rot.SetElement(0, 1, tempVecAy.x);
//          //      rot.SetElement(1, 1, tempVecAy.y);
//          //      rot.SetElement(2, 1, tempVecAy.z);
//          //
//          //      rot.SetElement(0, 2, tempVecAz.x);
//          //      rot.SetElement(1, 2, tempVecAz.y);
//          //      rot.SetElement(2, 2, tempVecAz.z);
//          //
//          //  }
//
//           
//            
//           
//
//
//
//           
//            cikList[cik - 1].nextDir = cikList[cik].mp - cikList[cik - 1].mp;
//
//           // cikList[cik - 1].nextDir = cikList[cik].transform.position - cikList[cik - 1].transform.position;
//
//
//            cikList[cik - 1].nextDir = Vector3.Normalize(cikList[cik - 1].nextDir);
//
//
//            cikList[cik ].rotations = cikList[cik].R * cikList[cik].ax_n;
//
//            //    cikList[cik - 1].ax = cikList[cik - 1].ax.cr
//            //  rv += cikList[cik].rotations.ToString() + "\n------------\n";
//
//          //  Debug.Log("输出矩阵：\n" + rot + "\n-----------\n");
//
//        }
//        //   Debug.Log("更新之后的th：\n" + contMx.ToString()+ "\n------------\n" + rv);
//      //
//      // RobotCIK.dic[1].transform.localEulerAngles = new Vector3(0,0,cikList[1].r_x);
//      //
//      // RobotCIK.dic[2].transform.localEulerAngles = new Vector3(0, 90 + cikList[2].r_y,0 );
        }

    public Vector3 matrix2Vector(Matrix vecMatrix)
    {
        Vector3 vec = new Vector3((float)vecMatrix.GetElement(0,0), (float)vecMatrix.GetElement(1, 0), (float)vecMatrix.GetElement(2, 0));

        return vec;

    }
    public Matrix vector2Matrix(Vector3 vec)
    {
        Matrix matrix = new Matrix(3, 1);

        matrix.SetElement(0, 0, vec.x);
        matrix.SetElement(1, 0, vec.x);
        matrix.SetElement(2, 0, vec.x);

        return matrix;
    }
    
    public Matrix get_dth(Matrix _J, Vector3 _moveDIr)

    {


        List<float> tempList = new List<float>();

        string value = matrix2str(_J);


       

        Matrix J2 = Inverse(_J);
        RequestTool tool = new RequestTool();
        
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("data", value);




        string revalue = tool.getResult(tool.CreatePostHttpResponse("requestIndex?", dic));

    
        Matrix invJ = str2Matrix(revalue);

        Matrix moveDir = new Matrix(6, 1);

       
        moveDir.SetElement(0, 0, _moveDIr.x);
        moveDir.SetElement(1, 0, _moveDIr.y);
        moveDir.SetElement(2, 0, _moveDIr.z);
        moveDir.SetElement(3, 0, 0);

        moveDir.SetElement(5, 0, 0);

        

        Matrix dSpeedMatrix = invJ*moveDir;

      
      


        return dSpeedMatrix;



    }


    public Matrix get_dth(Matrix _J, Vector3 _moveDIr,Vector3 _rotation)

    {
        List<float> tempList = new List<float>();

        string value = matrix2str(_J);




        Matrix J2 = Inverse(_J);
        RequestTool tool = new RequestTool();

        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("data", value);




        string revalue = tool.getResult(tool.CreatePostHttpResponse("requestIndex?", dic));
        //Debug.Log("J=\n" + J);

        Matrix invJ = str2Matrix(revalue);
        //Debug.Log("invj=:\n" + invJ);
        Matrix moveDir = new Matrix(6, 1);


        moveDir.SetElement(0, 0, _moveDIr.x);
        moveDir.SetElement(1, 0, _moveDIr.y);
        moveDir.SetElement(2, 0, _moveDIr.z);
        moveDir.SetElement(3, 0, _rotation.x);
        moveDir.SetElement(4, 0, _rotation.y);
        moveDir.SetElement(5, 0, _rotation.z);



        Matrix dSpeedMatrix = invJ * moveDir;




        Debug.Log("最终的速度微分：\n" + moveDir.ToString() + "---------\n" + dSpeedMatrix.ToString());
        return dSpeedMatrix;



    }
    public static Matrix Inverse(Matrix matrix)
    {
        Matrix m = new Matrix(matrix.Rows, matrix.Columns);
        double[,] array = new double[matrix.Rows, matrix.Columns];

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {

                array[i, j] = matrix.GetElement(i, j);
            }
        }
        array = Inverse(array);

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Columns; j++)
            {

              
                m.SetElement(i, j, array[i, j]);
            }
        }

        return m;
    }


    public static double[,] Inverse(double[,] Array)
    {
        int m = 0;
        int n = 0;
        m = Array.GetLength(0);
        n = Array.GetLength(1);
        double[,] array = new double[2 * m + 1, 2 * n + 1];
        for (int k = 0; k < 2 * m + 1; k++)  //初始化数组
        {
            for (int t = 0; t < 2 * n + 1; t++)
            {
                array[k, t] = 0.00000000;
            }
        }
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                array[i, j] = Array[i, j];
            }
        }

        for (int k = 0; k < m; k++)
        {
            for (int t = n; t <= 2 * n; t++)
            {
                if ((t - k) == m)
                {
                    array[k, t] = 1.0;
                }
                else
                {
                    array[k, t] = 0;
                }
            }
        }
        //得到逆矩阵
        for (int k = 0; k < m; k++)
        {
            if (array[k, k] != 1)
            {
                double bs = array[k, k];
                array[k, k] = 1;
                for (int p = k + 1; p < 2 * n; p++)
                {
                    array[k, p] /= bs;
                }
            }
            for (int q = 0; q < m; q++)
            {
                if (q != k)
                {
                    double bs = array[q, k];
                    for (int p = 0; p < 2 * n; p++)
                    {
                        array[q, p] -= bs * array[k, p];
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        double[,] NI = new double[m, n];
        for (int x = 0; x < m; x++)
        {
            for (int y = n; y < 2 * n; y++)
            {
                NI[x, y - n] = array[x, y];
            }
        }
        return NI;
    }
    public static float cos(float angle)
    {
        return Mathf.Cos(angle * Mathf.PI / 180f);
    }


    public static float sin(float angle)
    {
        return Mathf.Sin(angle * Mathf.PI / 180f);
    }

   static List<CIK_J_BASE> ForwardKinematics(List<CIK_J_BASE> dataList)
    {
        string value = "";
        for (int i = 1; i < 7; i++)
        {

            dataList[i].A = dataList[i - 1].A * dataList[i].A;
            value += "\n"+i + "\n------------\n" + dataList[i].A.ToString();
         
            dataList[i].p.SetElement(0, 0, dataList[i].A.GetElement( 0,3));
            dataList[i].p.SetElement(1, 0, dataList[i].A.GetElement( 1,3));
            dataList[i].p.SetElement(2, 0, dataList[i].A.GetElement( 2,3));
            dataList[i].p.SetElement(3, 0, dataList[i].A.GetElement( 3,3));

            dataList[i].n.SetElement(0, 0, dataList[i].A.GetElement( 0,0));
            dataList[i].n.SetElement(1, 0, dataList[i].A.GetElement( 1,0));
            dataList[i].n.SetElement(2, 0, dataList[i].A.GetElement( 2,0));
            dataList[i].n.SetElement(3, 0, dataList[i].A.GetElement( 3,0));

            dataList[i].o.SetElement(0, 0, dataList[i].A.GetElement( 0,1));
            dataList[i].o.SetElement(1, 0, dataList[i].A.GetElement( 1,1));
            dataList[i].o.SetElement(2, 0, dataList[i].A.GetElement( 2,1));
            dataList[i].o.SetElement(3, 0, dataList[i].A.GetElement( 3,1));

            dataList[i].a.SetElement(0, 0, dataList[i].A.GetElement( 0,2));
            dataList[i].a.SetElement(1, 0, dataList[i].A.GetElement( 1,2));
            dataList[i].a.SetElement(2, 0, dataList[i].A.GetElement( 2,2));
            dataList[i].a.SetElement(3, 0, dataList[i].A.GetElement( 3,2));

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


        return dataList;
      
    }


    static void Matrix_DH_Ln(CIK_J_BASE CIK)
    {

        float C = cos(CIK.th);
        float S = sin(CIK.th);
        float Ca = cos(CIK.alf);
        float Sa = sin(CIK.alf);
        float a = CIK.dx;
        float d = CIK.dz;

        CIK.n.SetData(new double[] { C, S, 0, 0 });
        CIK.o.SetData(new double[] { -1 * S * Ca, C * Ca, Sa, 0 });
        CIK.a.SetData(new double[] { S * Sa, -1 * C * Sa, Ca, 0 });
        CIK.p.SetData(new double[] { a * C, a * S, d, 1 });



        CIK.R.SetElement(0, 0, CIK.n.GetElement(0, 0));
        CIK.R.SetElement(1, 0, CIK.n.GetElement(1, 0));
        CIK.R.SetElement(2, 0, CIK.n.GetElement(2, 0));


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




}
