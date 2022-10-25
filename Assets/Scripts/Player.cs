using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rigid;
    int i = 0;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rigid = GetComponent<Rigidbody>();
        
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rigid.AddForce(0, 250, 0);
        }
        
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "test")
        {
            i++;
            GameManager.thisManager.UpdateScore(i);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Walls")
        {
            SceneManager.LoadScene("GameOver");
        }

        if(collision.gameObject.tag == "obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
