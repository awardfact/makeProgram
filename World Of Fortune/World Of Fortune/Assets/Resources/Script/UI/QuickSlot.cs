using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class QuickSlot : MonoBehaviour
{                     // 퀵슬롯에 등록한 것에 대한 정보를 담는 스크립트 

    StreamWriter streamWriter;
    StreamReader streamReader;
    string s;

    public string itemName;



    public string slotType;  // 스킬인지 아이템인지 
    public int itemSlotNumber;

    public Image itemImage;
    public Text quantityText;

    public void Start()
    {
        itemImage = transform.Find("Image").gameObject.GetComponent<Image>();
        quantityText = transform.Find("Text").gameObject.GetComponent<Text>();
    }


    public void SlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        // 퀵슬롯에 등록한 것이 아이템이면 아이템을 사용하고 숫자를 재조정한다 
        if (slotType == "Item")
        {
            UIManager.instance.item_ConsumeSlot[itemSlotNumber].Use();
            Refresh();

        }
    }

  
    

    public void Refresh()
    {

        if (slotType == "Item")
        {

            if (UIManager.instance.item_ConsumeSlot[itemSlotNumber].itemName == itemName)
            {
                itemImage.sprite = Resources.Load("Sprite/Item/Consume/" + UIManager.instance.item_ConsumeSlot[itemSlotNumber].itemName, typeof(Sprite)) as Sprite;
                itemImage.color = new Color(1, 1, 1, 1);
                // quantityText.text = UIManager.instance.item_ConsumeSlot[itemSlotNumber].quantity.ToString();
                quantityText.text = UIManager.instance.item_ConsumeSlot[itemSlotNumber].quantity.ToString();

            }
            else
            {
                itemImage.sprite = null;
                itemImage.color = new Color(1, 1, 1, 0);
                quantityText.text = 0.ToString();
                itemName = "null";
                slotType = "null";
                itemSlotNumber = -1;
            }
        }



    }

    public void Save()
    {

        if (UIManager.instance.environment == "Mobile")
        {
            streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + CharacterManager.instance.characterNumber + "/QuickSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(slotType + "`");
            streamWriter.Write(itemSlotNumber + "`");
            streamWriter.Write(itemName + "`");
            streamWriter.Close();

        }

        
        else
        {
            streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + CharacterManager.instance.characterNumber + "/QuickSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(slotType + "`");
            streamWriter.Write(itemSlotNumber + "`");
            streamWriter.Write(itemName + "`");
            streamWriter.Close();



        }
    }



    public void GameStart(int selectSlot)
    {


        //모바일일때 경로 
        if (UIManager.instance.environment == "Mobile")
        {

            streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/QuickSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            slotType = s.Split('`')[0];
            int.TryParse(s.Split('`')[1], out itemSlotNumber);
            itemName = s.Split('`')[2];
            streamReader.Close();
            Refresh();

        }
        // PC일때 경로 
        else
        {

            streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/QuickSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            slotType = s.Split('`')[0];
            int.TryParse(s.Split('`')[1], out itemSlotNumber);
            itemName = s.Split('`')[2];
            streamReader.Close();
            Refresh();

        }

        


    }

}
