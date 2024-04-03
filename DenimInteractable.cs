using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class DenimInteract : MonoBehaviour {

public string isHover = "False";

public void HoverOverDenim() {
 GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
 isHover = "True"; 
 }

public void HoverEndDenim() {
 GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
 isHover = "False"; 
 }
}