using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour,Enemy
{

    // 몬스터 스크립트 
    public Animator anim;
    private bool isFight;
    Player player;
    [SerializeField]
    private LayerMask layerMask;
    private float moveCount;
    private int randomAct;
    private float fightCount;
    public int speed;
    private RaycastHit ground;
    public Rigidbody2D rigid;
    SpriteRenderer sprite;
    public bool dameged;
    private int damegedCount;
    public long maxHp;
    public long currentHp;

    public long damege;
    public long defence;

    Sprite[] multisprite = new Sprite[2];


    public bool lookRight;
    public bool dieing;
    public int dieingCount;

    public string name;
    public long exp;

    public long damegeRand1;
    public long damegeRand2;
    public long dropRand1;
    public long dropRand2;
    public long dropRand3;
    public long defenceRand1;
    public long defenceRand2;
    public long expRand1;

    public int startpositionrand;

    public string dropItem1;
    public string dropItem2;
    public string dropItem3;
    public string dropItem4;
    public string dropItem5;

    public long dropMoney;

    //Start에서 몬스터의 정보를 넣어준다 
        void Start()
        {
            name = "Jelly";
            maxHp = 10;
            currentHp = 10;
            damege = 3;
            dropMoney = 100;
            startpositionrand = Random.Range(-50, 13);
            this.transform.position = new Vector2(startpositionrand, 3);
            exp = 100;
            defence = 1;
            anim = gameObject.GetComponent<Animator>();
            rigid = gameObject.GetComponent<Rigidbody2D>();
            sprite = gameObject.GetComponent<SpriteRenderer>();
            player = GameObject.Find("Player").gameObject.GetComponent<Player>();
            anim.SetBool("isIdle", true);
            StartCoroutine(MoveCor());
            multisprite = Resources.LoadAll<Sprite>("Sprite/Enemy/Jelly");
            speed = 4;
        }

        // Update is called once per frame
        void Update()
        {


            Move();


        }



    // 몬스터의 움직임은 3초마다 코루틴을 실행해서 어떤 움직임을 할지 랜덤으로 정한다  그리고 정해진 값에 따라서
    // 오른쪽으로 움직일지 , 가만히 있을지 왼쪽으로 움직일지를 실행한다 
        public void Move()
        {


            if (!dieing)
            {
                if (randomAct == 1)
                {

                    lookRight = true;
                    sprite.flipX = false;
                    anim.SetBool("isMove", true);
                    this.transform.position += Vector3.right * speed * Time.deltaTime;

                }
                else if (randomAct == 2)
                {
                    sprite.flipX = true;
                    lookRight = false;
                    anim.SetBool("isMove", true);
                    this.transform.position += Vector3.left * speed * Time.deltaTime;

                }
                else if (randomAct == 0)
                {
                    anim.SetBool("isIdle", true);
                }
            }
        }
        //   && col.gameObject.tag != "Weapon"


    // 몬스터가 다른 사물과 충돌 했을 때 
    // 먼저 충돌한 대상이 캐릭터인지, 캐릭터가 맞고 있는 상태인지, 죽은 상태인지 체크해서 
    // 모든 조건이 충족하면 캐릭터를 방향에 따라 밀려나게 하고 
    // 캐릭터가 맞는 함수를 몬스터 공격력을 넘겨서 실행시켜준다 
        public void OnCollisionStay2D(Collision2D col)
        {
            if (col.gameObject.tag == "User" && !CharacterManager.instance.isDameged && !dieing)
            {
                //  col.gameObject.GetComponent<Player>().anim.SetBool("isDameged", true);
                //   CharacterManager.instance.isDameged = true;
                //   CharacterManager.instance.HP -= damege;
                //    UIManager.instance.playCanvas.HPBarRefresh();
                UIManager.instance.player.Dameged(damege);
                if (CharacterManager.instance.lookRight)
                {
                    // 오른쪽으로 밀려남
                    // player.rigid.AddForce(new Vector2(3f, 3f), ForceMode2D.Impulse);
                    col.collider.attachedRigidbody.AddForce(new Vector2(3f, 3f), ForceMode2D.Impulse);
                }
                else
                {
                    col.collider.attachedRigidbody.AddForce(new Vector2(-3f, 3f), ForceMode2D.Impulse);
                    // player.rigid.AddForce(new Vector2(-3f, 3f), ForceMode2D.Impulse);
                    //왼쪽으로 밀려남 
                }
            }
        }


        //몬스터가 움직이게 하는 코루틴 랜덤돌려서 행동을 정하고 자신 코루틴을 호출해서 3초마다 반복하게 한다 
        IEnumerator MoveCor()
        {
            yield return new WaitForSeconds(3f);
            if(this.transform.position.x > 14 || this.transform.position.x < -50 && !dieing)
        {
            startpositionrand = Random.Range(-50, 13);
            this.transform.position = new Vector2(startpositionrand, 3);
        }
            randomAct = Random.Range(0, 3);
            anim.SetBool("isMove", false);
            anim.SetBool("isIdle", false);
            StartCoroutine(MoveCor());
        }



        //몬스터가 죽고 젠시간이 되면 이 코루틴을 호출한다 
        IEnumerator RebirthCor()
        {

             yield return new WaitForSeconds(2f);
            this.transform.position = new Vector2(-500f, 5);
            anim.SetBool("isDie", false);
             currentHp = maxHp;
            yield return new WaitForSeconds(6.5f);
            dieing = false;
            startpositionrand = Random.Range(-50, 13);
            this.transform.position = new Vector2(startpositionrand, 3);


       }

        //몬스터가 사용자에게 공격을 받으면 이 코루틴을 호출한다 
        IEnumerator DamegedCor()
        {
            yield return new WaitForSeconds(0.5f);
            dameged = false;
            anim.SetBool("isDameged", false);
        }


   

    // 몬스터가 맞으면 호출되는 함수 
    // 에너미 인터페이스에 있기 때문에 그것을 상속받는 모든 몬스터에 있는 함수이다 
    // 캐릭터는 어떤 몬스터이든 때리면 그냥 이 함수를 실행하면 된다
    // 먼저 죽은 상태거나 맞은 상태라면 공격을 추가로 할 수 없기 때문에 체크해준다 
    // 그리고 상대방 공격력과 몬스터 방어력을 랜덤으로 돌린 다음에 
    // 공식을 계산하여 몬스터가 맞을 데미지를 계산해준다 
    public void Damged(long attackDamege)
        {

            //죽은 상태나 공격받고있는 상태가 아니라면 
            if (!dameged && !dieing)
            {
                 DamegedSound();
                //매개변수로 받은 상대 공격력, 자신의 방어력은 랜덤으로 돌려서 받은 데미지를 계산한다 
                damegeRand1 = (long)Random.Range(1, attackDamege + 1);
                defenceRand1 = (long)Random.Range(0, defence + 1);
                // 데미지 공식대로 계산하여 1 이상이 나오면 그만큼의 데미지를 받고 아니면 1의 데미지를 받는다 
                if ((long)((damegeRand1 - defenceRand1) * (float)(10000 / (10000 - defenceRand1))) > 0)
                {
                    UIManager.instance.effectCanvas.enemeyDamegedText[UIManager.instance.effectCanvas.enemyDamegedCount].transform.position = this.transform.position + new Vector3(0,1f,0);
                    UIManager.instance.effectCanvas.EnemyDameged((long)((damegeRand1 - defenceRand1) * (float)(10000 / (10000 - defenceRand1))));
                    currentHp -= (long)((damegeRand1 - defenceRand1) * (float)(10000 / (10000 - defenceRand1)));
                }
                else
                {
                    UIManager.instance.effectCanvas.enemeyDamegedText[UIManager.instance.effectCanvas.enemyDamegedCount].transform.position = this.transform.position + new Vector3(0, 1f, 0);
                    UIManager.instance.effectCanvas.EnemyDameged(1);
                    currentHp -= 1;
                }

                // 몬스터 체력바가 표시되는 코루틴 실행 
                StartCoroutine(HpBarCor());

                //공격을 받고 체력이 0이하로 내려가면 캐릭터에게 경험치 지급, 드랍 아이템 설정, 죽은 상태로 돌린다 
                if (currentHp <= 0)
                {
                      UIManager.instance.enemyHpPanel.gameObject.SetActive(false);
                    dieing = true;
                    anim.SetBool("isDie", true);
                    expRand1 = (long)Random.Range(1, exp);
                    CharacterManager.instance.GetExp(expRand1);
                    UIManager.instance.playCanvas.SystemMessageOutput("경험치를 " + expRand1 + "획득하였습니다.");


                   UIManager.instance.questWindow.MonsterHunting(name);
                    //랜덤을 돌려서 드랍 아이템의 확률보다 높은 값이 나오면 드랍을 한다 
                    // 드랍 방식은 UI매니저에 있는 드랍 아이템을 죽은 몬스터 위치에 등장시키고 그 아이템을 먹으면 다시 원래 있던 위치로 되돌린다
                    // 30개의 아이템이 미리 만들어져 있으며 차례대로 아이템이 드랍된다 
                    dropRand1 =(long)Random.Range(0, 1000000000000);
                    if(dropRand1 > 500000000000)
                    {
                    Debug.Log("1");
                        UIManager.instance.dropItem_JellyLeather[UIManager.instance.jellyLeatherCount].transform.position = this.transform.position;
                        UIManager.instance.dropItem_JellyLeather[UIManager.instance.jellyLeatherCount].dropIng = true;
                        UIManager.instance.dropItem_JellyLeather[UIManager.instance.jellyLeatherCount].Drop();
                        UIManager.instance.jellyLeatherCount++;
                    Debug.Log("2");
                    if (UIManager.instance.jellyLeatherCount >= 30)
                        {

                            UIManager.instance.jellyLeatherCount = 0;
                        }
                    }
                   dropRand2 = (long)Random.Range(0, 1000000000000);
                    if (dropRand2 > 500000000000)
                    {
                        if (dropRand2 > 999000000000)
                        {
                            dropRand3 = (long)Random.Range(0, dropMoney + 1) * 1000;
                        }
                        else
                        {
                            dropRand3 = (long)Random.Range(0, dropMoney + 1);
                        }
                    Debug.Log("3");
                    UIManager.instance.dropItem_dropMoney[UIManager.instance.dropMoneyCount].transform.position = this.transform.position + new Vector3(0.2f, 0.1f,0);
                        UIManager.instance.dropItem_dropMoney[UIManager.instance.dropMoneyCount].dropIng = true;
                        UIManager.instance.dropItem_dropMoney[UIManager.instance.dropMoneyCount].moneyPrice = dropRand3;
                        UIManager.instance.dropItem_dropMoney[UIManager.instance.dropMoneyCount].Drop();
                        UIManager.instance.dropMoneyCount++;
                    Debug.Log("4");
                    if (UIManager.instance.dropMoneyCount >= 30)
                        {
                            UIManager.instance.dropMoneyCount = 0;
                        }
                    }


                StartCoroutine(RebirthCor());
                }
                //죽지 않았다면 잠시동안 공격을 받지 않는 상태가 된다 
                else
                {
                    dameged = true;
                    anim.SetBool("isDameged", true);
                    StartCoroutine(DamegedCor());
                }
            }

        }
        
    // 이 몬스터가 맞는 사운드를 실행하는 함수  Dameged에서 호출해준다 
        public void DamegedSound()
    {

        SoundManager.instance.SoundEffectOn("JellyDamegedSound", SoundManager.instance.soundEffectNumber);
    }


    //몬스터 체력상태를 위에 띄우는 코루틴
    // 이것도 몬스터마다 체력 이미지가 다르기 때문에 모든 몬스터에 있는 코루틴
    // 이미지를 몬스터 초상화로 바꿔주고 몬스터의 현재 체력, 최대 체력을 출력해준 다음에 
    // 3초뒤에 안 보이는 상태로 돌려준다
        IEnumerator HpBarCor()
        {

            UIManager.instance.playCanvas.enemyImage.sprite = multisprite[0];
            if (currentHp < 0)
            {
                UIManager.instance.playCanvas.enemyHpText.text =   "0 / " + maxHp;
            }
            else
            {
                UIManager.instance.playCanvas.enemyHpText.text = currentHp + " / " + maxHp;
            }

            UIManager.instance.playCanvas.enemyHpBarSlider.value = (float)currentHp / maxHp;
            UIManager.instance.enemyHpPanel.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            UIManager.instance.enemyHpPanel.gameObject.SetActive(false);
        }

 
        public bool DieCheck()
    {

        if (dieing)
        {

            return true;

        }
        else
        {
            return false;
        }


    }

}
