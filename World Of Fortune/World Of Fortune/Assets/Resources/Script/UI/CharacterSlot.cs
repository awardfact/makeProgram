using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSlot : MonoBehaviour
{
    // 캐릭터 슬롯 스크립트 

    public Text nameText;
    public Text levelText;
    public Image portrait;



    public string name;
    public int level;

    public int slotNumber;
    StreamReader streamReader;
    string s;




    // Start is called before the first frame update
    void Start()
    {
        portrait = transform.Find("PortraitImage").gameObject.GetComponent<Image>();
        levelText = transform.Find("LevelText").gameObject.GetComponent<Text>();
        nameText = transform.Find("NameText").gameObject.GetComponent<Text>();

        Refresh();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //캐릭터 슬롯을 클릭했을 때 발생 
    // 클릭한 슬롯에 캐릭터가 있으면 그 캐릭터 정보가 나오고 없으면 빈 슬롯 이렇게 나온다 
    public void slotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        //선택한 슬롯의 번호를 넘겨준다 
        UIManager.instance.characterSelecWindow.SelectNumber = int.Parse(this.transform.name.Split('_')[1]);
        UIManager.instance.character_CharacterAddWindow.selectNumber = int.Parse(this.transform.name.Split('_')[1]);
        // 그 슬롯에 캐릭터가 있으면 true없으면 false를 넘겨준다 
        if(UIManager.instance.environment == "Mobile")
        {
            if (!File.Exists(Application.persistentDataPath + "/Load/Character" + UIManager.instance.characterSelecWindow.SelectNumber + "/CharacterInfo.txt"))
            {
                UIManager.instance.characterSelecWindow.CharacterExist = false;
                UIManager.instance.character_SelectCharacterText.text = "선택한 슬롯에는 캐릭터가 없습니다.";
            }
            else
            {
                UIManager.instance.characterSelecWindow.CharacterExist = true;
                UIManager.instance.character_SelectCharacterText.text = "선택한 캐릭터 : " + name;
            }

        }
        else
        {

            if (!File.Exists("Assets/Resources/Load/Character" + UIManager.instance.characterSelecWindow.SelectNumber + "/CharacterInfo.txt"))
            {
                UIManager.instance.characterSelecWindow.CharacterExist = false;
                UIManager.instance.character_SelectCharacterText.text = "선택한 슬롯에는 캐릭터가 없습니다.";
            }
            else
            {
                UIManager.instance.characterSelecWindow.CharacterExist = true;
                UIManager.instance.character_SelectCharacterText.text = "선택한 캐릭터 : " + name;
            }



        }



    }



    public void Refresh()
    {
        slotNumber = int.Parse(this.transform.name.Split('_')[1]);
        //캐릭터가 있으면 캐릭터 이름 레벨 초상화를 표시한다 

        if(UIManager.instance.environment == "Mobile")
        {
            if (File.Exists(Application.persistentDataPath + "/Load/Character" + slotNumber + "/CharacterInfo.txt"))
            {

                streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + slotNumber + "/CharacterInfo.txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                name = s.Split('`')[0];
                int.TryParse(s.Split('`')[6], out level);
                nameText.text = "이름 : " + s.Split('`')[0];
                levelText.text = "레벨 : " + level;
                portrait.sprite = Resources.Load("Sprite/Player/Warrior/Portrait", typeof(Sprite)) as Sprite;
                portrait.color = new Color(1, 1, 1, 1);
                streamReader.Close();
            }
            // 없으면 빈 상태 
            else
            {
                nameText.text = "이름 : ";
                levelText.text = "레벨 : ";
                portrait.color = new Color(1, 1, 1, 0);
            }
        }
        else
        {
            if (File.Exists("Assets/Resources/Load/Character" + slotNumber + "/CharacterInfo.txt"))
            {

                streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + slotNumber + "/CharacterInfo.txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                name = s.Split('`')[0];
                int.TryParse(s.Split('`')[6], out level);
                nameText.text = "이름 : " + s.Split('`')[0];
                levelText.text = "레벨 : " + level;
                portrait.sprite = Resources.Load("Sprite/Player/Warrior/Portrait", typeof(Sprite)) as Sprite;
                portrait.color = new Color(1, 1, 1, 1);
                streamReader.Close();
            }
            // 없으면 빈 상태 
            else
            {
                nameText.text = "이름 : ";
                levelText.text = "레벨 : ";
                portrait.color = new Color(1, 1, 1, 0);

            }

        }


    }
}
