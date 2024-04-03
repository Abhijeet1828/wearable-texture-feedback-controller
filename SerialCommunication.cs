using System.Collections;
using System.Collections.Generic; using UnityEngine;
using System.IO.Ports;
using System.Threading;
using System;

public class SerialCommunication : MonoBehaviour {

public SerialPort data_stream = new SerialPort("COM3", 9600); 

string hoverDenim;
string hoverLeather;
string clothesTouched;

DenimInteract clothesinteractable; 
public GameObject denimcube;

LeatherInteractable leatherInteractable; 
public GameObject leatherJacket;

void Awake() {

clothesinteractable = denimcube.GetComponent<DenimInteract>(); 
leatherInteractable = leatherJacket.GetComponent<LeatherInteractable>();

clothesTouched = "False";

// Open the serial stream and availability on the Arduino
data_stream.DtrEnable = true; 
data_stream.RtsEnable = true; 
data_stream.WriteTimeout = 300; 
data_stream.ReadTimeout = 5000;

data_stream.Open(); 
data_stream.WriteLine("1"); 
Debug.Log("First write to Arduino");

Thread thread = new Thread(Run);
thread.Start(); 
}

// Start is called before the first frame update
void Start() {
}

void Run() {
  Debug.Log("Inside Run Method "); 
  while (true)
  {
    data_stream.WriteLine(clothesTouched); 
    Debug.Log("Writing data to Arduino " + clothesTouched);
  } 
}

// Update is called once per frame
void Update() {
if(clothesinteractable.isHover == "True") {
  clothesTouched = "JeansT";
 } else if (leatherInteractable.isHover == "True") {
  clothesTouched = "LeatherT"; } 
else {
 clothesTouched = "False";
 } 
}
}
