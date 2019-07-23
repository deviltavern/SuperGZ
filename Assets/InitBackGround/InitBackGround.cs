using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBackGround : MonoBehaviour {
    public static InitBackGround Instance;

    private void Awake()
    {
        Instance = this;

        StartCoroutine(delayInit());
    }


    IEnumerator delayInit()
    {
        yield return new WaitForSeconds(2);

        this.gameObject.SetActive(false);
    }


}
