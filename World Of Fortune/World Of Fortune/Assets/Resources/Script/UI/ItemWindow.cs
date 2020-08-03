using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWindow : MonoBehaviour
{
    // 아이템창에서 버튼을 눌렀을때 발생하는 이벤트를 담고있는 스크립트 

    public int sellItemQuantity;
    public int InputItemQuantity;
    public long rand;


    // 장비창 버튼 눌렀을때 발생, 장비슬롯만 SetActive시키고 다른 슬롯은 안보이게 한다, 그리고 버튼누른 버튼만 색이 변한다 
    public void EquipSlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.showSlot == 0)
        {
            return;
        }
        else if(UIManager.instance.showSlot == 1)
        {

            UIManager.instance.item_EquipSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_EquipSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_ConsumeSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_ConsumeSlotButton.image.color = new Color(128f/255f, 122f/255f, 122f/255f);
            UIManager.instance.showSlot = 0;

        }
        else if(UIManager.instance.showSlot == 2)
        {
            UIManager.instance.item_EquipSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_EquipSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_EtcSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_EtcSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 0;
        }
        else if(UIManager.instance.showSlot == 3)
        {
            UIManager.instance.item_EquipSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_EquipSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_CashSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_CashSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 0;
        }
    }

    // 소비창 버튼 눌렀을때 발생, 장비슬롯만 SetActive시키고 다른 슬롯은 안보이게 한다, 그리고 버튼누른 버튼만 색이 변한다 
    public void ConsumeSlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.showSlot == 0)
        {
            UIManager.instance.item_ConsumeSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_ConsumeSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_EquipSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_EquipSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 1;

        }
        else if (UIManager.instance.showSlot == 1)
        {
            return;
        }
        else if (UIManager.instance.showSlot == 2)
        {
            UIManager.instance.item_ConsumeSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_ConsumeSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_EtcSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_EtcSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 1;
        }
        else if (UIManager.instance.showSlot == 3)
        {
            UIManager.instance.item_ConsumeSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_ConsumeSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_CashSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_CashSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 1;
        }
    }

    // 기타창 버튼 눌렀을때 발생, 장비슬롯만 SetActive시키고 다른 슬롯은 안보이게 한다, 그리고 버튼누른 버튼만 색이 변한다 
    public void EtcSlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.showSlot == 0)
        {
            UIManager.instance.item_EtcSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_EtcSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_EquipSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_EquipSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 2;

        }
        else if (UIManager.instance.showSlot == 1)
        {
            UIManager.instance.item_EtcSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_EtcSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_ConsumeSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_ConsumeSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 2;
        }
        else if (UIManager.instance.showSlot == 2)
        {
            return;

        }
        else if (UIManager.instance.showSlot == 3)
        {
            UIManager.instance.item_EtcSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_EtcSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_CashSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_CashSlotButton.image.color = new Color(128f / 255f, 122f/ 255f, 122f / 255f);
            UIManager.instance.showSlot = 2;
        }
    }

    // 캐쉬창 버튼 눌렀을때 발생, 장비슬롯만 SetActive시키고 다른 슬롯은 안보이게 한다, 그리고 버튼누른 버튼만 색이 변한다 
    public void CashSlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.showSlot == 0)
        {
            UIManager.instance.item_CashSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_CashSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_EquipSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_EquipSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 3;

        }
        else if (UIManager.instance.showSlot == 1)
        {
            UIManager.instance.item_CashSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_CashSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_ConsumeSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_ConsumeSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 3;
        }
        else if (UIManager.instance.showSlot == 2)
        {
            UIManager.instance.item_CashSlotPanel.gameObject.SetActive(true);
            UIManager.instance.item_CashSlotButton.image.color = new Color(1, 1, 1);
            UIManager.instance.item_EtcSlotPanel.gameObject.SetActive(false);
            UIManager.instance.item_EtcSlotButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSlot = 3;
        }
        else if (UIManager.instance.showSlot == 3)
        {
            return;
        }
    }


    // 사용 버튼 클릭하면 선택된 아이템을 사용한다 
    public void UseButtonClick()
    {
        if(UIManager.instance.itemTemp.bigItemType == "Consume")
        {
                UIManager.instance.item_ConsumeSlot[UIManager.instance.itemTemp.slotNumber].Use();
        }
        else
        {
            StartCoroutine(UseButtonFailText());
        }
    }

    // 장착 버튼을 클릭하면 만약 장착 아이템이면 장착을 진행한다 
    public void EquipButtonClick()
    {
        if(UIManager.instance.itemTemp.itemName == "null")
        {
            return;
        }
        // 먼저 장비 아이템인지 먼저 확인한다 
        if (UIManager.instance.itemTemp.bigItemType == "Equipment")
        {
            // 그 다음에 장착 요건을 만족하는지 확인한다 
            if (UIManager.instance.itemTemp.requireLevel <= CharacterManager.instance.Level && UIManager.instance.itemTemp.requireSTR <= CharacterManager.instance.STR &&
                UIManager.instance.itemTemp.requireHEL <= CharacterManager.instance.HEL && UIManager.instance.itemTemp.requireINT <= CharacterManager.instance.INT &&
                UIManager.instance.itemTemp.requireLUK <= CharacterManager.instance.LUK && UIManager.instance.itemTemp.requireAccumulateLevel <= CharacterManager.instance.accumulateLevel)
            {
                SoundManager.instance.SoundEffectOn("EquipSound", SoundManager.instance.soundEffectNumber);
                switch (UIManager.instance.itemTemp.smallItemType)
                {

                    case "Weapon":
                        if (CharacterManager.instance.isEquipWeapon) // 장착중
                        {
                            // 장착하고 있던 아이템 정보를 useITemTemp에 저장 
                            UIManager.instance.useItemTemp.itemName = UIManager.instance.equip_WeaponSlot.itemName;
                            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.equip_WeaponSlot.bigItemType;
                            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.equip_WeaponSlot.smallItemType;
                            UIManager.instance.useItemTemp.price = UIManager.instance.equip_WeaponSlot.price;
                            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.equip_WeaponSlot.itemExplain;
                            UIManager.instance.useItemTemp.quantity = UIManager.instance.equip_WeaponSlot.quantity;
                            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.equip_WeaponSlot.sharePosiible;
                            UIManager.instance.useItemTemp.addMaxHP = UIManager.instance.equip_WeaponSlot.addMaxHP;
                            UIManager.instance.useItemTemp.addMaxMP = UIManager.instance.equip_WeaponSlot.addMaxMP;
                            UIManager.instance.useItemTemp.addSTR = UIManager.instance.equip_WeaponSlot.addSTR;
                            UIManager.instance.useItemTemp.addHEL = UIManager.instance.equip_WeaponSlot.addHEL;
                            UIManager.instance.useItemTemp.addINT = UIManager.instance.equip_WeaponSlot.addINT;
                            UIManager.instance.useItemTemp.addLUK = UIManager.instance.equip_WeaponSlot.addLUK;
                            UIManager.instance.useItemTemp.addPower = UIManager.instance.equip_WeaponSlot.addPower;
                            UIManager.instance.useItemTemp.addMagicPower = UIManager.instance.equip_WeaponSlot.addMagicPower;
                            UIManager.instance.useItemTemp.addDefence = UIManager.instance.equip_WeaponSlot.addDefence;
                            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.equip_WeaponSlot.requireAccumulateLevel;
                            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.equip_WeaponSlot.requireLevel;
                            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.equip_WeaponSlot.requireSTR;
                            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.equip_WeaponSlot.requireHEL;
                            UIManager.instance.useItemTemp.requireINT = UIManager.instance.equip_WeaponSlot.requireINT;
                            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.equip_WeaponSlot.requireLUK;
                            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.equip_WeaponSlot.enhanceLevel;
                            UIManager.instance.useItemTemp.enhanceStack = UIManager.instance.equip_WeaponSlot.enhanceStack;
                            //장착하고 있던 아이템 능력치를 없앰 
                            CharacterManager.instance.addMaxHP -= UIManager.instance.equip_WeaponSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP -= UIManager.instance.equip_WeaponSlot.addMaxMP;
                            CharacterManager.instance.addSTR -= UIManager.instance.equip_WeaponSlot.addSTR;
                            CharacterManager.instance.addHEL -= UIManager.instance.equip_WeaponSlot.addHEL;
                            CharacterManager.instance.addINT -= UIManager.instance.equip_WeaponSlot.addINT;
                            CharacterManager.instance.addLUK -= UIManager.instance.equip_WeaponSlot.addLUK;
                            CharacterManager.instance.addPower -= UIManager.instance.equip_WeaponSlot.addPower;
                            CharacterManager.instance.addMagicPower -= UIManager.instance.equip_WeaponSlot.addMagicPower;
                            CharacterManager.instance.addDefence -= UIManager.instance.equip_WeaponSlot.addDefence;
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_WeaponSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_WeaponSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_WeaponSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_WeaponSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_WeaponSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_WeaponSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_WeaponSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_WeaponSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_WeaponSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_WeaponSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_WeaponSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_WeaponSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_WeaponSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_WeaponSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_WeaponSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_WeaponSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_WeaponSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_WeaponSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_WeaponSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_WeaponSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_WeaponSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_WeaponSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_WeaponSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_WeaponSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_WeaponSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_WeaponSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_WeaponSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_WeaponSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_WeaponSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_WeaponSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_WeaponSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_WeaponSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_WeaponSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_WeaponSlot.addDefence;
                            UIManager.instance.equip_WeaponSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            //장착한 아이템 loseItem시켜줌 
                            UIManager.instance.itemTemp.LoseItem(1);
                            //ItemTemp에 장착중이던 아이템 넣고 getItem()
                            UIManager.instance.useItemTemp.GetItem(1);
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                        else
                        {

                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_WeaponSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_WeaponSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_WeaponSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_WeaponSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_WeaponSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_WeaponSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_WeaponSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_WeaponSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_WeaponSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_WeaponSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_WeaponSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_WeaponSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_WeaponSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_WeaponSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_WeaponSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_WeaponSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_WeaponSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_WeaponSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_WeaponSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_WeaponSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_WeaponSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_WeaponSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_WeaponSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_WeaponSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_WeaponSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_WeaponSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_WeaponSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_WeaponSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_WeaponSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_WeaponSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_WeaponSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_WeaponSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_WeaponSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_WeaponSlot.addDefence;
                            UIManager.instance.itemTemp.LoseItem(1);
                            UIManager.instance.equip_WeaponSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            // 장착상태로 변환 
                            CharacterManager.instance.isEquipWeapon = true;
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                    case "Armor":
                        if (CharacterManager.instance.isEquipArmor) // 장착중
                        {
                            // 장착하고 있던 아이템 정보를 useITemTemp에 저장 
                            UIManager.instance.useItemTemp.itemName = UIManager.instance.equip_ArmorSlot.itemName;
                            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.equip_ArmorSlot.bigItemType;
                            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.equip_ArmorSlot.smallItemType;
                            UIManager.instance.useItemTemp.price = UIManager.instance.equip_ArmorSlot.price;
                            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.equip_ArmorSlot.itemExplain;
                            UIManager.instance.useItemTemp.quantity = UIManager.instance.equip_ArmorSlot.quantity;
                            UIManager.instance.useItemTemp.addMaxHP = UIManager.instance.equip_ArmorSlot.addMaxHP;
                            UIManager.instance.useItemTemp.addMaxMP = UIManager.instance.equip_ArmorSlot.addMaxMP;
                            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.equip_ArmorSlot.sharePosiible;
                            UIManager.instance.useItemTemp.addSTR = UIManager.instance.equip_ArmorSlot.addSTR;
                            UIManager.instance.useItemTemp.addHEL = UIManager.instance.equip_ArmorSlot.addHEL;
                            UIManager.instance.useItemTemp.addINT = UIManager.instance.equip_ArmorSlot.addINT;
                            UIManager.instance.useItemTemp.addLUK = UIManager.instance.equip_ArmorSlot.addLUK;
                            UIManager.instance.useItemTemp.addPower = UIManager.instance.equip_ArmorSlot.addPower;
                            UIManager.instance.useItemTemp.addMagicPower = UIManager.instance.equip_ArmorSlot.addMagicPower;
                            UIManager.instance.useItemTemp.addDefence = UIManager.instance.equip_ArmorSlot.addDefence;
                            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.equip_ArmorSlot.requireAccumulateLevel;
                            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.equip_ArmorSlot.requireLevel;
                            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.equip_ArmorSlot.requireSTR;
                            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.equip_ArmorSlot.requireHEL;
                            UIManager.instance.useItemTemp.requireINT = UIManager.instance.equip_ArmorSlot.requireINT;
                            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.equip_ArmorSlot.requireLUK;
                            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.equip_ArmorSlot.enhanceLevel;
                            UIManager.instance.useItemTemp.enhanceStack = UIManager.instance.equip_ArmorSlot.enhanceStack;
                            //장착하고 있던 아이템 능력치를 없앰 
                            CharacterManager.instance.addMaxHP -= UIManager.instance.equip_ArmorSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP -= UIManager.instance.equip_ArmorSlot.addMaxMP;
                            CharacterManager.instance.addSTR -= UIManager.instance.equip_ArmorSlot.addSTR;
                            CharacterManager.instance.addHEL -= UIManager.instance.equip_ArmorSlot.addHEL;
                            CharacterManager.instance.addINT -= UIManager.instance.equip_ArmorSlot.addINT;
                            CharacterManager.instance.addLUK -= UIManager.instance.equip_ArmorSlot.addLUK;
                            CharacterManager.instance.addPower -= UIManager.instance.equip_ArmorSlot.addPower;
                            CharacterManager.instance.addMagicPower -= UIManager.instance.equip_ArmorSlot.addMagicPower;
                            CharacterManager.instance.addDefence -= UIManager.instance.equip_ArmorSlot.addDefence;
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_ArmorSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_ArmorSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_ArmorSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_ArmorSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_ArmorSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_ArmorSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_ArmorSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_ArmorSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_ArmorSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_ArmorSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_ArmorSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_ArmorSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_ArmorSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_ArmorSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_ArmorSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_ArmorSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_ArmorSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_ArmorSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_ArmorSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_ArmorSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_ArmorSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_ArmorSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_ArmorSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_ArmorSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_ArmorSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_ArmorSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_ArmorSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_ArmorSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_ArmorSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_ArmorSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_ArmorSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_ArmorSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_ArmorSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_ArmorSlot.addDefence;
                            UIManager.instance.equip_ArmorSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            //장착한 아이템 loseItem시켜줌 
                            UIManager.instance.itemTemp.LoseItem(1);
                            //ItemTemp에 장착중이던 아이템 넣고 getItem()
                            UIManager.instance.useItemTemp.GetItem(1);
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                        else
                        {
 
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_ArmorSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_ArmorSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_ArmorSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_ArmorSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_ArmorSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_ArmorSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_ArmorSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_ArmorSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_ArmorSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_ArmorSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_ArmorSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_ArmorSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_ArmorSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_ArmorSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_ArmorSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_ArmorSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_ArmorSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_ArmorSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_ArmorSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_ArmorSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_ArmorSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_ArmorSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_ArmorSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_ArmorSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_ArmorSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack; 
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_ArmorSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_ArmorSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_ArmorSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_ArmorSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_ArmorSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_ArmorSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_ArmorSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_ArmorSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_ArmorSlot.addDefence;
                            UIManager.instance.itemTemp.LoseItem(1);
                            UIManager.instance.equip_ArmorSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            // 장착상태로 변환 
                            CharacterManager.instance.isEquipArmor = true;
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                    case "Shoes":
                        if (CharacterManager.instance.isEquipShoes) // 장착중
                        {
                            // 장착하고 있던 아이템 정보를 useITemTemp에 저장 
                            UIManager.instance.useItemTemp.itemName = UIManager.instance.equip_ShoesSlot.itemName;
                            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.equip_ShoesSlot.bigItemType;
                            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.equip_ShoesSlot.smallItemType;
                            UIManager.instance.useItemTemp.price = UIManager.instance.equip_ShoesSlot.price;
                            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.equip_ShoesSlot.sharePosiible;
                            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.equip_ShoesSlot.itemExplain;
                            UIManager.instance.useItemTemp.quantity = UIManager.instance.equip_ShoesSlot.quantity;
                            UIManager.instance.useItemTemp.addMaxHP = UIManager.instance.equip_ShoesSlot.addMaxHP;
                            UIManager.instance.useItemTemp.addMaxMP = UIManager.instance.equip_ShoesSlot.addMaxMP;
                            UIManager.instance.useItemTemp.addSTR = UIManager.instance.equip_ShoesSlot.addSTR;
                            UIManager.instance.useItemTemp.addHEL = UIManager.instance.equip_ShoesSlot.addHEL;
                            UIManager.instance.useItemTemp.addINT = UIManager.instance.equip_ShoesSlot.addINT;
                            UIManager.instance.useItemTemp.addLUK = UIManager.instance.equip_ShoesSlot.addLUK;
                            UIManager.instance.useItemTemp.addPower = UIManager.instance.equip_ShoesSlot.addPower;
                            UIManager.instance.useItemTemp.addMagicPower = UIManager.instance.equip_ShoesSlot.addMagicPower;
                            UIManager.instance.useItemTemp.addDefence = UIManager.instance.equip_ShoesSlot.addDefence;
                            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.equip_ShoesSlot.requireAccumulateLevel;
                            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.equip_ShoesSlot.requireLevel;
                            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.equip_ShoesSlot.requireSTR;
                            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.equip_ShoesSlot.requireHEL;
                            UIManager.instance.useItemTemp.requireINT = UIManager.instance.equip_ShoesSlot.requireINT;
                            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.equip_ShoesSlot.requireLUK;
                            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.equip_ShoesSlot.enhanceLevel;
                            UIManager.instance.useItemTemp.enhanceStack = UIManager.instance.equip_ShoesSlot.enhanceStack;
                            //장착하고 있던 아이템 능력치를 없앰 
                            CharacterManager.instance.addMaxHP -= UIManager.instance.equip_ShoesSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP -= UIManager.instance.equip_ShoesSlot.addMaxMP;
                            CharacterManager.instance.addSTR -= UIManager.instance.equip_ShoesSlot.addSTR;
                            CharacterManager.instance.addHEL -= UIManager.instance.equip_ShoesSlot.addHEL;
                            CharacterManager.instance.addINT -= UIManager.instance.equip_ShoesSlot.addINT;
                            CharacterManager.instance.addLUK -= UIManager.instance.equip_ShoesSlot.addLUK;
                            CharacterManager.instance.addPower -= UIManager.instance.equip_ShoesSlot.addPower;
                            CharacterManager.instance.addMagicPower -= UIManager.instance.equip_ShoesSlot.addMagicPower;
                            CharacterManager.instance.addDefence -= UIManager.instance.equip_ShoesSlot.addDefence;
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_ShoesSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_ShoesSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_ShoesSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_ShoesSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_ShoesSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_ShoesSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_ShoesSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_ShoesSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_ShoesSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_ShoesSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_ShoesSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_ShoesSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_ShoesSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_ShoesSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_ShoesSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_ShoesSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_ShoesSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_ShoesSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_ShoesSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_ShoesSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_ShoesSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_ShoesSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_ShoesSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_ShoesSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_ShoesSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_ShoesSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_ShoesSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_ShoesSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_ShoesSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_ShoesSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_ShoesSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_ShoesSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_ShoesSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_ShoesSlot.addDefence;
                            UIManager.instance.equip_ShoesSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            //장착한 아이템 loseItem시켜줌 
                            UIManager.instance.itemTemp.LoseItem(1);
                            //ItemTemp에 장착중이던 아이템 넣고 getItem()
                            UIManager.instance.useItemTemp.GetItem(1);
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                        else
                        {

                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_ShoesSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_ShoesSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_ShoesSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_ShoesSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_ShoesSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_ShoesSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_ShoesSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_ShoesSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_ShoesSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_ShoesSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_ShoesSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_ShoesSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_ShoesSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_ShoesSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_ShoesSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_ShoesSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_ShoesSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_ShoesSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_ShoesSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_ShoesSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_ShoesSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_ShoesSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_ShoesSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_ShoesSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_ShoesSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_ShoesSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_ShoesSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_ShoesSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_ShoesSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_ShoesSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_ShoesSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_ShoesSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_ShoesSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_ShoesSlot.addDefence;
                            UIManager.instance.itemTemp.LoseItem(1);
                            UIManager.instance.equip_ShoesSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            // 장착상태로 변환 
                            CharacterManager.instance.isEquipShoes = true;
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                    case "Helmet":
                        if (CharacterManager.instance.isEquipHelmet) // 장착중
                        {
                            // 장착하고 있던 아이템 정보를 useITemTemp에 저장 
                            UIManager.instance.useItemTemp.itemName = UIManager.instance.equip_HelmetSlot.itemName;
                            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.equip_HelmetSlot.bigItemType;
                            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.equip_HelmetSlot.smallItemType;
                            UIManager.instance.useItemTemp.price = UIManager.instance.equip_HelmetSlot.price;
                            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.equip_HelmetSlot.itemExplain;
                            UIManager.instance.useItemTemp.quantity = UIManager.instance.equip_HelmetSlot.quantity;
                            UIManager.instance.useItemTemp.addMaxHP = UIManager.instance.equip_HelmetSlot.addMaxHP;
                            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.equip_HelmetSlot.sharePosiible;
                            UIManager.instance.useItemTemp.addMaxMP = UIManager.instance.equip_HelmetSlot.addMaxMP;
                            UIManager.instance.useItemTemp.addSTR = UIManager.instance.equip_HelmetSlot.addSTR;
                            UIManager.instance.useItemTemp.addHEL = UIManager.instance.equip_HelmetSlot.addHEL;
                            UIManager.instance.useItemTemp.addINT = UIManager.instance.equip_HelmetSlot.addINT;
                            UIManager.instance.useItemTemp.addLUK = UIManager.instance.equip_HelmetSlot.addLUK;
                            UIManager.instance.useItemTemp.addPower = UIManager.instance.equip_HelmetSlot.addPower;
                            UIManager.instance.useItemTemp.addMagicPower = UIManager.instance.equip_HelmetSlot.addMagicPower;
                            UIManager.instance.useItemTemp.addDefence = UIManager.instance.equip_HelmetSlot.addDefence;
                            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.equip_HelmetSlot.requireAccumulateLevel;
                            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.equip_HelmetSlot.requireLevel;
                            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.equip_HelmetSlot.requireSTR;
                            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.equip_HelmetSlot.requireHEL;
                            UIManager.instance.useItemTemp.requireINT = UIManager.instance.equip_HelmetSlot.requireINT;
                            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.equip_HelmetSlot.requireLUK;
                            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.equip_HelmetSlot.enhanceLevel;
                            UIManager.instance.useItemTemp.enhanceStack = UIManager.instance.equip_HelmetSlot.enhanceStack;
                            //장착하고 있던 아이템 능력치를 없앰 
                            CharacterManager.instance.addMaxHP -= UIManager.instance.equip_HelmetSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP -= UIManager.instance.equip_HelmetSlot.addMaxMP;
                            CharacterManager.instance.addSTR -= UIManager.instance.equip_HelmetSlot.addSTR;
                            CharacterManager.instance.addHEL -= UIManager.instance.equip_HelmetSlot.addHEL;
                            CharacterManager.instance.addINT -= UIManager.instance.equip_HelmetSlot.addINT;
                            CharacterManager.instance.addLUK -= UIManager.instance.equip_HelmetSlot.addLUK;
                            CharacterManager.instance.addPower -= UIManager.instance.equip_HelmetSlot.addPower;
                            CharacterManager.instance.addMagicPower -= UIManager.instance.equip_HelmetSlot.addMagicPower;
                            CharacterManager.instance.addDefence -= UIManager.instance.equip_HelmetSlot.addDefence;
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_HelmetSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_HelmetSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_HelmetSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_HelmetSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_HelmetSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_HelmetSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_HelmetSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_HelmetSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_HelmetSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_HelmetSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_HelmetSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_HelmetSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_HelmetSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_HelmetSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_HelmetSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_HelmetSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_HelmetSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_HelmetSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_HelmetSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_HelmetSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_HelmetSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_HelmetSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_HelmetSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_HelmetSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_HelmetSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_HelmetSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_HelmetSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_HelmetSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_HelmetSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_HelmetSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_HelmetSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_HelmetSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_HelmetSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_HelmetSlot.addDefence;
                            UIManager.instance.equip_HelmetSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            //장착한 아이템 loseItem시켜줌 
                            UIManager.instance.itemTemp.LoseItem(1);
                            //ItemTemp에 장착중이던 아이템 넣고 getItem()
                            UIManager.instance.useItemTemp.GetItem(1);
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                        else
                        {

                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_HelmetSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_HelmetSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_HelmetSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_HelmetSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_HelmetSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_HelmetSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_HelmetSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_HelmetSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_HelmetSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_HelmetSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_HelmetSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_HelmetSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_HelmetSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_HelmetSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_HelmetSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_HelmetSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_HelmetSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_HelmetSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_HelmetSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_HelmetSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_HelmetSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_HelmetSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_HelmetSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_HelmetSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_HelmetSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_HelmetSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_HelmetSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_HelmetSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_HelmetSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_HelmetSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_HelmetSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_HelmetSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_HelmetSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_HelmetSlot.addDefence;
                            UIManager.instance.itemTemp.LoseItem(1);
                            UIManager.instance.equip_HelmetSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            // 장착상태로 변환 
                            CharacterManager.instance.isEquipHelmet = true;
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                    case "Earring":
                        if (CharacterManager.instance.isEquipEarring) // 장착중
                        {
                            // 장착하고 있던 아이템 정보를 useITemTemp에 저장 
                            UIManager.instance.useItemTemp.itemName = UIManager.instance.equip_EarringSlot.itemName;
                            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.equip_EarringSlot.bigItemType;
                            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.equip_EarringSlot.smallItemType;
                            UIManager.instance.useItemTemp.price = UIManager.instance.equip_EarringSlot.price;
                            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.equip_EarringSlot.itemExplain;
                            UIManager.instance.useItemTemp.quantity = UIManager.instance.equip_EarringSlot.quantity;
                            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.equip_EarringSlot.sharePosiible;
                            UIManager.instance.useItemTemp.addMaxHP = UIManager.instance.equip_EarringSlot.addMaxHP;
                            UIManager.instance.useItemTemp.addMaxMP = UIManager.instance.equip_EarringSlot.addMaxMP;
                            UIManager.instance.useItemTemp.addSTR = UIManager.instance.equip_EarringSlot.addSTR;
                            UIManager.instance.useItemTemp.addHEL = UIManager.instance.equip_EarringSlot.addHEL;
                            UIManager.instance.useItemTemp.addINT = UIManager.instance.equip_EarringSlot.addINT;
                            UIManager.instance.useItemTemp.addLUK = UIManager.instance.equip_EarringSlot.addLUK;
                            UIManager.instance.useItemTemp.addPower = UIManager.instance.equip_EarringSlot.addPower;
                            UIManager.instance.useItemTemp.addMagicPower = UIManager.instance.equip_EarringSlot.addMagicPower;
                            UIManager.instance.useItemTemp.addDefence = UIManager.instance.equip_EarringSlot.addDefence;
                            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.equip_EarringSlot.requireAccumulateLevel;
                            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.equip_EarringSlot.requireLevel;
                            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.equip_EarringSlot.requireSTR;
                            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.equip_EarringSlot.requireHEL;
                            UIManager.instance.useItemTemp.requireINT = UIManager.instance.equip_EarringSlot.requireINT;
                            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.equip_EarringSlot.requireLUK;
                            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.equip_EarringSlot.enhanceLevel;
                            UIManager.instance.useItemTemp.enhanceStack = UIManager.instance.equip_EarringSlot.enhanceStack;
                            //장착하고 있던 아이템 능력치를 없앰 
                            CharacterManager.instance.addMaxHP -= UIManager.instance.equip_EarringSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP -= UIManager.instance.equip_EarringSlot.addMaxMP;
                            CharacterManager.instance.addSTR -= UIManager.instance.equip_EarringSlot.addSTR;
                            CharacterManager.instance.addHEL -= UIManager.instance.equip_EarringSlot.addHEL;
                            CharacterManager.instance.addINT -= UIManager.instance.equip_EarringSlot.addINT;
                            CharacterManager.instance.addLUK -= UIManager.instance.equip_EarringSlot.addLUK;
                            CharacterManager.instance.addPower -= UIManager.instance.equip_EarringSlot.addPower;
                            CharacterManager.instance.addMagicPower -= UIManager.instance.equip_EarringSlot.addMagicPower;
                            CharacterManager.instance.addDefence -= UIManager.instance.equip_EarringSlot.addDefence;
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_EarringSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_EarringSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_EarringSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_EarringSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_EarringSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_EarringSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_EarringSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_EarringSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_EarringSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_EarringSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_EarringSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_EarringSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_EarringSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_EarringSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_EarringSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_EarringSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_EarringSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_EarringSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_EarringSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_EarringSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_EarringSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_EarringSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_EarringSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_EarringSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_EarringSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_EarringSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_EarringSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_EarringSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_EarringSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_EarringSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_EarringSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_EarringSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_EarringSlot.addDefence;
                            UIManager.instance.equip_EarringSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            //장착한 아이템 loseItem시켜줌 
                            UIManager.instance.itemTemp.LoseItem(1);
                            //ItemTemp에 장착중이던 아이템 넣고 getItem()
                            UIManager.instance.useItemTemp.GetItem(1);
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                        else
                        {

                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_EarringSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_EarringSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_EarringSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_EarringSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_EarringSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_EarringSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_EarringSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_EarringSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_EarringSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_EarringSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_EarringSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_EarringSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_EarringSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_EarringSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_EarringSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_EarringSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_EarringSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_EarringSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_EarringSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_EarringSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_EarringSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_EarringSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_EarringSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_EarringSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_EarringSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_EarringSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_EarringSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_EarringSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_EarringSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_EarringSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_EarringSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_EarringSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_EarringSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_EarringSlot.addDefence;
                            UIManager.instance.itemTemp.LoseItem(1);
                            UIManager.instance.equip_EarringSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            // 장착상태로 변환 
                            CharacterManager.instance.isEquipEarring = true;
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                    case "Shield":
                        if (CharacterManager.instance.isEquipShield) // 장착중
                        {
                            // 장착하고 있던 아이템 정보를 useITemTemp에 저장 
                            UIManager.instance.useItemTemp.itemName = UIManager.instance.equip_ShieldSlot.itemName;
                            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.equip_ShieldSlot.bigItemType;
                            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.equip_ShieldSlot.smallItemType;
                            UIManager.instance.useItemTemp.price = UIManager.instance.equip_ShieldSlot.price;
                            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.equip_ShieldSlot.itemExplain;
                            UIManager.instance.useItemTemp.quantity = UIManager.instance.equip_ShieldSlot.quantity;
                            UIManager.instance.useItemTemp.addMaxHP = UIManager.instance.equip_ShieldSlot.addMaxHP;
                            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.equip_ShieldSlot.sharePosiible;
                            UIManager.instance.useItemTemp.addMaxMP = UIManager.instance.equip_ShieldSlot.addMaxMP;
                            UIManager.instance.useItemTemp.addSTR = UIManager.instance.equip_ShieldSlot.addSTR;
                            UIManager.instance.useItemTemp.addHEL = UIManager.instance.equip_ShieldSlot.addHEL;
                            UIManager.instance.useItemTemp.addINT = UIManager.instance.equip_ShieldSlot.addINT;
                            UIManager.instance.useItemTemp.addLUK = UIManager.instance.equip_ShieldSlot.addLUK;
                            UIManager.instance.useItemTemp.addPower = UIManager.instance.equip_ShieldSlot.addPower;
                            UIManager.instance.useItemTemp.addMagicPower = UIManager.instance.equip_ShieldSlot.addMagicPower;
                            UIManager.instance.useItemTemp.addDefence = UIManager.instance.equip_ShieldSlot.addDefence;
                            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.equip_ShieldSlot.requireAccumulateLevel;
                            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.equip_ShieldSlot.requireLevel;
                            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.equip_ShieldSlot.requireSTR;
                            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.equip_ShieldSlot.requireHEL;
                            UIManager.instance.useItemTemp.requireINT = UIManager.instance.equip_ShieldSlot.requireINT;
                            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.equip_ShieldSlot.requireLUK;
                            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.equip_ShieldSlot.enhanceLevel;
                            UIManager.instance.useItemTemp.enhanceStack = UIManager.instance.equip_ShieldSlot.enhanceStack;
                            //장착하고 있던 아이템 능력치를 없앰 
                            CharacterManager.instance.addMaxHP -= UIManager.instance.equip_ShieldSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP -= UIManager.instance.equip_ShieldSlot.addMaxMP;
                            CharacterManager.instance.addSTR -= UIManager.instance.equip_ShieldSlot.addSTR;
                            CharacterManager.instance.addHEL -= UIManager.instance.equip_ShieldSlot.addHEL;
                            CharacterManager.instance.addINT -= UIManager.instance.equip_ShieldSlot.addINT;
                            CharacterManager.instance.addLUK -= UIManager.instance.equip_ShieldSlot.addLUK;
                            CharacterManager.instance.addPower -= UIManager.instance.equip_ShieldSlot.addPower;
                            CharacterManager.instance.addMagicPower -= UIManager.instance.equip_ShieldSlot.addMagicPower;
                            CharacterManager.instance.addDefence -= UIManager.instance.equip_ShieldSlot.addDefence;
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_ShieldSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_ShieldSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_ShieldSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_ShieldSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_ShieldSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_ShieldSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_ShieldSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_ShieldSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_ShieldSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_ShieldSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_ShieldSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_ShieldSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_ShieldSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_ShieldSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_ShieldSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_ShieldSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_ShieldSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_ShieldSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_ShieldSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_ShieldSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_ShieldSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_ShieldSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_ShieldSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_ShieldSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_ShieldSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_ShieldSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_ShieldSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_ShieldSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_ShieldSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_ShieldSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_ShieldSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_ShieldSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_ShieldSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_ShieldSlot.addDefence;
                            UIManager.instance.equip_ShieldSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            //장착한 아이템 loseItem시켜줌 
                            UIManager.instance.itemTemp.LoseItem(1);
                            //ItemTemp에 장착중이던 아이템 넣고 getItem()
                            UIManager.instance.useItemTemp.GetItem(1);
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                        else
                        {
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_ShieldSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_ShieldSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_ShieldSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_ShieldSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_ShieldSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_ShieldSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_ShieldSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_ShieldSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_ShieldSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_ShieldSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_ShieldSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_ShieldSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_ShieldSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_ShieldSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_ShieldSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_ShieldSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_ShieldSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_ShieldSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_ShieldSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_ShieldSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_ShieldSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_ShieldSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_ShieldSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_ShieldSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_ShieldSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_ShieldSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_ShieldSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_ShieldSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_ShieldSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_ShieldSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_ShieldSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_ShieldSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_ShieldSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_ShieldSlot.addDefence;
                            UIManager.instance.itemTemp.LoseItem(1);
                            UIManager.instance.equip_ShieldSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            // 장착상태로 변환 
                            CharacterManager.instance.isEquipShield = true;
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                    case "Ring":
                        if (CharacterManager.instance.isEquipRing) // 장착중
                        {
                            // 장착하고 있던 아이템 정보를 useITemTemp에 저장 
                            UIManager.instance.useItemTemp.itemName = UIManager.instance.equip_RingSlot.itemName;
                            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.equip_RingSlot.bigItemType;
                            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.equip_RingSlot.smallItemType;
                            UIManager.instance.useItemTemp.price = UIManager.instance.equip_RingSlot.price;
                            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.equip_RingSlot.itemExplain;
                            UIManager.instance.useItemTemp.quantity = UIManager.instance.equip_RingSlot.quantity;
                            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.equip_RingSlot.sharePosiible;
                            UIManager.instance.useItemTemp.addMaxHP = UIManager.instance.equip_RingSlot.addMaxHP;
                            UIManager.instance.useItemTemp.addMaxMP = UIManager.instance.equip_RingSlot.addMaxMP;
                            UIManager.instance.useItemTemp.addSTR = UIManager.instance.equip_RingSlot.addSTR;
                            UIManager.instance.useItemTemp.addHEL = UIManager.instance.equip_RingSlot.addHEL;
                            UIManager.instance.useItemTemp.addINT = UIManager.instance.equip_RingSlot.addINT;
                            UIManager.instance.useItemTemp.addLUK = UIManager.instance.equip_RingSlot.addLUK;
                            UIManager.instance.useItemTemp.addPower = UIManager.instance.equip_RingSlot.addPower;
                            UIManager.instance.useItemTemp.addMagicPower = UIManager.instance.equip_RingSlot.addMagicPower;
                            UIManager.instance.useItemTemp.addDefence = UIManager.instance.equip_RingSlot.addDefence;
                            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.equip_RingSlot.requireAccumulateLevel;
                            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.equip_RingSlot.requireLevel;
                            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.equip_RingSlot.requireSTR;
                            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.equip_RingSlot.requireHEL;
                            UIManager.instance.useItemTemp.requireINT = UIManager.instance.equip_RingSlot.requireINT;
                            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.equip_RingSlot.requireLUK;
                            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.equip_RingSlot.enhanceLevel;
                            UIManager.instance.useItemTemp.enhanceStack = UIManager.instance.equip_RingSlot.enhanceStack;
                            //장착하고 있던 아이템 능력치를 없앰 
                            CharacterManager.instance.addMaxHP -= UIManager.instance.equip_RingSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP -= UIManager.instance.equip_RingSlot.addMaxMP;
                            CharacterManager.instance.addSTR -= UIManager.instance.equip_RingSlot.addSTR;
                            CharacterManager.instance.addHEL -= UIManager.instance.equip_RingSlot.addHEL;
                            CharacterManager.instance.addINT -= UIManager.instance.equip_RingSlot.addINT;
                            CharacterManager.instance.addLUK -= UIManager.instance.equip_RingSlot.addLUK;
                            CharacterManager.instance.addPower -= UIManager.instance.equip_RingSlot.addPower;
                            CharacterManager.instance.addMagicPower -= UIManager.instance.equip_RingSlot.addMagicPower;
                            CharacterManager.instance.addDefence -= UIManager.instance.equip_RingSlot.addDefence;
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_RingSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_RingSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_RingSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_RingSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_RingSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_RingSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_RingSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_RingSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_RingSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_RingSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_RingSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_RingSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_RingSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_RingSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_RingSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_RingSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_RingSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_RingSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_RingSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_RingSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_RingSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_RingSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_RingSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_RingSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_RingSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_RingSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_RingSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_RingSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_RingSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_RingSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_RingSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_RingSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_RingSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_RingSlot.addDefence;
                            UIManager.instance.equip_RingSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            //장착한 아이템 loseItem시켜줌 
                            UIManager.instance.itemTemp.LoseItem(1);
                            //ItemTemp에 장착중이던 아이템 넣고 getItem()
                            UIManager.instance.useItemTemp.GetItem(1);
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                        else
                        {

                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_RingSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_RingSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_RingSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_RingSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_RingSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_RingSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_RingSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_RingSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_RingSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_RingSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_RingSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_RingSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_RingSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_RingSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_RingSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_RingSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_RingSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_RingSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_RingSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_RingSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_RingSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_RingSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_RingSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_RingSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_RingSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_RingSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_RingSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_RingSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_RingSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_RingSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_RingSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_RingSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_RingSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_RingSlot.addDefence;
                            UIManager.instance.itemTemp.LoseItem(1);
                            UIManager.instance.equip_RingSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            // 장착상태로 변환 
                            CharacterManager.instance.isEquipWeapon = true;
                            break;
                        }
                    case "Glove":
                        if (CharacterManager.instance.isEquipGlove) // 장착중
                        {
                            // 장착하고 있던 아이템 정보를 useITemTemp에 저장 
                            UIManager.instance.useItemTemp.itemName = UIManager.instance.equip_GloveSlot.itemName;
                            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.equip_GloveSlot.bigItemType;
                            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.equip_GloveSlot.smallItemType;
                            UIManager.instance.useItemTemp.price = UIManager.instance.equip_GloveSlot.price;
                            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.equip_GloveSlot.itemExplain;
                            UIManager.instance.useItemTemp.quantity = UIManager.instance.equip_GloveSlot.quantity;
                            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.equip_GloveSlot.sharePosiible;
                            UIManager.instance.useItemTemp.addMaxHP = UIManager.instance.equip_GloveSlot.addMaxHP;
                            UIManager.instance.useItemTemp.addMaxMP = UIManager.instance.equip_GloveSlot.addMaxMP;
                            UIManager.instance.useItemTemp.addSTR = UIManager.instance.equip_GloveSlot.addSTR;
                            UIManager.instance.useItemTemp.addHEL = UIManager.instance.equip_GloveSlot.addHEL;
                            UIManager.instance.useItemTemp.addINT = UIManager.instance.equip_GloveSlot.addINT;
                            UIManager.instance.useItemTemp.addLUK = UIManager.instance.equip_GloveSlot.addLUK;
                            UIManager.instance.useItemTemp.addPower = UIManager.instance.equip_GloveSlot.addPower;
                            UIManager.instance.useItemTemp.addMagicPower = UIManager.instance.equip_GloveSlot.addMagicPower;
                            UIManager.instance.useItemTemp.addDefence = UIManager.instance.equip_GloveSlot.addDefence;
                            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.equip_GloveSlot.requireAccumulateLevel;
                            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.equip_GloveSlot.requireLevel;
                            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.equip_GloveSlot.requireSTR;
                            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.equip_GloveSlot.requireHEL;
                            UIManager.instance.useItemTemp.requireINT = UIManager.instance.equip_GloveSlot.requireINT;
                            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.equip_GloveSlot.requireLUK;
                            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.equip_GloveSlot.enhanceLevel;
                            UIManager.instance.useItemTemp.enhanceStack = UIManager.instance.equip_GloveSlot.enhanceStack;
                            //장착하고 있던 아이템 능력치를 없앰 
                            CharacterManager.instance.addMaxHP -= UIManager.instance.equip_GloveSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP -= UIManager.instance.equip_GloveSlot.addMaxMP;
                            CharacterManager.instance.addSTR -= UIManager.instance.equip_GloveSlot.addSTR;
                            CharacterManager.instance.addHEL -= UIManager.instance.equip_GloveSlot.addHEL;
                            CharacterManager.instance.addINT -= UIManager.instance.equip_GloveSlot.addINT;
                            CharacterManager.instance.addLUK -= UIManager.instance.equip_GloveSlot.addLUK;
                            CharacterManager.instance.addPower -= UIManager.instance.equip_GloveSlot.addPower;
                            CharacterManager.instance.addMagicPower -= UIManager.instance.equip_GloveSlot.addMagicPower;
                            CharacterManager.instance.addDefence -= UIManager.instance.equip_GloveSlot.addDefence;
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_GloveSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_GloveSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_GloveSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_GloveSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_GloveSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_GloveSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_GloveSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_GloveSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_GloveSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_GloveSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_GloveSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_GloveSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_GloveSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_GloveSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_GloveSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_GloveSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_GloveSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_GloveSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_GloveSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_GloveSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_GloveSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_GloveSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_GloveSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_GloveSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_GloveSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_GloveSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_GloveSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_GloveSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_GloveSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_GloveSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_GloveSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_GloveSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_GloveSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_GloveSlot.addDefence;
                            UIManager.instance.equip_GloveSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            //장착한 아이템 loseItem시켜줌 
                            UIManager.instance.itemTemp.LoseItem(1);
                            //ItemTemp에 장착중이던 아이템 넣고 getItem()
                            UIManager.instance.useItemTemp.GetItem(1);
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                        else
                        {

                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_GloveSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_GloveSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_GloveSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_GloveSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_GloveSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_GloveSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_GloveSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_GloveSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_GloveSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_GloveSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_GloveSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_GloveSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_GloveSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_GloveSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_GloveSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_GloveSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_GloveSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_GloveSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_GloveSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_GloveSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_GloveSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_GloveSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_GloveSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_GloveSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_GloveSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_GloveSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_GloveSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_GloveSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_GloveSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_GloveSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_GloveSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_GloveSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_GloveSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_GloveSlot.addDefence;
                            UIManager.instance.itemTemp.LoseItem(1);
                            UIManager.instance.equip_GloveSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            // 장착상태로 변환 
                            CharacterManager.instance.isEquipGlove = true;
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                    case "Necklace":
                        if (CharacterManager.instance.isEquipNecklace) // 장착중
                        {
                            // 장착하고 있던 아이템 정보를 useITemTemp에 저장 
                            UIManager.instance.useItemTemp.itemName = UIManager.instance.equip_NecklaceSlot.itemName;
                            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.equip_NecklaceSlot.bigItemType;
                            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.equip_NecklaceSlot.smallItemType;
                            UIManager.instance.useItemTemp.price = UIManager.instance.equip_NecklaceSlot.price;
                            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.equip_NecklaceSlot.itemExplain;
                            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.equip_NecklaceSlot.sharePosiible;
                            UIManager.instance.useItemTemp.quantity = UIManager.instance.equip_NecklaceSlot.quantity;
                            UIManager.instance.useItemTemp.addMaxHP = UIManager.instance.equip_NecklaceSlot.addMaxHP;
                            UIManager.instance.useItemTemp.addMaxMP = UIManager.instance.equip_NecklaceSlot.addMaxMP;
                            UIManager.instance.useItemTemp.addSTR = UIManager.instance.equip_NecklaceSlot.addSTR;
                            UIManager.instance.useItemTemp.addHEL = UIManager.instance.equip_NecklaceSlot.addHEL;
                            UIManager.instance.useItemTemp.addINT = UIManager.instance.equip_NecklaceSlot.addINT;
                            UIManager.instance.useItemTemp.addLUK = UIManager.instance.equip_NecklaceSlot.addLUK;
                            UIManager.instance.useItemTemp.addPower = UIManager.instance.equip_NecklaceSlot.addPower;
                            UIManager.instance.useItemTemp.addMagicPower = UIManager.instance.equip_NecklaceSlot.addMagicPower;
                            UIManager.instance.useItemTemp.addDefence = UIManager.instance.equip_NecklaceSlot.addDefence;
                            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.equip_NecklaceSlot.requireAccumulateLevel;
                            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.equip_NecklaceSlot.requireLevel;
                            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.equip_NecklaceSlot.requireSTR;
                            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.equip_NecklaceSlot.requireHEL;
                            UIManager.instance.useItemTemp.requireINT = UIManager.instance.equip_NecklaceSlot.requireINT;
                            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.equip_NecklaceSlot.requireLUK;
                            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.equip_NecklaceSlot.enhanceLevel;
                            UIManager.instance.useItemTemp.enhanceStack = UIManager.instance.equip_NecklaceSlot.enhanceStack;
                            //장착하고 있던 아이템 능력치를 없앰 
                            CharacterManager.instance.addMaxHP -= UIManager.instance.equip_NecklaceSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP -= UIManager.instance.equip_NecklaceSlot.addMaxMP;
                            CharacterManager.instance.addSTR -= UIManager.instance.equip_NecklaceSlot.addSTR;
                            CharacterManager.instance.addHEL -= UIManager.instance.equip_NecklaceSlot.addHEL;
                            CharacterManager.instance.addINT -= UIManager.instance.equip_NecklaceSlot.addINT;
                            CharacterManager.instance.addLUK -= UIManager.instance.equip_NecklaceSlot.addLUK;
                            CharacterManager.instance.addPower -= UIManager.instance.equip_NecklaceSlot.addPower;
                            CharacterManager.instance.addMagicPower -= UIManager.instance.equip_NecklaceSlot.addMagicPower;
                            CharacterManager.instance.addDefence -= UIManager.instance.equip_NecklaceSlot.addDefence;
                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_NecklaceSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_NecklaceSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_NecklaceSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_NecklaceSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_NecklaceSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_NecklaceSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_NecklaceSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_NecklaceSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_NecklaceSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_NecklaceSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_NecklaceSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_NecklaceSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_NecklaceSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_NecklaceSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_NecklaceSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_NecklaceSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_NecklaceSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_NecklaceSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_NecklaceSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_NecklaceSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_NecklaceSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_NecklaceSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_NecklaceSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_NecklaceSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_NecklaceSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_NecklaceSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_NecklaceSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_NecklaceSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_NecklaceSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_NecklaceSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_NecklaceSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_NecklaceSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_NecklaceSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_NecklaceSlot.addDefence;
                            UIManager.instance.equip_NecklaceSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            //장착한 아이템 loseItem시켜줌 
                            UIManager.instance.itemTemp.LoseItem(1);
                            //ItemTemp에 장착중이던 아이템 넣고 getItem()
                            UIManager.instance.useItemTemp.GetItem(1);
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }
                        else
                        {

                            // 장착 아이템 슬롯에 장착할 아이템의 정보를 넣는다 
                            UIManager.instance.equip_NecklaceSlot.itemName = UIManager.instance.itemTemp.itemName;
                            UIManager.instance.equip_NecklaceSlot.bigItemType = UIManager.instance.itemTemp.bigItemType;
                            UIManager.instance.equip_NecklaceSlot.smallItemType = UIManager.instance.itemTemp.smallItemType;
                            UIManager.instance.equip_NecklaceSlot.price = UIManager.instance.itemTemp.price;
                            UIManager.instance.equip_NecklaceSlot.itemExplain = UIManager.instance.itemTemp.itemExplain;
                            UIManager.instance.equip_NecklaceSlot.quantity = UIManager.instance.itemTemp.quantity;
                            UIManager.instance.equip_NecklaceSlot.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                            UIManager.instance.equip_NecklaceSlot.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                            UIManager.instance.equip_NecklaceSlot.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                            UIManager.instance.equip_NecklaceSlot.addSTR = UIManager.instance.itemTemp.addSTR;
                            UIManager.instance.equip_NecklaceSlot.addHEL = UIManager.instance.itemTemp.addHEL;
                            UIManager.instance.equip_NecklaceSlot.addINT = UIManager.instance.itemTemp.addINT;
                            UIManager.instance.equip_NecklaceSlot.addLUK = UIManager.instance.itemTemp.addLUK;
                            UIManager.instance.equip_NecklaceSlot.addPower = UIManager.instance.itemTemp.addPower;
                            UIManager.instance.equip_NecklaceSlot.addMagicPower = UIManager.instance.itemTemp.addMagicPower;
                            UIManager.instance.equip_NecklaceSlot.addDefence = UIManager.instance.itemTemp.addDefence;
                            UIManager.instance.equip_NecklaceSlot.requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
                            UIManager.instance.equip_NecklaceSlot.requireLevel = UIManager.instance.itemTemp.requireLevel;
                            UIManager.instance.equip_NecklaceSlot.requireSTR = UIManager.instance.itemTemp.requireSTR;
                            UIManager.instance.equip_NecklaceSlot.requireHEL = UIManager.instance.itemTemp.requireHEL;
                            UIManager.instance.equip_NecklaceSlot.requireINT = UIManager.instance.itemTemp.requireINT;
                            UIManager.instance.equip_NecklaceSlot.requireLUK = UIManager.instance.itemTemp.requireLUK;
                            UIManager.instance.equip_NecklaceSlot.slotNumber = UIManager.instance.itemTemp.slotNumber;
                            UIManager.instance.equip_NecklaceSlot.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                            UIManager.instance.equip_NecklaceSlot.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                            // 장착할 아이템 옵션만큼 스텟을 추가해준다 
                            CharacterManager.instance.addMaxHP += UIManager.instance.equip_NecklaceSlot.addMaxHP;
                            CharacterManager.instance.addMaxMP += UIManager.instance.equip_NecklaceSlot.addMaxMP;
                            CharacterManager.instance.addSTR += UIManager.instance.equip_NecklaceSlot.addSTR;
                            CharacterManager.instance.addHEL += UIManager.instance.equip_NecklaceSlot.addHEL;
                            CharacterManager.instance.addINT += UIManager.instance.equip_NecklaceSlot.addINT;
                            CharacterManager.instance.addLUK += UIManager.instance.equip_NecklaceSlot.addLUK;
                            CharacterManager.instance.addPower += UIManager.instance.equip_NecklaceSlot.addPower;
                            CharacterManager.instance.addMagicPower += UIManager.instance.equip_NecklaceSlot.addMagicPower;
                            CharacterManager.instance.addDefence += UIManager.instance.equip_NecklaceSlot.addDefence;
                            UIManager.instance.itemTemp.LoseItem(1);
                            UIManager.instance.equip_NecklaceSlot.Refresh();
                            // + 스텟쪽 초기화 시켜줌 
                            // 장착상태로 변환 
                            CharacterManager.instance.isEquipNecklace = true;
                            UIManager.instance.statWindow.Refresh();
                            break;
                        }

                }
                //         체크할거 1. 요구 능력치를 충족하는지, 2.이미 장착중인 경우 3.loseitem, getItem되는지 
                // 



                //아이템슬롯 loseItem시킴
                //장비 소분류를 구분
                //장착 부위 슬롯 변수들 ItemTemp에 있는거 or 장비 아이템 번호껄로 바꿔줌 
                //캐릭터 add능력치 + 해줌
                //캐릭터 그 부위 isEquip true
                // 장비슬롯 이미지 변경 


            }
            else
            {

                StartCoroutine(EquipButtonFailText());
            }

        }
        else
        {

            StartCoroutine(EquipButtonFailText());
        }
    }

    // 퀵슬롯 버튼을 클릭하면 만약 소비 아이템이면 퀵슬롯 이벤트 패널을 SetActive(true)한다 
    public void QuickSlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.itemTemp.bigItemType == "Consume")
        {
            UIManager.instance.item_QuickSlotClickEvnetPanel.gameObject.SetActive(true);

        }else
        {

            StartCoroutine(QuickSlotButtonFailText());

        }
    }

    // 퀵슬롯 이벤트 패널에서 퀵슬롯 1 버튼을 누르면 퀵슬롯1에 아이템을 등록한다 
    public void QuickSlotSelectButtonClick1()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.itemTemp.itemName != "null" && UIManager.instance.itemTemp.bigItemType == "Consume") 
        {
            for (int i = 0; i < 5; i++)
            {
                if (UIManager.instance.itemTemp.itemName == UIManager.instance.quickSlot[i].itemName)
                {
                    UIManager.instance.quickSlot[i].itemName = "null";
                    UIManager.instance.quickSlot[i].itemSlotNumber = -1;
                    UIManager.instance.quickSlot[i].slotType = "null";
                    UIManager.instance.quickSlot[i].Refresh();
                }
            }
            UIManager.instance.quickSlot[0].itemName = UIManager.instance.itemTemp.itemName;
            UIManager.instance.quickSlot[0].itemSlotNumber = UIManager.instance.itemTemp.slotNumber;
            UIManager.instance.quickSlot[0].slotType = "Item";
            UIManager.instance.quickSlot[0].Refresh();
            UIManager.instance.item_QuickSlotClickEvnetPanel.gameObject.SetActive(false);
        }

    }

    // 퀵슬롯 이벤트 패널에서 퀵슬롯2 버튼을 누르면 퀵슬롯2에 아이템을 등록한다 
    public void QuickSlotSelectButtonClick2()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.itemTemp.itemName != "null" && UIManager.instance.itemTemp.bigItemType == "Consume")
        {
            for(int i = 0; i < 5; i++)
            {
                if(UIManager.instance.itemTemp.itemName == UIManager.instance.quickSlot[i].itemName)
                {
                    UIManager.instance.quickSlot[i].itemName = "null";
                    UIManager.instance.quickSlot[i].itemSlotNumber = -1;
                    UIManager.instance.quickSlot[i].slotType = "null";
                    UIManager.instance.quickSlot[i].Refresh();
                }
            }
            UIManager.instance.quickSlot[1].itemName = UIManager.instance.itemTemp.itemName;
            UIManager.instance.quickSlot[1].itemSlotNumber = UIManager.instance.itemTemp.slotNumber;
            UIManager.instance.quickSlot[1].slotType = "Item";
            UIManager.instance.quickSlot[1].Refresh();
            UIManager.instance.item_QuickSlotClickEvnetPanel.gameObject.SetActive(false);
        }

    }

    // 퀵슬롯 이벤트 패널에서 퀵슬롯3 버튼을 누르면 퀵슬롯3에 아이템을 등록한다 
    public void QuickSlotSelectButtonClick3()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.itemTemp.itemName != "null" && UIManager.instance.itemTemp.bigItemType == "Consume")
        {
                for (int i = 0; i < 5; i++)
                {
                    if (UIManager.instance.itemTemp.itemName == UIManager.instance.quickSlot[i].itemName)
                    {

                        UIManager.instance.quickSlot[i].itemName = "null";
                        UIManager.instance.quickSlot[i].itemSlotNumber = -1;
                        UIManager.instance.quickSlot[i].slotType = "null";
                        UIManager.instance.quickSlot[i].Refresh();

                    }
                }
            UIManager.instance.quickSlot[2].itemName = UIManager.instance.itemTemp.itemName;
            UIManager.instance.quickSlot[2].itemSlotNumber = UIManager.instance.itemTemp.slotNumber;
            UIManager.instance.quickSlot[2].slotType = "Item";
            UIManager.instance.quickSlot[2].Refresh();
            UIManager.instance.item_QuickSlotClickEvnetPanel.gameObject.SetActive(false);
        }

    }

    // 퀵슬롯 이벤트 패널에서 퀵슬롯4 버튼을 누르면 퀵슬롯4에 아이템을 등록한다 
    public void QuickSlotSelectButtonClick4()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.itemTemp.itemName != "null" && UIManager.instance.itemTemp.bigItemType == "Consume")
        {
            for (int i = 0; i < 5; i++)
            {
                if (UIManager.instance.itemTemp.itemName == UIManager.instance.quickSlot[i].itemName)
                {

                    UIManager.instance.quickSlot[i].itemName = "null";
                    UIManager.instance.quickSlot[i].itemSlotNumber = -1;
                    UIManager.instance.quickSlot[i].slotType = "null";
                    UIManager.instance.quickSlot[i].Refresh();

                }
            }
            UIManager.instance.quickSlot[3].itemName = UIManager.instance.itemTemp.itemName;
            UIManager.instance.quickSlot[3].itemSlotNumber = UIManager.instance.itemTemp.slotNumber;
            UIManager.instance.quickSlot[3].slotType = "Item";
            UIManager.instance.quickSlot[3].Refresh();
            UIManager.instance.item_QuickSlotClickEvnetPanel.gameObject.SetActive(false);
        }




    }
    // 퀵슬롯 이벤트 패널에서 퀵슬롯5 버튼을 누르면 퀵슬롯5에 아이템을 등록한다 
    public void QuickSlotSelectButtonClick5()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.itemTemp.itemName != "null" && UIManager.instance.itemTemp.bigItemType == "Consume")
        {
            for (int i = 0; i < 5; i++)
            {
                if (UIManager.instance.itemTemp.itemName == UIManager.instance.quickSlot[i].itemName)
                {

                    UIManager.instance.quickSlot[i].itemName = "null";
                    UIManager.instance.quickSlot[i].itemSlotNumber = -1;
                    UIManager.instance.quickSlot[i].slotType = "null";
                    UIManager.instance.quickSlot[i].Refresh();

                }
            }
            UIManager.instance.quickSlot[4].itemName = UIManager.instance.itemTemp.itemName;
            UIManager.instance.quickSlot[4].itemSlotNumber = UIManager.instance.itemTemp.slotNumber;
            UIManager.instance.quickSlot[4].slotType = "Item";
            UIManager.instance.quickSlot[4].Refresh();
            UIManager.instance.item_QuickSlotClickEvnetPanel.gameObject.SetActive(false);
        }


    }

    //퀵슬롯 닫기 버튼 누르면 퀵슬롯 이벤트창이 꺼진다 
    public void QuickSlotEventExitButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.item_QuickSlotClickEvnetPanel.gameObject.SetActive(false);
    }
    
    // 판매 버튼을 누르면 진짜 판매할건지, 몇개를 판매할건지 확인하는 창이 뜬다 
    public void SellButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.item_SellClickEventPanel.gameObject.SetActive(true);


    }

    public void SellEvnetExitButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);

        UIManager.instance.item_SellClickEventPanel.gameObject.SetActive(false);

    }

    //인풋필드에 숫자를 입력했다면 입력한 숫자만큼 판매를 시도하고 아니면 1개를 판매 시도한다 
    public void SellFinishButtonClick()
    {

        if(!int.TryParse(UIManager.instance.item_SellQuantityInputField.text, out sellItemQuantity))
        {
            sellItemQuantity = 1;
        } 


        if(UIManager.instance.itemTemp.bigItemType == "Equipment")
        {
           
            if (UIManager.instance.item_EquipSlot[UIManager.instance.itemTemp.slotNumber].quantity >= sellItemQuantity)
            {

                SoundManager.instance.SoundEffectOn("ShopSound", SoundManager.instance.soundEffectNumber);
                if (UIManager.instance.itemTemp.LoseItem(sellItemQuantity) == 1)
                {
                    for (int i = 0; i < sellItemQuantity; i++)
                    {

                        rand = (long)Random.Range(1, UIManager.instance.item_EquipSlot[UIManager.instance.itemTemp.slotNumber].price);
                        UIManager.instance.hasMoney += rand;
                    }
                    UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
                }
            }
            else
            {
                StartCoroutine(SellFailText());
            }
        }
        else if (UIManager.instance.itemTemp.bigItemType == "Consume")
        {

            if (UIManager.instance.item_ConsumeSlot[UIManager.instance.itemTemp.slotNumber].quantity >= sellItemQuantity)
            {
                SoundManager.instance.SoundEffectOn("ShopSound", SoundManager.instance.soundEffectNumber);
                if (UIManager.instance.itemTemp.LoseItem(sellItemQuantity) == 1)
                {
                    for (int i = 0; i < sellItemQuantity; i++)
                    {

                        rand = (long)Random.Range(1, UIManager.instance.item_ConsumeSlot[UIManager.instance.itemTemp.slotNumber].price);
                        UIManager.instance.hasMoney += rand;
                    }
                    UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
                }

            }
            else
            {
                StartCoroutine(SellFailText());
            }
        }
        else if(UIManager.instance.itemTemp.bigItemType == "Etc")
        {
            if (UIManager.instance.item_EtcSlot[UIManager.instance.itemTemp.slotNumber].quantity >= sellItemQuantity)
            {
                SoundManager.instance.SoundEffectOn("ShopSound", SoundManager.instance.soundEffectNumber);
                if (UIManager.instance.itemTemp.LoseItem(sellItemQuantity) == 1)
                {
                    for (int i = 0; i < sellItemQuantity; i++)
                    {

                        rand = (long)Random.Range(1, UIManager.instance.item_EtcSlot[UIManager.instance.itemTemp.slotNumber].price);
                        UIManager.instance.hasMoney += rand;
                    }
                    UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
                }

            }
            else
            {
                StartCoroutine(SellFailText());
            }
        }

        else if(UIManager.instance.itemTemp.bigItemType == "Cash")
        {
            if (UIManager.instance.item_CashSlot[UIManager.instance.itemTemp.slotNumber].quantity >= sellItemQuantity)
            {
                SoundManager.instance.SoundEffectOn("ShopSound", SoundManager.instance.soundEffectNumber);
                if (UIManager.instance.itemTemp.LoseItem(sellItemQuantity) == 1)
                {
                    for (int i = 0; i < sellItemQuantity; i++)
                    {

                        rand = (long)Random.Range(1, UIManager.instance.item_CashSlot[UIManager.instance.itemTemp.slotNumber].price);
                        UIManager.instance.hasMoney += rand;
                    }
                    UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
                }

            }
            else
            {
                StartCoroutine(SellFailText());
            }
        }
        else
        {
            StartCoroutine(SellFailText());
        }
        sellItemQuantity = 0;
    }

    // 창고 버튼을 클릭하면 창고 이벤트패널이 SetActive(ture)된다 
    public void WarehouseButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.item_WarehouseClickEventPanel.gameObject.SetActive(true);

    }

    // 닫기버튼을 누르면 창고 이벤트패널이 닫힌다 
    public void WarehouseEventExitButton()
    {

        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.item_WarehouseClickEventPanel.gameObject.SetActive(false);


    }

    // 창고 이벤트패널에서 넣기 버튼을 클릭하면 인풋필드에 값을 입력하면 그 입력한 갯수만큼 넣기를 시도하고 아니면 
    //창고 이벤트에서 넣기버튼을 눌렀을 떄 발생 이벤트 
    //인풋필드에 입력된 값을 체크한다 
    // 인풋필드에 입력된 값보다 아이템 슬롯에 있는 숫자가 많으면 다음으로 진행한다 
    //슬롯 아이템 정보를 warehouseITemTemp에 넣는다 
    // warehouseITemTemp에 인풋필드에 입력된 값만큼 getItem을 시킨다 
    // 성공하면 itemTemp를 인풋필드에 입력된 값만큼  loseITem을 시킨다 
    public void WarehouseInputButtonClick()
    {


        if (!int.TryParse(UIManager.instance.item_WarehouseQuantityInputField.text, out sellItemQuantity))
        {
            InputItemQuantity = 1;
        }


        if (UIManager.instance.itemTemp.sharePosiible == true)
        {
            if (UIManager.instance.itemTemp.bigItemType == "Equipment")
            {
                if (UIManager.instance.item_EquipSlot[UIManager.instance.itemTemp.slotNumber].quantity >= InputItemQuantity)
                {
                    UIManager.instance.warehouseItemTemp.itemName = UIManager.instance.itemTemp.itemName;
                    UIManager.instance.warehouseItemTemp.bigItemType = UIManager.instance.itemTemp.bigItemType;
                    UIManager.instance.warehouseItemTemp.smallItemType = UIManager.instance.itemTemp.smallItemType;
                    UIManager.instance.warehouseItemTemp.price = UIManager.instance.itemTemp.price;
                    UIManager.instance.warehouseItemTemp.itemExplain = UIManager.instance.itemTemp.itemExplain;
                    UIManager.instance.warehouseItemTemp.maxAddHP = UIManager.instance.itemTemp.maxAddHP;
                    UIManager.instance.warehouseItemTemp.maxAddMP = UIManager.instance.itemTemp.maxAddMP;
                    UIManager.instance.warehouseItemTemp.maxAddMaxMP = UIManager.instance.itemTemp.maxAddMaxMP;
                    UIManager.instance.warehouseItemTemp.maxAddMaxHP = UIManager.instance.itemTemp.maxAddMaxHP;
                    UIManager.instance.warehouseItemTemp.maxAddSTR = UIManager.instance.itemTemp.maxAddSTR;
                    UIManager.instance.warehouseItemTemp.maxAddHEL = UIManager.instance.itemTemp.maxAddHEL;
                    UIManager.instance.warehouseItemTemp.maxAddINT = UIManager.instance.itemTemp.maxAddINT;
                    UIManager.instance.warehouseItemTemp.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                    UIManager.instance.warehouseItemTemp.maxAddLUK = UIManager.instance.itemTemp.maxAddLUK;
                    UIManager.instance.warehouseItemTemp.maxAddPower = UIManager.instance.itemTemp.maxAddPower;
                    UIManager.instance.warehouseItemTemp.maxAddDefence = UIManager.instance.itemTemp.maxAddDefence;
                    UIManager.instance.warehouseItemTemp.coolTime = UIManager.instance.itemTemp.coolTime;
                    UIManager.instance.warehouseItemTemp.stayTime = UIManager.instance.itemTemp.stayTime;
                    UIManager.instance.warehouseItemTemp.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                    UIManager.instance.warehouseItemTemp.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                    UIManager.instance.warehouseItemTemp.addSTR = UIManager.instance.itemTemp.addSTR;
                    UIManager.instance.warehouseItemTemp.addHEL = UIManager.instance.itemTemp.addHEL;
                    UIManager.instance.warehouseItemTemp.addINT = UIManager.instance.itemTemp.addINT;
                    UIManager.instance.warehouseItemTemp.addLUK = UIManager.instance.itemTemp.addLUK;
                    UIManager.instance.warehouseItemTemp.addPower = UIManager.instance.itemTemp.addPower;
                    UIManager.instance.warehouseItemTemp.addDefence = UIManager.instance.itemTemp.addDefence;
                    UIManager.instance.warehouseItemTemp.requireLevel = UIManager.instance.itemTemp.requireLevel;
                    UIManager.instance.warehouseItemTemp.requireSTR = UIManager.instance.itemTemp.requireSTR;
                    UIManager.instance.warehouseItemTemp.requireHEL = UIManager.instance.itemTemp.requireHEL;
                    UIManager.instance.warehouseItemTemp.requireINT = UIManager.instance.itemTemp.requireINT;
                    UIManager.instance.warehouseItemTemp.requireLUK = UIManager.instance.itemTemp.requireLUK;
                    UIManager.instance.warehouseItemTemp.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                    UIManager.instance.warehouseItemTemp.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                    if (UIManager.instance.warehouseItemTemp.GetItem(InputItemQuantity) == 1)
                    {
                        SoundManager.instance.SoundEffectOn("WarehousSound", SoundManager.instance.soundEffectNumber);
                        UIManager.instance.itemTemp.LoseItem(InputItemQuantity);
                    }
                    else
                    {
                        StartCoroutine(WarehouseInputFailText());
                    }
                }
                else
                {
                    StartCoroutine(WarehouseInputFailText());
                }
            }
            else if (UIManager.instance.itemTemp.bigItemType == "Consume")
            {
                if (UIManager.instance.item_ConsumeSlot[UIManager.instance.itemTemp.slotNumber].quantity >= InputItemQuantity)
                {
                    UIManager.instance.warehouseItemTemp.itemName = UIManager.instance.itemTemp.itemName;
                    UIManager.instance.warehouseItemTemp.bigItemType = UIManager.instance.itemTemp.bigItemType;
                    UIManager.instance.warehouseItemTemp.smallItemType = UIManager.instance.itemTemp.smallItemType;
                    UIManager.instance.warehouseItemTemp.price = UIManager.instance.itemTemp.price;
                    UIManager.instance.warehouseItemTemp.itemExplain = UIManager.instance.itemTemp.itemExplain;
                    UIManager.instance.warehouseItemTemp.maxAddHP = UIManager.instance.itemTemp.maxAddHP;
                    UIManager.instance.warehouseItemTemp.maxAddMP = UIManager.instance.itemTemp.maxAddMP;
                    UIManager.instance.warehouseItemTemp.maxAddMaxMP = UIManager.instance.itemTemp.maxAddMaxMP;
                    UIManager.instance.warehouseItemTemp.maxAddMaxHP = UIManager.instance.itemTemp.maxAddMaxHP;
                    UIManager.instance.warehouseItemTemp.maxAddSTR = UIManager.instance.itemTemp.maxAddSTR;
                    UIManager.instance.warehouseItemTemp.maxAddHEL = UIManager.instance.itemTemp.maxAddHEL;
                    UIManager.instance.warehouseItemTemp.maxAddINT = UIManager.instance.itemTemp.maxAddINT;
                    UIManager.instance.warehouseItemTemp.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                    UIManager.instance.warehouseItemTemp.maxAddLUK = UIManager.instance.itemTemp.maxAddLUK;
                    UIManager.instance.warehouseItemTemp.maxAddPower = UIManager.instance.itemTemp.maxAddPower;
                    UIManager.instance.warehouseItemTemp.maxAddDefence = UIManager.instance.itemTemp.maxAddDefence;
                    UIManager.instance.warehouseItemTemp.coolTime = UIManager.instance.itemTemp.coolTime;
                    UIManager.instance.warehouseItemTemp.stayTime = UIManager.instance.itemTemp.stayTime;
                    UIManager.instance.warehouseItemTemp.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                    UIManager.instance.warehouseItemTemp.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                    UIManager.instance.warehouseItemTemp.addSTR = UIManager.instance.itemTemp.addSTR;
                    UIManager.instance.warehouseItemTemp.addHEL = UIManager.instance.itemTemp.addHEL;
                    UIManager.instance.warehouseItemTemp.addINT = UIManager.instance.itemTemp.addINT;
                    UIManager.instance.warehouseItemTemp.addLUK = UIManager.instance.itemTemp.addLUK;
                    UIManager.instance.warehouseItemTemp.addPower = UIManager.instance.itemTemp.addPower;
                    UIManager.instance.warehouseItemTemp.addDefence = UIManager.instance.itemTemp.addDefence;
                    UIManager.instance.warehouseItemTemp.requireLevel = UIManager.instance.itemTemp.requireLevel;
                    UIManager.instance.warehouseItemTemp.requireSTR = UIManager.instance.itemTemp.requireSTR;
                    UIManager.instance.warehouseItemTemp.requireHEL = UIManager.instance.itemTemp.requireHEL;
                    UIManager.instance.warehouseItemTemp.requireINT = UIManager.instance.itemTemp.requireINT;
                    UIManager.instance.warehouseItemTemp.requireLUK = UIManager.instance.itemTemp.requireLUK;
                    UIManager.instance.warehouseItemTemp.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                    UIManager.instance.warehouseItemTemp.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                    if (UIManager.instance.warehouseItemTemp.GetItem(InputItemQuantity) == 1)
                    {
                        SoundManager.instance.SoundEffectOn("WarehousSound", SoundManager.instance.soundEffectNumber);
                        UIManager.instance.itemTemp.LoseItem(InputItemQuantity);
                    }
                    else
                    {
                        StartCoroutine(WarehouseInputFailText());
                    }

                }
                else
                {
                    StartCoroutine(WarehouseInputFailText());
                }
            }
            else if (UIManager.instance.itemTemp.bigItemType == "Etc")
            {
                if (UIManager.instance.item_EtcSlot[UIManager.instance.itemTemp.slotNumber].quantity >= InputItemQuantity)
                {
                    UIManager.instance.warehouseItemTemp.itemName = UIManager.instance.itemTemp.itemName;
                    UIManager.instance.warehouseItemTemp.bigItemType = UIManager.instance.itemTemp.bigItemType;
                    UIManager.instance.warehouseItemTemp.smallItemType = UIManager.instance.itemTemp.smallItemType;
                    UIManager.instance.warehouseItemTemp.price = UIManager.instance.itemTemp.price;
                    UIManager.instance.warehouseItemTemp.itemExplain = UIManager.instance.itemTemp.itemExplain;
                    UIManager.instance.warehouseItemTemp.maxAddHP = UIManager.instance.itemTemp.maxAddHP;
                    UIManager.instance.warehouseItemTemp.maxAddMP = UIManager.instance.itemTemp.maxAddMP;
                    UIManager.instance.warehouseItemTemp.maxAddMaxMP = UIManager.instance.itemTemp.maxAddMaxMP;
                    UIManager.instance.warehouseItemTemp.maxAddMaxHP = UIManager.instance.itemTemp.maxAddMaxHP;
                    UIManager.instance.warehouseItemTemp.maxAddSTR = UIManager.instance.itemTemp.maxAddSTR;
                    UIManager.instance.warehouseItemTemp.maxAddHEL = UIManager.instance.itemTemp.maxAddHEL;
                    UIManager.instance.warehouseItemTemp.maxAddINT = UIManager.instance.itemTemp.maxAddINT;
                    UIManager.instance.warehouseItemTemp.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                    UIManager.instance.warehouseItemTemp.maxAddLUK = UIManager.instance.itemTemp.maxAddLUK;
                    UIManager.instance.warehouseItemTemp.maxAddPower = UIManager.instance.itemTemp.maxAddPower;
                    UIManager.instance.warehouseItemTemp.maxAddDefence = UIManager.instance.itemTemp.maxAddDefence;
                    UIManager.instance.warehouseItemTemp.coolTime = UIManager.instance.itemTemp.coolTime;
                    UIManager.instance.warehouseItemTemp.stayTime = UIManager.instance.itemTemp.stayTime;
                    UIManager.instance.warehouseItemTemp.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                    UIManager.instance.warehouseItemTemp.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                    UIManager.instance.warehouseItemTemp.addSTR = UIManager.instance.itemTemp.addSTR;
                    UIManager.instance.warehouseItemTemp.addHEL = UIManager.instance.itemTemp.addHEL;
                    UIManager.instance.warehouseItemTemp.addINT = UIManager.instance.itemTemp.addINT;
                    UIManager.instance.warehouseItemTemp.addLUK = UIManager.instance.itemTemp.addLUK;
                    UIManager.instance.warehouseItemTemp.addPower = UIManager.instance.itemTemp.addPower;
                    UIManager.instance.warehouseItemTemp.addDefence = UIManager.instance.itemTemp.addDefence;
                    UIManager.instance.warehouseItemTemp.requireLevel = UIManager.instance.itemTemp.requireLevel;
                    UIManager.instance.warehouseItemTemp.requireSTR = UIManager.instance.itemTemp.requireSTR;
                    UIManager.instance.warehouseItemTemp.requireHEL = UIManager.instance.itemTemp.requireHEL;
                    UIManager.instance.warehouseItemTemp.requireINT = UIManager.instance.itemTemp.requireINT;
                    UIManager.instance.warehouseItemTemp.requireLUK = UIManager.instance.itemTemp.requireLUK;
                    UIManager.instance.warehouseItemTemp.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                    UIManager.instance.warehouseItemTemp.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                    if (UIManager.instance.warehouseItemTemp.GetItem(InputItemQuantity) == 1)
                    {
                        SoundManager.instance.SoundEffectOn("WarehousSound", SoundManager.instance.soundEffectNumber);
                        UIManager.instance.itemTemp.LoseItem(InputItemQuantity);
                    }
                    else
                    {
                        StartCoroutine(WarehouseInputFailText());
                    }

                }
                else
                {
                    StartCoroutine(WarehouseInputFailText());
                }
            }
            else if (UIManager.instance.itemTemp.bigItemType == "Cash")
            {
                if (UIManager.instance.item_CashSlot[UIManager.instance.itemTemp.slotNumber].quantity >= InputItemQuantity)
                {
                    UIManager.instance.warehouseItemTemp.itemName = UIManager.instance.itemTemp.itemName;
                    UIManager.instance.warehouseItemTemp.bigItemType = UIManager.instance.itemTemp.bigItemType;
                    UIManager.instance.warehouseItemTemp.smallItemType = UIManager.instance.itemTemp.smallItemType;
                    UIManager.instance.warehouseItemTemp.price = UIManager.instance.itemTemp.price;
                    UIManager.instance.warehouseItemTemp.itemExplain = UIManager.instance.itemTemp.itemExplain;
                    UIManager.instance.warehouseItemTemp.maxAddHP = UIManager.instance.itemTemp.maxAddHP;
                    UIManager.instance.warehouseItemTemp.maxAddMP = UIManager.instance.itemTemp.maxAddMP;
                    UIManager.instance.warehouseItemTemp.maxAddMaxMP = UIManager.instance.itemTemp.maxAddMaxMP;
                    UIManager.instance.warehouseItemTemp.maxAddMaxHP = UIManager.instance.itemTemp.maxAddMaxHP;
                    UIManager.instance.warehouseItemTemp.maxAddSTR = UIManager.instance.itemTemp.maxAddSTR;
                    UIManager.instance.warehouseItemTemp.maxAddHEL = UIManager.instance.itemTemp.maxAddHEL;
                    UIManager.instance.warehouseItemTemp.maxAddINT = UIManager.instance.itemTemp.maxAddINT;
                    UIManager.instance.warehouseItemTemp.sharePosiible = UIManager.instance.itemTemp.sharePosiible;
                    UIManager.instance.warehouseItemTemp.maxAddLUK = UIManager.instance.itemTemp.maxAddLUK;
                    UIManager.instance.warehouseItemTemp.maxAddPower = UIManager.instance.itemTemp.maxAddPower;
                    UIManager.instance.warehouseItemTemp.maxAddDefence = UIManager.instance.itemTemp.maxAddDefence;
                    UIManager.instance.warehouseItemTemp.coolTime = UIManager.instance.itemTemp.coolTime;
                    UIManager.instance.warehouseItemTemp.stayTime = UIManager.instance.itemTemp.stayTime;
                    UIManager.instance.warehouseItemTemp.addMaxHP = UIManager.instance.itemTemp.addMaxHP;
                    UIManager.instance.warehouseItemTemp.addMaxMP = UIManager.instance.itemTemp.addMaxMP;
                    UIManager.instance.warehouseItemTemp.addSTR = UIManager.instance.itemTemp.addSTR;
                    UIManager.instance.warehouseItemTemp.addHEL = UIManager.instance.itemTemp.addHEL;
                    UIManager.instance.warehouseItemTemp.addINT = UIManager.instance.itemTemp.addINT;
                    UIManager.instance.warehouseItemTemp.addLUK = UIManager.instance.itemTemp.addLUK;
                    UIManager.instance.warehouseItemTemp.addPower = UIManager.instance.itemTemp.addPower;
                    UIManager.instance.warehouseItemTemp.addDefence = UIManager.instance.itemTemp.addDefence;
                    UIManager.instance.warehouseItemTemp.requireLevel = UIManager.instance.itemTemp.requireLevel;
                    UIManager.instance.warehouseItemTemp.requireSTR = UIManager.instance.itemTemp.requireSTR;
                    UIManager.instance.warehouseItemTemp.requireHEL = UIManager.instance.itemTemp.requireHEL;
                    UIManager.instance.warehouseItemTemp.requireINT = UIManager.instance.itemTemp.requireINT;
                    UIManager.instance.warehouseItemTemp.requireLUK = UIManager.instance.itemTemp.requireLUK;
                    UIManager.instance.warehouseItemTemp.enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
                    UIManager.instance.warehouseItemTemp.enhanceStack = UIManager.instance.itemTemp.enhanceStack;
                    if (UIManager.instance.warehouseItemTemp.GetItem(InputItemQuantity) == 1)
                    {
                        SoundManager.instance.SoundEffectOn("WarehousSound", SoundManager.instance.soundEffectNumber);
                        UIManager.instance.itemTemp.LoseItem(InputItemQuantity);
                    }
                    else
                    {
                        StartCoroutine(WarehouseInputFailText());
                    }

                }
                else
                {
                    StartCoroutine(WarehouseInputFailText());
                }
            }
        }
        else
        {
            StartCoroutine(WarehouseInputFailText());
        }
        InputItemQuantity = 0;

    }

    // x버튼을 눌렀을 때 발생하는 이벤트, 아이템창을 SetActive(false)시킨다 
    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.item_WarehouseClickEventPanel.gameObject.SetActive(false);
        UIManager.instance.item_QuickSlotClickEvnetPanel.gameObject.SetActive(false);
        UIManager.instance.item_SellClickEventPanel.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    IEnumerator UseButtonFailText()
    {
        UIManager.instance.item_UseButtonFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.item_UseButtonFailText.gameObject.SetActive(false);
    }

    IEnumerator EquipButtonFailText()
    {
        UIManager.instance.item_EquipButtonFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.item_EquipButtonFailText.gameObject.SetActive(false);
    }

    IEnumerator QuickSlotButtonFailText()
    {
        UIManager.instance.item_QuickSlotButtonFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.item_QuickSlotButtonFailText.gameObject.SetActive(false);
    }


    IEnumerator SellFailText()
    {
        UIManager.instance.item_SellFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.item_SellFailText.gameObject.SetActive(false);
    }


    IEnumerator WarehouseInputFailText()
    {
        UIManager.instance.item_WarehouseInputFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.item_WarehouseInputFailText.gameObject.SetActive(false);
    }


}
