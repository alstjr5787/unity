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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuObject.SetActive(!menuObject.activeSelf);

            if (!menuObject.activeSelf)
            {
                mapObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            mapObject.SetActive(!mapObject.activeSelf);
        }

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

    public void OnMoveButton()
    {
        mapObject.SetActive(true);
    }

    public void MoveToLocation(Transform teleportPosition)
    {
        loadingCanvas.SetActive(true);
        charging = true;
        FindObjectOfType<Player>().transform.position = teleportPosition.position;
        FindObjectOfType<Player>().GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
