using UnityEngine;
using System.Collections;


public enum E_H_MULTILANGUAGE_KIND
{
    E_MESSAGE,          //!< ��� ����
}


/// <summary>
/// ����:
///    ���̸��� �Ȱ��� ��������մϴ�^^
///    ex) ���̸��� 1_LogoScene ----> E_1_LogoScene �̷��� �ٿ��ּ���^^
/// </summary>
public enum E_H_RESOURCELOAD
{
    E_0_COMMON,         //!< PrefabMng�ȿ� �ִ� ���� Resource���� �о�Ϳ�(���â ������^^)
    E_1_LogoScene,      //!< �ΰ��
    E_2_MenuScene,      //!< �޴���
    E_3_GameScene,      //!< ���Ӿ�
}

public enum E_H_POPUPWINDOWTYPE
{
    E_OK_CALCEL,            //! OK��ư CANCEL��ư �� �ִ³�
    E_OK,                   //! OK��ư�� �ִ³�
    E_CANCEL,               //! CANCEL ��ư�� �ִ³�
}

/// <summary>
/// ����
/// </summary>
public enum E_H_DIR
{
    E_RIGHT,
    E_LEFT,
    E_UP,
    E_DOWN,
    E_MAX
}