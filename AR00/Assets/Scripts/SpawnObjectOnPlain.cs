using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



[RequireComponent(typeof(ARRaycastManager))]
public class SpawnObjectOnPlain : MonoBehaviour
{
   
    static private int nSpawnedObjectMax = 100;

    private ARRaycastManager raycastManager;

    List<GameObject> placedPreFabList = new List<GameObject>();
    [SerializeField]
    private int maxPreFabSpawnCount = 100;
    private int objectCounter = 0;


    [SerializeField]
    private GameObject placeblePreFab;

    static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.GetTouch(0).phase==TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if(raycastManager.Raycast(touchPosition,s_hits,TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_hits[0].pose;
            if(objectCounter < nSpawnedObjectMax)
            {
                placedPreFabList[objectCounter] = Instantiate(placeblePreFab, hitPose.position, hitPose.rotation);
                placedPreFabList[objectCounter].transform.rotation = hitPose.rotation;
                objectCounter++;

            }
            else Debug.Log("there is to much objects to be spawned ");

        }


    }

    public void SetPrefabType(GameObject prefabType)
    {
       placeblePreFab = prefabType;
    }



}
