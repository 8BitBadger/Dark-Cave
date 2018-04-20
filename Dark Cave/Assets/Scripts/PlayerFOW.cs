using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFOW : MonoBehaviour
{
    Vector2 previousPosition;
    public LayerMask _obstaclesLayer;

    Rigidbody2D rb2d;

    private void Start()
    {
        _obstaclesLayer = LayerMask.GetMask("Obstacles");
    }

    public void StartFOWCheck(Rigidbody2D _rb2d)
    {
        rb2d = _rb2d;
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

                //Debug.DrawLine(transform.position, dir, Color.red);

                hit = Physics2D.LinecastAll(transform.position, dir, _obstaclesLayer);
                //Physics2D.LinecastNonAlloc(transform.position, dir, hit, obstaclesLayer);

                for (int j = 0; j < hit.Length - 1; j++)
                {
                    if (WorldManager.Instance.map.GetTileAt((int)hit[j].transform.position.x, (int)hit[j].transform.position.y).Type != TileType.Floor)
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
}
