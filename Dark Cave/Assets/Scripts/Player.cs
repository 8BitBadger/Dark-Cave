using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public ActorStats stats;

    //The Rigidbody2D for the Actor
    private Rigidbody2D rb2d;
    private Animator animator;

    Vector2 previousPosition;

    //The layers that are used for the FOW scanning
    private int scanLayers;

    private float walkSpeed;
    private float sprintSpeed;

    // Use this for initialization
    void Start()
    {
        int floorLayer = 1 << LayerMask.NameToLayer("Floor");
        int obstacleLayer = 1 << LayerMask.NameToLayer("Obstacles");

        scanLayers = floorLayer | obstacleLayer;

        stats.speedModifier = 1f;

        if (gameObject.GetComponent<Rigidbody2D>())
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
        }
        else
        {
            //Set up the rigibody2d component for the actor
            //SetUpRigidBody();
        }

        //animator = gameObject.GetComponent<Animator>();

        walkSpeed = (float)((stats.speed + stats.speedModifier) *  Time.deltaTime * 50 + (stats.agility / 5));
        sprintSpeed = walkSpeed + (walkSpeed / 2);
    }

    // Update is called once per frame
    void Update()
    {
        StartFOWCheck();

        float curSpeed = walkSpeed;
        //float maxSpeed = curSpeed;

        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }

    public void StartFOWCheck()
    {
        StartCoroutine("CheckFOW");
    }

    IEnumerator CheckFOW()
    {
        if (rb2d.position != previousPosition)
        {
            //The sprite renderer for the sprite
            SpriteRenderer tempSprite;

            //The distance calculation from the player
            //Use this later to make the game look prity prity lol
            //float tileDistance;

            //ATTEMPT 3
            //OPTIMIZE!!!
            //Do Physics2D.OverlapCircleAll to get the list of tiles to light u.
            //Then get the ground tiles in that list
            //Then rycast to those tiles and reset the tiles behind them to black.

            //How many rays to use for the FOW
            int RaysToShoot = 24;
            //The distance the charecter can see
            int viewDistance = 8;
            //The starting angel for the FOW
            float angle = 0;
            //The max array size for the hit from the raycast;
            RaycastHit2D[] hit = new RaycastHit2D[15];
            //The direction of the next raycast
            Vector3 dir;
            //The angle of the ray cast in x and y coordinates
            float x, y;

            for (int i = 0; i < RaysToShoot; i++)
            {
                x = Mathf.Sin(angle) * viewDistance;
                y = Mathf.Cos(angle) * viewDistance;
                angle += 2 * Mathf.PI / RaysToShoot;

                dir = new Vector3(transform.position.x + x, transform.position.y + y, 0);

                Debug.DrawLine(transform.position, dir, Color.red);

                hit = Physics2D.LinecastAll(transform.position, dir, scanLayers);

                for (int j = 0; j < hit.Length - 1; j++)
                {
                    int hitXPos = (int)hit[j].transform.position.x;
                    int hitYPos = (int)hit[j].transform.position.y;

                    if (WorldManager.Instance.map.GetTileAt(hitXPos, hitYPos).Type != TileType.Floor && WorldManager.Instance.map.GetTileAt(hitXPos, hitYPos).Type != TileType.Room)
                    {
                        tempSprite = hit[j].transform.GetComponent<SpriteRenderer>();

                        if (tempSprite.color != new Color(1f, 1f, 1f))
                        {
                            tempSprite.color = new Color(1f, 1f, 1f);
                        }
                        break;
                    }
                    else
                    {
                        tempSprite = hit[j].transform.GetComponent<SpriteRenderer>();

                        if (tempSprite.color != new Color(1f, 1f, 1f))
                        {
                            tempSprite.color = new Color(1f, 1f, 1f);
                        }
                    }
                }
            }
            previousPosition = rb2d.position;
        }
        yield return new WaitForSeconds(.5f);
    }

    public void TakeDamage(int damage)
    {
        stats.health -= damage;
        Debug.Log("Health = " + stats.health);
    }
}