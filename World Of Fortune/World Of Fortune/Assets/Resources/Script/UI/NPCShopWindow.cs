using System.Collections;
using System.Collections.Generic;
using UnityEngine;




//NPC 상점에서 활성화되는 버튼 이벤트가 들어있는 스크립트 
public class NPCShopWindow : MonoBehaviour
{


    //선택한 아이템 번호 
    public int buyItmeNumber;
    
    // 사려는 아이템 숫자 
    public int buyItemQuantity;

    public long longRand;
    public long priceRand;

    public void start()
    {

        buyItmeNumber = -1;
        buyItemQuantity = -1;

    }


    //나가기 버튼을 누르면 NPC대화창이 열린다 
    public void ExitButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        this.gameObject.SetActive(false);
        UIManager.instance.npcTalkWindow.gameObject.SetActive(true);
        buyItmeNumber = -1;
    }



    // 사기 버튼을 눌렀을 경우 발생
    // 선택한 아이템이 있는 경우만 발생  o
    // 먼저 입력한 숫자가 몇개인지 체크 -> TryParse가 되지 않는다면 1로 생각한다  o 
    // 돈이 있는지 확인 o, 아이템창에 빈 칸이 있는지 확인 
    // 장비템인 겨우 장비템의 능력치가 랜덤으로 적용되서 아이템창에 들어감 다른 아이템들은 그냥 들어감
    // 돈이 랜덤으로 감소된다 
    public void BuyButtonClick()
    {

        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        // 선택한 아이템이 있는 경우에만 
        if (UIManager.instance.shop_sellItem[buyItmeNumber].itemName != "null" && buyItmeNumber != -1)
        {


            // 인풋필드에 값을 입력하면 사는 개수를 입력한 값으로 하고 아니면 1로 한다 
            if(!int.TryParse(UIManager.instance.shop_BuyQuantityInputField.text, out buyItemQuantity))
            {

                buyItemQuantity = 1;

            }

            // 현재 가지고 있는 돈이 사려는 아이템 가격 * 개수보다 많을 경우에만 다음을 진행한다 
            if(UIManager.instance.hasMoney >= (UIManager.instance.shop_sellItem[buyItmeNumber].price *1.5) * buyItemQuantity)
            {
                // 사려는 아이템이 장비 템인 경우 
                //1개씩 아이템 옵션 랜덤조정되서 사지고 돈 --  -> 아이템창이 끝나면 break
                if(UIManager.instance.shop_sellItem[buyItmeNumber].bigItemType == "Equipment")
                {
                    SoundManager.instance.SoundEffectOn("ShopSound", SoundManager.instance.soundEffectNumber);
                    for (int i = 0; i < buyItemQuantity; i++)
                    {
                        if (UIManager.instance.shop_sellItem[buyItmeNumber].addMaxHP != 0)
                          UIManager.instance.itemTemp.addMaxHP = (long) Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].addMaxHP + 1);
                        if (UIManager.instance.shop_sellItem[buyItmeNumber].addMaxMP != 0)
                            UIManager.instance.itemTemp.addMaxMP = (long)Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].addMaxMP + 1);
                        if (UIManager.instance.shop_sellItem[buyItmeNumber].addSTR != 0)
                            UIManager.instance.itemTemp.addSTR = (long)Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].addSTR + 1);
                        if (UIManager.instance.shop_sellItem[buyItmeNumber].addHEL != 0)
                            UIManager.instance.itemTemp.addHEL = (long)Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].addHEL + 1);
                        if (UIManager.instance.shop_sellItem[buyItmeNumber].addINT != 0)
                            UIManager.instance.itemTemp.addINT = (long)Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].addINT + 1);
                        if (UIManager.instance.shop_sellItem[buyItmeNumber].addLUK != 0)
                            UIManager.instance.itemTemp.addLUK = (long)Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].addLUK + 1);
                        if (UIManager.instance.shop_sellItem[buyItmeNumber].addPower != 0)
                            UIManager.instance.itemTemp.addPower = (long)Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].addPower +1);
                        if (UIManager.instance.shop_sellItem[buyItmeNumber].addDefence != 0)
                            UIManager.instance.itemTemp.addDefence = (long)Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].addDefence + 1);
                        if (UIManager.instance.shop_sellItem[buyItmeNumber].addMagicPower != 0)
                            UIManager.instance.itemTemp.addMagicPower = (long)Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].addMagicPower + 1);
                        UIManager.instance.itemTemp.requireLevel =  UIManager.instance.shop_sellItem[buyItmeNumber].requireLevel;
                        UIManager.instance.itemTemp.requireAccumulateLevel = UIManager.instance.shop_sellItem[buyItmeNumber].requireAccumulateLevel;
                        UIManager.instance.itemTemp.requireSTR =  UIManager.instance.shop_sellItem[buyItmeNumber].requireSTR;
                        UIManager.instance.itemTemp.requireHEL =  UIManager.instance.shop_sellItem[buyItmeNumber].requireHEL;
                        UIManager.instance.itemTemp.requireINT = UIManager.instance.shop_sellItem[buyItmeNumber].requireINT;
                        UIManager.instance.itemTemp.requireLUK = UIManager.instance.shop_sellItem[buyItmeNumber].requireLUK;
                        UIManager.instance.itemTemp.enhanceLevel = 0;
                        if(UIManager.instance.itemTemp.GetItem(1) == 1)
                        {
                            priceRand =(long) Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].price + 1);

                            // 돈 랜덤으로 -- 
                            UIManager.instance.hasMoney -= priceRand;
                            UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
                            UIManager.instance.shop_MoneyText.text = UIManager.instance.hasMoney.ToString();
                            return;

                        }
                        // 장비창이 꽉 차서 더 안들어가면 itemTemp를 초기값으로 해주고 break
                        else
                        {
                            UIManager.instance.itemTemp.itemName = "null";
                            UIManager.instance.itemTemp.bigItemType = "null";
                            UIManager.instance.itemTemp.smallItemType = "null";
                            UIManager.instance.itemTemp.price = 0;
                            UIManager.instance.itemTemp.quantity = 0;
                            UIManager.instance.itemTemp.itemExplain = "null";
                            UIManager.instance.itemTemp.maxAddHP = 0;
                            UIManager.instance.itemTemp.maxAddMP = 0;
                            UIManager.instance.itemTemp.maxAddMaxMP = 0;
                            UIManager.instance.itemTemp.maxAddMaxHP = 0;
                            UIManager.instance.itemTemp.maxAddSTR = 0;
                            UIManager.instance.itemTemp.maxAddHEL = 0;
                            UIManager.instance.itemTemp.maxAddINT = 0;
                            UIManager.instance.itemTemp.maxAddLUK = 0;
                            UIManager.instance.itemTemp.maxAddPower = 0;
                            UIManager.instance.itemTemp.maxAddMagicPower = 0;
                            UIManager.instance.itemTemp.maxAddDefence = 0;
                            UIManager.instance.itemTemp.sharePosiible = false;
                            UIManager.instance.itemTemp.coolTime = 0;
                            UIManager.instance.itemTemp.stayTime = 0;
                            UIManager.instance.itemTemp.addMaxHP = 0;
                            UIManager.instance.itemTemp.addMaxMP = 0;
                            UIManager.instance.itemTemp.addSTR = 0;
                            UIManager.instance.itemTemp.addHEL = 0;
                            UIManager.instance.itemTemp.addINT = 0;
                            UIManager.instance.itemTemp.addLUK = 0;
                            UIManager.instance.itemTemp.addPower = 0;
                            UIManager.instance.itemTemp.addDefence = 0;
                            UIManager.instance.itemTemp.requireAccumulateLevel = 0;
                            UIManager.instance.itemTemp.requireLevel = 0;
                            UIManager.instance.itemTemp.requireSTR = 0;
                            UIManager.instance.itemTemp.requireHEL = 0;
                            UIManager.instance.itemTemp.requireINT = 0;
                            UIManager.instance.itemTemp.requireLUK = 0;
                            UIManager.instance.itemTemp.enhanceLevel = 0;
                            UIManager.instance.itemTemp.enhanceStack = 0;
                            return;
                        }
                    }


                }
                // 장비 아이템이 아닌 경우 
                else
                {
                    // 아이템 획득할 수 있으면 
                    if (UIManager.instance.itemTemp.GetItem(buyItemQuantity) == 1)
                    {
                        SoundManager.instance.SoundEffectOn("ShopSound", SoundManager.instance.soundEffectNumber);
                        // 아이템을 획득하고 랜덤으로 돈을 감소시킨다 
                        for (int i = 0; i < buyItemQuantity; i++)
                        {
                            priceRand = (long)Random.Range(1, UIManager.instance.shop_sellItem[buyItmeNumber].price + 1);
                            UIManager.instance.hasMoney -= priceRand;

                        }

                        UIManager.instance.item_MoneyText.text = UIManager.instance.hasMoney.ToString();
                        UIManager.instance.shop_MoneyText.text = UIManager.instance.hasMoney.ToString();
                        
                        return;

                    }



                }

             }



            }
        StartCoroutine(WarehouseInputFailText());

        }



    IEnumerator WarehouseInputFailText()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        UIManager.instance.Shop_BuyFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        UIManager.instance.Shop_BuyFailText.gameObject.SetActive(false);
    }






}
