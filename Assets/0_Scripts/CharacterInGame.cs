using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInGame : MonoBehaviour
{
    public List<CharacterInfo> charactersInGame;
    public CharacterInfo characterSelected;

    private void Awake()
    {
        characterSelected = CharacterSelected.instance.characterSelected;
    }

    private void Start()
    {
        foreach (var character in charactersInGame)
        {
            character.gameObject.SetActive(false);

            if (character.CharacterType == characterSelected.CharacterType)
            {
                character.gameObject.SetActive(true);
            }
        }
    }
}
