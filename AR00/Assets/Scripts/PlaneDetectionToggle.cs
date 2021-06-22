

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARPlaneManager))]
public class PlaneDetectionToggle : MonoBehaviour
{


    private ARPlaneManager planeManager;

    [SerializeField]
    private Text tooglePlainText;


    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
    }

   public void TogglePlaneDetection()
    {
        planeManager.enabled = !planeManager.enabled;
        string toggleButtonMessage = "";
        if (planeManager.enabled)
        {
            toggleButtonMessage = "Disable";
            SetAllPlanesActive(true);
        }
        else if(!planeManager.enabled)
        {
            toggleButtonMessage = "Enable";
            SetAllPlanesActive(false);
        }
    }

    private void SetAllPlanesActive(bool value)
    {
        foreach(var plan in planeManager.trackables)
        {
            plan.gameObject.SetActive(value);
        }
    }

}
