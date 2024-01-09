using System.Collections;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Transform spriteTransform;
    public Player player;

    void Start()
    {
        spriteTransform = GetComponent<Transform>();
        StartCoroutine(ScaleCoroutine());
    }

    IEnumerator ScaleCoroutine()
    {
        while (true)
        {
            spriteTransform.localScale = new Vector3(spriteTransform.localScale.x, spriteTransform.localScale.y + 10f, spriteTransform.localScale.z); ;

            yield return new WaitForSeconds(3.0f);

            spriteTransform.localScale = new Vector3(spriteTransform.localScale.x, 0, spriteTransform.localScale.z); ;

            yield return new WaitForSeconds(3.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.takeDamage(100);
            Destroy(collision.gameObject);
        }
    }
}
