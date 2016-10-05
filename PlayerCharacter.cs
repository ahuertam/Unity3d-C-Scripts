using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
private int _health;
private int _healthDefined;
public Text myText;
private int score;

void Start() {
score = 0;
_health = 10;
_healthDefined = _health;
setvidas();
}

public void Hurt(int damage) {
_health -= damage;
Debug.Log("Vidas: " + _health);
setvidas();

if (_health <=0){
	_health= _healthDefined;
	Application.LoadLevel("Practica6cocos1");
			}
}// Hurt

void setvidas(){
myText.text ="Vidas:"  + _health.ToString ();
}

public void addScore (int monsterPoint){ //Futuro método para llevar el Score

score += monsterPoint;
Debug.Log ("la puntuación es de : "+ score);
				}

}//CLASS