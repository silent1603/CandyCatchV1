using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    // Start is called before the first frame update
    [SerializeField] float speed = 20;
    [SerializeField]float maxPos;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            Move();
        }
    }
    private void Move()
    {
        float xInput = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * speed * xInput*Time.deltaTime;
        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);

        transform.position = new Vector3(xPos , transform.position.y, transform.position.z);
    }
}
