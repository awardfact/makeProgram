using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatWindow : MonoBehaviour
{

    public long statInputField;
    public long rand;

    //먼저 인풋필드에 입력한 값을 체크를 한다 
    //입력한 값보다 ap가 적으면 ap가 부족하다고 출력한다 ]
    //ap가 충분히 있으면 스텟을 찍고 refresh시켜준다 (ap 1로 스텟을 찍으면 1~3값이 나오는데 랜덤으로 나온 값만큼 스텟이 오른다 ap1 = hp,mp는 10~30 다른 스텟은 1~3)
    public void HPUpButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (!long.TryParse(UIManager.instance.stat_InputField.text, out statInputField))
        {
            statInputField = 1;
        }

        if(CharacterManager.instance.AP >= statInputField && statInputField >= 1)
        {
            CharacterManager.instance.AP -= statInputField;
            rand = (long)Random.Range(0, (statInputField * 2) + 1) + statInputField;
            CharacterManager.instance.maxHP += (rand * 3);
            Refresh();
        }
        else
        {
            StartCoroutine(StatUpFailText());
        }
    }

    public void MPUpButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (!long.TryParse(UIManager.instance.stat_InputField.text, out statInputField))
        {
            statInputField = 1;
        }

        if (CharacterManager.instance.AP >= statInputField && statInputField >= 1)
        {
            CharacterManager.instance.AP -= statInputField;
            rand = (long)Random.Range(0, (statInputField * 2) + 1) + statInputField;
            CharacterManager.instance.maxMP += (rand * 3);
            Refresh();
        }
        else
        {
            StartCoroutine(StatUpFailText());
        }
    }

    public void STRUpButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (!long.TryParse(UIManager.instance.stat_InputField.text, out statInputField))
        {
            statInputField = 1;
        }
        if (CharacterManager.instance.AP >= statInputField && statInputField >= 1)
        {
            CharacterManager.instance.AP -= statInputField;
            rand = (long)Random.Range(0, (statInputField * 2) + 1) + statInputField;
            CharacterManager.instance.STR += rand;
            Refresh();
        }
        else
        {
            StartCoroutine(StatUpFailText());
        }
    }

    public void HELUpButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (!long.TryParse(UIManager.instance.stat_InputField.text, out statInputField))
        {
            statInputField = 1;
        }
        if (CharacterManager.instance.AP >= statInputField && statInputField >= 1)
        {
            CharacterManager.instance.AP -= statInputField;
            rand = (long)Random.Range(0, (statInputField * 2) + 1) + statInputField;
            CharacterManager.instance.HEL += rand;
            Refresh();
        }
        else
        {
            StartCoroutine(StatUpFailText());
        }
    }

    public void INTUpButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (!long.TryParse(UIManager.instance.stat_InputField.text, out statInputField))
        {
            statInputField = 1;
        }
        if (CharacterManager.instance.AP >= statInputField && statInputField >= 1)
        {
            CharacterManager.instance.AP -= statInputField;
            rand = (long)Random.Range(0, (statInputField * 2) + 1) + statInputField;
            CharacterManager.instance.INT += rand;
            Refresh();
        }
        else
        {
            StartCoroutine(StatUpFailText());
        }
    }

    public void LUKUpBUttonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (!long.TryParse(UIManager.instance.stat_InputField.text, out statInputField))
        {
            statInputField = 1;
        }
        if (CharacterManager.instance.AP >= statInputField && statInputField >= 1)
        {
            CharacterManager.instance.AP -= statInputField;
            rand = (long)Random.Range(0, (statInputField * 2) + 1) + statInputField;
            CharacterManager.instance.LUK += rand;
            Refresh();
        }
        else
        {
            StartCoroutine(StatUpFailText());
        }
    }

    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        this.gameObject.SetActive(false);
    }

    // 스텟 초기화 할떄 호출 최종 스텟을 다시 계산하고 그것을 스텟창에 다시 보여준다 
    public void Refresh()
    {

        CharacterManager.instance.resultSTR = CharacterManager.instance.STR + CharacterManager.instance.addSTR;
        CharacterManager.instance.resultHEL = CharacterManager.instance.HEL + CharacterManager.instance.addHEL;
        CharacterManager.instance.resultINT = CharacterManager.instance.INT + CharacterManager.instance.addINT;
        CharacterManager.instance.resultLUK = CharacterManager.instance.LUK + CharacterManager.instance.addLUK;
        CharacterManager.instance.resultMaxHP = CharacterManager.instance.maxHP + CharacterManager.instance.addMaxHP + (long)(CharacterManager.instance.resultSTR * 0.5) + (long)(CharacterManager.instance.resultHEL * 1);
        CharacterManager.instance.resultMaxMP = CharacterManager.instance.maxMP + CharacterManager.instance.addMaxMP + (long)(CharacterManager.instance.resultINT * 1) + (long)(CharacterManager.instance.resultHEL * 0.1);
        CharacterManager.instance.power = (long)(CharacterManager.instance.resultSTR * 0.2) + (long)(CharacterManager.instance.resultHEL * 0.02) + CharacterManager.instance.addPower;
        CharacterManager.instance.magicPower = (long)(CharacterManager.instance.resultINT * 0.2) + (long)(CharacterManager.instance.resultHEL * 0.02) + CharacterManager.instance.addMagicPower;
        CharacterManager.instance.defence = (long)(CharacterManager.instance.resultSTR * 0.02) + (long)(CharacterManager.instance.resultINT * 0.02) + (long)(CharacterManager.instance.resultHEL * 0.2) + CharacterManager.instance.addDefence;
        UIManager.instance.stat_NameText.text = "이름 : " +  CharacterManager.instance.CharacterName;
        UIManager.instance.stat_JobText.text = "직업 : "  + CharacterManager.instance.job + "(" + CharacterManager.instance.thJob + ")";
        UIManager.instance.stat_LevelText.text = "레벨 : " + CharacterManager.instance.Level.ToString();
        UIManager.instance.stat_AccumulateLevelText.text = "누적레벨 : " + CharacterManager.instance.accumulateLevel.ToString();
        UIManager.instance.stat_MagicPowerText.text = "마력 : " + CharacterManager.instance.magicPower.ToString();
        UIManager.instance.stat_PowerText.text = "공격력 : " + CharacterManager.instance.power;
        UIManager.instance.stat_DefenceText.text = "방어력 : " + CharacterManager.instance.defence.ToString();
        UIManager.instance.stat_HPText.text = "체력 : " + CharacterManager.instance.resultMaxHP.ToString();
        UIManager.instance.stat_MPText.text = "마나 : " + CharacterManager.instance.resultMaxMP.ToString();
        UIManager.instance.stat_STRText.text = "힘 : " + CharacterManager.instance.resultSTR + "(" + CharacterManager.instance.STR + " + " + CharacterManager.instance.addSTR + ")";
        UIManager.instance.stat_HLEText.text = "건강 : " + CharacterManager.instance.resultHEL + "(" + CharacterManager.instance.HEL + " + " + CharacterManager.instance.addHEL + ")";
        UIManager.instance.stat_INTText.text = "지능 : " + CharacterManager.instance.resultINT + "(" + CharacterManager.instance.INT + " + " + CharacterManager.instance.addINT +")";
        UIManager.instance.stat_LUKText.text = "운 : " + CharacterManager.instance.resultLUK + "(" + CharacterManager.instance.LUK + " + " + CharacterManager.instance.addLUK + ")";
        UIManager.instance.stat_APText.text = "AP : " + CharacterManager.instance.AP.ToString();
        UIManager.instance.stat_HPRegenerateText.text = "체력재생 : " + (CharacterManager.instance.resultHEL * 0.2).ToString();
        UIManager.instance.stat_MPRegenerateText.text = "마나재생 : " + (CharacterManager.instance.resultINT *0.1).ToString();
        UIManager.instance.playCanvas.LevelRefresh();
        UIManager.instance.playCanvas.HPBarRefresh();
        UIManager.instance.playCanvas.MPBarRefresh();
    }


    // 스텟찍기 실패 메시지
    IEnumerator StatUpFailText()
    {
        UIManager.instance.stat_StatUpFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.stat_StatUpFailText.gameObject.SetActive(false);
    }


}




