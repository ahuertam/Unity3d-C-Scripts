using UnityEngine;
using System.Collections;
public class Spin : MonoBehaviour {
public float Velocidad = 4.0f; // Establece una variable Pública que podrás editar
void Update() { // Se actualiza cada Frame
transform.Rotate(0, Velocidad, 0); // Transform se activa sobre el objeto al que se aplique el script
// En este caso le estamos diciendo que gire sobre sí mismo con una velocidad que podamos modificar.
}
}
