using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarehouseItemTemp : MonoBehaviour
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

    public int minEmpty;




    //아이템 획득했을때 이 메소드 사용
    //ItemTemp에 아이템 정보를 넘기고 매개변수로 얻는 아이템 개수를 넘긴다 (장비는 무조건 1)
    // 먼저 
    public int GetItem(int getQuantity)
    {


        minEmpty = -1;

        if (bigItemType == "Equipment")
        {
            for (int i = 43; i >= 0; i--)
            {
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == "null")
                {
                    minEmpty = i;

                }
            }
            if (minEmpty != -1)
            {
                UIManager.instance.warehouse_ItemSlot[minEmpty].itemName = itemName;
                UIManager.instance.warehouse_ItemSlot[minEmpty].bigItemType = bigItemType;
                UIManager.instance.warehouse_ItemSlot[minEmpty].smallItemType = smallItemType;
                UIManager.instance.warehouse_ItemSlot[minEmpty].quantity = 1;
                UIManager.instance.warehouse_ItemSlot[minEmpty].price = price;
                UIManager.instance.warehouse_ItemSlot[minEmpty].itemExplain = itemExplain;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHP = maxAddHP;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMP = maxAddMP;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxMP = maxAddMaxMP;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxHP = maxAddMaxHP;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddSTR = maxAddSTR;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHEL = maxAddHEL;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddINT = maxAddINT;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddLUK = maxAddLUK;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddPower = maxAddPower;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMagicPower = maxAddMagicPower;
                UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddDefence = maxAddDefence;
                UIManager.instance.warehouse_ItemSlot[minEmpty].sharePosiible = sharePosiible;
                UIManager.instance.warehouse_ItemSlot[minEmpty].coolTime = coolTime;
                UIManager.instance.warehouse_ItemSlot[minEmpty].stayTime = stayTime;
                UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxHP = addMaxHP;
                UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxMP = addMaxMP;
                UIManager.instance.warehouse_ItemSlot[minEmpty].addSTR = addSTR;
                UIManager.instance.warehouse_ItemSlot[minEmpty].addHEL = addHEL;
                UIManager.instance.warehouse_ItemSlot[minEmpty].addINT = addINT;
                UIManager.instance.warehouse_ItemSlot[minEmpty].addLUK = addLUK;
                UIManager.instance.warehouse_ItemSlot[minEmpty].addPower = addPower;
                UIManager.instance.warehouse_ItemSlot[minEmpty].addDefence = addDefence;
                UIManager.instance.warehouse_ItemSlot[minEmpty].requireLevel = requireLevel;
                UIManager.instance.warehouse_ItemSlot[minEmpty].requireSTR = requireSTR;
                UIManager.instance.warehouse_ItemSlot[minEmpty].requireHEL = requireHEL;
                UIManager.instance.warehouse_ItemSlot[minEmpty].requireINT = requireINT;
                UIManager.instance.warehouse_ItemSlot[minEmpty].requireLUK = requireLUK;
                UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceLevel = enhanceLevel;
                UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceStack = enhanceStack;
                UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                return 1;

            }

        }
        else if (bigItemType == "Consume")
        {
            for (int i = 43; i >= 0; i--)
            {
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == "null")
                {
                    minEmpty = i;

                }
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == itemName && UIManager.instance.warehouse_ItemSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;

                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity == 0)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemName = itemName;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].bigItemType = bigItemType;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].smallItemType = smallItemType;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].price = price;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity = getQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemExplain = itemExplain;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHP = maxAddHP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMP = maxAddMP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxMP = maxAddMaxMP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxHP = maxAddMaxHP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddSTR = maxAddSTR;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHEL = maxAddHEL;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddINT = maxAddINT;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddLUK = maxAddLUK;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddPower = maxAddPower;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMagicPower = maxAddMagicPower;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddDefence = maxAddDefence;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].sharePosiible = sharePosiible;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].coolTime = coolTime;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].stayTime = stayTime;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxHP = addMaxHP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxMP = addMaxMP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addSTR = addSTR;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addHEL = addHEL;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addINT = addINT;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addLUK = addLUK;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addPower = addPower;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addDefence = addDefence;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLevel = requireLevel;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireSTR = requireSTR;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireHEL = requireHEL;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireINT = requireINT;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLUK = requireLUK;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceLevel = enhanceLevel;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceStack = enhanceStack;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }
                else
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity += getQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }

            }
        }
        else if (bigItemType == "Etc")
        {
            for (int i = 43; i >= 0; i--)
            {
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == "null")
                {
                    minEmpty = i;

                }
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == itemName && UIManager.instance.warehouse_ItemSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;

                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity == 0)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemName = itemName;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].bigItemType = bigItemType;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].smallItemType = smallItemType;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].price = price;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity = getQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemExplain = itemExplain;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHP = maxAddHP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMP = maxAddMP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxMP = maxAddMaxMP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxHP = maxAddMaxHP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddSTR = maxAddSTR;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHEL = maxAddHEL;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddINT = maxAddINT;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddLUK = maxAddLUK;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddPower = maxAddPower;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMagicPower = maxAddMagicPower;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].sharePosiible = sharePosiible;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddDefence = maxAddDefence;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].coolTime = coolTime;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].stayTime = stayTime;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxHP = addMaxHP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxMP = addMaxMP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addSTR = addSTR;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addHEL = addHEL;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addINT = addINT;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addLUK = addLUK;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addPower = addPower;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addDefence = addDefence;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLevel = requireLevel;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireSTR = requireSTR;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireHEL = requireHEL;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireINT = requireINT;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLUK = requireLUK;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceLevel = enhanceLevel;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceStack = enhanceStack;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }
                else
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity += getQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }

            }
        }
        else if (bigItemType == "Cash")
        {
            for (int i = 43; i >= 0; i--)
            {
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == "null")
                {
                    minEmpty = i;

                }
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == itemName && UIManager.instance.warehouse_ItemSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;

                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity == 0)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemName = itemName;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].bigItemType = bigItemType;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].smallItemType = smallItemType;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].price = price;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity = getQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemExplain = itemExplain;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHP = maxAddHP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMP = maxAddMP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxMP = maxAddMaxMP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxHP = maxAddMaxHP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddSTR = maxAddSTR;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHEL = maxAddHEL;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddINT = maxAddINT;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddLUK = maxAddLUK;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddPower = maxAddPower;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMagicPower = maxAddMagicPower;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddDefence = maxAddDefence;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].sharePosiible = sharePosiible;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].coolTime = coolTime;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].stayTime = stayTime;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxHP = addMaxHP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxMP = addMaxMP;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addSTR = addSTR;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addHEL = addHEL;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addINT = addINT;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addLUK = addLUK;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addPower = addPower;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addDefence = addDefence;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLevel = requireLevel;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireSTR = requireSTR;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireHEL = requireHEL;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireINT = requireINT;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLUK = requireLUK;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceLevel = enhanceLevel;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceStack = enhanceStack;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemGet(itemName, minEmpty);
                    return 1;
                }
                else
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity += getQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
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
            for (int i = 43; i >= 0; i--)
            {
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == itemName && UIManager.instance.warehouse_ItemSlot[i].sharePosiible == sharePosiible && UIManager.instance.warehouse_ItemSlot[i].addMaxHP == addMaxHP
                  && UIManager.instance.warehouse_ItemSlot[i].addMaxMP == addMaxMP && UIManager.instance.warehouse_ItemSlot[i].addSTR == addSTR && UIManager.instance.warehouse_ItemSlot[i].addHEL == addHEL &&
                  UIManager.instance.warehouse_ItemSlot[i].addINT == addINT && UIManager.instance.warehouse_ItemSlot[i].addLUK == addLUK &&
                  UIManager.instance.warehouse_ItemSlot[i].addPower == addPower && UIManager.instance.warehouse_ItemSlot[i].addMagicPower == addMagicPower && UIManager.instance.warehouse_ItemSlot[i].addDefence == addDefence
                   && UIManager.instance.warehouse_ItemSlot[i].enhanceStack == enhanceStack)
                {
                    minEmpty = i;
                    break;
                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity > loseQuantity)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity -= loseQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    return 1;
                }
                else if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity == loseQuantity) 
                {

                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity = 0;
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemName = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].bigItemType = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].smallItemType = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].price = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemExplain = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMagicPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddDefence = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].sharePosiible = false;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].coolTime = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].stayTime = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addDefence = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLevel = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceLevel = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceStack = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    return 1;
                }
            }
        }
        else if (bigItemType == "Consume")
        {
            for (int i = 43; i >= 0; i--)
            {
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == itemName && UIManager.instance.warehouse_ItemSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;
                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity > loseQuantity)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity -= loseQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    return 1;
                }
                else if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity == loseQuantity)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity = 0;
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemName = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].bigItemType = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].smallItemType = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].price = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemExplain = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMagicPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddDefence = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].sharePosiible = false;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].coolTime = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].stayTime = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addDefence = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLevel = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceLevel = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceStack = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    return 1;
                }
            }
        }
        else if (bigItemType == "Etc")
        {
            for (int i = 43; i >= 0; i--)
            {
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == itemName && UIManager.instance.warehouse_ItemSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;
                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity > loseQuantity)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity -= loseQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    return 1;
                }
                else if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity == loseQuantity)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity = 0;
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemName = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].bigItemType = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].smallItemType = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].price = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemExplain = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].sharePosiible = false;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMagicPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddDefence = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].coolTime = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].stayTime = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addDefence = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLevel = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceLevel = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceStack = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    return 1;
                }
            }
        }
        else if (bigItemType == "Cash")
        {
            for (int i = 43; i >= 0; i--)
            {
                if (UIManager.instance.warehouse_ItemSlot[i].itemName == itemName && UIManager.instance.warehouse_ItemSlot[i].sharePosiible == sharePosiible)
                {
                    minEmpty = i;
                    break;
                }
            }
            if (minEmpty != -1)
            {
                if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity > loseQuantity)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity -= loseQuantity;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    return 1;
                }
                else if (UIManager.instance.warehouse_ItemSlot[minEmpty].quantity == loseQuantity)
                {
                    UIManager.instance.warehouse_ItemSlot[minEmpty].quantity = 0;
                    UIManager.instance.questWindow.QuestItemLose(itemName, minEmpty);
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemName = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].bigItemType = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].smallItemType = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].price = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].itemExplain = "null";
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMaxHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].sharePosiible = false;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddMagicPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].maxAddDefence = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].coolTime = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].stayTime = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxHP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addMaxMP = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addPower = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].addDefence = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLevel = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireSTR = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireHEL = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireINT = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].requireLUK = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceLevel = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].enhanceStack = 0;
                    UIManager.instance.warehouse_ItemSlot[minEmpty].Refresh();
                    return 1;
                }
            }
        }

        return 0;
    }


    /*
    //아이템을 얻었을 때 진행중인 퀘스트에서 얻은 아이템을 모으는 퀘스트가 있다면 진행상황을 바꿔준다 
    public void QuestItemGet()
    {
        for (int i = 0; i < 5; i++)
        {

            if (UIManager.instance.quest_IngSlot[i].needItemName == itemName)
            {

                UIManager.instance.quest_IngSlot[i].currentCollecITemNumber = UIManager.instance.item_ConsumeSlot[minEmpty].quantity;
                if (UIManager.instance.quest_IngSlot[i].currentCollecITemNumber >= UIManager.instance.quest_IngSlot[i].needItemNumber)
                {

                    UIManager.instance.quest_IngSlot[i].questState = true;
                }
                UIManager.instance.playCanvas.QuestingPanleRefresh();

            }


        }

    }

    //아이템을 잃었을 때 진행중인 퀘스트에서 아이템을 모으는 퀘스트가 있다면 상태를 바꾸고 완료였다가 아이템 개수가 요구치보다 떨어지면 상태를 미완료로 바꿈
    public void QuestItemLose()
    {
        for (int i = 0; i < 5; i++)
        {
            if (UIManager.instance.quest_IngSlot[i].needItemName == itemName)
            {
                UIManager.instance.quest_IngSlot[i].currentCollecITemNumber = UIManager.instance.item_ConsumeSlot[minEmpty].quantity;
                if (UIManager.instance.quest_IngSlot[i].currentCollecITemNumber < UIManager.instance.quest_IngSlot[i].needItemNumber)
                {


                    UIManager.instance.quest_IngSlot[i].questState = false;


                }
                UIManager.instance.playCanvas.QuestingPanleRefresh();


            }

        }

    }

    */
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
