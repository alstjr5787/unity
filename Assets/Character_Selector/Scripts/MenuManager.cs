using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject menuObject;
    [SerializeField] GameObject mapObject;
    [SerializeField] GameObject loadingCanvas;
    [SerializeField] Image progressBar;
    [SerializeField] Image buildImage;
    [SerializeField] List<Sprite> buildImages;
    [SerializeField] Sprite imageToDisplay;
    bool onImageDisplay;

    float timerToChargeProgressBar;
    bool charging;

    private void Update()
    {
        if (charging)
        {
            timerToChargeProgressBar += Time.deltaTime;
            progressBar.fillAmount = timerToChargeProgressBar;

            if (timerToChargeProgressBar > 1)
            {
                //WHEN WE FINISH THE PROGRESS BAR, WE TURN OFF EVERY CANVAS
                //loadingCanvas.SetActive(false);
                buildImage.sprite = imageToDisplay;

                buildImage.enabled = true;
                onImageDisplay = true;
                GameManager.stopUsingMenu = true;
                mapObject.SetActive(false);
                menuObject.SetActive(false);
                charging = false;
                timerToChargeProgressBar = 0;
            }
        }

        if (onImageDisplay)
        {
            if (CharacterSelected.instance.playerInput.actions["Submit"].WasPressedThisFrame())
            {
                buildImage.enabled = false;
                mapObject.SetActive(false);
                menuObject.SetActive(false);
                loadingCanvas.SetActive(false);
                onImageDisplay = false;
                Invoke("WaitForMenu", 0.2f);
         
            }
        }
    }

    void WaitForMenu()
    {
   
        GameManager.stopUsingMenu = false;
 
    }


    public void MoveToLocation(Location location)
    {
        loadingCanvas.SetActive(true);
        charging = true;
        imageToDisplay = location.locationImage;
        ButtonSound.instance.PlayMove();
        Time.timeScale = 1f;
        FindObjectOfType<Player>().transform.position = location.locationTransform.position;
        FindObjectOfType<Player>().GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
