using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject cursorPrefab;

    public ActorStats playerStats;
    private Player playerInstance;

    //The world coordinates of the mouse in the last frame
    Vector3 lastFramePosition;
    Vector3 currFramePosition;

    bool buildModeIsObjects = false;
    TileType buildModeTile = TileType.Floor;

    float timeSinceLastAttack = 0f;

    private void Start()
    {
        playerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent("Player") as Player;
        cursorPrefab = Instantiate(cursorPrefab);
        Cursor.visible = false;
    }

    private void Update()
    {
        cursorPrefab.transform.position = GetMousePosition();

        //TODO:Impliment build mode later in the game this is the camera movement for it
        //currFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //currFramePosition.z = 0;

        //UpdateCameraMovement();

        //lastFramePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //lastFramePosition.z = 0;



        if (Input.GetMouseButton(0))
        {
            if ((Time.time - timeSinceLastAttack) > playerStats.attackInterval)
            {
                RaycastHit2D[] hit = Physics2D.LinecastAll(GetMousePosition2D(), GetMousePosition2D());

                Tile tile = WorldManager.Instance.GetTileAtWorldCoord(GetMousePosForTile());
                if (Vector2.Distance(new Vector2(tile.X, tile.Y), playerInstance.transform.position) < 1)
                {
                    if (tile != null && tile.Type != TileType.Rock && tile.Room == RoomType.None)
                    {
                        tile.Type = buildModeTile;
                    }
                }

                for (int i = 0; i < hit.Length; i++)
                {
                    if (hit[i].collider.tag == "")
                    {

                    }
                }

                timeSinceLastAttack = Time.time;
            }


        }
    }

    Vector3 GetMousePosition()
    {

        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    Vector2 GetMousePosition2D()
    {

        return new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
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
