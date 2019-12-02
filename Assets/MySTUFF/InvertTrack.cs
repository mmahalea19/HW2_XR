using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertTrack : MonoBehaviour
{
    public bool stopRotation = false;
    public bool stopTranslation = false;
    public OVRCameraRig camera;
    // Start is called before the first frame update
    void Start()
    {
        this.camera = GameObject.FindObjectOfType<OVRCameraRig>();
    }

    void checkButtons()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            stopRotation=!stopRotation;
            this.initalRotEuler = this.camera.transform.rotation.eulerAngles;
            initialRot = this.camera.transform.localRotation;
            initialMockPos = this.transform.rotation;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            stopTranslation=!stopTranslation;
            initialPos = this.camera.transform.position;
        }
        if (Input.GetKey(KeyCode.R))
        {
           this.camera.transform.Rotate(Vector3.up,1);
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
//          
           this.transform.rotation = Quaternion.Inverse(this.camera.transform.localRotation * Quaternion.Inverse(initialRot));

       }

        if (stopTranslation)
        {
            this.transform.transform.position -= this.camera.transform.position - initialPos;

        }


    }
}
