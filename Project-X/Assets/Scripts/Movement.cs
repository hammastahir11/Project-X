 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speedUp = 100f;
    [SerializeField] float RotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;

     
    Rigidbody Rigidbody;
    AudioSource audioSource;
    


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust(){
        if(Input.GetKey(KeyCode.Space)){
            Rigidbody.AddRelativeForce(Vector3.up * speedUp * Time.deltaTime);
            if(!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
        }
        else{
            audioSource.Stop();
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
