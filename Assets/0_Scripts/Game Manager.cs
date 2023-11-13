using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject menuSet;
    public GameObject mapSet;
    public Button firstButtonMenu;
    public Button firstButtonMap;


    // 이전의 Time.timeScale 값을 저장하기 위한 변수
    private float previousTimeScale;

    public bool canUseMenu;
    public static bool stopUsingMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        stopUsingMenu = true;
        // 게임 시작 시 Time.timeScale 값을 1.0으로 설정하여 정상적인 게임 시간을 유지
        canUseMenu = true;
        Time.timeScale = 1.0f;
        menuSet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (((CharacterSelected.instance.playerInput.actions["MenuRT"].IsPressed() && CharacterSelected.instance.playerInput.actions["MenuLT"].IsPressed()) || CharacterSelected.instance.playerInput.actions["MenuKeyboard"].IsPressed()) && canUseMenu && !WelcomeText.displayingText)
        {
            if (stopUsingMenu)
                return;

            canUseMenu = false;
            if (menuSet.activeSelf)
            {
                ResumeGame(); // 메뉴가 활성화되어 있으면 게임 재개
            }
            else
            {
                PauseGame(); // 메뉴가 비활성화되어 있으면 게임 일시 정지
            }

            StartCoroutine(WaitForMenu());
        }

        if (CharacterSelected.instance.playerInput.actions["Map"].WasPressedThisFrame() && !WelcomeText.displayingText)
        {
            if (!mapSet.activeSelf)
                OnOpenMap();
            else
                OnCloseMap();
        }
    }

    // 게임 일시 정지 함수
    void PauseGame()
    {
        ButtonSound.instance.PlayClick();
        previousTimeScale = Time.timeScale; // 현재 Time.timeScale 값을 저장
        Time.timeScale = 0.0f; // 게임 시간을 정지
        menuSet.SetActive(true); // 메뉴 활성화
        firstButtonMenu.Select();
    }

    // 게임 재개 함수
    public void ResumeGame()
    {
        ButtonSound.instance.PlayClick();
        Time.timeScale = 1f; // 이전의 Time.timeScale 값으로 복원
        menuSet.SetActive(false); // 메뉴 비활성화
        mapSet.SetActive(false);
    }


    public void OnOpenMap()
    {
        ButtonSound.instance.PlayClick();
        Time.timeScale = 0.0f;
        firstButtonMap.Select();
        mapSet.SetActive(true);
    }


    public void OnCloseMap()
    {
        Time.timeScale = 1.0f;
        mapSet.SetActive(false);
    }

    IEnumerator WaitForMenu()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        canUseMenu = true;
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
