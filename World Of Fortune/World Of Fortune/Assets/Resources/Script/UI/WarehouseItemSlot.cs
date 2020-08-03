using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class WarehouseItemSlot : MonoBehaviour
{



    StreamReader streamReader;
    StreamWriter streamWriter;
    string s;



    // 공통정보 
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
    public Text quantityText;



    public long rand1;
    public long rand2;
    public float rand3;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = transform.Find("Image").gameObject.GetComponent<Image>();
        quantityText = transform.Find("Text").gameObject.GetComponent<Text>();
        itemName = "null";
    }


    public void SlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (itemName != "null")
        {
            UIManager.instance.warehouseItemTemp.slotNumber = int.Parse(this.transform.name.Split('_')[1]) - 1;
            UIManager.instance.warehouseItemTemp.itemName = itemName;
            UIManager.instance.warehouseItemTemp.bigItemType = bigItemType;
            UIManager.instance.warehouseItemTemp.smallItemType = smallItemType;
            UIManager.instance.warehouseItemTemp.price = price;
            UIManager.instance.warehouseItemTemp.itemExplain = itemExplain;
            UIManager.instance.warehouseItemTemp.maxAddHP = maxAddHP;
            UIManager.instance.warehouseItemTemp.maxAddMP = maxAddMP;
            UIManager.instance.warehouseItemTemp.maxAddMaxMP = maxAddMaxMP;
            UIManager.instance.warehouseItemTemp.maxAddMaxHP = maxAddMaxHP;
            UIManager.instance.warehouseItemTemp.maxAddSTR = maxAddSTR;
            UIManager.instance.warehouseItemTemp.maxAddHEL = maxAddHEL;
            UIManager.instance.warehouseItemTemp.maxAddINT = maxAddINT;
            UIManager.instance.warehouseItemTemp.sharePosiible = sharePosiible;
            UIManager.instance.warehouseItemTemp.maxAddLUK = maxAddLUK;
            UIManager.instance.warehouseItemTemp.maxAddPower = maxAddPower;
            UIManager.instance.warehouseItemTemp.maxAddMagicPower = maxAddMagicPower;
            UIManager.instance.warehouseItemTemp.maxAddDefence = maxAddDefence;
            UIManager.instance.warehouseItemTemp.coolTime = coolTime;
            UIManager.instance.warehouseItemTemp.stayTime = stayTime;
            UIManager.instance.warehouseItemTemp.addMaxHP = addMaxHP;
            UIManager.instance.warehouseItemTemp.addMaxMP = addMaxMP;
            UIManager.instance.warehouseItemTemp.addSTR = addSTR;
            UIManager.instance.warehouseItemTemp.addHEL = addHEL;
            UIManager.instance.warehouseItemTemp.addINT = addINT;
            UIManager.instance.warehouseItemTemp.addLUK = addLUK;
            UIManager.instance.warehouseItemTemp.addPower = addPower;
            UIManager.instance.warehouseItemTemp.addDefence = addDefence;
            UIManager.instance.warehouseItemTemp.requireLevel = requireLevel;
            UIManager.instance.warehouseItemTemp.requireSTR = requireSTR;
            UIManager.instance.warehouseItemTemp.requireHEL = requireHEL;
            UIManager.instance.warehouseItemTemp.requireINT = requireINT;
            UIManager.instance.warehouseItemTemp.requireLUK = requireLUK;
            UIManager.instance.warehouseItemTemp.quantity = quantity;
            UIManager.instance.warehouseItemTemp.enhanceLevel = enhanceLevel;
            UIManager.instance.warehouseItemTemp.enhanceStack = enhanceStack;
            if (bigItemType == "Equipment")
            {
                UIManager.instance.warehouse_SelectItemText.text = itemName + "\n" + smallItemType + "\n가격 : " + price +
                    "\n공격력 : + " + addPower + " 마력 : + " + addMagicPower + "\n방어력 : + " + addDefence + "최대체력 : + " + addMaxHP + " 최대마나 : + " + addMaxMP + "\n힘 : + " + addSTR + " 건강 : + " + addHEL + "\n지능 : + "
                    + addINT + " 운 : + " + addLUK + "\n" + "착용 요구치 \n레벨 :  " + requireLevel + " 누적레벨 :  " + requireAccumulateLevel + "\nSTR : "
                    + requireSTR + " HEL : " + requireHEL + "\nINT : " + requireINT + " LUK : " + requireLUK + "\n강화의 비약 : " + enhanceStack + " 중첩";
            }
            else if (bigItemType == "Consume")
            {
                if (smallItemType == "StaticPotion")
                {
                    UIManager.instance.warehouse_SelectItemText.text = itemName + "\n" + smallItemType + "\n가격 : " + price +
                        "\n체력회복량 : " + maxAddHP + "\n마나회복량 : " + maxAddMP + "\n" + itemExplain + "\n공유 : " + sharePosiible;
                }
                else if (smallItemType == "Buff")
                {
                    UIManager.instance.warehouse_SelectItemText.text = itemName + "\n" + smallItemType + "\n가격 : " + price +
                     "\n지속시간 : " + stayTime + "\n최대체력 : + " + maxAddMaxHP + "\n최대마나 : + " + maxAddMaxMP + "\n힘 : + "
                     + maxAddSTR + "\n건강 : + " + maxAddHEL + "\n지능 : + " + maxAddINT + "\n운 : + " + maxAddLUK + "\n공격력 : +"
                     + maxAddPower + "\n마력 : + " + maxAddMagicPower + "\n방어력 : + " + maxAddDefence + "\n" + itemExplain + "\n공유 : " + sharePosiible; ;


                }
                else if (smallItemType == "PercentPotion")
                {
                    UIManager.instance.warehouse_SelectItemText.text = itemName + "\n" + smallItemType + "\n가격 : " + price +
                       "\n체력회복량 : " + maxAddHP + "%\n마나회복량 : " + maxAddMP + "%\n" + itemExplain + "\n공유 : " + sharePosiible; ;
                }


            }
            else if (bigItemType == "Etc")
            {
                UIManager.instance.warehouse_SelectItemText.text = itemName + "\n가격 : " + price +
                  "\n" + itemExplain + "\n공유 : " + sharePosiible; ;
            }
            else if (bigItemType == "Cash")
            {
                UIManager.instance.warehouse_SelectItemText.text = itemName + "\n가격 : " + price +
                    "\n" + itemExplain + "\n공유 : " + sharePosiible;
            }
        }
        else
        {
            UIManager.instance.warehouse_SelectItemText.text = "";  


        }


    }

    // 창고 슬롯에 보이는 것들을 현재상태로 바꿔준다 
    public void Refresh()
    {
        // 아이템 이름이 널이 아니면 아이템이 있는 상태이기 떄문에 아이템 이미지로 바꿔줌 
        if (itemName != "null")
        {
            if (bigItemType == "Equipment")
            {
                if (itemName.Substring(0, 1).Equals("+"))
                {
                    itemImage.sprite = Resources.Load("Sprite/Item/" + bigItemType + "/" + itemName.Substring(3), typeof(Sprite)) as Sprite;

                }
                else
                {
                    itemImage.sprite = Resources.Load("Sprite/Item/" + bigItemType + "/" + itemName, typeof(Sprite)) as Sprite;
                    quantityText.text = quantity.ToString();
                    itemImage.color = new Color(1, 1, 1, 1);

                }

            }
            else
            {
                itemImage.sprite = Resources.Load("Sprite/Item/" + bigItemType + "/" + itemName, typeof(Sprite)) as Sprite;
                quantityText.text = quantity.ToString();
                itemImage.color = new Color(1, 1, 1, 1);
            }

        }
        //아이템 이름이 널이면 아이템이 없는 상태이기 때문에 이미지를 투명하게 해준다 
        else
        {

            itemImage.sprite = null;
            itemImage.color = new Color(1, 1, 1, 0);
            quantityText.text = 0.ToString();

        }

    }


    //저장하기 버튼을 누르면 호출
    public void Save()
    {

        if (UIManager.instance.environment == "Mobile")
        {
            streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Warehouse/WarehouseSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(itemName + "`");
            streamWriter.Write(bigItemType + "`");
            streamWriter.Write(smallItemType + "`");
            streamWriter.Write(price + "`");
            streamWriter.Write(itemExplain + "`");
            streamWriter.Write(quantity + "`");
            streamWriter.Write(maxAddHP + "`");
            streamWriter.Write(maxAddMP + "`");
            streamWriter.Write(maxAddMaxMP + "`");
            streamWriter.Write(maxAddMaxHP + "`");
            streamWriter.Write(maxAddSTR + "`");
            streamWriter.Write(maxAddHEL + "`");
            streamWriter.Write(maxAddINT + "`");
            streamWriter.Write(maxAddLUK + "`");
            streamWriter.Write(maxAddPower + "`");
            streamWriter.Write(maxAddMagicPower + "`");
            streamWriter.Write(maxAddDefence + "`");
            streamWriter.Write(coolTime + "`");
            streamWriter.Write(stayTime + "`");
            streamWriter.Write(addMaxHP + "`");
            streamWriter.Write(addMaxMP + "`");
            streamWriter.Write(addSTR + "`");
            streamWriter.Write(addHEL + "`");
            streamWriter.Write(addINT + "`");
            streamWriter.Write(addLUK + "`");
            streamWriter.Write(addPower + "`");
            streamWriter.Write(addMagicPower + "`");
            streamWriter.Write(addDefence + "`");
            streamWriter.Write(requireLevel + "`");
            streamWriter.Write(requireAccumulateLevel + "`");
            streamWriter.Write(requireSTR + "`");
            streamWriter.Write(requireHEL + "`");
            streamWriter.Write(requireINT + "`");
            streamWriter.Write(requireLUK + "`");
            streamWriter.Write(enhanceLevel + "`");
            streamWriter.Write(enhanceStack + "`");
            streamWriter.Write(sharePosiible + "`");
            streamWriter.Close();

        }
        else
        {

            streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/WarehouseSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(itemName + "`");
            streamWriter.Write(bigItemType + "`");
            streamWriter.Write(smallItemType + "`");
            streamWriter.Write(price + "`");
            streamWriter.Write(itemExplain + "`");
            streamWriter.Write(quantity + "`");
            streamWriter.Write(maxAddHP + "`");
            streamWriter.Write(maxAddMP + "`");
            streamWriter.Write(maxAddMaxMP + "`");
            streamWriter.Write(maxAddMaxHP + "`");
            streamWriter.Write(maxAddSTR + "`");
            streamWriter.Write(maxAddHEL + "`");
            streamWriter.Write(maxAddINT + "`");
            streamWriter.Write(maxAddLUK + "`");
            streamWriter.Write(maxAddPower + "`");
            streamWriter.Write(maxAddMagicPower + "`");
            streamWriter.Write(maxAddDefence + "`");
            streamWriter.Write(coolTime + "`");
            streamWriter.Write(stayTime + "`");
            streamWriter.Write(addMaxHP + "`");
            streamWriter.Write(addMaxMP + "`");
            streamWriter.Write(addSTR + "`");
            streamWriter.Write(addHEL + "`");
            streamWriter.Write(addINT + "`");
            streamWriter.Write(addLUK + "`");
            streamWriter.Write(addPower + "`");
            streamWriter.Write(addMagicPower + "`");
            streamWriter.Write(addDefence + "`");
            streamWriter.Write(requireLevel + "`");
            streamWriter.Write(requireAccumulateLevel + "`");
            streamWriter.Write(requireSTR + "`");
            streamWriter.Write(requireHEL + "`");
            streamWriter.Write(requireINT + "`");
            streamWriter.Write(requireLUK + "`");
            streamWriter.Write(enhanceLevel + "`");
            streamWriter.Write(enhanceStack + "`");
            streamWriter.Write(sharePosiible + "`");
            streamWriter.Close();



        }
    }

    public void GameStart()
    {

        // 모바일일때 경로 
        if(UIManager.instance.environment == "Mobile")
        {

            streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Warehouse/WarehouseSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            itemName = s.Split('`')[0];
            bigItemType = s.Split('`')[1];
            smallItemType = s.Split('`')[2];
            long.TryParse(s.Split('`')[3], out price);
            itemExplain = s.Split('`')[4];
            int.TryParse(s.Split('`')[5], out quantity);
            long.TryParse(s.Split('`')[6], out maxAddHP);
            long.TryParse(s.Split('`')[7], out maxAddMP);
            long.TryParse(s.Split('`')[8], out maxAddMaxMP);
            long.TryParse(s.Split('`')[9], out maxAddMaxHP);
            long.TryParse(s.Split('`')[10], out maxAddSTR);
            long.TryParse(s.Split('`')[11], out maxAddHEL);
            long.TryParse(s.Split('`')[12], out maxAddINT);
            long.TryParse(s.Split('`')[13], out maxAddLUK);
            long.TryParse(s.Split('`')[14], out maxAddPower);
            long.TryParse(s.Split('`')[15], out maxAddMagicPower);
            long.TryParse(s.Split('`')[16], out maxAddDefence);
            float.TryParse(s.Split('`')[17], out coolTime);
            float.TryParse(s.Split('`')[18], out stayTime);
            long.TryParse(s.Split('`')[19], out addMaxHP);
            long.TryParse(s.Split('`')[20], out addMaxMP);
            long.TryParse(s.Split('`')[21], out addSTR);
            long.TryParse(s.Split('`')[22], out addHEL);
            long.TryParse(s.Split('`')[23], out addINT);
            long.TryParse(s.Split('`')[24], out addLUK);
            long.TryParse(s.Split('`')[25], out addPower);
            long.TryParse(s.Split('`')[26], out addMagicPower);
            long.TryParse(s.Split('`')[27], out addDefence);
            long.TryParse(s.Split('`')[28], out requireLevel);
            long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
            long.TryParse(s.Split('`')[30], out requireSTR);
            long.TryParse(s.Split('`')[31], out requireHEL);
            long.TryParse(s.Split('`')[32], out requireINT);
            long.TryParse(s.Split('`')[33], out requireLUK);
            int.TryParse(s.Split('`')[34], out enhanceLevel);
            int.TryParse(s.Split('`')[35], out enhanceStack);
            bool.TryParse(s.Split('`')[36], out sharePosiible);
            streamReader.Close();
        }
        // PC일떄 경로 
        else
        {
            streamReader = new StreamReader(new FileStream("Assets/Resources/Load/WarehouseSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            itemName = s.Split('`')[0];
            bigItemType = s.Split('`')[1];
            smallItemType = s.Split('`')[2];
            long.TryParse(s.Split('`')[3], out price);
            itemExplain = s.Split('`')[4];
            int.TryParse(s.Split('`')[5], out quantity);
            long.TryParse(s.Split('`')[6], out maxAddHP);
            long.TryParse(s.Split('`')[7], out maxAddMP);
            long.TryParse(s.Split('`')[8], out maxAddMaxMP);
            long.TryParse(s.Split('`')[9], out maxAddMaxHP);
            long.TryParse(s.Split('`')[10], out maxAddSTR);
            long.TryParse(s.Split('`')[11], out maxAddHEL);
            long.TryParse(s.Split('`')[12], out maxAddINT);
            long.TryParse(s.Split('`')[13], out maxAddLUK);
            long.TryParse(s.Split('`')[14], out maxAddPower);
            long.TryParse(s.Split('`')[15], out maxAddMagicPower);
            long.TryParse(s.Split('`')[16], out maxAddDefence);
            float.TryParse(s.Split('`')[17], out coolTime);
            float.TryParse(s.Split('`')[18], out stayTime);
            long.TryParse(s.Split('`')[19], out addMaxHP);
            long.TryParse(s.Split('`')[20], out addMaxMP);
            long.TryParse(s.Split('`')[21], out addSTR);
            long.TryParse(s.Split('`')[22], out addHEL);
            long.TryParse(s.Split('`')[23], out addINT);
            long.TryParse(s.Split('`')[24], out addLUK);
            long.TryParse(s.Split('`')[25], out addPower);
            long.TryParse(s.Split('`')[26], out addMagicPower);
            long.TryParse(s.Split('`')[27], out addDefence);
            long.TryParse(s.Split('`')[28], out requireLevel);
            long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
            long.TryParse(s.Split('`')[30], out requireSTR);
            long.TryParse(s.Split('`')[31], out requireHEL);
            long.TryParse(s.Split('`')[32], out requireINT);
            long.TryParse(s.Split('`')[33], out requireLUK);
            int.TryParse(s.Split('`')[34], out enhanceLevel);
            int.TryParse(s.Split('`')[35], out enhanceStack);
            bool.TryParse(s.Split('`')[36], out sharePosiible);
            streamReader.Close();

        }

    }

}
