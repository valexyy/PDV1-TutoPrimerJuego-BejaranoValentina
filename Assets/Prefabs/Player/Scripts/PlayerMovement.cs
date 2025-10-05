using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Modelo de datos del jugador
    private Player player;
    // Estrategia de movimiento lateral
    private IMovementStrategy movementStrategy;

    // Fuerza utilizada para avanzar
    private Vector3 fuerzaPorAplicar;
    private float tiempoDesdeUltimaFuerza;
    private float intervaloTiempo;

    void Start()
    {
        // Inicializa el modelo del jugador
        player = new Player(velocidad: 5f, aceleracion: 2f);
        movementStrategy = new LateralMovement(); // O usa AceletareMovement si prefieres aceleración

        fuerzaPorAplicar = new Vector3(0, 0, 300f);
        tiempoDesdeUltimaFuerza = 0f;
        intervaloTiempo = 2f;
    }

    void Update()
    {
        // Movimiento lateral con A/D o flechas
        movementStrategy.Move(transform, player);
    }

    void FixedUpdate()
    {
        // Movimiento hacia adelante cada cierto tiempo
        tiempoDesdeUltimaFuerza += Time.fixedDeltaTime;
        if (tiempoDesdeUltimaFuerza >= intervaloTiempo)
        {
            GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar);
            tiempoDesdeUltimaFuerza = 0f;
        }
    }
}