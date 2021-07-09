using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class tapToSpawn : MonoBehaviour

{

    public GameObject arObjectToSpawn;
    public GameObject placementIndicator;
    public int maxObjectToSpawn = 10;
    private int spawnedObjectCounter = 0;

    private Pose PlacementPose;
    private ARRaycastManager arRayCastManager;
    private bool placementPoseIsValid = false;
    private GameObject spawnedObject;



    // Start is called before the first frame update
    void Start()
    {

        arRayCastManager = FindObjectOfType<ARRaycastManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedObjectCounter<=maxObjectToSpawn&& placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            ARPlaceObject();
            spawnedObjectCounter++;
        }
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    void UpdatePlacementPose()
    {

        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRayCastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            PlacementPose = hits[0].pose;
        }


    }

    void UpdatePlacementIndicator()
    {

        if (spawnedObject == null && placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }

        else
        {
            placementIndicator.SetActive(false);
        }
    }

    void ARPlaceObject()
    {

        spawnedObject = Instantiate(arObjectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);

    }

}
