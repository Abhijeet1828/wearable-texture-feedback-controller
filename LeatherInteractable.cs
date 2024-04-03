using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class LeatherInteractable : MonoBehaviour {
public string isHover = "False";

public void HoverOver() {
 GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
 isHover = "True"; 
 }

public void HoverEnd() {
 GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
 isHover = "False"; 
 }
}