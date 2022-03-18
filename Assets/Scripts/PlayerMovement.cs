using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Oyuncunun Hizi")]

    [SerializeField] private float playerSpeed;
    private Rigidbody playerRb;
    private bool isPlaying = false;
    [SerializeField] private float sideLerpSpeed;
    [SerializeField] LayerMask layer;

    [SerializeField] Material ChangeRedBall;
    [SerializeField] Material ChangeBlueBall;
    [SerializeField] Material ChangeGreenBall;
    private Renderer myRenderer;
  



    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.velocity = transform.forward * playerSpeed;

        myRenderer = GetComponent<Renderer>();

    }


    void FixedUpdate()
    {
        if (isPlaying == true)
        {
            MoveForward();
            MoveSideways();
        }

        if (Input.GetMouseButton(0))
        {
            if (isPlaying == false)
            {
                isPlaying = true;
            }
         
        }

        Vector3 posX = transform.position;
        posX.x = Mathf.Clamp(transform.position.x, -0.53f, 1.553f);
        transform.position = posX;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bluegate"))
        {
            myRenderer.material = ChangeBlueBall;
            transform.gameObject.tag = ("blue");
        }
        if (other.gameObject.CompareTag("greengate"))
        {
            myRenderer.material = ChangeGreenBall;
            transform.gameObject.tag = ("green");
        }
        if (other.gameObject.CompareTag("redgate"))
        {
            myRenderer.material = ChangeRedBall;
            transform.gameObject.tag = ("red"); 

            
        }
        if (other.gameObject.CompareTag("finish"))
        {
            playerSpeed = 0;
            sideLerpSpeed = 0;
            //oyunbittiekraný

        }
    }



    void MoveForward()
    {
        playerRb.velocity =Vector3.forward * playerSpeed;
    }

    void MoveSideways()
    {
        Ray MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(MyRay, out hit, 100, layer))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), sideLerpSpeed * Time.deltaTime);
        }
    }
}
