using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class ARtapToPlaceObject : MonoBehaviour
{
   public    GameObject gameObjectToInstantiet;


   private   GameObject spawnedObject;
   private   ARRaycastManager arRayCastManager;
   private   Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>(); 


    private void Awake()
    {
        arRayCastManager = GetComponent<ARRaycastManager>();

    }

    bool TrayGetTouchPosition (out Vector2 touchPosition) 
    { 
    if(Input.touchCount>0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
   
    }


    private void Update()
    {
        if (!TrayGetTouchPosition(out Vector2 touchposition))
            return;


        if(arRayCastManager.Raycast(touchposition,hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPos = hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(gameObjectToInstantiet, hitPos.position, hitPos.rotation);

            }
            else 
            {
                spawnedObject.transform.position = hitPos.position;
            } 

        }

    }



}
