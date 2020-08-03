using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalkWindow : MonoBehaviour
{


    public string NPCName;
    public string NPCSay;
    public bool shopAvailable;
    public bool questAvailable;
    public bool enhanceAvailable;
    public bool rebirthAvailable;
    public bool warehouseAvailable;


    public bool enhanceStoneExist;
    public bool enhancePotionExist;
    public bool enhnaceProtectStoneExist;
    public bool returnScrollExist;
    public bool rebirthReturnScrollExist;

    public Text npcNameText;
    public Text npcTalkText;

    public Button shopButton;
    public Button questButton;
    public Button enhanceButton;
    public Button rebirthButton;
    public Button warehouseButton;

    public Text shopText;
    public Text questText;
    public Text enhanceText;
    public Text rebirthText;
    public Text warehouseText;


    public int rebirthGetStat;


    void Start()
    {
        npcNameText = transform.Find("TalkPanel/NPCNameText").gameObject.GetComponent<Text>();
        npcTalkText = transform.Find("TalkPanel/NPCSayText").gameObject.GetComponent<Text>();
        shopButton = transform.Find("TalkPanel/ShopButton").gameObject.GetComponent<Button>();
        questButton = transform.Find("TalkPanel/QuestButton").gameObject.GetComponent<Button>();
        enhanceButton = transform.Find("TalkPanel/EnhanceButton").gameObject.GetComponent<Button>();
        rebirthButton = transform.Find("TalkPanel/RebirthButton").gameObject.GetComponent<Button>();
        warehouseButton = transform.Find("TalkPanel/WarehouseButton").gameObject.GetComponent<Button>();
        shopText = transform.Find("TalkPanel/ShopButton/Text").gameObject.GetComponent<Text>();
        questText = transform.Find("TalkPanel/QuestButton/Text").gameObject.GetComponent<Text>();
        enhanceText = transform.Find("TalkPanel/EnhanceButton/Text").gameObject.GetComponent<Text>();
        rebirthText = transform.Find("TalkPanel/RebirthButton/Text").gameObject.GetComponent<Text>();
        warehouseText = transform.Find("TalkPanel/WarehouseButton/Text").gameObject.GetComponent<Text>();
    }


        // 상점을 이용 가능한 경우에만 받은 정보를 화면에 초기화 시키고  setActive true로 바꿔준다 
        public void ShopButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (shopAvailable == true)
        {
            for (int i = 0; i < 12; i++)
            {
                UIManager.instance.shop_sellItem[i].Refresh();
            }
            UIManager.instance.shop_CashText.text = UIManager.instance.hasCash.ToString();
            UIManager.instance.shop_MoneyText.text = UIManager.instance.hasMoney.ToString();
            this.gameObject.SetActive(false);
            UIManager.instance.npcShopWindow.gameObject.SetActive(true);
        }
    }

    // NPC대화창에서 퀘스트 버튼 클릭 
    public void QuestButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (questAvailable == true)
        {
            // 퀘스트 내용 리프레시 시켜준다 
            this.gameObject.SetActive(false);
            UIManager.instance.npcQuestWindow.gameObject.SetActive(true);

        }
    }


    //NPC 대화창에서 강화 버튼 클릭 
    // 기타창에 강화석, 보호석이 있는지 확인해서 있으면 강화석, 보호석 이미지 , 숫자를 보여주고 있는 슬롯넘버를 강화창에 넘겨준다 
    // 없으면 이미지 x 숫자 0으로 
    public void EnhanceButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);

        // 먼저 npc기능중에 강화창이 있는지 확인한다 없으면 진행 x
        if (enhanceAvailable == true)
        {

            //먼저 아이템창에 강화석과 보호석이 있는지 

            UIManager.instance.npcEnhanceWindow.slotNumber = -1;
            UIManager.instance.npcEnhanceWindow.clickkSlotNumber = -1;
            UIManager.instance.npcEnhanceWindow.enhanceStoneSlotNumber = -1;
            UIManager.instance.npcEnhanceWindow.enhanceProtectStoneSlotNumber = -1;
            UIManager.instance.npcEnhanceWindow.enhancePotionSlotNumber = -1;
            UIManager.instance.npcEnhanceWindow.returnScrollSlotNumber = -1;

            enhanceStoneExist = false;
            enhnaceProtectStoneExist = false;
            enhancePotionExist = false;
            returnScrollExist = false;

            for (int i =0; i < 32; i++)
            {
                UIManager.instance.enhance_EquipItemSlot[i].itemImage.sprite = UIManager.instance.item_EquipSlot[i].itemImage.sprite;

                if(UIManager.instance.item_EtcSlot[i].itemName == "강화석")
                {
                    UIManager.instance.enhanece_EnhanceStoneImage.sprite = Resources.Load("Sprite/Item/etc/강화석", typeof(Sprite)) as Sprite;
                    UIManager.instance.enhanece_EnhanceStoneImage.color = new Color(1, 1, 1, 1);
                    UIManager.instance.enhance_EnhanceStoneQuantityText.text = UIManager.instance.item_EtcSlot[i].quantity.ToString();
                    enhanceStoneExist = true;
                    UIManager.instance.npcEnhanceWindow.enhanceStoneSlotNumber = i;
                }
                else if (UIManager.instance.item_EtcSlot[i].itemName == "보호석")
                {

                    UIManager.instance.enhance_EnhanceProtectStoneImage.sprite = Resources.Load("Sprite/Item/etc/보호석", typeof(Sprite)) as Sprite;
                    UIManager.instance.enhance_EnhanceProtectStoneImage.color = new Color(1, 1, 1, 1);
                    UIManager.instance.enhance_EnhanceProtectStoneQuantityText.text = UIManager.instance.item_EtcSlot[i].quantity.ToString();
                    enhnaceProtectStoneExist = true;
                    UIManager.instance.npcEnhanceWindow.enhanceProtectStoneSlotNumber = i;
                }
                else if(UIManager.instance.item_EtcSlot[i].itemName == "강화의 비약")
                {
                    UIManager.instance.npcEnhanceWindow.enhancePotionSlotNumber = i;
                    UIManager.instance.enhance_EnhancePotionText.text = UIManager.instance.item_EtcSlot[i].quantity.ToString();
                    enhancePotionExist = true;
                }
                else if(UIManager.instance.item_EtcSlot[i].itemName == "리턴 스크롤(강화)")
                {
                    UIManager.instance.npcEnhanceWindow.returnScrollSlotNumber = i;
                    UIManager.instance.enhance_ReturnQuantityText.text = UIManager.instance.item_EtcSlot[i].quantity.ToString();
                    returnScrollExist = true;
                }

            }

            if (!enhanceStoneExist)
            {
                UIManager.instance.enhanece_EnhanceStoneImage.sprite = null;
                UIManager.instance.enhanece_EnhanceStoneImage.color = new Color(1, 1, 1, 0);
                UIManager.instance.enhance_EnhanceStoneQuantityText.text = "0";
            }
            if (!enhnaceProtectStoneExist)
            {
                UIManager.instance.enhance_EnhanceProtectStoneImage.sprite = null;
                UIManager.instance.enhance_EnhanceProtectStoneImage.color = new Color(1, 1, 1, 0);
                UIManager.instance.enhance_EnhanceProtectStoneQuantityText.text ="0";

            }
            if (!enhancePotionExist)
            {
                UIManager.instance.enhance_EnhancePotionText.text = "0";
            }
            if (!returnScrollExist)
            {
                UIManager.instance.enhance_ReturnQuantityText.text = "0";
            }

            for(int i = 0; i < 32; i++)
            {
               
                UIManager.instance.enhance_EquipItemSlot[i].Refresh();
            }


            this.gameObject.SetActive(false);
            UIManager.instance.npcEnhanceWindow.gameObject.SetActive(true);

        }
    }

    // NPC대화창에서 환생 버튼 클릭 
    public void RebirthButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (rebirthAvailable == true)
        {

            rebirthReturnScrollExist = false;
            for(int i = 0; i < 32; i ++)
            {
                if(UIManager.instance.item_EtcSlot[i].itemName == "리턴 스크롤(환생)")
                {
                    UIManager.instance.npcRebirthWindow.rebirthReturnScrollSlotNumber = i;
                    rebirthReturnScrollExist = true;
                    UIManager.instance.rebirth_RebirthReturnScrollQuantityText.text = UIManager.instance.item_EtcSlot[i].quantity.ToString();

                }

            }
            if (!rebirthReturnScrollExist)
            {

                UIManager.instance.rebirth_RebirthReturnScrollQuantityText.text = "0";

            }

            UIManager.instance.rebirth_CurrentLevelText.text ="현재 레벨  : "  + CharacterManager.instance.Level.ToString();
            if(CharacterManager.instance.Level >= 30)
            {
                rebirthGetStat = (int)(((CharacterManager.instance.Level / 10) * (CharacterManager.instance.Level - 29)) * ((float)CharacterManager.instance.Level / 30));
                UIManager.instance.rebirth_MaxGetText.text = "환생시 얻는 최대 수치 : " + rebirthGetStat.ToString() + "(스텟기준)";
            }
            else
            {
                UIManager.instance.rebirth_MaxGetText.text = "환생시 얻는 최대 수치 : 0";

            }



            this.gameObject.SetActive(false);
            UIManager.instance.npcRebirthWindow.gameObject.SetActive(true);

        }
    }

    // NPC대화창에서 창고 버튼 클릭 
    public void WarehouseButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (warehouseAvailable == true)
        {
            this.gameObject.SetActive(false);
            UIManager.instance.npcWarehouseWindow.gameObject.SetActive(true);

        }
    }



    // 닫기 버튼을 눌렀을 때 
    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        this.gameObject.SetActive(false);


    }




}
