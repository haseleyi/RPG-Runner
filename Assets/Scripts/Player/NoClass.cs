﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoClass : PlayerClass {

	public override string title {get; protected set;}

	void Start () {
		title = "None";
	}

	public override void Ability () {
		// Do nothing
	}
}
