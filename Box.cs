using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public GameObject box;
    public string player = "na";

    public void SelectBox(Sprite pIcon, string player)
    {
        box.GetComponent<Button>().interactable = false;
        box.GetComponent<Image>().color = Color.white;
        box.GetComponent<Image>().sprite = pIcon;
        this.player = player;
    }

    public void SetPlayer(string player) { this.player = player; }

    public string GetPlayer() { return this.player; }

}
