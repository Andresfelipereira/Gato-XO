using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Save save;

    //Se inicializa con reiniciar el puntaje de los jugadores
    void Start()
    {
        save.SetP1Score(0);
        save.SetP2Score(0);
    }

    //Se carga el juego en modo un jugador
    public void OnePlayer() {
        save.SetNumPlayers(1);
        SceneManager.LoadScene("Game");
    }

    //Se carga el juego en modo dos jugadores
    public void TwoPlayers() {
        save.SetNumPlayers(2);
        SceneManager.LoadScene("Game");
    }

    //Salir del juego
    public void Exit()
    {
        Application.Quit();
    }

}
