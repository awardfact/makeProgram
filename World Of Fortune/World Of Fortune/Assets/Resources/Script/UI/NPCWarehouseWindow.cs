using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWarehouseWindow : MonoBehaviour
{
    public int unloadItemQuantity;
    public long inputMoney;


    //창고에서 숫자를 입력하고 찾기 버튼을 눌렀을 떄 발생 이벤트 
    //인풋필드에 입력된 값을 체크한다 
    // 인풋필드에 입력된 값보다 슬롯에 있는 숫자가 많으면 다음으로 진행한다 
    //슬롯 아이템 정보를 itemTemp에 넘긴다 
    // itemTemp에 getItem을 시킨다 
    // 성공하면 warehousetemp에 loseITem을 시킨다 
    public void UnloadButtonClick()
    {

        if (!int.TryParse(UIManager.instance.warehouse_AmountInputField.text, out unloadItemQuantity))
        {
            unloadItemQuantity = 1;
        }

        if (UIManager.instance.warehouseItemTemp.quantity >= unloadItemQuantity)
        {
            UIManager.instance.itemTemp.itemName = UIManager.instance.warehouseItemTemp.itemName;
            UIManager.instance.itemTemp.bigItemType = UIManager.instance.warehouseItemTemp.bigItemType;
            UIManager.instance.itemTemp.smallItemType = UIManager.instance.warehouseItemTemp.smallItemType;
            UIManager.instance.itemTemp.price = UIManager.instance.warehouseItemTemp.price;
            UIManager.instance.itemTemp.itemExplain = UIManager.instance.warehouseItemTemp.itemExplain;
            UIManager.instance.itemTemp.maxAddHP = UIManager.instance.warehouseItemTemp.maxAddHP;
            UIManager.instance.itemTemp.maxAddMP = UIManager.instance.warehouseItemTemp.maxAddMP;
            UIManager.instance.itemTemp.maxAddMaxMP = UIManager.instance.warehouseItemTemp.maxAddMaxMP;
            UIManager.instance.itemTemp.maxAddMaxHP = UIManager.instance.warehouseItemTemp.maxAddMaxHP;
            UIManager.instance.itemTemp.maxAddSTR = UIManager.instance.warehouseItemTemp.maxAddSTR;
            UIManager.instance.itemTemp.maxAddHEL = UIManager.instance.warehouseItemTemp.maxAddHEL;
            UIManager.instance.itemTemp.maxAddINT = UIManager.instance.warehouseItemTemp.maxAddINT;
            UIManager.instance.itemTemp.sharePosiible = UIManager.instance.warehouseItemTemp.sharePosiible;
            UIManager.instance.itemTemp.maxAddLUK = UIManager.instance.warehouseItemTemp.maxAddLUK;
            UIManager.instance.itemTemp.maxAddPower = UIManager.instance.warehouseItemTemp.maxAddPower;
            UIManager.instance.itemTemp.maxAddMagicPower = UIManager.instance.warehouseItemTemp.maxAddMagicPower;
            UIManager.instance.itemTemp.maxAddDefence = UIManager.instance.warehouseItemTemp.maxAddDefence;
            UIManager.instance.itemTemp.coolTime = UIManager.instance.warehouseItemTemp.coolTime;
            UIManager.instance.itemTemp.stayTime = UIManager.instance.warehouseItemTemp.stayTime;
            UIManager.instance.itemTemp.addMaxHP = UIManager.instance.warehouseItemTemp.addMaxHP;
            UIManager.instance.itemTemp.addMaxMP = UIManager.instance.warehouseItemTemp.addMaxMP;
            UIManager.instance.itemTemp.addSTR = UIManager.instance.warehouseItemTemp.addSTR;
            UIManager.instance.itemTemp.addHEL = UIManager.instance.warehouseItemTemp.addHEL;
            UIManager.instance.itemTemp.addINT = UIManager.instance.warehouseItemTemp.addINT;
            UIManager.instance.itemTemp.addLUK = UIManager.instance.warehouseItemTemp.addLUK;
            UIManager.instance.itemTemp.addPower = UIManager.instance.warehouseItemTemp.addPower;
            UIManager.instance.itemTemp.addDefence = UIManager.instance.warehouseItemTemp.addDefence;
            UIManager.instance.itemTemp.requireLevel = UIManager.instance.warehouseItemTemp.requireLevel;
            UIManager.instance.itemTemp.requireSTR = UIManager.instance.warehouseItemTemp.requireSTR;
            UIManager.instance.itemTemp.requireHEL = UIManager.instance.warehouseItemTemp.requireHEL;
            UIManager.instance.itemTemp.requireINT = UIManager.instance.warehouseItemTemp.requireINT;
            UIManager.instance.itemTemp.requireLUK = UIManager.instance.warehouseItemTemp.requireLUK;
            UIManager.instance.itemTemp.enhanceLevel = UIManager.instance.warehouseItemTemp.enhanceLevel;
            UIManager.instance.itemTemp.enhanceStack = UIManager.instance.warehouseItemTemp.enhanceStack;
            UIManager.instance.itemTemp.quantity = unloadItemQuantity;
            if (UIManager.instance.itemTemp.GetItem(unloadItemQuantity) == 1)
            {
                SoundManager.instance.SoundEffectOn("WarehousSound", SoundManager.instance.soundEffectNumber);
                UIManager.instance.warehouseItemTemp.LoseItem(unloadItemQuantity);
            }
        }
        else
        {
            StartCoroutine(UnloadFailText());
        }

    }

    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("WarehousSound", SoundManager.instance.soundEffectNumber);
        this.gameObject.SetActive(false);
    }



    //인풋필드에 입력된 값을 체크한다 
    // 만약 인풋필드에 입력한 값보다 현재 소지한 돈이 많다면 뒤를 진행
    // 아이템창에 소지하고 있던 돈을 입력한 만큼 없앤다
    // 창고에 있는 돈에 입력한 만큼 추가시킨다
    public void DepositButtonClick()
    {
        if (!long.TryParse(UIManager.instance.warehouse_AmountInputField.text, out inputMoney))
        {
            inputMoney = 1;
        }

        if (UIManager.instance.hasMoney >= inputMoney)
        {
            SoundManager.instance.SoundEffectOn("ShopSound", SoundManager.instance.soundEffectNumber);
            UIManager.instance.hasMoney -= inputMoney;
            UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
            UIManager.instance.warehouseHasMoney += inputMoney;
            UIManager.instance.warehouse_moneyText.text = UIManager.instance.warehouseHasMoney.ToString();
        }
        else
        {
            StartCoroutine(DepositFailText());
        }
    }

    // 인풋필드에 입력된 값을 체크한다
    // 만약 인풋필드에 입력한 값보다 현재 창고에 있는 돈이 많다면 뒤를 진행
    // 창고에 있는 돈을 입력한 만큼 없앤다
    // 아이템창에 있는 동을 입력한 만큼 추가한다 
    public void WithdrawButtonClick()
    {
        if (!long.TryParse(UIManager.instance.warehouse_AmountInputField.text, out inputMoney))
        {
            inputMoney = 1;
        }

        if (UIManager.instance.warehouseHasMoney >= inputMoney)
        {
            SoundManager.instance.SoundEffectOn("ShopSound", SoundManager.instance.soundEffectNumber);
            UIManager.instance.warehouseHasMoney -= inputMoney;
            UIManager.instance.warehouse_moneyText.text = UIManager.instance.warehouseHasMoney.ToString();
            UIManager.instance.hasMoney += inputMoney;
            UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
        }
        else
        {
            StartCoroutine(WithdrawFailText());
        }
    }

    IEnumerator UnloadFailText()
    {
        UIManager.instance.warehouse_UnloadFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.warehouse_UnloadFailText.gameObject.SetActive(false);
    }

    IEnumerator WithdrawFailText()
    {
        UIManager.instance.warehouse_WithdrawFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.warehouse_WithdrawFailText.gameObject.SetActive(false);
    }

    IEnumerator DepositFailText()
    {
        UIManager.instance.warehouse_DepositFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.warehouse_DepositFailText.gameObject.SetActive(false);
    }
}
