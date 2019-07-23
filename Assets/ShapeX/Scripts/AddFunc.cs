using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AddFunc : MonoBehaviour {

    public static AddFunc Instance;


   public abstract void initFunc();
    public void Awake()
    {
        Instance = this;
        
    }

    public void Start()
    {
        initFunc();
    }
    public static void addFunc<T>() where T:MonoBehaviour
    {
        GameObject g = GameObject.Instantiate(ResourcesManager.prefabDic["FuncItem"], Instance.gameObject.transform);

        g.AddComponent<T>();

    }
}
