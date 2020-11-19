using UnityEngine;
using System.Collections;

public class SkillMng : MonoBehaviour {

    public UIButton[] Buttons = new UIButton[4];
    public UIButtonMessage[] ButtonMsg = new UIButtonMessage[4];
    float[] fUseTimer = new float[4];
    float[] fCoolTimer = new float[4];
    public UISprite[] CoolSprite = new UISprite[4];
    public UISprite[] UseSprite = new UISprite[4];
    float[] fFullUseTimer = new float[4];

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Skill_1", 2);
        PlayerPrefs.SetInt("Skill_2", 2);
        PlayerPrefs.SetInt("Skill_3", 2);
        PlayerPrefs.SetInt("Skill_4", 2);

        fFullUseTimer[0] = 10;
        fFullUseTimer[1] = 30;
        fFullUseTimer[2] = 10;
        fFullUseTimer[3] = 30;
	}
	
	// Update is called once per frame
	void Update () {
        CheckUse();
        CheckUsing();
        CheckDisabled();

        for (int i = 0; i < 4; i++)
        {
            CoolSprite[i].fillAmount = fCoolTimer[i] / 60;
            UseSprite[i].fillAmount = fUseTimer[i] / fFullUseTimer[i];
        }
    }

    void CheckDisabled()
    {
        if (PlayerPrefs.GetInt("Skill_1") == 0)
        {
            fCoolTimer[0] += Time.deltaTime;
            Buttons[0].enabled = true;
            Buttons[0].isEnabled = false;

            if (fCoolTimer[0] >= 60.0f)
            {
                PlayerPrefs.SetInt("Skill_1", 2);
            }
        }

        if (PlayerPrefs.GetInt("Skill_2") == 0)
        {
            fCoolTimer[1] += Time.deltaTime;
            Buttons[1].enabled = true;
            Buttons[1].isEnabled = false;

            if (fCoolTimer[1] >= 60.0f)
            {
                PlayerPrefs.SetInt("Skill_2", 2);
            }
        }

        if (PlayerPrefs.GetInt("Skill_3") == 0)
        {
            fCoolTimer[2] += Time.deltaTime;
            Buttons[2].enabled = true;
            Buttons[2].isEnabled = false;

            if (fCoolTimer[2] >= 60.0f)
            {
                PlayerPrefs.SetInt("Skill_3", 2);
            }
        }

        if (PlayerPrefs.GetInt("Skill_4") == 0)
        {
            fCoolTimer[3] += Time.deltaTime;
            Buttons[3].enabled = true;
            Buttons[3].isEnabled = false;

            if (fCoolTimer[3] >= 60.0f)
            {
                PlayerPrefs.SetInt("Skill_4", 2);
            }
        }
    }

    void CheckUsing()
    {
        if (PlayerPrefs.GetInt("Skill_1") == 1)
        {
            fUseTimer[0] -= Time.deltaTime;
            Buttons[0].enabled = false;
            ButtonMsg[0].enabled = false;

            if (fUseTimer[0] <= 0.0f)
            {
                PlayerPrefs.SetInt("Skill_1", 0);
                fCoolTimer[0] = 0;
            }
        }

        if (PlayerPrefs.GetInt("Skill_2") == 1)
        {
            fUseTimer[1] -= Time.deltaTime;
            Buttons[1].enabled = false;
            ButtonMsg[1].enabled = false;

            if (fUseTimer[1] <= 0.0f)
            {
                PlayerPrefs.SetInt("Skill_2", 0);
                fCoolTimer[1] = 0;
            }
        }

        if (PlayerPrefs.GetInt("Skill_3") == 1)
        {
            fUseTimer[2] -= Time.deltaTime;
            Buttons[2].enabled = false;
            ButtonMsg[2].enabled = false;

            if (fUseTimer[2] <= 0.0f)
            {
                PlayerPrefs.SetInt("Skill_3", 0);
                fCoolTimer[2] = 0;
            }
        }

        if (PlayerPrefs.GetInt("Skill_4") == 1)
        {
            fUseTimer[3] -= Time.deltaTime;
            Buttons[3].enabled = false;
            ButtonMsg[3].enabled = false;

            if (fUseTimer[3] <= 0.0f)
            {
                PlayerPrefs.SetInt("Skill_4", 0);
                fCoolTimer[3] = 0;
            }
        }
    }

    void CheckUse()
    {
        if (PlayerPrefs.GetInt("Skill_1") == 2)
        {
            Buttons[0].enabled = true;
            Buttons[0].isEnabled = true;
            ButtonMsg[0].enabled = true;
            fUseTimer[0] = 10.0f;
            fCoolTimer[0] = 0;
        }

        if (PlayerPrefs.GetInt("Skill_2") == 2)
        {
            Buttons[1].enabled = true;
            Buttons[1].isEnabled = true;
            ButtonMsg[1].enabled = true;
            fUseTimer[1] = 30.0f;
            fCoolTimer[1] = 0;
        }

        if (PlayerPrefs.GetInt("Skill_3") == 2)
        {
            Buttons[2].enabled = true;
            Buttons[2].isEnabled = true;
            ButtonMsg[2].enabled = true;
            fUseTimer[2] = 10.0f;
            fCoolTimer[2] = 0;
        }

        if (PlayerPrefs.GetInt("Skill_4") == 2)
        {
            Buttons[3].enabled = true;
            Buttons[3].isEnabled = true;
            ButtonMsg[3].enabled = true;
            fUseTimer[3] = 30.0f;
            fCoolTimer[3] = 0;
        }
    }

    void SkillFunc1()
    {
        PlayerPrefs.SetInt("Skill_1", 1);
        fUseTimer[0] = 10;
    }

    void SkillFunc2()
    {
        PlayerPrefs.SetInt("Skill_2", 1);
        fUseTimer[1] = 30;
    }

    void SkillFunc3()
    {
        PlayerPrefs.SetInt("Skill_3", 1);
        fUseTimer[2] = 10;
    }

    void SkillFunc4()
    {
        PlayerPrefs.SetInt("Skill_4", 1);
        fUseTimer[3] = 30;
    }
}