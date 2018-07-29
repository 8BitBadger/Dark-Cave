using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public UnitStats stats;

    //The Rigidbody2D for the Actor
    private Rigidbody2D rb2d;
    private Animator animator;

    private float speed;

    // Use this for initialization
    void Start()
    {

        stats.agility = stats.agility + stats.agilityModifier;

        if (gameObject.GetComponent<Rigidbody2D>())
        {
            rb2d = gameObject.GetComponent<Rigidbody2D>();
        }

        //animator = gameObject.GetComponent<Animator>();

        stats.speed = stats.sprintSpeed;
        stats.strengthModifier = 3;
    }

    // Update is called once per frame
    void Update()       
    {
        speed = (float)(stats.speed + (3 + (stats.agility / 5)) * Time.deltaTime);

        rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical") * speed, 0.8f));
    }


}