using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 15.0f;
    [SerializeField] float jumpForce = 10f;
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;
    [SerializeField] float jumpCheckDis;
    [SerializeField] LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        movedirection = new Vector3(horizontalInput * speed, rb.velocity.y, 0);

        if(Input.GetKeyDown(KeyCode.Space) && Grounded())
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = movedirection;
        if (horizontalInput == 0)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
        if (Grounded())
            Debug.Log("Ground");
        else Debug.Log("Not grounded");
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Powerup")
        {
            //Debug.Log("Powerup");
            collision.gameObject.GetComponent<Powerup>().Activate(gameObject);
        }
        else return;
    }

    bool Grounded()
    {
        if(Physics.BoxCast(GetComponent<Collider>().bounds.center, transform.localScale * 0.5f, -transform.up, transform.rotation, jumpCheckDis, groundLayer))
        {
            return true;
        }
        else return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(GetComponent<Collider>().bounds.center + -transform.up * jumpCheckDis, transform.localScale);
    }
}
