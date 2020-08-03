using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhanceItemSlot : MonoBehaviour
{
    public bool setActive; 
    public int slotNumber;
    public Image itemImage;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = transform.Find("Image").gameObject.GetComponent<Image>();

    }




    // 강화창에서 슬롯 버튼 눌렀을 때 
    public void SlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        // 몇번 슬롯 눌렀는지 slotNumber변수에 넣는다 
        slotNumber = int.Parse(this.transform.name.Split('_')[1]) - 1;

        // 아이템 정보창이 setActive(false)인 상태여야 새로 클릭한 슬롯의 아이템 정보가 나온다 
        if (!UIManager.instance.npcEnhanceWindow.setActive)
        {

            if (UIManager.instance.item_EquipSlot[slotNumber].itemName != "null")
            {
                UIManager.instance.enhance_SelectItemPanel.gameObject.SetActive(true);
                UIManager.instance.npcEnhanceWindow.setActive = true;
                UIManager.instance.enhance_SelectItemExplainText.text = UIManager.instance.item_EquipSlot[slotNumber].itemName + "\n" + UIManager.instance.item_EquipSlot[slotNumber].smallItemType +
                    "\n가격 : " + UIManager.instance.item_EquipSlot[slotNumber].price + "\n공격력 : + " + UIManager.instance.item_EquipSlot[slotNumber].addPower +
                    " 마력 : + " + UIManager.instance.item_EquipSlot[slotNumber].addMagicPower + "\n방어력 : + " + UIManager.instance.item_EquipSlot[slotNumber].addDefence +
                    "최대체력 : + " + UIManager.instance.item_EquipSlot[slotNumber].addMaxHP + " 최대마나 : + "
                    + UIManager.instance.item_EquipSlot[slotNumber].addMaxMP + "\n힘 : + " + UIManager.instance.item_EquipSlot[slotNumber].addSTR + " 건강 : + " +
                    UIManager.instance.item_EquipSlot[slotNumber].addHEL + "\n지능 : + "
                + UIManager.instance.item_EquipSlot[slotNumber].addINT + " 운 : + " + UIManager.instance.item_EquipSlot[slotNumber].addLUK + "\n" + "착용 요구치 \n레벨 :  "
                + UIManager.instance.item_EquipSlot[slotNumber].requireLevel +
                " 누적레벨 :  " + UIManager.instance.item_EquipSlot[slotNumber].requireAccumulateLevel + "\nSTR : "
                + UIManager.instance.item_EquipSlot[slotNumber].requireSTR + " HEL : " + UIManager.instance.item_EquipSlot[slotNumber].requireHEL + "\nINT : " + UIManager.instance.item_EquipSlot[slotNumber].requireINT +
                " LUK : " + UIManager.instance.item_EquipSlot[slotNumber].requireLUK + "\n강화의 비약 : " + UIManager.instance.item_EquipSlot[slotNumber].enhanceStack + " 중첩 ";

                UIManager.instance.npcEnhanceWindow.clickkSlotNumber = slotNumber;
            }
            else
            {
                StartCoroutine(ItemSelectFailText());
            }


        }

    }

    public void Refresh()
    {
        if(UIManager.instance.item_EquipSlot[int.Parse(this.transform.name.Split('_')[1]) - 1].itemName != "null")
        {
            itemImage.sprite = UIManager.instance.item_EquipSlot[int.Parse(this.transform.name.Split('_')[1]) - 1].itemImage.sprite;
            itemImage.color = new Color(1, 1, 1, 1);

        }
        else
        {


            itemImage.color = new Color(1, 1, 1, 0);

        }

    }

    //아이템 슬롯에 아이템이 없을때 코루틴 호출 
    public IEnumerator ItemSelectFailText()
    {

        UIManager.instance.enhance_ItemSelectFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.enhance_ItemSelectFailText.gameObject.SetActive(false);
    }


}
