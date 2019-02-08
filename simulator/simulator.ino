/*
 * This Arduino sketch simulates an AstroHaven dome.
 * Refer to your dome manual.
 */
 
#include <stdio.h> // for function sprintf

bool DEBUG=false;
int step = 10;
int leftShutterOpenPerc = 0;  // percentage open (left shutter)
int rightShutterOpenPerc = 0; // percentage open (right shutter)

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

/*
  SerialEvent occurs whenever a new data comes in the hardware serial RX. This
  routine is run between each time loop() runs, so using delay inside loop can
  delay response. Multiple bytes of data may be available.
*/
void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char c = (char)Serial.read();
    parseCommand(c);
  }
}

void loop() {
  // put your main code here, to run repeatedly:
  replyWithStatus();
  delay(1000);
}

void replyWithStatus() {
    if ((leftShutterOpenPerc == 0) && (rightShutterOpenPerc == 0))
        Serial.print(0); // both shutters closed
    else if ((leftShutterOpenPerc > 0) && (rightShutterOpenPerc == 0))
        Serial.print(1); // only right shutter is closed
    else if ((leftShutterOpenPerc == 0) && (rightShutterOpenPerc > 0))
        Serial.print(2); // only left shutter is closed
    else if ((leftShutterOpenPerc > 0) and (rightShutterOpenPerc > 0))
        Serial.print(3); // both shutter are open
}

void parseCommand(char s) {

    if ((s == 'D') || DEBUG) {
        Serial.print("left shutter:"); Serial.println(leftShutterOpenPerc);
        Serial.print("right shutter:"); Serial.println(rightShutterOpenPerc);
    }
    
    if (s == 'S') {
        replyWithStatus();
    }
    else if (s == 'A') { 
        // Attempt to close the left shutter
        if (leftShutterOpenPerc > 0) {
            leftShutterOpenPerc -= step;
        } else {
            // Cannot close the left shutter as it is already closed
            leftShutterOpenPerc = 0;
            Serial.print('X'); 
        }
    }
    else if (s == 'B') { 
        // Attempt to close the right shutter
        if (rightShutterOpenPerc > 0) {
            rightShutterOpenPerc -= step;
        } else {
            // Cannot close the right shutter as it is already closed
            rightShutterOpenPerc = 0;
            Serial.print('Y');
      }
    }
    else if (s == 'a') { 
        // Attempt to open the left shutter
        if (leftShutterOpenPerc < 100) {
            leftShutterOpenPerc += step;
        } else {
          // Cannot open the left shutter as it is already open
            leftShutterOpenPerc = 100;
            Serial.print('x');
        }
    }
    else if (s == 'b'){ 
      // Attempt to open the right shutter
        if (rightShutterOpenPerc < 100) {
            rightShutterOpenPerc += step;
        } else {
          // Cannot open the right shutter as it is already open
            rightShutterOpenPerc = 100;
            Serial.print('y'); 
        }
    } 
    else if (s == 'O'){ 
        // Fully open both shutters
        if ((rightShutterOpenPerc < 100) || (leftShutterOpenPerc < 100)) {
          delay(10000); // 10 seconds approx. to open both
          rightShutterOpenPerc = 100;
          leftShutterOpenPerc = 100;
        }
    } 
    else if (s == 'C'){ 
        // Fully close both shutters
        if ((rightShutterOpenPerc > 0) || (leftShutterOpenPerc > 0)) {
          delay(10000); // 10 seconds approx. to open both
          rightShutterOpenPerc = 0;
          leftShutterOpenPerc = 0;
        }
    } 
    else if (s == 'R'){ 
        // Reset the BG controller after the BG switch has been bumped
        delay(10000);
    } 
}
