using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    //1개의 아이템 슬롯에 있는 아이템 정보 



    StreamReader streamReader;
    StreamWriter streamWriter;
    string s;


    // 공통정보 
    public string itemName;
    public string bigItemType;
    public string smallItemType;
    public long price;
    public string itemExplain;
    public int quantity;


    public long maxAddHP;    // 사용시 올라가는 체력 최대치
    public long maxAddMP;   //  사용시 올라가는 마나 최대치 

    public long maxAddMaxMP;   // 사용시 올라가는 최대 체력 최대치( 올라가는 옵션이 최대 체력이고 사용했을때 랜덤으로 수치가 증가하는데 증가 수치 중 최대치가 이 변수)
    public long maxAddMaxHP; // 사용시 올라가는 최대 마나 최대치(BUFF) 
    public long maxAddSTR; //  사용시 올라가는 STR스텟 최대치(BUff)
    public long maxAddHEL;  // 사용시 올라가는 Hel스텟 최대치(BUFF)
    public long maxAddINT;  // 사용시 올라가는 INt스텟 최대치(BUFF)
    public long maxAddLUK; // 사용시 올라가는 LUk스텟 최대치(BUFF)
    public long maxAddPower;
    public long maxAddMagicPower;
    public long maxAddDefence;

    public float coolTime;  // 소비 아이템일떄 쿨타임
    public float stayTime;  //버프 아이템일때 지속시간


    public long addMaxHP;  // 장착시 올라가는 최대체력
    public long addMaxMP; // 장착시 올라가는 최대마나
    public long addSTR;  // 장착시 올라가는 Str스텟
    public long addHEL;  // 장착시 올라가는 hel스텟
    public long addINT;  //장착시 올라가는 int스텟
    public long addLUK;  // 장착시 올라가는luck스텟
    public long addPower;
    public long addMagicPower;
    public long addDefence;

    public long requireAccumulateLevel;
    public long requireLevel;
    public long requireSTR;
    public long requireHEL;
    public long requireINT;
    public long requireLUK;

    public int enhanceLevel;  // 강화단계 장비템 보여줄때 if이거 0아니면 이름 + 강화레벨로 이름을 보여줌 
    public int enhanceStack; // 스택이 높을수록 강화 확률이 올라간다 


    public bool sharePosiible; // 계정공유 가능한지 가능 = true;



    public int slotNumber;


    public Image itemImage;
    public Text quantityText;



    public long rand1;
    public long rand2;
    public float rand3;




    // Start is called before the first frame update
    void Start()
    {
        itemImage = transform.Find("Image").gameObject.GetComponent<Image>();
        quantityText = transform.Find("Text").gameObject.GetComponent<Text>();

      
    }
    // 오브젝트 이름을 보고 
    // 파일에서 슬롯 정보를 불러옴
    // 이미지 , 숫자 변경 






    //저장 버튼을 누르면 호출 
   public void Save()
    {
        if (UIManager.instance.environment == "Mobile")
        {
            if (this.transform.name.Split('_')[0] == "EquipSlot")
            {
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + CharacterManager.instance.characterNumber + "/EquipSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
                streamWriter.Write(itemName + "`");
                streamWriter.Write(bigItemType + "`");
                streamWriter.Write(smallItemType + "`");
                streamWriter.Write(price + "`");
                streamWriter.Write(itemExplain + "`");
                streamWriter.Write(quantity + "`");
                streamWriter.Write(maxAddHP + "`");
                streamWriter.Write(maxAddMP + "`");
                streamWriter.Write(maxAddMaxMP + "`");
                streamWriter.Write(maxAddMaxHP + "`");
                streamWriter.Write(maxAddSTR + "`");
                streamWriter.Write(maxAddHEL + "`");
                streamWriter.Write(maxAddINT + "`");
                streamWriter.Write(maxAddLUK + "`");
                streamWriter.Write(maxAddPower + "`");
                streamWriter.Write(maxAddMagicPower + "`");
                streamWriter.Write(maxAddDefence + "`");
                streamWriter.Write(coolTime + "`");
                streamWriter.Write(stayTime + "`");
                streamWriter.Write(addMaxHP + "`");
                streamWriter.Write(addMaxMP + "`");
                streamWriter.Write(addSTR + "`");
                streamWriter.Write(addHEL + "`");
                streamWriter.Write(addINT + "`");
                streamWriter.Write(addLUK + "`");
                streamWriter.Write(addPower + "`");
                streamWriter.Write(addMagicPower + "`");
                streamWriter.Write(addDefence + "`");
                streamWriter.Write(requireLevel + "`");
                streamWriter.Write(requireAccumulateLevel + "`");
                streamWriter.Write(requireSTR + "`");
                streamWriter.Write(requireHEL + "`");
                streamWriter.Write(requireINT + "`");
                streamWriter.Write(requireLUK + "`");
                streamWriter.Write(enhanceLevel + "`");
                streamWriter.Write(enhanceStack + "`");
                streamWriter.Write(sharePosiible + "`");
                streamWriter.Close();


            }
            else if (this.transform.name.Split('_')[0] == "ConsumeSlot")
            {
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + CharacterManager.instance.characterNumber + "/ConsumeSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
                streamWriter.Write(itemName + "`");
                streamWriter.Write(bigItemType + "`");
                streamWriter.Write(smallItemType + "`");
                streamWriter.Write(price + "`");
                streamWriter.Write(itemExplain + "`");
                streamWriter.Write(quantity + "`");
                streamWriter.Write(maxAddHP + "`");
                streamWriter.Write(maxAddMP + "`");
                streamWriter.Write(maxAddMaxMP + "`");
                streamWriter.Write(maxAddMaxHP + "`");
                streamWriter.Write(maxAddSTR + "`");
                streamWriter.Write(maxAddHEL + "`");
                streamWriter.Write(maxAddINT + "`");
                streamWriter.Write(maxAddLUK + "`");
                streamWriter.Write(maxAddPower + "`");
                streamWriter.Write(maxAddMagicPower + "`");
                streamWriter.Write(maxAddDefence + "`");
                streamWriter.Write(coolTime + "`");
                streamWriter.Write(stayTime + "`");
                streamWriter.Write(addMaxHP + "`");
                streamWriter.Write(addMaxMP + "`");
                streamWriter.Write(addSTR + "`");
                streamWriter.Write(addHEL + "`");
                streamWriter.Write(addINT + "`");
                streamWriter.Write(addLUK + "`");
                streamWriter.Write(addPower + "`");
                streamWriter.Write(addMagicPower + "`");
                streamWriter.Write(addDefence + "`");
                streamWriter.Write(requireLevel + "`");
                streamWriter.Write(requireAccumulateLevel + "`");
                streamWriter.Write(requireSTR + "`");
                streamWriter.Write(requireHEL + "`");
                streamWriter.Write(requireINT + "`");
                streamWriter.Write(requireLUK + "`");
                streamWriter.Write(enhanceLevel + "`");
                streamWriter.Write(enhanceStack + "`");
                streamWriter.Write(sharePosiible + "`");
                streamWriter.Close();
            }
            else if (this.transform.name.Split('_')[0] == "EtcSlot")
            {
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + CharacterManager.instance.characterNumber + "/EtcSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
                streamWriter.Write(itemName + "`");
                streamWriter.Write(bigItemType + "`");
                streamWriter.Write(smallItemType + "`");
                streamWriter.Write(price + "`");
                streamWriter.Write(itemExplain + "`");
                streamWriter.Write(quantity + "`");
                streamWriter.Write(maxAddHP + "`");
                streamWriter.Write(maxAddMP + "`");
                streamWriter.Write(maxAddMaxMP + "`");
                streamWriter.Write(maxAddMaxHP + "`");
                streamWriter.Write(maxAddSTR + "`");
                streamWriter.Write(maxAddHEL + "`");
                streamWriter.Write(maxAddINT + "`");
                streamWriter.Write(maxAddLUK + "`");
                streamWriter.Write(maxAddPower + "`");
                streamWriter.Write(maxAddMagicPower + "`");
                streamWriter.Write(maxAddDefence + "`");
                streamWriter.Write(coolTime + "`");
                streamWriter.Write(stayTime + "`");
                streamWriter.Write(addMaxHP + "`");
                streamWriter.Write(addMaxMP + "`");
                streamWriter.Write(addSTR + "`");
                streamWriter.Write(addHEL + "`");
                streamWriter.Write(addINT + "`");
                streamWriter.Write(addLUK + "`");
                streamWriter.Write(addPower + "`");
                streamWriter.Write(addMagicPower + "`");
                streamWriter.Write(addDefence + "`");
                streamWriter.Write(requireLevel + "`");
                streamWriter.Write(requireAccumulateLevel + "`");
                streamWriter.Write(requireSTR + "`");
                streamWriter.Write(requireHEL + "`");
                streamWriter.Write(requireINT + "`");
                streamWriter.Write(requireLUK + "`");
                streamWriter.Write(enhanceLevel + "`");
                streamWriter.Write(enhanceStack + "`");
                streamWriter.Write(sharePosiible + "`");
                streamWriter.Close();



            }
            else if (this.transform.name.Split('_')[0] == "CashSlot")
            {
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + CharacterManager.instance.characterNumber + "/CashSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
                streamWriter.Write(itemName + "`");
                streamWriter.Write(bigItemType + "`");
                streamWriter.Write(smallItemType + "`");
                streamWriter.Write(price + "`");
                streamWriter.Write(itemExplain + "`");
                streamWriter.Write(quantity + "`");
                streamWriter.Write(maxAddHP + "`");
                streamWriter.Write(maxAddMP + "`");
                streamWriter.Write(maxAddMaxMP + "`");
                streamWriter.Write(maxAddMaxHP + "`");
                streamWriter.Write(maxAddSTR + "`");
                streamWriter.Write(maxAddHEL + "`");
                streamWriter.Write(maxAddINT + "`");
                streamWriter.Write(maxAddLUK + "`");
                streamWriter.Write(maxAddPower + "`");
                streamWriter.Write(maxAddMagicPower + "`");
                streamWriter.Write(maxAddDefence + "`");
                streamWriter.Write(coolTime + "`");
                streamWriter.Write(stayTime + "`");
                streamWriter.Write(addMaxHP + "`");
                streamWriter.Write(addMaxMP + "`");
                streamWriter.Write(addSTR + "`");
                streamWriter.Write(addHEL + "`");
                streamWriter.Write(addINT + "`");
                streamWriter.Write(addLUK + "`");
                streamWriter.Write(addPower + "`");
                streamWriter.Write(addMagicPower + "`");
                streamWriter.Write(addDefence + "`");
                streamWriter.Write(requireLevel + "`");
                streamWriter.Write(requireAccumulateLevel + "`");
                streamWriter.Write(requireSTR + "`");
                streamWriter.Write(requireHEL + "`");
                streamWriter.Write(requireINT + "`");
                streamWriter.Write(requireLUK + "`");
                streamWriter.Write(enhanceLevel + "`");
                streamWriter.Write(enhanceStack + "`");
                streamWriter.Write(sharePosiible + "`");
                streamWriter.Close();



            }
        }
        else
        {
            if (this.transform.name.Split('_')[0] == "EquipSlot")
            {
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + CharacterManager.instance.characterNumber + "/EquipSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
                streamWriter.Write(itemName + "`");
                streamWriter.Write(bigItemType + "`");
                streamWriter.Write(smallItemType + "`");
                streamWriter.Write(price + "`");
                streamWriter.Write(itemExplain + "`");
                streamWriter.Write(quantity + "`");
                streamWriter.Write(maxAddHP + "`");
                streamWriter.Write(maxAddMP + "`");
                streamWriter.Write(maxAddMaxMP + "`");
                streamWriter.Write(maxAddMaxHP + "`");
                streamWriter.Write(maxAddSTR + "`");
                streamWriter.Write(maxAddHEL + "`");
                streamWriter.Write(maxAddINT + "`");
                streamWriter.Write(maxAddLUK + "`");
                streamWriter.Write(maxAddPower + "`");
                streamWriter.Write(maxAddMagicPower + "`");
                streamWriter.Write(maxAddDefence + "`");
                streamWriter.Write(coolTime + "`");
                streamWriter.Write(stayTime + "`");
                streamWriter.Write(addMaxHP + "`");
                streamWriter.Write(addMaxMP + "`");
                streamWriter.Write(addSTR + "`");
                streamWriter.Write(addHEL + "`");
                streamWriter.Write(addINT + "`");
                streamWriter.Write(addLUK + "`");
                streamWriter.Write(addPower + "`");
                streamWriter.Write(addMagicPower + "`");
                streamWriter.Write(addDefence + "`");
                streamWriter.Write(requireLevel + "`");
                streamWriter.Write(requireAccumulateLevel + "`");
                streamWriter.Write(requireSTR + "`");
                streamWriter.Write(requireHEL + "`");
                streamWriter.Write(requireINT + "`");
                streamWriter.Write(requireLUK + "`");
                streamWriter.Write(enhanceLevel + "`");
                streamWriter.Write(enhanceStack + "`");
                streamWriter.Write(sharePosiible + "`");
                streamWriter.Close();


            }
            else if (this.transform.name.Split('_')[0] == "ConsumeSlot")
            {
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + CharacterManager.instance.characterNumber + "/ConsumeSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
                streamWriter.Write(itemName + "`");
                streamWriter.Write(bigItemType + "`");
                streamWriter.Write(smallItemType + "`");
                streamWriter.Write(price + "`");
                streamWriter.Write(itemExplain + "`");
                streamWriter.Write(quantity + "`");
                streamWriter.Write(maxAddHP + "`");
                streamWriter.Write(maxAddMP + "`");
                streamWriter.Write(maxAddMaxMP + "`");
                streamWriter.Write(maxAddMaxHP + "`");
                streamWriter.Write(maxAddSTR + "`");
                streamWriter.Write(maxAddHEL + "`");
                streamWriter.Write(maxAddINT + "`");
                streamWriter.Write(maxAddLUK + "`");
                streamWriter.Write(maxAddPower + "`");
                streamWriter.Write(maxAddMagicPower + "`");
                streamWriter.Write(maxAddDefence + "`");
                streamWriter.Write(coolTime + "`");
                streamWriter.Write(stayTime + "`");
                streamWriter.Write(addMaxHP + "`");
                streamWriter.Write(addMaxMP + "`");
                streamWriter.Write(addSTR + "`");
                streamWriter.Write(addHEL + "`");
                streamWriter.Write(addINT + "`");
                streamWriter.Write(addLUK + "`");
                streamWriter.Write(addPower + "`");
                streamWriter.Write(addMagicPower + "`");
                streamWriter.Write(addDefence + "`");
                streamWriter.Write(requireLevel + "`");
                streamWriter.Write(requireAccumulateLevel + "`");
                streamWriter.Write(requireSTR + "`");
                streamWriter.Write(requireHEL + "`");
                streamWriter.Write(requireINT + "`");
                streamWriter.Write(requireLUK + "`");
                streamWriter.Write(enhanceLevel + "`");
                streamWriter.Write(enhanceStack + "`");
                streamWriter.Write(sharePosiible + "`");
                streamWriter.Close();
            }
            else if (this.transform.name.Split('_')[0] == "EtcSlot")
            {
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + CharacterManager.instance.characterNumber + "/EtcSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
                streamWriter.Write(itemName + "`");
                streamWriter.Write(bigItemType + "`");
                streamWriter.Write(smallItemType + "`");
                streamWriter.Write(price + "`");
                streamWriter.Write(itemExplain + "`");
                streamWriter.Write(quantity + "`");
                streamWriter.Write(maxAddHP + "`");
                streamWriter.Write(maxAddMP + "`");
                streamWriter.Write(maxAddMaxMP + "`");
                streamWriter.Write(maxAddMaxHP + "`");
                streamWriter.Write(maxAddSTR + "`");
                streamWriter.Write(maxAddHEL + "`");
                streamWriter.Write(maxAddINT + "`");
                streamWriter.Write(maxAddLUK + "`");
                streamWriter.Write(maxAddPower + "`");
                streamWriter.Write(maxAddMagicPower + "`");
                streamWriter.Write(maxAddDefence + "`");
                streamWriter.Write(coolTime + "`");
                streamWriter.Write(stayTime + "`");
                streamWriter.Write(addMaxHP + "`");
                streamWriter.Write(addMaxMP + "`");
                streamWriter.Write(addSTR + "`");
                streamWriter.Write(addHEL + "`");
                streamWriter.Write(addINT + "`");
                streamWriter.Write(addLUK + "`");
                streamWriter.Write(addPower + "`");
                streamWriter.Write(addMagicPower + "`");
                streamWriter.Write(addDefence + "`");
                streamWriter.Write(requireLevel + "`");
                streamWriter.Write(requireAccumulateLevel + "`");
                streamWriter.Write(requireSTR + "`");
                streamWriter.Write(requireHEL + "`");
                streamWriter.Write(requireINT + "`");
                streamWriter.Write(requireLUK + "`");
                streamWriter.Write(enhanceLevel + "`");
                streamWriter.Write(enhanceStack + "`");
                streamWriter.Write(sharePosiible + "`");
                streamWriter.Close();



            }
            else if (this.transform.name.Split('_')[0] == "CashSlot")
            {
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + CharacterManager.instance.characterNumber + "/CashSlot_" + int.Parse(this.transform.name.Split('_')[1]) + ".txt", FileMode.Create, FileAccess.Write));
                streamWriter.Write(itemName + "`");
                streamWriter.Write(bigItemType + "`");
                streamWriter.Write(smallItemType + "`");
                streamWriter.Write(price + "`");
                streamWriter.Write(itemExplain + "`");
                streamWriter.Write(quantity + "`");
                streamWriter.Write(maxAddHP + "`");
                streamWriter.Write(maxAddMP + "`");
                streamWriter.Write(maxAddMaxMP + "`");
                streamWriter.Write(maxAddMaxHP + "`");
                streamWriter.Write(maxAddSTR + "`");
                streamWriter.Write(maxAddHEL + "`");
                streamWriter.Write(maxAddINT + "`");
                streamWriter.Write(maxAddLUK + "`");
                streamWriter.Write(maxAddPower + "`");
                streamWriter.Write(maxAddMagicPower + "`");
                streamWriter.Write(maxAddDefence + "`");
                streamWriter.Write(coolTime + "`");
                streamWriter.Write(stayTime + "`");
                streamWriter.Write(addMaxHP + "`");
                streamWriter.Write(addMaxMP + "`");
                streamWriter.Write(addSTR + "`");
                streamWriter.Write(addHEL + "`");
                streamWriter.Write(addINT + "`");
                streamWriter.Write(addLUK + "`");
                streamWriter.Write(addPower + "`");
                streamWriter.Write(addMagicPower + "`");
                streamWriter.Write(addDefence + "`");
                streamWriter.Write(requireLevel + "`");
                streamWriter.Write(requireAccumulateLevel + "`");
                streamWriter.Write(requireSTR + "`");
                streamWriter.Write(requireHEL + "`");
                streamWriter.Write(requireINT + "`");
                streamWriter.Write(requireLUK + "`");
                streamWriter.Write(enhanceLevel + "`");
                streamWriter.Write(enhanceStack + "`");
                streamWriter.Write(sharePosiible + "`");
                streamWriter.Close();
            }




        }
    }

    public void GameStart(int selectSlot)
    {
        // 모바일일때 경로 
        if(UIManager.instance.environment == "Mobile")
        {
            // 트랜스폼 이름이 장비인 경우  
            if (this.transform.name.Split('_')[0] == "EquipSlot")
            {

                //장비 파일에서 아이템을 가져온다 
                streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/EquipSlot_" + this.transform.name.Split('_')[1] + ".txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                itemName = s.Split('`')[0];
                bigItemType = s.Split('`')[1];
                smallItemType = s.Split('`')[2];
                long.TryParse(s.Split('`')[3], out price);
                itemExplain = s.Split('`')[4];
                int.TryParse(s.Split('`')[5], out quantity);
                long.TryParse(s.Split('`')[6], out maxAddHP);
                long.TryParse(s.Split('`')[7], out maxAddMP);
                long.TryParse(s.Split('`')[8], out maxAddMaxMP);
                long.TryParse(s.Split('`')[9], out maxAddMaxHP);
                long.TryParse(s.Split('`')[10], out maxAddSTR);
                long.TryParse(s.Split('`')[11], out maxAddHEL);
                long.TryParse(s.Split('`')[12], out maxAddINT);
                long.TryParse(s.Split('`')[13], out maxAddLUK);
                long.TryParse(s.Split('`')[14], out maxAddPower);
                long.TryParse(s.Split('`')[15], out maxAddMagicPower);
                long.TryParse(s.Split('`')[16], out maxAddDefence);
                float.TryParse(s.Split('`')[17], out coolTime);
                float.TryParse(s.Split('`')[18], out stayTime);
                long.TryParse(s.Split('`')[19], out addMaxHP);
                long.TryParse(s.Split('`')[20], out addMaxMP);
                long.TryParse(s.Split('`')[21], out addSTR);
                long.TryParse(s.Split('`')[22], out addHEL);
                long.TryParse(s.Split('`')[23], out addINT);
                long.TryParse(s.Split('`')[24], out addLUK);
                long.TryParse(s.Split('`')[25], out addPower);
                long.TryParse(s.Split('`')[26], out addMagicPower);
                long.TryParse(s.Split('`')[27], out addDefence);
                long.TryParse(s.Split('`')[28], out requireLevel);
                long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
                long.TryParse(s.Split('`')[30], out requireSTR);
                long.TryParse(s.Split('`')[31], out requireHEL);
                long.TryParse(s.Split('`')[32], out requireINT);
                long.TryParse(s.Split('`')[33], out requireLUK);
                int.TryParse(s.Split('`')[34], out enhanceLevel);
                int.TryParse(s.Split('`')[35], out enhanceStack);
                bool.TryParse(s.Split('`')[36], out sharePosiible);
                streamReader.Close();
            }
            else if (this.transform.name.Split('_')[0] == "ConsumeSlot")
            {
                streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/ConsumeSlot_" + this.transform.name.Split('_')[1] + ".txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                itemName = s.Split('`')[0];
                bigItemType = s.Split('`')[1];
                smallItemType = s.Split('`')[2];
                long.TryParse(s.Split('`')[3], out price);
                itemExplain = s.Split('`')[4];
                int.TryParse(s.Split('`')[5], out quantity);
                long.TryParse(s.Split('`')[6], out maxAddHP);
                long.TryParse(s.Split('`')[7], out maxAddMP);
                long.TryParse(s.Split('`')[8], out maxAddMaxMP);
                long.TryParse(s.Split('`')[9], out maxAddMaxHP);
                long.TryParse(s.Split('`')[10], out maxAddSTR);
                long.TryParse(s.Split('`')[11], out maxAddHEL);
                long.TryParse(s.Split('`')[12], out maxAddINT);
                long.TryParse(s.Split('`')[13], out maxAddLUK);
                long.TryParse(s.Split('`')[14], out maxAddPower);
                long.TryParse(s.Split('`')[15], out maxAddMagicPower);
                long.TryParse(s.Split('`')[16], out maxAddDefence);
                float.TryParse(s.Split('`')[17], out coolTime);
                float.TryParse(s.Split('`')[18], out stayTime);
                long.TryParse(s.Split('`')[19], out addMaxHP);
                long.TryParse(s.Split('`')[20], out addMaxMP);
                long.TryParse(s.Split('`')[21], out addSTR);
                long.TryParse(s.Split('`')[22], out addHEL);
                long.TryParse(s.Split('`')[23], out addINT);
                long.TryParse(s.Split('`')[24], out addLUK);
                long.TryParse(s.Split('`')[25], out addPower);
                long.TryParse(s.Split('`')[26], out addMagicPower);
                long.TryParse(s.Split('`')[27], out addDefence);
                long.TryParse(s.Split('`')[28], out requireLevel);
                long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
                long.TryParse(s.Split('`')[30], out requireSTR);
                long.TryParse(s.Split('`')[31], out requireHEL);
                long.TryParse(s.Split('`')[32], out requireINT);
                long.TryParse(s.Split('`')[33], out requireLUK);
                int.TryParse(s.Split('`')[34], out enhanceLevel);
                int.TryParse(s.Split('`')[35], out enhanceStack);
                bool.TryParse(s.Split('`')[36], out sharePosiible);
                streamReader.Close();

            }
            else if (this.transform.name.Split('_')[0] == "EtcSlot")
            {
                streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/EtcSlot_" +this.transform.name.Split('_')[1] + ".txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                itemName = s.Split('`')[0];
                bigItemType = s.Split('`')[1];
                smallItemType = s.Split('`')[2];
                long.TryParse(s.Split('`')[3], out price);
                itemExplain = s.Split('`')[4];
                int.TryParse(s.Split('`')[5], out quantity);
                long.TryParse(s.Split('`')[6], out maxAddHP);
                long.TryParse(s.Split('`')[7], out maxAddMP);
                long.TryParse(s.Split('`')[8], out maxAddMaxMP);
                long.TryParse(s.Split('`')[9], out maxAddMaxHP);
                long.TryParse(s.Split('`')[10], out maxAddSTR);
                long.TryParse(s.Split('`')[11], out maxAddHEL);
                long.TryParse(s.Split('`')[12], out maxAddINT);
                long.TryParse(s.Split('`')[13], out maxAddLUK);
                long.TryParse(s.Split('`')[14], out maxAddPower);
                long.TryParse(s.Split('`')[15], out maxAddMagicPower);
                long.TryParse(s.Split('`')[16], out maxAddDefence);
                float.TryParse(s.Split('`')[17], out coolTime);
                float.TryParse(s.Split('`')[18], out stayTime);
                long.TryParse(s.Split('`')[19], out addMaxHP);
                long.TryParse(s.Split('`')[20], out addMaxMP);
                long.TryParse(s.Split('`')[21], out addSTR);
                long.TryParse(s.Split('`')[22], out addHEL);
                long.TryParse(s.Split('`')[23], out addINT);
                long.TryParse(s.Split('`')[24], out addLUK);
                long.TryParse(s.Split('`')[25], out addPower);
                long.TryParse(s.Split('`')[26], out addMagicPower);
                long.TryParse(s.Split('`')[27], out addDefence);
                long.TryParse(s.Split('`')[28], out requireLevel);
                long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
                long.TryParse(s.Split('`')[30], out requireSTR);
                long.TryParse(s.Split('`')[31], out requireHEL);
                long.TryParse(s.Split('`')[32], out requireINT);
                long.TryParse(s.Split('`')[33], out requireLUK);
                int.TryParse(s.Split('`')[34], out enhanceLevel);
                int.TryParse(s.Split('`')[35], out enhanceStack);
                bool.TryParse(s.Split('`')[36], out sharePosiible);
                streamReader.Close();
            }
            else if (this.transform.name.Split('_')[0] == "CashSlot")
            {
                streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/CashSlot_" + this.transform.name.Split('_')[1] + ".txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                itemName = s.Split('`')[0];
                bigItemType = s.Split('`')[1];
                smallItemType = s.Split('`')[2];
                long.TryParse(s.Split('`')[3], out price);
                itemExplain = s.Split('`')[4];
                int.TryParse(s.Split('`')[5], out quantity);
                long.TryParse(s.Split('`')[6], out maxAddHP);
                long.TryParse(s.Split('`')[7], out maxAddMP);
                long.TryParse(s.Split('`')[8], out maxAddMaxMP);
                long.TryParse(s.Split('`')[9], out maxAddMaxHP);
                long.TryParse(s.Split('`')[10], out maxAddSTR);
                long.TryParse(s.Split('`')[11], out maxAddHEL);
                long.TryParse(s.Split('`')[12], out maxAddINT);
                long.TryParse(s.Split('`')[13], out maxAddLUK);
                long.TryParse(s.Split('`')[14], out maxAddPower);
                long.TryParse(s.Split('`')[15], out maxAddMagicPower);
                long.TryParse(s.Split('`')[16], out maxAddDefence);
                float.TryParse(s.Split('`')[17], out coolTime);
                float.TryParse(s.Split('`')[18], out stayTime);
                long.TryParse(s.Split('`')[19], out addMaxHP);
                long.TryParse(s.Split('`')[20], out addMaxMP);
                long.TryParse(s.Split('`')[21], out addSTR);
                long.TryParse(s.Split('`')[22], out addHEL);
                long.TryParse(s.Split('`')[23], out addINT);
                long.TryParse(s.Split('`')[24], out addLUK);
                long.TryParse(s.Split('`')[25], out addPower);
                long.TryParse(s.Split('`')[26], out addMagicPower);
                long.TryParse(s.Split('`')[27], out addDefence);
                long.TryParse(s.Split('`')[28], out requireLevel);
                long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
                long.TryParse(s.Split('`')[30], out requireSTR);
                long.TryParse(s.Split('`')[31], out requireHEL);
                long.TryParse(s.Split('`')[32], out requireINT);
                long.TryParse(s.Split('`')[33], out requireLUK);
                int.TryParse(s.Split('`')[34], out enhanceLevel);
                int.TryParse(s.Split('`')[35], out enhanceStack);
                bool.TryParse(s.Split('`')[36], out sharePosiible);
                streamReader.Close();

            }
        }
        else
        {
            //PC일떄 경로 
            // 트랜스폼 이름이 장비인 경우  
            if (this.transform.name.Split('_')[0] == "EquipSlot")
            {
                //장비 파일에서 아이템을 가져온다 
                streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/EquipSlot_" + this.transform.name.Split('_')[1] + ".txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                itemName = s.Split('`')[0];
                bigItemType = s.Split('`')[1];
                smallItemType = s.Split('`')[2];
                long.TryParse(s.Split('`')[3], out price);
                itemExplain = s.Split('`')[4];
                int.TryParse(s.Split('`')[5], out quantity);
                long.TryParse(s.Split('`')[6], out maxAddHP);
                long.TryParse(s.Split('`')[7], out maxAddMP);
                long.TryParse(s.Split('`')[8], out maxAddMaxMP);
                long.TryParse(s.Split('`')[9], out maxAddMaxHP);
                long.TryParse(s.Split('`')[10], out maxAddSTR);
                long.TryParse(s.Split('`')[11], out maxAddHEL);
                long.TryParse(s.Split('`')[12], out maxAddINT);
                long.TryParse(s.Split('`')[13], out maxAddLUK);
                long.TryParse(s.Split('`')[14], out maxAddPower);
                long.TryParse(s.Split('`')[15], out maxAddMagicPower);
                long.TryParse(s.Split('`')[16], out maxAddDefence);
                float.TryParse(s.Split('`')[17], out coolTime);
                float.TryParse(s.Split('`')[18], out stayTime);
                long.TryParse(s.Split('`')[19], out addMaxHP);
                long.TryParse(s.Split('`')[20], out addMaxMP);
                long.TryParse(s.Split('`')[21], out addSTR);
                long.TryParse(s.Split('`')[22], out addHEL);
                long.TryParse(s.Split('`')[23], out addINT);
                long.TryParse(s.Split('`')[24], out addLUK);
                long.TryParse(s.Split('`')[25], out addPower);
                long.TryParse(s.Split('`')[26], out addMagicPower);
                long.TryParse(s.Split('`')[27], out addDefence);
                long.TryParse(s.Split('`')[28], out requireLevel);
                long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
                long.TryParse(s.Split('`')[30], out requireSTR);
                long.TryParse(s.Split('`')[31], out requireHEL);
                long.TryParse(s.Split('`')[32], out requireINT);
                long.TryParse(s.Split('`')[33], out requireLUK);
                int.TryParse(s.Split('`')[34], out enhanceLevel);
                int.TryParse(s.Split('`')[35], out enhanceStack);
                bool.TryParse(s.Split('`')[36], out sharePosiible);
                streamReader.Close();
            }
            else if (this.transform.name.Split('_')[0] == "ConsumeSlot")
            {
                streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/ConsumeSlot_" + this.transform.name.Split('_')[1] + ".txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                itemName = s.Split('`')[0];
                bigItemType = s.Split('`')[1];
                smallItemType = s.Split('`')[2];
                long.TryParse(s.Split('`')[3], out price);
                itemExplain = s.Split('`')[4];
                int.TryParse(s.Split('`')[5], out quantity);
                long.TryParse(s.Split('`')[6], out maxAddHP);
                long.TryParse(s.Split('`')[7], out maxAddMP);
                long.TryParse(s.Split('`')[8], out maxAddMaxMP);
                long.TryParse(s.Split('`')[9], out maxAddMaxHP);
                long.TryParse(s.Split('`')[10], out maxAddSTR);
                long.TryParse(s.Split('`')[11], out maxAddHEL);
                long.TryParse(s.Split('`')[12], out maxAddINT);
                long.TryParse(s.Split('`')[13], out maxAddLUK);
                long.TryParse(s.Split('`')[14], out maxAddPower);
                long.TryParse(s.Split('`')[15], out maxAddMagicPower);
                long.TryParse(s.Split('`')[16], out maxAddDefence);
                float.TryParse(s.Split('`')[17], out coolTime);
                float.TryParse(s.Split('`')[18], out stayTime);
                long.TryParse(s.Split('`')[19], out addMaxHP);
                long.TryParse(s.Split('`')[20], out addMaxMP);
                long.TryParse(s.Split('`')[21], out addSTR);
                long.TryParse(s.Split('`')[22], out addHEL);
                long.TryParse(s.Split('`')[23], out addINT);
                long.TryParse(s.Split('`')[24], out addLUK);
                long.TryParse(s.Split('`')[25], out addPower);
                long.TryParse(s.Split('`')[26], out addMagicPower);
                long.TryParse(s.Split('`')[27], out addDefence);
                long.TryParse(s.Split('`')[28], out requireLevel);
                long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
                long.TryParse(s.Split('`')[30], out requireSTR);
                long.TryParse(s.Split('`')[31], out requireHEL);
                long.TryParse(s.Split('`')[32], out requireINT);
                long.TryParse(s.Split('`')[33], out requireLUK);
                int.TryParse(s.Split('`')[34], out enhanceLevel);
                int.TryParse(s.Split('`')[35], out enhanceStack);
                bool.TryParse(s.Split('`')[36], out sharePosiible);
                streamReader.Close();

            }
            else if (this.transform.name.Split('_')[0] == "EtcSlot")
            {
                streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/EtcSlot_" + this.transform.name.Split('_')[1] + ".txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                itemName = s.Split('`')[0];
                bigItemType = s.Split('`')[1];
                smallItemType = s.Split('`')[2];
                long.TryParse(s.Split('`')[3], out price);
                itemExplain = s.Split('`')[4];
                int.TryParse(s.Split('`')[5], out quantity);
                long.TryParse(s.Split('`')[6], out maxAddHP);
                long.TryParse(s.Split('`')[7], out maxAddMP);
                long.TryParse(s.Split('`')[8], out maxAddMaxMP);
                long.TryParse(s.Split('`')[9], out maxAddMaxHP);
                long.TryParse(s.Split('`')[10], out maxAddSTR);
                long.TryParse(s.Split('`')[11], out maxAddHEL);
                long.TryParse(s.Split('`')[12], out maxAddINT);
                long.TryParse(s.Split('`')[13], out maxAddLUK);
                long.TryParse(s.Split('`')[14], out maxAddPower);
                long.TryParse(s.Split('`')[15], out maxAddMagicPower);
                long.TryParse(s.Split('`')[16], out maxAddDefence);
                float.TryParse(s.Split('`')[17], out coolTime);
                float.TryParse(s.Split('`')[18], out stayTime);
                long.TryParse(s.Split('`')[19], out addMaxHP);
                long.TryParse(s.Split('`')[20], out addMaxMP);
                long.TryParse(s.Split('`')[21], out addSTR);
                long.TryParse(s.Split('`')[22], out addHEL);
                long.TryParse(s.Split('`')[23], out addINT);
                long.TryParse(s.Split('`')[24], out addLUK);
                long.TryParse(s.Split('`')[25], out addPower);
                long.TryParse(s.Split('`')[26], out addMagicPower);
                long.TryParse(s.Split('`')[27], out addDefence);
                long.TryParse(s.Split('`')[28], out requireLevel);
                long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
                long.TryParse(s.Split('`')[30], out requireSTR);
                long.TryParse(s.Split('`')[31], out requireHEL);
                long.TryParse(s.Split('`')[32], out requireINT);
                long.TryParse(s.Split('`')[33], out requireLUK);
                int.TryParse(s.Split('`')[34], out enhanceLevel);
                int.TryParse(s.Split('`')[35], out enhanceStack);
                bool.TryParse(s.Split('`')[36], out sharePosiible);
                streamReader.Close();
            }
            else if (this.transform.name.Split('_')[0] == "CashSlot")
            {
                streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/CashSlot_" + this.transform.name.Split('_')[1] + ".txt", FileMode.Open, FileAccess.Read));
                s = streamReader.ReadLine();
                itemName = s.Split('`')[0];
                bigItemType = s.Split('`')[1];
                smallItemType = s.Split('`')[2];
                long.TryParse(s.Split('`')[3], out price);
                itemExplain = s.Split('`')[4];
                int.TryParse(s.Split('`')[5], out quantity);
                long.TryParse(s.Split('`')[6], out maxAddHP);
                long.TryParse(s.Split('`')[7], out maxAddMP);
                long.TryParse(s.Split('`')[8], out maxAddMaxMP);
                long.TryParse(s.Split('`')[9], out maxAddMaxHP);
                long.TryParse(s.Split('`')[10], out maxAddSTR);
                long.TryParse(s.Split('`')[11], out maxAddHEL);
                long.TryParse(s.Split('`')[12], out maxAddINT);
                long.TryParse(s.Split('`')[13], out maxAddLUK);
                long.TryParse(s.Split('`')[14], out maxAddPower);
                long.TryParse(s.Split('`')[15], out maxAddMagicPower);
                long.TryParse(s.Split('`')[16], out maxAddDefence);
                float.TryParse(s.Split('`')[17], out coolTime);
                float.TryParse(s.Split('`')[18], out stayTime);
                long.TryParse(s.Split('`')[19], out addMaxHP);
                long.TryParse(s.Split('`')[20], out addMaxMP);
                long.TryParse(s.Split('`')[21], out addSTR);
                long.TryParse(s.Split('`')[22], out addHEL);
                long.TryParse(s.Split('`')[23], out addINT);
                long.TryParse(s.Split('`')[24], out addLUK);
                long.TryParse(s.Split('`')[25], out addPower);
                long.TryParse(s.Split('`')[26], out addMagicPower);
                long.TryParse(s.Split('`')[27], out addDefence);
                long.TryParse(s.Split('`')[28], out requireLevel);
                long.TryParse(s.Split('`')[29], out requireAccumulateLevel);
                long.TryParse(s.Split('`')[30], out requireSTR);
                long.TryParse(s.Split('`')[31], out requireHEL);
                long.TryParse(s.Split('`')[32], out requireINT);
                long.TryParse(s.Split('`')[33], out requireLUK);
                int.TryParse(s.Split('`')[34], out enhanceLevel);
                int.TryParse(s.Split('`')[35], out enhanceStack);
                bool.TryParse(s.Split('`')[36], out sharePosiible);
                streamReader.Close();

            }



        }
  
        Refresh();

    }

    // loseItem
    // if 포션 or 버프 
    // 포션이면 옵션 랜덤돌려서 캐릭터의 체력, 마나를 올림
    // 버프면 옵션 랜덤돌려서 랜덤시간만큼 랜덤 스텟을 올림 
    public void Use()
    {
        if(bigItemType == "Consume")
        {

            SoundManager.instance.SoundEffectOn("EatPotionSound", SoundManager.instance.soundEffectNumber);
            // 사용한 아이템이 고정회복 포션이면 
            if (smallItemType == "StaticPotion")
            {
                //USeItemTemp에 아이템 정보를 넘기고 
                UIManager.instance.useItemTemp.itemName = itemName;
                UIManager.instance.useItemTemp.bigItemType = bigItemType;
                UIManager.instance.useItemTemp.smallItemType = smallItemType;
                UIManager.instance.useItemTemp.price = price;
                UIManager.instance.useItemTemp.itemExplain = itemExplain;
                UIManager.instance.useItemTemp.quantity = quantity;
                UIManager.instance.useItemTemp.maxAddHP = maxAddHP;
                UIManager.instance.useItemTemp.maxAddMP = maxAddMP;
                UIManager.instance.useItemTemp.maxAddMaxMP = maxAddMaxMP;
                UIManager.instance.useItemTemp.maxAddMaxHP = maxAddMaxHP;
                UIManager.instance.useItemTemp.sharePosiible = sharePosiible;
                UIManager.instance.useItemTemp.maxAddSTR = maxAddSTR;
                UIManager.instance.useItemTemp.maxAddHEL = maxAddHEL;
                UIManager.instance.useItemTemp.maxAddINT = maxAddINT;
                UIManager.instance.useItemTemp.maxAddLUK = maxAddLUK;
                UIManager.instance.useItemTemp.maxAddPower = maxAddPower;
                UIManager.instance.useItemTemp.maxAddPower = maxAddMagicPower;
                UIManager.instance.useItemTemp.maxAddDefence = maxAddDefence;
                UIManager.instance.useItemTemp.slotNumber = int.Parse(this.transform.name.Split('_')[1]) - 1;
                UIManager.instance.useItemTemp.stayTime = stayTime;

                //아이템 옵션에 따라 랜덤을 돌리고 
                if (maxAddHP > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddHP);
                }
                if (maxAddMP > 0)
                {
                    rand2 = (long)Random.Range(1, maxAddMP);
                }

                //캐릭터의 체력 or 마나를 회복시켜준다 
                if (CharacterManager.instance.HP + rand1 >= CharacterManager.instance.resultMaxHP)
                {
                    CharacterManager.instance.HP = CharacterManager.instance.resultMaxHP;
                    UIManager.instance.statWindow.Refresh();
                }
                else
                {
                    CharacterManager.instance.HP += rand1;
                    UIManager.instance.statWindow.Refresh();
                }
                if (CharacterManager.instance.MP + rand2 >= CharacterManager.instance.resultMaxMP)
                {
                    CharacterManager.instance.MP = CharacterManager.instance.resultMaxMP;
                    UIManager.instance.statWindow.Refresh();
                }
                else
                {
                    CharacterManager.instance.MP += rand2;
                    UIManager.instance.statWindow.Refresh();
                }
                // 그리고 아이템을 1개 없앤다 
                UIManager.instance.useItemTemp.LoseItem(1);
                //그리고 아이템 슬롯과 상태창, 스텟창 초기화 
                Refresh();
                // 스텟창 캐릭터 상태창도 refresh();

            }
            if (smallItemType == "PercentPotion")
            {
                //USeItemTemp에 아이템 정보를 넘기고 
                UIManager.instance.useItemTemp.itemName = itemName;
                UIManager.instance.useItemTemp.bigItemType = bigItemType;
                UIManager.instance.useItemTemp.smallItemType = smallItemType;
                UIManager.instance.useItemTemp.price = price;
                UIManager.instance.useItemTemp.itemExplain = itemExplain;
                UIManager.instance.useItemTemp.quantity = quantity;
                UIManager.instance.useItemTemp.maxAddHP = maxAddHP;
                UIManager.instance.useItemTemp.sharePosiible = sharePosiible;
                UIManager.instance.useItemTemp.maxAddMP = maxAddMP;
                UIManager.instance.useItemTemp.maxAddMaxMP = maxAddMaxMP;
                UIManager.instance.useItemTemp.maxAddMaxHP = maxAddMaxHP;
                UIManager.instance.useItemTemp.maxAddSTR = maxAddSTR;
                UIManager.instance.useItemTemp.maxAddHEL = maxAddHEL;
                UIManager.instance.useItemTemp.maxAddINT = maxAddINT;
                UIManager.instance.useItemTemp.maxAddLUK = maxAddLUK;
                UIManager.instance.useItemTemp.maxAddPower = maxAddPower;
                UIManager.instance.useItemTemp.maxAddMagicPower = maxAddMagicPower;
                UIManager.instance.useItemTemp.maxAddDefence = maxAddDefence;
                UIManager.instance.useItemTemp.slotNumber = int.Parse(this.transform.name.Split('_')[1]) - 1;
                UIManager.instance.useItemTemp.stayTime = stayTime;

                //아이템 옵션에 따라 랜덤을 돌리고 
                if (maxAddHP > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddHP);
                }
                if (maxAddMP > 0)
                {
                    rand2 = (long)Random.Range(1, maxAddMP);
                }

                //캐릭터의 체력 or 마나를 회복시켜준다 
                if (CharacterManager.instance.HP + ((CharacterManager.instance.resultMaxHP / 100) * rand1) >= CharacterManager.instance.resultMaxHP)
                {
                    CharacterManager.instance.HP = CharacterManager.instance.resultMaxHP;
                }
                else
                {
                    CharacterManager.instance.HP += ((CharacterManager.instance.resultMaxMP / 100) * rand1);
                }
                if (CharacterManager.instance.MP + ((CharacterManager.instance.resultMaxMP / 100) * rand2) >= CharacterManager.instance.resultMaxMP)
                {
                    CharacterManager.instance.MP = CharacterManager.instance.resultMaxMP;
                }
                else
                {
                    CharacterManager.instance.MP += ((CharacterManager.instance.resultMaxMP / 100) * rand2);
                }
                // 그리고 아이템을 1개 없앤다 
                UIManager.instance.useItemTemp.LoseItem(1);
                UIManager.instance.statWindow.Refresh();
                //그리고 아이템 슬롯과 상태창, 스텟창 초기화 
                Refresh();
                // 스텟창 캐릭터 상태창도 refresh();

            }
            else if (smallItemType == "Buff")
            {
                // 버프 아이템을 사용중이라면 버프 아이템 효과를 먼저 없애준다 
                if (CharacterManager.instance.isUseItemBuff)
                {
                    CharacterManager.instance.StopCoroutine(CharacterManager.instance.buffCoroutine);
                    CharacterManager.instance.addSTR -= CharacterManager.instance.useItemBuffAddSTR;
                    CharacterManager.instance.addHEL -= CharacterManager.instance.useItemBuffAddHEL;
                    CharacterManager.instance.addINT -= CharacterManager.instance.useItemBuffAddINT;
                    CharacterManager.instance.addLUK -= CharacterManager.instance.useItemBuffAddLUK;
                    CharacterManager.instance.addMaxHP -= CharacterManager.instance.useItemBuffAddMaxHP;
                    CharacterManager.instance.addMaxMP -= CharacterManager.instance.useItemBuffAddMaxMP;
                    CharacterManager.instance.addPower -= CharacterManager.instance.useItemBuffAddPower;
                    CharacterManager.instance.addMagicPower -= CharacterManager.instance.useItemBuffAddMagicPower;
                    CharacterManager.instance.addDefence -= CharacterManager.instance.useItemBuffAddDefence;
                    CharacterManager.instance.useItemBuffName = "null";
                    CharacterManager.instance.useItemBuffTime = 0;
                    CharacterManager.instance.useItemBuffAddSTR = 0;
                    CharacterManager.instance.useItemBuffAddHEL = 0;
                    CharacterManager.instance.useItemBuffAddINT = 0;
                    CharacterManager.instance.useItemBuffAddLUK = 0;
                    CharacterManager.instance.useItemBuffAddMaxHP = 0;
                    CharacterManager.instance.useItemBuffAddMaxMP = 0;
                    CharacterManager.instance.useItemBuffAddPower = 0;
                    CharacterManager.instance.useItemBuffAddMagicPower = 0;
                    CharacterManager.instance.useItemBuffAddDefence = 0;
                    CharacterManager.instance.isUseItemBuff = false;

                }
                // 그리고 useItemTemp에 아이템 정보를 넘겨준다 
                UIManager.instance.useItemTemp.itemName = itemName;
                UIManager.instance.useItemTemp.bigItemType = bigItemType;
                UIManager.instance.useItemTemp.smallItemType = smallItemType;
                UIManager.instance.useItemTemp.price = price;
                UIManager.instance.useItemTemp.itemExplain = itemExplain;
                UIManager.instance.useItemTemp.quantity = quantity;
                UIManager.instance.useItemTemp.maxAddHP = maxAddHP;
                UIManager.instance.useItemTemp.sharePosiible = sharePosiible;
                UIManager.instance.useItemTemp.maxAddMP = maxAddMP;
                UIManager.instance.useItemTemp.maxAddMaxMP = maxAddMaxMP;
                UIManager.instance.useItemTemp.maxAddMaxHP = maxAddMaxHP;
                UIManager.instance.useItemTemp.maxAddSTR = maxAddSTR;
                UIManager.instance.useItemTemp.maxAddHEL = maxAddHEL;
                UIManager.instance.useItemTemp.maxAddINT = maxAddINT;
                UIManager.instance.useItemTemp.maxAddLUK = maxAddLUK;
                UIManager.instance.useItemTemp.maxAddPower = maxAddPower;
                UIManager.instance.useItemTemp.maxAddMagicPower = maxAddMagicPower;
                UIManager.instance.useItemTemp.maxAddDefence = maxAddDefence;
                UIManager.instance.useItemTemp.slotNumber = int.Parse(this.transform.name.Split('_')[1]) - 1;
                UIManager.instance.useItemTemp.stayTime = stayTime;


                // 그 다음에 랜덤을 돌려서 버프 옵션을 얻는다 

                //힘
                if (maxAddSTR > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddSTR);
                    CharacterManager.instance.useItemBuffAddSTR = rand1;

                }
                else
                {
                    CharacterManager.instance.useItemBuffAddSTR = 0;
                }
                //건강
                if (maxAddHEL > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddHEL);
                    CharacterManager.instance.useItemBuffAddHEL = rand1;

                }
                else
                {
                    CharacterManager.instance.useItemBuffAddHEL = 0;
                }
                //지능
                if (maxAddINT > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddINT);
                    CharacterManager.instance.useItemBuffAddINT = rand1;

                }
                else
                {
                    CharacterManager.instance.useItemBuffAddINT = 0;
                }
                // 운ㄷ
                if (maxAddLUK > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddLUK);
                    CharacterManager.instance.useItemBuffAddLUK = rand1;

                }
                else
                {
                    CharacterManager.instance.useItemBuffAddLUK = 0;
                }
                // 최대체력 
                if (maxAddMaxHP > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddMaxHP);
                    CharacterManager.instance.useItemBuffAddMaxHP = rand1;

                }
                else
                {
                    CharacterManager.instance.useItemBuffAddMaxHP = 0;
                }
                //최대마나 
                if (maxAddMaxMP > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddMaxMP);
                    CharacterManager.instance.useItemBuffAddMaxMP = rand1;

                }
                else
                {
                    CharacterManager.instance.useItemBuffAddMaxMP = 0;
                }
                //공격력 
                if (maxAddPower > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddPower);
                    CharacterManager.instance.useItemBuffAddPower = rand1;

                }
                else
                {
                    CharacterManager.instance.useItemBuffAddPower = 0;
                }
                //마력
                if (maxAddMagicPower > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddMagicPower);
                    CharacterManager.instance.useItemBuffAddMagicPower = rand1;

                }
                else
                {
                    CharacterManager.instance.useItemBuffAddPower = 0;
                }
                //방어력 
                if (maxAddDefence > 0)
                {
                    rand1 = (long)Random.Range(1, maxAddDefence);
                    CharacterManager.instance.useItemBuffAddDefence = rand1;

                }
                else
                {
                    CharacterManager.instance.useItemBuffAddDefence = 0;
                }
                //지속시간
                if (stayTime > 0)
                {
                    rand3 = Random.Range(1f, stayTime);
                    CharacterManager.instance.useItemBuffTime = rand3;

                }
                else
                {
                    CharacterManager.instance.useItemBuffTime = 0;
                }
                // 캐릭터 능력치를 랜덤 돌려서 나온 값만큼 올려주고 코루틴을 시작한다 
                CharacterManager.instance.isUseItemBuff = true;
                CharacterManager.instance.addSTR += CharacterManager.instance.useItemBuffAddSTR;
                CharacterManager.instance.addHEL += CharacterManager.instance.useItemBuffAddHEL;
                CharacterManager.instance.addINT += CharacterManager.instance.useItemBuffAddINT;
                CharacterManager.instance.addLUK += CharacterManager.instance.useItemBuffAddLUK;
                CharacterManager.instance.addMaxHP += CharacterManager.instance.useItemBuffAddMaxHP;
                CharacterManager.instance.addMaxMP += CharacterManager.instance.useItemBuffAddMaxMP;
                CharacterManager.instance.addPower += CharacterManager.instance.useItemBuffAddPower;
                CharacterManager.instance.addMagicPower += CharacterManager.instance.useItemBuffAddMagicPower;
                CharacterManager.instance.addDefence += CharacterManager.instance.useItemBuffAddDefence;
                CharacterManager.instance.buffCoroutine = CharacterManager.instance.BuffItemStayCheck(CharacterManager.instance.useItemBuffTime);
                CharacterManager.instance.StartCoroutine(CharacterManager.instance.buffCoroutine);
                //아이템을 한개 없앤다 
                UIManager.instance.useItemTemp.LoseItem(1);
                //그리고 아이템 슬롯과 상태창, 스텟창 초기화 
                UIManager.instance.statWindow.Refresh();
                Refresh();
                // 스텟창 캐릭터 상태창도 refresh();


            }

        }

    }



    //아이템 슬롯을 클리하면 아이템 정보가 ItemTemp에 들어가고 오른쪽 화면에 정보가 나온다 
    public void SlotButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        if (itemName != "null")
        {
        UIManager.instance.itemTemp.slotNumber = int.Parse(this.transform.name.Split('_')[1]) - 1; 
        UIManager.instance.itemTemp.itemName = itemName;
        UIManager.instance.itemTemp.bigItemType = bigItemType;
        UIManager.instance.itemTemp.smallItemType = smallItemType;
        UIManager.instance.itemTemp.price = price;
        UIManager.instance.itemTemp.itemExplain = itemExplain;
        UIManager.instance.itemTemp.maxAddHP = maxAddHP;
        UIManager.instance.itemTemp.maxAddMP = maxAddMP;
        UIManager.instance.itemTemp.maxAddMaxMP = maxAddMaxMP;
        UIManager.instance.itemTemp.maxAddMaxHP = maxAddMaxHP;
        UIManager.instance.itemTemp.maxAddSTR = maxAddSTR;
        UIManager.instance.itemTemp.maxAddHEL = maxAddHEL;
        UIManager.instance.itemTemp.maxAddINT = maxAddINT;
        UIManager.instance.itemTemp.sharePosiible = sharePosiible;
        UIManager.instance.itemTemp.maxAddLUK = maxAddLUK;
        UIManager.instance.itemTemp.maxAddPower = maxAddPower;
        UIManager.instance.itemTemp.maxAddMagicPower = maxAddMagicPower;
        UIManager.instance.itemTemp.maxAddDefence = maxAddDefence;
        UIManager.instance.itemTemp.coolTime = coolTime;
        UIManager.instance.itemTemp.stayTime = stayTime;
        UIManager.instance.itemTemp.addMaxHP = addMaxHP;
        UIManager.instance.itemTemp.addMaxMP = addMaxMP;
        UIManager.instance.itemTemp.addSTR = addSTR;
        UIManager.instance.itemTemp.addHEL = addHEL;
        UIManager.instance.itemTemp.addINT = addINT;
        UIManager.instance.itemTemp.addLUK = addLUK;
        UIManager.instance.itemTemp.addPower = addPower;
        UIManager.instance.itemTemp.addMagicPower = addMagicPower;
        UIManager.instance.itemTemp.addDefence = addDefence;
        UIManager.instance.itemTemp.requireLevel = requireLevel;
        UIManager.instance.itemTemp.requireAccumulateLevel = requireAccumulateLevel;
        UIManager.instance.itemTemp.requireSTR = requireSTR;
        UIManager.instance.itemTemp.requireHEL = requireHEL;
        UIManager.instance.itemTemp.requireINT = requireINT;
        UIManager.instance.itemTemp.requireLUK = requireLUK;
        UIManager.instance.itemTemp.quantity = quantity;
        UIManager.instance.itemTemp.enhanceLevel = enhanceLevel;
        UIManager.instance.itemTemp.enhanceStack = enhanceStack;


            if (bigItemType == "Equipment")
            {
                UIManager.instance.item_SelectItemExplainText.text = itemName + "\n" + smallItemType + "\n가격 : " + price +
                "\n공격력 : + " + addPower + " 마력 : + " + addMagicPower + "\n방어력 : + " + addDefence + "최대체력 : + " + addMaxHP + " 최대마나 : + " + addMaxMP + "\n힘 : + " + addSTR + " 건강 : + " + addHEL + "\n지능 : + "
                + addINT + " 운 : + " + addLUK + "\n" + "착용 요구치 \n레벨 :  " + requireLevel + " 누적레벨 :  " + requireAccumulateLevel + "\nSTR : "
                + requireSTR + " HEL : " + requireHEL + "\nINT : " + requireINT + " LUK : " + requireLUK + "\n강화의 비약 : " + enhanceStack + " 중첩";
            }
            else if (bigItemType == "Consume")
            {
                if (smallItemType == "StaticPotion")
                {
                    UIManager.instance.item_SelectItemExplainText.text = itemName + "\n" + smallItemType + "\n가격 : " + price +
                        "\n체력회복량 : " + maxAddHP + "\n마나회복량 : " + maxAddMP + "\n" + itemExplain + "\n공유 : " + sharePosiible;
                }
                else if (smallItemType == "Buff")
                {
                    UIManager.instance.item_SelectItemExplainText.text = itemName + "\n" + smallItemType + "\n가격 : " + price +
                     "\n지속시간 : " + stayTime + "\n최대체력 : + " + maxAddMaxHP + "\n최대마나 : + " + maxAddMaxMP + "\n힘 : + "
                     + maxAddSTR + "\n건강 : + " + maxAddHEL + "\n지능 : + " + maxAddINT + "\n운 : + " + maxAddLUK + "\n공격력 : +"
                     + maxAddPower + "\n마력 : + " + maxAddMagicPower + "\n방어력 : + " + maxAddDefence + "\n" + itemExplain + "\n공유 : " + sharePosiible; ;


                }
                else if (smallItemType == "PercentPotion")
                {
                    UIManager.instance.item_SelectItemExplainText.text = itemName + "\n" + smallItemType + "\n가격 : " + price +
                       "\n체력회복량 : " + maxAddHP + "%\n마나회복량 : " + maxAddMP + "%\n" + itemExplain + "\n공유 : " + sharePosiible; ;
                }


            }
            else if (bigItemType == "Etc")
            {
                UIManager.instance.item_SelectItemExplainText.text = itemName + "\n가격 : " + price +
                  "\n" + itemExplain + "\n공유 : " + sharePosiible; ;
            }
            else if (bigItemType == "Cash")
            {
                UIManager.instance.item_SelectItemExplainText.text = itemName + "\n가격 : " + price +
                    "\n" + itemExplain + "\n공유 : " + sharePosiible; ;

            }

        }
        else
        {
            UIManager.instance.item_SelectItemExplainText.text = "";

        }
        //UIManager.instance.item_SelectItemExplainText.text = 내용


    }

    // 아이템 슬롯에 보이는 것들을 현재상태로 바꿔준다 
    public void Refresh()

    {



        // 아이템 이름이 널이 아니면 아이템이 있는 상태이기 떄문에 아이템 이미지로 바꿔줌 
        if (itemName != "null")
        {
            if(bigItemType == "Equipment")
            {
                if (itemName.Substring(0, 1).Equals("+"))
                {
                    itemImage.sprite = Resources.Load("Sprite/Item/" + bigItemType + "/" + itemName.Substring(3), typeof(Sprite)) as Sprite;
                    itemImage.color = new Color(1, 1, 1, 1);
                    quantityText.text = quantity.ToString();
                }
                else
                {
                    itemImage.sprite = Resources.Load("Sprite/Item/" + bigItemType + "/" + itemName, typeof(Sprite)) as Sprite;
                    quantityText.text = quantity.ToString();
                    itemImage.color = new Color(1, 1, 1, 1);

                }

            }
            else
            {
                itemImage.sprite = Resources.Load("Sprite/Item/" + bigItemType + "/" + itemName, typeof(Sprite)) as Sprite;
                quantityText.text = quantity.ToString();
                itemImage.color = new Color(1, 1, 1, 1);    
            }

        }
        //아이템 이름이 널이면 아이템이 없는 상태이기 때문에 이미지를 투명하게 해준다 
        else
        {

            itemImage.sprite = null;
            itemImage.color = new Color(1, 1, 1, 0);
            quantityText.text = 0.ToString();

        }

    }





}
