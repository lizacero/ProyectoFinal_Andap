using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadScene : MonoBehaviour
{
    public GameObject PantallaNivel;
    public GameObject PantallaVictoria;
    public GameObject PantallaDerrota;

    public void Update()
    {
        Victoria();
        Derrota();
    }


    void Victoria()
    {
        if (Input.GetKeyDown(KeyCode.X)) 
        {
            PantallaDerrota.SetActive(false);
            PantallaVictoria.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Derrota()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PantallaVictoria.SetActive(false);
            PantallaDerrota.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
