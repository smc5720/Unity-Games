using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
    public float speed;
    public float gravity;
    public Mng Manager;
    public bool UpState;
    public GameObject BoomAnimation;
    public GameObject EndPopup;
    void Start()
    {
        Manager = GameObject.Find("Mng").GetComponent<Mng>();
        speed = 0;
        gravity = 0.00f;
        UpState = false;
    }

    void Update()
    {
        gameObject.rigidbody.velocity = new Vector3(0, speed * Manager.SlowDisSpeed, 0);
        if (gameObject.transform.localPosition.y > 240 || gameObject.transform.localPosition.y < -240)
        {
            Manager.DieState = true;
            EndPopup.animation.Play("PopupUp");
            Manager.SlowDisSpeed = 0;

                CreatePrefab("Structure", "BoomAnimation", BoomAnimation, new Vector3(200, 200, 1), new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, -10));
            
            gameObject.transform.localPosition = new Vector3(-1000, 0, 0);
        }
    }

    void OnTriggerEnter(Collider Struct)
    {
        Manager.DieState = true;
        EndPopup.animation.Play("PopupUp");
        Manager.SlowDisSpeed = 0;
        if (Struct.tag == "Struct" || Struct.tag == "Block")
        {
            CreatePrefab("Structure", "BoomAnimation", BoomAnimation, new Vector3(200, 200, 1), new Vector3(gameObject.transform.localPosition.x,gameObject.transform.localPosition.y,-10));
        }
        gameObject.transform.localPosition = new Vector3(-1000, 0, 0);
    }
    public GameObject CreatePrefab(string Parent, string Name, GameObject Prefab, Vector3 Scale, Vector3 Position)
    {
        GameObject CreObj = (GameObject)Instantiate(Prefab);
        CreObj.transform.parent = GameObject.Find(Parent).transform;
        CreObj.name = Name;
        CreObj.transform.localScale = Scale;
        CreObj.transform.localPosition = Position;
        return CreObj;
    }
}
