using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestWindow : MonoBehaviour
{
    public int selectSlotNumber;

    public long rand1;
    public long rand2;
    public int rand3;

    public string getItemKind;
    public void Start()
    {

        selectSlotNumber = -1;

    }


    // 선택한 퀘스트 슬롯이 퀘스트 진행중인지 체크 
    // 퀘스트 완료 조건을 만족하는지 체크 
    // 랜덤 돌러서 경험치랑 돈 지급
    // 보상에 아이템도 있으면 장비인지 체크한다
    // 장비면 옵션 랜덤 돌려서 아이템템프에 덤기고 아니면 그냥 아이템템프에 아이템 정보를 넘긴다
    // 아이템템프getItem()시키고 NPC에 반복퀘스트가 아니면 퀘스트 상태를 바꿈 (NPC에게 어떻게 접근할지가 문제)
    // 퀘스트 슬롯 비우고 오른쪽 정보 나오는 곳도 비운다 
    public void QuestFinishButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        //퀘스트를 누른 상태이며 선택한 퀘스트 슬롯이 빈 슬롯이 아니라면 
        if (selectSlotNumber != -1 && UIManager.instance.quest_IngSlot[selectSlotNumber].questName != "null")
        {

            // 퀘스트 진행이 완료상태이면 
            if(UIManager.instance.quest_IngSlot[selectSlotNumber].questState == true)
            {
                // 경험치, 돈 보상을 랜덤을 돌린다 
                rand1 = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardExp);
                rand2 = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardMoney);
                //아이템 보상이 있는경우 
                if (UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName != "null")
                {
                    // 보상이 장비이면 스텟을 랜덤 돌리고 getItem();
                    if (UIManager.instance.quest_IngSlot[selectSlotNumber].bigItemType == "Equipment")
                    {
                        UIManager.instance.dropItemTemp.itemName = UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName;
                        UIManager.instance.dropItemTemp.bigItemType = UIManager.instance.quest_IngSlot[selectSlotNumber].bigItemType;
                        UIManager.instance.dropItemTemp.smallItemType = UIManager.instance.quest_IngSlot[selectSlotNumber].smallItemType;
                        UIManager.instance.dropItemTemp.price = UIManager.instance.quest_IngSlot[selectSlotNumber].price;
                        UIManager.instance.dropItemTemp.itemExplain = UIManager.instance.quest_IngSlot[selectSlotNumber].itemExplain;
                        UIManager.instance.dropItemTemp.sharePosiible = UIManager.instance.quest_IngSlot[selectSlotNumber].sharePosiible;
                        if(UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxHP != 0)
                           UIManager.instance.dropItemTemp.addMaxHP = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxHP + 1);
                        else
                          UIManager.instance.dropItemTemp.addMaxHP = UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxHP;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxMP != 0)
                            UIManager.instance.dropItemTemp.addMaxMP = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxMP + 1);
                        else
                            UIManager.instance.dropItemTemp.addSTR = UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxMP;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxMP != 0)
                            UIManager.instance.dropItemTemp.addSTR = (long)Random.Range(1,UIManager.instance.quest_IngSlot[selectSlotNumber].addSTR + 1);
                        else
                            UIManager.instance.dropItemTemp.addSTR = UIManager.instance.quest_IngSlot[selectSlotNumber].addSTR;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addHEL != 0)
                            UIManager.instance.dropItemTemp.addHEL = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addHEL + 1);
                        else
                            UIManager.instance.dropItemTemp.addHEL = UIManager.instance.quest_IngSlot[selectSlotNumber].addHEL;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addINT != 0)
                            UIManager.instance.dropItemTemp.addINT = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addINT + 1);
                        else

                            UIManager.instance.dropItemTemp.addINT = UIManager.instance.quest_IngSlot[selectSlotNumber].addINT;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addLUK != 0)
                            UIManager.instance.dropItemTemp.addLUK = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addLUK + 1);
                        else
                            UIManager.instance.dropItemTemp.addLUK = UIManager.instance.quest_IngSlot[selectSlotNumber].addLUK;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addPower != 0)
                            UIManager.instance.dropItemTemp.addPower = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addPower + 1);
                        else
                            UIManager.instance.dropItemTemp.addPower = UIManager.instance.quest_IngSlot[selectSlotNumber].addPower;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addMagicPower != 0)
                            UIManager.instance.dropItemTemp.addMagicPower = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addMagicPower + 1);
                        else
                            UIManager.instance.dropItemTemp.addMagicPower = UIManager.instance.quest_IngSlot[selectSlotNumber].addMagicPower;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addDefence != 0)
                            UIManager.instance.dropItemTemp.addDefence = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addDefence + 1);
                        else
                            UIManager.instance.dropItemTemp.addDefence = UIManager.instance.quest_IngSlot[selectSlotNumber].addDefence;

                        UIManager.instance.dropItemTemp.requireLevel = UIManager.instance.quest_IngSlot[selectSlotNumber].requireLevel;
                        UIManager.instance.dropItemTemp.requireSTR = UIManager.instance.quest_IngSlot[selectSlotNumber].requireSTR;
                        UIManager.instance.dropItemTemp.requireHEL = UIManager.instance.quest_IngSlot[selectSlotNumber].requireHEL;
                        UIManager.instance.dropItemTemp.requireINT = UIManager.instance.quest_IngSlot[selectSlotNumber].requireINT;
                        UIManager.instance.dropItemTemp.requireLUK = UIManager.instance.quest_IngSlot[selectSlotNumber].requireLUK;
                        UIManager.instance.dropItemTemp.quantity = UIManager.instance.quest_IngSlot[selectSlotNumber].quantity;
                        UIManager.instance.dropItemTemp.enhanceLevel = UIManager.instance.quest_IngSlot[selectSlotNumber].enhanceLevel;
                        UIManager.instance.dropItemTemp.enhanceStack = UIManager.instance.quest_IngSlot[selectSlotNumber].enhanceStack;
                        if (UIManager.instance.dropItemTemp.GetItem(1) != 1)
                        {
                            StartCoroutine(QeustFinishFailText());
                            return;

                        } // 아이템 획득 실패하면 리턴시킴 
                    }
                    // 보상이 장비가 아니고 다른 부위인 경우 
                    else
                    {
                        rand3 = (int)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].quantity + 1);
                        UIManager.instance.dropItemTemp.itemName = UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName;
                        UIManager.instance.dropItemTemp.bigItemType = UIManager.instance.quest_IngSlot[selectSlotNumber].bigItemType;
                        UIManager.instance.dropItemTemp.smallItemType = UIManager.instance.quest_IngSlot[selectSlotNumber].smallItemType;
                        UIManager.instance.dropItemTemp.price = UIManager.instance.quest_IngSlot[selectSlotNumber].price;
                        UIManager.instance.dropItemTemp.itemExplain = UIManager.instance.quest_IngSlot[selectSlotNumber].itemExplain;
                        UIManager.instance.dropItemTemp.maxAddHP = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddHP;
                        UIManager.instance.dropItemTemp.maxAddMP = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddMP;
                        UIManager.instance.dropItemTemp.maxAddMaxMP = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddMaxMP;
                        UIManager.instance.dropItemTemp.maxAddMaxHP = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddMaxHP;
                        UIManager.instance.dropItemTemp.maxAddSTR = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddSTR;
                        UIManager.instance.dropItemTemp.maxAddHEL = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddHEL;
                        UIManager.instance.dropItemTemp.maxAddINT = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddINT;
                        UIManager.instance.dropItemTemp.sharePosiible = UIManager.instance.quest_IngSlot[selectSlotNumber].sharePosiible;
                        UIManager.instance.dropItemTemp.maxAddLUK = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddLUK;
                        UIManager.instance.dropItemTemp.maxAddPower = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddPower;
                        UIManager.instance.dropItemTemp.maxAddMagicPower = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddMagicPower;
                        UIManager.instance.dropItemTemp.maxAddDefence = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddDefence;
                        UIManager.instance.dropItemTemp.coolTime = UIManager.instance.quest_IngSlot[selectSlotNumber].coolTime;
                        UIManager.instance.dropItemTemp.stayTime = UIManager.instance.quest_IngSlot[selectSlotNumber].stayTime;
                        UIManager.instance.dropItemTemp.quantity = rand3;
                        if (UIManager.instance.dropItemTemp.GetItem(UIManager.instance.quest_IngSlot[selectSlotNumber].quantity) != 1)
                        {
                            StartCoroutine(QeustFinishFailText());
                            return;

                        }
                    }
                }
                if (UIManager.instance.quest_IngSlot[selectSlotNumber].questKind == "GetItem")
                {
                    
                    UIManager.instance.itemTemp.itemName = UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName;
                    for(int i = 0; i < 32; i++)
                    {
                        if(UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName == UIManager.instance.item_EquipSlot[i].itemName)
                        {
                            getItemKind = "Equipment";
    
                            break;
                        }
                        else if (UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName == UIManager.instance.item_ConsumeSlot[i].itemName)
                        {
                            getItemKind = "Consume";
                            UIManager.instance.itemTemp.bigItemType = "Consume";
                            break;
                        }
                        else if (UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName == UIManager.instance.item_EtcSlot[i].itemName)
                        {
                            getItemKind = "Etc";
                            UIManager.instance.itemTemp.bigItemType = "Etc";
                            break;
                        }
                    }
                    if(getItemKind != "Equipment")
                    {

                        UIManager.instance.itemTemp.LoseItem(UIManager.instance.quest_IngSlot[selectSlotNumber].needItemNumber);
                    }

                } 
                    // 랜덤돌린 경험치 , 돈 지급 
                    CharacterManager.instance.GetExp(rand1);
                    UIManager.instance.hasMoney += rand2;
                    UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();

                     UIManager.instance.playCanvas.QuestingPanleRefresh();
                if (UIManager.instance.quest_IngSlot[selectSlotNumber].questType == "Story")
                    {
                        CharacterManager.instance.story += 1;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questName = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questType = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questKind = "null";
                        for(int i = 0; i < 12; i++)
                             UIManager.instance.quest_IngSlot[selectSlotNumber].questExplain[i] = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questNpc = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardExp = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardMoney = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questState = false;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needMeetingNPC = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingMonsterName = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needItemNumber = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingNumber = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].currentCollecITemNumber = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].currentHuntingMonsterNumber = 0;
                        UIManager.instance.quest_NameText.text = "퀘스트 이름";
                        UIManager.instance.quest_ContentText.text = "퀘스트 내용";
                        UIManager.instance.quest_ConditionText.text = "완료 조건";
                        UIManager.instance.quest_RewardText.text = "보상 : ";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questNameText.text = " ";
                    }
                    else if (UIManager.instance.quest_IngSlot[selectSlotNumber].questType == "Loop")
                    {
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questName = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questType = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questKind = "null";
                        for (int i = 0; i < 12; i++)
                          UIManager.instance.quest_IngSlot[selectSlotNumber].questExplain[i] = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questNpc = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardExp = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardMoney = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questState = false;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needMeetingNPC = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingMonsterName = "null";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needItemNumber = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingNumber = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].currentCollecITemNumber = 0;
                        UIManager.instance.quest_IngSlot[selectSlotNumber].currentHuntingMonsterNumber = 0;
                        UIManager.instance.quest_NameText.text = "퀘스트 이름";
                        UIManager.instance.quest_ContentText.text = "퀘스트 내용";
                        UIManager.instance.quest_ConditionText.text = "완료 조건";
                        UIManager.instance.quest_RewardText.text = "보상 : ";
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questNameText.text = " ";
                    // NPC퀘스트 중인거 다시 시작가능 상태로 
                }

                }
            }
        }


    //NCP -> 퀘스트창에서 특정 퀘스트를 클릭하고 퀘스트 완료를 누른 경우 
    public int npcQuestFinishButton()
    {
        //퀘스트를 누른 상태이며 선택한 퀘스트 슬롯이 빈 슬롯이 아니라면 
        if (selectSlotNumber != -1 && UIManager.instance.quest_IngSlot[selectSlotNumber].questName != "null")
        {

            // 퀘스트 진행이 완료상태이면 
            if (UIManager.instance.quest_IngSlot[selectSlotNumber].questState == true)
            {
                // 경험치, 돈 보상을 랜덤을 돌린다 
                rand1 = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardExp);
                rand2 = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardMoney);
                //아이템 보상이 있는경우 
                if (UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName != "null")
                {
                    // 보상이 장비이면 스텟을 랜덤 돌리고 getItem();
                    if (UIManager.instance.quest_IngSlot[selectSlotNumber].bigItemType == "Equipment")
                    {
                        UIManager.instance.dropItemTemp.itemName = UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName;
                        UIManager.instance.dropItemTemp.bigItemType = UIManager.instance.quest_IngSlot[selectSlotNumber].bigItemType;
                        UIManager.instance.dropItemTemp.smallItemType = UIManager.instance.quest_IngSlot[selectSlotNumber].smallItemType;
                        UIManager.instance.dropItemTemp.price = UIManager.instance.quest_IngSlot[selectSlotNumber].price;
                        UIManager.instance.dropItemTemp.itemExplain = UIManager.instance.quest_IngSlot[selectSlotNumber].itemExplain;
                        UIManager.instance.dropItemTemp.sharePosiible = UIManager.instance.quest_IngSlot[selectSlotNumber].sharePosiible;
                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxHP != 0)
                            UIManager.instance.dropItemTemp.addMaxHP = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxHP + 1);
                        else
                            UIManager.instance.dropItemTemp.addMaxHP = UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxHP;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxMP != 0)
                            UIManager.instance.dropItemTemp.addMaxMP = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxMP + 1);
                        else
                            UIManager.instance.dropItemTemp.addSTR = UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxMP;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addMaxMP != 0)
                            UIManager.instance.dropItemTemp.addSTR = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addSTR + 1);
                        else
                            UIManager.instance.dropItemTemp.addSTR = UIManager.instance.quest_IngSlot[selectSlotNumber].addSTR;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addHEL != 0)
                            UIManager.instance.dropItemTemp.addHEL = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addHEL + 1);
                        else
                            UIManager.instance.dropItemTemp.addHEL = UIManager.instance.quest_IngSlot[selectSlotNumber].addHEL;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addINT != 0)
                            UIManager.instance.dropItemTemp.addINT = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addINT + 1);
                        else

                            UIManager.instance.dropItemTemp.addINT = UIManager.instance.quest_IngSlot[selectSlotNumber].addINT;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addLUK != 0)
                            UIManager.instance.dropItemTemp.addLUK = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addLUK + 1);
                        else
                            UIManager.instance.dropItemTemp.addLUK = UIManager.instance.quest_IngSlot[selectSlotNumber].addLUK;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addPower != 0)
                            UIManager.instance.dropItemTemp.addPower = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addPower + 1);
                        else
                            UIManager.instance.dropItemTemp.addPower = UIManager.instance.quest_IngSlot[selectSlotNumber].addPower;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addMagicPower != 0)
                            UIManager.instance.dropItemTemp.addMagicPower = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addMagicPower + 1);
                        else
                            UIManager.instance.dropItemTemp.addMagicPower = UIManager.instance.quest_IngSlot[selectSlotNumber].addMagicPower;

                        if (UIManager.instance.quest_IngSlot[selectSlotNumber].addDefence != 0)
                            UIManager.instance.dropItemTemp.addDefence = (long)Random.Range(1, UIManager.instance.quest_IngSlot[selectSlotNumber].addDefence + 1);
                        else
                            UIManager.instance.dropItemTemp.addDefence = UIManager.instance.quest_IngSlot[selectSlotNumber].addDefence;

                        UIManager.instance.dropItemTemp.requireLevel = UIManager.instance.quest_IngSlot[selectSlotNumber].requireLevel;
                        UIManager.instance.dropItemTemp.requireSTR = UIManager.instance.quest_IngSlot[selectSlotNumber].requireSTR;
                        UIManager.instance.dropItemTemp.requireHEL = UIManager.instance.quest_IngSlot[selectSlotNumber].requireHEL;
                        UIManager.instance.dropItemTemp.requireINT = UIManager.instance.quest_IngSlot[selectSlotNumber].requireINT;
                        UIManager.instance.dropItemTemp.requireLUK = UIManager.instance.quest_IngSlot[selectSlotNumber].requireLUK;
                        UIManager.instance.dropItemTemp.quantity = UIManager.instance.quest_IngSlot[selectSlotNumber].quantity;
                        UIManager.instance.dropItemTemp.enhanceLevel = UIManager.instance.quest_IngSlot[selectSlotNumber].enhanceLevel;
                        UIManager.instance.dropItemTemp.enhanceStack = UIManager.instance.quest_IngSlot[selectSlotNumber].enhanceStack;
                        if (UIManager.instance.dropItemTemp.GetItem(1) != 1)
                        {
                            StartCoroutine(QeustFinishFailText());
                            return 0;

                        } // 아이템 획득 실패하면 리턴시킴 
                    }
                    // 보상이 장비가 아니고 다른 부위인 경우 
                    else
                    {
                        UIManager.instance.dropItemTemp.itemName = UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName;
                        UIManager.instance.dropItemTemp.bigItemType = UIManager.instance.quest_IngSlot[selectSlotNumber].bigItemType;
                        UIManager.instance.dropItemTemp.smallItemType = UIManager.instance.quest_IngSlot[selectSlotNumber].smallItemType;
                        UIManager.instance.dropItemTemp.price = UIManager.instance.quest_IngSlot[selectSlotNumber].price;
                        UIManager.instance.dropItemTemp.itemExplain = UIManager.instance.quest_IngSlot[selectSlotNumber].itemExplain;
                        UIManager.instance.dropItemTemp.maxAddHP = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddHP;
                        UIManager.instance.dropItemTemp.maxAddMP = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddMP;
                        UIManager.instance.dropItemTemp.maxAddMaxMP = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddMaxMP;
                        UIManager.instance.dropItemTemp.maxAddMaxHP = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddMaxHP;
                        UIManager.instance.dropItemTemp.maxAddSTR = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddSTR;
                        UIManager.instance.dropItemTemp.maxAddHEL = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddHEL;
                        UIManager.instance.dropItemTemp.maxAddINT = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddINT;
                        UIManager.instance.dropItemTemp.sharePosiible = UIManager.instance.quest_IngSlot[selectSlotNumber].sharePosiible;
                        UIManager.instance.dropItemTemp.maxAddLUK = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddLUK;
                        UIManager.instance.dropItemTemp.maxAddPower = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddPower;
                        UIManager.instance.dropItemTemp.maxAddMagicPower = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddMagicPower;
                        UIManager.instance.dropItemTemp.maxAddDefence = UIManager.instance.quest_IngSlot[selectSlotNumber].maxAddDefence;
                        UIManager.instance.dropItemTemp.coolTime = UIManager.instance.quest_IngSlot[selectSlotNumber].coolTime;
                        UIManager.instance.dropItemTemp.stayTime = UIManager.instance.quest_IngSlot[selectSlotNumber].stayTime;
                        UIManager.instance.dropItemTemp.quantity = UIManager.instance.quest_IngSlot[selectSlotNumber].quantity;
                        if (UIManager.instance.dropItemTemp.GetItem(UIManager.instance.quest_IngSlot[selectSlotNumber].quantity) != 1)
                        {
                            StartCoroutine(QeustFinishFailText());
                            return 0;

                        }
                    }
                }
                // 랜덤돌린 경험치 , 돈 지급 
                CharacterManager.instance.GetExp(rand1);
                UIManager.instance.hasMoney += rand2;
                SoundManager.instance.SoundEffectOn("SuccessSound", SoundManager.instance.soundEffectNumber);
                UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();

                UIManager.instance.playCanvas.QuestingPanleRefresh();
                if (UIManager.instance.quest_IngSlot[selectSlotNumber].questType == "Story")
                {
                    CharacterManager.instance.story += 1;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questName = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questType = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questKind = "null";
                    for (int i = 0; i < 12; i++)
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questExplain[i] = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questNpc = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardExp = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardMoney = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questState = false;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needMeetingNPC = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingMonsterName = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needItemNumber = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingNumber = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].currentCollecITemNumber = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].currentHuntingMonsterNumber = 0;
                    UIManager.instance.quest_NameText.text = "퀘스트 이름";
                    UIManager.instance.quest_ContentText.text = "퀘스트 내용";
                    UIManager.instance.quest_ConditionText.text = "완료 조건";
                    UIManager.instance.quest_RewardText.text = "보상 : ";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questNameText.text = " ";
                    return 1;
                }
                else if (UIManager.instance.quest_IngSlot[selectSlotNumber].questType == "Loop")
                {
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questName = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questType = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questKind = "null";
                    for (int i = 0; i < 12; i++)
                        UIManager.instance.quest_IngSlot[selectSlotNumber].questExplain[i] = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questNpc = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardExp = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardMoney = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questState = false;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needMeetingNPC = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingMonsterName = "null";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needItemNumber = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingNumber = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].currentCollecITemNumber = 0;
                    UIManager.instance.quest_IngSlot[selectSlotNumber].currentHuntingMonsterNumber = 0;
                    UIManager.instance.quest_NameText.text = "퀘스트 이름";
                    UIManager.instance.quest_ContentText.text = "퀘스트 내용";
                    UIManager.instance.quest_ConditionText.text = "완료 조건";
                    UIManager.instance.quest_RewardText.text = "보상 : ";
                    UIManager.instance.quest_IngSlot[selectSlotNumber].questNameText.text = " ";
                    return 1;
                    // NPC퀘스트 중인거 다시 시작가능 상태로 
                }

            }
        }
        return 0;
    }



    // 먼저 퀘스트가 진행 중인지 체크를 한다 
    // 퀘스트가 진행 중이라면 퀘스트 내용을 다 없앤다
    // 퀘스트 선택된 상태기 떄문에 그쪽 초기화시키고 슬롯 텍스트도 빈 상태로 바꿔준다 
    public void QuestGiveUpFinishButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.quest_IngSlot[selectSlotNumber].questName != "null")
        {

            UIManager.instance.quest_IngSlot[selectSlotNumber].questName = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questType = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questKind = "null";
            for (int i = 0; i < 12; i++)
                UIManager.instance.quest_IngSlot[selectSlotNumber].questExplain[i] = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questNpc = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardExp = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardMoney = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questState = false;
            UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].needMeetingNPC = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingMonsterName = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].needItemNumber = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingNumber = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].currentCollecITemNumber = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].currentHuntingMonsterNumber = 0;
            UIManager.instance.quest_NameText.text = "퀘스트 이름";
            UIManager.instance.quest_ContentText.text = "퀘스트 내용";
            UIManager.instance.quest_ConditionText.text = "완료 조건";
            UIManager.instance.quest_RewardText.text = "보상 : ";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questNameText.text = " ";
            UIManager.instance.quest_GiveUpEventPanel.gameObject.SetActive(false);

            UIManager.instance.playCanvas.QuestingPanleRefresh();
        }
        else
        {
            UIManager.instance.quest_GiveUpEventPanel.gameObject.SetActive(false);
        }

    }

    public int npcQuestGiveUpFinishButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.quest_IngSlot[selectSlotNumber].questName != "null")
        {

            UIManager.instance.quest_IngSlot[selectSlotNumber].questName = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questType = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questKind = "null";
            for (int i = 0; i < 12; i++)
                UIManager.instance.quest_IngSlot[selectSlotNumber].questExplain[i] = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questNpc = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardExp = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardMoney = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].questRewardItemName = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questState = false;
            UIManager.instance.quest_IngSlot[selectSlotNumber].needItemName = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].needMeetingNPC = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingMonsterName = "null";
            UIManager.instance.quest_IngSlot[selectSlotNumber].needItemNumber = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].needHuntingNumber = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].currentCollecITemNumber = 0;
            UIManager.instance.quest_IngSlot[selectSlotNumber].currentHuntingMonsterNumber = 0;
            UIManager.instance.quest_NameText.text = "퀘스트 이름";
            UIManager.instance.quest_ContentText.text = "퀘스트 내용";
            UIManager.instance.quest_ConditionText.text = "완료 조건";
            UIManager.instance.quest_RewardText.text = "보상 : ";
            UIManager.instance.quest_IngSlot[selectSlotNumber].questNameText.text = " ";
            UIManager.instance.quest_GiveUpEventPanel.gameObject.SetActive(false);

            UIManager.instance.playCanvas.QuestingPanleRefresh();
            return 1;

        }
        else
        {
            UIManager.instance.quest_GiveUpEventPanel.gameObject.SetActive(false);
            return 0;
        }

    }

    public void QuestGiveUpButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.quest_IngSlot[selectSlotNumber].questName != "null")
        {

            UIManager.instance.quest_GiveUpEventPanel.gameObject.SetActive(true);
        }
    }

    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.quest_NameText.text = "퀘스트 이름";
        UIManager.instance.quest_ContentText.text = "퀘스트 내용";
        UIManager.instance.quest_ConditionText.text = "완료 조건";
        UIManager.instance.quest_RewardText.text = "보상 : ";

        selectSlotNumber = -1;
        UIManager.instance.quest_GiveUpEventPanel.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    //아이템을 얻었을 때 진행중인 퀘스트에서 얻은 아이템을 모으는 퀘스트가 있다면 진행상황을 바꿔준다 
    public void QuestItemGet(string getItemName, int getItemSlot)
    {
        for (int i = 0; i < 5; i++)
        {

            if (UIManager.instance.quest_IngSlot[i].needItemName == getItemName)
            {
                if(UIManager.instance.item_ConsumeSlot[getItemSlot].itemName == UIManager.instance.quest_IngSlot[i].needItemName)
                  UIManager.instance.quest_IngSlot[i].currentCollecITemNumber = UIManager.instance.item_ConsumeSlot[getItemSlot].quantity;
                if (UIManager.instance.item_EtcSlot[getItemSlot].itemName == UIManager.instance.quest_IngSlot[i].needItemName)
                    UIManager.instance.quest_IngSlot[i].currentCollecITemNumber = UIManager.instance.item_EtcSlot[getItemSlot].quantity;
                if (UIManager.instance.item_EquipSlot[getItemSlot].itemName == UIManager.instance.quest_IngSlot[i].needItemName)
                    UIManager.instance.quest_IngSlot[i].currentCollecITemNumber = UIManager.instance.item_EquipSlot[getItemSlot].quantity;
                if (UIManager.instance.quest_IngSlot[i].currentCollecITemNumber >= UIManager.instance.quest_IngSlot[i].needItemNumber)
                {

                    UIManager.instance.quest_IngSlot[i].questState = true;
                }
                UIManager.instance.playCanvas.QuestingPanleRefresh();

            }


        }

    }

    //아이템을 잃었을 때 진행중인 퀘스트에서 아이템을 모으는 퀘스트가 있다면 상태를 바꾸고 완료였다가 아이템 개수가 요구치보다 떨어지면 상태를 미완료로 바꿈
    public void QuestItemLose(string loseItemName, int loseItemSlot)
    {
        for (int i = 0; i < 5; i++)
        {
            if (UIManager.instance.quest_IngSlot[i].needItemName == loseItemName)
            {
                UIManager.instance.quest_IngSlot[i].currentCollecITemNumber = UIManager.instance.item_ConsumeSlot[loseItemSlot].quantity;
                if (UIManager.instance.quest_IngSlot[i].currentCollecITemNumber < UIManager.instance.quest_IngSlot[i].needItemNumber)
                {


                    UIManager.instance.quest_IngSlot[i].questState = false;


                }
                UIManager.instance.playCanvas.QuestingPanleRefresh();


            }

        }

    }

    // 몬스터를 잡으면 이 함수를 호출하는데 잡은 몬스터가 퀘스트에 있는 몬스터와 같으면 수를 올려준다 
    public void MonsterHunting(string huntingMonsterName)
    {
        for(int i = 0; i < 5; i++)
        {
            if(UIManager.instance.quest_IngSlot[i].needHuntingMonsterName == huntingMonsterName)
            {
                UIManager.instance.quest_IngSlot[i].currentHuntingMonsterNumber += 1;
                if(UIManager.instance.quest_IngSlot[i].currentHuntingMonsterNumber >= UIManager.instance.quest_IngSlot[i].needHuntingNumber)
                {
                    UIManager.instance.quest_IngSlot[i].questState = true;
                }
            }
            UIManager.instance.playCanvas.QuestingPanleRefresh();
        }
    }


    public void NPCTalk(string npcName)
    {
        for(int i = 0; i < 5; i++)
        {
            if(UIManager.instance.quest_IngSlot[i].needMeetingNPC == npcName)
            {
                UIManager.instance.quest_IngSlot[i].questState = true;
                UIManager.instance.playCanvas.QuestingPanleRefresh();
            }

        }
    }


    public void QuestExplainNextButtonClick()
    {
        UIManager.instance.quest_IngSlot[selectSlotNumber].QuestExplainNextButton();
    }

    public void GiveUpEventExitButton()
    {
        UIManager.instance.quest_GiveUpEventPanel.gameObject.SetActive(false);
    }


    IEnumerator QeustFinishFailText()
    {
        UIManager.instance.quest_FailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.quest_FailText.gameObject.SetActive(false);
    }


}
