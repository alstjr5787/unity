using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuSet;

    // 이전의 Time.timeScale 값을 저장하기 위한 변수
    private float previousTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        // 게임 시작 시 Time.timeScale 값을 1.0으로 설정하여 정상적인 게임 시간을 유지
        Time.timeScale = 1.0f;
        menuSet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                ResumeGame(); // 메뉴가 활성화되어 있으면 게임 재개
            }
            else
            {
                PauseGame(); // 메뉴가 비활성화되어 있으면 게임 일시 정지
            }
        }
    }

    // 게임 일시 정지 함수
    void PauseGame()
    {
        previousTimeScale = Time.timeScale; // 현재 Time.timeScale 값을 저장
        Time.timeScale = 0.0f; // 게임 시간을 정지
        menuSet.SetActive(true); // 메뉴 활성화
    }

    // 게임 재개 함수
    void ResumeGame()
    {
        Time.timeScale = previousTimeScale; // 이전의 Time.timeScale 값으로 복원
        menuSet.SetActive(false); // 메뉴 비활성화
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
