﻿using UnityEngine;
using System.Collections;

public class SetChild : MonoBehaviour
{



    private bool isColliderAdded = false;
    private Transform rightHand, leftHand;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        rightHand = this.GetComponent<Transform>().Find("hand_right");
        leftHand = this.GetComponent<Transform>().Find("hand_left");
        if (leftHand != null && rightHand != null && !isColliderAdded)
        {
            this.GetComponent<Transform>().Find("AvatarGrabberRight").transform.position = new Vector3(0, 0, 0);
            this.GetComponent<Transform>().Find("AvatarGrabberRight").transform.parent = rightHand.transform;
            this.GetComponent<Transform>().Find("AvatarGrabberLeft").transform.position = new Vector3(0, 0, 0);
            this.GetComponent<Transform>().Find("AvatarGrabberLeft").transform.parent = leftHand.transform;
            isColliderAdded = true;
        }
    }


}