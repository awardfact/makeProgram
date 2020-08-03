using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCSellItem : MonoBehaviour
{

    public string itemName;
    public string bigItemType;
    public string smallItemType;
    public long price;
    public string itemExplain;
    public int quantity;


    public long maxAddHP;    // 사용시 올라가는 체력 최대치
    public long maxAddMP;   //  사용시 올라가는 마나 최대치 

    public long maxAddMaxMP;   // 사용시 올라가는 최대 체력 최대치( 올라가는 옵션이 최대 체력이고 사용했을때 랜덤으로 수치가 증가하는데 증가 수치 중 최대치가 이 변수)
    public long maxAddMaxHP; // 사용시 올라가는 최대 마나 최대치(BUFF) 
    public long maxAddSTR; //  사용시 올라가는 STR스텟 최대치(BUff)
    public long maxAddHEL;  // 사용시 올라가는 Hel스텟 최대치(BUFF)
    public long maxAddINT;  // 사용시 올라가는 INt스텟 최대치(BUFF)
    public long maxAddLUK; // 사용시 올라가는 LUk스텟 최대치(BUFF)
    public long maxAddPower;
    public long maxAddMagicPower;
    public long maxAddDefence;

    public float coolTime;  // 소비 아이템일떄 쿨타임
    public float stayTime;  //버프 아이템일때 지속시간


    public long addMaxHP;  // 장착시 올라가는 최대체력
    public long addMaxMP; // 장착시 올라가는 최대마나
    public long addSTR;  // 장착시 올라가는 Str스텟
    public long addHEL;  // 장착시 올라가는 hel스텟
    public long addINT;  //장착시 올라가는 int스텟
    public long addLUK;  // 장착시 올라가는luck스텟
    public long addPower;
    public long addMagicPower;
    public long addDefence;

    public long requireAccumulateLevel;
    public long requireLevel;
    public long requireSTR;
    public long requireHEL;
    public long requireINT;
    public long requireLUK;


    public bool sharePosiible; // 계정공유 가능한지 가능 = true;



    public int slotNumber;
    public int enhanceLevel;  // 강화단계 장비템 보여줄때 if이거 0아니면 이름 + 강화레벨로 이름을 보여줌 
    public int enhanceStack;

    public Image itemImage;
    public Text priceText;


    // Start is called before the first frame update
    void Start()
    {
        itemImage = transform.Find("ItemImage").gameObject.GetComponent<Image>();
        priceText = transform.Find("Price").gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //판매 아이템 버튼을 클릭하면 판매 아이템 정보가 ItemTemp에 넘어가고  상점에 판매 아이템 정보가 텍스트로 출력된다 
    public void SlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.npcShopWindow.buyItmeNumber = int.Parse(this.transform.name.Split('_')[1]) - 1;
        UIManager.instance.itemTemp.itemName = itemName;
        UIManager.instance.itemTemp.bigItemType = bigItemType;
        UIManager.instance.itemTemp.smallItemType = smallItemType;
        UIManager.instance.itemTemp.price = price;
        UIManager.instance.itemTemp.itemExplain = itemExplain;
        UIManager.instance.itemTemp.maxAddHP = maxAddHP;
        UIManager.instance.itemTemp.maxAddMP = maxAddMP;
        UIManager.instance.itemTemp.maxAddMaxMP = maxAddMaxMP;
        UIManager.instance.itemTemp.maxAddMaxHP = maxAddMaxHP;
        UIManager.instance.itemTemp.maxAddSTR = maxAddSTR;
        UIManager.instance.itemTemp.maxAddHEL = maxAddHEL;
        UIManager.instance.itemTemp.maxAddINT = maxAddINT;
        UIManager.instance.itemTemp.sharePosiible = sharePosiible;
        UIManager.instance.itemTemp.maxAddLUK = maxAddLUK;
        UIManager.instance.itemTemp.maxAddPower = maxAddPower;
        UIManager.instance.itemTemp.maxAddMagicPower = maxAddMagicPower;
        UIManager.instance.itemTemp.maxAddDefence = maxAddDefence;
        UIManager.instance.itemTemp.coolTime = coolTime;
        UIManager.instance.itemTemp.stayTime = stayTime;
        UIManager.instance.itemTemp.addMaxHP = addMaxHP;
        UIManager.instance.itemTemp.addMaxMP = addMaxMP;
        UIManager.instance.itemTemp.addSTR = addSTR;
        UIManager.instance.itemTemp.addHEL = addHEL;
        UIManager.instance.itemTemp.addINT = addINT;
        UIManager.instance.itemTemp.addLUK = addLUK;
        UIManager.instance.itemTemp.addPower = addPower;
        UIManager.instance.itemTemp.addMagicPower = addMagicPower;
        UIManager.instance.itemTemp.addDefence = addDefence;
        UIManager.instance.itemTemp.requireLevel = requireLevel;
        UIManager.instance.itemTemp.requireSTR = requireSTR;
        UIManager.instance.itemTemp.requireHEL = requireHEL;
        UIManager.instance.itemTemp.requireINT = requireINT;
        UIManager.instance.itemTemp.requireLUK = requireLUK;
        UIManager.instance.itemTemp.quantity = quantity;
        UIManager.instance.itemTemp.enhanceLevel = enhanceLevel;
        UIManager.instance.itemTemp.enhanceStack = enhanceStack;
        if (bigItemType == "Equipment")
        {
            UIManager.instance.shop_SelectItemText.text = "아이템 이름 : " + itemName + "\n" + "종류 : " + smallItemType + "\n가격 : " + (price * 1.5) +
                "\n공격력 : + " + addPower + " 마력 : + " + addMagicPower + "\n방어력 : + " + addDefence + "최대체력 : + " + addMaxHP + " 최대마나 : + " + addMaxMP + "\n힘 : + " + addSTR + " 건강 : + " + addHEL + "\n지능 : + "
                + addINT + " 운 : + " + addLUK + "\n" + "착용 요구치 \n레벨 :  " + requireLevel + " 누적레벨 :  " + requireAccumulateLevel + "\nSTR : "
                + requireSTR + " HEL : " + requireHEL + "\nINT : " + requireINT + " LUK : " + requireLUK + "\n강화의 비약 : " + enhanceStack + " 중첩";
        }
        else if (bigItemType == "Consume")
        {
            if (smallItemType == "StaticPotion")
            {
                UIManager.instance.shop_SelectItemText.text = "아이템 이름 : " + itemName + "\n" + "종류 : " + smallItemType + "\n가격 : " + (price * 1.5) +
                    "\n체력회복량 : " + maxAddHP + "\n마나회복량 : " + maxAddMP + "\n" + itemExplain + "\n공유 : " + sharePosiible;
            }
            else if (smallItemType == "Buff")
            {
                UIManager.instance.shop_SelectItemText.text = "아이템 이름 : " + itemName + "\n" + "종류 : " +smallItemType + "\n가격 : " + (price * 1.5) +
                 "\n지속시간 : " + stayTime + "\n최대체력 : + " + maxAddMaxHP + "\n최대마나 : + " + maxAddMaxMP + "\n힘 : + "
                 + maxAddSTR + "\n건강 : + " + maxAddHEL + "\n지능 : + " + maxAddINT + "\n운 : + " + maxAddLUK + "\n공격력 : +"
                 + maxAddPower + "\n마력 : + " + maxAddMagicPower + "\n방어력 : + " + maxAddDefence + "\n" + itemExplain + "\n공유 : " + sharePosiible; ;


            }
            else if (smallItemType == "PercentPotion")
            {
                UIManager.instance.shop_SelectItemText.text = "아이템 이름 : " + itemName + "\n" + "종류 : " + smallItemType + "\n가격 : " + (price * 1.5) +
                   "\n체력회복량 : " + maxAddHP + "%\n마나회복량 : " + maxAddMP + "%\n" + itemExplain + "\n공유 : " + sharePosiible; ;
            }


        }
        else if (bigItemType == "Etc")
        {
            UIManager.instance.shop_SelectItemText.text = "아이템 이름 : " + itemName + "\n가격 : " + (price * 1.5) +
              "\n" + itemExplain + "\n공유 : " + sharePosiible; ;
        }
        else if (bigItemType == "Cash")
        {
            UIManager.instance.shop_SelectItemText.text = "아이템 이름 : " + itemName + "\n가격 : " + (price * 1.5) +
                "\n" + itemExplain + "\n공유 : " + sharePosiible; ;

        }
        //UIManager.instance.item_SelectItemExplainText.text = 내용


    }

    public void Refresh()
    {
        // 아이템 이름이 널이 아니면 아이템이 있는 상태이기 떄문에 아이템 이미지로 바꿔줌 
        if (itemName != "null")
        {
            itemImage.sprite = Resources.Load("Sprite/Item/" + bigItemType + "/" + itemName, typeof(Sprite)) as Sprite;
            itemImage.color = new Color(1, 1, 1, 1);
            priceText.text = (price * 1.5).ToString();
        }
        //아이템 이름이 널이면 아이템이 없는 상태이기 때문에 이미지를 투명하게 해준다 
        else
        {

            itemImage.sprite = null;
            itemImage.color = new Color(1, 1, 1, 0);
            priceText.text = 0.ToString();

        }

    }

}
