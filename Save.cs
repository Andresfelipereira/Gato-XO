using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{

    public int GetNumPlayers()
    {
        if (PlayerPrefs.HasKey("NumPlayers") == false)
        {
            SetNumPlayers(1);
        }
        return PlayerPrefs.GetInt("NumPlayers");
    }

    public void SetNumPlayers(int value)
    {
        PlayerPrefs.SetInt("NumPlayers", value);
    }

    public int GetP1Score()
    {
        if (PlayerPrefs.HasKey("P1Score") == false)
        {
            SetP1Score(0);
        }
        return PlayerPrefs.GetInt("P1Score");
    }

    public void SetP1Score(int value)
    {
        PlayerPrefs.SetInt("P1Score", value);
    }

    public int GetP2Score()
    {
        if (PlayerPrefs.HasKey("P2Score") == false)
        {
            SetP2Score(0);
        }
        return PlayerPrefs.GetInt("P2Score");
    }

    public void SetP2Score(int value)
    {
        PlayerPrefs.SetInt("P2Score", value);
    }

}
