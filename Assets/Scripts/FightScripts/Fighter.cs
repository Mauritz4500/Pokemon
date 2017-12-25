using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
	Monster[] monster;
	void Start () {
		monster = new Monster[FightManager.maxMonsterInTeam];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
