using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectCanvas : MonoBehaviour
{
    // 캐릭터와 몬스터가 공격을 받았을 떄 받은 데미지를 출력하는 스크립트 
    // 한 번에 여러개의 데미지 텍스트가 필요하기 때문에 50개의 텍스트 배열을 만들고
    // 배열을 ++해가면서 텍스트를 출력해준다 
    public Text[] enemeyDamegedText = new Text[50];    //적 받은 데미지 텍스트 
    public Text[] playerDamegedText = new Text[10];  // 캐릭터 받은 데미지 텍스트 


    public int enemyDamegedCount;      // 0~50 순서대로 텍스트를 출력한다 
    public int playerDamegedCount;

    public Canvas effectCanvas;
    public Text levelUPText;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            enemeyDamegedText[i] = transform.Find("AttackDamegedPanel/Enemy/EnemyDamegedText_" + (i + 1)).gameObject.GetComponent<Text>();
            enemeyDamegedText[i].text = "";
        }
        for (int i = 0; i < 10; i++)
        {
            playerDamegedText[i] = transform.Find("AttackDamegedPanel/Player/PlayerDamegedText_" + (i + 1)).gameObject.GetComponent<Text>();
            playerDamegedText[i].text = "";
        }

        effectCanvas = GetComponent<Canvas>();
        levelUPText = transform.Find("EffectText/LevelUPText").gameObject.GetComponent<Text>();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 받은 데미지를 가지고 코루틴을 호출한다 
    public void EnemyDameged(long AttackDamege)
    {


        StartCoroutine(EnemyAttackDamegedTextCor(AttackDamege, enemyDamegedCount));


    }

    // 받은 데미지를 가지고 코루틴을 호출한다 
    public void PlayerDameged(long AttackDamege)
    {


        StartCoroutine(PlayerDamegedTextCor(AttackDamege, playerDamegedCount));


    }

    //텍스트를 출력하고 1.5초뒤에 안보이게 한다 
    IEnumerator EnemyAttackDamegedTextCor(long AttackDamege, int EnemyDamegedCount)
    {
        enemeyDamegedText[EnemyDamegedCount].text = AttackDamege.ToString();
        enemyDamegedCount++;
        if (enemyDamegedCount > 49)
        {
            enemyDamegedCount = 0;
        }
        yield return new WaitForSeconds(1.5f);
        enemeyDamegedText[EnemyDamegedCount].text = "";
    }

    IEnumerator PlayerDamegedTextCor(long AttackDamege, int PlayerDamegedCount)
    {
        playerDamegedText[PlayerDamegedCount].text = AttackDamege.ToString();
        playerDamegedCount++;
        if (playerDamegedCount > 9)
        {
            playerDamegedCount = 0;
        }
        yield return new WaitForSeconds(1.5f);
        playerDamegedText[PlayerDamegedCount].text = "";
    }


}
