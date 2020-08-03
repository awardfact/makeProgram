using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour    // 플레이어의 정보를 관리하는 매니저, 싱글톤으로 관리 
{


    public string attackName;


    StreamWriter streamWriter;
    StreamReader streamReader;
    string s;

    public static CharacterManager instance = null;

    public UIManager uiManager; // ui매니저 

    public string CharacterName;  // 이름
    public int characterNumber;   // 캐릭터 창에서 몇번째 캐릭인지 

    public string currentCity;
    public string currentPosition; // 현재 장소 

    public string job;  // 직업
    public int thJob; // 몇차 전직인지 

    public int Level; // 레벨 
    public int accumulateLevel; //누적레벨 

    public long maxNeedExp;  // 렙업했을 떄 랜덤으로 요구 경험치가 정해지는데 렙얼할때마다 랜덤으로 정해지는 범위는 고정되어있어서 렙업하면 이 변수의 범위가 바뀌고 이 변수 범위 내에서 needExp가 결정됨
    public long currentExp;  // 현재경험치
    public long needExp; // 요구경험치

    public int rebirthReturnScrollUseNumber;

    public int story;




    public long rebirthAPStack;    // 환생했을떄 지급되는 AP
    public long AP;
    public long SP;


    public long HP; // 현제체력 ,마나 
    public long MP;

    public long maxHP;  //기본 체력
    public long maxMP;  //기본 마나


    public long STR; //기본 힘
    public long HEL; //기본  건강
    public long INT; // 기본 지능
    public long LUK; //기본 운 



    public long power;  //최종 공격력
    public long magicPower; //최종 마력
    public long defence;  //최종 방어력




    public long addSTR;  //총 추가로 올라간 스텟
    public long addLUK;
    public long addINT;
    public long addHEL;
    public long addHP;
    public long addMP;
    public long addPower; // 총 추가로 올라간 공격력       addPower = addEquipPower + add
    public long addMagicPower;
    public long addDefence;  // '' 방어력
    public long addMaxHP;  //  '' 체력 
    public long addMaxMP;  // '' 마나 


    public long resultSTR;  // 기본스텟 + 올라간 스텟 
    public long resultHEL;
    public long resultINT;
    public long resultLUK;
    public long resultMaxHP;
    public long resultMaxMP;


    public IEnumerator buffCoroutine;

    public bool helpPanelVisible;
    public bool questingPanelVisible;


    public bool npcTalk;


    /*   public long addEquipSTR; //장비로 올라간 스텟
       public long addEquipLUK;
       public long addEquipINT;
       public long addEquipHEL;
       public long addEquipHP;
       public long addEquipMP;
       public long addEquipPower;
       public long addEquipDefence;
       public long addEquipMaxHp;
       public long addEquipMaxMp;

       public long addITemBuffSTR; // 아이템 버프로 올라간 스텟  
       //버프 사용되거나 해제되면 리셋되는데 그때addItemBuffSTR = 0 for(int i = 0; i < 5; i++) addItemBuffSTR += useItemBuffAddSTR[i];
       // 후에 addSTR = addItemBuffSTR + addSkillSTR + addEquipSTR; 
       // 그리고 stat창 refresh() 메소드 호출 
       // 스킬도 한 스킬이라도 사용되거나 시간이 끝나면 이와 같은 계산을 한다 
       // 장비는 장착이나 해제되었을때 계산 

       public long addITemBuffLUK;
       public long addItemBuffINT;
       public long addItemBuffHEL;
       public long addItemBuffHP;
       public long addItemBuffpMP;
       public long addItemBuffPower;
       public long addItemBuffDefence;
       public long addItemBuffMaxHp;
       public long addItemBuffMaxMp;

       public long addSkillSTR; // 스킬로 올라간 스텟 
       public long addSkillLUK;
       public long addSkillINT;
       public long addSkillHEL;
       public long addSkillHP;
       public long addSkillpMP;
       public long addSkillPower;
       public long addSkillDefence;
       public long addSkillMaxHp;
       public long addSkillMaxMp; */


    public bool isUseItemBuff;
    public string useItemBuffName;
    public float useItemBuffTime;
    public long useItemBuffAddSTR;
    public long useItemBuffAddLUK;
    public long useItemBuffAddINT;
    public long useItemBuffAddHEL;
    public long useItemBuffAddHP;
    public long useItemBuffAddMP;
    public long useItemBuffAddMagicPower;
    public long useItemBuffAddDefence;
    public long useItemBuffAddPower;
    public long useItemBuffAddMaxHP;
    public long useItemBuffAddMaxMP;


    public int basicAttackMultiple; //평타 데미지 배율 
    public int moveSpeed;   // 이동속도
    public int attackSpeed; // 공격속도 
    public int expMultiple;  // 경험치 배율 
    public int dropMultiple;  // 드랍 배율
    public int jumpForce; // 점프력

    public long huntMonster;  // 이제까지 플레이어가 몬스터를 몇 마리 잡았는지
    public long dieNumber; // 플레이어가 몇 번 죽었는지
    public long questingNumber; // 퀘스트를 몇 번 완료하였는지
    public long getExp; // 이제까지 경험치를 얼마나 획득하였는지 
    public long enhanceNumber; // 강화 몇 번 했는지
    public long rebrithNumber; // 환생 몇 번 했는지 



    public float expEventTime; // 경험치 버프가 얼마나 남았는지
    public float dropEventTime; // 드랍률 버프가 얼마나 남았는지 

    public bool isEquipWeapon;
    public bool isEquipShield;
    public bool isEquipHelmet;
    public bool isEquipArmor;
    public bool isEquipGlove;
    public bool isEquipShoes;
    public bool isEquipRing;
    public bool isEquipEarring;
    public bool isEquipNecklace; // 장비 장착 여부 

    public bool isAttack; // 공격중인지  
    public bool isDameged;  // 맞은 상태인지 

    public RaycastHit hitInfo;  // 레이캐스트 맞추면 반환되는곳 

    public bool lookRight; // 오른쪽을 바라보고 있는지 

    public string[] questing = new string[10];



    public bool isDie;

    public int skillLevel1_1;
    public int skillLevel1_2;
    public int skillLevel1_3;


    public int skillLevel2_1;
    public int skillLevel2_2;
    public int skillLevel2_3;
    public int skillLevel2_4;


    public int skillLevel3_1;
    public int skillLevel3_2;
    public int skillLevel3_3;
    public int skillLevel3_4;
    public int skillLevel3_5;

    public int skillLevel4_1;
    public int skillLevel4_2;
    public int skillLevel4_3;
    public int skillLevel4_4;
    public int skillLevel4_5; // 스킬레벨 
    public int skillLevel4_6;

    public long expRand;
    public long APRand;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


    private void Start()
    {
        isDie = false;

    }


    //경험치 얻으면 이 함수 호출 
    public void GetExp(long Exp)
    {
        // 현재 경험치에 얻은ㄴ 경험치를 더한다 
        currentExp += Exp;
        // 만약 요구 경험치보다 현재 경험치가 많아지면 렙업을 한다 
        if (currentExp >= needExp)
        {
            // 레벨이 10 이상이면 최대 요구 경험치는 10%씩 증가하고 
            if (Level >= 10)
            {

                maxNeedExp = (long)(maxNeedExp * 1.1);

            }
            // 10 이하이면 10씩 증가한다 
            else
            {
                maxNeedExp += 10;

            }

                // 현재 경험치에서 요구 경험치를 빼고 
                currentExp -= needExp;
                // 레벨업 하고 스텟포인트 랜덤 지급하고 요구 경험치를 랜덤 돌린다 
                needExp = (long)Random.Range(1, maxNeedExp);
                Level++;
                APRand = (long)Random.Range(1, 4);
                AP += APRand;
                //그리고 전직을 한 상태라면 스킬포인트 지급 
                if(thJob >= 1)
                 {
                SP++;
                }
                // 그리고 hp mp 최대치로 만들어주고 상태창 새로고침 
                HP = resultMaxHP;
                MP = resultMaxMP;
                UIManager.instance.statWindow.Refresh();
            UIManager.instance.playCanvas.LevelRefresh();
            UIManager.instance.player.LevelUpEffect();
            SoundManager.instance.SoundEffectOn("LevelUpSound", SoundManager.instance.soundEffectNumber);
        }

        // 경험치바 보이는 것은 새로고침해준다 
        UIManager.instance.playCanvas.ExpBarRefresh();


    }





    //저장 버튼을 누르면 호출 
    public void Save()
    {

        //모바일에서 실행할떄 파일 불러온다 
        if (UIManager.instance.environment == "Mobile")
        {
            streamWriter = new StreamWriter(new FileStream(Application.persistentDataPath + "/Load/Character" + characterNumber + "/CharacterInfo.txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(CharacterName + "`");
            streamWriter.Write(characterNumber + "`");
            streamWriter.Write(currentCity + "`");
            streamWriter.Write(currentPosition + "`");
            streamWriter.Write(job + "`");
            streamWriter.Write(thJob + "`");
            streamWriter.Write(Level + "`");
            streamWriter.Write(accumulateLevel + "`");
            streamWriter.Write(maxNeedExp + "`");
            streamWriter.Write(currentExp + "`");
            streamWriter.Write(needExp + "`");
            streamWriter.Write(rebirthReturnScrollUseNumber + "`");
            streamWriter.Write(story + "`");
            streamWriter.Write(rebirthAPStack + "`");
            streamWriter.Write(AP + "`");
            streamWriter.Write(SP + "`");
            streamWriter.Write(maxHP + "`");
            streamWriter.Write(maxMP + "`");
            streamWriter.Write(STR + "`");
            streamWriter.Write(HEL + "`");
            streamWriter.Write(INT + "`");
            streamWriter.Write(LUK + "`");
            streamWriter.Write(addSTR + "`");
            streamWriter.Write(addHEL + "`");
            streamWriter.Write(addINT + "`");
            streamWriter.Write(addLUK + "`");
            streamWriter.Write(addMaxHP + "`");
            streamWriter.Write(addMaxMP + "`");
            streamWriter.Write(addPower + "`");
            streamWriter.Write(addMagicPower + "`");
            streamWriter.Write(addDefence + "`");
            streamWriter.Write(isUseItemBuff + "`");
            streamWriter.Write(useItemBuffAddSTR + "`");
            streamWriter.Write(useItemBuffAddHEL + "`");
            streamWriter.Write(useItemBuffAddINT + "`");
            streamWriter.Write(useItemBuffAddLUK + "`");
            streamWriter.Write(useItemBuffAddMaxHP + "`");
            streamWriter.Write(useItemBuffAddMaxMP + "`");
            streamWriter.Write(useItemBuffAddPower + "`");
            streamWriter.Write(useItemBuffAddMagicPower + "`");
            streamWriter.Write(useItemBuffAddDefence + "`");
            streamWriter.Write(basicAttackMultiple + "`");
            streamWriter.Write(moveSpeed + "`");
            streamWriter.Write(jumpForce + "`");
            streamWriter.Write(attackSpeed + "`");
            streamWriter.Write(expMultiple + "`");
            streamWriter.Write(dropMultiple + "`");
            streamWriter.Write(huntMonster + "`");
            streamWriter.Write(dieNumber + "`");
            streamWriter.Write(questingNumber + "`");
            streamWriter.Write(getExp + "`");
            streamWriter.Write(enhanceNumber + "`");
            streamWriter.Write(rebrithNumber + "`");
            streamWriter.Write(isEquipWeapon + "`");
            streamWriter.Write(isEquipShield + "`");
            streamWriter.Write(isEquipHelmet + "`");
            streamWriter.Write(isEquipArmor + "`");
            streamWriter.Write(isEquipGlove + "`");
            streamWriter.Write(isEquipShoes + "`");
            streamWriter.Write(isEquipRing + "`");
            streamWriter.Write(isEquipEarring + "`");
            streamWriter.Write(isEquipNecklace + "`");
            streamWriter.Write(skillLevel1_1 + "`");
            streamWriter.Write(skillLevel1_2 + "`");
            streamWriter.Write(skillLevel1_3 + "`");
            streamWriter.Write(skillLevel2_1 + "`");
            streamWriter.Write(skillLevel2_2 + "`");
            streamWriter.Write(skillLevel2_3 + "`");
            streamWriter.Write(skillLevel2_4 + "`");
            streamWriter.Write(skillLevel3_1 + "`");
            streamWriter.Write(skillLevel3_2 + "`");
            streamWriter.Write(skillLevel3_3 + "`");
            streamWriter.Write(skillLevel3_4 + "`");
            streamWriter.Write(skillLevel3_5 + "`");
            streamWriter.Write(skillLevel4_1 + "`");
            streamWriter.Write(skillLevel4_2 + "`");
            streamWriter.Write(skillLevel4_3 + "`");
            streamWriter.Write(skillLevel4_4 + "`");
            streamWriter.Write(skillLevel4_5 + "`");
            streamWriter.Write(skillLevel4_6 + "`");
            streamWriter.Write(helpPanelVisible +"`");  // 도움말 패널 켜져있는지
            streamWriter.Write(questingPanelVisible + "`"); // 퀘스트 진행패널 켜져있는지 
            streamWriter.Close();
        }
        else
        {
            streamWriter = new StreamWriter(new FileStream("Assets/Resources/Load/Character" + characterNumber + "/CharacterInfo.txt", FileMode.Create, FileAccess.Write));
            streamWriter.Write(CharacterName + "`");
            streamWriter.Write(characterNumber + "`");
            streamWriter.Write(currentCity + "`");
            streamWriter.Write(currentPosition + "`");
            streamWriter.Write(job + "`");
            streamWriter.Write(thJob + "`");
            streamWriter.Write(Level + "`");
            streamWriter.Write(accumulateLevel + "`");
            streamWriter.Write(maxNeedExp + "`");
            streamWriter.Write(currentExp + "`");
            streamWriter.Write(needExp + "`");
            streamWriter.Write(rebirthReturnScrollUseNumber + "`");
            streamWriter.Write(story + "`");
            streamWriter.Write(rebirthAPStack + "`");
            streamWriter.Write(AP + "`");
            streamWriter.Write(SP + "`");
            streamWriter.Write(maxHP + "`");
            streamWriter.Write(maxMP + "`");
            streamWriter.Write(STR + "`");
            streamWriter.Write(HEL + "`");
            streamWriter.Write(INT + "`");
            streamWriter.Write(LUK + "`");
            streamWriter.Write(addSTR + "`");
            streamWriter.Write(addHEL + "`");
            streamWriter.Write(addINT + "`");
            streamWriter.Write(addLUK + "`");
            streamWriter.Write(addMaxHP + "`");
            streamWriter.Write(addMaxMP + "`");
            streamWriter.Write(addPower + "`");
            streamWriter.Write(addMagicPower + "`");
            streamWriter.Write(addDefence + "`");
            streamWriter.Write(isUseItemBuff + "`");
            streamWriter.Write(useItemBuffAddSTR + "`");
            streamWriter.Write(useItemBuffAddHEL + "`");
            streamWriter.Write(useItemBuffAddINT + "`");
            streamWriter.Write(useItemBuffAddLUK + "`");
            streamWriter.Write(useItemBuffAddMaxHP + "`");
            streamWriter.Write(useItemBuffAddMaxMP + "`");
            streamWriter.Write(useItemBuffAddPower + "`");
            streamWriter.Write(useItemBuffAddMagicPower + "`");
            streamWriter.Write(useItemBuffAddDefence + "`");
            streamWriter.Write(basicAttackMultiple + "`");
            streamWriter.Write(moveSpeed + "`");
            streamWriter.Write(jumpForce + "`");
            streamWriter.Write(attackSpeed + "`");
            streamWriter.Write(expMultiple + "`");
            streamWriter.Write(dropMultiple + "`");
            streamWriter.Write(huntMonster + "`");
            streamWriter.Write(dieNumber + "`");
            streamWriter.Write(questingNumber + "`");
            streamWriter.Write(getExp + "`");
            streamWriter.Write(enhanceNumber + "`");
            streamWriter.Write(rebrithNumber + "`");
            streamWriter.Write(isEquipWeapon + "`");
            streamWriter.Write(isEquipShield + "`");
            streamWriter.Write(isEquipHelmet + "`");
            streamWriter.Write(isEquipArmor + "`");
            streamWriter.Write(isEquipGlove + "`");
            streamWriter.Write(isEquipShoes + "`");
            streamWriter.Write(isEquipRing + "`");
            streamWriter.Write(isEquipEarring + "`");
            streamWriter.Write(isEquipNecklace + "`");
            streamWriter.Write(skillLevel1_1 + "`");
            streamWriter.Write(skillLevel1_2 + "`");
            streamWriter.Write(skillLevel1_3 + "`");
            streamWriter.Write(skillLevel2_1 + "`");
            streamWriter.Write(skillLevel2_2 + "`");
            streamWriter.Write(skillLevel2_3 + "`");
            streamWriter.Write(skillLevel2_4 + "`");
            streamWriter.Write(skillLevel3_1 + "`");
            streamWriter.Write(skillLevel3_2 + "`");
            streamWriter.Write(skillLevel3_3 + "`");
            streamWriter.Write(skillLevel3_4 + "`");
            streamWriter.Write(skillLevel3_5 + "`");
            streamWriter.Write(skillLevel4_1 + "`");
            streamWriter.Write(skillLevel4_2 + "`");
            streamWriter.Write(skillLevel4_3 + "`");
            streamWriter.Write(skillLevel4_4 + "`");
            streamWriter.Write(skillLevel4_5 + "`");
            streamWriter.Write(skillLevel4_6 + "`");
            streamWriter.Write(helpPanelVisible + "`");  // 도움말 패널 켜져있는지
            streamWriter.Write(questingPanelVisible + "`"); // 퀘스트 진행패널 켜져있는지 
            streamWriter.Close();




        }


        }






    //게임을 시작하면 이 함수를 호출해서 파일에 있는 정보를 불러온다 
    public void GameStart(int selectSlot)
    {


        //모바일에서 실행할떄 파일 불러온다 
        if (UIManager.instance.environment == "Mobile")
        {
            streamReader = new StreamReader(new FileStream(Application.persistentDataPath + "/Load/Character" + selectSlot + "/CharacterInfo.txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            CharacterName = s.Split('`')[0];
            int.TryParse(s.Split('`')[1], out characterNumber);
            currentCity = s.Split('`')[2];
            currentPosition = s.Split('`')[3];
            job = s.Split('`')[4];
            int.TryParse(s.Split('`')[5], out thJob);
            int.TryParse(s.Split('`')[6], out Level);
            int.TryParse(s.Split('`')[7], out accumulateLevel);
            long.TryParse(s.Split('`')[8], out maxNeedExp);
            long.TryParse(s.Split('`')[9], out currentExp);
            long.TryParse(s.Split('`')[10], out needExp);
            int.TryParse(s.Split('`')[11], out rebirthReturnScrollUseNumber);
            int.TryParse(s.Split('`')[12], out story);
            long.TryParse(s.Split('`')[13], out rebirthAPStack);
            long.TryParse(s.Split('`')[14], out AP);
            long.TryParse(s.Split('`')[15], out SP);
            long.TryParse(s.Split('`')[16], out maxHP);
            long.TryParse(s.Split('`')[17], out maxMP);
            long.TryParse(s.Split('`')[18], out STR);
            long.TryParse(s.Split('`')[19], out HEL);
            long.TryParse(s.Split('`')[20], out INT);
            long.TryParse(s.Split('`')[21], out LUK);
            long.TryParse(s.Split('`')[22], out addSTR);
            long.TryParse(s.Split('`')[23], out addHEL);
            long.TryParse(s.Split('`')[24], out addINT);
            long.TryParse(s.Split('`')[25], out addLUK);
            long.TryParse(s.Split('`')[26], out addMaxHP);
            long.TryParse(s.Split('`')[27], out addMaxMP);
            long.TryParse(s.Split('`')[28], out addPower);
            long.TryParse(s.Split('`')[29], out addMagicPower);
            long.TryParse(s.Split('`')[30], out addDefence);
            bool.TryParse(s.Split('`')[31], out isUseItemBuff);
            long.TryParse(s.Split('`')[32], out useItemBuffAddSTR);
            long.TryParse(s.Split('`')[33], out useItemBuffAddHEL);
            long.TryParse(s.Split('`')[34], out useItemBuffAddINT);
            long.TryParse(s.Split('`')[35], out useItemBuffAddLUK);
            long.TryParse(s.Split('`')[36], out useItemBuffAddMaxHP);
            long.TryParse(s.Split('`')[37], out useItemBuffAddMaxMP);
            long.TryParse(s.Split('`')[38], out useItemBuffAddPower);
            long.TryParse(s.Split('`')[39], out useItemBuffAddMagicPower);
            long.TryParse(s.Split('`')[40], out useItemBuffAddDefence);
            int.TryParse(s.Split('`')[41], out basicAttackMultiple);
            int.TryParse(s.Split('`')[42], out moveSpeed);
            int.TryParse(s.Split('`')[43], out jumpForce);
            int.TryParse(s.Split('`')[44], out attackSpeed);
            int.TryParse(s.Split('`')[45], out expMultiple);
            int.TryParse(s.Split('`')[46], out dropMultiple);
            long.TryParse(s.Split('`')[47], out huntMonster);
            long.TryParse(s.Split('`')[48], out dieNumber);
            long.TryParse(s.Split('`')[49], out questingNumber);
            long.TryParse(s.Split('`')[50], out getExp);
            long.TryParse(s.Split('`')[51], out enhanceNumber);
            long.TryParse(s.Split('`')[52], out rebrithNumber);
            bool.TryParse(s.Split('`')[53], out isEquipWeapon);
            bool.TryParse(s.Split('`')[54], out isEquipShield);
            bool.TryParse(s.Split('`')[55], out isEquipHelmet);
            bool.TryParse(s.Split('`')[56], out isEquipArmor);
            bool.TryParse(s.Split('`')[57], out isEquipGlove);
            bool.TryParse(s.Split('`')[58], out isEquipShoes);
            bool.TryParse(s.Split('`')[59], out isEquipRing);
            bool.TryParse(s.Split('`')[60], out isEquipEarring);
            bool.TryParse(s.Split('`')[61], out isEquipNecklace);
            int.TryParse(s.Split('`')[62], out skillLevel1_1);
            int.TryParse(s.Split('`')[63], out skillLevel1_2);
            int.TryParse(s.Split('`')[64], out skillLevel1_3);
            int.TryParse(s.Split('`')[65], out skillLevel2_1);
            int.TryParse(s.Split('`')[66], out skillLevel2_2);
            int.TryParse(s.Split('`')[67], out skillLevel2_3);
            int.TryParse(s.Split('`')[68], out skillLevel2_4);
            int.TryParse(s.Split('`')[69], out skillLevel3_1);
            int.TryParse(s.Split('`')[70], out skillLevel3_2);
            int.TryParse(s.Split('`')[71], out skillLevel3_3);
            int.TryParse(s.Split('`')[72], out skillLevel3_4);
            int.TryParse(s.Split('`')[73], out skillLevel3_5);
            int.TryParse(s.Split('`')[74], out skillLevel4_1);
            int.TryParse(s.Split('`')[75], out skillLevel4_2);
            int.TryParse(s.Split('`')[76], out skillLevel4_3);
            int.TryParse(s.Split('`')[77], out skillLevel4_4);
            int.TryParse(s.Split('`')[78], out skillLevel4_5);
            int.TryParse(s.Split('`')[79], out skillLevel4_6);
            bool.TryParse(s.Split('`')[80], out helpPanelVisible);
            bool.TryParse(s.Split('`')[81], out questingPanelVisible);
            streamReader.Close();




        }


        // PC에서 게임을 시작할 떄 파일을 불러온다 
        else
        {


            streamReader = new StreamReader(new FileStream("Assets/Resources/Load/Character" + selectSlot + "/CharacterInfo.txt", FileMode.Open, FileAccess.Read));
            s = streamReader.ReadLine();
            CharacterName = s.Split('`')[0];
            int.TryParse(s.Split('`')[1], out characterNumber);
            currentCity = s.Split('`')[2];
            currentPosition = s.Split('`')[3];
            job = s.Split('`')[4];
            int.TryParse(s.Split('`')[5], out thJob);
            int.TryParse(s.Split('`')[6], out Level);
            int.TryParse(s.Split('`')[7], out accumulateLevel);
            long.TryParse(s.Split('`')[8], out maxNeedExp);
            long.TryParse(s.Split('`')[9], out currentExp);
            long.TryParse(s.Split('`')[10], out needExp);
            int.TryParse(s.Split('`')[11], out rebirthReturnScrollUseNumber);
            int.TryParse(s.Split('`')[12], out story);
            long.TryParse(s.Split('`')[13], out rebirthAPStack);
            long.TryParse(s.Split('`')[14], out AP);
            long.TryParse(s.Split('`')[15], out SP);
            long.TryParse(s.Split('`')[16], out maxHP);
            long.TryParse(s.Split('`')[17], out maxMP);
            long.TryParse(s.Split('`')[18], out STR);
            long.TryParse(s.Split('`')[19], out HEL);
            long.TryParse(s.Split('`')[20], out INT);
            long.TryParse(s.Split('`')[21], out LUK);
            long.TryParse(s.Split('`')[22], out addSTR);
            long.TryParse(s.Split('`')[23], out addHEL);
            long.TryParse(s.Split('`')[24], out addINT);
            long.TryParse(s.Split('`')[25], out addLUK);
            long.TryParse(s.Split('`')[26], out addMaxHP);
            long.TryParse(s.Split('`')[27], out addMaxMP);
            long.TryParse(s.Split('`')[28], out addPower);
            long.TryParse(s.Split('`')[29], out addMagicPower);
            long.TryParse(s.Split('`')[30], out addDefence);
            bool.TryParse(s.Split('`')[31], out isUseItemBuff);
            long.TryParse(s.Split('`')[32], out useItemBuffAddSTR);
            long.TryParse(s.Split('`')[33], out useItemBuffAddHEL);
            long.TryParse(s.Split('`')[34], out useItemBuffAddINT);
            long.TryParse(s.Split('`')[35], out useItemBuffAddLUK);
            long.TryParse(s.Split('`')[36], out useItemBuffAddMaxHP);
            long.TryParse(s.Split('`')[37], out useItemBuffAddMaxMP);
            long.TryParse(s.Split('`')[38], out useItemBuffAddPower);
            long.TryParse(s.Split('`')[39], out useItemBuffAddMagicPower);
            long.TryParse(s.Split('`')[40], out useItemBuffAddDefence);
            int.TryParse(s.Split('`')[41], out basicAttackMultiple);
            int.TryParse(s.Split('`')[42], out moveSpeed);
            int.TryParse(s.Split('`')[43], out jumpForce);
            int.TryParse(s.Split('`')[44], out attackSpeed);
            int.TryParse(s.Split('`')[45], out expMultiple);
            int.TryParse(s.Split('`')[46], out dropMultiple);
            long.TryParse(s.Split('`')[47], out huntMonster);
            long.TryParse(s.Split('`')[48], out dieNumber);
            long.TryParse(s.Split('`')[49], out questingNumber);
            long.TryParse(s.Split('`')[50], out getExp);
            long.TryParse(s.Split('`')[51], out enhanceNumber);
            long.TryParse(s.Split('`')[52], out rebrithNumber);
            bool.TryParse(s.Split('`')[53], out isEquipWeapon);
            bool.TryParse(s.Split('`')[54], out isEquipShield);
            bool.TryParse(s.Split('`')[55], out isEquipHelmet);
            bool.TryParse(s.Split('`')[56], out isEquipArmor);
            bool.TryParse(s.Split('`')[57], out isEquipGlove);
            bool.TryParse(s.Split('`')[58], out isEquipShoes);
            bool.TryParse(s.Split('`')[59], out isEquipRing);
            bool.TryParse(s.Split('`')[60], out isEquipEarring);
            bool.TryParse(s.Split('`')[61], out isEquipNecklace);
            int.TryParse(s.Split('`')[62], out skillLevel1_1);
            int.TryParse(s.Split('`')[63], out skillLevel1_2);
            int.TryParse(s.Split('`')[64], out skillLevel1_3);
            int.TryParse(s.Split('`')[65], out skillLevel2_1);
            int.TryParse(s.Split('`')[66], out skillLevel2_2);
            int.TryParse(s.Split('`')[67], out skillLevel2_3);
            int.TryParse(s.Split('`')[68], out skillLevel2_4);
            int.TryParse(s.Split('`')[69], out skillLevel3_1);
            int.TryParse(s.Split('`')[70], out skillLevel3_2);
            int.TryParse(s.Split('`')[71], out skillLevel3_3);
            int.TryParse(s.Split('`')[72], out skillLevel3_4);
            int.TryParse(s.Split('`')[73], out skillLevel3_5);
            int.TryParse(s.Split('`')[74], out skillLevel4_1);
            int.TryParse(s.Split('`')[75], out skillLevel4_2);
            int.TryParse(s.Split('`')[76], out skillLevel4_3);
            int.TryParse(s.Split('`')[77], out skillLevel4_4);
            int.TryParse(s.Split('`')[78], out skillLevel4_5);
            int.TryParse(s.Split('`')[79], out skillLevel4_6);
            bool.TryParse(s.Split('`')[80], out helpPanelVisible);
            bool.TryParse(s.Split('`')[81], out questingPanelVisible);
            streamReader.Close();

        }


        // 버프 사용중이면 버프 사용을 false로 만들고 버프로 올라간 스텟을 뺀다 
        if (isUseItemBuff)
        {
            addSTR -= useItemBuffAddSTR;
            addHEL -= useItemBuffAddHEL;
            addINT -= useItemBuffAddINT;
            addLUK -= useItemBuffAddLUK;
            addMaxHP -= useItemBuffAddMaxHP;
            addMaxMP -= useItemBuffAddMaxMP;
            addPower -= useItemBuffAddPower;
            addMagicPower -= useItemBuffAddMagicPower;
            addDefence -= useItemBuffAddDefence;
            isUseItemBuff = false;

        }
        if (!helpPanelVisible)
        {
            UIManager.instance.playCanvas.helpPanel.gameObject.SetActive(false);

        }


        UIManager.instance.statWindow.Refresh();


        HP = resultMaxHP;
        MP = resultMaxMP;
        UIManager.instance.playCanvas.ExpBarRefresh();
        UIManager.instance.playCanvas.HPBarRefresh();
        UIManager.instance.playCanvas.MPBarRefresh();
        UIManager.instance.playCanvas.LevelRefresh();
    }





    // 게임 시작할 때 버프 사용중이면 남은시간만큼 이 코루틴 실행 
    public IEnumerator BuffItemStayCheck(float buffTime)
    {

        yield return new WaitForSeconds(buffTime);
        addSTR -= useItemBuffAddSTR;
        addHEL -= useItemBuffAddHEL;
        addINT -= useItemBuffAddINT;
        addLUK -= useItemBuffAddLUK;
        addMaxHP -= useItemBuffAddMaxHP;
        addMaxMP -= useItemBuffAddMaxMP;
        addPower -= useItemBuffAddPower;
        addMagicPower -= useItemBuffAddMagicPower;
        addDefence -= useItemBuffAddDefence;
        useItemBuffName = "null";
        useItemBuffTime = 0;
        useItemBuffAddSTR = 0;
        useItemBuffAddHEL = 0;
        useItemBuffAddINT = 0;
        useItemBuffAddLUK = 0;
        useItemBuffAddMaxHP = 0;
        useItemBuffAddMaxMP = 0;
        useItemBuffAddPower = 0;
        useItemBuffAddMagicPower = 0;
        useItemBuffAddDefence = 0;
        isUseItemBuff = false;
}









}
