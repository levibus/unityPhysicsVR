Authors: Levi Busching, Evan Bourke
Date: July 29, 2023
Description:

    This is a VR scene in which the user launches a ball equipped with velocity (purple) and acceleration (yellow) arrows.
The user can manipulate the launch angle, launch height, and launch speed. This demo is meant to be used to gain an understanding
of basic kinematics.

Scripts:

angleEM.cs - Signals when the buttons are pushed to increase/decrease the launch angle.
angleText.cs - Creates the text UI for the launch height, launch force, and launch angle of the ball.
BallScript.cs - Takes care of ball movement and starting position. It contains the functions to launch and reset the ball.
drawProjection.cs - Draws the projected launch path of the ball.
EventManager.cs - Signals when the buttons are pushed to launch and reset the ball.
heightEM.cs - Signals when the buttons are pushed to increase/decrease the height of the ball.
ObjectCenter.cs - Modifies the velocity and acceleration arrows inflight and before the launch. Calculates the velocity and acceleration 
                  to change the position, orientation, and scaling of the arrows, as well as changes their activity status.
speedEM.cs - Signals when the buttons are pushed to increase/decrease the launch angle.
startingPosition.cs - A class to keep track of the starting position of the ball with getters and setters.