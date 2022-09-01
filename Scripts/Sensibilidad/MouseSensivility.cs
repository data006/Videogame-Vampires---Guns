using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class MouseSensivility : MonoBehaviour
{


    public EstadoSensibilidad estadoSensibilidad;

    public Slider sensitivitySlider;

    public void ApplySensitivity()
    {
        GetComponent<FirstPersonController>().ChangeMouseSensitivity(estadoSensibilidad.x, estadoSensibilidad.x);
    }
}