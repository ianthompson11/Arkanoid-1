using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWin : MonoBehaviour
{
	public void StartGame(){

		SceneManager.LoadScene("Inicio"); //Esta linea va a cargar la escena
	}
}
