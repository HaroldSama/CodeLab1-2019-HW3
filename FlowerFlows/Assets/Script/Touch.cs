using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private GameObject target;
    public static bool Jumpable;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Touch");
        if (Jumpable == false && other.CompareTag("Hand") && transform.Find("Player") != null)
        {
            print("Ready");
            target = other.gameObject;
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
            transform.Find("Player").transform.SetParent(target.transform.parent, false);
            Jumpable = false;
            target = null;
        }

    }    
    
}
