﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner {

	List<GameObject> prefabs;
	public GameObject tankPrefab;
	public GameObject archerPrefab;
	public GameObject gruntPrefab;
	public GameObject firePrefab;
	public GameObject boulderPrefab;

	// Time at which each level begins
	[SerializeField] List<float> levelStarts = new List<float>();

	// Seconds between spawns for each level
	[SerializeField] List<float> spawnEvery = new List<float>();

	// Example: { .1, .2, .4, .1, .2 } 
	// Means: During this level, each spawn has a 10% chance of being a tank, a 20% chance of being an archer, etc.
	// Probabilities in a given level must sum to one
	[SerializeField] List<float> level0TankArcherGruntFireBoulder = new List<float>();
	[SerializeField] List<float> level1TankArcherGruntFireBoulder = new List<float>();
	[SerializeField] List<float> level2TankArcherGruntFireBoulder = new List<float>();
	List<List<float>> levels;

	void Start () {
		prefabs = new List<GameObject> { tankPrefab, archerPrefab, gruntPrefab, firePrefab, boulderPrefab };
		levels = new List<List<float>> {
			level0TankArcherGruntFireBoulder,
			level1TankArcherGruntFireBoulder,
			level2TankArcherGruntFireBoulder
		};
		StartCoroutine(SpawnCoroutine());
	}

	IEnumerator SpawnCoroutine() {
		for (int level = 0; level < levels.Count; level++) {
			while (level == levels.Count - 1 || Time.timeSinceLevelLoad < levelStarts[level + 1]) {

				yield return new WaitForSeconds (spawnEvery [level]);
				float r = Random.value;
				float probabilitySum = 0;

				for (int prefabIndex = 0; prefabIndex < prefabs.Count; prefabIndex++) {
					float prefabChance = levels[level][prefabIndex];
					if (probabilitySum < r && r < probabilitySum + prefabChance) {
						SpawnPrefab (prefabs [prefabIndex]);
					}
					probabilitySum += prefabChance;
				}
			}
		}
	}
}
