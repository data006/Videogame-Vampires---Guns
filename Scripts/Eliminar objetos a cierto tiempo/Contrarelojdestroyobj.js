var reloj : float = 0;
var objeto : GameObject;

function Update () {
  reloj -= Time.deltaTime;
  if(reloj<=0){
  objeto.SetActive (false);
  }
}