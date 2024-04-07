using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] float forwardVelocity;
    [SerializeField] float forwardAcceloration;
    [SerializeField] float horizontalVelocity;
    [SerializeField] float jumpHeight;
    [SerializeField] string roadTag;
    [SerializeField] string groundTag;
    [SerializeField] string obsticleTag;
    [SerializeField] GameLogic gameLogic;
    [SerializeField] ParticleSystem explosion;
    Animator animator;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.forward * forwardVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity += Vector3.forward * forwardAcceloration * Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Translate(-horizontalVelocity * Time.deltaTime,0,0);
        }
        if(Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(horizontalVelocity * Time.deltaTime, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight,ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == obsticleTag || collision.gameObject.tag == groundTag)
        {
            ShipExplosion();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == roadTag) 
        {
            ShipExplosion();
        }
    }

    void ShipExplosion()
    {
        animator.SetTrigger("Explode");
        StartCoroutine(SetExplosion());
    }

    IEnumerator SetExplosion()
    {
        explosion.Play();
        yield return new WaitForSeconds(3.5f);
        gameLogic.GameOver();
    }
}
