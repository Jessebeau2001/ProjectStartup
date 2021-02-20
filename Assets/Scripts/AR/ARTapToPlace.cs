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
    public Color colorIndicator = new Color(0, 255, 0);
    public GameObject canvas;
    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        ARRootObject.SetActive(false); //Hide all game related stuff before 0,0,0 has been set in the real world
    }

    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseValid && Input.touchCount > 0 && Input.GetTouch(0).phase ==  TouchPhase.Began) {
            if (clickIndex == 0) { //Set 0,0,0 for Unity Root GameObject in the real world
                ARRootObject.transform.position = placementPose.position;
                ARRootObject.SetActive(true);
                canvas.GetComponent<Animator>().SetBool("ShowText", false);
            }

            // if (clickIndex > 0 && clickIndex <= 10) {
            //     PlaceObject(ObjToPlace);
            // }

            if (clickIndex > 0) {
                PhysicsRaycast();
            }

            clickIndex++;
        }
    }

    private void PlaceObject(GameObject placeable)
    {
        Instantiate(placeable, placementPose.position, placementPose.rotation);
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
        Camera cam = Camera.current;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
            
            FriendCharacter character = hit.transform.gameObject.GetComponent<FriendCharacter>();
            if (character != null) {
                character.ToggleHide();
            }
        }
    }

    private void PhysicsRaycastHighlight() {
        RaycastHit hit;

        if (Physics.Raycast(Camera.current.transform.position, Camera.current.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity)) {
            hit.transform.gameObject.GetComponent<Renderer>().material.color = colorIndicator;
        }
    }
}
