using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{

    public string skillName; // 스킬이름
    public string skillType; // 스킬 타입
    public string skillExplain; // 스킬설명 
    public long skillLevel; // 스킬레벨 

    public long useHP; // 소모 체력 
    public long useMP; // 소모 마나 

    public long upHitDamege;  // 찍었을 때 올라가는 데미지

    public long oneHitDamege;  // 1회 히트당 데미지 
    public long hitNumber; // 히트수 
    public long hitMonsterNumber; // 히트몹수 
    public float stayTime;

    public string job; // 직업
    public int jobth; // 차수 


    public long passive_AddMaxHP; // 패시브 증가스텟 
    public long passive_AddMaxMP;
    public long passive_AddSTR;
    public long passive_AddHEL;
    public long passive_AddINT;
    public long passive_AddLUK;
    public long passive_AaddPower;
    public long passive_AddMagicPower;
    public long passive_AddDefence;

    public long passive_UpAddMaxHP; // 패시브  찍을 시 증가스텟 
    public long passive_UpAddMaxMP;
    public long passive_UpAddSTR;
    public long passive_UpAddHEL;
    public long passive_UpAddINT;
    public long passive_UpAddLUK;
    public long passive_UpAaddPower;
    public long passive_UpAddMagicPower;
    public long passive_UpAddDefence;

    public float buff_StayTime; // 버프 증가스텟 
    public long buff_AddMaxHP;
    public long buff_AddMaxMP;
    public long buff_AddSTR;
    public long buff_AddHEL;
    public long buff_AddINT;
    public long buff_AddLUK;
    public long buff_AddPower;
    public long buff_AddMagicPower;
    public long buff_AddDefence;

    public float buff_UpStayTime; // 버프 찍을 시 증가스텟 
    public long buff_UpAddMaxHP;
    public long buff_UpAddMaxMP;
    public long buff_UpAddSTR;
    public long buff_UpAddHEL;
    public long buff_UpAddINT;
    public long buff_UpAddLUK;
    public long buff_UpAddPower;
    public long buff_UpAddMagicPower;
    public long buff_UpAddDefence;



    public Image skillImage; // 스킬 이미지 
    public Text skillLevelText; // 스킳 레벨텍스트 
    public Text skillNameText; // 스킬 이름텍스트 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.skill_NameText.text = skillName;
        if(skillType == "Active")
        {

        }
        else if(skillType == "Buff")
        {



        }
        else if(skillType == "Passive")
        {



        }

    }

    public void Refresh()
    {
        skillLevelText.text = skillLevel.ToString();

    }
}
