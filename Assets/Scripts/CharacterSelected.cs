using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelected : MonoBehaviour
{
    public static CharacterSelected instance;

    public CharacterInfo characterSelected;

    public string userName;

    private void Awake()
    {
        characterSelected = null;

        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
