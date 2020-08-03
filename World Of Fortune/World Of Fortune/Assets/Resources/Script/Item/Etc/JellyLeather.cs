using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyLeather : MonoBehaviour
{
    public bool sharePosiible; // 계정공유 가능한지 가능 = true;

    public string itemName;
    public string bigItemType;
    public string smallItemType;
    public long price;
    public string itemExplain;
    public int quantity;

    public bool dropIng;


    // Start is called before the first frame update
    void Start()
    {
        itemName = "젤리가죽";
        bigItemType = "Etc";
        smallItemType = "Etc";
        price = 50;
        itemExplain = "젤리의 가죽이다.";
        quantity = 1;
        sharePosiible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "User" && dropIng)
        {
            UIManager.instance.dropItemTemp.itemName = itemName;
            UIManager.instance.dropItemTemp.bigItemType = bigItemType;
            UIManager.instance.dropItemTemp.smallItemType = smallItemType;
            UIManager.instance.dropItemTemp.price = price;
            UIManager.instance.dropItemTemp.itemExplain = itemExplain;
            UIManager.instance.dropItemTemp.quantity = quantity;
            UIManager.instance.dropItemTemp.GetItem(quantity);
            UIManager.instance.playCanvas.SystemMessageOutput("젤리가죽을 " + quantity + "개 획득하였습니다.");
            this.transform.position = new Vector2(-500f, 5f);
            dropIng = false;
            SoundManager.instance.SoundEffectOn("GetItemSound", SoundManager.instance.soundEffectNumber);
        }
    }
    public void Drop()
    {
        StartCoroutine(DropCor());
    }
    IEnumerator DropCor()
    {


        yield return new WaitForSeconds(30f);
        if (dropIng)
        {
            this.transform.position = new Vector2(-500f, 5f);
            dropIng = false;
        }



    }
}
