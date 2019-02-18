using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public static bool Jumpable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //print("Touch");
        if (Jumpable && other.CompareTag("Hand") && transform.Find("Player") != null)
        {
            print("Jump");
            transform.Find("Player").transform.SetParent(other.transform.parent, false);
            Jumpable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Jumpable == false && other.CompareTag("Hand") && transform.Find("Player") != null)
        {
            Jumpable = true;            
        }

    }
}
