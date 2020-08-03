using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public bool isAttack;

    [SerializeField]
    Animator anim;
    Player player;
    // Start is called before the first frame update

    ParticleSystem basicAttaackEffect;

    public long attackDamegeRand;
    public long attackDamege;

    void Start()
    {
        player = GameObject.Find("Player").gameObject.GetComponent<Player>();
        basicAttaackEffect = GameObject.Find("Effect").transform.Find("BasicAttackEffect").gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 무기와 다른 사물이 충돌 했을 때 실행하는 스크립트 
    // 충돌 대상이 적인지 , 지금 평타 공격중인지, 적이 죽은 상태가 아닌지를 체크한 다음에 
    // 적이 맞을 수 있는 상태이면 적을 방향에 따라 오른쪽이나 왼쪽으로 살짝 밀려나게 하고 
    // 충돌 이펙트를 실행한 다음에 자신의 공격력을 매개변수로 해서 적이 맞는 함수를 실행시킨다 
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && CharacterManager.instance.attackName == "BasicAttack" && !col.gameObject.GetComponent<Enemy>().DieCheck())
        {
            if (CharacterManager.instance.isAttack)
            {
                if (CharacterManager.instance.lookRight)
                {
                    // 오른쪽으로 밀려남
                //    col.gameObject.GetComponent<Collider>().rigid.AddForce(new Vector2(5f, 2f), ForceMode2D.Impulse);
                      col.attachedRigidbody.AddForce(new Vector2(2f, 2f), ForceMode2D.Impulse);
                }
                else
                {
                     col.attachedRigidbody.AddForce(new Vector2(-2f, 2f), ForceMode2D.Impulse);
                    //왼쪽으로 밀려남 
                }
                basicAttaackEffect.transform.position = col.transform.position;
                basicAttaackEffect.Play();
                attackDamege = (long)(CharacterManager.instance.power * (float)((100 + CharacterManager.instance.basicAttackMultiple) / 100));
                col.gameObject.GetComponent<Enemy>().Damged(attackDamege);
            }
        }

    }
}
