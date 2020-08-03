using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCEnhanceWindow : MonoBehaviour
{

    public bool setActive;
    public bool enhanceResult;
    public bool enhanceProtectStoneUse;
    public int slotNumber;  // 아이템을 클릭한 상태에서 선택완료 버튼을 누르면 클릭한 슬롯의 번호가 여기로 넘겨진다 
    public int clickkSlotNumber; // 아이템을 클릭하면 그 슬롯의 번호가 여기에 넘겨진다 

    public int enhanceStoneSlotNumber;  // 강화석있는 슬롯넘어 (없으면 -1)
    public int enhanceProtectStoneSlotNumber;// 강화보호석있는 슬롯넘버 (없으면 -1)
    public int enhancePotionSlotNumber;// 강화의비약 있는 슬롯넘버 (없으면 -1)
    public int returnScrollSlotNumber;// 리턴스크롤 있는 슬롯넘버 (없으면 -1)

    public int enhanceLevel1;//강화단계 1자리수 
    public int enhanceLevel; // 총 강화단계 ㄴ
    public int enhanceLevel10; // 강화단계 10자리수 

    public long enhanceChance;  // 랜덤돌린값이 이것보다 작아야 강화성공 

    public long randomResult; // 강화확률 랜덤으로 돌린 숫자
    public float randomOption; // 강화성공했을때 옵션 증가치를 랜덤으로 돌린다 

    public long changeAddMaxHP;
    public long changeaddMaxMP;
    public long changeAddSTR;
    public long changeAddHEL;
    public long changeAddINT;
    public long changeAddLUK;
    public long changeAddPower;
    public long changeAddMagicPower;
    public long changeAddDefence;
    // 강화 후 변경된 옵션들 









    // Start is called before the first frame update
    void Start()
    {
        //초기화 
        slotNumber = -1;
        clickkSlotNumber = -1;
        enhanceStoneSlotNumber = -1;
        enhanceProtectStoneSlotNumber = -1;
        enhancePotionSlotNumber = -1;
        returnScrollSlotNumber = -1;
        enhanceLevel = 0;
        enhanceLevel1 = 0;
        enhanceLevel10 = 0;
        enhanceProtectStoneUse = false;

    }
    
    // 나가기버튼 누르면 
    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        // 원래상태로 되돌림 
        setActive = false;
        UIManager.instance.enhance_EnhanceSuccessPanel.gameObject.SetActive(false);
        UIManager.instance.enhance_SelectItemPanel.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        slotNumber = -1;
        clickkSlotNumber = -1;
        enhanceStoneSlotNumber = -1;
        enhanceProtectStoneSlotNumber = -1;
        enhancePotionSlotNumber = -1;
        returnScrollSlotNumber = -1;
        enhanceLevel = 0;
        enhanceLevel1 = 0;
        enhanceLevel10 = 0;
        enhanceProtectStoneUse = false;
        UIManager.instance.enhance_SelectItemNameText.text = "강화 아이템";
        UIManager.instance.enhance_SelectItemImage.sprite = null;
        UIManager.instance.enhance_SelectItemImage.color = new Color(1, 1, 1, 0);
        UIManager.instance.npcTalkWindow.gameObject.SetActive(true);
        UIManager.instance.enhance_EnhancePotionStackText.text = " "; 

    }
    

    // 아이템 선택창에서 나가기 버튼 누르면 그 창을 그냥 닫는다 
    public void SelectPanelExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        setActive = false;
        UIManager.instance.enhance_SelectItemPanel.gameObject.SetActive(false);

    }

    // 선택 버튼을 누르면
    // 클릭한 슬롯의 번호가 넘겨지고
    // 강화할 아이템의 이미지와 이름이 장비창[클릭한 슬롯 번호] 껄로 바뀐다 
    public void SelectPanelSelectButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        slotNumber = clickkSlotNumber;
        UIManager.instance.enhance_SelectItemImage.color = new Color(1, 1, 1, 1);
        UIManager.instance.enhance_SelectItemImage.sprite = UIManager.instance.item_EquipSlot[slotNumber].itemImage.sprite;
        UIManager.instance.enhance_SelectItemNameText.text = UIManager.instance.item_EquipSlot[slotNumber].itemName;
        UIManager.instance.enhance_SelectItemPanel.gameObject.SetActive(false);
        setActive = false;
        UIManager.instance.enhance_EnhancePotionStackText.text = "강화의 비약 " +UIManager.instance.item_EquipSlot[slotNumber].enhanceStack.ToString() + " 중첩 ";

    }

    //강화버튼을 누르면 먼저 아이템을 클릭했는지, 강화석은 있는지 등을 확인한다 없으면 바로 리턴   
    //아이템의 정보를 ITEMtEMP에 넘긴다
    // 랜덤 돌리고 아이템의 강화상태를  확인해서 enhanceLevel에 넣는다 
    // 랜덤 돌린값이 강화확률보다 높으면 성공 낮으면 실패 
    // 성공의 경우 강화레벨에 비례해서 능력치 상승시켜서 useItemTemp에 넣어준다 , 강화석 -- 
    // -> slotNumber에 useItemTemp정보를 넣어준다 그리고 강화 확정할껀지 SUccess패널을 띄워준다 여기서 
    // -> 리턴스크롤이 있고 리턴스크롤을 사용버튼을 눌러주면 slotNumber에 ItemTemp정보를 넣어준다 
    // 실패의 경우 강화보호제 사용이 체크되어있는경우는 강화석 -- 강화보호석 -- 해주고 
    // -> slotNumber는 그대로 둔다 체크되어있지 않으면 slotNumber를 Null상태로 바꿔준다 
    public void EnhanceButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        enhanceLevel = 0;
        enhanceLevel1 = 0;
        enhanceLevel10 = 0;
        enhanceResult = false;
        //강화석 없거나 클릭하지 않은 상태이면 강화를 진행할 수 없으므로 리턴시킨다 
        if (slotNumber == -1 || enhanceStoneSlotNumber == -1)
        {

            StartCoroutine(EnhanceFailText());
            return;
        }
        // 강화석과 선택한 아이템이 있으면 먼저 그 아이템을 itemTemp에 넘긴다 
        UIManager.instance.itemTemp.itemName = UIManager.instance.item_EquipSlot[slotNumber].itemName;
        UIManager.instance.itemTemp.bigItemType = UIManager.instance.item_EquipSlot[slotNumber].bigItemType;
        UIManager.instance.itemTemp.smallItemType = UIManager.instance.item_EquipSlot[slotNumber].smallItemType;
        UIManager.instance.itemTemp.price = UIManager.instance.item_EquipSlot[slotNumber].price;
        UIManager.instance.itemTemp.itemExplain = UIManager.instance.item_EquipSlot[slotNumber].itemExplain;
        UIManager.instance.itemTemp.maxAddHP = UIManager.instance.item_EquipSlot[slotNumber].maxAddHP;
        UIManager.instance.itemTemp.maxAddMP = UIManager.instance.item_EquipSlot[slotNumber].maxAddMP;
        UIManager.instance.itemTemp.maxAddMaxMP = UIManager.instance.item_EquipSlot[slotNumber].maxAddMaxMP;
        UIManager.instance.itemTemp.maxAddMaxHP = UIManager.instance.item_EquipSlot[slotNumber].maxAddMaxHP;
        UIManager.instance.itemTemp.maxAddSTR = UIManager.instance.item_EquipSlot[slotNumber].maxAddSTR;
        UIManager.instance.itemTemp.maxAddHEL = UIManager.instance.item_EquipSlot[slotNumber].maxAddHEL;
        UIManager.instance.itemTemp.maxAddINT = UIManager.instance.item_EquipSlot[slotNumber].maxAddINT;
        UIManager.instance.itemTemp.sharePosiible = UIManager.instance.item_EquipSlot[slotNumber].sharePosiible;
        UIManager.instance.itemTemp.maxAddLUK = UIManager.instance.item_EquipSlot[slotNumber].maxAddLUK;
        UIManager.instance.itemTemp.maxAddPower = UIManager.instance.item_EquipSlot[slotNumber].maxAddPower;
        UIManager.instance.itemTemp.maxAddMagicPower = UIManager.instance.item_EquipSlot[slotNumber].maxAddMagicPower;
        UIManager.instance.itemTemp.maxAddDefence = UIManager.instance.item_EquipSlot[slotNumber].maxAddDefence;
        UIManager.instance.itemTemp.coolTime = UIManager.instance.item_EquipSlot[slotNumber].coolTime;
        UIManager.instance.itemTemp.stayTime = UIManager.instance.item_EquipSlot[slotNumber].stayTime;
        UIManager.instance.itemTemp.addMaxHP = UIManager.instance.item_EquipSlot[slotNumber].addMaxHP;
        UIManager.instance.itemTemp.addMaxMP = UIManager.instance.item_EquipSlot[slotNumber].addMaxMP;
        UIManager.instance.itemTemp.addSTR = UIManager.instance.item_EquipSlot[slotNumber].addSTR;
        UIManager.instance.itemTemp.addHEL = UIManager.instance.item_EquipSlot[slotNumber].addHEL;
        UIManager.instance.itemTemp.addINT = UIManager.instance.item_EquipSlot[slotNumber].addINT;
        UIManager.instance.itemTemp.addLUK = UIManager.instance.item_EquipSlot[slotNumber].addLUK;
        UIManager.instance.itemTemp.addPower = UIManager.instance.item_EquipSlot[slotNumber].addPower;
        UIManager.instance.itemTemp.addMagicPower = UIManager.instance.item_EquipSlot[slotNumber].addMagicPower;
        UIManager.instance.itemTemp.addDefence = UIManager.instance.item_EquipSlot[slotNumber].addDefence;
        UIManager.instance.itemTemp.requireLevel = UIManager.instance.item_EquipSlot[slotNumber].requireLevel;
        UIManager.instance.itemTemp.requireAccumulateLevel = UIManager.instance.item_EquipSlot[slotNumber].requireAccumulateLevel;
        UIManager.instance.itemTemp.requireSTR = UIManager.instance.item_EquipSlot[slotNumber].requireSTR;
        UIManager.instance.itemTemp.requireHEL = UIManager.instance.item_EquipSlot[slotNumber].requireHEL;
        UIManager.instance.itemTemp.requireINT = UIManager.instance.item_EquipSlot[slotNumber].requireINT;
        UIManager.instance.itemTemp.requireLUK = UIManager.instance.item_EquipSlot[slotNumber].requireLUK;
        UIManager.instance.itemTemp.quantity = UIManager.instance.item_EquipSlot[slotNumber].quantity;
        UIManager.instance.itemTemp.enhanceLevel = UIManager.instance.item_EquipSlot[slotNumber].enhanceLevel;
        UIManager.instance.itemTemp.enhanceStack = UIManager.instance.item_EquipSlot[slotNumber].enhanceStack;
        randomResult = Random.Range(1, 1000000000);
        if (UIManager.instance.item_EquipSlot[slotNumber].itemName.Substring(0, 1).Equals("+")) // 아이템 이름이 +로 시작된다면 강화를 한 아이템 
        {
            if (int.TryParse(UIManager.instance.item_EquipSlot[slotNumber].itemName.Substring(2, 1), out enhanceLevel1))  // 3번쨰 자리가 숫자인 경우 강화수치가 두자리수 
            {
                int.TryParse(UIManager.instance.item_EquipSlot[slotNumber].itemName.Substring(1, 1), out enhanceLevel10);  // 2번째 자리는 10의자리수
            }
            else
            {

                int.TryParse(UIManager.instance.item_EquipSlot[slotNumber].itemName.Substring(1, 1), out enhanceLevel1);   //3번째 자리가 숫자가 아니라면 2번째자리가 강화단계가된다 
            }



        }
        else
        {
            // 아이템이름이 + 로 시작하지 않는다면 강화를 하지 않은 아이템이다 
            enhanceLevel1 = 0;
            enhanceLevel10 = 0;

        }
        if (enhanceLevel10 == 0)  // 10의자리수가 0이면 강화단계는 1의자리수의 수가 된다 (0도포함) 
        {
            enhanceLevel = enhanceLevel1;
        }
        else
        {
            // 10의자리수가 0이 아니면 강화단계는 10의자리에 10을 곱해주고 거기에 1의자리를 더해준다 
            enhanceLevel = (enhanceLevel10 * 10) + enhanceLevel1;
        }
        // 아이템 강화레벨 얻기 완 
        /*    강화확률    0-> 1     90
                1-> 2      80
                2-> 3     70
                3-> 4     60
                4-> 5      50
                5-> 6      40
                6-> 7     30
                7-> 8      20
                8-> 9      10 
                이후엔 반절씩 감소 
                */
        //강화수치가 0~ 9까지는 90퍼에서 10퍼씩 감소된다 
        if (enhanceLevel < 9)
        {

            enhanceChance = 900000000 - (enhanceLevel * 100000000);

            randomResult = randomResult - (UIManager.instance.item_EquipSlot[slotNumber].enhanceStack * (long)(enhanceChance * 0.1))
    - (CharacterManager.instance.LUK * (long)(enhanceChance * 0.000001));

            if (randomResult <= enhanceChance) // 랜덤돌린값이 강화확률보다 작으면 성공 ex) 0->1은 나온갑이 900000000보다 작으면 성공이다 
            {

                enhanceResult = true;  // enhanceResult 가 true면 강화 성공한거 
            }




        }
        else
        {
            //강화수치가 10 이상인경우 
            enhanceChance = 100000000;
            for (int i = 9; i <= enhanceLevel; i++)
            {

                enhanceChance = enhanceChance / 2;
                Debug.Log(enhanceChance);

            }
            randomResult = randomResult - (UIManager.instance.item_EquipSlot[slotNumber].enhanceStack * (long)(enhanceChance * 0.1))
                - (CharacterManager.instance.LUK * (long)(enhanceChance * 0.000001));

            if (randomResult <= enhanceChance) // 랜덤돌린값이 강화확률보다 작으면 성공 
            {


                enhanceResult = true;  // enhanceResult 가 true면 강화 성공한거 
            }



        }

        //강화를 진행하였으므로 강화석을 1개 없앤다 
        UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].quantity -= 1;
        if (UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].quantity == 0)
        {


            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].itemName = "null";
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].bigItemType = "null";
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].smallItemType = "null";
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].price = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].quantity = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].itemExplain = "null";
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].sharePosiible = false;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddHP = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddMP = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddMaxMP = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddMaxHP = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddSTR = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddHEL = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddINT = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddLUK = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddPower = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddMagicPower = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].maxAddDefence = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].coolTime = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].stayTime = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].addMaxHP = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].addMaxMP = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].addSTR = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].addHEL = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].addINT = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].addLUK = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].addPower = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].addDefence = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].requireLevel = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].requireSTR = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].requireHEL = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].requireINT = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].requireLUK = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].enhanceLevel = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].enhanceStack = 0;
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].Refresh();
            enhanceStoneSlotNumber = -1;
            UIManager.instance.enhanece_EnhanceStoneImage.sprite = null;
            UIManager.instance.enhanece_EnhanceStoneImage.color = new Color(1, 1, 1, 0);
            UIManager.instance.enhance_EnhanceStoneQuantityText.text = "0";
        }
        else
        { 
            UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].Refresh();
            UIManager.instance.enhance_EnhanceStoneQuantityText.text = UIManager.instance.item_EtcSlot[enhanceStoneSlotNumber].quantity.ToString();
        }
        SoundManager.instance.StaySoundEffectON("EnhanceIngSound", SoundManager.instance.staySoundEffectNumber);
        StartCoroutine(EnhanceSuccessEffect());  // 강화 이펙트


        if (enhanceResult)
        {


            // 강화가 성공했을 경우 
            // 이름을 바꿔야 하는데 먼저 0강상태인 경우에는 원래이름 앞에 +1을붙여준다 강화아이템은 처음 3자리 이름이 강화용도로 쓰인다 
            if (!UIManager.instance.item_EquipSlot[slotNumber].itemName.Substring(0, 1).Equals("+"))
            {
                UIManager.instance.useItemTemp.itemName = "+1 " + UIManager.instance.item_EquipSlot[slotNumber].itemName;
            }
            // +1 해서 강화단계가 10 이상인 경우는 +뒤에 두자리수를 붙여준다 
            else if(enhanceLevel + 1 >= 10)
            {
                UIManager.instance.useItemTemp.itemName = "+" + (enhanceLevel + 1) + UIManager.instance.item_EquipSlot[slotNumber].itemName.Substring(3);
            }
            // +1 해서  10강 이하인 경우에는 +뒤에 강화단계, 그리고 강화용이름은 3자리를 차지하기 때문에 스페이스바를 넣어준다 
            else
            {
                UIManager.instance.useItemTemp.itemName = "+" + (enhanceLevel + 1) + " " + UIManager.instance.item_EquipSlot[slotNumber].itemName.Substring(3);
            }

            UIManager.instance.useItemTemp.bigItemType = UIManager.instance.item_EquipSlot[slotNumber].bigItemType;
            UIManager.instance.useItemTemp.smallItemType = UIManager.instance.item_EquipSlot[slotNumber].smallItemType;
            UIManager.instance.useItemTemp.price = UIManager.instance.item_EquipSlot[slotNumber].price;
            UIManager.instance.useItemTemp.itemExplain = UIManager.instance.item_EquipSlot[slotNumber].itemExplain;
            UIManager.instance.useItemTemp.quantity = UIManager.instance.item_EquipSlot[slotNumber].quantity;
            UIManager.instance.useItemTemp.maxAddHP = UIManager.instance.item_EquipSlot[slotNumber].maxAddHP;
            UIManager.instance.useItemTemp.maxAddMP = UIManager.instance.item_EquipSlot[slotNumber].maxAddMP;
            UIManager.instance.useItemTemp.maxAddMaxMP = UIManager.instance.item_EquipSlot[slotNumber].maxAddMaxMP;
            UIManager.instance.useItemTemp.maxAddMaxHP = UIManager.instance.item_EquipSlot[slotNumber].maxAddMaxHP;
            UIManager.instance.useItemTemp.maxAddSTR = UIManager.instance.item_EquipSlot[slotNumber].maxAddSTR;
            UIManager.instance.useItemTemp.maxAddHEL = UIManager.instance.item_EquipSlot[slotNumber].maxAddHEL;
            UIManager.instance.useItemTemp.maxAddINT = UIManager.instance.item_EquipSlot[slotNumber].maxAddINT;
            UIManager.instance.useItemTemp.sharePosiible = UIManager.instance.item_EquipSlot[slotNumber].sharePosiible;
            UIManager.instance.useItemTemp.maxAddLUK = UIManager.instance.item_EquipSlot[slotNumber].maxAddLUK;
            UIManager.instance.useItemTemp.maxAddPower = UIManager.instance.item_EquipSlot[slotNumber].maxAddPower;
            UIManager.instance.useItemTemp.maxAddMagicPower = UIManager.instance.item_EquipSlot[slotNumber].maxAddMagicPower;
            UIManager.instance.useItemTemp.maxAddDefence = UIManager.instance.item_EquipSlot[slotNumber].maxAddDefence;
            UIManager.instance.useItemTemp.coolTime = UIManager.instance.item_EquipSlot[slotNumber].coolTime;
            UIManager.instance.useItemTemp.stayTime = UIManager.instance.item_EquipSlot[slotNumber].stayTime;
            UIManager.instance.useItemTemp.requireLevel = UIManager.instance.item_EquipSlot[slotNumber].requireLevel;
            UIManager.instance.useItemTemp.requireAccumulateLevel = UIManager.instance.item_EquipSlot[slotNumber].requireAccumulateLevel;
            UIManager.instance.useItemTemp.requireSTR = UIManager.instance.item_EquipSlot[slotNumber].requireSTR;
            UIManager.instance.useItemTemp.requireHEL = UIManager.instance.item_EquipSlot[slotNumber].requireHEL;
            UIManager.instance.useItemTemp.requireINT = UIManager.instance.item_EquipSlot[slotNumber].requireINT;
            UIManager.instance.useItemTemp.requireLUK = UIManager.instance.item_EquipSlot[slotNumber].requireLUK;
            //위는 변하지 않는것들 



            if(UIManager.instance.item_EquipSlot[slotNumber].addMaxHP > 0)
            {
                randomOption = Random.Range(0.9f, 1.1f + (enhanceLevel * 0.1f));
                UIManager.instance.useItemTemp.addMaxHP = (long)(UIManager.instance.item_EquipSlot[slotNumber].addMaxHP * randomOption) + 1;
            }
            if (UIManager.instance.item_EquipSlot[slotNumber].addMaxMP > 0)
            {
                randomOption = Random.Range(0.9f, 1.1f + (enhanceLevel * 0.1f));
                UIManager.instance.useItemTemp.addMaxMP = (long)(UIManager.instance.item_EquipSlot[slotNumber].addMaxMP * randomOption) + 1;
            }
            if (UIManager.instance.item_EquipSlot[slotNumber].addSTR > 0)
            {
                randomOption = Random.Range(0.9f, 1.1f + (enhanceLevel * 0.1f));
                UIManager.instance.useItemTemp.addSTR = (long)(UIManager.instance.item_EquipSlot[slotNumber].addSTR * randomOption) + 1;
            }
            if (UIManager.instance.item_EquipSlot[slotNumber].addHEL > 0)
            {
                randomOption = Random.Range(0.9f, 1.1f + (enhanceLevel * 0.1f));
                UIManager.instance.useItemTemp.addHEL = (long)(UIManager.instance.item_EquipSlot[slotNumber].addHEL * randomOption) + 1;
            }
            if (UIManager.instance.item_EquipSlot[slotNumber].addINT > 0)
            {
                randomOption = Random.Range(0.9f, 1.1f + (enhanceLevel * 0.1f));
                UIManager.instance.useItemTemp.addINT = (long)(UIManager.instance.item_EquipSlot[slotNumber].addINT * randomOption) + 1;
            }
            if (UIManager.instance.item_EquipSlot[slotNumber].addLUK > 0)
            {
                randomOption = Random.Range(0.9f, 1.1f + (enhanceLevel * 0.1f));
                UIManager.instance.useItemTemp.addLUK = (long)(UIManager.instance.item_EquipSlot[slotNumber].addLUK * randomOption) + 1;
            }
            if (UIManager.instance.item_EquipSlot[slotNumber].addPower > 0)
            {
                randomOption = Random.Range(0.9f, 1.1f + (enhanceLevel * 0.1f));
                UIManager.instance.useItemTemp.addPower = (long)(UIManager.instance.item_EquipSlot[slotNumber].addPower * randomOption) + 1;
            }
            if (UIManager.instance.item_EquipSlot[slotNumber].addMagicPower > 0)
            {
                randomOption = Random.Range(0.9f, 1.1f + (enhanceLevel * 0.1f));
                UIManager.instance.useItemTemp.addMagicPower = (long)(UIManager.instance.item_EquipSlot[slotNumber].addMagicPower * randomOption) + 1;
            }
            if (UIManager.instance.item_EquipSlot[slotNumber].addDefence > 0)
            {
                randomOption = Random.Range(0.9f, 1.1f + (enhanceLevel * 0.1f));
                UIManager.instance.useItemTemp.addDefence = (long)(UIManager.instance.item_EquipSlot[slotNumber].addDefence * randomOption) + 1;
            }
            UIManager.instance.useItemTemp.enhanceLevel = UIManager.instance.item_EquipSlot[slotNumber].enhanceLevel + 1;
            UIManager.instance.useItemTemp.enhanceStack = 0;
            //위와같이 옵션을 변화시켜준다음 아이템 옵션을 바꿔준다 


            UIManager.instance.item_EquipSlot[slotNumber].itemName = UIManager.instance.useItemTemp.itemName;
            UIManager.instance.item_EquipSlot[slotNumber].addMaxHP = UIManager.instance.useItemTemp.addMaxHP;
            UIManager.instance.item_EquipSlot[slotNumber].addMaxMP = UIManager.instance.useItemTemp.addMaxMP;
            UIManager.instance.item_EquipSlot[slotNumber].addSTR = UIManager.instance.useItemTemp.addSTR;
            UIManager.instance.item_EquipSlot[slotNumber].addHEL = UIManager.instance.useItemTemp.addHEL;
            UIManager.instance.item_EquipSlot[slotNumber].addINT = UIManager.instance.useItemTemp.addINT;
            UIManager.instance.item_EquipSlot[slotNumber].addLUK = UIManager.instance.useItemTemp.addLUK;
            UIManager.instance.item_EquipSlot[slotNumber].addPower = UIManager.instance.useItemTemp.addPower;
            UIManager.instance.item_EquipSlot[slotNumber].addMagicPower = UIManager.instance.useItemTemp.addMagicPower;
            UIManager.instance.item_EquipSlot[slotNumber].addDefence = UIManager.instance.useItemTemp.addDefence;
            UIManager.instance.item_EquipSlot[slotNumber].requireLevel = UIManager.instance.useItemTemp.requireLevel;
            UIManager.instance.item_EquipSlot[slotNumber].requireAccumulateLevel = UIManager.instance.useItemTemp.requireAccumulateLevel;
            UIManager.instance.item_EquipSlot[slotNumber].requireSTR = UIManager.instance.useItemTemp.requireSTR;
            UIManager.instance.item_EquipSlot[slotNumber].requireHEL = UIManager.instance.useItemTemp.requireHEL;
            UIManager.instance.item_EquipSlot[slotNumber].requireINT = UIManager.instance.useItemTemp.requireINT;
            UIManager.instance.item_EquipSlot[slotNumber].requireLUK = UIManager.instance.useItemTemp.requireLUK;
            UIManager.instance.item_EquipSlot[slotNumber].enhanceLevel = UIManager.instance.useItemTemp.enhanceLevel;
            UIManager.instance.item_EquipSlot[slotNumber].enhanceStack = 0;
            UIManager.instance.item_EquipSlot[slotNumber].Refresh();

            changeAddMaxHP = UIManager.instance.useItemTemp.addMaxHP - UIManager.instance.itemTemp.addMaxHP;
            changeaddMaxMP = UIManager.instance.useItemTemp.addMaxMP - UIManager.instance.itemTemp.addMaxMP;
            changeAddSTR = UIManager.instance.useItemTemp.addSTR - UIManager.instance.itemTemp.addSTR;
            changeAddHEL = UIManager.instance.useItemTemp.addHEL - UIManager.instance.itemTemp.addHEL;
            changeAddINT = UIManager.instance.useItemTemp.addINT - UIManager.instance.itemTemp.addINT;
            changeAddLUK = UIManager.instance.useItemTemp.addLUK - UIManager.instance.itemTemp.addLUK;
            changeAddPower = UIManager.instance.useItemTemp.addPower - UIManager.instance.itemTemp.addPower;
            changeAddMagicPower = UIManager.instance.useItemTemp.addMagicPower - UIManager.instance.itemTemp.addMagicPower;
            changeAddDefence = UIManager.instance.useItemTemp.addDefence - UIManager.instance.itemTemp.addDefence;


            UIManager.instance.enhance_SelectItemImage.sprite = UIManager.instance.item_EquipSlot[slotNumber].itemImage.sprite;
            UIManager.instance.enhance_SelectItemNameText.text = UIManager.instance.item_EquipSlot[slotNumber].itemName;

            //변경된 옵션을 보여준다 
            UIManager.instance.enhance_SuccessChangeOptionText.text = "변경된 옵션\n"
                + "최대체력 : " + UIManager.instance.itemTemp.addMaxHP + "-> " + UIManager.instance.useItemTemp.addMaxHP
                + "\n최대마나 : " + UIManager.instance.itemTemp.addMaxMP + "-> " + UIManager.instance.useItemTemp.addMaxMP
                + "\n힘 : " + UIManager.instance.itemTemp.addSTR + "-> " + UIManager.instance.useItemTemp.addSTR
                + "\n건강 : " + UIManager.instance.itemTemp.addHEL + "-> " + UIManager.instance.useItemTemp.addHEL
            +"\n지능 : " + UIManager.instance.itemTemp.addINT + "-> " + UIManager.instance.useItemTemp.addINT
                + "\n운 : " + UIManager.instance.itemTemp.addLUK + "-> " + UIManager.instance.useItemTemp.addLUK
                + "\n공격력 : " + UIManager.instance.itemTemp.addPower + "-> " + UIManager.instance.useItemTemp.addPower
                + "\n마력 : " + UIManager.instance.itemTemp.addMagicPower + "-> " + UIManager.instance.useItemTemp.addMagicPower
                + "\n방어력 : " + UIManager.instance.itemTemp.addDefence + "-> " + UIManager.instance.useItemTemp.addDefence;


            //옵션을 바꿔준다음에 리턴스크롤 사용할 수 있는 패널을 보여준다 
            UIManager.instance.enhance_EnhancePotionStackText.text = "강화의 비약 " + UIManager.instance.item_EquipSlot[slotNumber].enhanceStack.ToString() + " 중첩 ";
            UIManager.instance.enhance_EnhanceSuccessPanel.gameObject.SetActive(true);
            
            for(int i = 0; i < 32; i++)
            {

                UIManager.instance.enhance_EquipItemSlot[i].Refresh();
            }
        }
        // 강화가 실패한 경우 
        else
        {

            //강화보호석을 사용했을 때 강화보호석 개수만 1개 없앤다 (enhanceProtectStoneUse이거는 강화보호석을 체크했을때 있어야먄 true가 된다)
            if (enhanceProtectStoneUse)
            {

                UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].quantity -= 1;
                if (UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].quantity == 0)
                {


                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].itemName = "null";
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].bigItemType = "null";
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].smallItemType = "null";
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].price = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].quantity = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].itemExplain = "null";
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].sharePosiible = false;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddHP = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddMP = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddMaxMP = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddMaxHP = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddSTR = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddHEL = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddINT = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddLUK = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddPower = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddMagicPower = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].maxAddDefence = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].coolTime = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].stayTime = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].addMaxHP = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].addMaxMP = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].addSTR = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].addHEL = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].addINT = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].addLUK = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].addPower = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].addDefence = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].requireLevel = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].requireSTR = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].requireHEL = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].requireINT = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].requireLUK = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].enhanceLevel = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].enhanceStack = 0;
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].Refresh();
                    enhanceProtectStoneSlotNumber = -1;
                    //보호석 이미지를 없애고 숫자를 0으로 
                    UIManager.instance.enhance_EnhanceProtectStoneImage.sprite = null;
                    UIManager.instance.enhance_EnhanceProtectStoneImage.color = new Color(1, 1, 1, 0);
                    UIManager.instance.enhance_EnhanceProtectStoneQuantityText.text = "0";
                    //보호석 사용상태를 false로 바꾸고 체크해제 
                    enhanceProtectStoneUse = false;
                    UIManager.instance.enhance_EnhanceProtectStoneUseCheckImage.sprite = Resources.Load("Sprite/UI/Window/CheckMark", typeof(Sprite)) as Sprite;
                    UIManager.instance.enhance_EnhanceProtectStoneUseCheckImage.color = new Color(1, 1, 1, 1);

                }
                else
                {
                    UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].Refresh();
                    UIManager.instance.enhance_EnhanceProtectStoneQuantityText.text = UIManager.instance.item_EtcSlot[enhanceProtectStoneSlotNumber].quantity.ToString();
                }
            }
            //강화보호석을 사용하지 않은 경우 
            else
            {
                UIManager.instance.item_EquipSlot[slotNumber].itemName = "null";
                UIManager.instance.item_EquipSlot[slotNumber].bigItemType = "null";
                UIManager.instance.item_EquipSlot[slotNumber].smallItemType = "null";
                UIManager.instance.item_EquipSlot[slotNumber].price = 0;
                UIManager.instance.item_EquipSlot[slotNumber].quantity = 0;
                UIManager.instance.item_EquipSlot[slotNumber].itemExplain = "null";
                UIManager.instance.item_EquipSlot[slotNumber].maxAddHP = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddMP = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddMaxMP = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddMaxHP = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddSTR = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddHEL = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddINT = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddLUK = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddPower = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddMagicPower = 0;
                UIManager.instance.item_EquipSlot[slotNumber].maxAddDefence = 0;
                UIManager.instance.item_EquipSlot[slotNumber].sharePosiible = false;
                UIManager.instance.item_EquipSlot[slotNumber].coolTime = 0;
                UIManager.instance.item_EquipSlot[slotNumber].stayTime = 0;
                UIManager.instance.item_EquipSlot[slotNumber].addMaxHP = 0;
                UIManager.instance.item_EquipSlot[slotNumber].addMaxMP = 0;
                UIManager.instance.item_EquipSlot[slotNumber].addSTR = 0;
                UIManager.instance.item_EquipSlot[slotNumber].addHEL = 0;
                UIManager.instance.item_EquipSlot[slotNumber].addINT = 0;
                UIManager.instance.item_EquipSlot[slotNumber].addLUK = 0;
                UIManager.instance.item_EquipSlot[slotNumber].addPower = 0;
                UIManager.instance.item_EquipSlot[slotNumber].addDefence = 0;
                UIManager.instance.item_EquipSlot[slotNumber].requireAccumulateLevel = 0;
                UIManager.instance.item_EquipSlot[slotNumber].requireLevel = 0;
                UIManager.instance.item_EquipSlot[slotNumber].requireSTR = 0;
                UIManager.instance.item_EquipSlot[slotNumber].requireHEL = 0;
                UIManager.instance.item_EquipSlot[slotNumber].requireINT = 0;
                UIManager.instance.item_EquipSlot[slotNumber].requireLUK = 0;
                UIManager.instance.item_EquipSlot[slotNumber].enhanceLevel = 0;
                UIManager.instance.item_EquipSlot[slotNumber].enhanceStack = 0;
                UIManager.instance.item_EquipSlot[slotNumber].Refresh();
                slotNumber = -1;
                UIManager.instance.enhance_SelectItemNameText.text = "강화 아이템";
                UIManager.instance.enhance_EnhancePotionStackText.text = " " ;
                UIManager.instance.enhance_SelectItemImage.sprite = null;
                UIManager.instance.enhance_SelectItemImage.color = new Color(1, 1, 1, 0);
            }


            for (int i = 0; i < 32; i++)
            {

                UIManager.instance.enhance_EquipItemSlot[i].Refresh();
            }

        }
        }
    



    //강화성공하고 리턴스크롤 사용버튼을 눌렀을 때 발생 
    // useTemp에 변화된 옵션 ItemTemp에 기존 옵션 
    public void ReturnScrollUseButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        //리턴스크롤을 가지오 있으면 진행 -1은 가지고 있지 않음

        if (returnScrollSlotNumber != -1)
        {
            //리턴스크롤의 개수를 1개 없앤다 
            UIManager.instance.item_EtcSlot[returnScrollSlotNumber].quantity -= 1;
            //1개없앴는데 0개가 되면 그 슬롯을 비운다 
            if (UIManager.instance.item_EtcSlot[returnScrollSlotNumber].quantity == 0)
            {


                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].itemName = "null";
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].bigItemType = "null";
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].smallItemType = "null";
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].price = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].quantity = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].itemExplain = "null";
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].sharePosiible = false;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddHP = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddMP = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddMaxMP = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddMaxHP = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddSTR = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddHEL = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddINT = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddLUK = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddPower = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddMagicPower = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].maxAddDefence = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].coolTime = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].stayTime = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].addMaxHP = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].addMaxMP = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].addSTR = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].addHEL = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].addINT = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].addLUK = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].addPower = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].addDefence = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].requireLevel = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].requireSTR = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].requireHEL = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].requireINT = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].requireLUK = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].enhanceLevel = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].enhanceStack = 0;
                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].Refresh();
                enhanceProtectStoneSlotNumber = -1;
                UIManager.instance.enhance_ReturnQuantityText.text = "0";
            }
            else
            {

                UIManager.instance.item_EtcSlot[returnScrollSlotNumber].Refresh();
                UIManager.instance.enhance_ReturnQuantityText.text = UIManager.instance.item_EtcSlot[returnScrollSlotNumber].quantity.ToString();

            }
            UIManager.instance.item_EquipSlot[slotNumber].itemName = UIManager.instance.itemTemp.itemName;
            UIManager.instance.item_EquipSlot[slotNumber].addMaxHP = UIManager.instance.itemTemp.addMaxHP;
            UIManager.instance.item_EquipSlot[slotNumber].addMaxMP = UIManager.instance.itemTemp.addMaxMP;
            UIManager.instance.item_EquipSlot[slotNumber].addSTR = UIManager.instance.itemTemp.addSTR;
            UIManager.instance.item_EquipSlot[slotNumber].addHEL = UIManager.instance.itemTemp.addHEL;
            UIManager.instance.item_EquipSlot[slotNumber].addINT = UIManager.instance.itemTemp.addINT;
            UIManager.instance.item_EquipSlot[slotNumber].addLUK = UIManager.instance.itemTemp.addLUK;
            UIManager.instance.item_EquipSlot[slotNumber].addPower = UIManager.instance.itemTemp.addPower;
            UIManager.instance.item_EquipSlot[slotNumber].addMagicPower = UIManager.instance.itemTemp.addMagicPower;
            UIManager.instance.item_EquipSlot[slotNumber].addDefence = UIManager.instance.itemTemp.addDefence;
            UIManager.instance.item_EquipSlot[slotNumber].requireLevel = UIManager.instance.itemTemp.requireLevel;
            UIManager.instance.item_EquipSlot[slotNumber].requireAccumulateLevel = UIManager.instance.itemTemp.requireAccumulateLevel;
            UIManager.instance.item_EquipSlot[slotNumber].requireSTR = UIManager.instance.itemTemp.requireSTR;
            UIManager.instance.item_EquipSlot[slotNumber].requireHEL = UIManager.instance.itemTemp.requireHEL;
            UIManager.instance.item_EquipSlot[slotNumber].requireINT = UIManager.instance.itemTemp.requireINT;
            UIManager.instance.item_EquipSlot[slotNumber].requireLUK = UIManager.instance.itemTemp.requireLUK;
            UIManager.instance.item_EquipSlot[slotNumber].quantity = UIManager.instance.itemTemp.quantity;
            UIManager.instance.item_EquipSlot[slotNumber].enhanceLevel = UIManager.instance.itemTemp.enhanceLevel;
            UIManager.instance.item_EquipSlot[slotNumber].enhanceStack = UIManager.instance.itemTemp.enhanceStack;
            UIManager.instance.item_EquipSlot[slotNumber].Refresh();
            UIManager.instance.enhance_SelectItemImage.sprite = UIManager.instance.item_EquipSlot[slotNumber].itemImage.sprite;
            UIManager.instance.enhance_SelectItemNameText.text = UIManager.instance.item_EquipSlot[slotNumber].itemName;
            UIManager.instance.enhance_EnhanceSuccessPanel.gameObject.SetActive(false);
            UIManager.instance.enhance_EnhancePotionStackText.text = "강화의 비약 " + UIManager.instance.item_EquipSlot[slotNumber].enhanceStack.ToString() + " 중첩 ";

        }
        else
        //리턴스크롤을 보유하고 있지 않을 경우 
        {
            StartCoroutine(ReturnScrollUseFailText());
        }

        for (int i = 0; i < 32; i++)
        {

            UIManager.instance.enhance_EquipItemSlot[i].Refresh();
        }

    }


    //리턴스크롤 사용하지 않음 버튼 클릭하였을 때 발생 
    public void ReturnScrollNoUseButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.enhance_EnhanceSuccessPanel.gameObject.SetActive(false);
        UIManager.instance.enhance_SelectItemImage.sprite = UIManager.instance.item_EquipSlot[slotNumber].itemImage.sprite;
        UIManager.instance.enhance_SelectItemNameText.text = UIManager.instance.item_EquipSlot[slotNumber].itemName;
        for(int i = 0; i< 5; i++)
        {
            if(UIManager.instance.quest_IngSlot[i].needItemName == UIManager.instance.useItemTemp.itemName && UIManager.instance.quest_IngSlot[i].questName !="null")
            {
                UIManager.instance.quest_IngSlot[i].currentCollecITemNumber++;
                if (UIManager.instance.quest_IngSlot[i].currentCollecITemNumber>= UIManager.instance.quest_IngSlot[i].needItemNumber)
                {

                    UIManager.instance.quest_IngSlot[i].questState = true;
                    UIManager.instance.playCanvas.QuestingPanleRefresh();
                }

            }


        }

        for (int i = 0; i < 32; i++)
        {

            UIManager.instance.enhance_EquipItemSlot[i].Refresh();
        }

    }

    // 보호석 사용 버튼을 눌렀을 떄 발생 
    // 보호석이 없으면 리턴하고
    // 보호석이 있으면 보호석 사용을 체크해준다 
    public void EnhanceProtectStoneUseButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);

        // 보호석을 사용 안할때 
        if (!enhanceProtectStoneUse)
        {
            if (enhanceProtectStoneSlotNumber == -1)
            {
                StartCoroutine(EnhanceProtectStoneUseFailText());
                return;
            }
            else
            {
                enhanceProtectStoneUse = true;
                UIManager.instance.enhance_EnhanceProtectStoneUseCheckImage.sprite = Resources.Load("Sprite/UI/Window/CheckMark", typeof(Sprite)) as Sprite;
                UIManager.instance.enhance_EnhanceProtectStoneUseCheckImage.color = new Color(1, 1, 1, 1);
            }
        }
        // 사용체크된 상태에서 다시 누르면 원상복귀
        else
        {

            enhanceProtectStoneUse = false;
            UIManager.instance.enhance_EnhanceProtectStoneUseCheckImage.sprite = null;
            UIManager.instance.enhance_EnhanceProtectStoneUseCheckImage.color = new Color(1, 1, 1, 0);





        }









    }

    //강화의 비약 사용 버튼을 눌렀을 떄 발생하는 이벤트
    //강화의 비약이 없거나 아이템을 선택하지 않으면 실패 메시지를 출력 
    // 있다면 선택한 아이템에 강화의 비약 스택을 1올려준다 
    public void EhancePotionUseButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);

        if (slotNumber == -1 || enhancePotionSlotNumber == -1)
        {
            StartCoroutine(EnhancePotionUseFailText());
            return;

        
        }


        //리턴되지 않았다면 강화의 비약도 있고 선택아이템도 있는 것이기 때문에 강화의 비약을 1개 없애고 선택 아이템의 비약 스택을 1올려준다 
        UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].quantity -= 1;
        UIManager.instance.item_EquipSlot[slotNumber].enhanceStack += 1;
        UIManager.instance.enhance_EnhancePotionStackText.text = "강화의 비약 " + UIManager.instance.item_EquipSlot[slotNumber].enhanceStack.ToString() + " 중첩 ";
        if (UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].quantity == 0)
        {


            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].itemName = "null";
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].bigItemType = "null";
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].smallItemType = "null";
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].price = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].quantity = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].itemExplain = "null";
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].sharePosiible = false;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddHP = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddMP = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddMaxMP = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddMaxHP = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddSTR = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddHEL = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddINT = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddLUK = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddPower = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddMagicPower = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].maxAddDefence = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].coolTime = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].stayTime = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].addMaxHP = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].addMaxMP = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].addSTR = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].addHEL = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].addINT = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].addLUK = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].addPower = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].addDefence = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].requireLevel = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].requireSTR = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].requireHEL = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].requireINT = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].requireLUK = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].enhanceLevel = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].enhanceStack = 0;
            UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].Refresh();
            enhancePotionSlotNumber = -1;
            //보호석 이미지를 없애고 숫자를 0으로 
            UIManager.instance.enhance_EnhancePotionText.text = "0";
        }
        else
        {
            UIManager.instance.enhance_EnhancePotionText.text = UIManager.instance.item_EtcSlot[enhancePotionSlotNumber].quantity.ToString();
        }


    }


    // 강화이펙트 코루틴 
    public IEnumerator EnhanceSuccessEffect()
    {

        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(false);
        UIManager.instance.enhance_SuccessEffect2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.enhance_SuccessEffect2.gameObject.SetActive(false);
        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(false);
        UIManager.instance.enhance_SuccessEffect2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.enhance_SuccessEffect2.gameObject.SetActive(false);
        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(false);
        UIManager.instance.enhance_SuccessEffect2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.enhance_SuccessEffect2.gameObject.SetActive(false);
        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(false);
        UIManager.instance.enhance_SuccessEffect2.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.enhance_SuccessEffect2.gameObject.SetActive(false);
        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(true);
        UIManager.instance.enhance_SuccessEffect2.gameObject.SetActive(false);
        UIManager.instance.enhance_SuccessEffect1.gameObject.SetActive(false);
        SoundManager.instance.StaySoundEffectOFF("EnhanceIngSound");
        if (enhanceResult)
        {
            SoundManager.instance.SoundEffectOn("SuccessSound", SoundManager.instance.soundEffectNumber);
        }
        else
        {
            SoundManager.instance.SoundEffectOn("EnhanceFailSound", SoundManager.instance.soundEffectNumber);
        }
    }


    //리턴스크롤이 없을 떄 호출 코루틴 
    public IEnumerator ReturnScrollUseFailText()
    {

        UIManager.instance.enhance_ReturnScorllUseFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.enhance_ReturnScorllUseFailText.gameObject.SetActive(false);
    }


    //보호석이 없을때 호출 코루틴 
    public IEnumerator EnhanceProtectStoneUseFailText()
    {

        UIManager.instance.enhance_EnhanceProtectStoneUseFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.enhance_EnhanceProtectStoneUseFailText.gameObject.SetActive(false);
    }



    //강화를 할 수 없을떄 코루틴 호출 
    public IEnumerator EnhanceFailText()
    {

        UIManager.instance.enhance_EnhanceFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.enhance_EnhanceFailText.gameObject.SetActive(false);
    }

    //강화의 비약 사용 실패시 호출 
    public IEnumerator EnhancePotionUseFailText()
    {

        UIManager.instance.enhance_EnhancePotionUseFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.enhance_EnhancePotionUseFailText.gameObject.SetActive(false);
    }

}
