using UnityEngine;

public class Reloj : MonoBehaviour
{
    public float timeToDestroy = 8f;
    void Update()
    {
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0f)
        {
            Destroy(this.gameObject);
            RelojSpawner.instance.clocksOnMap--;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player ha entrado en el trigger");
            GameManager.instance.maxGameTime += 35f;
            Destroy(this.gameObject);
            RelojSpawner.instance.clocksOnMap--;
        }
    }


}
