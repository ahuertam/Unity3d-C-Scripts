using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour 
{
//Sounds
[SerializeField] private AudioSource soundSource;
[SerializeField] private AudioClip hitWallSound;
[SerializeField] private AudioClip hitEnemySound;
//
private Camera _camera;
	
//START/////////////////////////////////////
void Start() {

//Accede al elemento camara del componente al que esté atached
_camera = GetComponent<Camera>();
//Esconde el cursor
Cursor.lockState = CursorLockMode.Locked;
Cursor.visible = false;


			}
//ONGUI///////////////////////////////////		
void OnGUI() {
int size = 12;
float posX = _camera.pixelWidth/2 - size/4;
float posY = _camera.pixelHeight/2 - size/2;
GUI.Label(new Rect(posX, posY, size, size), "*");
			}

//UPDATE/////////////////////////////////			
void Update() {
	//responde al click izdo del ratón
if (Input.GetMouseButtonDown(0)) {
	//se localiza la mitad de la pantalla
Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
// creamos un Raycast que sale de la posición central
Ray ray = _camera.ScreenPointToRay(point);
RaycastHit hit;

// Respuesta al Hit
if (Physics.Raycast(ray, out hit))
					 {
GameObject hitObject = hit.transform.gameObject;
ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
if (target != null) {
					target.ReactToHit();
					soundSource.PlayOneShot(hitEnemySound);

				} else {
					StartCoroutine(SphereIndicator(hit.point));
					soundSource.PlayOneShot(hitWallSound);
				}
					}	

						}
			}
////////////////////////////////////////

// La corutina usa las funciones de IEnumerator 
private IEnumerator SphereIndicator(Vector3 pos) 
	{
GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
sphere.transform.position = pos;
//yield le dice a la corutina cuando pausar 
yield return new WaitForSeconds(1);

//Destruye la esfera
Destroy(sphere);
	}

}