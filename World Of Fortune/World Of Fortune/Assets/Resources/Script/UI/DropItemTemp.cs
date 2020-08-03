using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItemTemp : MonoBehaviour
{
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
    public bool sharePosiible; // 계정공유 가능한지 가능 = true;


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
    public Text quantityText;
    public int minEmpty;




    //아이템 획득했을때 이 메소드 사용
    //ItemTemp에 아이템 정보를 넘기고 매개변수로 얻는 아이템 개수를 넘긴다 (장비는 무조건 1)
    // 먼저 
    public int GetItem(int getQuantity)
    {


        minEmpty = -1;

        if (bigItemType == "Equipment")
        {
            for (int i = 31; i >= 0; i--)
            {
                if (UIManager.instance.item_EquipSlot[i].itemName == "null")
                {
                    minEmpty = i;

                }
            }
            if (minEmpty != -1)
            {
                UIManager.instance.item_EquipSlot[minEmpty].itemName = itemName;
                UIManager.instance.item_EquipSlot[minEmpty].bigItemType = bigItemType;
                UIManager.instance.item_EquipSlot[minEmpty].smallItemType = smallItemType;
                UIManager.instance.item_EquipSlot[minEmpty].quantity = getQuantity;
                UIManager.instance.item_EquipSlot[minEmpty].price = price;
                UIManager.instance.item_EquipSlot[minEmpty].slotNumber = minEmpty;
                UIManager.instance.item_EquipSlot[minEmpty].itemExplain = itemExplain;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddHP = maxAddHP;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddMP = maxAddMP;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddMaxMP = maxAddMaxMP;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddMaxHP = maxAddMaxHP;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddSTR = maxAddSTR;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddHEL = maxAddHEL;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddINT = maxAddINT;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddLUK = maxAddLUK;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddPower = maxAddPower;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddMagicPower = maxAddMagicPower;
                UIManager.instance.item_EquipSlot[minEmpty].maxAddDefence = maxAddDefence;
                UIManager.instance.item_EquipSlot[minEmpty].sharePosiible = sharePosiible;
                UIManager.instance.item_EquipSlot[minEmpty].addMaxHP = addMaxHP;
                UIManager.instance.item_EquipSlot[minEmpty].addMaxMP = addMaxMP;
                UIManager.instance.item_EquipSlot[minEmpty].addSTR = addSTR;
                UIManager.instance.item_EquipSlot[minEmpty].addHEL = addHEL;
                UIManager.instance.item_EquipSlot[minEmpty].addINT = addINT;
                UIManager.instance.item_EquipSlot[minEmpty].addLUK = addLUK;
                UIManager.instance.item_EquipSlot[minEmpty].addPower = addPower;
                UIManager.instance.item_EquipSlot[minEmpty].addDefence = addDefence;
                UIManager.instance.item_EquipSlot[minEmpty].requireLevel = requireLevel;
                UIManager.instance.item_EquipSlot[minEmpty].requireSTR = requireSTR;
                UIManager.instance.item_EquipSlot[minEmpty].requireHEL = requireHEL;
                UIManager.instance.item_EquipSlot[minEmpty].requireINT = requireINT;
                UIManager.instance.item_EquipSlot[minEmpty].requireLUK = requireLUK;
                UIManager.instance.item_EquipSlot[minEmpty].enhanceLevel = enhanceLevel;
                UIManager.instance.item_EquipSlot[minEmpty].enhanceStack = enhanceStack;
                UIManager.instance.item_EquipSlot[minEmpty].Refresh();
                UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                return 1;

            }

        }
        else if (bigItemType == "Consume")
        {
            for (int i = 31; i >= 0; i--)
            {
                if (UIManager.instance.item_ConsumeSlot[i].itemName == "null")
                {
                    minEmpty = i;

                }
                if (UIManager.instance.item_ConsumeSlot[i].itemName == itemName && UIManager.instance.item_ConsumeSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;

                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.item_ConsumeSlot[minEmpty].quantity == 0)
                {
                    UIManager.instance.item_ConsumeSlot[minEmpty].itemName = itemName;
                    UIManager.instance.item_ConsumeSlot[minEmpty].bigItemType = bigItemType;
                    UIManager.instance.item_ConsumeSlot[minEmpty].smallItemType = smallItemType;
                    UIManager.instance.item_ConsumeSlot[minEmpty].price = price;
                    UIManager.instance.item_ConsumeSlot[minEmpty].quantity = getQuantity;
                    UIManager.instance.item_ConsumeSlot[minEmpty].slotNumber = minEmpty;
                    UIManager.instance.item_ConsumeSlot[minEmpty].itemExplain = itemExplain;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddHP = maxAddHP;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddMP = maxAddMP;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddMaxMP = maxAddMaxMP;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddMaxHP = maxAddMaxHP;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddSTR = maxAddSTR;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddHEL = maxAddHEL;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddINT = maxAddINT;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddLUK = maxAddLUK;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddPower = maxAddPower;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddMagicPower = maxAddMagicPower;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddDefence = maxAddDefence;
                    UIManager.instance.item_ConsumeSlot[minEmpty].sharePosiible = sharePosiible;
                    UIManager.instance.item_ConsumeSlot[minEmpty].coolTime = coolTime;
                    UIManager.instance.item_ConsumeSlot[minEmpty].stayTime = stayTime;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addMaxHP = addMaxHP;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addMaxMP = addMaxMP;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addSTR = addSTR;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addHEL = addHEL;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addINT = addINT;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addLUK = addLUK;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addPower = addPower;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addDefence = addDefence;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireLevel = requireLevel;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireSTR = requireSTR;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireHEL = requireHEL;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireINT = requireINT;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireLUK = requireLUK;
                    UIManager.instance.item_ConsumeSlot[minEmpty].enhanceLevel = enhanceLevel;
                    UIManager.instance.item_ConsumeSlot[minEmpty].enhanceStack = enhanceStack;
                    UIManager.instance.item_ConsumeSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }
                else
                {
                    UIManager.instance.item_ConsumeSlot[minEmpty].quantity += getQuantity;
                    UIManager.instance.item_ConsumeSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }

            }
        }
        else if (bigItemType == "Etc")
        {
            for (int i = 31; i >= 0; i--)
            {
                if (UIManager.instance.item_EtcSlot[i].itemName == "null")
                {
                    minEmpty = i;

                }
                if (UIManager.instance.item_EtcSlot[i].itemName == itemName && UIManager.instance.item_EtcSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;

                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.item_EtcSlot[minEmpty].quantity == 0)
                {
                    UIManager.instance.item_EtcSlot[minEmpty].itemName = itemName;
                    UIManager.instance.item_EtcSlot[minEmpty].bigItemType = bigItemType;
                    UIManager.instance.item_EtcSlot[minEmpty].smallItemType = smallItemType;
                    UIManager.instance.item_EtcSlot[minEmpty].price = price;
                    UIManager.instance.item_EtcSlot[minEmpty].quantity = getQuantity;
                    UIManager.instance.item_EtcSlot[minEmpty].slotNumber = minEmpty;
                    UIManager.instance.item_EtcSlot[minEmpty].itemExplain = itemExplain;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddHP = maxAddHP;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddMP = maxAddMP;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddMaxMP = maxAddMaxMP;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddMaxHP = maxAddMaxHP;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddSTR = maxAddSTR;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddHEL = maxAddHEL;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddINT = maxAddINT;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddLUK = maxAddLUK;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddPower = maxAddPower;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddMagicPower = maxAddMagicPower;
                    UIManager.instance.item_EtcSlot[minEmpty].sharePosiible = sharePosiible;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddDefence = maxAddDefence;
                    UIManager.instance.item_EtcSlot[minEmpty].coolTime = coolTime;
                    UIManager.instance.item_EtcSlot[minEmpty].stayTime = stayTime;
                    UIManager.instance.item_EtcSlot[minEmpty].addMaxHP = addMaxHP;
                    UIManager.instance.item_EtcSlot[minEmpty].addMaxMP = addMaxMP;
                    UIManager.instance.item_EtcSlot[minEmpty].addSTR = addSTR;
                    UIManager.instance.item_EtcSlot[minEmpty].addHEL = addHEL;
                    UIManager.instance.item_EtcSlot[minEmpty].addINT = addINT;
                    UIManager.instance.item_EtcSlot[minEmpty].addLUK = addLUK;
                    UIManager.instance.item_EtcSlot[minEmpty].addPower = addPower;
                    UIManager.instance.item_EtcSlot[minEmpty].addDefence = addDefence;
                    UIManager.instance.item_EtcSlot[minEmpty].requireLevel = requireLevel;
                    UIManager.instance.item_EtcSlot[minEmpty].requireSTR = requireSTR;
                    UIManager.instance.item_EtcSlot[minEmpty].requireHEL = requireHEL;
                    UIManager.instance.item_EtcSlot[minEmpty].requireINT = requireINT;
                    UIManager.instance.item_EtcSlot[minEmpty].requireLUK = requireLUK;
                    UIManager.instance.item_EtcSlot[minEmpty].enhanceLevel = enhanceLevel;
                    UIManager.instance.item_EtcSlot[minEmpty].enhanceStack = enhanceStack;
                    UIManager.instance.item_EtcSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }
                else
                {
                    UIManager.instance.item_EtcSlot[minEmpty].quantity += getQuantity;
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    UIManager.instance.item_EtcSlot[minEmpty].Refresh();
                    return 1;
                }

            }
        }
        else if (bigItemType == "Cash")
        {
            for (int i = 31; i >= 0; i--)
            {
                if (UIManager.instance.item_CashSlot[i].itemName == "null")
                {
                    minEmpty = i;

                }
                if (UIManager.instance.item_CashSlot[i].itemName == itemName && UIManager.instance.item_CashSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;

                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.item_CashSlot[minEmpty].quantity == 0)
                {
                    UIManager.instance.item_CashSlot[minEmpty].itemName = itemName;
                    UIManager.instance.item_CashSlot[minEmpty].bigItemType = bigItemType;
                    UIManager.instance.item_CashSlot[minEmpty].smallItemType = smallItemType;
                    UIManager.instance.item_CashSlot[minEmpty].price = price;
                    UIManager.instance.item_CashSlot[minEmpty].quantity = getQuantity;
                    UIManager.instance.item_CashSlot[minEmpty].slotNumber = minEmpty;
                    UIManager.instance.item_CashSlot[minEmpty].itemExplain = itemExplain;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddHP = maxAddHP;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddMP = maxAddMP;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddMaxMP = maxAddMaxMP;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddMaxHP = maxAddMaxHP;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddSTR = maxAddSTR;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddHEL = maxAddHEL;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddINT = maxAddINT;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddLUK = maxAddLUK;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddPower = maxAddPower;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddMagicPower = maxAddMagicPower;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddDefence = maxAddDefence;
                    UIManager.instance.item_CashSlot[minEmpty].sharePosiible = sharePosiible;
                    UIManager.instance.item_CashSlot[minEmpty].coolTime = coolTime;
                    UIManager.instance.item_CashSlot[minEmpty].stayTime = stayTime;
                    UIManager.instance.item_CashSlot[minEmpty].addMaxHP = addMaxHP;
                    UIManager.instance.item_CashSlot[minEmpty].addMaxMP = addMaxMP;
                    UIManager.instance.item_CashSlot[minEmpty].addSTR = addSTR;
                    UIManager.instance.item_CashSlot[minEmpty].addHEL = addHEL;
                    UIManager.instance.item_CashSlot[minEmpty].addINT = addINT;
                    UIManager.instance.item_CashSlot[minEmpty].addLUK = addLUK;
                    UIManager.instance.item_CashSlot[minEmpty].addPower = addPower;
                    UIManager.instance.item_CashSlot[minEmpty].addDefence = addDefence;
                    UIManager.instance.item_CashSlot[minEmpty].requireLevel = requireLevel;
                    UIManager.instance.item_CashSlot[minEmpty].requireSTR = requireSTR;
                    UIManager.instance.item_CashSlot[minEmpty].requireHEL = requireHEL;
                    UIManager.instance.item_CashSlot[minEmpty].requireINT = requireINT;
                    UIManager.instance.item_CashSlot[minEmpty].requireLUK = requireLUK;
                    UIManager.instance.item_CashSlot[minEmpty].enhanceLevel = enhanceLevel;
                    UIManager.instance.item_CashSlot[minEmpty].enhanceStack = enhanceStack;
                    UIManager.instance.item_CashSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }
                else
                {
                    UIManager.instance.item_CashSlot[minEmpty].quantity += getQuantity;
                    UIManager.instance.item_CashSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }

            }
        }
        return 0;

    }



    public int LoseItem(int loseQuantity)
    {

        minEmpty = -1;
        if (bigItemType == "Equipment")
        {
            for (int i = 31; i >= 0; i--)
            {
                if (UIManager.instance.item_EquipSlot[i].itemName == itemName && UIManager.instance.item_EquipSlot[i].sharePosiible == sharePosiible && UIManager.instance.item_EquipSlot[i].addMaxHP == addMaxHP
                  && UIManager.instance.item_EquipSlot[i].addMaxMP == addMaxMP && UIManager.instance.item_EquipSlot[i].addSTR == addSTR && UIManager.instance.item_EquipSlot[i].addHEL == addHEL &&
                  UIManager.instance.item_EquipSlot[i].addINT == addINT && UIManager.instance.item_EquipSlot[i].addLUK == addLUK &&
                  UIManager.instance.item_EquipSlot[i].addPower == addPower && UIManager.instance.item_EquipSlot[i].addMagicPower == addMagicPower && UIManager.instance.item_EquipSlot[i].addDefence == addDefence
                   && UIManager.instance.item_EquipSlot[i].enhanceStack == enhanceStack)
                {
                    minEmpty = i;
                    break;
                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.item_EquipSlot[minEmpty].quantity > loseQuantity)
                {
                    UIManager.instance.item_EquipSlot[minEmpty].quantity -= loseQuantity;
                    UIManager.instance.item_EquipSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    return 1;
                }
                else if (UIManager.instance.item_EquipSlot[minEmpty].quantity == loseQuantity)
                {

                    UIManager.instance.item_EquipSlot[minEmpty].quantity = 0;
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    UIManager.instance.item_EquipSlot[minEmpty].itemName = "null";
                    UIManager.instance.item_EquipSlot[minEmpty].bigItemType = "null";
                    UIManager.instance.item_EquipSlot[minEmpty].smallItemType = "null";
                    UIManager.instance.item_EquipSlot[minEmpty].price = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].itemExplain = "null";
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddHP = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddMP = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddMaxMP = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddMaxHP = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddSTR = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddHEL = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddINT = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddLUK = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddPower = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddMagicPower = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].maxAddDefence = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].sharePosiible = false;
                    UIManager.instance.item_EquipSlot[minEmpty].coolTime = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].stayTime = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].addMaxHP = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].addMaxMP = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].addSTR = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].addHEL = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].addINT = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].addLUK = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].addPower = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].addDefence = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].requireLevel = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].requireSTR = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].requireHEL = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].requireINT = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].requireLUK = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].enhanceLevel = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].enhanceStack = 0;
                    UIManager.instance.item_EquipSlot[minEmpty].Refresh();
                    return 1;
                }
            }
        }
        else if (bigItemType == "Consume")
        {
            for (int i = 31; i >= 0; i--)
            {
                if (UIManager.instance.item_ConsumeSlot[i].itemName == itemName && i == slotNumber && UIManager.instance.item_ConsumeSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;
                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.item_ConsumeSlot[minEmpty].quantity > loseQuantity)
                {
                    UIManager.instance.item_ConsumeSlot[minEmpty].quantity -= loseQuantity;
                    UIManager.instance.item_ConsumeSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    return 1;
                }
                else if (UIManager.instance.item_ConsumeSlot[minEmpty].quantity == loseQuantity)
                {
                    UIManager.instance.item_ConsumeSlot[minEmpty].quantity = 0;
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    UIManager.instance.item_ConsumeSlot[minEmpty].itemName = "null";
                    UIManager.instance.item_ConsumeSlot[minEmpty].bigItemType = "null";
                    UIManager.instance.item_ConsumeSlot[minEmpty].smallItemType = "null";
                    UIManager.instance.item_ConsumeSlot[minEmpty].price = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].itemExplain = "null";
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddHP = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddMP = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddMaxMP = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddMaxHP = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddSTR = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddHEL = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddINT = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddLUK = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddPower = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddMagicPower = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].maxAddDefence = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].sharePosiible = false;
                    UIManager.instance.item_ConsumeSlot[minEmpty].coolTime = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].stayTime = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addMaxHP = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addMaxMP = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addSTR = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addHEL = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addINT = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addLUK = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addPower = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].addDefence = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireLevel = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireSTR = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireHEL = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireINT = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].requireLUK = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].enhanceLevel = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].enhanceStack = 0;
                    UIManager.instance.item_ConsumeSlot[minEmpty].Refresh();
                    return 1;
                }
            }
        }
        else if (bigItemType == "Etc")
        {
            for (int i = 31; i >= 0; i--)
            {
                if (UIManager.instance.item_EtcSlot[i].itemName == itemName && i == slotNumber && UIManager.instance.item_EtcSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;
                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.item_EtcSlot[minEmpty].quantity > loseQuantity)
                {
                    UIManager.instance.item_EtcSlot[minEmpty].quantity -= loseQuantity;
                    UIManager.instance.item_EtcSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    return 1;
                }
                else if (UIManager.instance.item_EtcSlot[minEmpty].quantity == loseQuantity)
                {

                    UIManager.instance.item_EtcSlot[minEmpty].quantity = 0;
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    UIManager.instance.item_EtcSlot[minEmpty].itemName = "null";
                    UIManager.instance.item_EtcSlot[minEmpty].bigItemType = "null";
                    UIManager.instance.item_EtcSlot[minEmpty].smallItemType = "null";
                    UIManager.instance.item_EtcSlot[minEmpty].price = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].itemExplain = "null";
                    UIManager.instance.item_EtcSlot[minEmpty].sharePosiible = false;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddHP = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddMP = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddMaxMP = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddMaxHP = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddSTR = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddHEL = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddINT = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddLUK = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddPower = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddMagicPower = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].maxAddDefence = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].coolTime = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].stayTime = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].addMaxHP = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].addMaxMP = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].addSTR = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].addHEL = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].addINT = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].addLUK = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].addPower = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].addDefence = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].requireLevel = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].requireSTR = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].requireHEL = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].requireINT = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].requireLUK = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].enhanceLevel = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].enhanceStack = 0;
                    UIManager.instance.item_EtcSlot[minEmpty].Refresh();
                    return 1;
                }
            }
        }
        else if (bigItemType == "Cash")
        {
            for (int i = 31; i >= 0; i--)
            {
                if (UIManager.instance.item_CashSlot[i].itemName == itemName && i == slotNumber  && UIManager.instance.item_CashSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;
                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.item_CashSlot[minEmpty].quantity > loseQuantity)
                {
                    UIManager.instance.item_CashSlot[minEmpty].quantity -= loseQuantity;
                    UIManager.instance.item_CashSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    return 1;
                }
                else if (UIManager.instance.item_CashSlot[minEmpty].quantity == loseQuantity)
                {
                    UIManager.instance.item_CashSlot[minEmpty].quantity = 0;
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    UIManager.instance.item_CashSlot[minEmpty].itemName = "null";
                    UIManager.instance.item_CashSlot[minEmpty].bigItemType = "null";
                    UIManager.instance.item_CashSlot[minEmpty].smallItemType = "null";
                    UIManager.instance.item_CashSlot[minEmpty].price = 0;
                    UIManager.instance.item_CashSlot[minEmpty].itemExplain = "null";
                    UIManager.instance.item_CashSlot[minEmpty].maxAddHP = 0;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddMP = 0;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddMaxMP = 0;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddMaxHP = 0;
                    UIManager.instance.item_CashSlot[minEmpty].sharePosiible = false;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddSTR = 0;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddHEL = 0;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddINT = 0;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddLUK = 0;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddPower = 0;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddMagicPower = 0;
                    UIManager.instance.item_CashSlot[minEmpty].maxAddDefence = 0;
                    UIManager.instance.item_CashSlot[minEmpty].coolTime = 0;
                    UIManager.instance.item_CashSlot[minEmpty].stayTime = 0;
                    UIManager.instance.item_CashSlot[minEmpty].addMaxHP = 0;
                    UIManager.instance.item_CashSlot[minEmpty].addMaxMP = 0;
                    UIManager.instance.item_CashSlot[minEmpty].addSTR = 0;
                    UIManager.instance.item_CashSlot[minEmpty].addHEL = 0;
                    UIManager.instance.item_CashSlot[minEmpty].addINT = 0;
                    UIManager.instance.item_CashSlot[minEmpty].addLUK = 0;
                    UIManager.instance.item_CashSlot[minEmpty].addPower = 0;
                    UIManager.instance.item_CashSlot[minEmpty].addDefence = 0;
                    UIManager.instance.item_CashSlot[minEmpty].requireLevel = 0;
                    UIManager.instance.item_CashSlot[minEmpty].requireSTR = 0;
                    UIManager.instance.item_CashSlot[minEmpty].requireHEL = 0;
                    UIManager.instance.item_CashSlot[minEmpty].requireINT = 0;
                    UIManager.instance.item_CashSlot[minEmpty].requireLUK = 0;
                    UIManager.instance.item_CashSlot[minEmpty].enhanceLevel = 0;
                    UIManager.instance.item_CashSlot[minEmpty].enhanceStack = 0;
                    UIManager.instance.item_CashSlot[minEmpty].Refresh();
                    return 1;
                }
            }
        }

        return 0;
    }



    public int InputItem(int inputQuantity)
    {



        return 0;
    }

    public int OutputItem(int outputQuantity)
    {


        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
