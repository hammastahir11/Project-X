using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip collision;
    [SerializeField] AudioClip success;



     AudioSource audioSource;
     bool isTransitioning = false;

    void Start() {
            audioSource = GetComponent<AudioSource>();
     }
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning) {
            return;
        }
        switch (other.gameObject.tag)
        {
            case "Friendly":            
                break;
            case "Finish":
                StartSuccessSequence();               
                break;

            default:
                StartCrashSequence();
                break;
        }
    }


    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(collision);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", levelLoadDelay);
    }
    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void LoadNextLevel()
    {
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = currentSceneIndex + 1;
        if(NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0;
        }
        SceneManager.LoadScene(NextSceneIndex);
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
