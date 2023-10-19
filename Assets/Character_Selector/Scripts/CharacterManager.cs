using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CharacterSelector.Scripts
{
    public class CharacterManager : SingletonBase<CharacterManager>
    {
        public CharacterInfo[] Characters;

        public GameObject[] SpawnPoint;

        private int _currentIndex = 0;

        private CharacterInfo _currentCharacterType = null;

        public CharacterInfo _currentCharacter = null;

        public Text characterDescriptionText;

        protected override void Init()
        {
            Persist = true;
            base.Init();
        }

        public void Start()
        {
            if (SpawnPoint != null)
            {
                CreateAllCharacters();
                //SetCurrentCharacterType(_currentIndex);
            }
        }

        public void CreateAllCharacters()
        {
            for (int i = 0; i < Characters.Length; i++)
            {
                Instantiate<CharacterInfo>(Characters[i],
                SpawnPoint[i].transform.position, Quaternion.identity);
            }
        }

        public void SetCurrentCharacterType(int index)
        {
            if (_currentCharacterType != null)
            {
                Destroy(_currentCharacterType.gameObject);
            }


            CharacterInfo character = Characters[index];
            characterDescriptionText.text = character.Description;
            _currentCharacter = character;

            CharacterSelected.instance.characterSelected = character;
            //_currentCharacterType = Instantiate<CharacterInfo>(character, 
            //    SpawnPoint.transform.position, Quaternion.identity);

            _currentIndex = index;
        }

        public void SetCurrentCharacterType(string name)
        {
            int idx = 0;
            foreach (CharacterInfo characterInfo in Characters)
            {
                if (characterInfo.CharacterType.Equals(name, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    SetCurrentCharacterType(idx);
                    break;
                }
                idx++;
            }
        }

        public void CreateCurrentCharacter(string name)
        {
            //_currentCharacter = Instantiate<CharacterInfo>(_currentCharacterType, 
            //SpawnPoint.transform.position, Quaternion.identity);
            //DontDestroyOnLoad(_currentCharacter);
            _currentCharacter.Name = name;
            SceneManager.LoadScene(2);
        }

        public CharacterInfo GetCurrentCharacter(int index)
        {
            return Characters[index];
        }

        public CharacterInfo GetCurrentCharacter()
        {
            return _currentCharacter;
        }
    }
}
