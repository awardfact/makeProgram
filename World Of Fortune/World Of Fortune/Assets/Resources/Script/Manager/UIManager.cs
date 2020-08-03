using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour   // UI에 관한 오브젝트는 웬만하면 다 UIManager에서 관리 다른 곳에서 UI관련된 오브젝트를 이용하려면 UIManager를 이용

{
    StreamWriter streamWriter;
    StreamReader streamReader;
    string s;

    public string environment;

    public Player player;

    public static UIManager instance = null;

    public CharacterManager characterManager;

    //퀵슬롯
    public QuickSlot[] quickSlot = new QuickSlot[5];

    public Camera main_Camera;
    public EffectCanvas effectCanvas;


    public EquipWindow equipWindow;
    public StatWindow statWindow;
    public SkillWindow skillWindow;
    public QuestWindow questWindow;
    public MenuWindow menuWindow;
    public PlayCanvas playCanvas;
    public NPCWindow npcWindow;
    public NPCTalkWindow npcTalkWindow;
    public NPCShopWindow npcShopWindow;
    public NPCQuestWindow npcQuestWindow;
    public NPCEnhanceWindow npcEnhanceWindow;
    public NPCRebirthWindow npcRebirthWindow;
    public NPCWarehouseWindow npcWarehouseWindow;
    public CharacterSelectWindow characterSelecWindow;

    //아이템 임시저장소 관련 변수 
    public ItemTemp itemTemp;
    public DropItemTemp dropItemTemp;
    public UseItemTemp useItemTemp;
    public WarehouseItemTemp warehouseItemTemp;
    public CharacterInfoTemp characterInfoTemp;
 


    //소지하고 있는 돈과 캐시
    public long warehouseHasMoney;
    public long warehouseHasCash;
    public long hasMoney;
    public long hasCash;  // 캐시는 계정공유이기 때문에 모든 캐릭이 같은 파일에서 불러온다 


    // 아이템창 관련 변수 
    public ItemWindow itemWindow;
    public ItemSlot[] item_EquipSlot = new ItemSlot[32];
    public ItemSlot[] item_ConsumeSlot = new ItemSlot[32];
    public ItemSlot[] item_EtcSlot = new ItemSlot[32];
    public ItemSlot[] item_CashSlot = new ItemSlot[32];
    public Button item_EquipSlotButton;
    public Button item_ConsumeSlotButton;
    public Button item_EtcSlotButton;
    public Button item_CashSlotButton;
    public Text item_MoneyText;
    public Text item_CashText;
    public Text item_SelectItemExplainText;
    public Button item_UseButton;
    public Text item_UseButtonFailText;
    public Button item_EquipButton;
    public Text item_EquipButtonFailText;
    public Button item_QuickSlotButton;
    public Text item_QuickSlotButtonFailText;
    public Button item_SellButton;
    public Text item_SellFailText;
    public Button item_WarehouseButton;
    public Text item_WarehouseInputFailText;
    public RectTransform item_EquipSlotPanel;
    public RectTransform item_ConsumeSlotPanel;
    public RectTransform item_EtcSlotPanel;
    public RectTransform item_CashSlotPanel;
    public int showSlot;
    public RectTransform item_QuickSlotClickEvnetPanel;
    public RectTransform item_SellClickEventPanel;
    public InputField item_SellQuantityInputField;
    public RectTransform item_WarehouseClickEventPanel;
    public InputField item_WarehouseQuantityInputField;

    public WarehouseItemSlot[] warehouse_ItemSlot = new WarehouseItemSlot[44];
    public Text warehouse_SelectItemText;
    public InputField warehouse_AmountInputField;
    public Text warehouse_moneyText;
    public Text warehouse_UnloadFailText;
    public Text warehouse_WithdrawFailText;
    public Text warehouse_DepositFailText;

    public Text equip_SelectItemExplainText;
    public Text equip_UnequipFailText;
    public EquipSlot equip_WeaponSlot;
    public EquipSlot equip_ArmorSlot;
    public EquipSlot equip_ShoesSlot;
    public EquipSlot equip_HelmetSlot;
    public EquipSlot equip_EarringSlot;
    public EquipSlot equip_ShieldSlot;
    public EquipSlot equip_RingSlot;
    public EquipSlot equip_GloveSlot;
    public EquipSlot equip_NecklaceSlot;

    public Text stat_NameText;
    public Text stat_JobText;
    public Text stat_LevelText;
    public Text stat_AccumulateLevelText;
    public Text stat_MagicPowerText;
    public Text stat_PowerText;
    public Text stat_DefenceText;
    public Text stat_HPText;
    public Text stat_MPText;
    public Text stat_STRText;
    public Text stat_HLEText;
    public Text stat_INTText;
    public Text stat_LUKText;
    public Text stat_APText;
    public Text stat_HPRegenerateText;
    public Text stat_MPRegenerateText;
    public InputField stat_InputField;
    public Button stat_ExitButton;
    public Button stat_HPUpButton;
    public Button stat_MPUpButton;
    public Button stat_STRUpButton;
    public Button stat_HELUpButton;
    public Button stat_INTUpBUtton;
    public Button stat_LUKUpButton;
    public Text stat_StatUpFailText;

    public int showSkill;
    public RectTransform skill_1thPanel;
    public RectTransform skill_2thPanel;
    public RectTransform skill_3thPanel;
    public RectTransform skill_4thPanel;
    public Button skill_1thButton;
    public Button skill_2thButton;
    public Button skill_3thButton;
    public Button skill_4thButton;
    public Text skill_ExplainText;
    public Text skill_NameText;
    public Text skill_SPText;
    public Text skill_FailText;
    public AttackEnhance_1_1 skill_1_1AttackEnhance;

    public Text quest_NameText;
    public Text quest_ContentText;
    public Text quest_ConditionText;
    public Text quest_RewardText;
    public QuestSlot[] quest_IngSlot = new QuestSlot[5];
    public RectTransform quest_GiveUpEventPanel;
    public Text quest_FailText;


    public NPCSellItem[] shop_sellItem = new NPCSellItem[12];
    public Text shop_SelectItemText;
    public Text shop_MoneyText;
    public Text shop_CashText;
    public Text Shop_BuyFailText;
    public InputField shop_BuyQuantityInputField;


    public NPCQuestSlot[] npcQuestSlot = new NPCQuestSlot[3];
    public Text npcQuest_FinishFailText;
    public Text npcQuest_AcceptFailText;
    public Text npcQuest_GIveUpFailText;
    public RectTransform npcQuest_GiveUpEventPanel;
    public Text npcQuest_NameText;
    public Text npcQuest_ContentText;
    public Text npcQuest_ConditionText;
    public Text npcQuest_RewardText;

    public RectTransform enhance_SelectItemPanel;
    public Text enhance_SelectItemExplainText;

    public Image enhance_SelectItemImage;
    public Text enhance_SelectItemNameText;
    public Image enhanece_EnhanceStoneImage;
    public Text enhance_EnhanceStoneQuantityText;
    public Image enhance_EnhanceProtectStoneImage;
    public Text enhance_EnhanceProtectStoneQuantityText;
    public Text enhance_EnhancePotionText;
    public EnhanceItemSlot[] enhance_EquipItemSlot = new EnhanceItemSlot[32];
    public RectTransform enhance_SuccessEffect1;
    public RectTransform enhance_SuccessEffect2;
    public Text enhance_ReturnQuantityText;
    public RectTransform enhance_EnhanceSuccessPanel;
    public Text enhance_ReturnScorllUseFailText;
    public Text enhance_SuccessChangeOptionText;
    public Text enhance_EnhanceProtectStoneUseFailText;
    public Image enhance_EnhanceProtectStoneUseCheckImage;
    public Text enhance_EnhanceFailText;
    public Text enhance_ItemSelectFailText;
    public Text enhance_EnhancePotionUseFailText;
    public Text enhance_EnhancePotionStackText;


    public Text rebirth_CurrentLevelText;
    public Text rebirth_MaxGetText;
    public Text rebirth_RebirthFailText;
    public Text rebirth_SelectRebirthTypeText;
    public RectTransform rebirth_RebirthWarningPanel;
    public RectTransform rebirth_RebirthEffect1;
    public RectTransform rebirth_RebirthEffect2;
    public RectTransform rebirth_RebirthFinishPanel;
    public Text rebirth_RebirthReturnScrollQuantityText;
    public Text rebirth_ReturnScrollUseFailText;
    public Text rebirth_RebirthRewardTypeText;
    public Text rebirth_RebirthRewardAmountText;

    public CharacterSlot[] CharacterSlot = new CharacterSlot[3];
    public Text character_SelectCharacterText;
    public CharacterAddWindow character_CharacterAddWindow;
    public Text character_CharacterAddFailText;
    public Image character_DiceButton;
    public RectTransform character_DeletePanel;

    public Text environmentText;

    public RectTransform enemyHpPanel;

    public Text[] systemMessageText = new Text[4];


    public JellyLeather[] dropItem_JellyLeather = new JellyLeather[30];
    public DropMoney[] dropItem_dropMoney = new DropMoney[30];
    public int jellyLeatherCount;
    public int dropMoneyCount;
    public RectTransform diePanel;




    public int EnenmyDamegedCount;
    public int PlyerDamegedCount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        showSlot = 0;
        itemWindow = transform.Find("ItemWindowCanvas").gameObject.GetComponent<ItemWindow>();
        equipWindow = transform.Find("EquipWindowCanvas").gameObject.GetComponent<EquipWindow>();
        statWindow = transform.Find("StatWindowCanvas").gameObject.GetComponent<StatWindow>();
        skillWindow = transform.Find("SkillWindowCanvas").gameObject.GetComponent<SkillWindow>();
        questWindow = transform.Find("QuestWindowCanvas").gameObject.GetComponent<QuestWindow>();
        menuWindow = transform.Find("MenuCanvas").gameObject.GetComponent<MenuWindow>();
        playCanvas = transform.Find("PlayCanvas").gameObject.GetComponent<PlayCanvas>();
        npcWindow = transform.Find("NPC").gameObject.GetComponent<NPCWindow>();
        npcTalkWindow = transform.Find("NPC/TalkCanvas").gameObject.GetComponent<NPCTalkWindow>();
        npcShopWindow = transform.Find("NPC/ShopCanvas").gameObject.GetComponent<NPCShopWindow>();
        npcQuestWindow = transform.Find("NPC/QuestCanvas").gameObject.GetComponent<NPCQuestWindow>();
        npcEnhanceWindow = transform.Find("NPC/EnhanceCanvas").gameObject.GetComponent<NPCEnhanceWindow>();
        npcRebirthWindow = transform.Find("NPC/RebirthCanvas").gameObject.GetComponent<NPCRebirthWindow>();
        npcWarehouseWindow = transform.Find("NPC/WarehouseCanvas").gameObject.GetComponent<NPCWarehouseWindow>();
        characterSelecWindow = GameObject.Find("CharacterSelecWindowPanel").gameObject.GetComponent<CharacterSelectWindow>();
        for(int i = 0; i <3; i++)
        {
            CharacterSlot[i] = GameObject.Find("CharacterSelecWindowPanel").transform.Find("CharacterSlot_" + (i + 1)).gameObject.GetComponent<CharacterSlot>();
        }

        for (int i = 0; i < 32; i++)
        {
            item_EquipSlot[i] = transform.Find("ItemWindowCanvas/ItemPanel/EquipSlotPanel/EquipSlot_" + (i + 1)).gameObject.GetComponent<ItemSlot>();
            item_ConsumeSlot[i] = transform.Find("ItemWindowCanvas/ItemPanel/ConsumeSlotPanel/ConsumeSlot_" + (i + 1)).gameObject.GetComponent<ItemSlot>();
            item_EtcSlot[i] = transform.Find("ItemWindowCanvas/ItemPanel/EtcSlotPanel/EtcSlot_" + (i + 1)).gameObject.GetComponent<ItemSlot>();
            item_CashSlot[i] = transform.Find("ItemWindowCanvas/ItemPanel/CashSlotPanel/CashSlot_" + (i + 1)).gameObject.GetComponent<ItemSlot>();
            enhance_EquipItemSlot[i] = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EquipPanel/EquipSlot_" + (i + 1)).gameObject.GetComponent<EnhanceItemSlot>();
        }
        item_EquipSlotButton = transform.Find("ItemWindowCanvas/ItemPanel/EquipSlotButton").gameObject.GetComponent<Button>();
        item_ConsumeSlotButton = transform.Find("ItemWindowCanvas/ItemPanel/ConsumeSlotButton").gameObject.GetComponent<Button>();
        item_EtcSlotButton = transform.Find("ItemWindowCanvas/ItemPanel/EtcSlotButton").gameObject.GetComponent<Button>();
        item_CashSlotButton = transform.Find("ItemWindowCanvas/ItemPanel/CashSlotButton").gameObject.GetComponent<Button>();
        item_EquipSlotPanel = transform.Find("ItemWindowCanvas/ItemPanel/EquipSlotPanel").gameObject.GetComponent<RectTransform>();
        item_ConsumeSlotPanel = transform.Find("ItemWindowCanvas/ItemPanel/ConsumeSlotPanel").gameObject.GetComponent<RectTransform>();
        item_EtcSlotPanel = transform.Find("ItemWindowCanvas/ItemPanel/EtcSlotPanel").gameObject.GetComponent<RectTransform>();
        item_CashSlotPanel = transform.Find("ItemWindowCanvas/ItemPanel/CashSlotPanel").gameObject.GetComponent<RectTransform>();
        item_MoneyText = transform.Find("ItemWindowCanvas/ItemPanel/MoneyImage/Image/HasMoneyText").gameObject.GetComponent<Text>();
        item_CashText = transform.Find("ItemWindowCanvas/ItemPanel/CashImage/Image/HasCashText").gameObject.GetComponent<Text>();
        item_SelectItemExplainText = transform.Find("ItemWindowCanvas/SelectItemPanel/ExplainText").gameObject.GetComponent<Text>();
        item_UseButton = transform.Find("ItemWindowCanvas/SelectItemPanel/UseButton").gameObject.GetComponent<Button>();
        item_UseButtonFailText = transform.Find("ItemWindowCanvas/SelectItemPanel/UseButton/FailText").gameObject.GetComponent<Text>();
        item_EquipButton = transform.Find("ItemWindowCanvas/SelectItemPanel/EquipButton").gameObject.GetComponent<Button>();
        item_EquipButtonFailText = transform.Find("ItemWindowCanvas/SelectItemPanel/EquipButton/FailText").gameObject.GetComponent<Text>();
        item_QuickSlotButton = transform.Find("ItemWindowCanvas/SelectItemPanel/QuickSlotButton").gameObject.GetComponent<Button>();
        item_QuickSlotButtonFailText = transform.Find("ItemWindowCanvas/SelectItemPanel/QuickSlotButton/FailText").gameObject.GetComponent<Text>();
        item_SellButton = transform.Find("ItemWindowCanvas/SelectItemPanel/SellButton").gameObject.GetComponent<Button>();
        item_SellFailText = transform.Find("ItemWindowCanvas/SelectItemPanel/SellButton/FailText").gameObject.GetComponent<Text>();
        item_WarehouseButton = transform.Find("ItemWindowCanvas/SelectItemPanel/WarehouseButton").gameObject.GetComponent<Button>();
        item_WarehouseInputFailText = transform.Find("ItemWindowCanvas/SelectItemPanel/WarehouseButton/FailText").gameObject.GetComponent<Text>();
        item_QuickSlotClickEvnetPanel = transform.Find("ItemWindowCanvas/SelectItemPanel/QuickSlotButton/ClickEvnetPanel").gameObject.GetComponent<RectTransform>();
        item_SellClickEventPanel = transform.Find("ItemWindowCanvas/SelectItemPanel/SellButton/SellEventPaenl").gameObject.GetComponent<RectTransform>();
        item_SellQuantityInputField = transform.Find("ItemWindowCanvas/SelectItemPanel/SellButton/SellEventPaenl/InputField").gameObject.GetComponent<InputField>();
        item_WarehouseClickEventPanel = transform.Find("ItemWindowCanvas/SelectItemPanel/WarehouseButton/WarehouseEventPanel").gameObject.GetComponent<RectTransform>();
        item_WarehouseQuantityInputField = transform.Find("ItemWindowCanvas/SelectItemPanel/WarehouseButton/WarehouseEventPanel/InputField").gameObject.GetComponent<InputField>();
        for (int i = 0; i < 5; i++)
        {
            quickSlot[i] = transform.Find("PlayCanvas/QuickSlotPanel/QuickSlot_" + (i + 1)).gameObject.GetComponent<QuickSlot>();
        }
        itemTemp = transform.Find("EventSystem").gameObject.GetComponent<ItemTemp>();
        dropItemTemp = transform.Find("EventSystem").gameObject.GetComponent<DropItemTemp>();
        useItemTemp = transform.Find("EventSystem").gameObject.GetComponent<UseItemTemp>();
        warehouseItemTemp = transform.Find("EventSystem").gameObject.GetComponent<WarehouseItemTemp>();
        characterInfoTemp = transform.Find("EventSystem").gameObject.GetComponent<CharacterInfoTemp>();
        equip_SelectItemExplainText = transform.Find("EquipWindowCanvas/EquipPanel/SelectItemPanel/SelectItemExplainText").gameObject.GetComponent<Text>();
        equip_UnequipFailText = transform.Find("EquipWindowCanvas/EquipPanel/SelectItemPanel/FailText").gameObject.GetComponent<Text>();
        equip_WeaponSlot = transform.Find("EquipWindowCanvas/EquipPanel/EquipWeapon").gameObject.GetComponent<EquipSlot>();
        equip_ArmorSlot = transform.Find("EquipWindowCanvas/EquipPanel/EquipArmor").gameObject.GetComponent<EquipSlot>();
        equip_ShoesSlot = transform.Find("EquipWindowCanvas/EquipPanel/EquipShoes").gameObject.GetComponent<EquipSlot>();
        equip_HelmetSlot = transform.Find("EquipWindowCanvas/EquipPanel/EquipHelmet").gameObject.GetComponent<EquipSlot>();
        equip_EarringSlot = transform.Find("EquipWindowCanvas/EquipPanel/EquipEarring").gameObject.GetComponent<EquipSlot>();
        equip_ShieldSlot = transform.Find("EquipWindowCanvas/EquipPanel/EquipShield").gameObject.GetComponent<EquipSlot>();
        equip_RingSlot = transform.Find("EquipWindowCanvas/EquipPanel/EquipRing").gameObject.GetComponent<EquipSlot>();
        equip_GloveSlot = transform.Find("EquipWindowCanvas/EquipPanel/EquipGlove").gameObject.GetComponent<EquipSlot>();
        equip_NecklaceSlot = transform.Find("EquipWindowCanvas/EquipPanel/EquipNecklace").gameObject.GetComponent<EquipSlot>();
        for (int i = 0; i < 44; i++)
        {
            warehouse_ItemSlot[i] = transform.Find("NPC/WarehouseCanvas/WarehousePanel/SlotPanel/Slot_" + (i + 1)).gameObject.GetComponent<WarehouseItemSlot>();
        }

        warehouse_SelectItemText = transform.Find("NPC/WarehouseCanvas/WarehousePanel/SelectItemPanel/SelectItemText").gameObject.GetComponent<Text>();
        warehouse_AmountInputField = transform.Find("NPC/WarehouseCanvas/WarehousePanel/AmountInputField").gameObject.GetComponent<InputField>();
        warehouse_moneyText = transform.Find("NPC/WarehouseCanvas/WarehousePanel/MoneyImage/Image/HasMoneyText").gameObject.GetComponent<Text>();
        warehouse_UnloadFailText = transform.Find("NPC/WarehouseCanvas/WarehousePanel/UnloadButton/FailText").gameObject.GetComponent<Text>(); 
        warehouse_WithdrawFailText = transform.Find("NPC/WarehouseCanvas/WarehousePanel/WithdrawButton/FailText").gameObject.GetComponent<Text>(); 
        warehouse_DepositFailText = transform.Find("NPC/WarehouseCanvas/WarehousePanel/DepositButton/FailText").gameObject.GetComponent<Text>();

        stat_NameText = transform.Find("StatWindowCanvas/StatPanel/NameText").gameObject.GetComponent<Text>();
        stat_JobText = transform.Find("StatWindowCanvas/StatPanel/JobText").gameObject.GetComponent<Text>();
        stat_LevelText = transform.Find("StatWindowCanvas/StatPanel/LevelText").gameObject.GetComponent<Text>();
        stat_AccumulateLevelText = transform.Find("StatWindowCanvas/StatPanel/AccumulateLevelText").gameObject.GetComponent<Text>();
        stat_MagicPowerText = transform.Find("StatWindowCanvas/StatPanel/MagicPowerText").gameObject.GetComponent<Text>();
        stat_PowerText = transform.Find("StatWindowCanvas/StatPanel/PowerText").gameObject.GetComponent<Text>();
        stat_DefenceText = transform.Find("StatWindowCanvas/StatPanel/DefenceText").gameObject.GetComponent<Text>();
        stat_HPText = transform.Find("StatWindowCanvas/StatPanel/HPText").gameObject.GetComponent<Text>();
        stat_MPText = transform.Find("StatWindowCanvas/StatPanel/MPText").gameObject.GetComponent<Text>();
        stat_STRText = transform.Find("StatWindowCanvas/StatPanel/STRText").gameObject.GetComponent<Text>();
        stat_HLEText = transform.Find("StatWindowCanvas/StatPanel/HELText").gameObject.GetComponent<Text>();
        stat_INTText = transform.Find("StatWindowCanvas/StatPanel/INTText").gameObject.GetComponent<Text>();
        stat_LUKText = transform.Find("StatWindowCanvas/StatPanel/LUKText").gameObject.GetComponent<Text>();
        stat_APText = transform.Find("StatWindowCanvas/StatPanel/APText").gameObject.GetComponent<Text>();
        stat_HPRegenerateText = transform.Find("StatWindowCanvas/StatPanel/HPRegenerateText").gameObject.GetComponent<Text>();
        stat_MPRegenerateText = transform.Find("StatWindowCanvas/StatPanel/MPRegenerateText").gameObject.GetComponent<Text>();
        stat_InputField = transform.Find("StatWindowCanvas/StatPanel/StatInputField").gameObject.GetComponent<InputField>();
        stat_ExitButton = transform.Find("StatWindowCanvas/StatPanel/ExitButton").gameObject.GetComponent<Button>();
        stat_HPUpButton = transform.Find("StatWindowCanvas/StatPanel/HPText/Button").gameObject.GetComponent<Button>();
        stat_MPUpButton = transform.Find("StatWindowCanvas/StatPanel/MPText/Button").gameObject.GetComponent<Button>();
        stat_STRUpButton = transform.Find("StatWindowCanvas/StatPanel/STRText/Button").gameObject.GetComponent<Button>();
        stat_HELUpButton = transform.Find("StatWindowCanvas/StatPanel/HELText/Button").gameObject.GetComponent<Button>();
        stat_INTUpBUtton = transform.Find("StatWindowCanvas/StatPanel/INTText/Button").gameObject.GetComponent<Button>();
        stat_LUKUpButton = transform.Find("StatWindowCanvas/StatPanel/LUKText/Button").gameObject.GetComponent<Button>();
        stat_StatUpFailText = transform.Find("StatWindowCanvas/StatPanel/StatUpFailText").gameObject.GetComponent<Text>();

        skill_1thPanel = transform.Find("SkillWindowCanvas/SkillPanel/Skill_1thPanel").gameObject.GetComponent<RectTransform>(); 
        skill_2thPanel = transform.Find("SkillWindowCanvas/SkillPanel/Skill_2thPanel").gameObject.GetComponent<RectTransform>(); 
        skill_3thPanel = transform.Find("SkillWindowCanvas/SkillPanel/Skill_3thPanel").gameObject.GetComponent<RectTransform>(); 
        skill_4thPanel = transform.Find("SkillWindowCanvas/SkillPanel/Skill_4thPanel").gameObject.GetComponent<RectTransform>();
        skill_1thButton = transform.Find("SkillWindowCanvas/SkillPanel/Skill_1thButton").gameObject.GetComponent<Button>();
        skill_2thButton = transform.Find("SkillWindowCanvas/SkillPanel/Skill_2thButton").gameObject.GetComponent<Button>();
        skill_3thButton = transform.Find("SkillWindowCanvas/SkillPanel/Skill_3thButton").gameObject.GetComponent<Button>();
        skill_4thButton = transform.Find("SkillWindowCanvas/SkillPanel/Skill_4thButton").gameObject.GetComponent<Button>();
        skill_1_1AttackEnhance = transform.Find("SkillWindowCanvas/SkillPanel/Skill_1thPanel/Skill1").gameObject.GetComponent<AttackEnhance_1_1>();
        skill_ExplainText = transform.Find("SkillWindowCanvas/SkillPanel/SelectSkillPanel/SelectSkillExplain").gameObject.GetComponent<Text>();
        skill_NameText = transform.Find("SkillWindowCanvas/SkillPanel/SelectSkillPanel/SelectSkillName").gameObject.GetComponent<Text>();
        skill_SPText = transform.Find("SkillWindowCanvas/SkillPanel/SPText").gameObject.GetComponent<Text>();
        skill_FailText = transform.Find("SkillWindowCanvas/SkillPanel/FailText").gameObject.GetComponent<Text>();

        quest_NameText = transform.Find("QuestWindowCanvas/QuestPanel/QuestContentPanel/QuestNameText").gameObject.GetComponent<Text>();  
        quest_ContentText = transform.Find("QuestWindowCanvas/QuestPanel/QuestContentPanel/QuestContentText").gameObject.GetComponent<Text>();
        quest_ConditionText = transform.Find("QuestWindowCanvas/QuestPanel/QuestContentPanel/QuestConditionText").gameObject.GetComponent<Text>();
        quest_RewardText = transform.Find("QuestWindowCanvas/QuestPanel/QuestContentPanel/QuestRewardText").gameObject.GetComponent<Text>();
        quest_GiveUpEventPanel = transform.Find("QuestWindowCanvas/QuestPanel/GiveUpPanel").gameObject.GetComponent<RectTransform>();
        quest_FailText = transform.Find("QuestWindowCanvas/QuestPanel/QuestContentPanel/FinishFailText").gameObject.GetComponent<Text>();
        for (int i =0; i < 5; i++)
        {
            quest_IngSlot[i] = transform.Find("QuestWindowCanvas/QuestPanel/Questing_" + (i + 1)).gameObject.GetComponent<QuestSlot>();
        }
        for(int i = 0; i < 12; i++)
        {

            shop_sellItem[i] = transform.Find("NPC/ShopCanvas/ShopPanel/ShopSlot_" + (i + 1)).gameObject.GetComponent<NPCSellItem>();

        }

        shop_SelectItemText = transform.Find("NPC/ShopCanvas/ShopPanel/SelectItem").gameObject.GetComponent<Text>();
        shop_MoneyText = transform.Find("NPC/ShopCanvas/MoneyImage/Image/HasMoneyText").gameObject.GetComponent<Text>(); 
        shop_CashText = transform.Find("NPC/ShopCanvas/CashImage/Image/HasCashText").gameObject.GetComponent<Text>();
        Shop_BuyFailText = transform.Find("NPC/ShopCanvas/ShopPanel/FailText").gameObject.GetComponent<Text>();
        shop_BuyQuantityInputField = transform.Find("NPC/ShopCanvas/ShopPanel/InputField").gameObject.GetComponent<InputField>();
        for(int i = 0; i < 3; i++)
        {
            npcQuestSlot[i] = transform.Find("NPC/QuestCanvas/QuestPanel/Questing_" + (i + 1)).gameObject.GetComponent<NPCQuestSlot>();
        }
        npcQuest_FinishFailText = transform.Find("NPC/QuestCanvas/QuestContentPanel/FinishFailText").gameObject.GetComponent<Text>(); 
        npcQuest_AcceptFailText = transform.Find("NPC/QuestCanvas/QuestContentPanel/AcceptFailText").gameObject.GetComponent<Text>();
        npcQuest_GIveUpFailText = transform.Find("NPC/QuestCanvas/QuestContentPanel/GiveUpFailText").gameObject.GetComponent<Text>();
        npcQuest_GiveUpEventPanel = transform.Find("NPC/QuestCanvas/QuestContentPanel/GiveUpPanel").gameObject.GetComponent<RectTransform>();

        npcQuest_NameText = transform.Find("NPC/QuestCanvas/QuestContentPanel/QuestNameText").gameObject.GetComponent<Text>();
        npcQuest_ContentText = transform.Find("NPC/QuestCanvas/QuestContentPanel/QuestContentText").gameObject.GetComponent<Text>();
        npcQuest_ConditionText = transform.Find("NPC/QuestCanvas/QuestContentPanel/QuestConditionText").gameObject.GetComponent<Text>();
        npcQuest_RewardText = transform.Find("NPC/QuestCanvas/QuestContentPanel/QuestRewardText").gameObject.GetComponent<Text>();

        enhance_SelectItemPanel = transform.Find("NPC/EnhanceCanvas/EnhancePanel/ItemSelectPanel").gameObject.GetComponent<RectTransform>(); 
        enhance_SelectItemExplainText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/ItemSelectPanel/SelectItemExplainText").gameObject.GetComponent<Text>();
        enhance_SelectItemImage = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceItem/Image").gameObject.GetComponent<Image>(); 
        enhance_SelectItemNameText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceItem/ItemName").gameObject.GetComponent<Text>();
        enhanece_EnhanceStoneImage = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceStone/Image").gameObject.GetComponent<Image>();
        enhance_EnhanceStoneQuantityText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceStone/ItemQuantity").gameObject.GetComponent<Text>();
        enhance_EnhanceProtectStoneImage = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceProtectStone/Image").gameObject.GetComponent<Image>();
        enhance_EnhanceProtectStoneQuantityText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceProtectStone/ItemQuantity").gameObject.GetComponent<Text>();
        enhance_EnhancePotionText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhancePotionQuantityText").gameObject.GetComponent<Text>();
        enhance_SuccessEffect1 = transform.Find("NPC/EnhanceCanvas/EnhancePanel/SuccessEffect1").gameObject.GetComponent<RectTransform>();
        enhance_SuccessEffect2 = transform.Find("NPC/EnhanceCanvas/EnhancePanel/SuccessEffect2").gameObject.GetComponent<RectTransform>();
        enhance_ReturnQuantityText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceSuccessPanel/RetrunScrollUseQuantity").gameObject.GetComponent<Text>();
        enhance_EnhanceSuccessPanel= transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceSuccessPanel").gameObject.GetComponent<RectTransform>();
        enhance_ReturnScorllUseFailText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceSuccessPanel/ReturnScorllUseFailText").gameObject.GetComponent<Text>();
        enhance_SuccessChangeOptionText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceSuccessPanel/ChangeOptionText").gameObject.GetComponent<Text>();
        enhance_EnhanceProtectStoneUseCheckImage = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceProtectStoneUseButton/Image").gameObject.GetComponent<Image>();
        enhance_EnhanceProtectStoneUseFailText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceProtectStoneUseFailText").gameObject.GetComponent<Text>();
        enhance_EnhanceFailText =transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhanceFailText").gameObject.GetComponent<Text>();
        enhance_ItemSelectFailText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/ItemSelectFailText").gameObject.GetComponent<Text>();
        enhance_EnhancePotionUseFailText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhancePotionUseFailText").gameObject.GetComponent<Text>();
        enhance_EnhancePotionStackText = transform.Find("NPC/EnhanceCanvas/EnhancePanel/EnhancePotionStackText").gameObject.GetComponent<Text>();


        rebirth_CurrentLevelText = transform.Find("NPC/RebirthCanvas/RebirthPanel/LevelText").gameObject.GetComponent<Text>();
        rebirth_MaxGetText = transform.Find("NPC/RebirthCanvas/RebirthPanel/MaxGetText").gameObject.GetComponent<Text>();
        rebirth_RebirthFailText = transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthFailText").gameObject.GetComponent<Text>();
        rebirth_SelectRebirthTypeText = transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthWarningPanel/SelectRebirthTypeText").gameObject.GetComponent<Text>();
        rebirth_RebirthWarningPanel = transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthWarningPanel").gameObject.GetComponent<RectTransform>();
        rebirth_RebirthEffect1 = transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthEffect1").gameObject.GetComponent<RectTransform>();
        rebirth_RebirthEffect2 = transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthEffect2").gameObject.GetComponent<RectTransform>();
        rebirth_RebirthFinishPanel = transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthFinishPanel").gameObject.GetComponent<RectTransform>();
        rebirth_RebirthReturnScrollQuantityText =  transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthFinishPanel/ReturnScrollQuantityText").gameObject.GetComponent<Text>();
        rebirth_ReturnScrollUseFailText = transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthFinishPanel/ReturnScrollUseFailText").gameObject.GetComponent<Text>();
        rebirth_RebirthRewardTypeText = transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthFinishPanel/RebirthRewardTypeText").gameObject.GetComponent<Text>();
        rebirth_RebirthRewardAmountText = transform.Find("NPC/RebirthCanvas/RebirthPanel/RebirthFinishPanel/RebirthRewardAmountText").gameObject.GetComponent<Text>();

        diePanel = transform.Find("PlayCanvas/DiePanel").gameObject.GetComponent<RectTransform>();

        character_SelectCharacterText = GameObject.Find("CharacterSelecWindowPanel").transform.Find("SelectCharacterText").gameObject.GetComponent<Text>();
        character_CharacterAddWindow = GameObject.Find("AddCharacterPanel").gameObject.GetComponent<CharacterAddWindow>();
        character_CharacterAddFailText =  GameObject.Find("CharacterSelecWindowPanel").transform.Find("CharacterAddFailText").gameObject.GetComponent<Text>();
        character_DiceButton = GameObject.Find("AddCharacterPanel").transform.Find("DiceButton").gameObject.GetComponent<Image>();

        environmentText = GameObject.Find("CharacterSelecWindowPanel").transform.Find("EnvironmnetButton/Text").gameObject.GetComponent<Text>();

        enemyHpPanel = transform.Find("PlayCanvas/EnemyHpPanel").gameObject.GetComponent<RectTransform>();
        for(int i = 0; i < 4; i++)
        {
            systemMessageText[i] = transform.Find("PlayCanvas/SystemMessagePanel/SystemMessage_" + (i + 1)).gameObject.GetComponent<Text>();
        }

        effectCanvas = transform.Find("EffectCanvas").gameObject.GetComponent<EffectCanvas>();
        character_DeletePanel = GameObject.Find("CharacterSelecWindowPanel").transform.Find("DeletePanel").gameObject.GetComponent<RectTransform>();
        environment = "Mobile";

}

    
// Update is called once per frame
void Update()
    {
        
    }

    public void Save()
    {

        if (environment == "Mobile")
        {
            streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + CharacterManager.instance.characterNumber + "/HasMoney.txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(hasMoney);
            streamWriter.Close();
            streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + CharacterManager.instance.characterNumber + "/HasCash.txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(hasCash);
            streamWriter.Close();
            streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Warehouse/WarehouseHasMoney.txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(warehouseHasMoney);
            streamWriter.Close();
        }
        else
        {

            streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + CharacterManager.instance.characterNumber + "/HasMoney.txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(hasMoney);
            streamWriter.Close();
            streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + CharacterManager.instance.characterNumber + "/HasCash.txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(hasCash);
            streamWriter.Close();
            streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/WarehouseHasMoney.txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(warehouseHasMoney);
            streamWriter.Close();
        }
    }



    //게임이 시작하면 선택한 캐릭슬롯에 있는 파일을 불러온다 
    public void GameStart(int selectSlot)
    {

        // 모바일일때 경로 
        if(environment == "Mobile")
        {
            streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/HasMoney.txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            long.TryParse(s,out hasMoney);
            streamReader.Close();
            streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/HasCash.txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            long.TryParse(s, out hasCash);
            streamReader.Close();

            item_MoneyText.text = hasMoney.ToString();
            item_CashText.text = hasCash.ToString();


            streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Warehouse/WarehouseHasMoney.txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            long.TryParse(s, out warehouseHasMoney);
            streamReader.Close();
            warehouse_moneyText.text = warehouseHasMoney.ToString();

        }
        // PC일때 경로 
        else
        {
            streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/HasMoney.txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            long.TryParse(s, out hasMoney);
            streamReader.Close();
            streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/HasCash.txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            long.TryParse(s, out hasCash);
            streamReader.Close();
            item_MoneyText.text = hasMoney.ToString();
            item_CashText.text = hasCash.ToString();


            streamReader = new StreamReader(new FileStream("Assets/Resources/Load/WarehouseHasMoney.txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            long.TryParse(s, out warehouseHasMoney);
            streamReader.Close();
            warehouse_moneyText.text = warehouseHasMoney.ToString();
        }

        StartCoroutine(PlayerLoad());
    }
    IEnumerator PlayerLoad()
    {
        yield return new WaitForSeconds(0.7f);
        player = GameObject.Find("Player").GetComponent<Player>();

        main_Camera = GameObject.Find("Player").transform.Find("Main Camera").gameObject.GetComponent<Camera>();
        effectCanvas.effectCanvas.worldCamera = main_Camera;
        for (int i = 0; i < 30; i++)
        {
            dropItem_JellyLeather[i] = GameObject.Find("Item").transform.Find("Etc/JellyLeather/JellyLeather_" + (i + 1).ToString()).gameObject.GetComponent<JellyLeather>();
            dropItem_dropMoney[i] = GameObject.Find("Item").transform.Find("Moeny/Money_" + (i + 1).ToString()).gameObject.GetComponent<DropMoney>();


        }
        jellyLeatherCount = 0;
        dropMoneyCount = 0;
    }





}
