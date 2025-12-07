using UnityEngine;
using UnityEngine.InputSystem;

public class ControlDePersonaje : MonoBehaviour
{

    public float velocidadMovimiento = 8f;
    public float velocidadRotacion = 200f;

    private CharacterController controlador;
    private PlayerControls controles;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controlador = GetComponent < CharacterController >();
        controles = new PlayerControls();

    }

    private void OnEnable() => controles.Enable();
    private void OnDisable() => controles.Disable();
    


    // Update is called once per frame
    void Update()
    {

        float moverInput = controles.Personaje.Mover.ReadValue<float>();
        float rotarInput = controles.Personaje.Rotar.ReadValue<float>();

        Debug.Log("MoverInput: " + moverInput + " | RotarInput: " + rotarInput);

        transform.Rotate(0f, rotarInput * velocidadRotacion * Time.deltaTime, 0f);

        Vector3 move = transform.forward * moverInput * velocidadMovimiento;
        controlador.Move(move * Time.deltaTime);
    }
}
