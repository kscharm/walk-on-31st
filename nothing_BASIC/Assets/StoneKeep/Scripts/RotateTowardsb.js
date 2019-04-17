#pragma strict
//SIMPLE SCRIPT OT MOVE OBJECT FROM IT'S POSITION TO A NEW POSITION
static var players : GameObject[]; //all players, used to RPC
static var player : Transform; //the player, used to RPC
var startRot : Vector3; //the door's starting rotation
var newRot : Vector3; //the door's new (open) rotation
var rotateSpeed : int = 80; //how fast the door opens
var opened = false; //whether the door is opened or closed

function Start() {
	startRot = transform.rotation.eulerAngles;
}
function Action() {
	//if door is shut
	if(opened == false) {
		//while door's rotation is not equal to the new rotation
		var myRot : Vector3 = Vector3(0, 0, 0);
		while(transform.rotation.eulerAngles != newRot) {
			//rotate door
			transform.rotation.eulerAngles = Vector3.MoveTowards(transform.rotation.eulerAngles, newRot, Time.deltaTime * rotateSpeed);
			var distanceBetween : float = Vector3.Distance(transform.rotation.eulerAngles, newRot);
			if(distanceBetween < 0.1) {
				break;
			}
			
			//if object doesn't lerp... for whatever reason
			if(myRot != transform.rotation.eulerAngles) {
				myRot = transform.rotation.eulerAngles;
			}
			else {
				transform.rotation.eulerAngles = startRot;
				break;
			}
			yield;
		}
		//when while loop ends, opened is true
		opened = true;
	}//if door is open
	else {
		//while door's rotation is not equal to its starting rotation
		myRot = Vector3(0, 0, 0);
		while(transform.rotation.eulerAngles != startRot) {
			//rotate door
			transform.rotation.eulerAngles = Vector3.MoveTowards(transform.rotation.eulerAngles, startRot, Time.deltaTime * rotateSpeed);
			distanceBetween = Vector3.Distance(transform.rotation.eulerAngles, startRot);
			if(distanceBetween < 0.1) {
				break;
			}
			//if object doesn't lerp... for whatever reason
			if(myRot != transform.rotation.eulerAngles) {
				myRot = transform.rotation.eulerAngles;
			}
			else {
				transform.rotation.eulerAngles = startRot;
				break;
			}
			yield;
		}
		//when while loop ends, opened is false
		opened = false;
	}
}
