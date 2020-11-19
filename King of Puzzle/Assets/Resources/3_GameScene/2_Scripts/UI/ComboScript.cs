using UnityEngine;
using System.Collections;

public class ComboScript : MonoBehaviour {
    int nNum;
    float fTimer;

    // Use this for initialization
    void Start()
    {
        nNum = Random.Range(1, 5);
        fTimer = 0.0f;

        if (nNum == 1)
        {
            gameObject.rigidbody.AddForce(Vector3.left * 20);
            gameObject.rigidbody.AddForce(Vector3.up * 100);
        }

        else if (nNum == 2)
        {
            gameObject.rigidbody.AddForce(Vector3.right * 20);
            gameObject.rigidbody.AddForce(Vector3.up * 100);
        }

        else if (nNum == 3)
        {
            gameObject.rigidbody.AddForce(Vector3.left * 10);
            gameObject.rigidbody.AddForce(Vector3.up * 100);
        }

        else if (nNum == 4)
        {
            gameObject.rigidbody.AddForce(Vector3.right * 10);
            gameObject.rigidbody.AddForce(Vector3.up * 100);
        }
        gameObject.GetComponent<UILabel>().text = "Combo " + BallSingleTon.I.nCombo.ToString() + "!";
    }

    // Update is called once per frame
    void Update()
    {
        fTimer += Time.deltaTime;

        if (fTimer >= 1.0f)
        {
            HPrefabMng.I.DestroyPrefab(gameObject);
        }
	}
}
