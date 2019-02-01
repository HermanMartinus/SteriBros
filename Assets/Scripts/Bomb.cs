using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public float _force;
    public GameObject boom;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            boom.SetActive(true);
            collision.collider.GetComponent<Rigidbody2D>().AddForceAtPosition(transform.forward * _force, transform.position);
            Destroy(gameObject, 0.5f);
        }
    }
}
