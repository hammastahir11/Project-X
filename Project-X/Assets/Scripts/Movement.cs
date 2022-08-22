 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] float speedUp = 100f;
    [SerializeField] float RotationThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem Flame0;
    [SerializeField] ParticleSystem Flame1;
    [SerializeField] ParticleSystem Flame2;
    [SerializeField] ParticleSystem Flame3;

     
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
            if(!Flame0.isPlaying)
            {
                RocketFlames();
            }
        }
        else
        {
            StopMethod();
        }

    }

    private void StopMethod()
    {
        audioSource.Stop();
        Flame0.Stop();
        Flame1.Stop();
        Flame2.Stop();
        Flame3.Stop();
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

    void RocketFlames(){
        
                Flame0.Play();
                Flame1.Play();
                Flame2.Play();
                Flame3.Play();

        

    }
}
