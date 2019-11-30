using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertTrack : MonoBehaviour
{
    public bool stopRotation = false;
    public bool stopTranslation = false;
    public OVRPlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        this.controller = GameObject.FindObjectOfType<OVRPlayerController>();
    }

    void checkButtons()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            stopRotation=!stopRotation;
            this.initalRotEuler = this.controller.transform.rotation.eulerAngles;
            initialRot = this.controller.transform.rotation;
            initialMockPos = this.transform.rotation;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            stopTranslation=!stopTranslation;
            initialPos = this.controller.transform.position;
        }
        if (Input.GetKey(KeyCode.R))
        {
           this.controller.transform.Rotate(Vector3.up,1);
        }
    }

    public Quaternion initialMockPos;
    public Vector3 initialPos;
    public Quaternion initialRot;

    public Vector3 initalRotEuler;
    // Update is called once per frame
    void Update()
    {
        checkButtons();
//        if (stopRotation)
//        {
//            Quaternion diff = this.controller.transform.rotation *Quaternion.Inverse(initialRot);
//            this.transform.rotation *= Quaternion.Inverse(diff);
//            this.initialRot = this.controller.transform.rotation;
//
//        }
       if (stopRotation)
       {
//           Quaternion diff = this.controller.transform.rotation * Quaternion.Inverse(initialRot);
//           this.transform.rotation=initialMockPos*Quaternion.Inverse(diff);
           this.controller.transform.rotation = initialRot;
           // this.initalRotEuler = this.controller.transform.rotation.eulerAngles;

       }

        if (stopTranslation)
        {
            Vector3 diff = this.controller.transform.position - initialPos;
            this.transform.position -= diff;
        }


    }
}
