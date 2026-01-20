using UnityEngine;

public class Respawn : MonoBehaviour
{
    [Header("Punto respawn")]
    public Transform puntoRespawn;

    public void Reaparecer()
    {
        Debug.Log("Llamada a reaparicion");

        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        transform.position = puntoRespawn.position;

        if (cc != null) cc.enabled = true;
    }
}
