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

    float timerToChargeProgressBar;
    bool charging;

    private void Update()
    {
        if (charging)
        {
            timerToChargeProgressBar += Time.deltaTime;
            progressBar.fillAmount = timerToChargeProgressBar;
            if(timerToChargeProgressBar > 1)
            {
                //WHEN WE FINISH THE PROGRESS BAR, WE TURN OFF EVERY CANVAS
                loadingCanvas.SetActive(false);
                mapObject.SetActive(false);
                menuObject.SetActive(false);
                charging = false;
                timerToChargeProgressBar = 0;
            }
        }
    }


    public void MoveToLocation(Transform teleportPosition)
    {
        loadingCanvas.SetActive(true);
        charging = true;
        Time.timeScale = 1f;
        FindObjectOfType<Player>().transform.position = teleportPosition.position;
        FindObjectOfType<Player>().GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
