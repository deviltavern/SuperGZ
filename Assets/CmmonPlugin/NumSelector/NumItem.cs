using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NumItem : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{

    bool allowDrug = false;


    public void OnPointerEnter(PointerEventData eventData)
    {
        allowDrug = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        allowDrug = false;
    }

    void Update()
    {

        if (allowDrug == true)
        {
            this.transform.parent.GetComponent<RectTransform>().localPosition += new Vector3(0, Input.mouseScrollDelta.y, 0)*10;
        }

    }
}
