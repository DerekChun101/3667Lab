using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloon : MonoBehaviour
{
    [SerializeField] GameObject controller;
    [SerializeField] AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        if (audio == null)
        {
            audio = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("pin")))
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            score();
        }
       
    }
    void score()
    {
        if (gameObject.transform.localScale.x < 1.5 && gameObject.transform.localScale.y < 1.5)
        {
            controller.GetComponent<Score>().AddPoints(1);
            Debug.Log("1");
        }
        else if (gameObject.transform.localScale.x > 1.5 && gameObject.transform.localScale.y > 1.5)
        {
            if (gameObject.transform.localScale.x < 1.9 && gameObject.transform.localScale.y < 1.9)
            {
                controller.GetComponent<Score>().AddPoints(2);
                Debug.Log("2");
            }
        }
        else
            controller.GetComponent<Score>().AddPoints(3);
    }
}
