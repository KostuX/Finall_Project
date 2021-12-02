using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_RotateDrone : MonoBehaviour
{
   public Rigidbody drone_RB;
    // Start is called before the first frame update
    void Start()
    {
     drone_RB   = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
           drone_RB.AddRelativeTorque(transform.forward * 0.005f);
           drone_RB.AddRelativeTorque(transform.up * 0.001f);
    }
}
