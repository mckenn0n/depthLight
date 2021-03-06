
/*
http://tolsonwinters.com/a/HC_SR04_Range_Finder.ino
HC-SR04 Ping distance sensor
VCC to Arduino 5V
GND to Arduino GND
Echo to Arduino pin 2
Trig to Arduino pin 3
Original code improvements to the Ping sketch sourced from Trollmaker.com
Some code and wiring inspired by http://en.wikiversity.org/wiki/User:Dstaub/robotcar
Modified by Tolson Winters (Aug 27, 2014) for simplified serial monitor reading.
Modified by McKennon McMillian
*/

//Define pins and array size
#define trigPin 3
#define echoPin 2
#define SIZE 20 //Size of array


void setup() {
  Serial.begin (115200);
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
}

void loop() {
  long duration;
  float distance, average, sum;
  int i;
  for(i = 0; i < SIZE; i++){
  digitalWrite(trigPin, LOW);
  delayMicroseconds(2);
  digitalWrite(trigPin, HIGH);
  delayMicroseconds(10);
  digitalWrite(trigPin, LOW);
  duration = pulseIn(echoPin, HIGH);
  distance = duration / 58.2; // time/speedOfSound 
  
    sum += distance;
  }
  average = float(sum) / SIZE;
  //The HC-SR04 has a max read distance 4 meters. If the average is greater than 400cm average is set to 400
  if(average > 400){
    average = 400;
  }
    Serial.flush();
    Serial.print(average); //Send average as cm
    Serial.println();
  
  delay(10);
}
