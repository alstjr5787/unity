using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeText : MonoBehaviour
{
    Text textGameObject;

    [SerializeField]
    Image playerImage;

    public static bool displayingText;

    private void Awake()
    {
        textGameObject = gameObject.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        textGameObject.text = "안녕! " + CharacterSelected.instance.userName + "아, 대전대학교 가상 캠퍼스에 온걸 환영해 !";

        playerImage.sprite = CharacterSelected.instance.characterSelected.characterImage;

        displayingText = true;
    }

    private void Update()
    {
        if (CharacterSelected.instance.playerInput.actions["Submit"].WasPressedThisFrame() && displayingText)
        {
            displayingText = false;
            Invoke("WaitForMenu", 0.2f);
            gameObject.SetActive(false);
        }
    }

    void WaitForMenu()
    {
        GameManager.stopUsingMenu = false;
    }
}
