using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CharacterAddWindow : MonoBehaviour
{
    //캐릭터 선택 창 ㅌ
    public Text jobText;   //직업 클릭하면 나오는 텍스트 
    public Text jobExplainText;  // 직업 클릭하면 설명 나오는 텍스트 

    public int nameLength;   // 입력한 이름 길이 
    public int diceStr;  // 주사위 돌려서 나온 힘
    public int diceHel;  // 주사위 돌려서 나온 체력 
    public int diceInt; // 주사위 돌려서 나온 지능 
    public int diceLuk;  // 주사위 돌려서 나온 운 
    public string characterName;  //입력한 캐릭터 이름 


    public bool jobSelect;   // 직업 선택하면 true로 바뀐다 
    public string selectJob;   // 선택한 직업의 이름 

    public Text strText;   // 주사위 돌리면 표시되는 힘 
    public Text helText; // 주사위 돌리면 표시되는 체력 
    public Text intText;  //주사위 돌리면 표시되는 지능 
    public Text luckText; // 주사위 돌리면 표시되는 운 
    public Text characterAddFailText;  // 직업 선택하지 않았거나 

    public InputField nameInputField;

    public int selectNumber;  // 몇 번째  슬롯인지 

    public string environment;


    StreamReader streamReader;
    string line;
    StreamWriter streamWriter;
    FileStream fileStream;

    // Start is called before the first frame update
    void Start()
    {
        strText = transform.Find("StrText").gameObject.GetComponent<Text>();
        helText = transform.Find("HelText").gameObject.GetComponent<Text>();
        intText = transform.Find("IntText").gameObject.GetComponent<Text>();
        luckText = transform.Find("LuckText").gameObject.GetComponent<Text>();
        nameInputField = transform.Find("NameInputField").gameObject.GetComponent<InputField>();
        jobText = transform.Find("JobNameText").gameObject.GetComponent<Text>();
        jobExplainText = transform.Find("JobExpalinText").gameObject.GetComponent<Text>();
        characterAddFailText = transform.Find("CharacterAddFailText").gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //뒤로가기 버튼 눌렀을때 발생
    //현재 패널을 안보이게 하고 캐릭터 선택 창 패널을 보이게 한다 
    //그리고 주사위를 초기화 시켜주고 캐릭터 이름 등도 초기상태로 돌려준다 
    public void BackButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        this.gameObject.SetActive(false);
        UIManager.instance.characterSelecWindow.gameObject.SetActive(true);
        jobSelect = false;
        nameInputField.text = "";
        jobExplainText.text = "직업설명";
        jobText.text = "직업";
        selectJob = "null";
        diceStr = Random.Range(5, 21);
        diceHel = Random.Range(5, 21);
        diceInt = Random.Range(5, 21);
        diceLuk = Random.Range(5, 21);
        strText.text = diceStr.ToString();
        helText.text = diceHel.ToString();
        intText.text = diceInt.ToString();
        luckText.text = diceLuk.ToString();
        selectJob = "";
        jobText.text = "";
        jobExplainText.text = "";
        jobSelect = false;
    }



    // 주사위 클릭하면 실행한다 
    public void DiceClick()
    {
        
        //직업을 선택했으면 주사위가 돌아간다 
        if (jobSelect)
        {
            SoundManager.instance.SoundEffectOn("DiceSound", SoundManager.instance.soundEffectNumber);
            StartCoroutine(DiceClickCo());
        }


    }

    //전사를 클릭하면 직업 설명이 나오고 직업을 클릭한 상태로 바뀐다 
    public void WarriorClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        selectJob = "Warrior";
        jobText.text = "전사";
        jobExplainText.text = "검을 들고 싸우는 용맹한 전사이다";
        jobSelect = true;



    }




    //캐릭터 생성 버튼을 눌렀을때 발생한다
    // 먼저 캐릭터 생성 조건을 만족하였는지 확인한다 (캐릭터 이름을 길이 , 직업선택여부)
    // 생성 파일 캐릭터당 캐릭터 정보 파일, 아이템창(32x 4 ) 퀘스트스슬롯(5) 장비슬롯(9)
    // 창고는 최소 생성시에만 생성된다 (44)
    public void CharacterAddFinishButtonClick()
    {
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        // 직업을 선택했고 이름이 적절하면 다음을 진행한다 
        nameLength = nameInputField.text.Length;
        if (jobSelect && (nameLength >= 2 && nameLength < 9))
        {


            characterName = nameInputField.text;
            //캐릭터 정보  파일 생성 

            if(UIManager.instance.environment == "Mobile")
            {
                if (!Directory.Exists(Application.persistentDataPath + "/Load"))
                {
                    Directory.CreateDirectory(Application.persistentDataPath + "/Load");
                    Directory.CreateDirectory(Application.persistentDataPath + "/Load/Character1");
                    Directory.CreateDirectory(Application.persistentDataPath + "/Load/Character2");
                    Directory.CreateDirectory(Application.persistentDataPath + "/Load/Character3");
                }
                if (!Directory.Exists(Application.persistentDataPath + "/Load/Warehouse"))
                {
                    Directory.CreateDirectory(Application.persistentDataPath + "/Load/Warehouse");
                    for (int i = 0; i < 44; i++)
                    {
                        fileStream = File.Create(Application.persistentDataPath + "/Load/Warehouse/WarehouseSlot_"  + (i + 1) + ".txt");
                        fileStream.Close();
                        streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Warehouse/WarehouseSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                        streamWriter.Write("null`");  // 아이템 이름 
                        streamWriter.Write("null`");   //아이템 대분류 
                        streamWriter.Write("null`");  // 아이템 소분류 
                        streamWriter.Write("0`");   // 아이템 가격 
                        streamWriter.Write("null`");  // 아잍메 설명
                        streamWriter.Write("0`");  // 아이템 갯수 
                        streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                        streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                        streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                        streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                        streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                        streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                        streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                        streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                        streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                        streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                        streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                        streamWriter.Write("0`"); // 쿨타임
                        streamWriter.Write("0`"); // 지속시간 (버프 )
                        streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                        streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                        streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                        streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                        streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                        streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                        streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                        streamWriter.Write("0`"); // 장착시 올라가는 마력 
                        streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                        streamWriter.Write("0`"); // 장착 요구레벨 
                        streamWriter.Write("0`"); // 장착 요구누적레벨 
                        streamWriter.Write("0`");   // 장착 요구 STR
                        streamWriter.Write("0`"); // 장착 요구 HEL 
                        streamWriter.Write("0`"); //장착 요구 INT 
                        streamWriter.Write("0`"); // 장착 요구luck
                        streamWriter.Write("0`");  // 강화단계
                        streamWriter.Write("0`");// 강화스텍
                        streamWriter.Write("false`");  // 계정공유 가능한지 
                        streamWriter.Close();
                    }
                    //창고에 있는 돈 
                    fileStream = File.Create(Application.persistentDataPath + "/Load/Warehouse/WarehouseHasMoney.txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Warehouse/WarehouseHasMoney.txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("0");
                    streamWriter.Close();

                    //창고에 있는 캐시 
                    fileStream = File.Create(Application.persistentDataPath + "/Load/Warehouse/WarehouseHasCash.txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Warehouse/WarehouseHasCash.txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("0");
                    streamWriter.Close();

                }

                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/CharacterInfo.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/CharacterInfo.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write(characterName + "`");   //캐릭텅 이름 
                streamWriter.Write(selectNumber + "`");  // 몇 번째 슬롯 캐릭인지 
                streamWriter.Write("튜토리얼`"); // 현재마을 
                streamWriter.Write("튜토리얼`"); // 현재장소 
                streamWriter.Write("전사`");  //직업이름 
                streamWriter.Write("0`");  // 직업 차수 
                streamWriter.Write("1`");  // 레벨 
                streamWriter.Write("1`");  //누적레벨   
                streamWriter.Write("10`");    // 최고 요구경험치 
                streamWriter.Write("0`");   // 현재 경험치 
                streamWriter.Write("10`");   // 요구경험치  
                streamWriter.Write("0`");   // 환생 리턴스크롤 사용횟수 
                streamWriter.Write("0`");   //현재 스토리 단계 
                streamWriter.Write("0`");   // 환생  시 지급 ap 
                streamWriter.Write("0`");   //  현재 ap
                streamWriter.Write("0`");   // 현재 sp
                streamWriter.Write("30`");   // 기본 최대 hp
                streamWriter.Write("30`");   // 기본 최대 mp
                streamWriter.Write(diceStr + "`"); // 힘 스텟 
                streamWriter.Write(diceHel + "`");  // 체력 스텟 
                streamWriter.Write(diceInt + "`"); // 지능 스텟 
                streamWriter.Write(diceLuk + "`");  // 운 스텟 
                streamWriter.Write("0`");   // 추가 힘 스텟 
                streamWriter.Write("0`");  // 추가 체력 스텟 
                streamWriter.Write("0`");  //추가 지능 스텟 
                streamWriter.Write("0`");  // 추가 운 스텟 
                streamWriter.Write("0`");  // 추가 hp스텟
                streamWriter.Write("0`"); // 추가 mp스텟 
                streamWriter.Write("0`");  // 추가 공격력 
                streamWriter.Write("0`");  // 추가 마력 
                streamWriter.Write("0`"); // 추가 방어력 
                streamWriter.Write("false`");  // 버프 사용중인지 
                streamWriter.Write("0`");   // 버프 추가 힘 
                streamWriter.Write("0`");   // 버프 추가 체력 
                streamWriter.Write("0`");  // 버프 추가 지능 
                streamWriter.Write("0`");  // 버프 추가 운 
                streamWriter.Write("0`");   // 버프 추가 hp 
                streamWriter.Write("0`");  // 버프 추가 mp
                streamWriter.Write("0`");  // 버프 추가 공겨력 
                streamWriter.Write("0`"); // 버프 추가 마력 
                streamWriter.Write("0`"); // 버프 추가 방어력 
                streamWriter.Write("0`");  // 평타 데미지 세기  100이 2배 0이 1배 
                streamWriter.Write("10`");  // 이동속도 
                streamWriter.Write("8`");   // 점프력 
                streamWriter.Write("1`");  // 공격속도 
                streamWriter.Write("1`");  // 경험치 배율 
                streamWriter.Write("1`");  // 드랍배율 
                streamWriter.Write("0`");  // 몬스터 잡은 수 
                streamWriter.Write("0`");  // 죽은 횟수 
                streamWriter.Write("0`");   // 퀘스트 완료 횟수 
                streamWriter.Write("0`");   // 이제까지 얻은 경험치 양 
                streamWriter.Write("0`");   // 강화한 횟수 
                streamWriter.Write("0`");   // 환생한 횟수 
                streamWriter.Write("false`");   // 무기 장착여부 
                streamWriter.Write("false`");  // 방패 장착여부 
                streamWriter.Write("false`");  // 헬멧 장착여부 
                streamWriter.Write("false`");   // 갑옷 장착여부 
                streamWriter.Write("false`");   // 장갑 장착여부 
                streamWriter.Write("false`");  // 신발 장착여부 
                streamWriter.Write("false`");  // 반지 장착여부  
                streamWriter.Write("false`");  // 귀걸이 장착여부 
                streamWriter.Write("false`");   // 목걸이 장착여부 

                streamWriter.Write("0`");   // 1-1스킬레벨 
                streamWriter.Write("0`");  // 1-2스킬레벨
                streamWriter.Write("0`");  // 1-3스킬레벨 
                streamWriter.Write("0`");   // 2-1스킬레벨
                streamWriter.Write("0`");   // 2-2스킬레벨
                streamWriter.Write("0`");   // 2-3스킬레벨
                streamWriter.Write("0`");   // 2-4스킬레벨 
                streamWriter.Write("0`");  // 3-1스킬레벨 
                streamWriter.Write("0`");  // 3-2스킬레벨
                streamWriter.Write("0`");  // 3-3스킬레벨

                streamWriter.Write("0`");  // 3-4스킬레벨
                streamWriter.Write("0`");  // 3-5스킬레벨  
                streamWriter.Write("0`");  //4-1스킬레벨 
                streamWriter.Write("0`");  // 4-2스킬레벨
                streamWriter.Write("0`");  // 4-3스킬레벨
                streamWriter.Write("0`");  // 4-4스킬레벨
                streamWriter.Write("0`"); // 4-5스킬레벨
                streamWriter.Write("0`");   // 4-6스킬레벨
                streamWriter.Write("true`");  // 도움말 패널 켜져있는지
                streamWriter.Write("true`"); // 퀘스트 진행패널 켜져있는지 
                streamWriter.Close();



                //아이템창 파일 생성
                for (int i = 0; i < 32; i++)
                {
                    fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  // 아이템 이름 
                    streamWriter.Write("null`");   //아이템 대분류 
                    streamWriter.Write("null`");  // 아이템 소분류 
                    streamWriter.Write("0`");   // 아이템 가격 
                    streamWriter.Write("null`");  // 아잍메 설명
                    streamWriter.Write("0`");  // 아이템 갯수 
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("false`");  // 계정공유 가능한지 
                    streamWriter.Close();
                    fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/ConsumeSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/ConsumeSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  // 아이템 이름 
                    streamWriter.Write("null`");   //아이템 대분류 
                    streamWriter.Write("null`");  // 아이템 소분류 
                    streamWriter.Write("0`");   // 아이템 가격 
                    streamWriter.Write("null`");  // 아잍메 설명
                    streamWriter.Write("0`");  // 아이템 갯수 
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("false`");  // 계정공유 가능한지 
                    streamWriter.Close();
                    fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EtcSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EtcSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  // 아이템 이름 
                    streamWriter.Write("null`");   //아이템 대분류 
                    streamWriter.Write("null`");  // 아이템 소분류 
                    streamWriter.Write("0`");   // 아이템 가격 
                    streamWriter.Write("null`");  // 아잍메 설명
                    streamWriter.Write("0`");  // 아이템 갯수 
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("false`");  // 계정공유 가능한지 
                    streamWriter.Close();
                    fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/CashSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/CashSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  // 아이템 이름 
                    streamWriter.Write("null`");   //아이템 대분류 
                    streamWriter.Write("null`");  // 아이템 소분류 
                    streamWriter.Write("0`");   // 아이템 가격 
                    streamWriter.Write("null`");  // 아잍메 설명
                    streamWriter.Write("0`");  // 아이템 갯수 
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("false`");  // 계정공유 가능한지 
                    streamWriter.Close();
                }
                // 가지고 있는 돈 파일 생성 
                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/HasMoney.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/HasMoney.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("0");
                streamWriter.Close();
                // 가지고 있는 캐시파일 생성 
                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/HasCash.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/HasCash.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("0");
                streamWriter.Close();

                // 진행 퀘스트 슬롯 파일 생성 
                for (int i = 0; i < 5; i++)
                {
                    fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/QuestSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/QuestSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  //퀘스트이름
                    streamWriter.Write("null`");  // 퀘스트 타입 (반복인지 스토리인지)
                    streamWriter.Write("null`"); // 퀘스트 종류   (사냥인지 아이템 수집인지 NPC방문인지)
                    for (int j = 0; j < 12; j++)
                        streamWriter.Write("null`");  // 퀘스트 설명 
                    streamWriter.Write("null`"); // 퀘스트 NPC
                    streamWriter.Write("0`");   // 퀘스트 보상(경험치)
                    streamWriter.Write("0`"); // 퀘스트 보상(돈)
                    streamWriter.Write("null`");  //퀘스트 보상 아이템 
                    streamWriter.Write("false`");   // 퀘스트 상태 true되면 퀘스트 완료 가능 
                    streamWriter.Write("0`");  // 스토리 퀘스트인경우 스토리 단계
                    streamWriter.Write("null`");  // 퀘스트 완료조건 NPC
                    streamWriter.Write("false`");   // 퀘스트 완료조건 NPC만났는지 
                    streamWriter.Write("null`");   // 퀘스트 완료조건 아이템
                    streamWriter.Write("0`");     // 퀘스트 완료조건 아이템 숫자 요구치 
                    streamWriter.Write("0`");   // 현재 모은 아이템 숫자 
                    streamWriter.Write("false`"); // 아이템 다 모았는지
                    streamWriter.Write("null`");  // 퀘스트 완료조건 몬스터 이름
                    streamWriter.Write("0`");   // 퀘스트 완료조건 몬스터 숫자 
                    streamWriter.Write("0`"); // 현재 잡은 몬스토 숫자 
                    streamWriter.Write("fasle`");   // 몬스터 다 잡았는지 
                    streamWriter.Write("null`");  //보상 아이템 대분류
                    streamWriter.Write("null`");  // 보상 아이템 소분류
                    streamWriter.Write("0`");    // 아이템 가격
                    streamWriter.Write("null`"); //아이템 설명
                    streamWriter.Write("0`");  // 아이템 숫자
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("0`");// 퀘스트 요구 레베 ㄹ
                    streamWriter.Write("0`");// 퀘스트 요구 누적레벨 
                    streamWriter.Write("false`");// 퀘스트 보상 아이템 교환 가능한지
                    streamWriter.Close();

                }

                //장착 장비 정보 담는 파일 생성 
                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipWeapon.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipWeapon.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();




                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipArmor.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipArmor.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipShoes.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipShoes.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipHelmet.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipHelmet.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipEarring.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipEarring.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipShield.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipShield.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipRing.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipRing.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipGlove.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipGlove.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipNecklace.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/EquipNecklace.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();
                for (int i = 0; i < 5; i++)
                {
                    fileStream = File.Create(Application.persistentDataPath + "/Load/Character" + selectNumber + "/QuickSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + selectNumber + "/QuickSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`"); // 슬롯에 등록된게 있는지 없는지 
                    streamWriter.Write("-1`");  // 등록되어있다면 몇번재 슬롯 아이템이 등록되어있는지
                    streamWriter.Write("null`"); //퀵슬롯 등록 아이템 이름;
                    streamWriter.Close();
                }



                UIManager.instance.characterSelecWindow.SelectNumber = 0;
                //슬롯화면 새로고침하고 캐릭터 선택창으로 
                UIManager.instance.CharacterSlot[selectNumber - 1].Refresh();



                this.gameObject.SetActive(false);
                UIManager.instance.characterSelecWindow.gameObject.SetActive(true);
                diceStr = Random.Range(5, 21);
                diceHel = Random.Range(5, 21);
                diceInt = Random.Range(5, 21);
                diceLuk = Random.Range(5, 21);
                strText.text = diceStr.ToString();
                helText.text = diceHel.ToString();
                intText.text = diceInt.ToString();
                luckText.text = diceLuk.ToString();
                nameInputField.text = "";
                selectJob = "";
                jobText.text = "";
                jobExplainText.text = "";
                jobSelect = false;


            }
            else
            {
                //창고 파일이 존재하지 않을경우 창고 파일을 만든다
                if (!(File.Exists("Assets/Resources/Load/WarehouseSlot_1.txt")))
                {
                    for (int i = 0; i < 44; i++)
                    {
                        fileStream = File.Create("Assets/Resources/Load/WarehouseSlot_" + (i + 1) + ".txt");
                        fileStream.Close();
                        streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/WarehouseSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                        streamWriter.Write("null`");  // 아이템 이름 
                        streamWriter.Write("null`");   //아이템 대분류 
                        streamWriter.Write("null`");  // 아이템 소분류 
                        streamWriter.Write("0`");   // 아이템 가격 
                        streamWriter.Write("null`");  // 아잍메 설명
                        streamWriter.Write("0`");  // 아이템 갯수 
                        streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                        streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                        streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                        streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                        streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                        streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                        streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                        streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                        streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                        streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                        streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                        streamWriter.Write("0`"); // 쿨타임
                        streamWriter.Write("0`"); // 지속시간 (버프 )
                        streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                        streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                        streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                        streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                        streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                        streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                        streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                        streamWriter.Write("0`"); // 장착시 올라가는 마력 
                        streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                        streamWriter.Write("0`"); // 장착 요구레벨 
                        streamWriter.Write("0`"); // 장착 요구누적레벨 
                        streamWriter.Write("0`");   // 장착 요구 STR
                        streamWriter.Write("0`"); // 장착 요구 HEL 
                        streamWriter.Write("0`"); //장착 요구 INT 
                        streamWriter.Write("0`"); // 장착 요구luck
                        streamWriter.Write("0`");  // 강화단계
                        streamWriter.Write("0`");// 강화스텍
                        streamWriter.Write("false`");  // 계정공유 가능한지 
                        streamWriter.Close();
                    }
                    //창고에 있는 돈 
                    fileStream = File.Create("Assets/Resources/Load/WarehouseHasMoney.txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/WarehouseHasMoney.txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("0");
                    streamWriter.Close();

                    //창고에 있는 캐시 
                    fileStream = File.Create("Assets/Resources/Load/WarehouseHasCash.txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/WarehouseHasCash.txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("0");
                    streamWriter.Close();

                }


           
                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/CharacterInfo.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/CharacterInfo.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write(characterName + "`");   //캐릭텅 이름 
                streamWriter.Write(selectNumber + "`");  // 몇 번째 슬롯 캐릭인지 
                streamWriter.Write("튜토리얼`"); // 현재마을 
                streamWriter.Write("튜토리얼`"); // 현재장소 
                streamWriter.Write("전사`");  //직업이름 
                streamWriter.Write("0`");  // 직업 차수 
                streamWriter.Write("1`");  // 레벨 
                streamWriter.Write("1`");  //누적레벨   
                streamWriter.Write("10`");    // 최고 요구경험치 
                streamWriter.Write("0`");   // 현재 경험치 
                streamWriter.Write("10`");   // 요구경험치  
                streamWriter.Write("0`");   // 환생 리턴스크롤 사용횟수 
                streamWriter.Write("0`");   //현재 스토리 단계 
                streamWriter.Write("0`");   // 환생  시 지급 ap 
                streamWriter.Write("0`");   //  현재 ap
                streamWriter.Write("0`");   // 현재 sp
                streamWriter.Write("30`");   // 기본 최대 hp
                streamWriter.Write("30`");   // 기본 최대 mp
                streamWriter.Write(diceStr + "`"); // 힘 스텟 
                streamWriter.Write(diceHel + "`");  // 체력 스텟 
                streamWriter.Write(diceInt + "`"); // 지능 스텟 
                streamWriter.Write(diceLuk + "`");  // 운 스텟 
                streamWriter.Write("0`");   // 추가 힘 스텟 
                streamWriter.Write("0`");  // 추가 체력 스텟 
                streamWriter.Write("0`");  //추가 지능 스텟 
                streamWriter.Write("0`");  // 추가 운 스텟 
                streamWriter.Write("0`");  // 추가 hp스텟
                streamWriter.Write("0`"); // 추가 mp스텟 
                streamWriter.Write("0`");  // 추가 공격력 
                streamWriter.Write("0`");  // 추가 마력 
                streamWriter.Write("0`"); // 추가 방어력 
                streamWriter.Write("false`");  // 버프 사용중인지 
                streamWriter.Write("0`");   // 버프 추가 힘 
                streamWriter.Write("0`");   // 버프 추가 체력 
                streamWriter.Write("0`");  // 버프 추가 지능 
                streamWriter.Write("0`");  // 버프 추가 운 
                streamWriter.Write("0`");   // 버프 추가 hp 
                streamWriter.Write("0`");  // 버프 추가 mp
                streamWriter.Write("0`");  // 버프 추가 공겨력 
                streamWriter.Write("0`"); // 버프 추가 마력 
                streamWriter.Write("0`"); // 버프 추가 방어력 
                streamWriter.Write("0`");  // 평타 데미지 세기  100이 2배 0이 1배 
                streamWriter.Write("10`");  // 이동속도 
                streamWriter.Write("8`");   // 점프력 
                streamWriter.Write("1`");  // 공격속도 
                streamWriter.Write("1`");  // 경험치 배율 
                streamWriter.Write("1`");  // 드랍배율 
                streamWriter.Write("0`");  // 몬스터 잡은 수 
                streamWriter.Write("0`");  // 죽은 횟수 
                streamWriter.Write("0`");   // 퀘스트 완료 횟수 
                streamWriter.Write("0`");   // 이제까지 얻은 경험치 양 
                streamWriter.Write("0`");   // 강화한 횟수 
                streamWriter.Write("0`");   // 환생한 횟수 
                streamWriter.Write("false`");   // 무기 장착여부 
                streamWriter.Write("false`");  // 방패 장착여부 
                streamWriter.Write("false`");  // 헬멧 장착여부 
                streamWriter.Write("false`");   // 갑옷 장착여부 
                streamWriter.Write("false`");   // 장갑 장착여부 
                streamWriter.Write("false`");  // 신발 장착여부 
                streamWriter.Write("false`");  // 반지 장착여부  
                streamWriter.Write("false`");  // 귀걸이 장착여부 
                streamWriter.Write("false`");   // 목걸이 장착여부 

                streamWriter.Write("0`");   // 1-1스킬레벨 
                streamWriter.Write("0`");  // 1-2스킬레벨
                streamWriter.Write("0`");  // 1-3스킬레벨 
                streamWriter.Write("0`");   // 2-1스킬레벨
                streamWriter.Write("0`");   // 2-2스킬레벨
                streamWriter.Write("0`");   // 2-3스킬레벨
                streamWriter.Write("0`");   // 2-4스킬레벨 
                streamWriter.Write("0`");  // 3-1스킬레벨 
                streamWriter.Write("0`");  // 3-2스킬레벨
                streamWriter.Write("0`");  // 3-3스킬레벨

                streamWriter.Write("0`");  // 3-4스킬레벨
                streamWriter.Write("0`");  // 3-5스킬레벨  
                streamWriter.Write("0`");  //4-1스킬레벨 
                streamWriter.Write("0`");  // 4-2스킬레벨
                streamWriter.Write("0`");  // 4-3스킬레벨
                streamWriter.Write("0`");  // 4-4스킬레벨
                streamWriter.Write("0`"); // 4-5스킬레벨
                streamWriter.Write("0`");   // 4-6스킬레벨
                streamWriter.Write("true`");  // 도움말 패널 켜져있는지
                streamWriter.Write("true`"); // 퀘스트 진행패널 켜져있는지 
                streamWriter.Close();



                //아이템창 파일 생성
                for (int i = 0; i < 32; i++)
                {
                    fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  // 아이템 이름 
                    streamWriter.Write("null`");   //아이템 대분류    
                    streamWriter.Write("null`");  // 아이템 소분류 
                    streamWriter.Write("0`");   // 아이템 가격 
                    streamWriter.Write("null`");  // 아잍메 설명
                    streamWriter.Write("0`");  // 아이템 갯수 
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("false`");  // 계정공유 가능한지 
                    streamWriter.Close();
                    fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/ConsumeSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/ConsumeSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  // 아이템 이름 
                    streamWriter.Write("null`");   //아이템 대분류 
                    streamWriter.Write("null`");  // 아이템 소분류 
                    streamWriter.Write("0`");   // 아이템 가격 
                    streamWriter.Write("null`");  // 아잍메 설명
                    streamWriter.Write("0`");  // 아이템 갯수 
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("false`");  // 계정공유 가능한지 
                    streamWriter.Close();
                    fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EtcSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EtcSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  // 아이템 이름 
                    streamWriter.Write("null`");   //아이템 대분류 
                    streamWriter.Write("null`");  // 아이템 소분류 
                    streamWriter.Write("0`");   // 아이템 가격 
                    streamWriter.Write("null`");  // 아잍메 설명
                    streamWriter.Write("0`");  // 아이템 갯수 
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("false`");  // 계정공유 가능한지 
                    streamWriter.Close();
                    fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/CashSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/CashSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  // 아이템 이름 
                    streamWriter.Write("null`");   //아이템 대분류 
                    streamWriter.Write("null`");  // 아이템 소분류 
                    streamWriter.Write("0`");   // 아이템 가격 
                    streamWriter.Write("null`");  // 아잍메 설명
                    streamWriter.Write("0`");  // 아이템 갯수 
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("false`");  // 계정공유 가능한지 
                    streamWriter.Close();
                }
                // 가지고 있는 돈 파일 생성 
                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/HasMoney.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/HasMoney.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("0");
                streamWriter.Close();
                // 가지고 있는 캐시파일 생성 
                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/HasCash.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/HasCash.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("0");
                streamWriter.Close();

                // 진행 퀘스트 슬롯 파일 생성 
                for (int i = 0; i < 5; i++)
                {
                    fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/QuestSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/QuestSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`");  //퀘스트이름
                    streamWriter.Write("null`");  // 퀘스트 타입 (반복인지 스토리인지)
                    streamWriter.Write("null`"); // 퀘스트 종류   (사냥인지 아이템 수집인지 NPC방문인지)
                    for (int j = 0; j < 12; j++)
                        streamWriter.Write("null`");  // 퀘스트 설명 
                    streamWriter.Write("null`"); // 퀘스트 NPC
                    streamWriter.Write("0`");   // 퀘스트 보상(경험치)
                    streamWriter.Write("0`"); // 퀘스트 보상(돈)
                    streamWriter.Write("null`");  //퀘스트 보상 아이템 
                    streamWriter.Write("false`");   // 퀘스트 상태 true되면 퀘스트 완료 가능 
                    streamWriter.Write("0`");  // 스토리 퀘스트인경우 스토리 단계
                    streamWriter.Write("null`");  // 퀘스트 완료조건 NPC
                    streamWriter.Write("false`");   // 퀘스트 완료조건 NPC만났는지 
                    streamWriter.Write("null`");   // 퀘스트 완료조건 아이템
                    streamWriter.Write("0`");     // 퀘스트 완료조건 아이템 숫자 요구치 
                    streamWriter.Write("0`");   // 현재 모은 아이템 숫자 
                    streamWriter.Write("false`"); // 아이템 다 모았는지
                    streamWriter.Write("null`");  // 퀘스트 완료조건 몬스터 이름
                    streamWriter.Write("0`");   // 퀘스트 완료조건 몬스터 숫자 
                    streamWriter.Write("0`"); // 현재 잡은 몬스토 숫자 
                    streamWriter.Write("fasle`");   // 몬스터 다 잡았는지 
                    streamWriter.Write("null`");  //보상 아이템 대분류
                    streamWriter.Write("null`");  // 보상 아이템 소분류
                    streamWriter.Write("0`");    // 아이템 가격
                    streamWriter.Write("null`"); //아이템 설명
                    streamWriter.Write("0`");  // 아이템 숫자
                    streamWriter.Write("0`");  // 사용시 올라가는 체력 최대치 (포션)
                    streamWriter.Write("0`"); //사용시 욜라가는 마나 최대치 (포션)
                    streamWriter.Write("0`");  //사용시 올라가는 최대 체력 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시올라가는 최대마나 최대치(버프)
                    streamWriter.Write("0`");  // 사용시 올라가는 STR스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Hel 스텟 최대치(버프 )
                    streamWriter.Write("0`"); //사용시 올라가는 INt 스텟 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 Luk스텟 최대치(버프 )
                    streamWriter.Write("0`");  // 사용시 올라가는 공격력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 마력 최대치 (버프 )
                    streamWriter.Write("0`"); // 사용시 올라가는 방어력 최대치 (버프 )
                    streamWriter.Write("0`"); // 쿨타임
                    streamWriter.Write("0`"); // 지속시간 (버프 )
                    streamWriter.Write("0`"); // 장착시 올라가는 최대체력
                    streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                    streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 HEL 스텟
                    streamWriter.Write("0`"); // 장착시 올라가근 INT스텟 
                    streamWriter.Write("0`"); // 장착시 올라가는 LUCK 스텟
                    streamWriter.Write("0`"); // 장착시 올라가는 공격력 
                    streamWriter.Write("0`"); // 장착시 올라가는 마력 
                    streamWriter.Write("0`"); // 장착시 올라가는 방어력 
                    streamWriter.Write("0`"); // 장착 요구레벨 
                    streamWriter.Write("0`"); // 장착 요구누적레벨 
                    streamWriter.Write("0`");   // 장착 요구 STR
                    streamWriter.Write("0`"); // 장착 요구 HEL 
                    streamWriter.Write("0`"); //장착 요구 INT 
                    streamWriter.Write("0`"); // 장착 요구luck
                    streamWriter.Write("0`");  // 강화단계
                    streamWriter.Write("0`");// 강화스텍
                    streamWriter.Write("0`");// 퀘스트 요구 레베 ㄹ
                    streamWriter.Write("0`");// 퀘스트 요구 누적레벨 
                    streamWriter.Write("false`");// 퀘스트 보상 아이템 교환 가능한지
                    streamWriter.Close();

                }

                //장착 장비 정보 담는 파일 생성 
                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipWeapon.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipWeapon.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();




                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipArmor.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipArmor.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipShoes.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipShoes.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipHelmet.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipHelmet.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipEarring.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipEarring.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipShield.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipShield.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipRing.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipRing.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipGlove.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipGlove.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();

                fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/EquipNecklace.txt");
                fileStream.Close();
                streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/EquipNecklace.txt", FileMode.Append, FileAccess.Write));
                streamWriter.Write("null`");   // 아이템 이름 
                streamWriter.Write("null`"); // 아이템 대분류
                streamWriter.Write("null`"); // 아이템 소분류 
                streamWriter.Write("0`");  //아이템 가격 
                streamWriter.Write("null`"); //아이템 설명 
                streamWriter.Write("0`");  // 아이템 숫자 
                streamWriter.Write("false`");  //아이템 계정공유 여부
                streamWriter.Write("0`");  // 장착시 올라가는 최대체력 
                streamWriter.Write("0`"); // 장착시 올라가는 최대마나 
                streamWriter.Write("0`"); //장착시 올라가는 STR스텟
                streamWriter.Write("0`"); // 장착시 올라가는 HEL스텟 
                streamWriter.Write("0`"); // 장착시 올라가는 INT스텟
                streamWriter.Write("0`"); // 장착시 올라가는 LUCK스텟
                streamWriter.Write("0`"); //장착시 올라가는 공격력
                streamWriter.Write("0`"); // 장착시 올라가는 마력
                streamWriter.Write("0`");// 장착시 올라가는 방어력
                streamWriter.Write("0`");  // 장착 요구레벨
                streamWriter.Write("0`"); // 장착 요구누적레벨
                streamWriter.Write("0`"); // 장착 요구 STR
                streamWriter.Write("0`"); // 장착 요구 HEL
                streamWriter.Write("0`"); // 장착 요구 INT
                streamWriter.Write("0`"); // 장착 요구 LUCk 
                streamWriter.Write("0`"); // 강화단계 
                streamWriter.Write("0`"); // 강화스텍 
                streamWriter.Close();
                for (int i = 0; i < 5; i++)
                {
                    fileStream = File.Create("Assets/Resources/Load/Character" + selectNumber + "/QuickSlot_" + (i + 1) + ".txt");
                    fileStream.Close();
                    streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + selectNumber + "/QuickSlot_" + (i + 1) + ".txt", FileMode.Append, FileAccess.Write));
                    streamWriter.Write("null`"); // 슬롯에 등록된게 있는지 없는지 
                    streamWriter.Write("-1`");  // 등록되어있다면 몇번재 슬롯 아이템이 등록되어있는지
                    streamWriter.Write("null`"); //퀵슬롯 등록 아이템 이름;
                    streamWriter.Close();
                }



                UIManager.instance.characterSelecWindow.SelectNumber = 0;
                //슬롯화면 새로고침하고 캐릭터 선택창으로 
                UIManager.instance.CharacterSlot[selectNumber - 1].Refresh();

                this.gameObject.SetActive(false);
                UIManager.instance.characterSelecWindow.gameObject.SetActive(true);
                diceStr = Random.Range(5, 21);
                diceHel = Random.Range(5, 21);
                diceInt = Random.Range(5, 21);
                diceLuk = Random.Range(5, 21);
                strText.text = diceStr.ToString();
                helText.text = diceHel.ToString();
                intText.text = diceInt.ToString();
                luckText.text = diceLuk.ToString();
                nameInputField.text = "";
                selectJob = "";
                jobText.text = "";
                jobExplainText.text = "";
                jobSelect = false;


            }
   
        }
        else
        {
            StartCoroutine(CharacterAddFailTextCo());
        }

    }



    //주사위 클릭했을때 실행하는 코루틴 
    IEnumerator DiceClickCo()
    {
        strText.text = "||";
        helText.text = "||";
        intText.text = "||";
        luckText.text = "||";
        UIManager.instance.character_DiceButton.sprite = Resources.Load("Sprite/UI/Window/dice2", typeof(Sprite)) as Sprite;
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.character_DiceButton.sprite = Resources.Load("Sprite/UI/Window/dice3", typeof(Sprite)) as Sprite;
        yield return new WaitForSeconds(0.3f);
        UIManager.instance.character_DiceButton.sprite = Resources.Load("Sprite/UI/Window/dice1", typeof(Sprite)) as Sprite;
        diceStr = Random.Range(5, 21);
        diceHel = Random.Range(5, 21);
        diceInt = Random.Range(5, 21);
        diceLuk = Random.Range(5, 21);
        strText.text = diceStr.ToString();
        helText.text = diceHel.ToString();
        intText.text = diceInt.ToString();
        luckText.text = diceLuk.ToString();


    }

    IEnumerator CharacterAddFailTextCo()
    {

        characterAddFailText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        characterAddFailText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);

    }


}
