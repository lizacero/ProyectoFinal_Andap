using UnityEngine;

public class SpawnJugador : MonoBehaviour
{
    public GameObject[] personajes;
  
    private void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        //Instantiate(Manager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);
        if (indexJugador == 0)
        {
            personajes[0].SetActive(true);
            personajes[1].SetActive(false);
            GameManager.instance.player = personajes[0].GetComponent<PlayerController>();
        }
        else if (indexJugador == 1)
        {
            personajes[0].SetActive(false);
            personajes[1].SetActive(true);
            GameManager.instance.player = personajes[1].GetComponent<PlayerController>();
        }
    }

}
