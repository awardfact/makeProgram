using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfoTemp : MonoBehaviour
{

    public int Level; // 레벨 
    public int accumulateLevel; //누적레벨 

    public long maxNeedExp;  // 렙업했을 떄 랜덤으로 요구 경험치가 정해지는데 렙얼할때마다 랜덤으로 정해지는 범위는 고정되어있어서 렙업하면 이 변수의 범위가 바뀌고 이 변수 범위 내에서 needExp가 결정됨
    public long curretnExp;  // 현재경험치
    public long needExp; // 요구경험치

    public int rebirthReturnScrollUseNumber;
    public int story;

    public string currentPlace; // 현재 장소 
    public string CharacterName;  // 이름
    public string job;  // 직업
    public int thJob; // 몇차 전직인지 

    public int characterNumber;   // 캐릭터 창에서 몇번째 캐릭인지 
    public long rebirthAPStack;    // 환생했을떄 지급되는 AP
    public long AP;
    public long SP;

    public long HP; // 현제체력 ,마나 
    public long MP;

    public long power;  // 공격력
    public long magicPower; // 마력
    public long defence;  // 방어력
    public long STR; //힘
    public long LUK; //운 
    public long INT; // 마력
    public long HEL; // 건강
    public long maxHP;  // 체력
    public long maxMP;  // 마나


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


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
