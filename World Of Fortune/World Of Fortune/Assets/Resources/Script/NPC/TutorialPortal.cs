using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPortal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    // 캐릭터가 npc, 포털 on상태로 충동이 되면 캐릭터의 위치를 옮겨준다 
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "User" && CharacterManager.instance.npcTalk && CharacterManager.instance.Level >= 10)
        {
            col.gameObject.GetComponent<Player>().transform.position = new Vector3(300f, 0, 0);
            CharacterManager.instance.currentCity = "헤르비아";
            CharacterManager.instance.currentPosition = "헤르비아";

        }
    }
}

