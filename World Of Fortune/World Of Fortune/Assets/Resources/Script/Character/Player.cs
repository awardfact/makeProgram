using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer bodyRenderer;
    public SpriteRenderer headRenderer;
    public SpriteRenderer helmetRenderer;
    public SpriteRenderer weaponRenderer;
    public SpriteRenderer shieldRenderer;
    public SpriteRenderer leftLegRenderer;
    public SpriteRenderer rightLegRenderer;
    public Rigidbody2D rigid;

    public bool lookRight;
    ParticleSystem levelUpEffect;

    public long enemyAttackRand;
    public long characterDefenceRand;
    public long rand3;
    //튜토리얼 위치 x -50 ~ 10


    // Start is called before the first frame update
    void Start()
    {
        levelUpEffect = GameObject.Find("Effect").transform.Find("LevelUpEffect").gameObject.GetComponent<ParticleSystem>();
        anim = gameObject.GetComponent<Animator>();
        bodyRenderer = GameObject.Find("Player").transform.Find("body").gameObject.GetComponent<SpriteRenderer>();
        headRenderer = GameObject.Find("Player").transform.Find("body/Head").gameObject.GetComponent<SpriteRenderer>();
        helmetRenderer = GameObject.Find("Player").transform.Find("body/Head/Hat-Helmet").gameObject.GetComponent<SpriteRenderer>();
        weaponRenderer = GameObject.Find("Player").transform.Find("body/Weapon/Weapon-Sword").gameObject.GetComponent<SpriteRenderer>();
        shieldRenderer = GameObject.Find("Player").transform.Find("body/Shield/Weapon-Shield").gameObject.GetComponent<SpriteRenderer>();
        leftLegRenderer = GameObject.Find("Player").transform.Find("LeftLeg").gameObject.GetComponent<SpriteRenderer>();
        rightLegRenderer = GameObject.Find("Player").transform.Find("RightLeg").gameObject.GetComponent<SpriteRenderer>();
        rigid = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    // 맞는 애니메ㅅ이션이 끝나면 맞은 상태를 false로 바꿔주고 
    // 점프 애니메이션이 실행중인데 y축 힘이 들어가지 않으면 점프 상태를 false로 바꿔준다 
    public void Move()
    {
        /*   if (hitInfo = Physics2D.Raycast(this.transform.position + (Vector3.up * 0.1f), Vector2.down, 1f))
           {
               anim.applyRootMotion = true;
           }
           else anim.applyRootMotion = false; */


        /*   if (this.anim.GetCurrentAnimatorStateInfo(1).IsName("AttackLayer.LeftAttack") && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.93f)
           {
               anim.SetBool("isLeftAttack", false);
               CharacterManager.instance.isAttack = false;
               if (!CharacterManager.instance.lookRight)
               {
                   weaponRenderer.transform.localPosition = new Vector3(-0.4f, 0.3f, -2f);
                   shieldRenderer.transform.localPosition = new Vector3(0.4f, 0.1f ,0);
               }
               else
               {
                   weaponRenderer.transform.localPosition = new Vector3(0.4f, 0.3f, -2f);
                   shieldRenderer.transform.localPosition = new Vector3(-0.3f, 0.1f, 0);
               }

           }
           if (this.anim.GetCurrentAnimatorStateInfo(1).IsName("AttackLayer.RightAttack") && anim.GetCurrentAnimatorStateInfo(1).normalizedTime > 0.93f)
           {
               anim.SetBool("isRightAttack", false);
               CharacterManager.instance.isAttack = false;
               if (!CharacterManager.instance.lookRight)
               {
                   weaponRenderer.transform.localPosition = new Vector3(-0.4f, 0.3f, -2f);
                   shieldRenderer.transform.localPosition = new Vector3(0.4f, 0.1f, 0);
               }
               else
               {
                   weaponRenderer.transform.localPosition = new Vector3(0.4f, 0.3f, -2f);
                   shieldRenderer.transform.localPosition = new Vector3(-0.3f, 0.1f, 0);
               }

           }

           */

        if (this.anim.GetCurrentAnimatorStateInfo(2).IsName("DamegedLayer.Dameged") && anim.GetCurrentAnimatorStateInfo(2).normalizedTime > 0.99f)
        {
            anim.SetBool("isDameged", false);
            CharacterManager.instance.isDameged = false;
        }

        if (anim.GetBool("isJump") && rigid.velocity.y == 0)
        {
            anim.SetBool("isJump", false);
        }




        /*
            if (Mathf.Abs(rigid.velocity.x) < 0.1f)
                anim.SetBool("isMove", false);      


    */








    }

    // 오른쪽 키를 누르면 캐릭터의 방향을 오른쪽으로 이동시켜주고 무기, 방패 위치를 바꿔준다 그리고 캐릭터에게 오른쪽으로 힘을 가해서 이동시킨다 
    public void RightKey()
    {
        bodyRenderer.flipX = true;
        headRenderer.flipX = true;
        helmetRenderer.flipX = true;
        weaponRenderer.flipX = true;
        shieldRenderer.flipX = true;
        leftLegRenderer.flipX = true;
        rightLegRenderer.flipX = true;

        if (!CharacterManager.instance.lookRight)
        {
            CharacterManager.instance.lookRight = true;
            //    Shield.transform.localPosition = this.transform.position;
            weaponRenderer.transform.localPosition += new Vector3(0.8f, 0, 0);
            shieldRenderer.transform.localPosition += new Vector3(-0.7f, 0, 0);
            //    shieldPsoition.localPosition += new Vector3(-0.8f, 0, 0);

        }
        //         if (Mathf.Abs(rigid.velocity.x) < speed)
        //       {
        //  rigid.velocity = Vector2.right;
        //       rigid.transform.Translate(rigid.velocity * speed * Time.deltaTime);
        // rigid.AddForce(Vector2.right * speed , ForceMode2D.Force);
        this.transform.position += Vector3.right * CharacterManager.instance.moveSpeed * Time.deltaTime;
        //     }

    }


    public void LeftKey()
    {


        bodyRenderer.flipX = false;
        headRenderer.flipX = false;
        helmetRenderer.flipX = false;
        weaponRenderer.flipX = false;
        shieldRenderer.flipX = false;
        leftLegRenderer.flipX = false;
        rightLegRenderer.flipX = false;
        if (CharacterManager.instance.lookRight)
        {
            CharacterManager.instance.lookRight = false;
            //  Shield.transform.localPosition = this.transform.position;
            weaponRenderer.transform.localPosition += new Vector3(-0.8f, 0, 0);
            shieldRenderer.transform.localPosition += new Vector3(0.7f, 0, 0);
            //   shieldPsoition.localPosition += new Vector3(0.8f, 0, 0);

        }
        //       if (Mathf.Abs(rigid.velocity.x) < speed)
        //      {
        //  rigid.velocity = -Vector2.right;
        //  rigid.AddForce(-Vector2.right * speed,ForceMode2D.Force);
        this.transform.position += -Vector3.right * CharacterManager.instance.moveSpeed * Time.deltaTime;
        //      }




    }

    // 점프키를 누르면 현재 점프 상태가 아니라면 점프 상태로 바꿔주고 위쪽으로 힘을 가해준다 
    public void JumpKey()
    {


        if (!(anim.GetBool("isJump")))
        {

            rigid.AddForce(new Vector2(0, CharacterManager.instance.jumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJump", true);


        }


    }

    // 공격키를 누르면 왼쪽을 바라보는 상태라면 왼쪽 공격을 실행하고 오른쪽을 바라보고 있으면 오른쪽 공격을 실행한다 
    public void AttackKey()
    {
        //왼쪽 바라볼때 
        if (!CharacterManager.instance.lookRight)
        {
            anim.SetBool("isLeftAttack", true);
            CharacterManager.instance.isAttack = true;

        }

        //오른쪽 바라볼때 
        else if (CharacterManager.instance.lookRight)
        {
            anim.SetBool("isRightAttack", true);
            CharacterManager.instance.isAttack = true;

        }




    }

    // 캐릭터가 맞았을 때 적 오브젝트에서 이 함수를 호출한다 호출할 때 적의 공격력을 넘기는데
    //먼저 캐릭터가 맞을 수 있는 상태인지 체크한다 (공격 받고있는지, 죽은 상태인지)
    // 그리고 적 공격력과 캐릭터의 방어력을 랜덤으로 돌린다 
    // 그 다음에 공격력과 방어력을 가지고 공식을 돌려 캐릭터가 받는 데미지 값을 계산한다 만약 1 이하면 그냥 1 로 한다 
    // 그리고 캐릭터에게 데미지를 가하고 , 맞는 소리 실행, 캐릭터가 맞는 상태로 만들어주고 체력바 초기화시켜준다 

    public void Dameged(long AttackDamege)
    {
        if (!CharacterManager.instance.isDameged && !CharacterManager.instance.isDie)
        {
            SoundManager.instance.SoundEffectOn("CharacterDamegedSound", SoundManager.instance.soundEffectNumber);
            characterDefenceRand = (long)Random.Range(0, CharacterManager.instance.defence + 1);
            enemyAttackRand = (long)Random.Range(1, AttackDamege + 1);

            if ((long)((enemyAttackRand - characterDefenceRand) * (float)((10000 / (10000 - characterDefenceRand)))) > 0)
            {
                UIManager.instance.effectCanvas.playerDamegedText[UIManager.instance.effectCanvas.playerDamegedCount].transform.position = this.transform.position + new Vector3(0, 1f, 0);
                UIManager.instance.effectCanvas.PlayerDameged((long)((enemyAttackRand - characterDefenceRand) * (float)((10000 / (10000 - characterDefenceRand)))));
                CharacterManager.instance.HP -= (long)((enemyAttackRand - characterDefenceRand) * (float)((10000 / (10000 - characterDefenceRand))));
            }
            else
            {
                UIManager.instance.effectCanvas.playerDamegedText[UIManager.instance.effectCanvas.playerDamegedCount].transform.position = this.transform.position + new Vector3(0, 1f, 0);
                UIManager.instance.effectCanvas.PlayerDameged(1);
                CharacterManager.instance.HP -= 1;
            }
            anim.SetBool("isDameged", true);
            // 캐릭터의 체력이 0 이하로 내려가면 캐릭터 상태를 죽은 상태로 바꿔준다 
            if(CharacterManager.instance.HP <= 0)
            {

                anim.SetBool("isDile", true);
                UIManager.instance.diePanel.gameObject.SetActive(true);
                CharacterManager.instance.isDie = true;


            }
            CharacterManager.instance.isDameged = true;
            UIManager.instance.playCanvas.HPBarRefresh();

        }

    }

    // 캐릭터가 레벨업을 하면 레벨업 이펙트를 보여주는데 이펙트의 위치를 캐릭터 위치로 해주고 
    // Level up이라는 글자도 캐릭터 위치로 올린다음에 화면에 띄운다 그리고 2초 뒤에 다시 보이지 않게 한다 
    public void LevelUpEffect()
    {
        levelUpEffect.transform.position = this.transform.position;
        StartCoroutine(LevelUPTextCor());
        levelUpEffect.Play();
    }

    IEnumerator LevelUPTextCor()
    {
        UIManager.instance.effectCanvas.levelUPText.transform.position = this.transform.position + new Vector3(0, 5f, 0);
        UIManager.instance.effectCanvas.levelUPText.text = "Level UP !!";
        yield return new WaitForSeconds(2f);
        UIManager.instance.effectCanvas.levelUPText.text = "";
    }

    public void itemGet(string itemName)
    {




    }
}
