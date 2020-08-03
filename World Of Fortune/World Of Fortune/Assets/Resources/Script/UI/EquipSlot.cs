using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class EquipSlot : MonoBehaviour
{

    StreamWriter streamWriter;
    StreamReader streamReader;
    string s;


    public string itemName;
    public string bigItemType;
    public string smallItemType;
    public long price;
    public string itemExplain;
    public int quantity;
    public bool sharePosiible; // 계정공유 가능한지 가능 = true;

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

    public int slotNumber;
    public int enhanceLevel;  // 강화단계 장비템 보여줄때 if이거 0아니면 이름 + 강화레벨로 이름을 보여줌 
    public int enhanceStack;



    public Image itemImage;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = transform.Find("Image").gameObject.GetComponent<Image>();

    
    
    }




    //저장하면 호출 
    public void Save()
    {
        if (UIManager.instance.environment == "Mobile")
        {
            streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + CharacterManager.instance.characterNumber + "/" + this.transform.name + ".txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(itemName + "`");
            streamWriter.Write(bigItemType + "`");
            streamWriter.Write(smallItemType + "`");
            streamWriter.Write(price + "`");
            streamWriter.Write(itemExplain + "`");
            streamWriter.Write(quantity + "`");
            streamWriter.Write(sharePosiible + "`");
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
            streamWriter.Close();

        }
        else
        {

            streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + CharacterManager.instance.characterNumber + "/" + this.transform.name + ".txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(itemName + "`");
            streamWriter.Write(bigItemType + "`");
            streamWriter.Write(smallItemType + "`");
            streamWriter.Write(price + "`");
            streamWriter.Write(itemExplain + "`");
            streamWriter.Write(quantity + "`");
            streamWriter.Write(sharePosiible + "`");
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
            streamWriter.Close();
        }
    }



    // 오브젝트 이름을 보고 
    // 파일에서 슬롯 정보를 불러옴
    // 이미지 변경 
    public void GameStart(int selectSlot)
    {
        if(UIManager.instance.environment == "Mobile")
        {

            streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/" + this.transform.name + ".txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            itemName = s.Split('`')[0];
            bigItemType = s.Split('`')[1];
            smallItemType = s.Split('`')[2];
            long.TryParse(s.Split('`')[3], out price);
            itemExplain = s.Split('`')[4];
            int.TryParse(s.Split('`')[5], out quantity);
            bool.TryParse(s.Split('`')[6], out sharePosiible);
            long.TryParse(s.Split('`')[7], out addMaxHP);
            long.TryParse(s.Split('`')[8], out addMaxMP);
            long.TryParse(s.Split('`')[9], out addSTR);
            long.TryParse(s.Split('`')[10], out addHEL);
            long.TryParse(s.Split('`')[11], out addINT);
            long.TryParse(s.Split('`')[12], out addLUK);
            long.TryParse(s.Split('`')[13], out addPower);
            long.TryParse(s.Split('`')[14], out addMagicPower);
            long.TryParse(s.Split('`')[15], out addDefence);
            long.TryParse(s.Split('`')[16], out requireLevel);
            long.TryParse(s.Split('`')[17], out requireAccumulateLevel);
            long.TryParse(s.Split('`')[18], out requireSTR);
            long.TryParse(s.Split('`')[19], out requireHEL);
            long.TryParse(s.Split('`')[20], out requireINT);
            long.TryParse(s.Split('`')[21], out requireLUK);
            int.TryParse(s.Split('`')[22], out enhanceLevel);
            int.TryParse(s.Split('`')[23], out enhanceStack);
            streamReader.Close();

        }
        else
        {

            streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/" + this.transform.name + ".txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            itemName = s.Split('`')[0];
            bigItemType = s.Split('`')[1];
            smallItemType = s.Split('`')[2];
            long.TryParse(s.Split('`')[3], out price);
            itemExplain = s.Split('`')[4];
            int.TryParse(s.Split('`')[5], out quantity);
            bool.TryParse(s.Split('`')[6], out sharePosiible);
            long.TryParse(s.Split('`')[7], out addMaxHP);
            long.TryParse(s.Split('`')[8], out addMaxMP);
            long.TryParse(s.Split('`')[9], out addSTR);
            long.TryParse(s.Split('`')[10], out addHEL);
            long.TryParse(s.Split('`')[11], out addINT);
            long.TryParse(s.Split('`')[12], out addLUK);
            long.TryParse(s.Split('`')[13], out addPower);
            long.TryParse(s.Split('`')[14], out addMagicPower);
            long.TryParse(s.Split('`')[15], out addDefence);
            long.TryParse(s.Split('`')[16], out requireLevel);
            long.TryParse(s.Split('`')[17], out requireAccumulateLevel);
            long.TryParse(s.Split('`')[18], out requireSTR);
            long.TryParse(s.Split('`')[19], out requireHEL);
            long.TryParse(s.Split('`')[20], out requireINT);
            long.TryParse(s.Split('`')[21], out requireLUK);
            int.TryParse(s.Split('`')[22], out enhanceLevel);
            int.TryParse(s.Split('`')[23], out enhanceStack);
            streamReader.Close();
        }
        Refresh();
}


    //아이템 슬롯에 getItem 
    //옵션조정   
    //장비슬롯 null로 만듬
    // 장비슬롯 이미지 변환
    // 캐릭터 그 부위 isEquip false   
    public int Enequip()
    {
            if (UIManager.instance.itemTemp.GetItem(1) == 1)
            {
                SoundManager.instance.SoundEffectOn("EquipSound", SoundManager.instance.soundEffectNumber);
                CharacterManager.instance.addMaxHP -= addMaxHP;
                CharacterManager.instance.addMaxMP -= addMaxMP;
                CharacterManager.instance.addSTR -= addSTR;
                CharacterManager.instance.addHEL -= addHEL;
                CharacterManager.instance.addINT -= addINT;
                CharacterManager.instance.addLUK -= addLUK;
                CharacterManager.instance.addPower -= addPower;
                CharacterManager.instance.addMagicPower -= addMagicPower;
                CharacterManager.instance.addDefence -= addDefence;
                itemName = "null";
                bigItemType = "null";
                smallItemType = "null";
                price = 0;
                quantity = 0;
                itemExplain = "null";
                sharePosiible = false;
                addMaxHP = 0;
                addMaxMP = 0;
                addSTR = 0;
                addHEL = 0;
                addINT = 0;
                addLUK = 0;
                addPower = 0;
                addMagicPower = 0;
                addDefence = 0;
                requireAccumulateLevel = 0;
                requireLevel = 0;
                requireSTR = 0;
                requireHEL = 0;
                requireINT = 0;
                requireLUK = 0;
                enhanceLevel = 0;
                enhanceStack = 0;
                UIManager.instance.itemTemp.itemName = "null";
                Refresh();
                UIManager.instance.statWindow.Refresh();
                SlotButtonClick();
                //스텟 초기화 
                return 1;
            }
            else
            {
                StartCoroutine(UIManager.instance.equipWindow.EnequipFailText());
                return 0;
            }

    }

    public void Refresh()
    {
        if (itemName != "null")
        {
            if (itemName.Substring(0, 1).Equals("+"))
            {
                itemImage.sprite = Resources.Load("Sprite/Item/" + bigItemType + "/" + itemName.Substring(3), typeof(Sprite)) as Sprite;
                itemImage.color = new Color(1, 1, 1, 1);
            }
            else
            {
                itemImage.sprite = Resources.Load("Sprite/Item/" + bigItemType + "/" + itemName, typeof(Sprite)) as Sprite;
                itemImage.color = new Color(1, 1, 1, 1);
            }
        }
        else
        {
            itemImage.sprite = null;
            itemImage.color = new Color(1, 1, 1, 0);
        }

    }

    public void SlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("EquipSound", SoundManager.instance.soundEffectNumber);
        if (itemName != "null")
        {
            UIManager.instance.itemTemp.slotNumber = 0;
            UIManager.instance.itemTemp.itemName = itemName;
            UIManager.instance.itemTemp.bigItemType = bigItemType;
            UIManager.instance.itemTemp.smallItemType = smallItemType;
            UIManager.instance.itemTemp.price = price;
            UIManager.instance.itemTemp.itemExplain = itemExplain;
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
            UIManager.instance.itemTemp.requireLevel = requireAccumulateLevel;
            UIManager.instance.itemTemp.sharePosiible = sharePosiible;
            UIManager.instance.itemTemp.requireSTR = requireSTR;
            UIManager.instance.itemTemp.requireHEL = requireHEL;
            UIManager.instance.itemTemp.requireINT = requireINT;
            UIManager.instance.itemTemp.requireLUK = requireLUK;
            UIManager.instance.itemTemp.enhanceLevel = enhanceLevel;
            UIManager.instance.itemTemp.enhanceStack = enhanceStack;
            UIManager.instance.equip_SelectItemExplainText.text = itemName + "\n" + smallItemType + "\n가격 : " + price +
                "\n공격력 : + " + addPower + " 마력 : + " + addMagicPower + "\n방어력 : + " + addDefence + "최대체력 : + " + addMaxHP + " 최대마나 : + " + addMaxMP + "\n힘 : + " + addSTR + " 건강 : + " + addHEL + "\n지능 : + "
                + addINT + " 운 : + " + addLUK + "\n" + "착용 요구치 \n레벨 :  " + requireLevel + " 누적레벨 :  " + requireAccumulateLevel + "\nSTR : "
                + requireSTR + " HEL : " + requireHEL + "\nINT : " + requireINT + " LUK : " + requireLUK + "\n강화의 비약 : " + enhanceStack + " 중첩";

        }
        else
        {
            UIManager.instance.equip_SelectItemExplainText.text = "장비를 장착하고 있지 않습니다.";


        }
    }
}
/*UIManager.instance.equip_SelectItemExplainText.text = "이름 : " + itemName + "\n종류 : " + smallItemType + "\n가격 : " + price + "\n설명 : " + itemExplain +
            "\n+" + addMaxHP + "maxHP" + "\n+" + addMaxMP + "maxMP\n+" + addSTR + "SRT\n+" + addHEL + "HEL\n+" + addINT + "INT\n+" + addLUK + "Luk\n" + "착용 요구치 \n레벨 :  " + requireLevel 
            + " 누적레벨 :  " + requireAccumulateLevel + "\n STR : " +  requireSTR + " HEL : "  + requireHEL + "\n INT : " + requireINT + " LUK : " + requireLUK;*/