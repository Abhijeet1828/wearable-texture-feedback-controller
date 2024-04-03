#include<AFMotor.h>
#include <Servo.h>

// Defining the motors
Servo myservo;
AF_DCMotor motor(1);

String last_item_touched = "LeatherT";

void setup() {
  Serial.begin(9600);

  motor.setSpeed(100);
    motor.run(RELEASE);

  myservo.attach(9);
}

void loop() {

if(Serial.available() > 0) {
  String touch_clothes = Serial.readStringUntil('\n');
  touch_clothes.trim();

  if(touch_clothes.equals("JeansT") || touch_clothes.equals("LeatherT")){
    checkLastItemTouched(touch_clothes);
  }else {
    bringDown();
  }
}

}

void checkLastItemTouched(String currentItem) {
  if(currentItem.equals(last_item_touched)) {
    bringUp();
  } else {
    changeAndBringUp(currentItem);
  }
}

void changeAndBringUp(String currentItem) {
  last_item_touched = currentItem;
  motor.run(FORWARD);
  delay(200);
  motor.run(RELEASE);

  myservo.write(55);

}

void bringUp() {
  myservo.write(55);
}

void bringDown() {
  myservo.write(130);
}
