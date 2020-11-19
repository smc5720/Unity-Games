using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 위치 :  0_Mngs
/// 프리팹 생성 삭제 관련 메니져입니다
/// </summary>
public class HPrefabMng : MonoBehaviour
{
    private static HPrefabMng m_Instance = null;
    public static HPrefabMng I
    {
        get
        {
            if (null == m_Instance)
            {
                m_Instance = FindObjectOfType(typeof(HPrefabMng)) as HPrefabMng;

                if (null == m_Instance)
                {
#if _debug
                    Debug.Log("Fail to get Manager Instance [HPrefabMng.cs]");
#endif
                    return null;
                }
            }
            return m_Instance;
        }
    }

    /// <summary>
    /// 공통으로 쓰여지는 리소스 리스트입니다(경고창 같은 종류들)
    /// </summary>
    public List<GameObject> ResourceList = null;

    /// <summary>
    /// 만들어진 프리펩 GameObject 임시 저장 장소
    /// </summary>
    public Dictionary<string, GameObject> CreatePrefabsList = null;

    /// <summary>
    /// 팝업으로 만들어진 프리팹 이름만 저장
    /// </summary>
    public List<string> CreatePopupPrefabsNameList = null;

    private float PopupBasicDepth = -40.0f;
    private float PopupDepth = -30.0f;

    void Awake()
    {
        CreatePrefabsList = new Dictionary<string, GameObject>();
        ResourceList = new List<GameObject>();

        CreatePopupPrefabsNameList = new List<string>();

        if (m_Instance == null)
            m_Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public GameObject CreatePrefab(E_H_RESOURCELOAD eResourceLoadPos, string sPrefabName, Vector3 vPos, Vector3 vScale, string sTitleName = "", string sAddComponent = "")
    {
        GameObject CretaePrefabGame = null;

        if (bOverLapGameObject(sPrefabName, sTitleName))
        {
#if _debug
                Debug.Log("OverLapGameObject return null [CreatePrefab/HPrefabMng.cs]");
#endif
            return null;
        }

        // 9_Room씬일때에만 이렇게 합니다
        //if (Application.loadedLevelName == "9_Room")
        //{
        //    eResourceLoadPos = E_H_RESOURCELOAD.E_ROOMSCENE;
        //}

        List<GameObject> Resource = GetReousrceList(sPrefabName, eResourceLoadPos);

        if (Resource != null)
        {
            foreach (GameObject obj in Resource)
            {
                if (obj.transform.name == sPrefabName)
                {
                    CretaePrefabGame = Instantiate(obj) as GameObject;

                    if (sAddComponent != "")
                        CretaePrefabGame.AddComponent(sAddComponent);

                    if (sTitleName != "")
                        CretaePrefabGame.transform.name = sTitleName + "(Clone)";

                    CretaePrefabGame.transform.localPosition = vPos;
                    CretaePrefabGame.transform.localScale = vScale;

                    //! 만들어진 프리펩 윈도우를 List에 추가합니다.
                    CreatePrefabsList.Add(CretaePrefabGame.transform.name, CretaePrefabGame);

                    return CretaePrefabGame;
                }
            }
#if _debug
            Debug.Log(" No Find PrefabName ->" + sPrefabName + " [CreatePrefab/HPrefabMng.cs]");
#endif
        }
        else
        {
#if _debug
            Debug.Log(" NULL Resource [CreatePrefab/HPrefabMng.cs]");
#endif
        }
        return null;
    }


    public GameObject CreatePrefab(GameObject ParentGame, E_H_RESOURCELOAD eResourceLoadPos, string sPrefabName, float fZPos = -1.0f, string sTitleName = "", string sAddComponent = "")
    {
        GameObject CretaePrefabGame = null;

        if (ParentGame)
        {
            if (bOverLapGameObject(sPrefabName, sTitleName))
            {
#if _debug
                Debug.Log("sTitleName :"+sTitleName + " OverLapGameObject return null [CreatePrefab/HPrefabMng.cs]");
#endif
                return null;
            }

            // 9_Room씬일때에만 이렇게 합니다
            //if (Application.loadedLevelName == "9_Room")
            //{
            //    eResourceLoadPos = E_H_RESOURCELOAD.E_ROOMSCENE;
            //}

            List<GameObject> Resource = GetReousrceList(sPrefabName, eResourceLoadPos);

            if (Resource != null)
            {
                foreach (GameObject obj in Resource)
                {
                    if (obj.transform.name == sPrefabName)
                    {
                        CretaePrefabGame = Instantiate(obj) as GameObject;

                        if (sAddComponent != "")
                            CretaePrefabGame.AddComponent(sAddComponent);

                        if (sTitleName != "")
                            CretaePrefabGame.transform.name = sTitleName + "(Clone)";

                        CretaePrefabGame.transform.parent = ParentGame.transform;                   //!< 자식으로 넣는거죠
                        CretaePrefabGame.transform.localPosition = new Vector3(0.0f, 0.0f, fZPos);

                        CretaePrefabGame.transform.localScale = Vector3.one;

                        //! 만들어진 프리펩 윈도우를 List에 추가합니다.
                        CreatePrefabsList.Add(CretaePrefabGame.transform.name, CretaePrefabGame);

                        return CretaePrefabGame;
                    }
                }
#if _debug
            Debug.Log(" No Find PrefabName ->" + sPrefabName + " [CreatePrefab/HPrefabMng.cs]");
#endif
            }
            else
            {
#if _debug
            Debug.Log(" NULL Resource [CreatePrefab/HPrefabMng.cs]");
#endif
            }
        }
        return null;
    }


    public GameObject CreatePrefab(string sParentName, E_H_RESOURCELOAD eResourceLoadPos, string sPrefabName, float fZPos = -1.0f, string sTitleName = "", string sAddComponent = "")
    {
        GameObject ParentGame = GameObject.Find(sParentName);
        GameObject CretaePrefabGame = null;

        if (ParentGame)
        {
            if (bOverLapGameObject(sPrefabName, sTitleName))
            {
#if _debug
                Debug.Log("sTitleName is "+sTitleName + "/sPrefabName is " + sPrefabName + "/OverLapGameObject return null [CreatePrefab/HPrefabMng.cs]");
#endif
                return null;
            }

            //// 9_Room씬일때에만 이렇게 합니다
            //if (Application.loadedLevelName == "9_Room")
            //{
            //    eResourceLoadPos = E_H_RESOURCELOAD.E_ROOMSCENE;
            //}

            List<GameObject> Resource = GetReousrceList(sPrefabName, eResourceLoadPos);

            if (Resource != null)
            {
                foreach (GameObject obj in Resource)
                {
                    if (obj.transform.name == sPrefabName)
                    {
                        CretaePrefabGame = Instantiate(obj) as GameObject;
                        Debug.Log(CretaePrefabGame);
                        if (sAddComponent != "")
                            CretaePrefabGame.AddComponent(sAddComponent);

                        if (sTitleName != "")
                            CretaePrefabGame.transform.name = sTitleName + "(Clone)";

                        CretaePrefabGame.transform.parent = ParentGame.transform;                   //!< 자식으로 넣는거죠
                        CretaePrefabGame.transform.localPosition = new Vector3(0.0f, 0.0f, fZPos);

                        CretaePrefabGame.transform.localScale = Vector3.one;

                        //! 만들어진 프리펩 윈도우를 List에 추가합니다.
                        CreatePrefabsList.Add(CretaePrefabGame.transform.name, CretaePrefabGame);

                        return CretaePrefabGame;
                    }
                }
#if _debug
            Debug.Log(" No Find PrefabName ->" + sPrefabName + " [CreatePrefab/HPrefabMng.cs]");
#endif
            }
            else
            {
#if _debug
            Debug.Log(" NULL Resource [CreatePrefab/HPrefabMng.cs]");
#endif
            }
        }
        else
        {
#if _debug
        Debug.Log("ParentGame is NULL [CreatePrefab/HPrefabMng.cs]");
#endif
        }

        return null;
    }

    public GameObject CreatePrefab(string sParentName, E_H_RESOURCELOAD eResourceLoadPos, string sPrefabName, Vector3 PosVec, Vector3 ScaleVec, string sTitleName = "", string sAddComponent = "")
    {
        GameObject ParentGame = GameObject.Find(sParentName);
        GameObject CretaePrefabGame = null;

        if (ParentGame)
        {
            if (bOverLapGameObject(sPrefabName, sTitleName))
            {
                Debug.Log(sPrefabName);
                return null;
            }

            List<GameObject> Resource = GetReousrceList(sPrefabName, eResourceLoadPos);

            if (Resource != null)
            {
                foreach (GameObject obj in Resource)
                {
                    if (obj.transform.name == sPrefabName)
                    {
                        CretaePrefabGame = Instantiate(obj) as GameObject;

                        if (sAddComponent != "")
                            CretaePrefabGame.AddComponent(sAddComponent);

                        if (sTitleName != "")
                            CretaePrefabGame.transform.name = sTitleName + "(Clone)";

                        CretaePrefabGame.transform.parent = ParentGame.transform;  //!< 자식으로 넣는거죠
                        CretaePrefabGame.transform.localPosition = PosVec;
                        CretaePrefabGame.transform.localScale = ScaleVec;

                        //! 만들어진 프리펩 윈도우를 List에 추가합니다.
                        CreatePrefabsList.Add(CretaePrefabGame.transform.name, CretaePrefabGame);

                        return CretaePrefabGame;
                    }
                }

#if _debug
            Debug.Log(" No Find PrefabName ->" + sPrefabName + " [CreatePrefab/HPrefabMng.cs]");
#endif

            }
            else
            {
#if _debug
            Debug.Log(" NULL Resource [CreatePrefab/HPrefabMng.cs]");
#endif
            }
        }
        else
        {
#if _debug
        Debug.Log("ParentGame is NULL [CreatePrefab/HPrefabMng.cs]");
#endif
        }

        return null;
    }

    public GameObject CreatePopupPrefab(string sParentName, E_H_RESOURCELOAD eResourceLoadPos, string sPrefabName, string sTitleName = "", string sAddComponent = "")
    {
        float fZPos = CreatePopupPrefabsNameList.Count * PopupDepth + PopupBasicDepth;

        GameObject ParentGame = GameObject.Find(sParentName);
        GameObject CretaePrefabGame = null;

        if (ParentGame)
        {
            if (bOverLapGameObject(sPrefabName, sTitleName))
            {
#if _debug
                Debug.Log("sTitleName is "+sTitleName + "/sPrefabName is " + sPrefabName + "/OverLapGameObject return null [CreatePrefab/HPrefabMng.cs]");
#endif
                return null;
            }

            //// 9_Room씬일때에만 이렇게 합니다
            //if (Application.loadedLevelName == "9_Room")
            //{
            //    eResourceLoadPos = E_H_RESOURCELOAD.E_ROOMSCENE;
            //}

            List<GameObject> Resource = GetReousrceList(sPrefabName, eResourceLoadPos);

            if (Resource != null)
            {
                foreach (GameObject obj in Resource)
                {
                    if (obj.transform.name == sPrefabName)
                    {
                        CretaePrefabGame = Instantiate(obj) as GameObject;

                        if (sAddComponent != "")
                            CretaePrefabGame.AddComponent(sAddComponent);

                        if (sTitleName != "")
                            CretaePrefabGame.transform.name = sTitleName + "(Clone)";

                        CretaePrefabGame.transform.parent = ParentGame.transform;                   //!< 자식으로 넣는거죠
                        CretaePrefabGame.transform.localPosition = new Vector3(0.0f, 0.0f, fZPos);

                        CretaePrefabGame.transform.localScale = Vector3.one;

                        //! 만들어진 프리펩 윈도우를 List에 추가합니다.
                        CreatePrefabsList.Add(CretaePrefabGame.transform.name, CretaePrefabGame);

                        CreatePopupPrefabsNameList.Add(CretaePrefabGame.transform.name);

                        return CretaePrefabGame;
                    }
                }
#if _debug
            Debug.Log(" No Find PrefabName ->" + sPrefabName + " [CreatePrefab/HPrefabMng.cs]");
#endif
            }
            else
            {
#if _debug
            Debug.Log(" NULL Resource [CreatePrefab/HPrefabMng.cs]");
#endif
            }
        }
        else
        {
#if _debug
        Debug.Log("ParentGame is NULL [CreatePrefab/HPrefabMng.cs]");
#endif
        }

        return null;
    }

    public GameObject CreateMessagePopupPrefab(string sParentName, string sAddComponent, Vector3 PosVec, int nMsgNum1 = -1, int nMsgNum2 = -1, bool bWarringSpriteShow = true, E_H_POPUPWINDOWTYPE eBtnType = E_H_POPUPWINDOWTYPE.E_OK_CALCEL)
    {
        float fZPos = CreatePopupPrefabsNameList.Count * PopupDepth + PopupBasicDepth;
        PosVec.z = fZPos;

        GameObject ParentGame = GameObject.Find(sParentName);
        GameObject CretaePrefabGame = null;
        GameObject LayoutSpriteGame = null;
        GameObject WarringSpriteGame = null;
        GameObject MessageGroup = null;
        UILabel WarringMessageLabel1 = null;
        UILabel WarringMessageLabel2 = null;
        GameObject OkBtnGam = null;
        GameObject CancelBtnGam = null;


        string sPrefabName = "HMessagePopupPrefab";

        HPrefabMng.I.DestroyPrefab(sPrefabName + "(Clone)");

        ////! 경고창은 이미 있으면 지워염
        //if (Obj)
        //    PrefabMng.I.DestroyPrefab(Obj);
        ResourceLoad("0_Common", sPrefabName, ResourceList);

        string sMessage1 = string.Empty;
        string sMessage2 = string.Empty;

        int nMessageSize = 0;

        if (nMsgNum1 == -1 && nMsgNum2 == -1)
        {
#if _debug
            Debug.Log("nMsgNum2 and nMsgNum1 is -1");            
#endif
            return null;
        }

        sMessage1 = HConfigMng.I.GetMultiLanguageText(E_H_MULTILANGUAGE_KIND.E_MESSAGE, nMsgNum1);
        sMessage2 = HConfigMng.I.GetMultiLanguageText(E_H_MULTILANGUAGE_KIND.E_MESSAGE, nMsgNum2);

        if (ParentGame)
        {
            foreach (GameObject obj in ResourceList)
            {
                if (obj.transform.name == sPrefabName)
                {
                    CretaePrefabGame = Instantiate(obj) as GameObject;

                    CretaePrefabGame.transform.parent = ParentGame.transform;  //!< 자식으로 넣는거죠
                    CretaePrefabGame.transform.localPosition = PosVec;

                    CretaePrefabGame.transform.localScale = Vector3.one;

                    //! 만들어진 프리펩 윈도우를 List에 추가합니다.
                    CreatePrefabsList.Add(CretaePrefabGame.transform.name, CretaePrefabGame);


                    HMessagePopupPrefab PopupPrefab = null;

                    PopupPrefab = CretaePrefabGame.transform.GetComponent<HMessagePopupPrefab>();

                    //Transform PopupGroupTm = CretaePrefabGame.transform.Find("PopupGroup");

                    LayoutSpriteGame = PopupPrefab.HMSG_LayoutGroupGam;// PopupGroupTm.Find("HMSG_LayoutGroup").transform.FindChild("RankingLayout").gameObject;
                    MessageGroup = PopupPrefab.MessageGroupGam;// PopupGroupTm.Find("MessageGroup").gameObject;
                    WarringMessageLabel1 = PopupPrefab.WarringMessageLabel1Label;// PopupGroupTm.Find("MessageGroup").transform.FindChild("WarringMessageLabel1").GetComponent<UILabel>();
                    WarringMessageLabel2 = PopupPrefab.WarringMessageLabel2Label;// PopupGroupTm.Find("MessageGroup").transform.FindChild("WarringMessageLabel2").GetComponent<UILabel>();
                    WarringSpriteGame = PopupPrefab.WarringSpriteGam;// PopupGroupTm.Find("WarringSprite").gameObject;

                    OkBtnGam = PopupPrefab.OkBtnGam;// PopupGroupTm.Find("Btns").transform.FindChild("OkBtn").gameObject;

                    if (sAddComponent != null)
                    {
                        OkBtnGam.AddComponent(sAddComponent);
                        Debug.Log(sAddComponent + " What Component");
                    }

                    CancelBtnGam = CancelBtnGam = PopupPrefab.CancelBtnGam;

                    //! 메시지 길이가 긴놈을 기준으로 윈도우 사이즈 정합니다.
                    if (sMessage1.Length > sMessage2.Length)
                        nMessageSize = sMessage1.Length;
                    else
                        nMessageSize = sMessage2.Length;

                    if (!bWarringSpriteShow)
                        WarringSpriteGame.SetActiveRecursively(false);

                    float fCalcLayoutCalc = nMessageSize * 23;
                    if (fCalcLayoutCalc < 500.0f)
                        fCalcLayoutCalc = 500.0f;


                    if (nMsgNum1 != -1 && nMsgNum2 == -1)
                    {
                        //! 메시지 하나
                        WarringMessageLabel1.text = sMessage1;
                        LayoutSpriteGame.transform.localScale = new Vector3(fCalcLayoutCalc, LayoutSpriteGame.transform.localScale.y, LayoutSpriteGame.transform.localScale.z);
                        MessageGroup.transform.localPosition = new Vector3(MessageGroup.transform.localPosition.x, MessageGroup.transform.localPosition.y - 10.0f, MessageGroup.transform.localPosition.z);

                        nMessageSize = sMessage1.Length;
                    }
                    else
                    {
                        if (nMsgNum1 != -1 && nMsgNum2 != -1)
                        {
                            //메시지가 두개일때
                            WarringMessageLabel1.text = sMessage1;
                            WarringMessageLabel2.text = sMessage2;

                            LayoutSpriteGame.transform.localScale = new Vector3(fCalcLayoutCalc, LayoutSpriteGame.transform.localScale.y * 1.0f, LayoutSpriteGame.transform.localScale.z);
                        }
                    }

                    switch (eBtnType)
                    {
                        case E_H_POPUPWINDOWTYPE.E_OK_CALCEL:
                            OkBtnGam.transform.localPosition = new Vector3(OkBtnGam.transform.localPosition.x, 0.0f, -1.0f);
                            CancelBtnGam.transform.localPosition = new Vector3(CancelBtnGam.transform.localPosition.x, 0.0f, -1.0f);
                            break;
                        case E_H_POPUPWINDOWTYPE.E_OK:
                            OkBtnGam.transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
                            CancelBtnGam.SetActiveRecursively(false);
                            break;

                        case E_H_POPUPWINDOWTYPE.E_CANCEL:
                            CancelBtnGam.transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
                            OkBtnGam.SetActiveRecursively(false);
                            break;
                    }

                    //nCurSelectInfoTextNum = nMessageNum1;

                    return CretaePrefabGame;
                }
            }
        }
        return null;
    }

    public void Update()
    {

    }
    public GameObject CreateMessagePopupPrefab(string sParentName, Vector3 PosVec, int nMsgNum1 = -1, int nMsgNum2 = -1, bool bWarringSpriteShow = true, E_H_POPUPWINDOWTYPE eBtnType = E_H_POPUPWINDOWTYPE.E_OK_CALCEL, string sOkBtnAddComponent = "", string sCancelBtnAddComponent = "")
    {
        float fZPos = CreatePopupPrefabsNameList.Count * PopupDepth + PopupBasicDepth;
        PosVec.z = fZPos;

        GameObject ParentGame = GameObject.Find(sParentName);
        GameObject CretaePrefabGame = null;
        GameObject LayoutSpriteGame = null;
        GameObject WarringSpriteGame = null;
        GameObject MessageGroup = null;
        UILabel WarringMessageLabel1 = null;
        UILabel WarringMessageLabel2 = null;
        GameObject OkBtnGam = null;
        GameObject CancelBtnGam = null;


        string sPrefabName = "HMessagePopupPrefab";

        HPrefabMng.I.DestroyPrefab(sPrefabName + "(Clone)");

        ////! 경고창은 이미 있으면 지워염
        //if (Obj)
        //    PrefabMng.I.DestroyPrefab(Obj);
        ResourceLoad("0_Common", sPrefabName, ResourceList);

        string sMessage1 = string.Empty;
        string sMessage2 = string.Empty;

        int nMessageSize = 0;

        if (nMsgNum1 == -1 && nMsgNum2 == -1)
        {
#if _debug
            Debug.Log("nMsgNum2 and nMsgNum1 is -1");            
#endif
            return null;
        }

        sMessage1 = HConfigMng.I.GetMultiLanguageText(E_H_MULTILANGUAGE_KIND.E_MESSAGE, nMsgNum1);
        sMessage2 = HConfigMng.I.GetMultiLanguageText(E_H_MULTILANGUAGE_KIND.E_MESSAGE, nMsgNum2);

        if (ParentGame)
        {
            foreach (GameObject obj in ResourceList)
            {
                if (obj.transform.name == sPrefabName)
                {
                    CretaePrefabGame = Instantiate(obj) as GameObject;

                    CretaePrefabGame.transform.parent = ParentGame.transform;  //!< 자식으로 넣는거죠
                    CretaePrefabGame.transform.localPosition = PosVec;

                    CretaePrefabGame.transform.localScale = Vector3.one;

                    //! 만들어진 프리펩 윈도우를 List에 추가합니다.
                    CreatePrefabsList.Add(CretaePrefabGame.transform.name, CretaePrefabGame);
                    HMessagePopupPrefab PopupPrefab = null;

                    PopupPrefab = CretaePrefabGame.transform.GetComponent<HMessagePopupPrefab>();

                    //Transform PopupGroupTm = CretaePrefabGame.transform.Find("PopupGroup");

                    LayoutSpriteGame = PopupPrefab.HMSG_LayoutGroupGam;// PopupGroupTm.Find("HMSG_LayoutGroup").transform.FindChild("RankingLayout").gameObject;
                    MessageGroup = PopupPrefab.MessageGroupGam;// PopupGroupTm.Find("MessageGroup").gameObject;
                    WarringMessageLabel1 = PopupPrefab.WarringMessageLabel1Label;// PopupGroupTm.Find("MessageGroup").transform.FindChild("WarringMessageLabel1").GetComponent<UILabel>();
                    WarringMessageLabel2 = PopupPrefab.WarringMessageLabel2Label;// PopupGroupTm.Find("MessageGroup").transform.FindChild("WarringMessageLabel2").GetComponent<UILabel>();
                    WarringSpriteGame = PopupPrefab.WarringSpriteGam;// PopupGroupTm.Find("WarringSprite").gameObject;

                    OkBtnGam = PopupPrefab.OkBtnGam;// PopupGroupTm.Find("Btns").transform.FindChild("OkBtn").gameObject;
                    CancelBtnGam = PopupPrefab.CancelBtnGam;//.Find("Btns").transform.FindChild("CancelBtn").gameObject;

                    //OkBtnGam = PopupGroupTm.Find("Btns").transform.FindChild("OkBtn").gameObject;

                    //! 메시지 길이가 긴놈을 기준으로 윈도우 사이즈 정합니다.
                    if (sMessage1.Length > sMessage2.Length)
                        nMessageSize = sMessage1.Length;
                    else
                        nMessageSize = sMessage2.Length;

                    if (!bWarringSpriteShow)
                        WarringSpriteGame.SetActiveRecursively(false);

                    float fCalcLayoutCalc = nMessageSize * 23;
                    if (fCalcLayoutCalc < 500.0f)
                        fCalcLayoutCalc = 500.0f;


                    if (nMsgNum1 != -1 && nMsgNum2 == -1)
                    {
                        //! 메시지 하나
                        WarringMessageLabel1.text = sMessage1;
                        LayoutSpriteGame.transform.localScale = new Vector3(fCalcLayoutCalc, LayoutSpriteGame.transform.localScale.y, LayoutSpriteGame.transform.localScale.z);
                        MessageGroup.transform.localPosition = new Vector3(MessageGroup.transform.localPosition.x, MessageGroup.transform.localPosition.y - 10.0f, MessageGroup.transform.localPosition.z);

                        nMessageSize = sMessage1.Length;
                    }
                    else
                    {
                        if (nMsgNum1 != -1 && nMsgNum2 != -1)
                        {
                            //메시지가 두개일때
                            WarringMessageLabel1.text = sMessage1;
                            WarringMessageLabel2.text = sMessage2;

                            LayoutSpriteGame.transform.localScale = new Vector3(fCalcLayoutCalc, LayoutSpriteGame.transform.localScale.y * 1.0f, LayoutSpriteGame.transform.localScale.z);
                        }
                    }

                    switch (eBtnType)
                    {
                        case E_H_POPUPWINDOWTYPE.E_OK_CALCEL:
                            if (sOkBtnAddComponent != "")
                                OkBtnGam.AddComponent(sOkBtnAddComponent);
                            OkBtnGam.transform.localPosition = new Vector3(OkBtnGam.transform.localPosition.x, 0.0f, -1.0f);
                            if (sCancelBtnAddComponent != "")
                                CancelBtnGam.AddComponent(sCancelBtnAddComponent);
                            CancelBtnGam.transform.localPosition = new Vector3(CancelBtnGam.transform.localPosition.x, 0.0f, -1.0f);
                            break;
                        case E_H_POPUPWINDOWTYPE.E_OK:
                            if (sOkBtnAddComponent != "")
                                OkBtnGam.AddComponent(sOkBtnAddComponent);
                            OkBtnGam.transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
                            CancelBtnGam.SetActiveRecursively(false);
                            break;

                        case E_H_POPUPWINDOWTYPE.E_CANCEL:
                            if (sCancelBtnAddComponent != "")
                                CancelBtnGam.AddComponent(sCancelBtnAddComponent);
                            CancelBtnGam.transform.localPosition = new Vector3(0.0f, 0.0f, -1.0f);
                            OkBtnGam.SetActiveRecursively(false);
                            break;
                    }

                    //nCurSelectInfoTextNum = nMessageNum1;

                    return CretaePrefabGame;
                }
            }
        }
        return null;
    }

    public string GetSceneName(string sName)
    {
        if (sName != string.Empty)
        {
            int nStartNum = sName.IndexOf("_");

            string sTemp = sName.Substring(nStartNum + 1);

            return sTemp;
        }
        return null;
    }

    /// <summary>
    /// 리소스 로드 합니다^^
    /// </summary>
    /// <param name="sPrefabName"></param>
    /// <param name="eResourceLoadPos"></param>
    /// <returns></returns>
    List<GameObject> GetReousrceList(string sPrefabName, E_H_RESOURCELOAD eResourceLoadPos)
    {
        List<GameObject> Resource = null;

        string sSceneName = GetSceneName(eResourceLoadPos.ToString());

        if (eResourceLoadPos == E_H_RESOURCELOAD.E_0_COMMON)
        {
            Resource = HPrefabMng.I.ResourceList;
            ResourceLoad(sSceneName, sPrefabName, Resource);
            return Resource;
        }
        else
        {
            Resource = GetResourceList();
            ResourceLoad(sSceneName, sPrefabName, Resource);
            return Resource;
        }
    }

    /// <summary>
    /// 로딩화면 프리펩
    /// </summary>
    /// <param name="bDirectUpdateFrame">true를 넣으면 애니메이션 됩니다. 기본값은 flase입니다. 기본값이 false인 이유는 이 함수의 목적은 씬넘길때 애니메이션 되게 하기위함이기 때문입니다^^</param>
    /// <returns></returns>
    public HLoadingSpriteCtrl CreateLoadingPrefab(bool bBackgroundUseFlag = true, bool bDirectUpdateFrame = true, string sParent = "PopupOffset")
    {
        GameObject Obj = CreatePrefab(sParent, E_H_RESOURCELOAD.E_0_COMMON, "HLoadingPrefab", -50.0f);

        if (Obj == null)
        {
#if _debug
            Debug.Log(" Create LoadingPrefab is null [CreateLodingPrefab()/HPrefabMng.cs]");
#endif
            return null;
        }

        HLoadingSpriteCtrl Ctrl = Obj.transform.FindChild("LoadingSprite").GetComponent<HLoadingSpriteCtrl>();

        //BoxCollider Collider = Obj.transform.GetComponent<BoxCollider>();
        UISprite BackSprite = Obj.transform.FindChild("Background").GetComponent<UISprite>();

        BackSprite.enabled = bBackgroundUseFlag;
        //Collider.enabled = bBackgroundUseFlag;

        if (bDirectUpdateFrame)
            Ctrl.UpdateFrame();

        return Ctrl;
    }

    /// <summary>
    /// 로딩화면 프리팹 제거
    /// </summary>
    public void DestroyLoadingPrefab()
    {
        DestroyPrefab("HLoadingPrefab(Clone)");
    }

    /// <summary>
    /// 이미 같은 이름의 프리펩이 만들어져있는지 검사합니다.
    /// </summary>
    /// <param name="sPrefabName"></param>
    /// <param name="sTitleName"></param>
    /// <returns></returns>
    bool bOverLapGameObject(string sPrefabName, string sTitleName)
    {
        string sTempStr = null;

        if (sTitleName == "")
            sTempStr = sPrefabName + "(Clone)";
        else
            sTempStr = sTitleName + "(Clone)";

        bool TempGameFlag = false;


        if (CreatePrefabsList == null)
        {
            return false;
        }

        if (CreatePrefabsList.Count == 0)
        {
            return false;
        }

        TempGameFlag = CreatePrefabsList.ContainsKey(sTempStr);

        if (TempGameFlag)
        {
            return true;
        }
        else
            return false;

    }

    void ResourceLoad(string sCurSceneName, string sPrefabName, List<GameObject> Resource)
    {
        int nCnt = 0;

        foreach (GameObject obj in Resource)
        {
            if (obj.transform.name == sPrefabName)
                nCnt++;
        }

        if (nCnt == 0)
        {
            string sPath = sCurSceneName + "/1_Prefabs/" + sPrefabName;

            GameObject ResourcePrefabGame = (GameObject)Resources.Load(sPath, typeof(GameObject));

            if (ResourcePrefabGame == null)
            {
#if _debug
                Debug.Log("ResourcePrefabGame is NULL " + sPath +" [ResourceLoad(..)/HPrefabMng.cs]");
#endif
                return;
            }

            ResourcePrefabGame.name = sPrefabName;


            if (ResourcePrefabGame != null)
                Resource.Add(ResourcePrefabGame);
            else
            {
#if _debug
            Debug.Log("failed Resource.load [ResourceLoad/HPrefabMng.cs]");
#endif
            }
        }
    }

    /// <summary>
    /// 리소스저장할 위치
    /// </summary>
    /// <returns></returns>
    List<GameObject> GetResourceList()
    {
        HScene[] Behaviours = null;

        GameObject Obj = GameObject.Find("SceneMng");

        Behaviours = Obj.GetComponents<HScene>();

        if (Behaviours.Length == 0)
        {
            Debug.Log("return null [GetResourceList/HPrefabMng.cs]");
            return null;
        }
        return Behaviours[0].ResourceList;
    }


    /// <summary>
    /// 메세지팝업 프리펩을 지워줍니다.
    /// </summary>
    public void DestroyMessagePopupPrefab()
    {
        HPrefabMng.I.DestroyPrefab("HMessagePopupPrefab(Clone)");
    }


    public void DestroyPrefab(string Name)
    {

        if (CreatePrefabsList == null)
        {
            return;
        }


        if (CreatePrefabsList.Count == 0)
        {
#if _debug
            Debug.Log("CreatePrefabList is Zero [DestroyPrefab/HPrefabMng.cs]");
#endif
            return;
        }

        if (CreatePrefabsList.ContainsKey(Name))
        {
            //Debug.Log(Name);

            Destroy(CreatePrefabsList[Name]);
            CreatePrefabsList[Name] = null;
            CreatePrefabsList.Remove(Name);
        }

        if (CreatePopupPrefabsNameList.Contains(Name))
        {
            CreatePopupPrefabsNameList.Remove(Name);
        }


    }

    public void DestroyPrefab(GameObject PrefabGame)
    {
        string sDeleteName = PrefabGame.name;

        if (CreatePrefabsList == null)
            return;

        if (CreatePrefabsList.Count == 0)
        {
#if _debug
            Debug.Log("CreatePrefabList is Zero [DestroyPrefab/HPrefabMng.cs]");
#endif
            return;
        }

        if (CreatePrefabsList.ContainsKey(sDeleteName))
        {
            Destroy(CreatePrefabsList[sDeleteName]);
            CreatePrefabsList[sDeleteName] = null;
            CreatePrefabsList.Remove(sDeleteName);
        }

        if (CreatePopupPrefabsNameList.Contains(sDeleteName))
        {
            CreatePopupPrefabsNameList.Remove(sDeleteName);
        }
    }

    public void DestroyPrefabs()
    {
        if (CreatePrefabsList == null)
            return;

        if (CreatePrefabsList.Count == 0)
        {
#if _debug
            Debug.Log("CreatePrefabsList.Count == 0   [DestroyPrefab/HPrefabMng.cs]");            
#endif
            return;
        }

        foreach (GameObject obj in CreatePrefabsList.Values)
        {
            if (obj != null)
            {

                Destroy(obj);

                continue;
            }
            //            else
            //            {
            //#if _debug
            //                Debug.Log("obj == null [DestroyPrefab/HPrefabMng.cs]");
            //#endif
            //            }
        }


        //Debug.Log("delete all");


        CreatePrefabsList.Clear();

        System.GC.Collect();
        Resources.UnloadUnusedAssets();
    }
}
