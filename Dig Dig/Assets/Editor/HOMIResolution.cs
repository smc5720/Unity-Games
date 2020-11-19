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
        window.title = "해상도 조정";

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
        GUILayout.Label("해상도 설정", EditorStyles.boldLabel);
        GUILayout.Label("Ver 1.0", EditorStyles.boldLabel);
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(10.0f);

        GUILayout.Label("< 크기 >", EditorStyles.boldLabel);
        //EditorGUILayout.BeginHorizontal();
        SetResolution.I.Width = EditorGUILayout.IntField("너비", SetResolution.I.Width);
        SetResolution.I.Height = EditorGUILayout.IntField("높이", SetResolution.I.Height);
        //EditorGUILayout.EndHorizontal();

        GUILayout.Space(10.0f);

        GUILayout.Label("< 비율 >", EditorStyles.boldLabel);

        //EditorGUILayout.BeginHorizontal();
        SetResolution.I.RatioWidth = EditorGUILayout.IntField("너비", SetResolution.I.RatioWidth);
        SetResolution.I.RatioHeight = EditorGUILayout.IntField("높이", SetResolution.I.RatioHeight);
        //EditorGUILayout.EndHorizontal();
        
        //PlayerPrefs.Save();

        EditorGUILayout.EndVertical();
    }
}