﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundOnEnable : MonoBehaviour {

    [SerializeField]
    private AudioSource soundMain;
    [SerializeField]
    private AudioClip SoundToPlay;

    // Use this for initialization
    void Start () {
        soundMain.PlayOneShot(SoundToPlay);
	}
	
	
}
