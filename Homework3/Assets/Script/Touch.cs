using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private float SlidingSpeed = 0.1f;
    //public GameObject target;
    public GameObject Destination;
    public GameObject Player;
    public static bool Jumpable;
    public static bool Sliding;
    private bool SlidingPrivate;
    public Vector3 Way;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Touch");
        
        //The Condition to become Jumpable:
        //1. Player is not sliding
        //2. Player is not Jumpable already
        //3. This Petal Anchor's "hand" collides with the "hand" of another Petal Anchor.
        //4. This Petal Anchor contains the Player as its child.
        if (!Sliding && !Jumpable && other.CompareTag("Hand") && transform.Find("Player") != null)
        {
            //print("Ready");
            //target = other.gameObject;
            
            Destination = other.transform.parent.gameObject;//Assign the destination for Player to slide to
            Jumpable = true;//Player become able to jump.
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand") && transform.Find("Player") != null)//if player doesn't jump before the collision exit.
        {
            Jumpable = false;//Player become unable to jump.
            //target = null;
            //print("Expire");
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.Find("Player") != null)//When player press the Space and it's within this petal.
        {
            if (Jumpable)//If player is able to jump.
            {
                Player = transform.Find("Player").gameObject;//Get the player as a gameobject for further operation.
                Player.transform.parent = null;//Move the player out of it's parent to stop it moving along with the parent.
                //transform.Find("Player").transform.SetParent(target.transform.parent, false);
                Sliding = true;//This is a static to tell all Petals to hold operating while the player is sliding
                SlidingPrivate = true;//This is a private to control the start and end of the sliding on this particular petal
                Jumpable = false;//Make player unable to do more jump.
                //target = null;
                Scoring.Instance.Perfect++;//Increase the count of successful jump.
            }
            else
            {
                Scoring.Instance.Miss++;//Increase the count of failed jump.
            }        
        }


        if (Sliding && SlidingPrivate)
        {
            Slide();//Perform the sliding action.
        }

    }

    void Slide()
    {
        Way =  Destination.transform.position - Player.transform.position;
        if (Way.magnitude > SlidingSpeed)
        {
            /*print("Player" + Player.transform.position);
            print("Destination" + Destination.transform.position);
            print(Way);
            print(Way.magnitude);
            print(Way / Way.magnitude * SlidingSpeed);*/
            Player.transform.position += Way / Way.magnitude * SlidingSpeed;
        }
        else
        {
            print("Set");
            Player.transform.SetParent(Destination.transform, true);
            Player.transform.position = Destination.transform.position;
            Player = null;
            Destination = null;
            Sliding = false;
            SlidingPrivate = false;
        }
    }
    
}
