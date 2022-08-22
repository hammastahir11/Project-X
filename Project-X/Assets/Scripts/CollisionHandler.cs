using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] AudioClip collision;
    [SerializeField] AudioClip success;

    [SerializeField] ParticleSystem Crash;
    [SerializeField] ParticleSystem successParticles;
    




     AudioSource audioSource;
  
     bool isTransitioning = false;
     bool collisionDisable = false;

    void Start() {
            audioSource = GetComponent<AudioSource>();
            
     }

    void Update() {
        RespondToDebugKeys();
     }


     void RespondToDebugKeys() {
        if(Input.GetKeyDown(KeyCode.C)) {
            collisionDisable = !collisionDisable;
        }
        else if(Input.GetKeyDown(KeyCode.L)) {
            LoadNextLevel();
        }
     }
    void OnCollisionEnter(Collision other) 
    {
        if (isTransitioning || collisionDisable) {
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
        Crash.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", levelLoadDelay);
    }
    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        successParticles.Play();
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
