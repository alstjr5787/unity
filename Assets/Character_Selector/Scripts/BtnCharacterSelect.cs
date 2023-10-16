using CharacterSelector.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCharacterSelect : MonoBehaviour
{
    public InputField CharacterName;

    //THIS IS THE NEW INDEX YOU SHOULD SET IT WITH THE INSPECTOR, FIRST SLOT IS INDEX 0 BUTTON
    public int characterIndex;

    public void SwitchCharacter()
    {
        // e.g. Ethan or Rabbit
        //string characterName = transform.Find("Text").GetComponent<Text>().text;

        //CharacterManager.Instance.SetCurrentCharacterType(characterName);

        CharacterManager.Instance.SetCurrentCharacterType(characterIndex);
    }

    public void CreateCharacter()
    {
        string characterName = CharacterName.text.Trim(); // 입력된 닉네임을 가져와서 공백을 제거

        if (string.IsNullOrEmpty(characterName))
        {
            // 닉네임이 입력되지 않았을 때 처리 (예: 오류 메시지 표시 또는 경고)
            Debug.LogError("닉네임을 필수로 입력하세요."); // 콘솔에 오류 메시지 출력 (테스트용, 필요에 따라 변경)
        }
        else
        {
            // 닉네임이 입력되었을 경우에만 다음 화면으로 넘어감
            CharacterSelected.instance.userName = characterName;
            CharacterManager.Instance.CreateCurrentCharacter(characterName);
        }
    }
}
