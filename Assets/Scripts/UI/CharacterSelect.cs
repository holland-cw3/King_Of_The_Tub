using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelect : MonoBehaviour
{
    public GameObject selectUI;

    void Start()

    {
        selectUI.SetActive(false);
    }

    public void openSelect()
    {
        selectUI.SetActive(true);
    }

    public void exitSelect()
    {
        selectUI.SetActive(false);
    }

    void Buy()
    {

    }

    public void useChar()
    {
        
    }

    private void UpdateCharacter(int selectedOption)
    {
        //Character character = characterDB.GetCharacter(selectedOption);
        //artworkSprite.sprite = character.characterSprite;
    }


}
