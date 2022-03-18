using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallController : MonoBehaviour
{
    [SerializeField] private GameObject pointParticle;
    [SerializeField] private GameObject deathParticle;
    [SerializeField] private cameracontrol _cameracontrol;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("red"))
        {

            Instantiate(deathParticle, other.gameObject.transform.position, other.gameObject.transform.rotation);
            _cameracontrol.enabled = false;
            Destroy(other.gameObject);


        }
        if (other.CompareTag("blue"))
        {
            Instantiate(deathParticle, other.gameObject.transform.position, other.gameObject.transform.rotation);
            _cameracontrol.enabled = false;
            Destroy(other.gameObject);


        }
        if (other.CompareTag("green"))
        {
            //skor
            Destroy(gameObject);
            Instantiate(pointParticle, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
