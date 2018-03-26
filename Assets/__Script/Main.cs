﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    static public Main S;
	public static int highScore = 0;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefultPadding = 1.5f;         //the default padding is used when the object dont have BoundsCheck script. this is good 
    public float restartDelay = 2f;
	public enum weaponType {simpleWp, blasterWp};
	//public weaponType wp = weaponType.simpleWp;
    private BoundsCheck boundsCheck;
	public Text highScoreText;

    private void Awake()
    {
        if (S!=null)
        {
            Debug.LogError("Main.awake()-attempted to assign second Main.S");
        }
        else
        {
            S = this;
        }


        boundsCheck = GetComponent<BoundsCheck>();
        if (boundsCheck == null) Debug.LogError("no boundsCheck was found in Main");


        bool checkPrefab = true;
        foreach (GameObject ele in prefabEnemies){
            if (ele == null) checkPrefab = false;
        }
        if (prefabEnemies.Length < 1 || !checkPrefab) Debug.LogError("prefab attaching error");
        

        

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }

    public void DelayedRestart()
    {
		if (highScore < ScoreDisplay.score)
			highScore = ScoreDisplay.score;
		displayHighScore ();
        Invoke("Restart", restartDelay);
    }

    public void Restart()
    {
		highScoreText.text = "";
        SceneManager.LoadScene("GamePlay");
    }

    public void SpawnEnemy()
    {
        int index = UnityEngine.Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[index]);

        float padding = enemyDefultPadding;
        if (go.GetComponent<BoundsCheck>() != null) padding = Mathf.Abs(go.GetComponent<BoundsCheck>().padding);

        Vector3 pos = Vector3.zero;
        pos.x = UnityEngine.Random.Range(-(boundsCheck.camWidth - padding), boundsCheck.camWidth - padding);
        pos.y = boundsCheck.camHeight + padding;

        go.transform.position = pos;

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }

	public void displayHighScore(){
		highScoreText.text = "Your High Score is: " + highScore + "!";
	}

//	private int getScore(){
//		int result = 0;
//		result = ScoreDisplay.score;
//	}
}
