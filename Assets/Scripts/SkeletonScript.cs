using UnityEngine;
using System.Collections;

public class SkeletonScript : MonoBehaviour
{
    public GameObject pref;
    public Rigidbody2D rb2d;
    private IEnumerator SpawnBone() {
        Instantiate(pref, new Vector2(transform.position.x, transform.position.y + .5f), transform.rotation);
        yield return new WaitForSeconds(3);
        StartCoroutine(SpawnBone());
    }
    void Start()
    {
        StartCoroutine(SpawnBone());
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(-2.5f, rb2d.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Bark") {
            Instantiate(pref, new Vector2(transform.position.x, transform.position.y + .5f), transform.rotation);
        }
    }
}
