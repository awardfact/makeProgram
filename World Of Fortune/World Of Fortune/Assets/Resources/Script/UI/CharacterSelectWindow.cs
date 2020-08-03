using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

public class CharacterSelectWindow : MonoBehaviour
{
    // 캐릭터창 스크립트 
    public int SelectNumber;

    public bool CharacterExist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 게임 시작 버튼을 누르면 
    // 먼저 캐릭터를 클릭했는지 체크한 다음에 
    // 파일이 필요한 모든 스크립트에 있는 GameStart를 실행시켜준다 
    // 그리고 씬을 , 사운드를 바꿔준다 
    public void GameStartButtonClick()
    {
        if(SelectNumber != 0)
        {


           CharacterManager.instance.GameStart(SelectNumber);
            UIManager.instance.GameStart(SelectNumber);
            UIManager.instance.equip_WeaponSlot.GameStart(SelectNumber);
            UIManager.instance.equip_ArmorSlot.GameStart(SelectNumber);
            UIManager.instance.equip_ShoesSlot.GameStart(SelectNumber);
            UIManager.instance.equip_HelmetSlot.GameStart(SelectNumber);
            UIManager.instance.equip_EarringSlot.GameStart(SelectNumber);
            UIManager.instance.equip_ShieldSlot.GameStart(SelectNumber);
            UIManager.instance.equip_RingSlot.GameStart(SelectNumber);
            UIManager.instance.equip_GloveSlot.GameStart(SelectNumber);
            UIManager.instance.equip_NecklaceSlot.GameStart(SelectNumber);
            for (int i = 0; i < 32; i++)
                 {
                    UIManager.instance.item_EquipSlot[i].GameStart(SelectNumber);
                   UIManager.instance.item_ConsumeSlot[i].GameStart(SelectNumber);
                   UIManager.instance.item_EtcSlot[i].GameStart(SelectNumber);
                      UIManager.instance.item_CashSlot[i].GameStart(SelectNumber);
            }
              
             for (int i = 0; i <5; i++)
                   {
                       UIManager.instance.quest_IngSlot[i].GameStart(SelectNumber);

                   }

                   for(int i = 0; i <44; i++)
                   {
                       UIManager.instance.warehouse_ItemSlot[i].GameStart();
                   }


       
             for (int i = 0; i < 5; i++)
              {

                  UIManager.instance.quickSlot[i].GameStart(SelectNumber);

                 }

            UIManager.instance.character_DeletePanel.gameObject.SetActive(false);
            SceneManager.LoadScene("Scenes/FirstMap");
            SoundManager.instance.BGMChange("PeacefulBGM");

        }



    }

    // PC랑 모바일이랑 경로가 달라서 PC인지 모바일상태인지 버튼 눌러서 바꿔준다 
    public void EnvironMentButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        //실행환경이 모바일이면 PC로 바꿔줌 
        if (UIManager.instance.environment == "Mobile")
        {
            UIManager.instance.environment = "PC";
            UIManager.instance.environmentText.text = "PC\nPlay";
            for(int i = 0; i <3; i++)
            {
                UIManager.instance.CharacterSlot[i].Refresh();


            }


        }
        ///실행환경이 PC면 모바일로 바꿔줌 
        else
        {

            UIManager.instance.environment = "Mobile";
            UIManager.instance.environmentText.text = "Mobile\nPlay";
            for (int i = 0; i < 3; i++)
            {
                UIManager.instance.CharacterSlot[i].Refresh();
            }
        }

    }

    //캐릭터 삭제 패널에서 삭제하기 누르면 그 캐릭터의 모든 정보를 삭제시킨다 
    public void DeletePanelDeleteButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.environment == "Mobile")
        {
            if(File.Exists(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/CharacterInfo.txt"))
            {

                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/CharacterInfo.txt");
                for(int i = 0; i < 32; i++)
                {
                    File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipSlot_" + (i + 1) + ".txt");
                    File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/ConsumeSlot_" + (i + 1) + ".txt");
                    File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EtcSlot_" + (i + 1) + ".txt");
                    File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/CashSlot_" + (i + 1) + ".txt");
                }
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/HasMoney.txt");
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/HasCash.txt");
                for(int i = 0; i < 5; i++)
                {
                    File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber    + "/QuestSlot_" + (i + 1) + ".txt");
                    File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/QuickSlot_" + (i + 1) + ".txt");
                }
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipWeapon.txt");
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipArmor.txt");
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipShoes.txt");
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipHelmet.txt");
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipEarring.txt");
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipShield.txt");
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipRing.txt");
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipGlove.txt");
                File.Delete(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/EquipNecklace.txt");

            }



        }
        else
        {
            if (File.Exists("Assets/Resources/Load/Character" + SelectNumber + "/CharacterInfo.txt"))
            {
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/CharacterInfo.txt");
                for(int i = 0; i < 32; i++)
                {
                    File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipSlot_" + (i + 1) + ".txt");
                    File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/ConsumeSlot_" + (i + 1) + ".txt");
                    File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EtcSlot_" + (i + 1) + ".txt");
                    File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/CashSlot_" + (i + 1) + ".txt");
                }


                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/HasMoney.txt");
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/HasCash.txt");
                for(int i = 0; i < 5; i++)
                {
                    File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/QuestSlot_" + (i + 1) + ".txt");
                    File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/QuickSlot_" + (i + 1) + ".txt");


                }

                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipWeapon.txt");
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipArmor.txt");
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipShoes.txt");
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipHelmet.txt");
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipEarring.txt");
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipShield.txt");
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipRing.txt");
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipGlove.txt");
                File.Delete("Assets/Resources/Load/Character" + SelectNumber + "/EquipNecklace.txt");

            }




        }


        UIManager.instance.character_DeletePanel.gameObject.SetActive(false);
        UIManager.instance.CharacterSlot[SelectNumber -1].Refresh();


    }



    // 캐릭터 선택창에서 삭제 버튼을 누르면 선택한 캐릭터가 있다면 삭제 패넝이 실행된다 
    public void DeleteButton()
    {

        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (UIManager.instance.environment == "Mobile")
        {
            if (File.Exists(Application.persistentDataPath + "/Load/Character" + SelectNumber + "/CharacterInfo.txt"))
            {
                UIManager.instance.character_DeletePanel.gameObject.SetActive(true);
            }
         }
            else
        {

            if (File.Exists("Assets/Resources/Load/Character" + SelectNumber + "/CharacterInfo.txt"))
            {
                UIManager.instance.character_DeletePanel.gameObject.SetActive(true);
            }
        }
    }

    public void DeletePanelBackButton()
    {

        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.character_DeletePanel.gameObject.SetActive(false);




    }

    


    // 캐릭터가 현재 꽉 찬 상태가 아니라면 캐릭터  캐릭터 생성 창으로 화면을 바꿔준다 
    public void CharacterMakeButton()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        // 슬롯을 선택한 상태이며 그 슬롯에 캐릭터가 존재하지ㅣ 않을경우 뒤를 진행한다 
        if (SelectNumber != 0 && !CharacterExist)
        {

            this.gameObject.SetActive(false);
            UIManager.instance.character_CharacterAddWindow.gameObject.SetActive(true);
            UIManager.instance.character_CharacterAddWindow.diceStr = Random.Range(5, 21);
            UIManager.instance.character_CharacterAddWindow.diceHel = Random.Range(5, 21);
            UIManager.instance.character_CharacterAddWindow.diceInt = Random.Range(5, 21);
            UIManager.instance.character_CharacterAddWindow.diceLuk = Random.Range(5, 21);
            UIManager.instance.character_CharacterAddWindow.strText.text = UIManager.instance.character_CharacterAddWindow.diceStr.ToString();
            UIManager.instance.character_CharacterAddWindow.helText.text = UIManager.instance.character_CharacterAddWindow.diceHel.ToString();
            UIManager.instance.character_CharacterAddWindow.intText.text = UIManager.instance.character_CharacterAddWindow.diceInt.ToString();
            UIManager.instance.character_CharacterAddWindow.luckText.text = UIManager.instance.character_CharacterAddWindow.diceLuk.ToString();
            UIManager.instance.character_DeletePanel.gameObject.SetActive(false);
        }
        // 아니면 생성할 수 없다고 메시지를 띄운다 
        else
        {

            StartCoroutine(ChracterAddFailText());
        }



    }


    // 추가 실패 코루틴 
    IEnumerator ChracterAddFailText()
    {
        UIManager.instance.character_CharacterAddFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.character_CharacterAddFailText.gameObject.SetActive(false);
    }





}
