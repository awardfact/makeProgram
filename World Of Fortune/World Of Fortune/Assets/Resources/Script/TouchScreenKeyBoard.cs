using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchScreenKeyBoard : MonoBehaviour
{

    InputField input;

    public void start()
    {

        input = transform.GetComponent<InputField>();

    }


    public void KeyBoardOpen()
    {
        input.text = GUI.TextField(new Rect(200,200,100,50), input.text, 15);
    }
}
