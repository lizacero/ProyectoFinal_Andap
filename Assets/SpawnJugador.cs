using UnityEngine;

public class SpawnJugador : MonoBehaviour
{
  
    private void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(Manager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);
    }

}
