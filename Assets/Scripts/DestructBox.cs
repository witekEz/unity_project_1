using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructBox : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public int hp;
    public bool isRigidBody = false;

    private Material material;
    private int maxHp = 3;
    private Rigidbody rb;

    void Start()
    {
        hp= Mathf.Clamp(hp, 1,maxHp);
        material = GetComponent<MeshRenderer>().material;
        SetColor();
        if(isRigidBody)
        {
            rb=gameObject.AddComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode=CollisionDetectionMode.Continuous;
            rb.mass = 0.75f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            hp--;

            if(hp>0)
            {
                SetColor();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    void SetColor()
    {
        material.color = Color.Lerp(endColor, startColor, ((float)hp - 1) / ((float)maxHp - 1));
    }
    private void OnValidate()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        SetColor();
    }
}
