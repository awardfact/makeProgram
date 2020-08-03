using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillWindow : MonoBehaviour
{


    // 1차스킬 버튼을 클릭하면 일어나는 이벤트
    //만약 1차전직 이상이면  1차스킬 패널을 활성화한다 
   public void Skill_1thButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.showSkill == 0 && CharacterManager.instance.thJob >= 1)
        {

            UIManager.instance.skill_1thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_1thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 1;
        }else if(UIManager.instance.showSkill == 1 && CharacterManager.instance.thJob >= 1)
        {
            return;
        }
        else if (UIManager.instance.showSkill == 2 && CharacterManager.instance.thJob >= 1)
        {
            UIManager.instance.skill_2thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_2thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_1thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_1thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 1;
        }
        else if (UIManager.instance.showSkill == 3 && CharacterManager.instance.thJob >= 1)
        {
            UIManager.instance.skill_3thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_3thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_1thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_1thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 1;
        }
        else if (UIManager.instance.showSkill == 4 && CharacterManager.instance.thJob >= 1)
        {
            UIManager.instance.skill_4thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_4thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_1thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_1thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 1;
        }

    }


    // 2차스킬 버튼을 클릭하면 일어나는 이벤트
    //만약 2차전직 이상이면  2차스킬 패널을 활성화한다 
    public void Skill_2thButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.showSkill == 0 && CharacterManager.instance.thJob >= 2)
        {

            UIManager.instance.skill_2thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_2thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 2;
        }
        else if (UIManager.instance.showSkill == 1 && CharacterManager.instance.thJob >= 2)
        {
            UIManager.instance.skill_1thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_1thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_2thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_2thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 2;
        }
        else if (UIManager.instance.showSkill == 2 && CharacterManager.instance.thJob >= 2)
        {
            return;
        }
        else if (UIManager.instance.showSkill == 3 && CharacterManager.instance.thJob >= 2)
        {
            UIManager.instance.skill_3thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_3thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_2thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_2thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 2;
        }
        else if (UIManager.instance.showSkill == 4 && CharacterManager.instance.thJob >= 2)
        {
            UIManager.instance.skill_4thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_4thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_2thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_2thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 2;
        }
    }


    // 3차스킬 버튼을 클릭하면 일어나는 이벤트
    //만약 3차전직 이상이면  3차스킬 패널을 활성화한다 
    public void Skill_3thButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.showSkill == 0 && CharacterManager.instance.thJob >= 3)
        {

            UIManager.instance.skill_3thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_3thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 3;
        }
        else if (UIManager.instance.showSkill == 1 && CharacterManager.instance.thJob >= 3)
        {
            UIManager.instance.skill_1thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_1thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_3thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_3thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 3;
        }
        else if (UIManager.instance.showSkill == 2 && CharacterManager.instance.thJob >= 3)
        {
            UIManager.instance.skill_2thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_2thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_3thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_3thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 3;
        }
        else if (UIManager.instance.showSkill == 3 && CharacterManager.instance.thJob >= 3)
        {
            return;
        }
        else if (UIManager.instance.showSkill == 4 && CharacterManager.instance.thJob >= 3)
        {
            UIManager.instance.skill_4thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_4thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_3thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_3thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 3;
        }
    }


    // 4차스킬 버튼을 클릭하면 일어나는 이벤트
    //만약 4차전직 이상이면  4차스킬 패널을 활성화한다 
    public void Skill_4thButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.showSkill == 0 && CharacterManager.instance.thJob >= 4)
        {

            UIManager.instance.skill_4thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_4thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 4;
        }
        else if (UIManager.instance.showSkill == 1 && CharacterManager.instance.thJob >= 4)
        {
            UIManager.instance.skill_1thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_1thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_4thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_4thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 4;
        }
        else if (UIManager.instance.showSkill == 2 && CharacterManager.instance.thJob >= 4)
        {
            UIManager.instance.skill_2thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_2thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_4thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_4thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 4;
        }
        else if (UIManager.instance.showSkill == 3 && CharacterManager.instance.thJob >= 4)
        {
            UIManager.instance.skill_3thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_3thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_4thPanel.gameObject.SetActive(true);
            UIManager.instance.skill_4thButton.image.color = new Color(1, 1, 1);
            UIManager.instance.showSkill = 4;
        }
        else if (UIManager.instance.showSkill == 4 && CharacterManager.instance.thJob >= 4)
        {
            return;
        }
    }


    public void SkillReset()
    {

            UIManager.instance.skill_1thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_1thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_2thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_2thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_3thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_3thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.skill_4thPanel.gameObject.SetActive(false);
            UIManager.instance.skill_4thButton.image.color = new Color(128f / 255f, 122f / 255f, 122f / 255f);
            UIManager.instance.showSkill = 0;

    }




    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        this.gameObject.SetActive(false);
    }

    public IEnumerator SkillUpFailText()
    {
        UIManager.instance.skill_FailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.skill_FailText.gameObject.SetActive(false);
    }


}
