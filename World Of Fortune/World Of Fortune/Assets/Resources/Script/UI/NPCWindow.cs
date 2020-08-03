using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCWindow : MonoBehaviour
{
    public string NPCName;
    public string NPCSay;
    public bool shopAvailable;
    public bool questAvailable;
    public bool enhanceAvailable;
    public bool rebirthAvailable;
    public bool warehouseAvailable;



    // Start is called before the first frame update
    void Start()
    {
        NPCName = "null";
        NPCSay = "null";
        shopAvailable = true;
        questAvailable = true;
        enhanceAvailable = true;
        rebirthAvailable = true;
        warehouseAvailable = true;

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
