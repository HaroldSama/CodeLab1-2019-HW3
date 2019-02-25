using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private float SlidingSpeed = 0.1f;
    public GameObject target;
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
        if (!Sliding && !Jumpable && other.CompareTag("Hand") && transform.Find("Player") != null)
        {
            print("Ready");
            target = other.gameObject;
            Destination = target.transform.parent.gameObject;
            Jumpable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand") && transform.Find("Player") != null)
        {
            Jumpable = false;
            target = null;
            print("Expire");
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        if (Jumpable && Input.GetKeyDown(KeyCode.Space) && transform.Find("Player") != null)
        {
            Player = transform.Find("Player").gameObject;
            Player.transform.parent = null;
            //transform.Find("Player").transform.SetParent(target.transform.parent, false);
            Sliding = true;
            SlidingPrivate = true;
            Jumpable = false;
            target = null;
        }

        if (Sliding && SlidingPrivate)
        {
            Slide();
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
