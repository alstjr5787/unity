using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeText : MonoBehaviour
{
    Text textGameObject;

    [SerializeField]
    Image playerImage;

    private void Awake()
    {
        textGameObject = gameObject.GetComponentInChildren<Text>();
    }

    private void Start()
    {
        textGameObject.text = "안녕! " + CharacterSelected.instance.userName + "아, 대전대학교 가상 캠퍼스에 온걸 환영해 !";

        playerImage.sprite = CharacterSelected.instance.characterSelected.characterImage;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }
}
