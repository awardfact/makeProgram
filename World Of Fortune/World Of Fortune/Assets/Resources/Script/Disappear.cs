using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour {
    // 처음에 비활성화 상태로 시작하면은 아이템창을 키거나 장비창을 키기전에는 그 기능을 못해서 처음에 활성화로 만든다음 바로 사라지게 하는 스크립트 
    private float i;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        if (i < 0.1)
            i += Time.deltaTime;
        else
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<Disappear>().enabled = false;
        }
    }
}
