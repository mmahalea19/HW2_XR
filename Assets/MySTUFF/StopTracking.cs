using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTracking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.MCParent=GameObject.Find("Mock");
        this.mainCamera = Camera.FindObjectOfType<OVRPlayerController>();
    }

    public bool verticalTrack = false;
    public bool horizontalTrack = false;
    public GameObject MCParent;
    public OVRPlayerController mainCamera;
    void checkButtons()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
            {
            verticalTrack = !verticalTrack;

        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            horizontalTrack = !horizontalTrack;

        }

    }

    void resetCamera()
    {
        mainCamera. transform.localRotation =Quaternion.Euler(Vector3.zero);
        mainCamera.transform.localPosition = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        checkButtons();

        if (verticalTrack)
        {
            Vector3 mcPosition = mainCamera.transform.localPosition;

            Quaternion camRot = mainCamera.transform.localRotation;
            Vector3 eulerAngles = camRot.eulerAngles;
            eulerAngles.x = 0;//MCParent.transform.rotation.eulerAngles.x;
            eulerAngles.z = 0; //MCParent.transform.rotation.eulerAngles.z;
            MCParent.transform.rotation = MCParent.transform.rotation  *Quaternion.Euler(eulerAngles);
            
            
            
            mcPosition.y = 0;
            MCParent.transform.position += mcPosition; 
            
            
            
            
        }
        else if (horizontalTrack)
        {
            Vector3 mcPosition = mainCamera.transform.localPosition;
            Quaternion camRot = mainCamera.transform.localRotation;
            Vector3 eulerAngles = camRot.eulerAngles;
            eulerAngles.y = 0;//MCParent.transform.rotation.eulerAngles.x;
           
            MCParent.transform.rotation = MCParent.transform.rotation  *Quaternion.Euler(eulerAngles);
            
            
            
           
            mcPosition.x = 0;
            mcPosition.z = 0;
            MCParent.transform.position += mcPosition; 
        }
        else
        {
            
            MCParent.transform.rotation = MCParent.transform.rotation* mainCamera.transform.localRotation;
            MCParent.transform.position += mainCamera.transform.localPosition;
           
        
        }
        resetCamera();
        
        
        
        
        
    }
}
