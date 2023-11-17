using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{
    // Start at truck position;

    // When round is over --> place camera at determine ccPos
    // Look at player
    // Play set animPlayer animation of truck moving
    // When animations is over --> set camera back to truck position
    
    [Header("Cameras Positions")]
    public Transform tcPos; // Truck Camera Position
    public Transform[] ccPos;  // Cutscene Camera Positions     "ToRound0" + Round.roundNum
    public GameObject cutsceneCamera;

    [Header("Trucks")]
    public GameObject truck;
    public GameObject cutsceneTruck;
    public Transform[] truckPos; // Truck Camera Position

    public KeyCode playCutscene = KeyCode.C;

    public bool inCutscene;

    Animator animPlayer;
    
    void Start()
    {
        animPlayer = cutsceneTruck.GetComponent<Animator>();

        Round.show = true;

        truck.SetActive(true);
        cutsceneTruck.SetActive(false);
        cutsceneCamera.SetActive(false);

        transform.position = tcPos.position;
        truck.transform.position = truckPos[0].transform.position;
        CameraMovement.canMoveCamera = true;

    }

    void Update()
    {
        if(Input.GetKeyDown(playCutscene) && !inCutscene)
        {
            Debug.Log("On Cutscene: ToRound" + Round.roundNum);
            Debug.Log("Round: " + Round.roundNum);
            
            inCutscene = !inCutscene;
            CameraMovement.canMoveCamera = !CameraMovement.canMoveCamera;
            Round.show = true;
            
            // Move Camera and truck to determine cutscene position, then turn of the truck model
            transform.position = ccPos[Round.roundNum - 1].transform.position;
            truck.transform.position = truckPos[Round.roundNum].transform.position;
            truck.SetActive(false);
            
            cutsceneTruck.SetActive(true);
            cutsceneCamera.SetActive(true);
            animPlayer.Play("ToRound" + (Round.roundNum + 1));

            StartCoroutine(WaitAnimationToBeOver(3f));

        }

    }

    IEnumerator WaitAnimationToBeOver(float time)
    {
        yield return new WaitForSeconds(time);

        Debug.Log("Off Cutscene");
            
        inCutscene = !inCutscene;
        CameraMovement.canMoveCamera = !CameraMovement.canMoveCamera;

        truck.SetActive(true);
        transform.position = tcPos.transform.position;

        cutsceneTruck.SetActive(false);
        cutsceneCamera.SetActive(false);


    }

}
