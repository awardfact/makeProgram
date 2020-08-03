using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCQuestSlot : MonoBehaviour
{



    public string questName;   //퀘스트 이름 
    public string questType; // 퀘스트 타입 반복 스토리 1회성인지 
    public string questKind; //퀘스트 종류  (NPC이동 몬스터 사냥 , 아이템 획득)
    public string[] questExplain = new string[12];  // 퀘스트 설명 
    public string questNpc; // 퀘스트 엔피시 

    public int thStroy; // 스토리퀘일 경우 몇번쨰 스토리 퀘스트인지 (1번부터 시작)

    public long questRewardExp;  // 퀘스트 경험치보상
    public long questRewardMoney; // 퀘스트 돈 보상
    public string questRewardItemName; // 퀘스트 보상 아이템 

    public bool questState; // 퀘스트 상태 true면 완료된 상태 


    public string needItemName; // 퀘스트 완료조건 아이템 
    public string needMeetingNPC; // 퀘스트 완료조건 NPC
    public bool meetingNpcFinish;    // 퀘스트 완료조건 NPC만났는지 
    public string needHuntingMonsterName; // 퀘스트 완료조건 몬스터 
    public int needItemNumber; // 퀘스트 완료조건 아이템 숫자 
    public int needHuntingNumber; // 퀘스트 완료조건 몬스터 숫자 
    public int currentCollecITemNumber; // 현재 모은 아이템  
    public int currentHuntingMonsterNumber; //현재 잡은 몬스터 





    //보상 아이템 정보 
    public string bigItemType;
    public string smallItemType;
    public long price;
    public string itemExplain;
    public int quantity;

    public int questRequireLevel;  // 퀘스트 시작 조건 레벨 
    public int questRequireAccmulateLevel; // 퀘스트 시작 조건 누적레벨 

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


    //장착아이템일경우 착용조건 
    public long requireAccumulateLevel;
    public long requireLevel;
    public long requireSTR;
    public long requireHEL;
    public long requireINT;
    public long requireLUK;

    public int enhanceLevel;
    public int enhanceStack;

    public bool sharePosiible; //보상 아이템 계정공유 가능한지 가능 = true;

    public Text questNameText;  // 퀘스트이름 

    public int questExplainNumber;
    // Start is called before the first frame update
    void Start()
    {
        questExplain = new string[12];
        questName = "null";
        questNameText = transform.Find("QuestNameText").gameObject.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuestExplainNextButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        questExplainNumber++;
        if (questExplain[questExplainNumber] != "null")
        {

            UIManager.instance.npcQuest_ContentText.text = "퀘스트설명\n" + questExplain[questExplainNumber];

        }
        else
        {
            questExplainNumber = 0;

            UIManager.instance.npcQuest_ContentText.text = "퀘스트설명\n" + questExplain[questExplainNumber];

        }
    }

    // 퀘스트 슬롯을 클릭하면 몇번 슬롯인지 퀘스트창에 넘기고
    // 퀘스트가 진행중 (null이 아닌 상태)이면 퀘스트 정보를 오른쪽에 출력해준다 
    public void SlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.npcQuestWindow.selectSlotNumber = int.Parse(this.transform.name.Split('_')[1]) - 1;
        if (questName != "null")    
        {
            UIManager.instance.npcQuest_NameText.text = questName;
            UIManager.instance.npcQuest_ContentText.text = "퀘스트내용\n" + questExplain[0];
            if (questKind == "Collect")
            {
                UIManager.instance.npcQuest_ConditionText.text ="완료조건\n" +  needItemName + " : " + currentCollecITemNumber + " / " + needItemNumber;
            }
            else if (questKind == "Hunting")
            {
                UIManager.instance.npcQuest_ConditionText.text = "완료조건\n" +needHuntingMonsterName + " : " + currentHuntingMonsterNumber + " / " + needHuntingNumber;
            }
            else if (questKind == "Meeting")
            {
                UIManager.instance.npcQuest_ConditionText.text =  "완료조건\n" +needMeetingNPC + "방문하기";
            }
            if (questRewardItemName != "null")
                UIManager.instance.npcQuest_RewardText.text = "보상 : \n" + "경험치 : " + questRewardExp + ", 돈 : " + questRewardMoney + ", " + questRewardItemName;
            else UIManager.instance.npcQuest_RewardText.text = "보상 : \n" + "경험치 : " + questRewardExp + " 돈 : " + questRewardMoney;
        }
        else
        {
            UIManager.instance.npcQuest_NameText.text = "퀘스트이름";
            UIManager.instance.npcQuest_ContentText.text = "퀘스트내용";
            UIManager.instance.npcQuest_ConditionText.text = "완료조건";
            UIManager.instance.npcQuest_RewardText.text = "보상";

        }
    }
}
