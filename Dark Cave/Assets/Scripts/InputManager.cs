using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject cursorPrefab;

    //The world coordinates of the mouse in the last frame
    Vector3 lastFramePosition;
    Vector3 currFramePosition;

    bool buildModeIsObjects = false;
    TileType buildModeTile = TileType.Floor;


    private void Update()
    {

        //TODO:Impliment build mode later in the game this is the camera movement for it
        //currFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //currFramePosition.z = 0;

        //UpdateCameraMovement();

        //lastFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //lastFramePosition.z = 0;

        if (Input.GetMouseButton(0))
        {
            Tile t = WorldManager.Instance.GetTileAtWorldCoord(GetMousePosForTile());

            if (t != null && t.Type != TileType.Rock && t.Room == RoomType.None)
            {
                t.Type = buildModeTile;
            }
        }
    }

    Vector3 GetMousePosition()
    {
        
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector3 GetMousePosForTile()
    {
        Vector3 mousePos = new Vector3(Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x),
                                       Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y),
                                       Camera.main.ScreenToWorldPoint(Input.mousePosition).z);

        return mousePos;
    }

    public void SetMode_BreakGround()
    {
        buildModeIsObjects = false;
        buildModeTile = TileType.Floor;
    }




    void UpdateCameraMovement()
    {
        //Update screen dragging
        if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
        {
            Vector3 diff = lastFramePosition - currFramePosition;
            Camera.main.transform.Translate(diff);
        }

        Camera.main.orthographicSize -= Camera.main.orthographicSize * Input.GetAxis("Mouse ScrollWheel");

        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 3f, 25f);
    }
}
