using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour
{
    [Header("Control Settings")]
    [SerializeField]
    private float speed = 1f;
    public float maxAngularVelocity;
    private Rigidbody rb;
    private bool isRigidbody;

    void Start()
    {
        if(isRigidbody = TryGetComponent<Rigidbody>(out rb))
        {
            rb.maxAngularVelocity = maxAngularVelocity;
        }
    }
    private void Update()
    {
        if(transform.position.y <= -10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void FixedUpdate()
    {
        float Hdirection;
        float Vdirection;

        if ((Hdirection = Input.GetAxis("Horizontal")) != 0)
        {
            rb.AddForce(Hdirection * speed * Time.fixedDeltaTime, 0, 0);
        }


        if ((Vdirection = Input.GetAxis("Vertical")) != 0)
        {
            rb.AddForce(0, 0, Vdirection * speed * Time.fixedDeltaTime);
        }
    }
}
