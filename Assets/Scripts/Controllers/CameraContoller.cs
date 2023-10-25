using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private float cameraWidth;
    private float cameraHeight;
    private float cameraSize;
    private int stageX;
    private int stageY;
    [SerializeField]
    private float cameraSmoothTime = 0.5f; 
    private Vector3 cameraVelocity = Vector3.zero;


    private void Start()
    {
        cameraSize =  Camera.main.orthographicSize; 
        cameraWidth = cameraSize * Camera.main.aspect * 2;
        cameraHeight = cameraSize * 2;
    }

    private void Update()
    {
        CameraPosition();
    }

    private void GetStage()
    {
        if (player.transform.position.x < 0)
        {
            stageX = (int)((player.transform.position.x / cameraWidth) - .5);
        }
        else
        {
            stageX = (int)((player.transform.position.x / cameraWidth) + .5);
        }
      
        if(player.transform.position.y < 0)
        {

           stageY = (int)((player.position.y / cameraHeight) - .5);
        }
        else
        {

            stageY = (int)((player.position.y / cameraHeight) + .5);
        }

    }
    private void CameraPosition()
    {
        GetStage();
        float cameraX = stageX * cameraWidth;
        float cameraY = (stageY * cameraHeight);
        Vector3 targetPosition = new Vector3(cameraX, cameraY, transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref cameraVelocity, cameraSmoothTime);
    }
}