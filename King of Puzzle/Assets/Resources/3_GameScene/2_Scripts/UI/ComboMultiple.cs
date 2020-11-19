using UnityEngine;
using System.Collections;

public class ComboMultiple : MonoBehaviour {
    public GameObject[] ComboLabel = new GameObject[10]; 
    BallSingleTon BallSingle;
	// Use this for initialization
	void Start () {
        BallSingle = BallSingleTon.I;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ChangeSprite(BallSingle.nFeverMulti);
	}

    void ChangeSprite(int nCombo)
    {
        switch (nCombo)
        {
            case 1:
                for (int i = 0; i < 10; i++ )
                {
                    if (i == 0)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;

            case 2:
                for (int i = 0; i < 10; i++)
                {
                    if (i == 1)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;

            case 3:
                for (int i = 0; i < 10; i++)
                {
                    if (i == 2)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;

            case 4:
                for (int i = 0; i < 10; i++)
                {
                    if (i == 3)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;

            case 5:
                for (int i = 0; i < 10; i++)
                {
                    if (i == 4)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;

            case 6:
                for (int i = 0; i < 10; i++)
                {
                    if (i == 5)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;

            case 7:
                for (int i = 0; i < 10; i++)
                {
                    if (i == 6)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;

            case 8:
                for (int i = 0; i < 10; i++)
                {
                    if (i == 7)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;

            case 9:
                for (int i = 0; i < 10; i++)
                {
                    if (i == 8)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;

            case 10:
                for (int i = 0; i < 10; i++)
                {
                    if (i == 9)
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(-155.0f, 190.0f, -1.0f);
                    }

                    else
                    {
                        ComboLabel[i].transform.localPosition = new Vector3(755.0f, 190.0f, -1.0f);
                    }
                }
                break;
        }
    }
}
