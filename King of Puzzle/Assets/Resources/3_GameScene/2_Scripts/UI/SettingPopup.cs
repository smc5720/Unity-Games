using UnityEngine;
using System.Collections;

public class SettingPopup : MonoBehaviour
{
    public GameObject Popup;
    public GameObject MuteBtn;
    public GameObject Root1;
    AudioSource RootAudio;
    UICheckbox MuteCheck;
    // Use this for initialization
    void Start()
    {
        MuteCheck = MuteBtn.GetComponent<UICheckbox>();
        RootAudio = Root1.GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("isMute") == 1)
        {
            PlayerPrefs.SetInt("isMute", 1);
            RootAudio.mute = true;
            MuteCheck.mChecked = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (MuteCheck.mChecked == true)
        {
            PlayerPrefs.SetInt("isMute", 1);
            RootAudio.mute = true;
        }

        else if (MuteCheck.mChecked == false)
        {
            PlayerPrefs.SetInt("isMute", 0);
            RootAudio.mute = false;
        }
    }

    void OnClickBtn()
    {
        Popup.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
        Popup.transform.localPosition = new Vector3(0, 0, -5);
        Popup.animation.Play("CreatePopupAni");
    }

    void StaffClick()
    {

    }

    void ExitClick()
    {
        Popup.transform.localScale = new Vector3(0.01f, 0.01f, 1.0f);
        Popup.transform.localPosition = new Vector3(-1000, 0, -5);
    }

    void SetClick()
    {

    }
}