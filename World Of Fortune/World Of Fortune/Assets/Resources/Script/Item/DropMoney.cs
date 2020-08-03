using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMoney : MonoBehaviour
{



    public string itemName;
    public string bigItemType;
    public string smallItemType;
    public long price;
    public string itemExplain;
    public int quantity;


    public long moneyPrice;

    public bool dropIng;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "User" && dropIng)
        {
            UIManager.instance.hasMoney += moneyPrice;
            UIManager.instance.playCanvas.SystemMessageOutput("돈을 " + moneyPrice + " 획득하였습니다.");
            UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
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
