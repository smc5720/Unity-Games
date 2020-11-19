using UnityEngine;
using System.Collections;

public class Feveritem : MonoBehaviour
{
    StarGage ComboGage;
    BallSingleTon BallSingle;
    ComboGage itforCombo;
    public AudioClip FeverItem;
    BlockShuffle ShuffleMng;
    // Use this for initialization
    void Start()
    {
        ComboGage = GameObject.Find("StarFore").GetComponent<StarGage>();
        BallSingle = BallSingleTon.I;
        ShuffleMng = GameObject.Find("ResetButton").GetComponent<BlockShuffle>();
        itforCombo = GameObject.Find("ComboGage").GetComponent<ComboGage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ComboGage.bComboState == false)
        {
            HPrefabMng.I.DestroyPrefab(gameObject);
            BallSingle.FeverComboZero();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            AudioSource.PlayClipAtPoint(FeverItem, transform.position);
            BallSingle.ScoreAdd(BallSingle.nFeverMulti);
            HPrefabMng.I.DestroyPrefab(gameObject);
            itforCombo.TimerCharge();
            ShuffleMng.nCheckNum++;
            BallSingle.ComboCalculate();
            BallSingle.FeverCalculate();
        }
    }
}