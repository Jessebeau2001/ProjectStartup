using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject ObjToPlace;
    public GameObject placementIndicator;
    private int clickIndex = 0;
    private Pose placementPose;
    private ARRaycastManager raycastManager;
    private bool placementPoseValid = false;
    public GameObject ARRootObject;
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseValid && Input.touchCount > 0 && Input.GetTouch(0).phase ==  TouchPhase.Began) {
            PlaceObject(ObjToPlace);
        }
    }

    private void PlaceObject(GameObject placeable)
    {
        if (clickIndex == 0) { //Code to set the 0/root point of all the Standard GameObjects that should be inialized on bootup
            ARRootObject.transform.position = placementPose.position;
        }

        if (clickIndex > 0 && clickIndex <= 10) {
            Instantiate(placeable, placementPose.position, placementPose.rotation);
        }

        if (clickIndex > 10) {
            PhysicsRaycast();
        }

        clickIndex++;
    }

    private void UpdatePlacementIndicator() {
        if (placementPoseValid) {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        } else {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose() {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseValid = hits.Count > 0;

        if (placementPoseValid) {
            placementPose = hits[0].pose;
        }

    }

    private void ARRayCastTest() {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        raycastManager.Raycast(screenCenter, hits);

        if (hits.Count > 0) {
            foreach(ARRaycastHit hit in hits) {
                //???????
            }
        }
    }

    private void PhysicsRaycast() {
        RaycastHit hit;
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        Camera cam = Camera.current;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
            Destroy(hit.transform.gameObject);
        }
    }
}
