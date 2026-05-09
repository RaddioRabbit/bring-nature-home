using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlant2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject objectToToggle;


    private void Update()
    {
        Ray ray = new Ray(OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch), OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch) * Vector3.forward);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                Instantiate(objectToToggle, hit.point, Quaternion.FromToRotation(Vector3.up, Vector3.up));
            }
        }

        //if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        //{
        //    //Vector3 controllerPosition = objectToToggle.GetComponent<Transform>();
        //    //Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        //    Instantiate(objectToToggle);
     
        //}
    }
}
