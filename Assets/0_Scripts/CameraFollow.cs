using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;

    [SerializeField] Vector3 offSet;

    private void Start()
    {
        //Need to wait a little bit, so we secure that the player has been spawned
        if (CharacterSelected.instance)
            Invoke("SetCharacter", 0.1f);

        //this.enabled = true;
    }

    private void Update()
    {
        if (player)
            Camera.main.transform.position = player.transform.position - offSet;
    }

    void SetCharacter()
    {
        player = FindObjectOfType<Player>().transform;
    }
}