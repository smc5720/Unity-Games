using UnityEngine;
using UnityEditor;


public class HOMIResolution : EditorWindow 
{
    static Vector2 size;
    int Width;
    int Height;

    int RatioWidth;
    int RatioHeight;

    [MenuItem("Resolution/SetResolution")]
    static void Init()
    {
        HOMIResolution window = (HOMIResolution)EditorWindow.GetWindow(typeof(HOMIResolution));
        window.title = "�ػ� ����";

        size.x = 200.0f;
        size.y = 165.0f;
        window.minSize = size;

        size.x = 201.0f;
        size.y = 166.0f;
        window.maxSize = size;
    }

    void OnGUI()
    {
        size.x = 200.0f;
        size.y = 165.0f;

        this.minSize = size;

        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("�ػ� ����", EditorStyles.boldLabel);
        GUILayout.Label("Ver 1.0", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10.0f);

        GUILayout.Label("< ũ�� >", EditorStyles.boldLabel);
        //EditorGUILayout.BeginHorizontal();
        SetResolution.I.Width = EditorGUILayout.IntField("�ʺ�", SetResolution.I.Width);
        SetResolution.I.Height = EditorGUILayout.IntField("����", SetResolution.I.Height);
        //EditorGUILayout.EndHorizontal();

        GUILayout.Space(10.0f);

        GUILayout.Label("< ���� >", EditorStyles.boldLabel);

        //EditorGUILayout.BeginHorizontal();
        SetResolution.I.RatioWidth = EditorGUILayout.IntField("�ʺ�", SetResolution.I.RatioWidth);
        SetResolution.I.RatioHeight = EditorGUILayout.IntField("����", SetResolution.I.RatioHeight);
        //EditorGUILayout.EndHorizontal();
        
        //PlayerPrefs.Save();

        EditorGUILayout.EndVertical();
    }
}