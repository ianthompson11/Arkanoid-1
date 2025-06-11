using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
	public void BeginGame(){

		SceneManager.LoadScene("Level1"); //Esta linea va a cargar la escena
	}
	public void Niveles(){

		SceneManager.LoadScene("LevelControl"); //Esta linea va a cargar la escena
	}
}

