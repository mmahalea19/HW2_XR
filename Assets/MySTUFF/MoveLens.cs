using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MoveLens : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mainCamera;
    public GameObject mirrorCamera;
    public GameObject mirror;
    private OVRCameraRig ovrCam;
    void Start()
    {
        this.mainCamera = GameObject.Find("OVRCameraRig");
        this.mirrorCamera = GameObject.Find("Camera");
        this.mirror = GameObject.Find("Glass");
        ovrCam = GameObject.FindObjectOfType<OVRCameraRig>();
    }

    void checkMovement()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("DOwn");
            this.mirror.transform.Translate(Vector3.down*(float)0.1,Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("DOwn");
            this.mirror.transform.Translate(Vector3.up*(float)0.1,Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("DOwn");
            this.mirror.transform.Translate(Vector3.left*(float)0.1,Space.Self);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("DOwn");
            this.mirror.transform.Translate(Vector3.right*(float)0.1,Space.Self);
        }
    }

    // Update is called once per frame
    void Update()
    {
//        ovrCam.
        //Debug.Log(mirror);
        checkMovement();
        Vector3 up=Vector3.up*(float)0.3;
        Vector3 z =( mirror.transform.localPosition+Vector3.forward + Vector3.up*mirror.transform.position.y);
       
     

        Vector3 center = mirror.transform.TransformPoint(z );
       // Debug.Log(center);
        
        mirrorCamera.transform.LookAt(center);

    }
}
