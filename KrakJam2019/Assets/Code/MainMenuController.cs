﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour{
	[SerializeField] Button playButton;
	[SerializeField] Button exitButton;

	void Start(){
		playButton.onClick.AddListener(Play);
		exitButton.onClick.AddListener(Exit);
	}

	void Play(){
		SceneManager.LoadScene(1);
	}

	void Exit(){
		Application.Quit();
		Debug.Log("Wyjszlo z apki");
	}
}