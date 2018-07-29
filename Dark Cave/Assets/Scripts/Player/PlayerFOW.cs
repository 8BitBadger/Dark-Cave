using UnityEngine;
using System.Collections;

public class PlayerFOW : MonoBehaviour
{
    //The Rigidbody2D for the Actor
    private Rigidbody2D rb2d;

    Vector2 previousPosition;

    //The layers that are used for the FOW scanning
    private int scanLayers;

    // Use this for initialization
    void Start()
    {
        int floorLayer = 1 << LayerMask.NameToLayer("Floor");
        int obstacleLayer = 1 << LayerMask.NameToLayer("Obstacles");
        int enemyLayer = 1 << LayerMask.NameToLayer("Enemy");

        scanLayers = floorLayer | obstacleLayer | enemyLayer;

        if (gameObject.GetComponent<Rigidbody2D>())
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        StartFOWCheck();
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

            //How many rays to use for the FOW
            int RaysToShoot = 40;
            //The distance the charecter can see
            int viewDistance = 16;
            //The starting angel for the FOW
            float angle = 0;
            //The max array size for the hit from the raycast;
            RaycastHit2D[] hits = new RaycastHit2D[15];
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

                hits = Physics2D.LinecastAll(transform.position, dir, scanLayers);

                for (int j = 0; j < hits.Length - 1; j++)
                {
                    if (hits[j].transform.tag == "Enemy")
                    {
                        tempSprite = hits[j].transform.GetComponent<SpriteRenderer>();
                        if (tempSprite.color == new Color(0f, 0f, 0f))
                        {
                            tempSprite.color = new Color(1f, 1f, 1f);
                        }

                    }

                    int hitXPos = (int)hits[j].transform.position.x;
                    int hitYPos = (int)hits[j].transform.position.y;


                    if (MapSystem.WorldManager.Instance.map.GetTileAt(hitXPos, hitYPos).Type != TileType.Floor && MapSystem.WorldManager.Instance.map.GetTileAt(hitXPos, hitYPos).Type != TileType.Room)
                    {
                        tempSprite = hits[j].transform.GetComponent<SpriteRenderer>();

                        if (tempSprite.color != new Color(1f, 1f, 1f))
                        {
                            tempSprite.color = new Color(1f, 1f, 1f);
                        }
                        break;
                    }
                    else
                    {
                        tempSprite = hits[j].transform.GetComponent<SpriteRenderer>();

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
}