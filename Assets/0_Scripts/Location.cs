using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public Transform locationTransform;
    public Sprite locationImage;

    // Start is called before the first frame update
    void Awake()
    {
        locationTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
