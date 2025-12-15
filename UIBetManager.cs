using UnityEngine;

public class UIBetManager : MonoBehaviour
{
  
    public GameObject panelApuesta;
    public GameObject botonReintentar;
    public UICoinFlip coin;

    private int apuesta = -1;

    private void Start()
    {
        panelApuesta.SetActive(true);  // mostramos panel de apuesta al inicio
        botonReintentar.SetActive(false);   // ocultamos el boton de reintento al inicio
    }

    // Metodo llamado cuando el jugador apuesta a cara
    public void ApostarCara()
    {
        apuesta = 0;
        panelApuesta.SetActive(false); // ocultamos panel de apuesta
        botonReintentar.SetActive(false); // ocultamos boton de reintento
        coin.IniciarLanzamiento(this); // iniciamos el lanzamiento de la moneda
    }

    // Metodo llamado cuando el jugador apuesta a cruz
    public void ApostarCruz()
    {
        apuesta = 1;
        panelApuesta.SetActive(false);      
        botonReintentar.SetActive(false);   
        coin.IniciarLanzamiento(this);      
    }

    // Metodo llamado desde UICoinFlip al terminar la animacion
    public void Resultado(int resultado)
    {
        if (apuesta == resultado)
        {
            GameManager.Instance.GanarDinero(100);  // suma dinero al jugador
            Debug.Log("✔ ¡Ganaste la apuesta! +100 dinero");
        }
        else
        {
            GameManager.Instance.cordura -= 10; // resta cordura
            Debug.Log("✘ Perdiste la apuesta... -10 cordura");
        }

        // Actualiza la UI 
        GameManager.Instance.OnEstadisticasActualizadas?.Invoke();

        // Otra apuesta
        botonReintentar.SetActive(true);
    }

    // Metodo llamado por el boton "Volver a apostar"
    public void VolverAApostar()
    {
        panelApuesta.SetActive(true);       
        botonReintentar.SetActive(false);  
    }
}
