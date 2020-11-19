using UnityEngine;
using System.Collections;

public class RectMove : MonoBehaviour {

    bool bState;
    public GameObject Folder;

	// Use this for initialization
	void Start () {
        gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Random.Range(-330, 330), -1);
        gameObject.transform.localScale = new Vector3(25, 165, 1);
        bState = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.localPosition.y <= -360)
        {
            bState = false;
        }

        else if (gameObject.transform.localPosition.y >= 360)
        {
            bState = true;
            
        }

        if (bState == true)
        {
            gameObject.rigidbody.velocity = new Vector3(0, -3.0f, 0) * CharacterMove.I.fSpeed;
        }

        else if (bState == false)
        {
            gameObject.rigidbody.velocity = new Vector3(0, 3.0f, 0) * CharacterMove.I.fSpeed;
        }
	}

    void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "CheckWall")
        {
            Folder.transform.localPosition += new Vector3(1000, 0, 0);

            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, Random.Range(-330, 330), -1);
        }
    }
}
