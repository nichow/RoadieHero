﻿using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<AudioSource>().Play();
    }
}
