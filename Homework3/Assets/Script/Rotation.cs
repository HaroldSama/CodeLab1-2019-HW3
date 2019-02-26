using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float Speed;
    private float _angle;
    
    // Start is called before the first frame update
    void Start()
    {
        //_angle = new Quaternion(0, Speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation =  Quaternion.AngleAxis(_angle, Vector3.up);
        _angle += Speed;
    }
}
