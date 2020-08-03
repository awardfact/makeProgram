using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackEnhance_1_1 : MonoBehaviour    // 1차 1번쨰 스킬 (평타 강화)
{
    public string skillName;
    public string skillType;
    public string skillExplain;
    public int skillLevel;

    public string job; // 직업
    public int jobth; // 차수 
    public int masterLevel; // 스킬 마스터레벨 

    public int normalPlusAttack;  // 레벨 0일떄 상태 0%증가
    public int currentPlusAttackDamege; //현재 스킬로 올라간 평타 데미지 
    public int upPlustAttackDamege; // 레벨 올라갈때 마다 증가량 

    public int beforePlusAttackDamege;

    public int skillLevelTemp;
    public int currentPlusAttackDamgeTemp;
 

    public Image skillImage; // 스킬 이미지 
    public Text skillLevelText; // 스킳 레벨텍스트 
    public Text skillNameText; // 스킬 이름텍스트 
    public Button skillLevelUpButton; //스킬 레벨업 버튼 
    
    public int rand;

    // Start is called before the first frame update
    void Start()
    {
        // 변수는 파일에서 불러온다 
        skillImage = transform.Find("SkillImage").gameObject.GetComponent<Image>();
        skillLevelText = transform.Find("SkillLevelText").gameObject.GetComponent<Text>();
        skillNameText = transform.Find("SkillNameText").gameObject.GetComponent<Text>();
        skillLevelUpButton = transform.Find("SkillUpButton").gameObject.GetComponent<Button>();

        skillName = "평타강화";
        skillType = "패시브";
        skillLevelText.text = skillLevel.ToString();
        skillNameText.text = skillName;
        skillExplain = "평타의 데미지를 일정 비율 증가시켜주는 스킬이다. 스킬을 많이 찍을수록 효율이 좋다.";
        job = "Warrior";
        skillLevel = 0;
        jobth = 1;
        normalPlusAttack = 0;
        currentPlusAttackDamege = 0;
        upPlustAttackDamege = 5;
        masterLevel = 100;
    }

    // 스킬을 클릭하면 스킬 정보가 나온다 
    public void SlotButtonClick()
    {
        UIManager.instance.skill_NameText.text = skillName;
        UIManager.instance.skill_ExplainText.text = skillExplain + "\n" + "스킬레벨 : " + CharacterManager.instance.skillLevel1_1 + "\n" + "평타 데미지 증가량 : " +
            (int)(currentPlusAttackDamege) + "%" + "\n" + "스킬레벨 증가시 증가량 : 1 ~  " + (upPlustAttackDamege * (1 + ((skillLevel / 10) * 0.2))) + "%\n" + 
            "마스터 레벨 : " + masterLevel;
    }

    //SP가 있는지 체크한다 
    //Sp가 있으면 스킬레벨을 올리고 스킬 효과도 올린다 
    //필요한 것들을 Refresh해준다 
    public void SkillLevelUpButtonClick()
    {
        if(CharacterManager.instance.SP >= 1 && skillLevel < masterLevel)
        {

            CharacterManager.instance.SP -= 1;
            skillLevel += 1;
            CharacterManager.instance.skillLevel1_1 += 1;
            rand = (int)Random.Range(1,upPlustAttackDamege * (1+ ((skillLevel / 10) * 0.2f)) + 1);
            currentPlusAttackDamege += rand;
            CharacterManager.instance.basicAttackMultiple = currentPlusAttackDamege;
            beforePlusAttackDamege = currentPlusAttackDamege;
            Refresh();
        }
        else
        {

            StartCoroutine(UIManager.instance.skillWindow.SkillUpFailText());
        }
    }


    // 스킬포인트 1개 되돌리기 
    // 스킬레벨이 1 이상이고 저번꺼되돌리지 않았을 때 가능 
    // 스킬포인트 1 증가, 스킬레벨 1 감소 스킬 공격력 전 레벨로 되돌림 
    public void SkillLevel1Reset()
    {
        if(skillLevel >= 1 && beforePlusAttackDamege != 0)
        {
            CharacterManager.instance.SP += 1;
            CharacterManager.instance.skillLevel1_1 -= 1;
            skillLevel -= 1;
            currentPlusAttackDamege = beforePlusAttackDamege;
            beforePlusAttackDamege = 0;
            CharacterManager.instance.basicAttackMultiple = currentPlusAttackDamege;
            Refresh();
        }
    }
    


    // 스킬정보를 현재 상태로 보여줌 
    public void Refresh()
    {
        skillLevelText.text = skillLevel.ToString();
        UIManager.instance.skill_SPText.text = "SP : "  + CharacterManager.instance.SP.ToString();
        UIManager.instance.skill_NameText.text = skillName;
        UIManager.instance.skill_ExplainText.text = skillExplain + "\n" + "스킬레벨 : " + skillLevel + "\n" + "평타 데미지 증가량 : " +
            (currentPlusAttackDamege) + "%" + "\n" + "스킬레벨 증가시 증가량 : 1 ~  " + (upPlustAttackDamege * (1 + ((skillLevel / 10) * 0.2))) + "%\n" +
            "마스터 레벨 : " + masterLevel;
    }

    // 환생했을때 스킬을 초기화시켜줌
    public void SkillReset()
    {

        skillLevelTemp = skillLevel;
        skillLevel = 0;
        currentPlusAttackDamgeTemp = currentPlusAttackDamege;
        CharacterManager.instance.skillLevel1_1 = 0;
        currentPlusAttackDamege = 0;
        CharacterManager.instance.basicAttackMultiple = currentPlusAttackDamege;
        Refresh();
    }


    // 환생 취소하면 원래대로 되돌림 
    public void SKillReturnReset()
    {

        skillLevel = skillLevelTemp;
        CharacterManager.instance.skillLevel1_1 = skillLevelTemp;
        currentPlusAttackDamege = currentPlusAttackDamgeTemp;
        CharacterManager.instance.basicAttackMultiple = currentPlusAttackDamgeTemp;
        Refresh();
    }


}

