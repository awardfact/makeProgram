using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hans : MonoBehaviour
{

    public string name; // NPC이름

    public string NPCSay; // NPC대화
    public bool shopAvailable; // NPC가 상점이 있는지
    public bool questAvailable;  // NPC가 퀘스트가 있는지 
    public bool enhanceAvailable; //NPC가 강화가 있는지 
    public bool rebirthAvailable;  // NPC가 환생 기능이 있는지 
    public bool warehouseAvailable;  //NPC가 창고 기능이 있는지 

    //여기부터 NPC가 파는 아이템 정보 
    public string[] sellItemName = new string[12];
    public string[] sellBigItemType = new string[12];
    public string[] sellSmallItemType = new string[12];
    public long[] sellPrice = new long[12];
    public string[] sellItemExplain = new string[12];
    public int[] sellQuantity = new int[12];
    public long[] sellMaxAddHP = new long[12];
    public long[] sellMaxAddMP = new long[12];
    public long[] sellMaxAddMaxMP = new long[12];
    public long[] sellMaxAddMaxHP = new long[12];
    public long[] sellMaxAddSTR = new long[12];
    public long[] sellMaxAddHEL = new long[12];
    public long[] sellMaxAddINT = new long[12];
    public long[] sellMaxAddLUK = new long[12];
    public long[] sellMaxAddPower = new long[12];
    public long[] sellMaxAddMagicPower = new long[12];
    public long[] sellMaxAddDefence = new long[12];
    public float[] sellCoolTime = new float[12];
    public float[] sellStayTime = new float[12];
    public long[] sellAddMaxHP = new long[12];
    public long[] sellAddMaxMP = new long[12];
    public long[] sellAddSTR = new long[12];
    public long[] sellAddHEL = new long[12];
    public long[] sellAddINT = new long[12];
    public long[] sellAddLUK = new long[12];
    public long[] sellAddPower = new long[12];
    public long[] sellAddMagicPower = new long[12];
    public long[] sellAddDefence = new long[12];
    public long[] sellRequireAccumulateLevel = new long[12];
    public long[] sellRequireLevel = new long[12];
    public long[] sellRequireSTR = new long[12];
    public long[] sellRequireHEL = new long[12];
    public long[] sellRequireINT = new long[12];
    public long[] sellRequireLUK = new long[12];
    public int[] sellEnhanceLevel = new int[12];
    public int[] sellEnhanceStack = new int[12];
    public bool[] sellSharePosiible = new bool[12];

    // 여기부터 퀘스트 정보 
    public string[] questName = new string[12];   //퀘스트 이름 
    public string[] questType = new string[12]; // 퀘스트 타입 반복 스토리 1회성인지 
    public string[] questKind =  new string[12];//퀘스트 종류  (NPC이동 몬스터 사냥 , 아이템 획득)
    public string[,] questExplain = new string[12,12];// 퀘스트 설명 
    public string[] questNpc =  new string[12]; // 퀘스트 엔피시 

    public int[] thStroy = new int[12]; // 스토리퀘일 경우 몇번쨰 스토리 퀘스트인지 (1번부터 시작)

    public long[] questRewardExp = new long[12];  // 퀘스트 경험치보상
    public long[] questRewardMoney = new long[12]; // 퀘스트 돈 보상
    public string[] questRewardItemName = new string[12]; // 퀘스트 보상 아이템 

    public bool[] questState = new bool[12]; // 퀘스트 상태 true면 완료된 상태 


    public string[] needItemName = new string[12]; // 퀘스트 완료조건 아이템 
    public string[] needMeetingNPC = new string[12]; // 퀘스트 완료조건 NPC
    public bool[] meetingNpcFinish = new bool[12];    // 퀘스트 완료조건 NPC만났는지 
    public string[] needHuntingMonsterName = new string[12]; // 퀘스트 완료조건 몬스터 
    public int[] needItemNumber = new int [12]; // 퀘스트 완료조건 아이템 숫자 
    public int[] needHuntingNumber = new int[12]; // 퀘스트 완료조건 몬스터 숫자 
    public int[] currentCollecITemNumber = new int[12]; // 현재 모은 아이템  
    public int[] currentHuntingMonsterNumber = new int[12]; //현재 잡은 몬스터 

    //보상 아이템 정보 
    public string[] questItemBigItemType = new string[12];
    public string[] questItemSmallItemType = new string[12];
    public long[] questItemPrice = new long[12];
    public string[] questItemExplain = new string[12];
    public int[] QuestItemQuantity = new int[12];

    public int[] questRequireLevel = new int[12];  // 퀘스트 시작 조건 레벨 
    public int[] questRequireAccmulateLevel = new int[12]; // 퀘스트 시작 조건 누적레벨 

    public long[] questItemMaxAddHP = new long[12];    // 사용시 올라가는 체력 최대치
    public long[] questItemMaxAddMP = new long[12];   //  사용시 올라가는 마나 최대치 

    public long[] questItemMaxAddMaxMP = new long[12];   // 사용시 올라가는 최대 체력 최대치( 올라가는 옵션이 최대 체력이고 사용했을때 랜덤으로 수치가 증가하는데 증가 수치 중 최대치가 이 변수)
    public long[] questItemMaxAddMaxHP = new long[12]; // 사용시 올라가는 최대 마나 최대치(BUFF) 
    public long[] questItemMaxAddSTR = new long[12]; //  사용시 올라가는 STR스텟 최대치(BUff)
    public long[] questItemMaxAddHEL = new long[12];  // 사용시 올라가는 Hel스텟 최대치(BUFF)
    public long[] questItemMaxAddINT = new long[12];  // 사용시 올라가는 INt스텟 최대치(BUFF)
    public long[] questItemMaxAddLUK = new long[12]; // 사용시 올라가는 LUk스텟 최대치(BUFF)
    public long[] questItemMxAddPower = new long[12];
    public long[] questItemMaxAddMagicPower = new long[12];
    public long[] questItemMaxAddDefence = new long[12];

    public float[] questItemCoolTime = new float[12];  // 소비 아이템일떄 쿨타임
    public float[] questItemStayTime = new float[12];  //버프 아이템일때 지속시간


    public long[] questItemAddMaxHP = new long[12];  // 장착시 올라가는 최대체력
    public long[] questItemAddMaxMP = new long[12]; // 장착시 올라가는 최대마나
    public long[] questItemAddSTR = new long[12];  // 장착시 올라가는 Str스텟
    public long[] questItemAddHEL= new long[12];  // 장착시 올라가는 hel스텟
    public long[] questItemAddINT = new long[12];  //장착시 올라가는 int스텟
    public long[] questItemAddLUK = new long[12];  // 장착시 올라가는luck스텟
    public long[] questItemAddPower = new long[12];
    public long[] questItemAdMagicPower = new long[12];
    public long[] questItemAddDefence = new long[12]; 


    //장착아이템일경우 착용조건 
    public long[] questItemRequireAccumulateLevel = new long[12];
    public long[] questItemRequireLevel = new long[12];
    public long[] questItemRequireSTR = new long[12];
    public long[] questItemRequireHEL = new long[12];
    public long[] questItemRequireINT = new long[12];
    public long[] questItemRequireLUK = new long[12];

    public int[] questItemEnhanceLevel = new int[12];
    public int[] questItemEnhanceStack = new int[12];

    public bool[] questItemSharePosiible = new bool[12]; //보상 아이템 계정공유 가능한지 가능 = true;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            questName[i] = "null";
            sellItemName[i] = "null";
            for (int j = 0; j < 12; j++)
                questExplain[i, j] = "null";
        }


        name = "한스";
        NPCSay = "처음보는 얼굴이군!";
        shopAvailable = true;
        questAvailable = true;
        enhanceAvailable = true;
        rebirthAvailable = true;
        warehouseAvailable = false;
        //파는 아이템 1
        sellItemName[0] = "나무 칼";
        sellBigItemType[0] = "Equipment";
        sellSmallItemType[0] = "Weapon";
        sellPrice[0] = 2500;
        sellItemExplain[0] ="어릴 때 가지고 놀던 장난감 칼";
        sellQuantity[0] = 1;
        sellAddMaxHP[0] = 0;
        sellAddMaxMP[0] = 0;
        sellAddSTR[0] = 2;
        sellAddHEL[0] = 0;
        sellAddINT[0] = 0;
        sellAddLUK[0] = 0;
        sellAddPower[0] = 2;
        sellAddMagicPower[0] = 0;
        sellAddDefence[0] = 0;
        sellRequireAccumulateLevel[0] = 0;
        sellRequireLevel[0] = 1;
        sellRequireSTR[0] = 0;
        sellRequireHEL[0] = 0;
        sellRequireINT[0] = 0;
        sellRequireLUK[0] = 0;
        sellEnhanceLevel[0] = 0;
        sellEnhanceStack[0] = 0;
        sellSharePosiible[0] = true;

        //파튼 아이템 2
        sellItemName[1] = "누더기 옷";
        sellBigItemType[1] = "Equipment";
        sellSmallItemType[1] = "Armor";
        sellPrice[1] = 2500;
        sellItemExplain[1] = "체온 유지하기엔 쓸만하다";
        sellQuantity[1] = 1;
        sellAddMaxHP[1] = 12;
        sellAddMaxMP[1] = 0;
        sellAddSTR[1] = 1;
        sellAddHEL[1] = 0;
        sellAddINT[1] = 0;
        sellAddLUK[1] = 0;
        sellAddPower[1] = 0;
        sellAddMagicPower[1] = 0;
        sellAddDefence[1] = 1;
        sellRequireAccumulateLevel[1] = 0;
        sellRequireLevel[1] = 1;
        sellRequireSTR[1] = 0;
        sellRequireHEL[1] = 0;
        sellRequireINT[1] = 0;
        sellRequireLUK[1] = 0;
        sellEnhanceLevel[1] = 0;
        sellEnhanceStack[1] = 0;
        sellSharePosiible[1] = true;

        //파튼 아이템 3
        sellItemName[2] = "삼x슬리퍼";
        sellBigItemType[2] = "Equipment";
        sellSmallItemType[2] = "Shoes";
        sellPrice[2] = 2500;
        sellItemExplain[2] = "누구나 한번쯤 신어본 그 신발";
        sellQuantity[2] = 1;
        sellAddMaxHP[2] = 0;
        sellAddMaxMP[2] = 0;
        sellAddSTR[2] = 0;
        sellAddHEL[2] = 2;
        sellAddINT[2] = 0;
        sellAddLUK[2] = 0;
        sellAddPower[2] = 0;
        sellAddMagicPower[2] = 0;
        sellAddDefence[2] = 1;
        sellRequireAccumulateLevel[2] = 0;
        sellRequireLevel[2] = 1;
        sellRequireSTR[2] = 0;
        sellRequireHEL[2] = 0;
        sellRequireINT[2] = 0;
        sellRequireLUK[2] = 0;
        sellEnhanceLevel[2] = 0;
        sellEnhanceStack[2] = 0;
        sellSharePosiible[2] = true;

        //파튼 아이템 4
        sellItemName[3] = "파란 두건";
        sellBigItemType[3] = "Equipment";
        sellSmallItemType[3] = "Helmet";
        sellPrice[3] = 2500;
        sellItemExplain[3] = "상당히 이쁜 두건";
        sellQuantity[3] = 1;
        sellAddMaxHP[3] = 0;
        sellAddMaxMP[3] = 0;
        sellAddSTR[3] = 3;
        sellAddHEL[3] = 0;
        sellAddINT[3] = 0;
        sellAddLUK[3] = 0;
        sellAddPower[3] = 0;
        sellAddMagicPower[3] = 0;
        sellAddDefence[3] = 1;
        sellRequireAccumulateLevel[3] = 0;
        sellRequireLevel[3] = 1;
        sellRequireSTR[3] = 0;
        sellRequireHEL[3] = 0;
        sellRequireINT[3] = 0;
        sellRequireLUK[3] = 0;
        sellEnhanceLevel[3] = 0;
        sellEnhanceStack[3] = 0;
        sellSharePosiible[3] = true;

        //파튼 아이템 5
        sellItemName[4] = "허름한 방패";
        sellBigItemType[4] = "Equipment";
        sellSmallItemType[4] = "Shield";
        sellPrice[4] = 2500;
        sellItemExplain[4] = "약해보이지만 쓸만하다.";
        sellQuantity[4] = 1;
        sellAddMaxHP[4] = 0;
        sellAddMaxMP[4] = 0;
        sellAddSTR[4] = 0;
        sellAddHEL[4] = 2;
        sellAddINT[4] = 0;
        sellAddLUK[4] = 0;
        sellAddPower[4] = 0;
        sellAddMagicPower[4] = 0;
        sellAddDefence[4] = 1;
        sellRequireAccumulateLevel[4] = 0;
        sellRequireLevel[4] = 1;
        sellRequireSTR[4] = 0;
        sellRequireHEL[4] = 0;
        sellRequireINT[4] = 0;
        sellRequireLUK[4] = 0;
        sellEnhanceLevel[4] = 0;
        sellEnhanceStack[4] = 0;
        sellSharePosiible[4] = true;

        //파튼 아이템 6
        sellItemName[5] = "벙어리 장갑";
        sellBigItemType[5] = "Equipment";
        sellSmallItemType[5] = "Glove";
        sellPrice[5] = 2500;
        sellItemExplain[5] = "주먹과 보자기만 낼 수 있다는 전설의 아이템.";
        sellQuantity[5] = 1;
        sellAddMaxHP[5] = 0;
        sellAddMaxMP[5] = 0;
        sellAddSTR[5] = 1;
        sellAddHEL[5] = 0;
        sellAddINT[5] = 0;
        sellAddLUK[5] = 0;
        sellAddPower[5] = 1;
        sellAddMagicPower[5] = 0;
        sellAddDefence[5] = 0;
        sellRequireAccumulateLevel[5] = 0;
        sellRequireLevel[5] = 1;
        sellRequireSTR[5] = 0;
        sellRequireHEL[5] = 0;
        sellRequireINT[5] = 0;
        sellRequireLUK[5] = 0;
        sellEnhanceLevel[5] = 0;
        sellEnhanceStack[5] = 0;
        sellSharePosiible[5] = true;

        //파튼 아이템 7
        sellItemName[6] = "양파 이어링";
        sellBigItemType[6] = "Equipment";
        sellSmallItemType[6] = "Earring";
        sellPrice[6] = 2000;
        sellItemExplain[6] = "양파모양의 귀걸이다.";
        sellQuantity[6] = 1;
        sellAddMaxHP[6] = 0;
        sellAddMaxMP[6] = 0;
        sellAddSTR[6] = 3;
        sellAddHEL[6] = 0;
        sellAddINT[6] = 0;
        sellAddLUK[6] = 0;
        sellAddPower[6] = 0;
        sellAddMagicPower[6] = 0;
        sellAddDefence[6] = 0;
        sellRequireAccumulateLevel[6] = 0;
        sellRequireLevel[6] = 1;
        sellRequireSTR[6] = 0;
        sellRequireHEL[6] = 0;
        sellRequireINT[6] = 0;
        sellRequireLUK[6] = 0;
        sellEnhanceLevel[6] = 0;
        sellEnhanceStack[6] = 0;
        sellSharePosiible[6] = true;

        //파튼 아이템 8
        sellItemName[7] = "도금 반지";
        sellBigItemType[7] = "Equipment";
        sellSmallItemType[7] = "Ring";
        sellPrice[7] = 2000;
        sellItemExplain[7] = "딱봐도 저가의 도금이다.";
        sellQuantity[7] = 1;
        sellAddMaxHP[7] = 0;
        sellAddMaxMP[7] = 0;
        sellAddSTR[7] = 0;
        sellAddHEL[7] = 0;
        sellAddINT[7] = 3;
        sellAddLUK[7] = 0;
        sellAddPower[7] = 0;
        sellAddMagicPower[7] = 0;
        sellAddDefence[7] = 0;
        sellRequireAccumulateLevel[7] = 0;
        sellRequireLevel[7] = 1;
        sellRequireSTR[7] = 0;
        sellRequireHEL[7] = 0;
        sellRequireINT[7] = 0;
        sellRequireLUK[7] = 0;
        sellEnhanceLevel[7] = 0;
        sellEnhanceStack[7] = 0;
        sellSharePosiible[7] = true;


        //파튼 아이템 9
        sellItemName[8] = "토마토 목걸이";
        sellBigItemType[8] = "Equipment";
        sellSmallItemType[8] = "Necklace";
        sellPrice[8] = 2000;
        sellItemExplain[8] = "누가 만든지 모르는 이상한 목걸이";
        sellQuantity[8] = 1;
        sellAddMaxHP[8] = 0;
        sellAddMaxMP[8] = 0;
        sellAddSTR[8] = 0;
        sellAddHEL[8] = 0;
        sellAddINT[8] = 3;
        sellAddLUK[8] = 0;
        sellAddPower[8] = 0;
        sellAddMagicPower[8] = 0;
        sellAddDefence[8] = 0;
        sellRequireAccumulateLevel[8] = 0;
        sellRequireLevel[8] = 1;
        sellRequireSTR[8] = 0;
        sellRequireHEL[8] = 0;
        sellRequireINT[8] = 0;
        sellRequireLUK[8] = 0;
        sellEnhanceLevel[8] = 0;
        sellEnhanceStack[8] = 0;
        sellSharePosiible[8] = true;

        //파튼 아이템 10
        sellItemName[9] = "시든 꽃";
        sellBigItemType[9] = "Consume";
        sellSmallItemType[9] = "StaticPotion";
        sellPrice[9] = 50;
        sellItemExplain[9] = "시든 꽃의 꿀을 먹었더니 기력이 아주 조금 찬다.";
        sellQuantity[9] = 1;
        sellMaxAddHP[9] = 50;
        sellMaxAddMP[9] = 0;
        sellSharePosiible[9] = true;
        //파튼 아이템 11
        sellItemName[10] = "썩은 꽃";
        sellBigItemType[10] = "Consume";
        sellSmallItemType[10] = "StaticPotion";
        sellPrice[10] = 50;
        sellItemExplain[10] = "썩은 꽃의 꿀을 먹었더니 마나만 아주 조금 찬다.";
        sellQuantity[10] = 1;
        sellMaxAddHP[10] = 0;
        sellMaxAddMP[10] = 50;
        sellSharePosiible[10] = true;


        //파튼 아이템 12
        sellItemName[11] = "강화석";
        sellBigItemType[11] = "Etc";
        sellSmallItemType[11] = "Etc";
        sellPrice[11] = 400000;
        sellItemExplain[11] = "강화할 때 필요한 광석이다.";
        sellQuantity[11] = 1;
        sellSharePosiible[11] = true;

        questName[0] = "한스와의 대화";
        questType[0] = "Story";
        questKind[0] = "Meeting";
        questExplain[0, 0] = "만나서 반갑네 나의 구원자여 와프에 온 걸 환영하네";
        questExplain[0, 1] = "내 이름은 한스! 대 마법사지 ";
        questExplain[0, 2] = "응 ? 마법사가 왜 검을 들고 있냐교??";
        questExplain[0, 3] = "사실 내 스승님이 거대한 실험을 하다가 실패해서 세상이 뒤죽박죽으로 바뀌었거든....";
        questExplain[0, 4] = "그래서 스승님은 사형 당하시고 마법이 금지되었지.. ";
        questExplain[0, 5] = "하지만 나는 스승님의 유지에 따라 세상을 다시 돌려놓기 위해 새로운 마법을 연구했고 오늘 바로 자네를 불러왔다네 ";
        questExplain[0, 6] = "세계가 어떻게 변했길래 너를 불렀냐고?? ";
        questExplain[0, 7] = "말했다시피 완전히 뒤죽박죽이 되었지.. 모든게 랜덤으로 변했어.";
        questExplain[0, 8] = "최고의 사냥꾼이 토끼를 잡다가 토끼의 공격에 그대로 즉사했다고!";
        questExplain[0, 9] = "이런 세상에서 어떻게 싸우냐고?? 어차피 저런 경우는 10억번 하면 한번정도 터지는 확률이네";
        questExplain[0, 10] = "많이 혼란스러운 모양이군, 생각이 정리되면 다시 나에게 찾아오게.";
        questNpc[0] = "Hans";
        thStroy[0] = 0;
        questRewardExp[0] = 5;
        questRewardMoney[0] = 1000;
        questRewardItemName[0] = "나무 칼";
        questState[0] = false;
        needItemName[0] = "null";
        needMeetingNPC[0] = "Hans";
        meetingNpcFinish[0] = false;
        needHuntingMonsterName[0] = "null";
        needItemNumber[0] = 0;
        needHuntingNumber[0] = 0;
        currentCollecITemNumber[0] = 0;
        currentHuntingMonsterNumber[0] = 0;
        questItemBigItemType[0] = "Equipment";
        questItemSmallItemType[0] = "Weapon";
        questItemPrice[0] = 2500;
        questItemExplain[0] = "어릴 때 가지고 놀던 장난감 칼";
        QuestItemQuantity[0] = 1;
        questRequireLevel[0] = 1;
        questRequireAccmulateLevel[0] = 1;
        questItemAddMaxHP[0] = 0;
        questItemAddMaxMP[0] = 0;
        questItemAddSTR[0] = 2;
        questItemAddHEL[0] = 0;
        questItemAddINT[0] = 0;
        questItemAddLUK[0] = 0;
        questItemAddPower[0] = 2;
        questItemAdMagicPower[0] = 0;
        questItemAddDefence[0] = 0;
        questItemRequireAccumulateLevel[0] = 0;
        questItemRequireLevel[0] =0;
        questItemRequireSTR[0] = 0;
        questItemRequireHEL[0] = 0;
        questItemRequireINT[0] = 0;
        questItemRequireLUK[0] = 0;
        questItemEnhanceLevel[0] = 0;
        questItemEnhanceStack[0] = 5;
        questItemSharePosiible[0] = true;



        questName[1] = "한스의 시험";
        questType[1] = "Story";
        questKind[1] = "Hunting";
        questExplain[1, 0] = "생각 좀 정리했나??";
        questExplain[1, 1] = "그래! 잘 선택했네";
        questExplain[1, 2] = "일단 자네가 어느 정도 수준인지 확인을 하고 싶은데...";
        questExplain[1, 3] = "그래서 말인데 자네 혹시 3대 몇 치나??";
        questExplain[1, 4] = "갑자기 그런 건 왜 물어보냐고??";
        questExplain[1, 5] = "그쪽 세계에서 이게 강함을 판단하는 기준이라고 하던데 흠...";
        questExplain[1, 6] = "어쨌든 지금 자네 실력이 어느 정도인지 확인할 필요가 있네";
        questExplain[1, 7] = "조금만 나가면 젤리라는 몬스터가 있는데 그 몬스터를 1마리 잡아와주게";
        questExplain[1, 8] = "잡는 모습을 보고 내가 실력을 판단해 주지!";
        questNpc[1] = "Hans";
        thStroy[1] = 1;
        questRewardExp[1] = 10;
        questRewardMoney[1] = 3000;
        questRewardItemName[1] = "누더기 옷";
        questState[1] = false;
        needItemName[1] = "null";
        needMeetingNPC[1] = "null";
        meetingNpcFinish[1] = false;
        needHuntingMonsterName[1] = "Jelly";
        needItemNumber[1] = 0;
        needHuntingNumber[1] = 1;
        currentCollecITemNumber[1] = 0;
        currentHuntingMonsterNumber[1] = 0;
        questItemBigItemType[1] = "Equipment";
        questItemSmallItemType[1] = "Armor";
        questItemPrice[1] = 2500;
        questItemExplain[1] = "체온 유지하기엔 쓸만하다";
        QuestItemQuantity[1] = 1;
        questRequireLevel[1] = 1;
        questRequireAccmulateLevel[1] = 1;
        questItemAddMaxHP[1] = 12;
        questItemAddMaxMP[1] = 0;
        questItemAddSTR[1] = 1;
        questItemAddHEL[1] = 0;
        questItemAddINT[1] = 0;
        questItemAddLUK[1] = 0;
        questItemAddPower[1] = 0;
        questItemAdMagicPower[1] = 0;
        questItemAddDefence[1] = 1;
        questItemRequireAccumulateLevel[1] = 1;
        questItemRequireLevel[1] = 0;
        questItemRequireSTR[1] = 0;
        questItemRequireHEL[1] = 0;
        questItemRequireINT[1] = 0;
        questItemRequireLUK[1] = 0;
        questItemEnhanceLevel[1] = 0;
        questItemEnhanceStack[1] = 5;
        questItemSharePosiible[1] = true;


        questName[2] = "한스의 시험2";
        questType[2] = "Story";
        questKind[2] = "Hunting";
        questExplain[2, 0] = "그래. 잡는 모습 잘 봤네..";
        questExplain[2, 1] = "근데 한 마리 잡는 거 지켜봐서는 어느 정도인지 정확히 알기가 힘들군";
        questExplain[2, 2] = "하지만 한 가지는 확실히 알겠네 자네 생각보다 많이 약하군!";
        questExplain[2, 3] = "몬스터가 강한 거 아니냐고??";
        questExplain[2, 4] = "그냥 자네가 심각하게 약한 거 같은데..";
        questExplain[2, 5] = "자네가 운이 없는 건 아니냐고?? 가능성이 낮긴 하지만 자네가 운이 없는 거일 수도 있긴 하지";
        questExplain[2, 6] = "그럼 젤리를 3마리 더 잡아오게!";
        questExplain[2, 7] = "그럼 운 때문인지 그냥 자네가 약한지 확실히 알 수 있겠지.";
        questNpc[2] = "Hans";
        thStroy[2] = 2;
        questRewardExp[2] = 30;
        questRewardMoney[2] = 5000;
        questRewardItemName[2] = "강화석";
        questState[2] = false;
        needItemName[2] = "null";
        needMeetingNPC[2] = "null";
        meetingNpcFinish[2] = false;
        needHuntingMonsterName[2] = "Jelly";
        needItemNumber[2] = 0;
        needHuntingNumber[2] = 3;
        currentCollecITemNumber[2] = 0;
        currentHuntingMonsterNumber[2] = 0;
        questItemBigItemType[2] = "Etc";
        questItemSmallItemType[2] = "Etc";
        questItemPrice[2] = 10000;
        questItemExplain[2] = "강화할 때 필요한 광석이다.";
        QuestItemQuantity[2] = 10;
        questItemSharePosiible[2] = false;


        questName[3] = "강화를 하자!";
        questType[3] = "Story";
        questKind[3] = "GetItem";
        questExplain[3, 0] = "이제 자네의 실력을 확실히 알겠네";
        questExplain[3, 1] = "자네 정말 심각하게 약하군.. ";
        questExplain[3, 2] = "어떻게 하면 강해질 수 있냐고???";
        questExplain[3, 3] = "여기서 강해지는 방법은 3가지가 있네 몬스터와 싸워서 강해지는 것, 좋은 아이템을 장착, 좋은 운";
        questExplain[3, 4] = "몬스터는 아까와 같이 잡으면 되고 운은 기도하는 거 밖에 방법이 없네";
        questExplain[3, 5] = "남은 방법인 좋은 아이템을 장착하기 위해서는 좋은 아이템이 있어야 하지 내가 좋은 아이템을 만드는 방법을 알려주겠네";
        questExplain[3, 6] = "우선 기본 옵션이 좋은 장비 아이템이 필요하네 같은 아이템을 얻어도 옵션이 다 다르기 때문에 기본 베이스가 좋은 아이템을 얻는 것이 중요하네";
        questExplain[3, 7] = "그리고 그 기본 옵션 좋은 아이템으로 강화를 하면 더욱 좋은 아이템을 얻을 수 있지 운만 좋다면 말이야 하하!";
        questExplain[3, 8] = "강화를 위해서는 우선 강화석이 필요하네 강화석은 아까 내가 줘서 있을 거야. 강화창에서 강화할 아이템을 올리고 강화를 누르면 강화 수치에 따라 일정 확률로 강화가 성공하거나 실패하지" +
            "성공하면 옵션에 따라 랜덤으로 옵션이 오르네, 강화 단계가 오를수록 옵션은 더 큰 폭으로 증가하지 하지만 실패하면 아이템이 파괴되니 신중하게 생각하고 강화를 해야 하네. ";
        questExplain[3, 9] = "하지만 걱정 말게 보호석이 있다면 강화가 실패해도 보호석만 소모되고 아이템은 파괴되지 않는다네 그리고 리턴 스크롤이라는 아이템이 있는데 그 아이템을 사용하면 강화가 성공했을 때 옵션이 마음에 들지 않으면 강화 전 상태로 되돌려주지";
        questExplain[3, 10] = "그리고 강화의 비약이라는 아주 구하기 힘든 아이템이 있는데 그것을 사용하면 강화 단계에 따라 강화 성공 확률을 일정량 올려주는 아이템이라네 그리고 이 아이템은 중첩이 가능하지.";
        questExplain[3, 11] = "강화에 대한 설명은 이쯤 하고 내가 준 나무 칼과 강화석을 가지고 +1나무 칼을 가져다주게 ";
        questNpc[3] = "Hans";
        thStroy[3] = 3;
        questRewardExp[3] = 30;
        questRewardMoney[3] = 10000;
        questRewardItemName[3] = "강화석";
        questState[3] = false;
        needItemName[3] = "+1 나무 칼";
        needMeetingNPC[3] = "null";
        meetingNpcFinish[3] = false;
        needHuntingMonsterName[3] = "null";
        needItemNumber[3] = 1;
        needHuntingNumber[3] = 0;
        currentCollecITemNumber[3] = 0;
        currentHuntingMonsterNumber[3] = 0;
        questItemBigItemType[3] = "Etc";
        questItemSmallItemType[3] = "Etc";
        questItemPrice[3] = 10000;
        questItemExplain[3] = "강화할 때 필요한 광석이다.";
        QuestItemQuantity[3] = 15;
        questItemSharePosiible[3] = false;


        questName[4] = "강화를 하자! 2";
        questType[4] = "Story";
        questKind[4] = "GetItem";
        questExplain[4, 0] = "좋아! 훌륭하진 않지만 자네에게는 아주 훌륭한 검이 되었군!";
        questExplain[4, 1] = "이제 강화를 어떻게 하는지 조금 알겠지??";
        questExplain[4, 2] = "이번엔 내가 준 누더기 옷을 한번 강화 해보게";
        questExplain[4, 3] = "보상으로 보호석을 주겠네.";
        questExplain[4, 4] = "실패하면 어떡하냐고? 그건 내 알 바 아니지 ㅋ";
        questNpc[4] = "Hans";
        thStroy[4] = 4;
        questRewardExp[4] = 30;
        questRewardMoney[4] = 10000;
        questRewardItemName[4] = "보호석";
        questState[4] = false;
        needItemName[4] = "+1 누더기 옷";
        needMeetingNPC[4] = "null";
        meetingNpcFinish[4] = false;
        needHuntingMonsterName[4] = "null";
        needItemNumber[4] = 1;
        needHuntingNumber[4] = 0;
        currentCollecITemNumber[4] = 0;
        currentHuntingMonsterNumber[4] = 0;
        questItemBigItemType[4] = "Etc";
        questItemSmallItemType[4] = "Etc";
        questItemPrice[4] = 10000;
        questItemExplain[4] = "장비의 파괴를 보호해주는 보석이다.";
        QuestItemQuantity[4] = 10;
        questItemSharePosiible[4] = false;


        questName[5] = "젤리는 껌이지!";
        questType[5] = "Story";
        questKind[5] = "Hunting";
        questExplain[5, 0] = "이제 장비도 어느정도 갖춰진 것 같군!";
        questExplain[5, 1] = "그 장비를 가지고 젤리를 잡아보게";
        questExplain[5, 2] = "전과는 확실히 달라진 걸 느낄 수 있을 걸세";
        questExplain[5, 3] = "젤리 10마리 정도면 되겠군!";
        questNpc[5] = "Hans";
        thStroy[5] = 5;
        questRewardExp[5] = 100;
        questRewardMoney[5] = 50000;
        questRewardItemName[5] = "리턴 스크롤(강화)";
        questState[5] = false;
        needItemName[5] = "null";
        needMeetingNPC[5] = "null";
        meetingNpcFinish[5] = false;
        needHuntingMonsterName[5] = "Jelly";
        needItemNumber[5] = 0;
        needHuntingNumber[5] = 10;
        currentCollecITemNumber[5] = 0;
        currentHuntingMonsterNumber[5] = 0;
        questItemBigItemType[5] = "Etc";
        questItemSmallItemType[5] = "Etc";
        questItemPrice[5] = 10000;
        questItemExplain[5] = "강화가 성공했을 때 성공하기 전으로 되돌릴 수 있는 아이템";
        QuestItemQuantity[5] = 10;
        questItemSharePosiible[5] = false;

        questName[6] = "헤르비아로!";
        questType[6] = "Story";
        questKind[6] = "Meeting";
        questExplain[6, 0] = "이제 젤리정도는 씹어먹고 다니는군!";
        questExplain[6, 1] = "슬슬 더 큰 세상으로 갈 떄가 된거같네";
        questExplain[6, 2] = "나는 먼저 워프를 타고 와프 동쪽에 위치한 헤르비아로 가있겠네";
        questExplain[6, 3] = "자네는 젤리나 씹으면서 천천히 오라고!";
        questExplain[6, 4] = "헤르비아는 여기서 위로 쭉 올라가면 나오는 포탈을 타고 갈 수 있네.";
        questExplain[6, 5] = "아! 마을에서는 가명을 쓰고 있으니 Hans말고 Shan으로 찾아오게";
        questNpc[6] = "Hans";
        thStroy[6] = 6;
        questRewardExp[6] = 50;
        questRewardMoney[6] = 10000;
        questRewardItemName[6] = "리턴 스크롤(환생)";
        questState[6] = false;
        needItemName[6] = "null";
        needMeetingNPC[6] = "shan";
        meetingNpcFinish[6] = false;
        needHuntingMonsterName[6] = "null";
        needItemNumber[6] = 0;
        needHuntingNumber[6] = 0;
        currentCollecITemNumber[6] = 0;
        currentHuntingMonsterNumber[6] = 0;
        questItemBigItemType[6] = "Etc";
        questItemSmallItemType[6] = "Etc";
        questItemPrice[6] = 10000;
        questItemExplain[6] = "환생 이전으로 되돌려주는 아이템";
        QuestItemQuantity[6] = 10;
        questItemSharePosiible[6] = false;




        questName[7] = "젤리 가죽은 무슨 맛?!";
        questType[7] = "Loop";
        questKind[7] = "GetItem";
        questExplain[7, 0] = "입이 심심하군.";
        questExplain[7, 1] = "이럴 땐 젤리 가죽을 먹으면 딱인데....";
        questExplain[7, 2] = "뭐지? 그 젤리 가죽 나오면 혼자 먹을 거 같은 표정은?";
        questExplain[7, 3] = "어차피 젤리 가죽에는 독이 있어서 자네 혼자서는 먹지도 못 해 ";
        questExplain[7, 4] = "나같은 대- 마법사가 정화를 써야 독이 중화되지 훗.";
        questExplain[7, 5] = "젤리가죽 3개를 가져다 주면 자네에게도 하나를 주겠네.";
        questNpc[7] = "Hans";
        thStroy[7] = -1;
        questRewardExp[7] = 50;
        questRewardMoney[7] = 10000;
        questRewardItemName[7] = "독이 없는 젤리 가죽";
        questState[7] = false;
        needItemName[7] = "젤리가죽";
        needMeetingNPC[7] = "null";
        meetingNpcFinish[7] = false;
        needHuntingMonsterName[7] = "null";
        needItemNumber[7] = 3;
        needHuntingNumber[7] = 0;
        currentCollecITemNumber[7] = 0;
        currentHuntingMonsterNumber[7] = 0;
        questItemBigItemType[7] = "Consume";
        questItemSmallItemType[7] = "StaticPotion";
        questItemPrice[7] = 500;
        questItemExplain[7] = "겉보기와는 다르게 큰꿈틀이 맛이 난다.";
        QuestItemQuantity[7] = 1;
        questItemSharePosiible[7] = true;
        questItemMaxAddHP[7] = 200;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //NPC콜라이더랑 붙은 상태에서 공격키를 누르면 대화 
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "User" && CharacterManager.instance.npcTalk)
        {

            UIManager.instance.questWindow.NPCTalk("한스");
            //NPC가 가지고 있는 기능과 정보를 넘긴다 
            UIManager.instance.npcTalkWindow.shopAvailable = shopAvailable;
            UIManager.instance.npcTalkWindow.questAvailable = questAvailable;
            UIManager.instance.npcTalkWindow.enhanceAvailable = enhanceAvailable;
            UIManager.instance.npcTalkWindow.rebirthAvailable = rebirthAvailable;
            UIManager.instance.npcTalkWindow.warehouseAvailable = warehouseAvailable;
            //기능이 없다면 그 기능 버튼이 비어있게 보인다 
            if (!shopAvailable)
            {
                UIManager.instance.npcTalkWindow.shopButton.image.color = new Color(1, 1, 1, 0);
                UIManager.instance.npcTalkWindow.shopText.text = "";
            }
            else
            {
                UIManager.instance.npcTalkWindow.shopButton.image.color = new Color(1, 1, 1, 1);
                UIManager.instance.npcTalkWindow.shopText.text = "상점";
            }


            if (!questAvailable)
            {
                UIManager.instance.npcTalkWindow.questButton.image.color = new Color(1, 1, 1, 0);
                UIManager.instance.npcTalkWindow.questText.text = "";
            }
            else
            {
                UIManager.instance.npcTalkWindow.questButton.image.color = new Color(1, 1, 1, 1);
                UIManager.instance.npcTalkWindow.questText.text = "퀘스트";
            }


            if (!enhanceAvailable)
            {
                UIManager.instance.npcTalkWindow.enhanceButton.image.color = new Color(1, 1, 1, 0);
                UIManager.instance.npcTalkWindow.enhanceText.text = "";
            }
            else
            {
                UIManager.instance.npcTalkWindow.enhanceButton.image.color = new Color(1, 1, 1, 1);
                UIManager.instance.npcTalkWindow.enhanceText.text = "강화";
            }


            if (!rebirthAvailable)
            {
                UIManager.instance.npcTalkWindow.rebirthButton.image.color = new Color(1, 1, 1, 0);
                UIManager.instance.npcTalkWindow.rebirthText.text = "";
            }
            else
            {
                UIManager.instance.npcTalkWindow.rebirthButton.image.color = new Color(1, 1, 1, 1);
                UIManager.instance.npcTalkWindow.rebirthText.text = "환생";
            }


            if (!warehouseAvailable)
            {
                UIManager.instance.npcTalkWindow.warehouseButton.image.color = new Color(1, 1, 1, 0);
                UIManager.instance.npcTalkWindow.warehouseText.text = "";
            }
            else
            {
                UIManager.instance.npcTalkWindow.warehouseButton.image.color = new Color(1, 1, 1, 1);
                UIManager.instance.npcTalkWindow.warehouseText.text = "창고";
            }
            UIManager.instance.questWindow.NPCTalk("Hans");
            UIManager.instance.npcQuestSlot[0].questName = "null";
            UIManager.instance.npcQuestSlot[0].questNameText.text = "";
            UIManager.instance.npcQuestSlot[1].questName = "null";
            UIManager.instance.npcQuestSlot[1].questNameText.text = "";
            UIManager.instance.npcQuestSlot[2].questName = "null";
            UIManager.instance.npcQuestSlot[2].questNameText.text = "";
            UIManager.instance.npcTalkWindow.npcTalkText.text = NPCSay;
            UIManager.instance.npcTalkWindow.npcNameText.text = name;




            // NPC의 퀘스트 요구조건을 충족하면 슬롯에 차례로 퀘스트 정보가 들어간다 
            for (int i = 0; i< 12; i++)
            {
                if(questName[i] != "null" && questRequireLevel[i] <= CharacterManager.instance.Level &&
                    questRequireAccmulateLevel[i] <= CharacterManager.instance.accumulateLevel)
                {
                    switch (questType[i])
                    {
                        case "Story" :
                            if(thStroy[i] == CharacterManager.instance.story)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    if (UIManager.instance.npcQuestSlot[j].questName == "null")
                                    {
                                        UIManager.instance.npcQuestSlot[j].questName = questName[i];
                                        UIManager.instance.npcQuestSlot[j].questType = questType[i];
                                        UIManager.instance.npcQuestSlot[j].questKind = questKind[i];
                                        for (int k = 0; k < 12; k++)
                                        {
                                            UIManager.instance.npcQuestSlot[j].questExplain[k] = questExplain[i, k];

                                        }


                                        UIManager.instance.npcQuestSlot[j].questNpc = questNpc[i];
                                        UIManager.instance.npcQuestSlot[j].thStroy = thStroy[i];
                                        UIManager.instance.npcQuestSlot[j].questRewardExp = questRewardExp[i];
                                        UIManager.instance.npcQuestSlot[j].questRewardMoney = questRewardMoney[i];
                                        UIManager.instance.npcQuestSlot[j].questRewardItemName = questRewardItemName[i];
                                        UIManager.instance.npcQuestSlot[j].questState = questState[i];
                                        UIManager.instance.npcQuestSlot[j].needItemName = needItemName[i];
                                        UIManager.instance.npcQuestSlot[j].needMeetingNPC = needMeetingNPC[i];
                                        UIManager.instance.npcQuestSlot[j].meetingNpcFinish = meetingNpcFinish[i];
                                        UIManager.instance.npcQuestSlot[j].needHuntingMonsterName = needHuntingMonsterName[i];
                                        UIManager.instance.npcQuestSlot[j].needItemNumber = needItemNumber[i];
                                        UIManager.instance.npcQuestSlot[j].needHuntingNumber = needHuntingNumber[i];
                                        UIManager.instance.npcQuestSlot[j].currentCollecITemNumber = currentCollecITemNumber[i];
                                        UIManager.instance.npcQuestSlot[j].currentHuntingMonsterNumber = currentHuntingMonsterNumber[i];
                                        UIManager.instance.npcQuestSlot[j].bigItemType = questItemBigItemType[i];
                                        UIManager.instance.npcQuestSlot[j].smallItemType = questItemSmallItemType[i];
                                        UIManager.instance.npcQuestSlot[j].price = questItemPrice[i];
                                        UIManager.instance.npcQuestSlot[j].itemExplain = questItemExplain[i];
                                        UIManager.instance.npcQuestSlot[j].quantity = QuestItemQuantity[i];
                                        UIManager.instance.npcQuestSlot[j].questRequireLevel = questRequireLevel[i];
                                        UIManager.instance.npcQuestSlot[j].questRequireAccmulateLevel = questRequireAccmulateLevel[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddHP = questItemMaxAddHP[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddMP = questItemMaxAddMP[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddMaxMP = questItemMaxAddMaxMP[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddMaxHP = questItemMaxAddMaxHP[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddSTR = questItemMaxAddSTR[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddHEL = questItemMaxAddHEL[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddINT = questItemMaxAddINT[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddLUK = questItemMaxAddLUK[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddPower = questItemMxAddPower[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddMagicPower = questItemMaxAddMagicPower[i];
                                        UIManager.instance.npcQuestSlot[j].maxAddDefence = questItemMaxAddDefence[i];
                                        UIManager.instance.npcQuestSlot[j].coolTime = questItemCoolTime[i];
                                        UIManager.instance.npcQuestSlot[j].stayTime = questItemStayTime[i];
                                        UIManager.instance.npcQuestSlot[j].addMaxHP = questItemAddMaxHP[i];
                                        UIManager.instance.npcQuestSlot[j].addMaxMP = questItemAddMaxMP[i];
                                        UIManager.instance.npcQuestSlot[j].addSTR = questItemAddSTR[i];
                                        UIManager.instance.npcQuestSlot[j].addHEL = questItemAddHEL[i];
                                        UIManager.instance.npcQuestSlot[j].addINT = questItemAddINT[i];
                                        UIManager.instance.npcQuestSlot[j].addLUK = questItemAddLUK[i];
                                        UIManager.instance.npcQuestSlot[j].addPower = questItemAddPower[i];
                                        UIManager.instance.npcQuestSlot[j].addMagicPower = questItemAdMagicPower[i];
                                        UIManager.instance.npcQuestSlot[j].addDefence = questItemAddDefence[i];
                                        UIManager.instance.npcQuestSlot[j].requireAccumulateLevel = questItemRequireAccumulateLevel[i];
                                        UIManager.instance.npcQuestSlot[j].requireLevel = questItemRequireLevel[i];
                                        UIManager.instance.npcQuestSlot[j].requireSTR = questItemRequireSTR[i];
                                        UIManager.instance.npcQuestSlot[j].requireHEL = questItemRequireHEL[i];
                                        UIManager.instance.npcQuestSlot[j].requireINT = questItemRequireINT[i];
                                        UIManager.instance.npcQuestSlot[j].requireLUK = questItemRequireLUK[i];
                                        UIManager.instance.npcQuestSlot[j].enhanceLevel = questItemEnhanceLevel[i];
                                        UIManager.instance.npcQuestSlot[j].enhanceStack = questItemEnhanceStack[i];
                                        UIManager.instance.npcQuestSlot[j].sharePosiible = questItemSharePosiible[i];
                                        UIManager.instance.npcQuestSlot[j].questNameText.text = UIManager.instance.npcQuestSlot[j].questName;
                                        for (int k = 0; k < 5; k++)
                                        {
                                            if(UIManager.instance.quest_IngSlot[k].questName == UIManager.instance.npcQuestSlot[j].questName)
                                            {
                                                UIManager.instance.npcQuestSlot[j].questNpc = UIManager.instance.quest_IngSlot[k].questNpc;
                                                UIManager.instance.npcQuestSlot[j].thStroy = UIManager.instance.quest_IngSlot[k].thStroy;
                                                UIManager.instance.npcQuestSlot[j].questRewardExp = UIManager.instance.quest_IngSlot[k].questRewardExp;
                                                UIManager.instance.npcQuestSlot[j].questRewardMoney = UIManager.instance.quest_IngSlot[k].questRewardMoney;
                                                UIManager.instance.npcQuestSlot[j].questRewardItemName = UIManager.instance.quest_IngSlot[k].questRewardItemName;
                                                UIManager.instance.npcQuestSlot[j].questState = UIManager.instance.quest_IngSlot[k].questState;
                                                UIManager.instance.npcQuestSlot[j].needItemName = UIManager.instance.quest_IngSlot[k].needItemName;
                                                UIManager.instance.npcQuestSlot[j].needMeetingNPC = UIManager.instance.quest_IngSlot[k].needMeetingNPC;
                                                UIManager.instance.npcQuestSlot[j].meetingNpcFinish = UIManager.instance.quest_IngSlot[k].meetingNpcFinish;
                                                UIManager.instance.npcQuestSlot[j].needHuntingMonsterName = UIManager.instance.quest_IngSlot[k].needHuntingMonsterName;
                                                UIManager.instance.npcQuestSlot[j].needItemNumber = UIManager.instance.quest_IngSlot[k].needItemNumber;
                                                UIManager.instance.npcQuestSlot[j].needHuntingNumber = UIManager.instance.quest_IngSlot[k].needHuntingNumber;
                                                UIManager.instance.npcQuestSlot[j].currentCollecITemNumber = UIManager.instance.quest_IngSlot[k].currentCollecITemNumber;
                                                UIManager.instance.npcQuestSlot[j].currentHuntingMonsterNumber = UIManager.instance.quest_IngSlot[k].currentHuntingMonsterNumber;
                                                UIManager.instance.npcQuestSlot[j].bigItemType = UIManager.instance.quest_IngSlot[k].bigItemType;
                                                UIManager.instance.npcQuestSlot[j].smallItemType = UIManager.instance.quest_IngSlot[k].smallItemType;
                                                UIManager.instance.npcQuestSlot[j].price =  UIManager.instance.quest_IngSlot[k].price;
                                                UIManager.instance.npcQuestSlot[j].itemExplain = UIManager.instance.quest_IngSlot[k].itemExplain;
                                                UIManager.instance.npcQuestSlot[j].quantity = UIManager.instance.quest_IngSlot[k].quantity;
                                                UIManager.instance.npcQuestSlot[j].questRequireLevel = UIManager.instance.quest_IngSlot[k].questRequireLevel;
                                                UIManager.instance.npcQuestSlot[j].questRequireAccmulateLevel = UIManager.instance.quest_IngSlot[k].questRequireAccmulateLevel;
                                                UIManager.instance.npcQuestSlot[j].maxAddHP = UIManager.instance.quest_IngSlot[k].maxAddHP;
                                                UIManager.instance.npcQuestSlot[j].maxAddMP = UIManager.instance.quest_IngSlot[k].maxAddMP;
                                                UIManager.instance.npcQuestSlot[j].maxAddMaxMP = UIManager.instance.quest_IngSlot[k].maxAddMaxMP;
                                                UIManager.instance.npcQuestSlot[j].maxAddMaxHP = UIManager.instance.quest_IngSlot[k].maxAddMaxHP;
                                                UIManager.instance.npcQuestSlot[j].maxAddSTR = UIManager.instance.quest_IngSlot[k].maxAddSTR;
                                                UIManager.instance.npcQuestSlot[j].maxAddHEL = UIManager.instance.quest_IngSlot[k].maxAddHEL;
                                                UIManager.instance.npcQuestSlot[j].maxAddINT = UIManager.instance.quest_IngSlot[k].maxAddINT;
                                                UIManager.instance.npcQuestSlot[j].maxAddLUK = UIManager.instance.quest_IngSlot[k].maxAddLUK;
                                                UIManager.instance.npcQuestSlot[j].maxAddPower = UIManager.instance.quest_IngSlot[k].maxAddPower;
                                                UIManager.instance.npcQuestSlot[j].maxAddMagicPower = UIManager.instance.quest_IngSlot[k].maxAddMagicPower;
                                                UIManager.instance.npcQuestSlot[j].maxAddDefence = UIManager.instance.quest_IngSlot[k].maxAddDefence;
                                                UIManager.instance.npcQuestSlot[j].coolTime = UIManager.instance.quest_IngSlot[k].coolTime;
                                                UIManager.instance.npcQuestSlot[j].stayTime = UIManager.instance.quest_IngSlot[k].stayTime;
                                                UIManager.instance.npcQuestSlot[j].addMaxHP = UIManager.instance.quest_IngSlot[k].addMaxHP;
                                                UIManager.instance.npcQuestSlot[j].addMaxMP = UIManager.instance.quest_IngSlot[k].addMaxMP;
                                                UIManager.instance.npcQuestSlot[j].addSTR = UIManager.instance.quest_IngSlot[k].addSTR;
                                                UIManager.instance.npcQuestSlot[j].addHEL = UIManager.instance.quest_IngSlot[k].addHEL;
                                                UIManager.instance.npcQuestSlot[j].addINT = UIManager.instance.quest_IngSlot[k].addINT;
                                                UIManager.instance.npcQuestSlot[j].addLUK = UIManager.instance.quest_IngSlot[k].addLUK;
                                                UIManager.instance.npcQuestSlot[j].addPower = UIManager.instance.quest_IngSlot[k].addPower;
                                                UIManager.instance.npcQuestSlot[j].addMagicPower = UIManager.instance.quest_IngSlot[k].addMagicPower;
                                                UIManager.instance.npcQuestSlot[j].addDefence = UIManager.instance.quest_IngSlot[k].addDefence;
                                                UIManager.instance.npcQuestSlot[j].requireAccumulateLevel = UIManager.instance.quest_IngSlot[k].requireAccumulateLevel;
                                                UIManager.instance.npcQuestSlot[j].requireLevel = UIManager.instance.quest_IngSlot[k].requireLevel;
                                                UIManager.instance.npcQuestSlot[j].requireSTR = UIManager.instance.quest_IngSlot[k].requireSTR;
                                                UIManager.instance.npcQuestSlot[j].requireHEL = UIManager.instance.quest_IngSlot[k].requireHEL;
                                                UIManager.instance.npcQuestSlot[j].requireINT = UIManager.instance.quest_IngSlot[k].requireINT;
                                                UIManager.instance.npcQuestSlot[j].requireLUK = UIManager.instance.quest_IngSlot[k].requireLUK;
                                                UIManager.instance.npcQuestSlot[j].enhanceLevel = UIManager.instance.quest_IngSlot[k].enhanceLevel;
                                                UIManager.instance.npcQuestSlot[j].enhanceStack = UIManager.instance.quest_IngSlot[k].enhanceStack;
                                                UIManager.instance.npcQuestSlot[j].sharePosiible = UIManager.instance.quest_IngSlot[k].sharePosiible;
                                                if(UIManager.instance.npcQuestSlot[j].questState)
                                                    UIManager.instance.npcQuestSlot[j].questNameText.text = UIManager.instance.npcQuestSlot[j].questName + " (완료)";
                                                else
                                                    UIManager.instance.npcQuestSlot[j].questNameText.text = UIManager.instance.npcQuestSlot[j].questName + " (진행중)";
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                            break;

                        case "Loop":
                            for (int j = 0; j < 3; j++)
                            {
                                if (UIManager.instance.npcQuestSlot[j].questName == "null")
                                {
                                    UIManager.instance.npcQuestSlot[j].questName = questName[i];
                                    UIManager.instance.npcQuestSlot[j].questType = questType[i];
                                    UIManager.instance.npcQuestSlot[j].questKind = questKind[i];
                                    for (int k = 0; k < 12; k++)
                                        UIManager.instance.npcQuestSlot[j].questExplain[k] = questExplain[i, k];
                                    UIManager.instance.npcQuestSlot[j].questNpc = questNpc[i];
                                    UIManager.instance.npcQuestSlot[j].thStroy = thStroy[i];
                                    UIManager.instance.npcQuestSlot[j].questRewardExp = questRewardExp[i];
                                    UIManager.instance.npcQuestSlot[j].questRewardMoney = questRewardMoney[i];
                                    UIManager.instance.npcQuestSlot[j].questRewardItemName = questRewardItemName[i];
                                    UIManager.instance.npcQuestSlot[j].questState = questState[i];
                                    UIManager.instance.npcQuestSlot[j].needItemName = needItemName[i];
                                    UIManager.instance.npcQuestSlot[j].needMeetingNPC = needMeetingNPC[i];
                                    UIManager.instance.npcQuestSlot[j].meetingNpcFinish = meetingNpcFinish[i];
                                    UIManager.instance.npcQuestSlot[j].needHuntingMonsterName = needHuntingMonsterName[i];
                                    UIManager.instance.npcQuestSlot[j].needItemNumber = needItemNumber[i];
                                    UIManager.instance.npcQuestSlot[j].needHuntingNumber = needHuntingNumber[i];
                                    UIManager.instance.npcQuestSlot[j].currentCollecITemNumber = currentCollecITemNumber[i];
                                    UIManager.instance.npcQuestSlot[j].currentHuntingMonsterNumber = currentHuntingMonsterNumber[i];
                                    UIManager.instance.npcQuestSlot[j].bigItemType = questItemBigItemType[i];
                                    UIManager.instance.npcQuestSlot[j].smallItemType = questItemSmallItemType[i];
                                    UIManager.instance.npcQuestSlot[j].price = questItemPrice[i];
                                    UIManager.instance.npcQuestSlot[j].itemExplain = questItemExplain[i];
                                    UIManager.instance.npcQuestSlot[j].quantity = QuestItemQuantity[i];
                                    UIManager.instance.npcQuestSlot[j].questRequireLevel = questRequireLevel[i];
                                    UIManager.instance.npcQuestSlot[j].questRequireAccmulateLevel = questRequireAccmulateLevel[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddHP = questItemMaxAddHP[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddMP = questItemMaxAddMP[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddMaxMP = questItemMaxAddMaxMP[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddMaxHP = questItemMaxAddMaxHP[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddSTR = questItemMaxAddSTR[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddHEL = questItemMaxAddHEL[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddINT = questItemMaxAddINT[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddLUK = questItemMaxAddLUK[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddPower = questItemMxAddPower[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddMagicPower = questItemMaxAddMagicPower[i];
                                    UIManager.instance.npcQuestSlot[j].maxAddDefence = questItemMaxAddDefence[i];
                                    UIManager.instance.npcQuestSlot[j].coolTime = questItemCoolTime[i];
                                    UIManager.instance.npcQuestSlot[j].stayTime = questItemStayTime[i];
                                    UIManager.instance.npcQuestSlot[j].addMaxHP = questItemAddMaxHP[i];
                                    UIManager.instance.npcQuestSlot[j].addMaxMP = questItemAddMaxMP[i];
                                    UIManager.instance.npcQuestSlot[j].addSTR = questItemAddSTR[i];
                                    UIManager.instance.npcQuestSlot[j].addHEL = questItemAddHEL[i];
                                    UIManager.instance.npcQuestSlot[j].addINT = questItemAddINT[i];
                                    UIManager.instance.npcQuestSlot[j].addLUK = questItemAddLUK[i];
                                    UIManager.instance.npcQuestSlot[j].addPower = questItemAddPower[i];
                                    UIManager.instance.npcQuestSlot[j].addMagicPower = questItemAdMagicPower[i];
                                    UIManager.instance.npcQuestSlot[j].addDefence = questItemAddDefence[i];
                                    UIManager.instance.npcQuestSlot[j].requireAccumulateLevel = questItemRequireAccumulateLevel[i];
                                    UIManager.instance.npcQuestSlot[j].requireLevel = questItemRequireLevel[i];
                                    UIManager.instance.npcQuestSlot[j].requireSTR = questItemRequireSTR[i];
                                    UIManager.instance.npcQuestSlot[j].requireHEL = questItemRequireHEL[i];
                                    UIManager.instance.npcQuestSlot[j].requireINT = questItemRequireINT[i];
                                    UIManager.instance.npcQuestSlot[j].requireLUK = questItemRequireLUK[i];
                                    UIManager.instance.npcQuestSlot[j].enhanceLevel = questItemEnhanceLevel[i];
                                    UIManager.instance.npcQuestSlot[j].enhanceStack = questItemEnhanceStack[i];
                                    UIManager.instance.npcQuestSlot[j].sharePosiible = questItemSharePosiible[i];
                                    UIManager.instance.npcQuestSlot[j].questNameText.text = UIManager.instance.npcQuestSlot[j].questName;
                                    for (int k = 0; k < 5; k++)
                                    {
                                        if (UIManager.instance.quest_IngSlot[k].questName == UIManager.instance.npcQuestSlot[j].questName)
                                        {

                                            Debug.Log("진행중");
                                            UIManager.instance.npcQuestSlot[j].questNpc = UIManager.instance.quest_IngSlot[k].questNpc;
                                            UIManager.instance.npcQuestSlot[j].thStroy = UIManager.instance.quest_IngSlot[k].thStroy;
                                            UIManager.instance.npcQuestSlot[j].questRewardExp = UIManager.instance.quest_IngSlot[k].questRewardExp;
                                            UIManager.instance.npcQuestSlot[j].questRewardMoney = UIManager.instance.quest_IngSlot[k].questRewardMoney;
                                            UIManager.instance.npcQuestSlot[j].questRewardItemName = UIManager.instance.quest_IngSlot[k].questRewardItemName;
                                            UIManager.instance.npcQuestSlot[j].questState = UIManager.instance.quest_IngSlot[k].questState;
                                            UIManager.instance.npcQuestSlot[j].needItemName = UIManager.instance.quest_IngSlot[k].needItemName;
                                            UIManager.instance.npcQuestSlot[j].needMeetingNPC = UIManager.instance.quest_IngSlot[k].needMeetingNPC;
                                            UIManager.instance.npcQuestSlot[j].meetingNpcFinish = UIManager.instance.quest_IngSlot[k].meetingNpcFinish;
                                            UIManager.instance.npcQuestSlot[j].needHuntingMonsterName = UIManager.instance.quest_IngSlot[k].needHuntingMonsterName;
                                            UIManager.instance.npcQuestSlot[j].needItemNumber = UIManager.instance.quest_IngSlot[k].needItemNumber;
                                            UIManager.instance.npcQuestSlot[j].needHuntingNumber = UIManager.instance.quest_IngSlot[k].needHuntingNumber;
                                            UIManager.instance.npcQuestSlot[j].currentCollecITemNumber = UIManager.instance.quest_IngSlot[k].currentCollecITemNumber;
                                            UIManager.instance.npcQuestSlot[j].currentHuntingMonsterNumber = UIManager.instance.quest_IngSlot[k].currentHuntingMonsterNumber;
                                            UIManager.instance.npcQuestSlot[j].bigItemType = UIManager.instance.quest_IngSlot[k].bigItemType;
                                            UIManager.instance.npcQuestSlot[j].smallItemType = UIManager.instance.quest_IngSlot[k].smallItemType;
                                            UIManager.instance.npcQuestSlot[j].price = UIManager.instance.quest_IngSlot[k].price;
                                            UIManager.instance.npcQuestSlot[j].itemExplain = UIManager.instance.quest_IngSlot[k].itemExplain;
                                            UIManager.instance.npcQuestSlot[j].quantity = UIManager.instance.quest_IngSlot[k].quantity;
                                            UIManager.instance.npcQuestSlot[j].questRequireLevel = UIManager.instance.quest_IngSlot[k].questRequireLevel;
                                            UIManager.instance.npcQuestSlot[j].questRequireAccmulateLevel = UIManager.instance.quest_IngSlot[k].questRequireAccmulateLevel;
                                            UIManager.instance.npcQuestSlot[j].maxAddHP = UIManager.instance.quest_IngSlot[k].maxAddHP;
                                            UIManager.instance.npcQuestSlot[j].maxAddMP = UIManager.instance.quest_IngSlot[k].maxAddMP;
                                            UIManager.instance.npcQuestSlot[j].maxAddMaxMP = UIManager.instance.quest_IngSlot[k].maxAddMaxMP;
                                            UIManager.instance.npcQuestSlot[j].maxAddMaxHP = UIManager.instance.quest_IngSlot[k].maxAddMaxHP;
                                            UIManager.instance.npcQuestSlot[j].maxAddSTR = UIManager.instance.quest_IngSlot[k].maxAddSTR;
                                            UIManager.instance.npcQuestSlot[j].maxAddHEL = UIManager.instance.quest_IngSlot[k].maxAddHEL;
                                            UIManager.instance.npcQuestSlot[j].maxAddINT = UIManager.instance.quest_IngSlot[k].maxAddINT;
                                            UIManager.instance.npcQuestSlot[j].maxAddLUK = UIManager.instance.quest_IngSlot[k].maxAddLUK;
                                            UIManager.instance.npcQuestSlot[j].maxAddPower = UIManager.instance.quest_IngSlot[k].maxAddPower;
                                            UIManager.instance.npcQuestSlot[j].maxAddMagicPower = UIManager.instance.quest_IngSlot[k].maxAddMagicPower;
                                            UIManager.instance.npcQuestSlot[j].maxAddDefence = UIManager.instance.quest_IngSlot[k].maxAddDefence;
                                            UIManager.instance.npcQuestSlot[j].coolTime = UIManager.instance.quest_IngSlot[k].coolTime;
                                            UIManager.instance.npcQuestSlot[j].stayTime = UIManager.instance.quest_IngSlot[k].stayTime;
                                            UIManager.instance.npcQuestSlot[j].addMaxHP = UIManager.instance.quest_IngSlot[k].addMaxHP;
                                            UIManager.instance.npcQuestSlot[j].addMaxMP = UIManager.instance.quest_IngSlot[k].addMaxMP;
                                            UIManager.instance.npcQuestSlot[j].addSTR = UIManager.instance.quest_IngSlot[k].addSTR;
                                            UIManager.instance.npcQuestSlot[j].addHEL = UIManager.instance.quest_IngSlot[k].addHEL;
                                            UIManager.instance.npcQuestSlot[j].addINT = UIManager.instance.quest_IngSlot[k].addINT;
                                            UIManager.instance.npcQuestSlot[j].addLUK = UIManager.instance.quest_IngSlot[k].addLUK;
                                            UIManager.instance.npcQuestSlot[j].addPower = UIManager.instance.quest_IngSlot[k].addPower;
                                            UIManager.instance.npcQuestSlot[j].addMagicPower = UIManager.instance.quest_IngSlot[k].addMagicPower;
                                            UIManager.instance.npcQuestSlot[j].addDefence = UIManager.instance.quest_IngSlot[k].addDefence;
                                            UIManager.instance.npcQuestSlot[j].requireAccumulateLevel = UIManager.instance.quest_IngSlot[k].requireAccumulateLevel;
                                            UIManager.instance.npcQuestSlot[j].requireLevel = UIManager.instance.quest_IngSlot[k].requireLevel;
                                            UIManager.instance.npcQuestSlot[j].requireSTR = UIManager.instance.quest_IngSlot[k].requireSTR;
                                            UIManager.instance.npcQuestSlot[j].requireHEL = UIManager.instance.quest_IngSlot[k].requireHEL;
                                            UIManager.instance.npcQuestSlot[j].requireINT = UIManager.instance.quest_IngSlot[k].requireINT;
                                            UIManager.instance.npcQuestSlot[j].requireLUK = UIManager.instance.quest_IngSlot[k].requireLUK;
                                            UIManager.instance.npcQuestSlot[j].enhanceLevel = UIManager.instance.quest_IngSlot[k].enhanceLevel;
                                            UIManager.instance.npcQuestSlot[j].enhanceStack = UIManager.instance.quest_IngSlot[k].enhanceStack;
                                            UIManager.instance.npcQuestSlot[j].sharePosiible = UIManager.instance.quest_IngSlot[k].sharePosiible;
                                            if (UIManager.instance.npcQuestSlot[j].questState)
                                                UIManager.instance.npcQuestSlot[j].questNameText.text = UIManager.instance.npcQuestSlot[j].questName + " (완료)";
                                            else
                                                UIManager.instance.npcQuestSlot[j].questNameText.text = UIManager.instance.npcQuestSlot[j].questName + " (진행중)";
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            break;
                        default:
                            break;

                    }









                }


            }




            //NPC가 파는 아이템 정보와 퀘스트 정보를 넘겨준다 
            for(int i = 0; i < 12; i++)
            {
                if(sellItemName[i] != "null")
                {
                    UIManager.instance.shop_sellItem[i].itemName = sellItemName[i];
                    UIManager.instance.shop_sellItem[i].bigItemType = sellBigItemType[i];
                    UIManager.instance.shop_sellItem[i].smallItemType = sellSmallItemType[i];
                    UIManager.instance.shop_sellItem[i].price = sellPrice[i];
                    UIManager.instance.shop_sellItem[i].itemExplain = sellItemExplain[i];
                    UIManager.instance.shop_sellItem[i].quantity = sellQuantity[i];
                    UIManager.instance.shop_sellItem[i].maxAddHP = sellMaxAddHP[i];
                    UIManager.instance.shop_sellItem[i].maxAddMP = sellMaxAddMP[i];
                    UIManager.instance.shop_sellItem[i].maxAddMaxHP = sellMaxAddMaxMP[i];
                    UIManager.instance.shop_sellItem[i].maxAddMaxMP = sellMaxAddMaxHP[i];
                    UIManager.instance.shop_sellItem[i].maxAddSTR = sellMaxAddSTR[i];
                    UIManager.instance.shop_sellItem[i].maxAddHEL = sellMaxAddHEL[i];
                    UIManager.instance.shop_sellItem[i].maxAddINT = sellMaxAddINT[i];
                    UIManager.instance.shop_sellItem[i].maxAddLUK = sellMaxAddLUK[i];
                    UIManager.instance.shop_sellItem[i].maxAddPower = sellMaxAddPower[i];
                    UIManager.instance.shop_sellItem[i].maxAddMagicPower = sellMaxAddMagicPower[i];
                    UIManager.instance.shop_sellItem[i].maxAddDefence = sellMaxAddDefence[i];
                    UIManager.instance.shop_sellItem[i].coolTime = sellCoolTime[i];
                    UIManager.instance.shop_sellItem[i].stayTime = sellStayTime[i];
                    UIManager.instance.shop_sellItem[i].addMaxHP = sellAddMaxHP[i];
                    UIManager.instance.shop_sellItem[i].addMaxMP = sellAddMaxMP[i];
                    UIManager.instance.shop_sellItem[i].addSTR = sellAddSTR[i];
                    UIManager.instance.shop_sellItem[i].addHEL = sellAddHEL[i];
                    UIManager.instance.shop_sellItem[i].addINT = sellAddINT[i];
                    UIManager.instance.shop_sellItem[i].addLUK = sellAddLUK[i];
                    UIManager.instance.shop_sellItem[i].addPower = sellAddPower[i];
                    UIManager.instance.shop_sellItem[i].addMagicPower = sellAddMagicPower[i];
                    UIManager.instance.shop_sellItem[i].addDefence = sellAddDefence[i];
                    UIManager.instance.shop_sellItem[i].requireAccumulateLevel = sellRequireAccumulateLevel[i];
                    UIManager.instance.shop_sellItem[i].requireLevel = sellRequireLevel[i];
                    UIManager.instance.shop_sellItem[i].requireSTR = sellRequireSTR[i];
                    UIManager.instance.shop_sellItem[i].requireHEL = sellRequireHEL[i];
                    UIManager.instance.shop_sellItem[i].requireINT = sellRequireINT[i];
                    UIManager.instance.shop_sellItem[i].requireLUK = sellRequireLUK[i];
                    UIManager.instance.shop_sellItem[i].sharePosiible = sellSharePosiible[i];
                    UIManager.instance.shop_sellItem[i].enhanceLevel = sellEnhanceLevel[i];
                    UIManager.instance.shop_sellItem[i].enhanceStack = sellEnhanceStack[i];
                }
                else
                {
                    UIManager.instance.shop_sellItem[i].itemName = "null";
                }
                UIManager.instance.shop_sellItem[i].Refresh();

        }
            UIManager.instance.npcTalkWindow.gameObject.SetActive(true);
        }
    }



}
