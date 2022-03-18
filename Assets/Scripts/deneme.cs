using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed;
    private Rigidbody PlayerRb;
    private bool isPlaying = false;
    [SerializeField] private float SideLerpSpeed;
    [SerializeField] LayerMask layer;




    void Start()
    {
        PlayerRb = GetComponent<Rigidbody>();
        PlayerRb.velocity = transform.forward;

    }

    void MoveForward()
    {
        PlayerRb.velocity = Vector3.forward * PlayerSpeed;

    }

    void MoveSideWays()
    {
        Ray MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(MyRay, out hit, 100, layer))
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(hit.point.x, transform.position.y, transform.position.z), SideLerpSpeed * Time.deltaTime);
        }

    }

    private void FixedUpdate()
    {
        if (isPlaying == true)
        {
            MoveForward();
            MoveSideWays();
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

}
