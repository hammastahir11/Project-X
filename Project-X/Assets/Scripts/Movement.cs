using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speedUp = 100f;
    [SerializeField] float RotationThrust = 1f;
    Rigidbody Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            Rigidbody.AddRelativeForce(Vector3.up * speedUp * Time.deltaTime);
        }

    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            Rigidbody.freezeRotation = true;
            transform.Rotate(Vector3.forward*RotationThrust*Time.deltaTime);
            Rigidbody.freezeRotation = false;
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            Rigidbody.freezeRotation = true;
            transform.Rotate(-Vector3.forward*RotationThrust*Time.deltaTime);
            Rigidbody.freezeRotation = false;
        }

    }
}
