using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {
    public ParticleSystem ParticleGame;
	// Use this for initialization
	void Start () {
        ParticleGame.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}