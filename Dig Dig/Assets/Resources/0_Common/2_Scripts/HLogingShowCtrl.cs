using UnityEngine;
using System.Collections;

/// <summary>
/// À§Ä¡ : LoadingPrefab/
/// </summary>
public class HLogingShowCtrl : MonoBehaviour {

    public float fDelayTime = 5.0f;
    float fDeltaTime = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fDeltaTime >= fDelayTime)
        {
            HPrefabMng.I.DestroyPrefab(transform.name);
#if _debug
            Debug.Log(transform.name + "Destroy name [HLoginShowCtrl()/HLoginShowCtrl.cs]");
#endif

            fDeltaTime = 0;
        }
        else
            fDeltaTime += Time.deltaTime;

        //Debug.Log(fDeltaTime);
    }
}
