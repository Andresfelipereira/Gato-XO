using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public enum Turn { A, B };

public class Game : MonoBehaviour
{
    public Save save;
    public Box[] boxes;
    public Sprite[] playersSprites;
    public TextMeshProUGUI scoreText;
    public GameObject resultScreen;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI scoreResultText;
    public Image winnerIcon;
    public Turn turn;
    public int numPlayers;
    public int p1Score;
    public int p2Score;

    // Se inicia el juego obteniendo el numero de jugadores, asi como su respectivo puntaje
    void Start()
    {
        resultScreen.SetActive(false);
        numPlayers = save.GetNumPlayers();
        p1Score = save.GetP1Score();
        p2Score = save.GetP2Score();
        scoreText.text = p1Score.ToString()+" - "+p2Score.ToString();
        turn = Turn.A;
    }

    //Se selecciona una casilla especifica y se verifica el estado de la partida
    public void SelectBox(Box box)
    {
        Sprite sprite;
        switch (turn)
        {
            case Turn.A:
                sprite = playersSprites[0];
                break;
            case Turn.B:    
                sprite = playersSprites[1];
                break;
            default:
                sprite = playersSprites[0];
                break;              
        }
        box.SelectBox(sprite,turn.ToString());
        if (TicTacToe(turn.ToString()))
        {
            winnerIcon.enabled = true;
            if(turn == Turn.A)
            {
                p1Score++;
                save.SetP1Score(p1Score);
                winnerIcon.GetComponent<Image>().sprite = playersSprites[0];
            }else if(turn == Turn.B)
            {
                p2Score++;
                save.SetP2Score(p2Score);
                winnerIcon.GetComponent<Image>().sprite = playersSprites[1];
            }
            resultText.text = "Jugador "+turn.ToString()+ " gana";
            StartCoroutine(GetResult());
        }
        else
        {
            if (!Tie()) { 
             switch (turn)
                {
                    case Turn.A:
                        turn = Turn.B;
                        break;
                    case Turn.B:
                        turn = Turn.A;
                        break;
                    default:
                        turn = Turn.A;
                        break;
                }
                if(numPlayers == 1 && turn == Turn.B)
                {
                    StartCoroutine(CPUTurn());
                }
            }
            else
            {
                resultText.text = "Empate";
                winnerIcon.enabled = false;
                StartCoroutine(GetResult());
            }
            
        }
    }
    
    //Comprueba si el jugador gana la partida
    public bool TicTacToe(string player)
    {
            if((boxes[0].player == player&& boxes[1].player == player && boxes[2].player == player)
            || (boxes[3].player == player && boxes[4].player == player && boxes[5].player == player)
            || (boxes[6].player == player && boxes[7].player == player && boxes[8].player == player)
            || (boxes[0].player == player && boxes[3].player == player && boxes[6].player == player)
            || (boxes[1].player == player && boxes[4].player == player && boxes[7].player == player)
            || (boxes[2].player == player && boxes[5].player == player && boxes[8].player == player)
            || (boxes[0].player == player && boxes[4].player == player && boxes[8].player == player)
            || (boxes[2].player == player && boxes[4].player == player && boxes[6].player == player))
            {
            return true;
            }
            return false;
    }
    
    //Obtiene el resultado obtenido en la partida y lo muestra en pantalla
    public IEnumerator GetResult()
    {
        DisableAllBoxes();
        yield return new WaitForSeconds(2f);
        resultScreen.SetActive(true);
        scoreResultText.text = p1Score.ToString() + " - " + p2Score.ToString();
    }

    //Comprueba si hay empate al finalizar la partida
    public bool Tie()
    {
        bool result = true;
        for (int i = 0; i < boxes.Length; i++)
        {
            if(boxes[i].GetComponent<Button>().IsInteractable())
            {
                result = false;
            }
        }
        return result;
    }

    //Desactiva la posilidad de selecionar alguna casilla
    public void DisableAllBoxes()
    {
        for(int i = 0; i < boxes.Length; i++)
        {
            boxes[i].box.GetComponent<Button>().interactable = false;
        }
    }

    //Gestiona el turno de la computadora si el juego se encuentra en modo un jugador
    IEnumerator CPUTurn()
    {
        bool completed = false;   
        while (!completed) { 
            int selectedBox = Random.Range(0, 9);
            if (boxes[selectedBox].GetComponent<Button>().IsInteractable())
            {
                yield return new WaitForSeconds(2f);
                boxes[selectedBox].GetComponent<Button>().onClick.Invoke();
                completed = true;
            }
        }

    }

    //Reiniciar el juego
    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    //Salir del juego
    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

}
