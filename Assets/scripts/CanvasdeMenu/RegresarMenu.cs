using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresarMenu : MonoBehaviour
{
    public void VolverAlMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Aseg�rate de que el nombre coincida con el de tu escena
    }
}
