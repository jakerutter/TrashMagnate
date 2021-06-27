using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Button previous;
    public Button next;
    public Button select;

    public void SelectCharacter()
    {
        Debug.Log("Selected character");
    }

    public void PreviousCharacter()
    {
        Debug.Log("Show previous character");
    }

    public void NextCharacter()
    {
        Debug.Log("Show next character");
    }
}
