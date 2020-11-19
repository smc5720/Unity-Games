using UnityEngine;
using System.Collections;


public enum E_H_MULTILANGUAGE_KIND
{
    E_MESSAGE,          //!< 경고 관련
}


/// <summary>
/// 주의:
///    씬이름과 똑같이 적어줘야합니다^^
///    ex) 씬이름이 1_LogoScene ----> E_1_LogoScene 이렇게 붙여주세요^^
/// </summary>
public enum E_H_RESOURCELOAD
{
    E_0_COMMON,         //!< PrefabMng안에 있는 전역 Resource에서 읽어와요(경고창 같은거^^)
    E_1_LogoScene,      //!< 로고씬
    E_2_MenuScene,      //!< 메뉴씬
    E_3_GameScene,      //!< 게임씬
}

public enum E_H_POPUPWINDOWTYPE
{
    E_OK_CALCEL,            //! OK버튼 CANCEL버튼 다 있는놈
    E_OK,                   //! OK버튼만 있는놈
    E_CANCEL,               //! CANCEL 버튼만 있는놈
}

/// <summary>
/// 방향
/// </summary>
public enum E_H_DIR
{
    E_RIGHT,
    E_LEFT,
    E_UP,
    E_DOWN,
    E_MAX
}