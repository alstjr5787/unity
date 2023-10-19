using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSelected : MonoBehaviour
{
    public static CharacterSelected instance;

    public CharacterInfo characterSelected;

    public string userName;

    public PlayerInput playerInput;

    private void Awake()
    {
        characterSelected = null;

        playerInput = GetComponent<PlayerInput>();

        if (instance == null)
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}
