using UnityEngine;
using System.Collections;


//[System.Serializable]
/// <summary>
/// ���� : ��ũ�� ���� Ŭ�����Դϴ�
/// ��ġ : ��ũ���� Object
/// </summary>
public class HScrollControl : MonoBehaviour {

    public UITexture ScrollSpirte = null;
    public bool bScrollFlag = false;
    public Vector2 fScrollSpeedVec2 = new Vector3(1.0f, 0.0f);

    [HideInInspector]
    public Vector2 fMngScrollSpeedVec2 = new Vector3(1.0f, 0.0f);

    public string textureName = "_MainTex";

    Vector2 uvOffset = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        ScrollSpirte = transform.GetComponent<UITexture>();
    }
	
    void LateUpdate()
    {
        Vector2 MulVec = Vector2.zero;
        
        if (ScrollSpirte.material)
        {
            MulVec.x = fMngScrollSpeedVec2.x * fScrollSpeedVec2.x;
            MulVec.y = fMngScrollSpeedVec2.y * fScrollSpeedVec2.y;

            uvOffset += ((MulVec) * Time.deltaTime);

            ScrollSpirte.material.SetTextureOffset(textureName, uvOffset);
        }
    }
}
