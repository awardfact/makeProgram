using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWindow : MonoBehaviour
{
    //장비창 스크립트 

     //장착해제 버튼 눌렀을 때 
     //클릭한 장비의 부위에 따라 장착상태를 바꺼준다 
    public void UnequipButtonClick()
    {

        switch (UIManager.instance.itemTemp.smallItemType)
        {
            case "Weapon" :
                if(UIManager.instance.equip_WeaponSlot.Enequip() == 1)
                {
                    CharacterManager.instance.isEquipWeapon = false;
                }
                break;
            case "Armor"  :
                if (UIManager.instance.equip_ArmorSlot.Enequip() == 1)
                {
                    CharacterManager.instance.isEquipArmor = false;
                }
                break;
            case "Shoes":
                if (UIManager.instance.equip_ShoesSlot.Enequip() == 1)
                {
                    CharacterManager.instance.isEquipShoes = false;
                }
                break;
            case "Helmet":
                if (UIManager.instance.equip_HelmetSlot.Enequip() == 1)
                {
                    CharacterManager.instance.isEquipHelmet = false;
                }
                break;
            case "Earring":
                if (UIManager.instance.equip_EarringSlot.Enequip() == 1)
                {
                    CharacterManager.instance.isEquipEarring = false;
                }
                break;
            case "Shield":
                if (UIManager.instance.equip_ShieldSlot.Enequip() == 1)
                {
                    CharacterManager.instance.isEquipShield = false;
                }
                break;
            case "Ring":
                if (UIManager.instance.equip_RingSlot.Enequip() == 1)
                {
                    CharacterManager.instance.isEquipRing = false;
                }
                break;
            case "Glove":
                if (UIManager.instance.equip_GloveSlot.Enequip() == 1)
                {
                    CharacterManager.instance.isEquipGlove = false;
                }
                break;
            case "Necklace":
                if (UIManager.instance.equip_NecklaceSlot.Enequip() == 1)
                {
                    CharacterManager.instance.isEquipNecklace = false;
                }
                break;
            default:
                break;
        }
 }

    //x버튼을 누르면 창이 닫힌다 
    public void ExitButtonClick()
    {

        this.gameObject.SetActive(false);

    }



    public IEnumerator EnequipFailText()
    {
        UIManager.instance.equip_UnequipFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.equip_UnequipFailText.gameObject.SetActive(false);
    }

}
