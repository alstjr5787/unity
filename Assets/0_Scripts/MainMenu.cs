using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void main()
    {
        ButtonSound.instance.PlayClick();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        ButtonSound.instance.PlayClick();
        Application.Quit();
    }
}
