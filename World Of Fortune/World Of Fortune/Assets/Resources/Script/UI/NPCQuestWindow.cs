using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// npc - 퀘스트창에서 수락, 완료 , 포기 눌렀을 때 발생하는 이벤트 처리 담는 스크립트 
public class NPCQuestWindow : MonoBehaviour  
{
    public int selectSlotNumber;  // 클릭한 npc의 퀘스트 슬롯 번호 

    public int aceeptSlotNumber;  // 퀘스트를 받을 떄 들어가는 퀘스트 슬롯 번호 또는 같은 이름의 퀘스트가 있으면 그곳의 슬롯 번호 
    public int min;

    // Start is called before the first frame update
    void Start()
    {
        selectSlotNumber = -1;
        aceeptSlotNumber = -1;
        min = -1;
    }

    // 포기하기 버튼은 버튼 자체를 눌렀을 때 클릭한 퀘스트가 진행중인 퀘스트와 이름이 같으면  정말 포기하겠습니까 ?? 알림이 뜬다 
    public void GiveUpButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        for (int i = 0; i < 5; i++)
        {
            if(UIManager.instance.quest_IngSlot[i].questName == UIManager.instance.npcQuestSlot[selectSlotNumber].questName)
            {
                UIManager.instance.npcQuest_GiveUpEventPanel.gameObject.SetActive(true);
                aceeptSlotNumber = i;
                return;
            }
        }
        StartCoroutine(QeustGiveUpFailText());

    }
    
    //포기 이벤트에서 닫기 버튼 클릭했을때 발생 
    public void GiveUpEventExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.npcQuest_GiveUpEventPanel.gameObject.SetActive(false);
    }


    // 포기 이벤트에서 포기 버튼 클릭했을 때 발생 
    //포기하기 버튼 클릭하였을 때 발새 ㅇ
    // 받은 퀘스트 중에 npc퀘스트 슬롯에서 클릭한 퀘스트 이름과 동일 한 퀘스트가 있어야 가능함 
    // 받은 퀘스트 중에 npc퀘스트창에서 클릭한 퀘스트와 동일한 퀘스트의 내용을 삭제한다  삭제는 진행중인 슬롯넘버를 알아내서 그 슬롯넘버의 포기 메소드 호출 
    public void GiveUpEventFinishButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.questWindow.selectSlotNumber = aceeptSlotNumber;
        UIManager.instance.questWindow.npcQuestGiveUpFinishButton();
        UIManager.instance.npcQuest_GiveUpEventPanel.gameObject.SetActive(false);
        aceeptSlotNumber = -1;
        UIManager.instance.questWindow.selectSlotNumber = -1;

    }
  
    // 완료하기 버튼 클릭하였을 때 발생
    // 받은 퀘스트 중에 npc퀘스트 슬롯에서 클릭한 퀘스트 이름과 동일한 퀘스트가 있어야 한다 
    // 동일한 퀘스트의 완료 요구조건을 모두 만족하면 완료를 할 수 있다 완료는 진행중인 슬롯넘버만 알아내고 그 슬롯넘버의 완료 메소드 호출 
    public void FInishButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        for (int i = 0; i < 5; i++)
        {
            if (UIManager.instance.quest_IngSlot[i].questName == UIManager.instance.npcQuestSlot[selectSlotNumber].questName)
            {
                UIManager.instance.questWindow.selectSlotNumber = i;


                if (UIManager.instance.questWindow.npcQuestFinishButton() == 1)
                {
                    UIManager.instance.npcQuestSlot[selectSlotNumber].questName = "null";
                    UIManager.instance.npcQuestSlot[selectSlotNumber].questNameText.text = "완료 !";
                    UIManager.instance.npcQuest_NameText.text = "퀘스트이름";
                    UIManager.instance.npcQuest_ContentText.text = "퀘스트내용";
                    UIManager.instance.npcQuest_ConditionText.text = "완료 조건";
                    UIManager.instance.npcQuest_RewardText.text = "보상";
                    UIManager.instance.npcQuestSlot[selectSlotNumber].SlotButtonClick();
                    aceeptSlotNumber = -1;
                    UIManager.instance.questWindow.selectSlotNumber = -1;

                }

                return;
            }
        }

        StartCoroutine(QeustFinishFailText());



    }

    public void QuestExplainNextButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.npcQuestSlot[selectSlotNumber].QuestExplainNextButton();



    }





    // 수락하기 버튼을 눌렀을 떄 발생
    // 스토리 퀘스트라면 cHARACTERmANAGER의 STROY의 숫자와 같아야 수락이 가능하다 보다 크면 선행 퀘스트가 있습니다. 작으면 완료한 퀘스트입니다라고 뜬다
    // 그리고 진행중인 퀘스트 중에 같은 이름의 퀘스트가 있는지 체크를 한다 같은 것이 있으면 이미 진행중인 퀘스트입니다 알림이 뜬다 
    // 퀘스트 창이 비어있는지 확인한다 비어있지 않으면 퀘스트 슬롯이 꽉 찼습니다 알림이 뜬다(0번부터 해서 퀘스트이름이 "null"이면  aceeptSslotNumber를 그 숫자로 바꾸고 break;
    // 위의 3 경우가 아니라면 퀘스트를 수락할 수 있는데 퀘스트슬롯[aceeptSslotNumber]에 퀘스트 내용을 넣어준다 그리고 화면 Refresh를 해준다
    public void AcceptButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        aceeptSlotNumber = -1;

        // 클릭한 슬롯의 퀘스트 이름이 null인 경우 퀘스트가 없으므로 수락할 수 없기 떄문에 리턴한다 
        if (UIManager.instance.npcQuestSlot[selectSlotNumber].questName == "null")
        {
            StartCoroutine(QeustAcceptFailText());
            return;
        }


        for (int i = 4; i >= 0; i--)
        {
            // 진행중인 퀘스트에 받으려는 퀘스트와 같은 퀘스트가 있는 경우 리턴한다 
            if (UIManager.instance.quest_IngSlot[i].questName == UIManager.instance.npcQuestSlot[selectSlotNumber].questName)
            {
                StartCoroutine(QeustAcceptFailText());
                return;

            }
            // 빈 퀘스트 슬롯 번호를  aceeptSlotNumber에 넣는다 5부터 시작하므로 가장 작은것이 들어감 
            if (UIManager.instance.quest_IngSlot[i].questName == "null")
            {
                aceeptSlotNumber = i;
            }
        }

        // aceeptSlotNumber가 -1이라는 것은 빈 슬롯이 없다는 것이기 때문에 리턴 
        if (aceeptSlotNumber == -1)
        {
            StartCoroutine(QeustAcceptFailText());
            return;
        }


        // 받으려는 퀘스트의 타입이 stroy라면 캐릭터매니저의 stroy의 숫자와 받으려는 퀘스트 스토리 번호가 같아야 받을 수 있다 아니면 리턴시킨다 
        if(UIManager.instance.npcQuestSlot[selectSlotNumber].questType == "Story")
        {
            if (UIManager.instance.npcQuestSlot[selectSlotNumber].thStroy != CharacterManager.instance.story)
            {
                StartCoroutine(QeustAcceptFailText());
                return;
            }

        }
        UIManager.instance.npcQuestSlot[selectSlotNumber].questNameText.text = UIManager.instance.npcQuestSlot[selectSlotNumber].questName + "(진행중) ";
        // 위에서 리턴되지 않으면 퀘스트가 받아진다 클릭한 퀘스트 슬롯의 내용이 빈 퀘스트 슬롯에 들어간다 
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questName = UIManager.instance.npcQuestSlot[selectSlotNumber].questName;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questType = UIManager.instance.npcQuestSlot[selectSlotNumber].questType;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questKind = UIManager.instance.npcQuestSlot[selectSlotNumber].questKind;
        for(int i = 0; i < 12; i++)
           UIManager.instance.quest_IngSlot[aceeptSlotNumber].questExplain[i] = UIManager.instance.npcQuestSlot[selectSlotNumber].questExplain[i];
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questNpc = UIManager.instance.npcQuestSlot[selectSlotNumber].questNpc;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].thStroy = UIManager.instance.npcQuestSlot[selectSlotNumber].thStroy;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questRewardExp = UIManager.instance.npcQuestSlot[selectSlotNumber].questRewardExp;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questRewardMoney = UIManager.instance.npcQuestSlot[selectSlotNumber].questRewardMoney;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questRewardItemName = UIManager.instance.npcQuestSlot[selectSlotNumber].questRewardItemName;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questState = UIManager.instance.npcQuestSlot[selectSlotNumber].questState;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].needItemName = UIManager.instance.npcQuestSlot[selectSlotNumber].needItemName;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].needMeetingNPC = UIManager.instance.npcQuestSlot[selectSlotNumber].needMeetingNPC;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].meetingNpcFinish = UIManager.instance.npcQuestSlot[selectSlotNumber].meetingNpcFinish;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].needHuntingMonsterName = UIManager.instance.npcQuestSlot[selectSlotNumber].needHuntingMonsterName;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].needItemNumber = UIManager.instance.npcQuestSlot[selectSlotNumber].needItemNumber;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].needHuntingNumber = UIManager.instance.npcQuestSlot[selectSlotNumber].needHuntingNumber;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].currentCollecITemNumber = UIManager.instance.npcQuestSlot[selectSlotNumber].currentCollecITemNumber;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].currentHuntingMonsterNumber = UIManager.instance.npcQuestSlot[selectSlotNumber].currentHuntingMonsterNumber;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].bigItemType = UIManager.instance.npcQuestSlot[selectSlotNumber].bigItemType;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].smallItemType = UIManager.instance.npcQuestSlot[selectSlotNumber].smallItemType;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].price = UIManager.instance.npcQuestSlot[selectSlotNumber].price;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].itemExplain = UIManager.instance.npcQuestSlot[selectSlotNumber].itemExplain;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].quantity = UIManager.instance.npcQuestSlot[selectSlotNumber].quantity;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questRequireLevel = UIManager.instance.npcQuestSlot[selectSlotNumber].questRequireLevel;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questRequireAccmulateLevel = UIManager.instance.npcQuestSlot[selectSlotNumber].questRequireAccmulateLevel;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddHP = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddHP;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddMP = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddMP;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddMaxMP = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddMaxMP;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddMaxHP = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddMaxHP;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddSTR = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddSTR;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddHEL = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddHEL;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddINT = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddINT;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddLUK = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddLUK;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddPower = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddPower;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddMagicPower = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddMagicPower;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].maxAddDefence = UIManager.instance.npcQuestSlot[selectSlotNumber].maxAddDefence;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].coolTime = UIManager.instance.npcQuestSlot[selectSlotNumber].coolTime;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].stayTime = UIManager.instance.npcQuestSlot[selectSlotNumber].stayTime;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].addMaxHP = UIManager.instance.npcQuestSlot[selectSlotNumber].addMaxHP;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].addMaxMP = UIManager.instance.npcQuestSlot[selectSlotNumber].addMaxMP;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].addSTR = UIManager.instance.npcQuestSlot[selectSlotNumber].addSTR;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].addHEL = UIManager.instance.npcQuestSlot[selectSlotNumber].addHEL;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].addINT = UIManager.instance.npcQuestSlot[selectSlotNumber].addINT;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].addLUK = UIManager.instance.npcQuestSlot[selectSlotNumber].addLUK;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].addPower = UIManager.instance.npcQuestSlot[selectSlotNumber].addPower;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].addMagicPower = UIManager.instance.npcQuestSlot[selectSlotNumber].addMagicPower;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].addDefence = UIManager.instance.npcQuestSlot[selectSlotNumber].addDefence;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].requireAccumulateLevel = UIManager.instance.npcQuestSlot[selectSlotNumber].requireAccumulateLevel;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].requireLevel = UIManager.instance.npcQuestSlot[selectSlotNumber].requireLevel;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].requireSTR = UIManager.instance.npcQuestSlot[selectSlotNumber].requireSTR;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].requireHEL = UIManager.instance.npcQuestSlot[selectSlotNumber].requireHEL;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].requireINT = UIManager.instance.npcQuestSlot[selectSlotNumber].requireINT;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].requireLUK = UIManager.instance.npcQuestSlot[selectSlotNumber].requireLUK;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].enhanceLevel = UIManager.instance.npcQuestSlot[selectSlotNumber].enhanceLevel;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].enhanceStack = UIManager.instance.npcQuestSlot[selectSlotNumber].enhanceStack;
        UIManager.instance.quest_IngSlot[aceeptSlotNumber].sharePosiible = UIManager.instance.npcQuestSlot[selectSlotNumber].sharePosiible;

        UIManager.instance.quest_IngSlot[aceeptSlotNumber].questNameText.text = UIManager.instance.quest_IngSlot[aceeptSlotNumber].questName;  // 퀘스트이름 
        UIManager.instance.playCanvas.QuestingPanleRefresh();
}

    public void ExitButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        this.gameObject.SetActive(false);
        UIManager.instance.npcTalkWindow.gameObject.SetActive(true);
        selectSlotNumber = -1;
        aceeptSlotNumber = -1;
        UIManager.instance.npcQuest_FinishFailText.gameObject.SetActive(false);
        UIManager.instance.npcQuest_GIveUpFailText.gameObject.SetActive(false);
        UIManager.instance.npcQuest_AcceptFailText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator QeustFinishFailText()
    {
        UIManager.instance.npcQuest_FinishFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.npcQuest_FinishFailText.gameObject.SetActive(false);

    }

    IEnumerator QeustGiveUpFailText()
    {
        UIManager.instance.npcQuest_GIveUpFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.npcQuest_GIveUpFailText.gameObject.SetActive(false);

    }

    IEnumerator QeustAcceptFailText()
    {
        UIManager.instance.npcQuest_AcceptFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.npcQuest_AcceptFailText.gameObject.SetActive(false);
    }

}
