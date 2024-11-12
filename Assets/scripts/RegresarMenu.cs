using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarMenu : MonoBehaviour
{
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Asegúrate de que el nombre coincida con el de tu escena
    }
}
