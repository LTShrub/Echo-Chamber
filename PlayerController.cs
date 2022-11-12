using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController control;
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float speed;
    private GameObject focalPoint;
    public GameObject firstHouse;
    public GameObject secondHouse;
    public AudioClip walkSound;
    private AudioSource playerAudio;

    private void Awake()
    {
        if (control == null)
        {
            control = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.transform.Translate(Vector3.forward * speed * forwardInput);
        float sidewaysInput = Input.GetAxis("Horizontal");
        playerRb.transform.Translate(Vector3.right * speed * sidewaysInput);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Box"))
        {
          playerRb.transform.position = new Vector3(playerRb.transform.position.x, playerRb.transform.position.y + 1, playerRb.transform.position.z + 5);
          firstHouse.gameObject.SetActive(false);
          secondHouse.gameObject.SetActive(true);
          GameManager.gameManager.ending4.gameObject.SetActive(false);
          GameManager.gameManager.ending3.gameObject.SetActive(false);
          GameManager.gameManager.ending2.gameObject.SetActive(false);
          GameManager.gameManager.ending1.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("EchoSensor1")){
            GameManager.gameManager.AskQuestion(0);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("EchoSensor2")){
            GameManager.gameManager.AskQuestion(1);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("EchoSensor3")){
            GameManager.gameManager.AskQuestion(2);
            Destroy(other.gameObject);
        }
    }
}
