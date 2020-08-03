using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy 
{
    // 모든 몬스터는 이 스크립트를 상속받는다 

    // 캐릭터가 어떤 몬스터를 쳤을 때 어떤 몬스터인지 체크할 필요를 없게 하기 위해 모든 몬스터가 동일한 함수를 가지게 하기 위함 


    // 몬스터가 맞았ㅇㄹ 때 캐릭터가 호출하는 ㅇ함수 
    void Damged(long attackDamege);

   
    bool DieCheck();

    // 맞은 몬스터마다 소리가 다르기 때문에 Dameged에서 이 함수를 호출해준다 
    void DamegedSound();



}
