using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soccer_Ball : MonoBehaviour
{
    [SerializeField] float kickForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("something");
        if (collision.gameObject.CompareTag("KickHitBox")) {
            Debug.Log("kicked");
            ContactPoint2D punto = collision.GetContact(0);

            Vector2 direccion = (new Vector2 (transform.position.x, transform.position.y) - punto.point).normalized;

            GetComponent<Rigidbody2D>().velocity = direccion * kickForce;
        }
    }
}
