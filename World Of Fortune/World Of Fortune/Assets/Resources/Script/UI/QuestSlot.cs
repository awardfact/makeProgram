using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour
{



    StreamWriter streamWriter;
    StreamReader streamReader;
    string s;
    int a;

    public string questName;   //퀘스트 이름 
    public string questType; // 퀘스트 타입 반복 스토리 1회성인지 
    public string questKind; //퀘스트 종류  (NPC이동 몬스터 사냥 , 아이템 획득)
    public string[] questExplain = new string[12];
    public string questNpc; // 퀘스트 엔피시 

    public long questRewardExp;  // 퀘스트 경험치보상
    public long questRewardMoney; // 퀘스트 돈 보상
    public string questRewardItemName; // 퀘스트 보상 아이템 

    public bool questState; // 퀘스트 상태 true면 완료된 상태 
    public int thStroy;


    public string needMeetingNPC; // 퀘스트 완료조건 NPC
    public bool meetingNpcFinish;    // 퀘스트 완료조건 NPC만났는지 


    public string needItemName; // 퀘스트 완료조건 아이템 
    public int needItemNumber; // 퀘스트 완료조건 아이템 숫자 
    public int currentCollecITemNumber; // 현재 모은 아이템  
    public bool collectItemFinish; // 아이템 모으는거 다 했는지 

    public string needHuntingMonsterName; // 퀘스트 완료조건 몬스터 
    public int needHuntingNumber; // 퀘스트 완료조건 몬스터 숫자 
    public int currentHuntingMonsterNumber; //현재 잡은 몬스터 
    public bool huntingMonsterFinish; // 몬스터 다 잡았는지 



    public int questRequireLevel;  // 퀘스트 시작 조건 레벨 
    public int questRequireAccmulateLevel; // 퀘스트 시작 조건 누적레벨 

    //보상 아이템 정보 
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

    // 퀘스트 슬롯을 클릭하면 몇번 슬롯인지 퀘스트창에 넘기고
    // 퀘스트가 진행중 (null이 아닌 상태)이면 퀘스트 정보를 오른쪽에 출력해준다 
    public void SlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        questExplainNumber = 0;
        UIManager.instance.questWindow.selectSlotNumber = int.Parse(this.transform.name.Split('_')[1]) - 1;
        if (questName != "null")
        {
            UIManager.instance.quest_NameText.text = questName;
            UIManager.instance.quest_ContentText.text = "퀘스트내용\n" + questExplain[0]; 
            if (questKind == "Collect")
            {
                UIManager.instance.quest_ConditionText.text = "완료조건\n" + needItemName + " : " + currentCollecITemNumber + " / " + needItemNumber;
            }
            else if (questKind == "Hunting")
            {
                UIManager.instance.quest_ConditionText.text = "완료조건\n" + needHuntingMonsterName + " : " + currentHuntingMonsterNumber + " / " + needHuntingNumber;
            }
            else if (questKind == "Meeting")
            {
                UIManager.instance.quest_ConditionText.text = "완료조건\n" + needMeetingNPC + "방문하기";
            }
            if (questRewardItemName != "null")
                UIManager.instance.quest_RewardText.text = "보상 : \n" + "경험치 : " + questRewardExp + ", 돈 : " + questRewardMoney + ", " + questRewardItemName;
            else UIManager.instance.quest_RewardText.text = "보상 : \n" + "경험치 : " + questRewardExp + " 돈 : " + questRewardMoney;
        }
        else
        {
            UIManager.instance.quest_NameText.text = "퀘스트이름";
            UIManager.instance.quest_ContentText.text = "퀘스트내용";
            UIManager.instance.quest_ConditionText.text = "완료조건";
            UIManager.instance.quest_RewardText.text = "보상";

        }
    }



    public void QuestExplainNextButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        questExplainNumber++;
        if(questExplain[questExplainNumber] != "null")
        {

            UIManager.instance.quest_ContentText.text = "퀘스트설명\n" + questExplain[questExplainNumber];

        }
        else
        {
            questExplainNumber = 0;

            UIManager.instance.quest_ContentText.text = "퀘스트설명\n" + questExplain[questExplainNumber];

        }
    }


    //저장 버튼을 누르면 호출 
    public void Save()
    {
        if (UIManager.instance.environment == "Mobile")
        {
            streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + CharacterManager.instance.characterNumber + "/QuestSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(questName + "`");
            streamWriter.Write(questType + "`");
            streamWriter.Write(questKind + "`");
            for (int i = 0; i < 12; i++)
                streamWriter.Write(questExplain[i] + "`");
            streamWriter.Write(questNpc + "`");
            streamWriter.Write(questRewardExp + "`");
            streamWriter.Write(questRewardMoney + "`");
            streamWriter.Write(questRewardItemName + "`");
            streamWriter.Write(questState + "`");
            streamWriter.Write(thStroy + "`");
            streamWriter.Write(needMeetingNPC + "`");
            streamWriter.Write(meetingNpcFinish + "`");
            streamWriter.Write(needItemName + "`");
            streamWriter.Write(needItemNumber + "`");
            streamWriter.Write(currentCollecITemNumber + "`");
            streamWriter.Write(collectItemFinish + "`");
            streamWriter.Write(needHuntingMonsterName + "`");
            streamWriter.Write(needHuntingNumber + "`");
            streamWriter.Write(currentHuntingMonsterNumber + "`");
            streamWriter.Write(huntingMonsterFinish + "`");
            streamWriter.Write(bigItemType + "`");
            streamWriter.Write(smallItemType + "`");
            streamWriter.Write(price + "`");
            streamWriter.Write(itemExplain + "`");
            streamWriter.Write(quantity + "`");
            streamWriter.Write(maxAddHP + "`");
            streamWriter.Write(maxAddMP + "`");
            streamWriter.Write(maxAddMaxHP + "`");
            streamWriter.Write(maxAddMaxMP + "`");
            streamWriter.Write(maxAddSTR + "`");
            streamWriter.Write(maxAddHEL + "`");
            streamWriter.Write(maxAddINT + "`");
            streamWriter.Write(maxAddLUK + "`");
            streamWriter.Write(maxAddPower + "`");
            streamWriter.Write(maxAddMagicPower + "`");
            streamWriter.Write(maxAddDefence + "`");
            streamWriter.Write(coolTime + "`");
            streamWriter.Write(stayTime + "`");
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
            streamWriter.Write(questRequireLevel + "`");
            streamWriter.Write(questRequireAccmulateLevel + "`");
            streamWriter.Write(sharePosiible + "`");
            streamWriter.Close();
        }
        else
        {
            streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + CharacterManager.instance.characterNumber + "/QuestSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(questName + "`");
            streamWriter.Write(questType + "`");
            streamWriter.Write(questKind + "`");
            for(int i = 0; i < 12; i++)
                streamWriter.Write(questExplain[i] + "`");
            streamWriter.Write(questNpc + "`");
            streamWriter.Write(questRewardExp + "`");
            streamWriter.Write(questRewardMoney + "`");
            streamWriter.Write(questRewardItemName + "`");
            streamWriter.Write(questState + "`");
            streamWriter.Write(thStroy + "`");
            streamWriter.Write(needMeetingNPC + "`");
            streamWriter.Write(meetingNpcFinish + "`");
            streamWriter.Write(needItemName + "`");
            streamWriter.Write(needItemNumber + "`");
            streamWriter.Write(currentCollecITemNumber + "`");
            streamWriter.Write(collectItemFinish + "`");
            streamWriter.Write(needHuntingMonsterName + "`");
            streamWriter.Write(needHuntingNumber + "`");
            streamWriter.Write(currentHuntingMonsterNumber + "`");
            streamWriter.Write(huntingMonsterFinish + "`");
            streamWriter.Write(bigItemType + "`");
            streamWriter.Write(smallItemType + "`");
            streamWriter.Write(price + "`");
            streamWriter.Write(itemExplain + "`");
            streamWriter.Write(quantity + "`");
            streamWriter.Write(maxAddHP + "`");
            streamWriter.Write(maxAddMP + "`");
            streamWriter.Write(maxAddMaxHP + "`");
            streamWriter.Write(maxAddMaxMP + "`");
            streamWriter.Write(maxAddSTR + "`");
            streamWriter.Write(maxAddHEL + "`");
            streamWriter.Write(maxAddINT + "`");
            streamWriter.Write(maxAddLUK + "`");
            streamWriter.Write(maxAddPower + "`");
            streamWriter.Write(maxAddMagicPower + "`");
            streamWriter.Write(maxAddDefence + "`");
            streamWriter.Write(coolTime + "`");
            streamWriter.Write(stayTime + "`");
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
            streamWriter.Write(questRequireLevel + "`");
            streamWriter.Write(questRequireAccmulateLevel + "`");
            streamWriter.Write(sharePosiible + "`");
            streamWriter.Close();
        }
    }


    // 이 함수를 호출하면 퀘스트 파일을 불러온다 
    public void GameStart(int selectSlot)
    {

        // 모바일일떄 경로 
        if(UIManager.instance.environment == "Mobile")
        {
            streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/QuestSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Open, FileAccess.Read));
            a = 0; 
            s = streamReader.ReadLine();
            questName = s.Split('`')[a++];
            questType = s.Split('`')[a++];
            questKind = s.Split('`')[a++];
            for(int i = 0; i < 12; i++)
               questExplain[i] = s.Split('`')[a++];
            questNpc = s.Split('`')[a++];
            long.TryParse(s.Split('`')[a++], out questRewardExp);
            long.TryParse(s.Split('`')[a++], out questRewardMoney);
            questRewardItemName = s.Split('`')[a++];
            bool.TryParse(s.Split('`')[a++], out questState);
            int.TryParse(s.Split('`')[a++], out thStroy);
            needMeetingNPC = s.Split('`')[a++];
            bool.TryParse(s.Split('`')[a++], out meetingNpcFinish);
            needItemName = s.Split('`')[a++];
            int.TryParse(s.Split('`')[a++], out needItemNumber);
            int.TryParse(s.Split('`')[a++], out currentCollecITemNumber);
            bool.TryParse(s.Split('`')[a++], out collectItemFinish);
            needHuntingMonsterName = s.Split('`')[a++];
            int.TryParse(s.Split('`')[a++], out needHuntingNumber);
            int.TryParse(s.Split('`')[a++], out currentHuntingMonsterNumber);
            bool.TryParse(s.Split('`')[a++], out huntingMonsterFinish);
            bigItemType = s.Split('`')[a++];
            smallItemType = s.Split('`')[a++];
            long.TryParse(s.Split('`')[a++], out price);
            itemExplain = s.Split('`')[a++];
            int.TryParse(s.Split('`')[a++], out quantity);
            long.TryParse(s.Split('`')[a++], out maxAddHP);
            long.TryParse(s.Split('`')[a++], out maxAddMP);
            long.TryParse(s.Split('`')[a++], out maxAddMaxHP);
            long.TryParse(s.Split('`')[a++], out maxAddMaxMP);
            long.TryParse(s.Split('`')[a++], out maxAddSTR);
            long.TryParse(s.Split('`')[a++], out maxAddHEL);
            long.TryParse(s.Split('`')[a++], out maxAddINT);
            long.TryParse(s.Split('`')[a++], out maxAddLUK);
            long.TryParse(s.Split('`')[a++], out maxAddPower);
            long.TryParse(s.Split('`')[a++], out maxAddMagicPower);
            long.TryParse(s.Split('`')[a++], out maxAddDefence);
            float.TryParse(s.Split('`')[a++], out coolTime);
            float.TryParse(s.Split('`')[a++], out stayTime);
            long.TryParse(s.Split('`')[a++], out addMaxHP);
            long.TryParse(s.Split('`')[a++], out addMaxMP);
            long.TryParse(s.Split('`')[a++], out addSTR);
            long.TryParse(s.Split('`')[a++], out addHEL);
            long.TryParse(s.Split('`')[a++], out addINT);
            long.TryParse(s.Split('`')[a++], out addLUK);
            long.TryParse(s.Split('`')[a++], out addPower);
            long.TryParse(s.Split('`')[a++], out addMagicPower);
            long.TryParse(s.Split('`')[a++], out addDefence);
            long.TryParse(s.Split('`')[a++], out requireLevel);
            long.TryParse(s.Split('`')[a++], out requireAccumulateLevel);
            long.TryParse(s.Split('`')[a++], out requireSTR);
            long.TryParse(s.Split('`')[a++], out requireHEL);
            long.TryParse(s.Split('`')[a++], out requireINT);
            long.TryParse(s.Split('`')[a++], out requireLUK);
            int.TryParse(s.Split('`')[a++], out enhanceLevel);
            int.TryParse(s.Split('`')[a++], out enhanceStack);
            int.TryParse(s.Split('`')[a++], out questRequireLevel);
            int.TryParse(s.Split('`')[a++], out questRequireAccmulateLevel);
            bool.TryParse(s.Split('`')[a], out sharePosiible);
            streamReader.Close();

        }
        else
        {
            // PC일때 경로 
            streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/QuestSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            a = 0;
            questName = s.Split('`')[a++];
            questType = s.Split('`')[a++];
            questKind = s.Split('`')[a++];

            for (int i = 0; i < 12; i++)
            {
                questExplain[3] = s.Split('`')[a++];

            }
            
            questNpc = s.Split('`')[a++];
            long.TryParse(s.Split('`')[a++], out questRewardExp);
            long.TryParse(s.Split('`')[a++], out questRewardMoney);
            questRewardItemName = s.Split('`')[a++];
            bool.TryParse(s.Split('`')[a++], out questState);
            int.TryParse(s.Split('`')[a++], out thStroy);
            needMeetingNPC = s.Split('`')[a++];
            bool.TryParse(s.Split('`')[a++], out meetingNpcFinish);
            needItemName = s.Split('`')[a++];

            int.TryParse(s.Split('`')[a++], out needItemNumber);
            int.TryParse(s.Split('`')[a++], out currentCollecITemNumber);
            bool.TryParse(s.Split('`')[a++], out collectItemFinish);
            needHuntingMonsterName = s.Split('`')[a++];
            int.TryParse(s.Split('`')[a++], out needHuntingNumber);
            int.TryParse(s.Split('`')[a++], out currentHuntingMonsterNumber);
            bool.TryParse(s.Split('`')[a++], out huntingMonsterFinish);
            bigItemType = s.Split('`')[a++];
            smallItemType = s.Split('`')[a++];

            long.TryParse(s.Split('`')[a++], out price);
            itemExplain = s.Split('`')[a++];
            int.TryParse(s.Split('`')[a++], out quantity);
            long.TryParse(s.Split('`')[a++], out maxAddHP);
            long.TryParse(s.Split('`')[a++], out maxAddMP);
            long.TryParse(s.Split('`')[a++], out maxAddMaxHP);
            long.TryParse(s.Split('`')[a++], out maxAddMaxMP);
            long.TryParse(s.Split('`')[a++], out maxAddSTR);
            long.TryParse(s.Split('`')[a++], out maxAddHEL);
            long.TryParse(s.Split('`')[a++], out maxAddINT);
            long.TryParse(s.Split('`')[a++], out maxAddLUK);
            long.TryParse(s.Split('`')[a++], out maxAddPower);
            long.TryParse(s.Split('`')[a++], out maxAddMagicPower);
            long.TryParse(s.Split('`')[a++], out maxAddDefence);
            float.TryParse(s.Split('`')[a++], out coolTime);
            float.TryParse(s.Split('`')[a++], out stayTime);
            long.TryParse(s.Split('`')[a++], out addMaxHP);
            long.TryParse(s.Split('`')[a++], out addMaxMP);
            long.TryParse(s.Split('`')[a++], out addSTR);
            long.TryParse(s.Split('`')[a++], out addHEL);
            long.TryParse(s.Split('`')[a++], out addINT);
            long.TryParse(s.Split('`')[a++], out addLUK);
            long.TryParse(s.Split('`')[a++], out addPower);
            long.TryParse(s.Split('`')[a++], out addMagicPower);
            long.TryParse(s.Split('`')[a++], out addDefence);
            long.TryParse(s.Split('`')[a++], out requireLevel);
            long.TryParse(s.Split('`')[a++], out requireAccumulateLevel);
            long.TryParse(s.Split('`')[a++], out requireSTR);
            long.TryParse(s.Split('`')[a++], out requireHEL);
            long.TryParse(s.Split('`')[a++], out requireINT);
            long.TryParse(s.Split('`')[a++], out requireLUK);
            int.TryParse(s.Split('`')[a++], out enhanceLevel);
            int.TryParse(s.Split('`')[a++], out enhanceStack);
            int.TryParse(s.Split('`')[a++], out questRequireLevel);

            int.TryParse(s.Split('`')[a++], out questRequireAccmulateLevel);

            bool.TryParse(s.Split('`')[a], out sharePosiible);

            streamReader.Close();

        }

        questNameText.text = questName;
    }

}
