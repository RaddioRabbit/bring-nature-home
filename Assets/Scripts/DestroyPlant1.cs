using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlant1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject objectToToggle;


    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            //Vector3 controllerPosition = objectToToggle.GetComponent<Transform>();
            //Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
            Destroy(objectToToggle);

        }
    }
}
