using UnityEngine;

public class Reposition : MonoBehaviour
{
    private Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }
        Vector3 playerPosition = GameManager.instance.player.transform.position;
        Vector3 myPosition = transform.position;
        float diffX = Mathf.Abs(playerPosition.x - myPosition.x);
        float diffY = Mathf.Abs(playerPosition.y - myPosition.y);

        Vector2 playerDirection = GameManager.instance.player.inputVector;
        float directionX = playerDirection.x < 0 ? -1 : 1;
        float directionY = playerDirection.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY){
                    transform.Translate(Vector3.right * directionX * 40);
                }
                else if (diffX < diffY){
                    transform.Translate(Vector3.up * directionY * 40);
                }
                break;
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDirection * 20 + new Vector2(Random.Range(-3, 3), Random.Range(-3, 3)));
                }
                break;
        }
    }
}
