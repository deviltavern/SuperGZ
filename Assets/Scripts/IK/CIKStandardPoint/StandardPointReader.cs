using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StandardPointReader : MonoBehaviour {

    public static List<StandardPoint> sList = new List<StandardPoint>();

   
    private void Awake()
    {
        StreamReader sr = new StreamReader(Application.streamingAssetsPath + "/LayerStructure/" + "impoint" + ".txt");


        string value = sr.ReadToEnd();

        string[] valueArray = value.Split('&');

        for (int i = 0; i < valueArray.Length - 1; i++)
        {
            StandardPoint pt = JsonUtility.FromJson<StandardPoint>(valueArray[i]);
            sList.Add(pt);
        }

    }



}
