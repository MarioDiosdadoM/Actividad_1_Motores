using UnityEngine;
using System.Collections;

public class LanzaLlamas : MonoBehaviour
{
    private ParticleSystem llamas;
    private Collider peligro;

    public float tiempoEncendido = 2f;
    public float tiempoApagado = 2f;

    private void Awake()
    {
        llamas = GetComponent<ParticleSystem>();
        peligro = GetComponent<Collider>();

        peligro.enabled = false;
    }
    void Start()
    {
        StartCoroutine(CicloLlamas());
    }

    private System.Collections.IEnumerator CicloLlamas()
    {
        while (true)
        {
            Encender();
            yield return new WaitForSeconds(tiempoEncendido);

            Apagar();
            yield return new WaitForSeconds(tiempoApagado);
        }
    }

    void Encender()
    {
        llamas.Play();
        peligro.enabled = true;
    }

    void Apagar()
    {
        llamas.Stop();
        peligro.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Contacto con lanzallamas");

        if (other.CompareTag("Jugador"))
        {
            Respawn reaparicion = other.GetComponent<Respawn>();

            if (reaparicion != null)
            {
                reaparicion.Reaparecer();
            }
        }
    }
}
