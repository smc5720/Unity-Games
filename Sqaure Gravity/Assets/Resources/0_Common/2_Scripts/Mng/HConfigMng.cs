#define D_H_KOR_LANGUAGE
//#define D_H_CHINA_LANGUAGE



using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 위치 :  0_Mngs
/// 환경설정 메니져입니다
/// 해상도/다국어등
/// </summary>
public class HConfigMng : MonoBehaviour
{
    private static HConfigMng m_Instance = null;
    public static HConfigMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(HConfigMng)) as HConfigMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HConfigMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    /// <summary>
    /// 다국어 버젼 관련
    /// </summary>
    public Dictionary<E_H_MULTILANGUAGE_KIND, List<string>> MultiLanguageList;
    public List<string> MessageTextList = null;


    /// <summary>
    /// 화면 넓이 높이 사이즈 및 비율 저장 변수
    /// </summary>
    public int nScreenWidth = 0;
    public int nScreenHeight = 0;
    public AspectRatio Ratio = AspectRatio.Aspect16by10;
    public Vector3 RatioScaleVec = Vector3.zero;
    public Vector3 DRatioScaleVec = Vector3.zero;
    public int nFrameRate = 30;
    public bool bRunInBackground = true;


    // Use this for initialization
    void Awake()
    {
        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);      

        //////////////////////////////////////////////////////////////////////////
        // 다국어 관련 메모리 할당
        //////////////////////////////////////////////////////////////////////////
        MultiLanguageList = new Dictionary<E_H_MULTILANGUAGE_KIND, List<string>>();

        MessageTextList = new List<string>();
        //////////////////////////////////////////////////////////////////////////

        // 화면비율 계산하기 위해
        Ratio = AspectRatios.GetAspectRatio();
        SetHRadtio();

        //! 이렇게 하면 화면이 16:10 비율로 나오는군요 아직 버튼은 확인 안해봤어요!
        //! 핸펀이 필요해요^^ 앗 그리고 옛날 핸드폰에서는 SetResolution이 안 먹는군요 이런 된장
        //Screen.SetResolution(1280, (1280 / 16) * 10, true);        
        //Screen.SetResolution(800, 480, true);
        //! 절전모드로 안들어가게 함입니다
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.runInBackground = bRunInBackground;
        Application.targetFrameRate = nFrameRate;

        nScreenWidth = Screen.width;
        nScreenHeight = Screen.height;

        InitMultiLanguage();

        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }


    /// <summary>
    /// 다중언어 설정
    /// </summary>
    void InitMultiLanguage()
    {
#if D_H_KOR_LANGUAGE
        //////////////////////////////////////////////////////////////////////////
        MessageTextList.Add("로그인 체크중...");//!0 
        MessageTextList.Add("네트워크 접속을 실패하였습니다.");//!1
        MessageTextList.Add("로그아웃중... 잠시후 다시 접속해주세요!");//!2 
        MessageTextList.Add("기타 설정중...");//!3  
        MessageTextList.Add("로그인 처리중...");//!4
        MessageTextList.Add("로그인 버튼을 클릭해 주세요!");//!5
        MessageTextList.Add("내 정보 가져오는중...");//!6
        MessageTextList.Add("로그인 처리가 되지 않았습니다.");//!7
        MessageTextList.Add("정말로 능력치를 재분배 하시겠습니까?");//!8
        MessageTextList.Add("한번 결정된 능력치는 되돌릴 수 없습니다.");//!9
        MessageTextList.Add("방의 설정이 바뀌어 준비가 해제 되었습니다.");//!10
        MessageTextList.Add("서버에 접속할 수 없습니다.");//!11
        MessageTextList.Add("재시도 하시겠습니까?");//!12
        MessageTextList.Add("게임 진행 도중 나가시면 보상을 얻을 수 없습니다.");//!13
        MessageTextList.Add("구매 하시 겠습니까?");//!14
        MessageTextList.Add("보유한 잼이 부족합니다.");//!15
        MessageTextList.Add("충전하시겠습니까?");//!16
        MessageTextList.Add("정말로 강제 퇴장 시키시겠습니까?");//!17
        MessageTextList.Add("게임이 진행중인 방에는 입장할 수 없습니다.");//!18
        MessageTextList.Add("인벤토리 공간이 부족합니다.");//!19
        MessageTextList.Add("티켓이 부족합니다.");//!20
        MessageTextList.Add("축하합니다.");//!21
        MessageTextList.Add("랭크가 올랐습니다.");//!22
        MessageTextList.Add("친구를 찾을 수 없습니다.");//!23
        MessageTextList.Add("조건에 맞는 게임을 검색중입니다.");//!24
        MessageTextList.Add("검색완료 게임이 시작됩니다.");//!25
        MessageTextList.Add("서버가 혼잡합니다.");//!26
        MessageTextList.Add("잠시 후 다시 시도해 주세요");//!27
        MessageTextList.Add("게임 서버 로그인중...");//!28
        MessageTextList.Add("서버에 접속중...");//!29
        MessageTextList.Add("로그 아웃중 잠시 후 다시 시도해 주세요!");//!30
        MessageTextList.Add("친구 목록 가져 오는중...");//!31
        MessageTextList.Add("이미 접속되어져 있습니다.");//!32
        MessageTextList.Add("사용할 닉네임을 입력해 주세요");//!33
        MessageTextList.Add("영어와 숫자 조합 3~6자 이내로 입력해주세요");//!34=  
        MessageTextList.Add("캐릭터를 선택해 주세요");//!35
        MessageTextList.Add("게임 서버에 접속중 입니다.");//!36
        MessageTextList.Add("접속장애로 인해 실패 했습니다.");//!37
        MessageTextList.Add("잠시후 다시 시도해 주세요!");//!38
        MessageTextList.Add("인증실패 했습니다");//!39
        MessageTextList.Add("다시 시도해 주세요");//!40
        MessageTextList.Add("다시 시도하시겠습니까?");//!41
        MessageTextList.Add("금액이 부족합니다.");//!42
        MessageTextList.Add("성공적으로 구매하였습니다.");//!43
        MessageTextList.Add("성공적으로 판매하였습니다.");//!44
        MessageTextList.Add("강화 재료가 부족합니다.");//!45
        MessageTextList.Add("강화 최대 입니다.");//!46
        MessageTextList.Add("게임의 새로운 버전이 나왔습니다.");//!47
        MessageTextList.Add("스토어에서 업데이트 해주세요");//!48
        MessageTextList.Add("게임을 종료하시겠습니까?");//!49
        MessageTextList.Add("티켓을 발송하였습니다.");//!50
        MessageTextList.Add("모든 정보가 사라집니다.");//!51
        MessageTextList.Add("탈퇴 하시겠습니까?");//!52
        MessageTextList.Add("다른 기기에서 접속하여");//!53
        MessageTextList.Add("연결을 해제합니다.");//!54
        MessageTextList.Add("슬롯 공간이 부족합니다.");//!55
        MultiLanguageList.Add(E_H_MULTILANGUAGE_KIND.E_MESSAGE, MessageTextList);

#endif

#if D_H_CHINA_LANGUAGE
        
#endif
    }

    /// <summary>
    /// 비율에 따른 스케일 값 설정 변수 입니다
    /// </summary>
    public void SetHRadtio()
    {
        Debug.Log("Current RAspectRatio : " + AspectRatios.GetAspectRatio());

        switch (AspectRatios.GetAspectRatio())
        {
            case AspectRatio.Aspect4by3:        //! 옵티머스뷰
                RatioScaleVec.x = 1.2f;
                RatioScaleVec.y = 1.4f;
                RatioScaleVec.z = 1.0f;
                break;

            case AspectRatio.Aspect5by4:
                RatioScaleVec.x = 1.4f;
                RatioScaleVec.y = 1.4f;
                RatioScaleVec.z = 1.0f;
                break;

            case AspectRatio.Aspect16by9:
                RatioScaleVec.x = 1.4f;
                RatioScaleVec.y = 1.4f;
                RatioScaleVec.z = 1.0f;
                break;

            case AspectRatio.Aspect16by10:
                RatioScaleVec.x = 1.4f;
                RatioScaleVec.y = 1.4f;
                RatioScaleVec.z = 1.0f;
                break;

            case AspectRatio.Aspect3by2:
                RatioScaleVec.x = 1.2f;
                RatioScaleVec.y = 1.3f;
                RatioScaleVec.z = 1.0f;
                break;

            case AspectRatio.AspectCustom1280x752:
                RatioScaleVec.x = 1.4f;
                RatioScaleVec.y = 1.4f;
                RatioScaleVec.z = 1.0f;
                break;

            case AspectRatio.AspectCustom1024x600:
                RatioScaleVec.x = 1.4f;
                RatioScaleVec.y = 1.4f;
                RatioScaleVec.z = 1.0f;
                break;

            case AspectRatio.AspectCustom800x480:
                RatioScaleVec.x = 1.4f;
                RatioScaleVec.y = 1.4f;
                RatioScaleVec.z = 1.0f;
                break;

            case AspectRatio.AspectOthers:
                RatioScaleVec.x = 1.4f;
                RatioScaleVec.y = 1.4f;
                RatioScaleVec.z = 1.0f;
                break;
        }
    }

  
    /// <summary>
    /// 화면에 출력할 내용 얻어오기
    /// </summary>
    /// <param name="eKind">종류</param>
    /// <param name="nNum">번호</param>
    /// <returns>출력할 내용</returns>
    public string GetMultiLanguageText(E_H_MULTILANGUAGE_KIND eKind, int nNum)
    {
        if (nNum <= -1)
        {
            Debug.Log("nNum is  <= -1 [GetMultiLanguageText/HConfigMng.cs]");
            return "";
        }

        if (MultiLanguageList[eKind].Count == nNum)
        {
            Debug.Log("Count == nNum  [GetMultiLanguageText/HConfigMng.cs]");
            return "";
        }

        return MultiLanguageList[eKind][nNum];
    }
}
