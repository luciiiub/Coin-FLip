using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICoinFlip : MonoBehaviour
{
    // Array de sprites que representan las dos caras de la moneda
    public Sprite[] sides;


    private Image coinImage;
    private bool isFlipping = false;  // Impedir lanzar la moneda varias veces mientras esta girando!!!
    private UIBetManager betManager;

    private void Awake()
    {
        coinImage = GetComponent<Image>(); 
    }

    
    public void IniciarLanzamiento(UIBetManager manager)
    {
        betManager = manager; 
        OnClickCoin();   // Llama al metodo que inicia el giro
    }

    // Comprueba si la moneda no esta girando antes de empezar
    public void OnClickCoin()
    {
        if (!isFlipping)
            StartCoroutine(FlipCoin());
    }

    // Corrutina que realiza la animacion completa del lanzamiento
    IEnumerator FlipCoin()
    {
        isFlipping = true;   // Bloquea nuevos lanzamientos !!!!

        float duration = 0.02f;  // Velocidad del flip
        int flips = Random.Range(5, 10);    // N de giros
        int randomSide = Random.Range(0, 2);    // Cara aleatoria final (0 o 1)

        // Bucle animacion giro
        for (int i = 0; i < flips; i++)
        {
            // Escala hacia abajo simulando la vuelta!!
            for (float scaleY = 1f; scaleY > 0f; scaleY -= 0.25f)
            {
                transform.localScale = new Vector3(1, scaleY, 1);
                yield return new WaitForSeconds(duration);
            }

            coinImage.sprite = sides[i % 2];       // Cambia temporalmente entre cara y cruz

            for (float scaleY = 0f; scaleY < 1f; scaleY += 0.25f)  // Escala hacia arriba volviendo a tamaño normal
            {
                transform.localScale = new Vector3(1, scaleY, 1);
                yield return new WaitForSeconds(duration);
            }
        }

        // Ultima animacion antes de mostrar el resultado real
        for (float scaleY = 1f; scaleY > 0f; scaleY -= 0.25f)
        {
            transform.localScale = new Vector3(1, scaleY, 1);
            yield return new WaitForSeconds(duration);
        }

        coinImage.sprite = sides[randomSide];     // Se asigna la cara final correcta

        // Animacion final de escalado hacia arriba
        for (float scaleY = 0f; scaleY <= 1f; scaleY += 0.25f)
        {
            transform.localScale = new Vector3(1, scaleY, 1);
            yield return new WaitForSeconds(duration);
        }


        transform.localScale = new Vector3(1, 1, 1);   // Asegura que queda en tamano normal

        isFlipping = false;  
        
        if (betManager != null)
            betManager.Resultado(randomSide);
    }
}
