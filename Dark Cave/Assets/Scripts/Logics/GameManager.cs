﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{  
	//Static instance of GameManager which allows it to be accessed by any other script.
	public static GameManager instance = null;
	
	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
		{
			//if not, set instance to this
			instance = this;
		}
		//If instance already exists and it's not this:
		else if (instance != this)
		{  
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
		
		//Get a component reference to the attached BoardManager script
		//mapManager = GetComponent<MapCreator>();

		SetUpGame();
	}
	
	void SetUpGame()
	{
		
	}
}
