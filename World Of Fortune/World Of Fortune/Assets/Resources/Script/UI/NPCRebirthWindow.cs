using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRebirthWindow : MonoBehaviour
{
    public int rebirthGetStat;
    public string rebirthType;
    public int rebirthReturnScrollSlotNumber;

    public int typeRand;
    public long rewardRand;
    public long maxReward;

    public bool slotMax;

    // Start is called before the first frame update
    void Start()
    {
        rebirthReturnScrollSlotNumber = -1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // X버튼 눌렀을 떄 발생 
    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        rebirthReturnScrollSlotNumber = -1;
        slotMax = true;
        rewardRand = 0;
        maxReward = 0;
        typeRand = 0;
        UIManager.instance.rebirth_RebirthWarningPanel.gameObject.SetActive(false);
        UIManager.instance.rebirth_SelectRebirthTypeText.text = "";
        this.gameObject.SetActive(false);
        UIManager.instance.rebirth_CurrentLevelText.text = "현재 레벨  : ";
        UIManager.instance.rebirth_MaxGetText.text = "환생시 얻는 최대 수치 : ";
        rebirthType = "null";
        UIManager.instance.npcTalkWindow.gameObject.SetActive(true);
        UIManager.instance.rebirth_RebirthFinishPanel.gameObject.SetActive(false);
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
    }


    // AP환생버튼 클릭하면 레벨이 10보다 낮으면 환생을 할 수 없다라고 나오고
    // 10이상이면 환생창이뜬다 
    public void APRebirthButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        //레벨 10 이상이고 장비를 장착하고 있지 않은 상태면 환생창이 뜬다 
        if (CharacterManager.instance.Level >= 10 && CharacterManager.instance.isEquipArmor == false && CharacterManager.instance.isEquipEarring == false &&
            CharacterManager.instance.isEquipGlove == false && CharacterManager.instance.isEquipHelmet == false && CharacterManager.instance.isEquipNecklace == false
            && CharacterManager.instance.isEquipRing == false && CharacterManager.instance.isEquipShield == false && CharacterManager.instance.isEquipShoes == false
            && CharacterManager.instance.isEquipWeapon == false)
        {
            rebirthType = "AP";
            UIManager.instance.rebirth_SelectRebirthTypeText.text = "선택보상 : AP";
            UIManager.instance.rebirth_RebirthWarningPanel.gameObject.SetActive(true);
            return;
        }
        else
        {
            StartCoroutine(RebirthFailText());
            return;
        }

    }


    // Gold환생버튼 클릭하면 레벨이 10보다 낮으면 환생을 할 수 없다라고 나오고
    // 10이상이면 환생창이뜬다 
    public void GoldRebirthButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        //레벨 10 이상이고 장비를 장착하고 있지 않은 상태면 환생창이 뜬다 
        if (CharacterManager.instance.Level >= 10 && CharacterManager.instance.isEquipArmor == false && CharacterManager.instance.isEquipEarring == false &&
            CharacterManager.instance.isEquipGlove == false && CharacterManager.instance.isEquipHelmet == false && CharacterManager.instance.isEquipNecklace == false
            && CharacterManager.instance.isEquipRing == false && CharacterManager.instance.isEquipShield == false && CharacterManager.instance.isEquipShoes == false
            && CharacterManager.instance.isEquipWeapon == false)
        {
            rebirthType = "Gold";
            UIManager.instance.rebirth_SelectRebirthTypeText.text = "선택보상 : Gold";
            UIManager.instance.rebirth_RebirthWarningPanel.gameObject.SetActive(true);
            return;
        }
        else
        {
            StartCoroutine(RebirthFailText());
            return;
        }

    }


    // Clover환생버튼 클릭하면 레벨이 10보다 낮으면 환생을 할 수 없다라고 나오고
    // 10이상이면 환생창이뜬다 
    public void CloverRebirthButtonClick()
    {

        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        slotMax = true;
        for(int i = 0; i < 32; i++)
        {
            if(UIManager.instance.item_EtcSlot[i].itemName == "null" || UIManager.instance.item_EtcSlot[i].itemName == "Clover")
            {
                slotMax = false;
                break;
            }
        }



        //레벨 10 이상이고 장비를 장착하고 있지 않은 상태면 환생창이 뜬다 
        if (CharacterManager.instance.Level >= 10 && CharacterManager.instance.isEquipArmor == false && CharacterManager.instance.isEquipEarring == false &&
            CharacterManager.instance.isEquipGlove == false && CharacterManager.instance.isEquipHelmet == false && CharacterManager.instance.isEquipNecklace == false
            && CharacterManager.instance.isEquipRing == false && CharacterManager.instance.isEquipShield == false && CharacterManager.instance.isEquipShoes == false
            && CharacterManager.instance.isEquipWeapon == false && slotMax == false)
        {
            rebirthType = "Clover";
            UIManager.instance.rebirth_SelectRebirthTypeText.text = "선택보상 : Clover";
            UIManager.instance.rebirth_RebirthWarningPanel.gameObject.SetActive(true);
            return;
        }
        else
        {



            StartCoroutine(RebirthFailText());
            return;
        }



    }


    // Random환생버튼 클릭하면 레벨이 10보다 낮으면 환생을 할 수 없다라고 나오고
    // 10이상이면 환생창이뜬다 
    public void RandomRebirthButtonClick()
    {
        slotMax = true;
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        for (int i = 0; i < 32; i++)
        {
            if (UIManager.instance.item_EtcSlot[i].itemName == "null" || UIManager.instance.item_EtcSlot[i].itemName == "Clover")
            {
                slotMax = false;
                break;
            }
        }
        //레벨 10 이상이고 장비를 장착하고 있지 않은 상태면 환생창이 뜬다 
        if (CharacterManager.instance.Level >= 10 && CharacterManager.instance.isEquipArmor == false && CharacterManager.instance.isEquipEarring == false &&
            CharacterManager.instance.isEquipGlove == false && CharacterManager.instance.isEquipHelmet == false && CharacterManager.instance.isEquipNecklace == false
            && CharacterManager.instance.isEquipRing == false && CharacterManager.instance.isEquipShield == false && CharacterManager.instance.isEquipShoes == false
            && CharacterManager.instance.isEquipWeapon == false && slotMax == false)
        {
            rebirthType = "Random";
            UIManager.instance.rebirth_SelectRebirthTypeText.text = "선택보상 : Random";
            UIManager.instance.rebirth_RebirthWarningPanel.gameObject.SetActive(true);
            return;
        }
        else
        {
            StartCoroutine(RebirthFailText());
            return;
        }



    }

    // 환생하기 버튼을 누르면
    // 먼저 레벨을 체크한다 
    // 레벨에 따른 보상을 랜덤으로 돌린다 돌린결과에서 랜덤을 선택했다면 25%추가해준다
    // 기존 캐릭터 능력치를 저장해두고 초기화해준다(이때 주사위는 랜덤으로 돌아감)
    // 선택된 보상에 따라 보상이 지급된다 지급한 타입과 양은 저장해둔다
    // 리턴스크롤을 사용할건지 창이 뜬다(이 창에서는 리턴스크롤을 사용하면 기존 캐릭터 정보가 환생하기 전으로 돌아가고 보상지급된것도 사라짐)
    public void RebirthButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        rewardRand = 0;
        maxReward = 0;
        typeRand = 0;
        if (CharacterManager.instance.Level < 30)
        {
            //스텟초기화하고 환생 보너스 스텟 지급
            CharacterManager.instance.Level = 1;
            CharacterManager.instance.maxNeedExp = 5;
            CharacterManager.instance.currentExp = 0;
            CharacterManager.instance.needExp = 5;
            CharacterManager.instance.AP = CharacterManager.instance.rebirthAPStack;
            CharacterManager.instance.SP = 0;
            CharacterManager.instance.STR = Random.Range(5, 20);
            CharacterManager.instance.LUK = Random.Range(5, 20);
            CharacterManager.instance.INT = Random.Range(5, 20);
            CharacterManager.instance.HEL = Random.Range(5, 20);
            CharacterManager.instance.maxHP = Random.Range(25, 100);
            CharacterManager.instance.maxMP = Random.Range(25, 100);
            CharacterManager.instance.HP = CharacterManager.instance.maxHP;
            CharacterManager.instance.MP = CharacterManager.instance.maxMP;

            CharacterManager.instance.rebirthReturnScrollUseNumber = 0;

            //스킽 초기화 
            CharacterManager.instance.skillLevel1_1 = 0;
            CharacterManager.instance.skillLevel1_2 = 0;
            CharacterManager.instance.skillLevel1_3 = 0;
            CharacterManager.instance.skillLevel2_1 = 0;
            CharacterManager.instance.skillLevel2_2 = 0;
            CharacterManager.instance.skillLevel2_3 = 0;
            CharacterManager.instance.skillLevel2_4 = 0;
            CharacterManager.instance.skillLevel3_1 = 0;
            CharacterManager.instance.skillLevel3_2 = 0;
            CharacterManager.instance.skillLevel3_3 = 0;
            CharacterManager.instance.skillLevel3_4 = 0;
            CharacterManager.instance.skillLevel3_5 = 0;
            CharacterManager.instance.skillLevel4_1 = 0;
            CharacterManager.instance.skillLevel4_2 = 0;
            CharacterManager.instance.skillLevel4_3 = 0;
            CharacterManager.instance.skillLevel4_4 = 0;
            CharacterManager.instance.skillLevel4_5 = 0;
            CharacterManager.instance.skillLevel4_6 = 0;
            UIManager.instance.skill_1_1AttackEnhance.SkillReset();

            UIManager.instance.skillWindow.SkillReset();
            UIManager.instance.statWindow.Refresh();
            UIManager.instance.rebirth_RebirthWarningPanel.gameObject.SetActive(false);
            SoundManager.instance.StaySoundEffectON("RebirthIngSound", SoundManager.instance.staySoundEffectNumber);
            StartCoroutine(RebirthEffect());

            if (CharacterManager.instance.Level >= 30)
            {
                rebirthGetStat = (int)(((CharacterManager.instance.Level / 10) * (CharacterManager.instance.Level - 29)) * ((float)CharacterManager.instance.Level / 30));
                UIManager.instance.rebirth_MaxGetText.text = "환생시 얻는 최대 수치 : " + rebirthGetStat.ToString() + "(스텟기준)";
            }
            else
            {
                UIManager.instance.rebirth_MaxGetText.text = "환생시 얻는 최대 수치 : 0";
            }
            return;

        }
        // 보상을 레벨에 비례해서 랜덤으로 돌린다  ((Level / 10)  * (level - 29) ) * (level / 30)
        maxReward = ((CharacterManager.instance.Level / 10) * (CharacterManager.instance.Level - 29)) * (CharacterManager.instance.Level / 30);
        rewardRand = (long)Random.Range(1, maxReward + 1);
        // 랜덤을 선택하였으면 보상을 1,25배 추가한 다음에 어떤 보상을 지급할지 랜덤을 돌린다 
        if (rebirthType == "Random")
        {
            rewardRand = (long)(rewardRand * 1.25);
            typeRand = Random.Range(1, 4);
            if(typeRand == 1)
            {
                rebirthType = "AP";
            }
            if (typeRand == 2)
            {
                rebirthType = "Gold";
            }
            if (typeRand == 3)
            {
                rebirthType = "Clover";
            }
        }
                
        // 환생을 되돌릴 수 있으므로 임시 변수에 저장해둠 
        UIManager.instance.characterInfoTemp.Level = CharacterManager.instance.Level;
        UIManager.instance.characterInfoTemp.rebirthReturnScrollUseNumber = CharacterManager.instance.rebirthReturnScrollUseNumber;
        UIManager.instance.characterInfoTemp.maxNeedExp = CharacterManager.instance.maxNeedExp;
        UIManager.instance.characterInfoTemp.curretnExp = CharacterManager.instance.currentExp;
        UIManager.instance.characterInfoTemp.needExp = CharacterManager.instance.needExp;
        UIManager.instance.characterInfoTemp.AP = CharacterManager.instance.AP;
        UIManager.instance.characterInfoTemp.SP = CharacterManager.instance.SP;
        UIManager.instance.characterInfoTemp.STR = CharacterManager.instance.STR;
        UIManager.instance.characterInfoTemp.LUK = CharacterManager.instance.LUK;
        UIManager.instance.characterInfoTemp.INT = CharacterManager.instance.INT;
        UIManager.instance.characterInfoTemp.HEL = CharacterManager.instance.HEL;
        UIManager.instance.characterInfoTemp.maxHP = CharacterManager.instance.maxHP;
        UIManager.instance.characterInfoTemp.maxMP = CharacterManager.instance.maxMP;
        UIManager.instance.characterInfoTemp.HP = CharacterManager.instance.HP;
        UIManager.instance.characterInfoTemp.MP = CharacterManager.instance.MP;
        UIManager.instance.characterInfoTemp.skillLevel1_1 = CharacterManager.instance.skillLevel1_1;
        UIManager.instance.characterInfoTemp.skillLevel1_2 = CharacterManager.instance.skillLevel1_2;
        UIManager.instance.characterInfoTemp.skillLevel1_3 = CharacterManager.instance.skillLevel1_3;
        UIManager.instance.characterInfoTemp.skillLevel2_1 = CharacterManager.instance.skillLevel2_1;
        UIManager.instance.characterInfoTemp.skillLevel2_2 = CharacterManager.instance.skillLevel2_2;
        UIManager.instance.characterInfoTemp.skillLevel2_3 = CharacterManager.instance.skillLevel2_3;
        UIManager.instance.characterInfoTemp.skillLevel2_4 = CharacterManager.instance.skillLevel2_4;
        UIManager.instance.characterInfoTemp.skillLevel3_1 = CharacterManager.instance.skillLevel3_1;
        UIManager.instance.characterInfoTemp.skillLevel3_2 = CharacterManager.instance.skillLevel3_2;
        UIManager.instance.characterInfoTemp.skillLevel3_3 = CharacterManager.instance.skillLevel3_3;
        UIManager.instance.characterInfoTemp.skillLevel3_4 = CharacterManager.instance.skillLevel3_4;
        UIManager.instance.characterInfoTemp.skillLevel3_5 = CharacterManager.instance.skillLevel3_5;
        UIManager.instance.characterInfoTemp.skillLevel4_1 = CharacterManager.instance.skillLevel4_1;
        UIManager.instance.characterInfoTemp.skillLevel4_2 = CharacterManager.instance.skillLevel4_2;
        UIManager.instance.characterInfoTemp.skillLevel4_3 = CharacterManager.instance.skillLevel4_3;
        UIManager.instance.characterInfoTemp.skillLevel4_4 = CharacterManager.instance.skillLevel4_4;
        UIManager.instance.characterInfoTemp.skillLevel4_5 = CharacterManager.instance.skillLevel4_5;
        UIManager.instance.characterInfoTemp.skillLevel4_6 = CharacterManager.instance.skillLevel4_6;


        /// 타입이 ap인경우 누적 ap를 증가시킨다 
        if(rebirthType == "AP")
        {

            CharacterManager.instance.rebirthAPStack += rewardRand;
            UIManager.instance.rebirth_RebirthRewardTypeText.text = "AP";
            UIManager.instance.rebirth_RebirthRewardAmountText.text = rewardRand.ToString();

            // 보상이 gold인 경우 골드를 지급해준다 
        }
        else if(rebirthType == "Gold")
        {
            UIManager.instance.hasMoney += (rewardRand * 500000);
            UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
            UIManager.instance.rebirth_RebirthRewardTypeText.text = "Gold";
            UIManager.instance.rebirth_RebirthRewardAmountText.text = rewardRand * 500000 + "골드";
            // 보상이 Clover인 경우 clover를 지급한다 아이템 창이 꽉 차면 애초에 여기 못 옴 
        }
        else if(rebirthType == "Clover")
        {
            UIManager.instance.rebirth_RebirthRewardTypeText.text = "Clover"; 
            UIManager.instance.rebirth_RebirthRewardAmountText.text = rewardRand + "개";
            UIManager.instance.itemTemp.itemName = "Clover";
            UIManager.instance.itemTemp.bigItemType = "Etc";
            UIManager.instance.itemTemp.smallItemType = "null";
            UIManager.instance.itemTemp.price = 100000;
            UIManager.instance.itemTemp.itemExplain = "네잎이 아니라 행운이 찾아올거 같지 않지만 행운의 아이템으로 교환할 수 있다,";
            UIManager.instance.itemTemp.maxAddHP = 0;
            UIManager.instance.itemTemp.maxAddMP = 0;
            UIManager.instance.itemTemp.maxAddMaxMP = 0;
            UIManager.instance.itemTemp.maxAddMaxHP = 0;
            UIManager.instance.itemTemp.maxAddSTR = 0;
            UIManager.instance.itemTemp.maxAddHEL = 0;
            UIManager.instance.itemTemp.maxAddINT = 0;
            UIManager.instance.itemTemp.sharePosiible = true;
            UIManager.instance.itemTemp.maxAddLUK = 0;
            UIManager.instance.itemTemp.maxAddPower = 0;
            UIManager.instance.itemTemp.maxAddMagicPower = 0;
            UIManager.instance.itemTemp.maxAddDefence = 0;
            UIManager.instance.itemTemp.coolTime = 0;
            UIManager.instance.itemTemp.stayTime = 0;
            UIManager.instance.itemTemp.addMaxHP = 0;
            UIManager.instance.itemTemp.addMaxMP = 0;
            UIManager.instance.itemTemp.addSTR = 0;
            UIManager.instance.itemTemp.addHEL = 0;
            UIManager.instance.itemTemp.addINT = 0;
            UIManager.instance.itemTemp.addLUK = 0;
            UIManager.instance.itemTemp.addPower = 0;
            UIManager.instance.itemTemp.addMagicPower = 0;
            UIManager.instance.itemTemp.addDefence = 0;
            UIManager.instance.itemTemp.requireLevel = 0;
            UIManager.instance.itemTemp.requireAccumulateLevel = 0;
            UIManager.instance.itemTemp.requireSTR = 0;
            UIManager.instance.itemTemp.requireHEL = 0;
            UIManager.instance.itemTemp.requireINT = 0;
            UIManager.instance.itemTemp.requireLUK = 0;
            UIManager.instance.itemTemp.quantity = (int)rewardRand;
            UIManager.instance.itemTemp.enhanceLevel = 0;
            UIManager.instance.itemTemp.enhanceStack = 0;
            //기타창이 꽉차있으면 애초에 여기 못옴
            UIManager.instance.itemTemp.GetItem((int)rewardRand);
            
        }

        //스텟초기화하고 환생 보너스 스텟 지급
        CharacterManager.instance.Level = 1;
        CharacterManager.instance.maxNeedExp = 5;
        CharacterManager.instance.currentExp = 0;
        CharacterManager.instance.needExp = 5;
        CharacterManager.instance.AP = CharacterManager.instance.rebirthAPStack;
        CharacterManager.instance.SP = 0;
        CharacterManager.instance.STR = Random.Range(5, 20);
        CharacterManager.instance.LUK = Random.Range(5, 20);
        CharacterManager.instance.INT = Random.Range(5, 20);
        CharacterManager.instance.HEL = Random.Range(5, 20);
        CharacterManager.instance.maxHP = Random.Range(25, 100);
        CharacterManager.instance.maxMP = Random.Range(25, 100);
        CharacterManager.instance.HP = CharacterManager.instance.maxHP;
        CharacterManager.instance.MP = CharacterManager.instance.maxMP;

        CharacterManager.instance.rebirthReturnScrollUseNumber = 0;

        //스킽 초기화 
        CharacterManager.instance.skillLevel1_1 = 0;
        CharacterManager.instance.skillLevel1_2 = 0;
        CharacterManager.instance.skillLevel1_3 = 0;
        CharacterManager.instance.skillLevel2_1 = 0;
        CharacterManager.instance.skillLevel2_2 = 0;
        CharacterManager.instance.skillLevel2_3 = 0;
        CharacterManager.instance.skillLevel2_4 = 0;
        CharacterManager.instance.skillLevel3_1 = 0;
        CharacterManager.instance.skillLevel3_2 = 0;
        CharacterManager.instance.skillLevel3_3 = 0;
        CharacterManager.instance.skillLevel3_4 = 0;
        CharacterManager.instance.skillLevel3_5 = 0;
        CharacterManager.instance.skillLevel4_1 = 0;
        CharacterManager.instance.skillLevel4_2 = 0;
        CharacterManager.instance.skillLevel4_3 = 0;
        CharacterManager.instance.skillLevel4_4 = 0;
        CharacterManager.instance.skillLevel4_5 = 0;
        CharacterManager.instance.skillLevel4_6 = 0;
        UIManager.instance.skill_1_1AttackEnhance.SkillReset();

        UIManager.instance.skillWindow.SkillReset();
        UIManager.instance.statWindow.Refresh();
        UIManager.instance.rebirth_RebirthWarningPanel.gameObject.SetActive(false);
        SoundManager.instance.StaySoundEffectON("RebirthIngSound", SoundManager.instance.staySoundEffectNumber);
        StartCoroutine(RebirthEffect());
        UIManager.instance.rebirth_RebirthFinishPanel.gameObject.SetActive(true);

        if (CharacterManager.instance.Level >= 30)
        {
            rebirthGetStat = (int)(((CharacterManager.instance.Level / 10) * (CharacterManager.instance.Level - 29)) * ((float)CharacterManager.instance.Level / 30));
            UIManager.instance.rebirth_MaxGetText.text = "환생시 얻는 최대 수치 : " + rebirthGetStat.ToString() + "(스텟기준)";
        }
        else
        {
            UIManager.instance.rebirth_MaxGetText.text = "환생시 얻는 최대 수치 : 0";
        }
        return;

    }


    public void RebirthWarningPanelExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.rebirth_RebirthWarningPanel.gameObject.SetActive(false);
    }


    // 리턴스크롤 버튼을 클릭했을때 
    //먼저 리턴스크롤이 있는지 체크를 한다 없으면 리턴 
    // 있으면 리턴스크롤을1개 없앤다 
    // 환생전의 정보로 되돌린다 
    public void RebirthReturnScrollUseButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        // 리턴스크롤이 없으면 리턴 
        if (rebirthReturnScrollSlotNumber == -1 || CharacterManager.instance.rebrithNumber >= 5)
        {
            StartCoroutine(RebirthReturnScrollUseFailText());
            return;
        }


        //리턴스크롤을 하나 없애고 
        UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].quantity -= 1;
        if (UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].quantity == 0)
        {


            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].itemName = "null";
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].bigItemType = "null";
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].smallItemType = "null";
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].price = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].quantity = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].itemExplain = "null";
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].sharePosiible = false;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddHP = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddMP = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddMaxMP = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddMaxHP = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddSTR = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddHEL = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddINT = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddLUK = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddPower = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddMagicPower = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].maxAddDefence = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].coolTime = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].stayTime = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].addMaxHP = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].addMaxMP = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].addSTR = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].addHEL = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].addINT = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].addLUK = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].addPower = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].addDefence = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].requireLevel = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].requireSTR = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].requireHEL = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].requireINT = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].requireLUK = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].enhanceLevel = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].enhanceStack = 0;
            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].Refresh();
            rebirthReturnScrollSlotNumber = -1;
            UIManager.instance.rebirth_RebirthReturnScrollQuantityText.text = "0";
        }
        else
        {

            UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].Refresh();
            UIManager.instance.rebirth_RebirthReturnScrollQuantityText.text = UIManager.instance.item_EtcSlot[rebirthReturnScrollSlotNumber].quantity.ToString();

        }


        if (rebirthType == "AP")
        {

            CharacterManager.instance.rebirthAPStack -= rewardRand;


            // 보상이 gold인 경우 골드를 지급해준다 
        }
        else if (rebirthType == "Gold")
        {
            UIManager.instance.hasMoney -= (rewardRand * 500000);
            UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();

            // 보상이 Clover인 경우 clover를 지급한다 아이템 창이 꽉 차면 애초에 여기 못 옴 
        }
        else if (rebirthType == "Clover")
        {
            Debug.Log("클로버 리턴");
            UIManager.instance.itemTemp.itemName = "Clover";
            UIManager.instance.itemTemp.bigItemType = "Etc";
            UIManager.instance.itemTemp.smallItemType = "null";
            UIManager.instance.itemTemp.price = 100000;
            UIManager.instance.itemTemp.itemExplain = "네잎이 아니라 행운이 찾아올거 같지 않지만 행운의 아이템으로 교환할 수 있다,";
            UIManager.instance.itemTemp.maxAddHP = 0;
            UIManager.instance.itemTemp.maxAddMP = 0;
            UIManager.instance.itemTemp.maxAddMaxMP = 0;
            UIManager.instance.itemTemp.maxAddMaxHP = 0;
            UIManager.instance.itemTemp.maxAddSTR = 0;
            UIManager.instance.itemTemp.maxAddHEL = 0;
            UIManager.instance.itemTemp.maxAddINT = 0;
            UIManager.instance.itemTemp.sharePosiible = true;
            UIManager.instance.itemTemp.maxAddLUK = 0;
            UIManager.instance.itemTemp.maxAddPower = 0;
            UIManager.instance.itemTemp.maxAddMagicPower = 0;
            UIManager.instance.itemTemp.maxAddDefence = 0;
            UIManager.instance.itemTemp.coolTime = 0;
            UIManager.instance.itemTemp.stayTime = 0;
            UIManager.instance.itemTemp.addMaxHP = 0;
            UIManager.instance.itemTemp.addMaxMP = 0;
            UIManager.instance.itemTemp.addSTR = 0;
            UIManager.instance.itemTemp.addHEL = 0;
            UIManager.instance.itemTemp.addINT = 0;
            UIManager.instance.itemTemp.addLUK = 0;
            UIManager.instance.itemTemp.addPower = 0;
            UIManager.instance.itemTemp.addMagicPower = 0;
            UIManager.instance.itemTemp.addDefence = 0;
            UIManager.instance.itemTemp.requireLevel = 0;
            UIManager.instance.itemTemp.requireAccumulateLevel = 0;
            UIManager.instance.itemTemp.requireSTR = 0;
            UIManager.instance.itemTemp.requireHEL = 0;
            UIManager.instance.itemTemp.requireINT = 0;
            UIManager.instance.itemTemp.requireLUK = 0;
            UIManager.instance.itemTemp.quantity = (int)rewardRand;
            UIManager.instance.itemTemp.enhanceLevel = 0;
            UIManager.instance.itemTemp.enhanceStack = 0;
            //기타창이 꽉차있으면 애초에 여기 못옴
            Debug.Log(UIManager.instance.itemTemp.LoseItem((int)rewardRand));


        }


        CharacterManager.instance.Level =UIManager.instance.characterInfoTemp.Level;
        CharacterManager.instance.rebirthReturnScrollUseNumber = UIManager.instance.characterInfoTemp.rebirthReturnScrollUseNumber + 1;
        CharacterManager.instance.maxNeedExp = UIManager.instance.characterInfoTemp.maxNeedExp;
        CharacterManager.instance.currentExp = UIManager.instance.characterInfoTemp.curretnExp;
        CharacterManager.instance.needExp = UIManager.instance.characterInfoTemp.needExp;
        CharacterManager.instance.AP = UIManager.instance.characterInfoTemp.AP;
        CharacterManager.instance.SP = UIManager.instance.characterInfoTemp.SP;
        CharacterManager.instance.STR = UIManager.instance.characterInfoTemp.STR;
        CharacterManager.instance.LUK = UIManager.instance.characterInfoTemp.LUK;
        CharacterManager.instance.INT = UIManager.instance.characterInfoTemp.INT;
        CharacterManager.instance.HEL = UIManager.instance.characterInfoTemp.HEL;
        CharacterManager.instance.maxHP = UIManager.instance.characterInfoTemp.maxHP;
        CharacterManager.instance.maxMP = UIManager.instance.characterInfoTemp.maxMP;
        CharacterManager.instance.HP = UIManager.instance.characterInfoTemp.HP;
        CharacterManager.instance.MP = UIManager.instance.characterInfoTemp.MP;
        CharacterManager.instance.skillLevel1_1 = UIManager.instance.characterInfoTemp.skillLevel1_1;
        CharacterManager.instance.skillLevel1_2 = UIManager.instance.characterInfoTemp.skillLevel1_2;
        CharacterManager.instance.skillLevel1_3 = UIManager.instance.characterInfoTemp.skillLevel1_3;
        CharacterManager.instance.skillLevel2_1 = UIManager.instance.characterInfoTemp.skillLevel2_1;
        CharacterManager.instance.skillLevel2_2 = UIManager.instance.characterInfoTemp.skillLevel2_2;
        CharacterManager.instance.skillLevel2_3 = UIManager.instance.characterInfoTemp.skillLevel2_3;
        CharacterManager.instance.skillLevel2_4 = UIManager.instance.characterInfoTemp.skillLevel2_4;
        CharacterManager.instance.skillLevel3_1 = UIManager.instance.characterInfoTemp.skillLevel3_1;
        CharacterManager.instance.skillLevel3_2 = UIManager.instance.characterInfoTemp.skillLevel3_2;
        CharacterManager.instance.skillLevel3_3 = UIManager.instance.characterInfoTemp.skillLevel3_3;
        CharacterManager.instance.skillLevel3_4 = UIManager.instance.characterInfoTemp.skillLevel3_4;
        CharacterManager.instance.skillLevel3_5 = UIManager.instance.characterInfoTemp.skillLevel3_5;
        CharacterManager.instance.skillLevel4_1 = UIManager.instance.characterInfoTemp.skillLevel4_1;
        CharacterManager.instance.skillLevel4_2 = UIManager.instance.characterInfoTemp.skillLevel4_2;
        CharacterManager.instance.skillLevel4_3 = UIManager.instance.characterInfoTemp.skillLevel4_3;
        CharacterManager.instance.skillLevel4_4 = UIManager.instance.characterInfoTemp.skillLevel4_4;
        CharacterManager.instance.skillLevel4_5 = UIManager.instance.characterInfoTemp.skillLevel4_5;
        CharacterManager.instance.skillLevel4_6 = UIManager.instance.characterInfoTemp.skillLevel4_6;
        

        UIManager.instance.statWindow.Refresh();
        UIManager.instance.skill_1_1AttackEnhance.SKillReturnReset();
        UIManager.instance.rebirth_RebirthFinishPanel.gameObject.SetActive(false);
        UIManager.instance.rebirth_CurrentLevelText.text = "현재 레벨  : " + CharacterManager.instance.Level.ToString();



        if(CharacterManager.instance.Level >= 30)
        {
            rebirthGetStat = (int)(((CharacterManager.instance.Level / 10) * (CharacterManager.instance.Level - 29)) * ((float)CharacterManager.instance.Level / 30));
            UIManager.instance.rebirth_MaxGetText.text = "환생시 얻는 최대 수치 : " + rebirthGetStat.ToString() + "(스텟기준)";
        }
        else
        {
            UIManager.instance.rebirth_MaxGetText.text = "환생시 얻는 최대 수치 : 0" ;
        }


    }

    public void RebirthFinishPanelExitButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.rebirth_RebirthFinishPanel.gameObject.SetActive(false);


    }


    //레벨이 낮으면 호출되는 코루틴 
    public IEnumerator RebirthFailText()
    {

        UIManager.instance.rebirth_RebirthFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.rebirth_RebirthFailText.gameObject.SetActive(false);
    }
    

    //리턴스크롤 사용 실패 
     public IEnumerator RebirthReturnScrollUseFailText()
    {

        UIManager.instance.rebirth_ReturnScrollUseFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.rebirth_ReturnScrollUseFailText.gameObject.SetActive(false);
    }

    //환생 시 나오는 이펙트 코루틴 
    public IEnumerator RebirthEffect()
    {

        UIManager.instance.rebirth_RebirthEffect1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.rebirth_RebirthEffect1.gameObject.SetActive(false);
        UIManager.instance.rebirth_RebirthEffect2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.rebirth_RebirthEffect2.gameObject.SetActive(false);
        UIManager.instance.rebirth_RebirthEffect1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.rebirth_RebirthEffect1.gameObject.SetActive(false);
        UIManager.instance.rebirth_RebirthEffect2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.rebirth_RebirthEffect2.gameObject.SetActive(false);
        UIManager.instance.rebirth_RebirthEffect1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.rebirth_RebirthEffect1.gameObject.SetActive(false);
        UIManager.instance.rebirth_RebirthEffect2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        UIManager.instance.rebirth_RebirthEffect2.gameObject.SetActive(false);
        UIManager.instance.rebirth_RebirthEffect1.gameObject.SetActive(false);
        SoundManager.instance.StaySoundEffectOFF("RebirthIngSound");
        SoundManager.instance.SoundEffectOn("SuccessSound", SoundManager.instance.soundEffectNumber);
    }

}
