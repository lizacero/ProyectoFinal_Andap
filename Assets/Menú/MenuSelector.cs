using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSelector : MonoBehaviour
{
    private int index;
    [SerializeField] private Image Imagen;
    [SerializeField] private TextMeshProUGUI Nombre;

    private Manager manager;

    private void Start()
    {
        manager = Manager.Instance;
        index = PlayerPrefs.GetInt("JugadorIndex");
        CambiarPantalla();

        if (index > manager.personajes.Count -1)
        {
            index = 0;
        }

    }

    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("JugadorIndex", index);
        Imagen.sprite = manager.personajes[index].imagen;
        Nombre.text = manager.personajes[index].name;
    }

    public void SiguientePersonaje()
    {
        if (index == manager.personajes.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        CambiarPantalla();
    }

    public void AnteriorPersonaje()
    {
        if (index == 0)
        {
            index = manager.personajes.Count - 1;
        }
        else
        {
            index -= 1;
        }
        CambiarPantalla();
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Saliste del juego");
    }

}
