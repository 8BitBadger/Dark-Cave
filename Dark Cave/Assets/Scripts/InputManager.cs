using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject cursorPrefab;

    public ActorStats playerStats;

    private EventCbSystem.PlayerLogic playerLogic;

    //The world coordinates of the mouse in the last frame
    Vector3 lastFramePosition;
    Vector3 currFramePosition;

    bool buildModeIsObjects = false;
    TileType buildModeTile = TileType.Floor;
    RoomType buildModeRoom = RoomType.None;

    float timeSinceLastAttack = 0f;

    private void Start()
    {
        playerLogic = GameObject.FindGameObjectWithTag("Player").GetComponent<EventCbSystem.PlayerLogic>() as EventCbSystem.PlayerLogic;
        cursorPrefab = Instantiate(cursorPrefab);
        playerStats = playerLogic.stats;
        Cursor.visible = false;
    }

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
            if ((Time.time - timeSinceLastAttack) > playerStats.attackInterval)
            {
                RaycastHit2D[] hit = Physics2D.LinecastAll(GetMousePosition2D(), GetMousePosition2D());

                MapSystem.Tile tile = MapSystem.WorldManager.Instance.GetTileAtWorldCoord(GetMousePosForTile());
                if (Vector2.Distance(new Vector2(tile.X, tile.Y), playerLogic.transform.position) < playerStats.attackRange)
                { 
                    if (tile != null && tile.Type != TileType.Rock  && tile.Type != TileType.Floor && tile.Room == RoomType.None)
                    {
                        //tile.Type = buildModeTile;
                        tile.TakeDamage(playerLogic.CalculateDamage());
                        print("Tile Hit");
                        print("Damage = " + playerLogic.CalculateDamage());
                    }

                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.tag == "Enemy")
                        {
                            hit[i].collider.GetComponent<EventCbSystem.EnemyLogic>().TakeDamage(playerLogic.CalculateDamage());
                        }
                    }
                }
                timeSinceLastAttack = Time.time;
            }
        }
    }
    private void LateUpdate()
    {
        cursorPrefab.transform.position = GetMousePosition2D();
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

    public void SetMode_BuildTreasureRoom()
    {
        buildModeIsObjects = false;
        buildModeTile = TileType.Room;
        buildModeRoom = RoomType.Tresuary;
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
