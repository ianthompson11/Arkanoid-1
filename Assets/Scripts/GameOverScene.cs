using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
	public void ResetGame(){

		SceneManager.LoadScene("Level1"); //Esta linea va a cargar la escena
	}
	public void MoreLives(){
		string lastScene = PlayerPrefs.GetString("LastScene", "Level1"); // usa "Level1" si no se encuentra nada
        SceneManager.LoadScene(lastScene);
	}

	public void StartGame(){

		SceneManager.LoadScene("Inicio"); //Esta linea va a cargar la escena
	}
}
