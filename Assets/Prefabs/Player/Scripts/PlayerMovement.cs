using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Atributos
    //fuerza utilizada para dar movimiento
    private Vector3 fuerzaPorAplicar;
    //Tiempo transcurrido desde la ultima aplicacion
    private float tiempoDesdeUltimaFuerza;
    //Cada cuanto se aplica la fuerza
    private float intervaloTiempo;
    
    #endregion

    #region Ciclo de vida del Script 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuerzaPorAplicar = new Vector3(0, 0, 300f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;
    }

    private void FixedUpdate()
    {
       tiempoDesdeUltimaFuerza += Time.fixedDeltaTime;
         if (tiempoDesdeUltimaFuerza >= intervaloTiempo)
         {
              GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar);
              tiempoDesdeUltimaFuerza = 0f;
         }
    }
    #endregion
}