using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputStrategy_InsBox : Strategy,IViewer {



    public GameObject tempObj;
    public InputStrategy_InsBox() {

        SPKeyBoard.Instance.addViewer(this);

    }
    int index = 0;
    public override void doSomthing()
    {
      
        if (Input.GetKey(KeyCode.LeftControl))
        {

            if (Input.GetKeyDown(KeyCode.D)) {

 
                
            }
        }


    }

    public override void onEnd()
    {
      
    }

    public void update(ViewInfo info)
    {

     
      
    }

    public override void waitting()
    {
      
    }

    // Use this for initialization

}
