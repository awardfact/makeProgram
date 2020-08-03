using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayCanvas : MonoBehaviour    //왼쪽 이동 , 오른쪽 이동, 점프를 눌렀을 떄 동작
{

    Player player;
    //시스템 메시지를 관리할 큐 
    Queue<string> systemMessageQueue = new Queue<string>();



    // 경험치 바와 바에 출력하는 텍스트 
    public Slider expBarSlider;
    public Text expText;



    // 적 이미지와 체력 바, 체력 텍스트 
    public Slider enemyHpBarSlider;
    public Text enemyHpText;
    public Image enemyImage;


    // 캐릭터 hp바와 hp텍스트 
    public Slider hpBarSlider;
    public Text hpText;


    // 캐릭터 mp바와 mp텍스트 
    public Slider mpBarSlider;
    public Text mpText;

    public Text levelText;

    public RectTransform helpPanel;
    int j;
    int l;

    public bool rightButtonClickIng;
    public bool leftButtonClickIng;
    public bool attackButtonClickIng;
    public bool jumpButtonClickIng;

    public string[] systemMessage = new string[4];
    public string[] systemMessage2 = new string[4];


    public string[] helpString = new string[10];
    public int helpNumberCount;
    public Text helpText;
    public Text helpNumberText;


    public Text questingText;
    public Text questingNumberText;
    public RectTransform questingPanel;
    public int questingCount;


    public Text npcTalkText;


    // Start is called before the first frame update
    void Start()
    {
        // 도움말 
        helpString[0] = "NPC와 대화하거나 포탈을 이용하기 좌측 상단 버튼을 눌러 NPC, 포탈 ON 상태에서 포탈, NPC에게 다가가면 됩니다, 퀘스트 완료 후 그 NPC에게 퀘스트가 남아있다면 다시 NPC와 대화해야합니다.";
        helpString[1] = "레벨업 시 AP 1~3, SP 1이(전직했을 경우) 지급되며 AP당 1~3의 스텟이 증가합니다.";
        helpString[2] = "레벨 30 이상이면 환생 시 AP, 돈, 클로버 중 하나를 보상으로 받을 수 있으며 Random 선택 시 보상이 25%증가합니다.";
        helpString[3] = "레벨업에 필요한 경험치는 레벨에 비례하여 랜덤으로 결정됩니다.";
        helpString[4] = "장비 아이템의 모든 옵션은 아이템에 따라 랜덤으로 결정됩니다.";
        helpString[5] = "강화 성공 시 강화 단계에 따라 옵션이 랜덤으로 증가하거나 약간 감소하며 , 강화 보호석을 사용하면 강화 실패 시 아이템 파괴가 방지되며 강화의 비약을 통해 강화 스택(강화 확률 증가)을 중첩할 수 있습니다.";
        helpString[6] = "강화 성공 시 증가 옵션이나 환생 보상이 마음에 들지 않을 경우 리턴 스크롤(환생 또는 강화)을 사용하여 되돌릴 수 있으며 리턴스크롤(환생)은 환생 당 5번까지 사용이 가능합니다.";
        helpString[7] = "아이템 판매 시 아이템 가치에 따라 돈이 랜덤으로 증가하며 구매 시 아이템 가치에 따라 돈이 랜덤으로 감소합니다.";
        helpString[8] = "운이 증가하면 확률 또는 보상이 아주 소량 증가합니다.";
        helpString[9] = "이외에도 많은 것들이 랜덤으로 결정됩니다.";

        expBarSlider = transform.Find("ExpBar").gameObject.GetComponent<Slider>();
        expText = transform.Find("ExpBar/ExpText").gameObject.GetComponent<Text>();

        hpBarSlider = transform.Find("PortraitPanel/HPBar").gameObject.GetComponent<Slider>();
        mpBarSlider = transform.Find("PortraitPanel/MPBar").gameObject.GetComponent<Slider>();
        hpText = transform.Find("PortraitPanel/HPBar/CurrentHPText").gameObject.GetComponent<Text>();
        mpText = transform.Find("PortraitPanel/MPBar/CurrentMPText").gameObject.GetComponent<Text>();

        enemyHpBarSlider = transform.Find("EnemyHpPanel/EnemyHPBar").gameObject.GetComponent<Slider>();
        enemyHpText = transform.Find("EnemyHpPanel/EnemyHPBar/CurrentHPText").gameObject.GetComponent<Text>();
        enemyImage = transform.Find("EnemyHpPanel/EnemyPortraitFrame/EnemyPortraitImage").gameObject.GetComponent<Image>();

        levelText = transform.Find("PortraitPanel/LevelText").gameObject.GetComponent<Text>();

        helpPanel = transform.Find("HelpPanel").gameObject.GetComponent<RectTransform>();
        helpText = transform.Find("HelpPanel/HelpText").gameObject.GetComponent<Text>();
        helpNumberText = transform.Find("HelpPanel/CurrentNumberText").gameObject.GetComponent<Text>();
        helpText.text = helpString[0];
        questingPanel = transform.Find("QuestingPanel").gameObject.GetComponent<RectTransform>();
        questingText = transform.Find("QuestingPanel/QuestingText").gameObject.GetComponent<Text>();
        questingNumberText = transform.Find("QuestingPanel/CurrentNumberText").gameObject.GetComponent<Text>();

        npcTalkText = transform.Find("NPCTalk/Text").gameObject.GetComponent<Text>();

        npcTalkText.text = "NPC, 포탈 ON";
        CharacterManager.instance.npcTalk = true;
    }

    void Update()
    {

        /*
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rightButtonClickIng = true;
            RightMove();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftButtonClickIng = true;
            LeftMove();
        }
        */

        //공격키가 눌려져 있으면 
        if (attackButtonClickIng)
        {
            //공격상태로 하고 
            Attack();

            CharacterManager.instance.attackName = "BasicAttack";

            //왼쪽을 보고 있다면 왼쪽공격,, 오른쪽공격은 false
            if (!CharacterManager.instance.lookRight)
            {
                UIManager.instance.player.anim.SetBool("isRightAttack", false);
                UIManager.instance.player.anim.SetBool("isLeftAttack", true);

            }

            //오른쪽을 보고 있다면 오른쪽공격을 true 왼쪽 공격을 false로 해준다 
            else
            {
                UIManager.instance.player.anim.SetBool("isLeftAttack", false);
                UIManager.instance.player.anim.SetBool("isRightAttack", true);
            }


        }

        //오른쪽 이동이 눌려져있으면 오른쪽으로 이동 
        if (rightButtonClickIng)
        {
            RightMove();

        }


        //왼쪽 이동이 눌려져있으면 왼쪽으로 이동 
        if (leftButtonClickIng)
        {

            LeftMove();

        }
    }



    //시스템 메시지를 매개변수로 받고 그 메시지를 화면에 출력한다 최근 메시지는 밑에 출력되고 5초가 지나면 메시지는 사라진다 
    //먼저 메시지를 큐에 넣고 만약 큐에 4개 이상의 메시지가 있으면 Dequeue를 해서 먼저 들어온 메시지를 삭제한다 
    // 그리고 Count는 1이면 1개있는 상태니까 배열은 -1을 해서 현재 큐에 있는 개수만큼 디큐해서 디큐한 메시지를 string배열에 넣어주고
    // string 배열에 있는 내용을 화면에 출력해준다 
    // 그 다음에 메시지들을 다시 먼저 들어온거 먼저 큐에 넣어주고 코루틴을 실행하는데 코루틴은
    // 5초가 지나면 디큐를 해서 먼저 들어온 메시지를 삭제시켜준다음에
    // 메시지를 다시 출력해준다 
    public void SystemMessageOutput(string message)
    {

        systemMessageQueue.Enqueue(message);
        if (systemMessageQueue.Count > 4)
        {
            systemMessageQueue.Dequeue();
        }


        j = systemMessageQueue.Count - 1;

        for (int i = systemMessageQueue.Count - 1; i >= 0; i--)
        {

            systemMessage[i] = systemMessageQueue.Dequeue();
            UIManager.instance.systemMessageText[i].text = systemMessage[i];

        }

        for (int i = j; i >= 0; i--)
        {
            systemMessageQueue.Enqueue(systemMessage[i]);
        }

        StartCoroutine(SystemMessageCor());


    }




    // 공격버튼을 누르면 공격중 상태가 된다 
    public void AttackButtonClick()
    {
  
        attackButtonClickIng = true;
        CharacterManager.instance.isAttack = true;
        SoundManager.instance.StaySoundEffectON("SwordSwingSound", SoundManager.instance.staySoundEffectNumber);
    }

    //공격 버튼을 떼면 공격상태를 false로 
    public void AttackButtonUp()
    {
        attackButtonClickIng = false;
        CharacterManager.instance.isAttack = false;
        CharacterManager.instance.attackName = "null";
        UIManager.instance.player.anim.SetBool("isLeftAttack", false);
        UIManager.instance.player.anim.SetBool("isRightAttack", false);
        SoundManager.instance.StaySoundEffectOFF("SwordSwingSound");
    }



    //오른쪽 버튼을 누르면 오른쪽 이동 상태가 된다 
    public void RightButtonClick()
    {
        rightButtonClickIng = true;
        UIManager.instance.player.anim.SetBool("isMove", true);
        SoundManager.instance.StaySoundEffectON("WalkSound", SoundManager.instance.staySoundEffectNumber);
    }

    public void RightButtonUp()
    {
        rightButtonClickIng = false;
        UIManager.instance.player.anim.SetBool("isMove", false);
        SoundManager.instance.StaySoundEffectOFF("WalkSound");
    }
    public void leftButtonClick()
    {
        leftButtonClickIng = true;
        UIManager.instance.player.anim.SetBool("isMove", true);
        SoundManager.instance.StaySoundEffectON("WalkSound", SoundManager.instance.staySoundEffectNumber);
    }

    public void leftButtonUp()
    {
        leftButtonClickIng = false;
        UIManager.instance.player.anim.SetBool("isMove", false);
        SoundManager.instance.StaySoundEffectOFF("WalkSound");
    }



    public void LeftMove()    //왼쪽 이동 버튼을 눌렀을 떄 움직이는 애니메이션을 키고 반대쪽을 돌아보도록 하고 moveSpeed 속도로 이동시킨다 
    {

        UIManager.instance.player.LeftKey();

        /*
        player.anim.SetBool("isMove", true);
        player.bodyRenderer.flipX = false;
        player.headRenderer.flipX = false;
        player.helmetRenderer.flipX = false;
        player.weaponRenderer.flipX = false;
        player.shieldRenderer.flipX = false;
        player.leftLegRenderer.flipX = false;
        player.rightLegRenderer.flipX = false;
        if (CharacterManager.instance.lookRight)
        {
            CharacterManager.instance.lookRight = false;
            player.weaponRenderer.transform.localPosition += new Vector3(-0.8f, 0, 0);
            player.shieldRenderer.transform.localPosition += new Vector3(0.7f, 0, 0);

        }
        player.transform.position += -Vector3.right * CharacterManager.instance.moveSpeed * Time.deltaTime;

        */
    }



    public void RightMove() //오른쪽 이동 버튼을 눌렀을 떄 움직이는 애니메이션을 키고 반대쪽을 돌아보도록 하고 moveSpeed 속도로 이동시킨다 
    {


        UIManager.instance.player.RightKey();

        /*
        player.anim.SetBool("isMove", true);
        player.bodyRenderer.flipX = true;
        player.headRenderer.flipX = true;
        player.helmetRenderer.flipX = true;
        player.weaponRenderer.flipX = true;
        player.shieldRenderer.flipX = true;
        player.leftLegRenderer.flipX = true;
        player.rightLegRenderer.flipX = true;

        if (!CharacterManager.instance.lookRight)
        {

            CharacterManager.instance.lookRight = true;
            player.weaponRenderer.transform.localPosition += new Vector3(0.8f, 0, 0);
            player.shieldRenderer.transform.localPosition += new Vector3(-0.7f, 0, 0);
        }
        player.transform.position += Vector3.right * CharacterManager.instance.moveSpeed * Time.deltaTime;


        */
    }

    // 점프 버튼을 누르면 addforce를 y축에 해준다 그리고 jump애니메이션을 실행 
    public void Jump()
    {



        UIManager.instance.player.JumpKey();
        SoundManager.instance.SoundEffectOn("JumpSound", SoundManager.instance.soundEffectNumber);
        /*
        if (!player.anim.GetBool("IsJump"))
        {
            player.rigid.AddForce(new Vector2(0, 5f), ForceMode2D.Impulse);
            player.anim.SetBool("isJump", true);

        }

        */
    }


    // 오른쪽을 바라보고 있으면 오른쪽 공격 애니메이션, 왼쪽을 바라보고 있으면 왼쪽 공격 애니메이션을 실행한다 , 그리고 공격중인 상태가 된다 
    public void Attack()
    {


        UIManager.instance.player.AttackKey();
        CharacterManager.instance.attackName = "BasicAttack";
        /*
        if (CharacterManager.instance.lookRight)
        {
            player.anim.SetBool("isRightAttack", true);
            CharacterManager.instance.isAttack = true;
        }
        else
        {
            player.anim.SetBool("isLeftAttack", true);
            CharacterManager.instance.isAttack = true;
        }  */
    }


    public void MenuButton()
    {
        UIManager.instance.menuWindow.gameObject.SetActive(true);

    }


    //exp바 상태를 새로고침해준다 
    public void ExpBarRefresh()
    {
        expText.text = CharacterManager.instance.currentExp + " / " + CharacterManager.instance.needExp
            + "(" + (((float)CharacterManager.instance.currentExp / CharacterManager.instance.needExp) * 100) + "%)";
        expBarSlider.value = (float)CharacterManager.instance.currentExp / CharacterManager.instance.needExp;
    }

    //hp바 상태를 새로고침한다 
    public void HPBarRefresh()
    {


        hpText.text =  CharacterManager.instance.HP + " / "  + CharacterManager.instance.resultMaxHP;
        hpBarSlider.value = (float)CharacterManager.instance.HP  / CharacterManager.instance.resultMaxHP;



    }


    //mp바 상태를 새로고침한다 
    public void MPBarRefresh()
    {

        mpText.text = CharacterManager.instance.MP + " / " + CharacterManager.instance.resultMaxMP;
        mpBarSlider.value = (float)CharacterManager.instance.MP / CharacterManager.instance.resultMaxMP;
    }



    //레벨텍스트를 새로고침한다 
    public void LevelRefresh()
    {

        levelText.text ="Level : " +  CharacterManager.instance.Level;


    }



    IEnumerator SystemMessageCor()
    {

        yield return new WaitForSeconds(5f);
        
        if(systemMessageQueue.Count > 0)
        {

            systemMessageQueue.Dequeue();
        }


        for (int k = 0; k < 4; k++)
        {

            
            systemMessage2[k] = "";


        }

        l = systemMessageQueue.Count - 1;

        if (l != -1)

        {
            for (int k = systemMessageQueue.Count - 1; k >= 0; k--)
            {


                systemMessage2[k] = systemMessageQueue.Dequeue();


            }
        }


        for (int k = 3; k >= 0; k--)
        {

            UIManager.instance.systemMessageText[k].text = systemMessage2[k];

        }

        if (l != -1)

        {
            for (int k = l; k >= 0; k--)
            {

                systemMessageQueue.Enqueue(systemMessage2[k]);

            }
        }
    }

    public void HelpPanelExitButton()
    {



        helpPanel.gameObject.SetActive(false);
        CharacterManager.instance.helpPanelVisible = false;


    }
    public void HelpPanelNextButton()
    {

        helpNumberCount++;
        if(helpNumberCount >= 10)
        {
            helpNumberCount = 0;
        }
        helpText.text = helpString[helpNumberCount];
        helpNumberText.text = (helpNumberCount + 1) + " / " + "10";
        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);


    }




    public void QuestingPanelExitButton()
    {




        SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
    }
    public void QuuestingPnaelNextButtonClick()
    {

        questingCount++;
        if(questingCount >= 5)
        {

            questingCount = 0;

        }
        QuestingPanleRefresh();


    }

    public void QuestingPanleRefresh()
    {
        if(UIManager.instance.quest_IngSlot[questingCount].questName == "null")
        {
            questingText.text = "이 슬롯에서 진행중인 퀘스트가 없습니다.";
            questingNumberText.text = (questingCount + 1).ToString() + " / 5";
            return;
        }

        questingNumberText.text = (questingCount + 1).ToString() + " / 5";
        if (UIManager.instance.quest_IngSlot[questingCount].questKind == "Meeting")
        {
            if(UIManager.instance.quest_IngSlot[questingCount].questState == true)
            {
                questingText.text = UIManager.instance.quest_IngSlot[questingCount].questName + "\n" + UIManager.instance.quest_IngSlot[questingCount].needMeetingNPC + "를 만나기 (완료)";
            }
            else
            {

                questingText.text = UIManager.instance.quest_IngSlot[questingCount].questName + "\n" + UIManager.instance.quest_IngSlot[questingCount].needMeetingNPC + "를 만나기";

            }

        }
        if (UIManager.instance.quest_IngSlot[questingCount].questKind == "Hunting")
        {
            if (UIManager.instance.quest_IngSlot[questingCount].questState == true)
            {

                questingText.text = UIManager.instance.quest_IngSlot[questingCount].questName + "\n" + UIManager.instance.quest_IngSlot[questingCount].needHuntingMonsterName + UIManager.instance.quest_IngSlot[questingCount].needHuntingNumber + "마리 잡기\n"
                    + "진행상황 :" + UIManager.instance.quest_IngSlot[questingCount].currentHuntingMonsterNumber + " / " + UIManager.instance.quest_IngSlot[questingCount].needHuntingNumber + " (완료)";



            }
            else
            {
                questingText.text = UIManager.instance.quest_IngSlot[questingCount].questName + "\n" + UIManager.instance.quest_IngSlot[questingCount].needHuntingMonsterName + " " + UIManager.instance.quest_IngSlot[questingCount].needHuntingNumber + "마리 잡기\n"
                      + "진행상황 :" + UIManager.instance.quest_IngSlot[questingCount].currentHuntingMonsterNumber + " / " + UIManager.instance.quest_IngSlot[questingCount].needHuntingNumber;


            }
        }
        if (UIManager.instance.quest_IngSlot[questingCount].questKind == "GetItem")
        {
            if (UIManager.instance.quest_IngSlot[questingCount].questState == true)
            {
                questingText.text = UIManager.instance.quest_IngSlot[questingCount].questName + "\n"
                     + UIManager.instance.quest_IngSlot[questingCount].needItemName + " " + UIManager.instance.quest_IngSlot[questingCount].needItemNumber + "개 모으기\n"
                     + "진행상황 : " + UIManager.instance.quest_IngSlot[questingCount].currentCollecITemNumber + " / " + UIManager.instance.quest_IngSlot[questingCount].needItemNumber + " (완료)";

            }
            else
            {
                questingText.text = UIManager.instance.quest_IngSlot[questingCount].questName + "\n"
                     + UIManager.instance.quest_IngSlot[questingCount].needItemName + " " + UIManager.instance.quest_IngSlot[questingCount].needItemNumber + "개 모으기\n"
                     + "진행상황 : " + UIManager.instance.quest_IngSlot[questingCount].currentCollecITemNumber + " / " + UIManager.instance.quest_IngSlot[questingCount].needItemNumber;
            }
        }


    }

    public void GoVillageButtonClick()
    {
            if(CharacterManager.instance.currentCity == "튜토리얼")
        {
            CharacterManager.instance.HP = CharacterManager.instance.maxHP / 10;
            UIManager.instance.statWindow.Refresh();
            CharacterManager.instance.isDie = false;
            UIManager.instance.player.anim.SetBool("isDIe", false);
            UIManager.instance.player.transform.position = new Vector3(-50f, 5, 0);
            UIManager.instance.diePanel.gameObject.SetActive(false);

        }
        else
        {
            CharacterManager.instance.HP = CharacterManager.instance.maxHP / 10;
            UIManager.instance.statWindow.Refresh();
            CharacterManager.instance.isDie = false;
            UIManager.instance.player.anim.SetBool("isDIe", false);
            UIManager.instance.player.transform.position = new Vector3(300f, 5, 0);
            UIManager.instance.diePanel.gameObject.SetActive(false);


        }

    }




    public void NPCTalkButtonClick()
    {
        if (CharacterManager.instance.npcTalk == false)
        {


            CharacterManager.instance.npcTalk = true;

            npcTalkText.text = "NPC, 포탈 ON";
            SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        }
        else
        {


            CharacterManager.instance.npcTalk = false;


            npcTalkText.text = "NPC, 포탈 OFF";
            SoundManager.instance.SoundEffectOn("ClickSound", SoundManager.instance.soundEffectNumber);
        }



    }

}
