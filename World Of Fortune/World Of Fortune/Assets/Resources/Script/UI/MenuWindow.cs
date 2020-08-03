using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuWindow : MonoBehaviour
{





    // Start is called before the first frame update
    void Start()
    {

    }

    //닫기 버튼을 눙르면 닫힌다 
    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        this.gameObject.SetActive(false);
    }


    //아이템창 버튼을 누르면 아이템 창이 열린다 
    public void ItemButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.itemWindow.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    // 스텟창 버튼을 누르면 스텟창이 열린다 
    public void StatButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.statWindow.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    //스킬 창 버튼을 누르면 스킬창이 열린다 
    public void SkillButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.skillWindow.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

    }

    // 장비창 버튼을 누르면 장비창이 열린다 
    public void EqipButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.equipWindow.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    //퀘스트창 버튼을 누르면 퀘스트창이 열린다 
    public void QuestButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.questWindow.gameObject.SetActive(true);
        this.gameObject.SetActive(false);

    }


    // 저장하기 버튼을 클릭하면 불러온 정보들을 다시 저장한다 
    public void SaveButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        CharacterManager.instance.Save();
        UIManager.instance.equip_WeaponSlot.Save();
        UIManager.instance.equip_ArmorSlot.Save();
        UIManager.instance.equip_ShoesSlot.Save();
        UIManager.instance.equip_HelmetSlot.Save();
        UIManager.instance.equip_EarringSlot.Save();
        UIManager.instance.equip_ShieldSlot.Save();
        UIManager.instance.equip_RingSlot.Save();
        UIManager.instance.equip_GloveSlot.Save();
        UIManager.instance.equip_NecklaceSlot.Save();
        for (int i = 0; i < 32; i++)
        {
         UIManager.instance.item_EquipSlot[i].Save();
         UIManager.instance.item_ConsumeSlot[i].Save();
          UIManager.instance.item_EtcSlot[i].Save();
           UIManager.instance.item_CashSlot[i].Save();
        }
        for (int i = 0; i < 44; i++)
        {
            UIManager.instance.warehouse_ItemSlot[i].Save();
        }
        for (int i = 0; i < 5; i++)
        {
            UIManager.instance.quest_IngSlot[i].Save();

        }
        for (int i = 0; i < 5; i++)
        {

            UIManager.instance.quickSlot[i].Save();

        }
        UIManager.instance.Save();


    }

  
    public void CashShopButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);


    }

    public void SetUpButtonClick()
    {

        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);


    }

    public void CharacterSelectButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);



    }


    public void WorldMapButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);


    }



    public void HelpButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.playCanvas.helpPanel.gameObject.SetActive(true);
        CharacterManager.instance.helpPanelVisible = true;

    }


    public void GameEndButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        Application.Quit();
    }
}
