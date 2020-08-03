using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    public AudioSource bgm;
    public AudioClip bgmClip;

    public AudioSource[] soundEffect = new AudioSource[30];
    public AudioClip[] soundEffectClip = new AudioClip[30];
    public int soundEffectNumber;



    public AudioSource[] staySoundEffect = new AudioSource[5];
    public AudioClip[] staySoundEffectClip = new AudioClip[5];
    public string[] staySoundEffectName = new string[5];
    public int staySoundEffectNumber;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        soundEffectNumber = 0;
        staySoundEffectNumber = 0;
        for (int i = 0; i < 30; i++)
            soundEffect[i] = transform.Find("SoundEffect_" + (i + 1)).gameObject.GetComponent<AudioSource>();
       for(int i = 0; i < 5; i++)
            staySoundEffect[i] = transform.Find("StaySoundEffect_" + (i + 1)).gameObject.GetComponent<AudioSource>();
        bgm = transform.Find("BGMSource").gameObject.GetComponent<AudioSource>(); 
        bgmClip = Resources.Load("Sound/BGM/CharacterSelectBGM", typeof(AudioClip)) as AudioClip;
        bgm.clip = bgmClip;
        bgm.volume = 0.3f;
        bgm.loop = true;
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // 맵을 이동할때 BGM을 바꿔준다 
    //매개변수로 BGM이름을 받고 그 이름으로 파일을 찾아서 넣는다 그리고 반복재생이기 때문에 loop를 true로 해주고 실행시킨다 
    public void BGMChange(string BGMName)
    {
        bgmClip = Resources.Load("Sound/BGM/" + BGMName, typeof(AudioClip)) as AudioClip;
        bgm.clip = bgmClip;
        bgm.loop = true;
        bgm.volume = 0.3f;
        bgm.Play();
    }

    public void SoundEffectOn(string SoundEffectName, int SoundEffectNumber)
    {


        StartCoroutine(SoundEffectCor(SoundEffectName, SoundEffectNumber));

    }



    // 단발성 효과음이 필요할 때 이 코루틴을 호출해준다 동시에 30개까지 가능 
    // 매개변수로 사운드 이름과 효과음 배열 넘버를 받는다 
    // 사운드 이름을 통해 파일을 찾아 사운드 클립에 넣고 클립을 소스에 넣어서 사운드를 적용한다
    // 그리고 사운드를 실행시킨다음에 배열 넘버를 올린다 
    // 배열 넘버를 올려서 이 배열의 사운드를 중지시키면 이상한 사운드를 중지시키는 것이 되기 떄문에
    // 매개변수로 미리 현재 배열 넘버를 받는다 매개변수로 받은 배열 넘버의 사운드를 중지시키면 여기서 실행한 배열 사운드를 중지하게 된다
    // 사운드는 1.5초동안 실행하고 중지시킨다 
    IEnumerator SoundEffectCor(string SoundEffectName_C, int SoundEffectNumber_C)
    {
        soundEffectClip[soundEffectNumber] = Resources.Load("Sound/Sound_Effect/" + SoundEffectName_C, typeof(AudioClip)) as AudioClip;
        soundEffect[soundEffectNumber].clip = soundEffectClip[soundEffectNumber];

        soundEffect[soundEffectNumber].Play();
        soundEffectNumber++;

        if (soundEffectNumber >= 30)
        {
            soundEffectNumber = 0;
        }
        yield return new WaitForSeconds(1.5f);
        soundEffect[SoundEffectNumber_C].Stop();
    }

    //지속되는 효과음이 필요할 때 이 함수를 호출 동시에 최대 5개
    // 매개변수로 사운드 이름과 soundManager의 staySound의 배열 넘버를 받아서
    // 파일에서 매개변수로 받은 사운드 이름을 찾아 클립에 넣고 소스에 클립을 넣어 사운드를 넣고
    // 지속 사운드여서 루프를 실행시키고 사운드를 실행한다 그리고 배열 넘버를 추가시킨다(겹치는거 방지)
    public void StaySoundEffectON(string soundEffectName, int StaySoundEffectNumber)
    {
        staySoundEffectClip[staySoundEffectNumber] = Resources.Load("Sound/Sound_Effect/" + soundEffectName, typeof(AudioClip)) as AudioClip;
        staySoundEffect[staySoundEffectNumber].clip = staySoundEffectClip[staySoundEffectNumber];
        staySoundEffect[staySoundEffectNumber].loop = true;

        staySoundEffect[staySoundEffectNumber].Play();
        staySoundEffectName[staySoundEffectNumber] = soundEffectName;

        staySoundEffectNumber++;

        if (staySoundEffectNumber >= 5)
        {
            staySoundEffectNumber = 0;
        }
    }
    //지속되는 효과음을 종료할 때 이 함수를 호출 
    //실행시켰던 사운드 소스를 종료시킨다 
    public void StaySoundEffectOFF(string soundEffectName)
    {
        for(int i = 0; i < 5; i++)
        {
            if (staySoundEffectName[i] == soundEffectName)
                staySoundEffect[i].Stop();
        }
    }
}
