using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class StandardPoint {

  public float p_x;
  public float p_y;
  public float p_z;
  
  public float r_x;
  public float r_y;
  public float r_z;

    public Vector3 getPos()
    {
        return new Vector3(p_x, p_y, p_z);
    }

    public Vector3 getRot()
    {
        return new Vector3(r_x, r_y, r_z);
    }

    public static List<StandardPoint> list = new List<StandardPoint>();

    public StandardPoint(float r_x, float r_y, float r_z)
    {
        this.r_x = r_x;
        this.r_y = r_y;
        this.r_z = r_z;
    }
    public StandardPoint(Vector3 pos,Vector3 rot)
    {
        this.p_x = pos.x;
        this.p_y = pos.y;
        this.p_z = pos.z;

        this.r_x = rot.x;
        this.r_y = rot.y;
        this.r_z = rot.z;
    }

    public static void saveFromList()
    {
        string value = "";


        foreach (StandardPoint point in list)
        {
            value += JsonUtility.ToJson(point) + "&";


        }




        StreamWriter sw = new StreamWriter(Application.streamingAssetsPath + "/LayerStructure/" + "impoint" + ".txt");
        sw.Write(value);
        sw.Flush();
        sw.Close();


    }


}
