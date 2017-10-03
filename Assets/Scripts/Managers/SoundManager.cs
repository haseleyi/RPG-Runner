﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource fireball;

	public static SoundManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
		AudioSource[] sounds = GetComponents<AudioSource> ();
		fireball = sounds [0];
	}
}
