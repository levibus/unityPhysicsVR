Authors: Levi Busching, Ivan Cheah, Evan Bourke
Date: July 29, 2023
Description:

This scene contains a block that slides down a ramp. The block has freebody diagram arrows on it, 
such as the velocity, normal, friction, and x and y gravity component vectors. The arrows, board, 
and block can all have their visibility turned on and off. The angle of the ramp can be changed, 
and the static and dynamic coefficients of friction on the cube can be changed.

This demonstration is designed to be paired with a physical demonstration of the same setup, 
so that the physical cube can have the freebody diagram overlayed on it as it slides down the physical ramp. 
Unfortunately, the Oculus headset doesn't allow for object tracking, so this demonstration simply lines up 
the components of friction between the physical and virtual demonstrations so that the virtual arrows 
respond well to the movement of the physical block.

Scripts:
angleText.cs - Changes the angle of the ramp incline displayed in the UI.
arduinoCommunication.cs - Causes the arduino to be triggered when a button in the UI is pushed.
arrowUI.cs - Signals when the buttons are pushed to turn the arrows on/off.
board.cs - Changes the angle of the board and whether or not it is visible.
boardAngleEM.cs - Signals when the buttons are pushed to increase/decrease the angle of the board.
center.cs - Changes the direction and scale of the velocity and acceleration arrows on the cube.
            Currently, the acceleration arrow is commented out, as it is not useful for the demonstration.
cube.cs - Takes care of the cube GameObject: including the position, orientation, gravity, coefficient of friction, and visibility.
cubeCollision.cs - Signals when the cube hits the ground (so that some of the arrows can be destroyed)
dynoFrictionText.cs - Changes the text in the UI for the dynamic coefficient of friction.
frictionArrow.cs - Toggles the visibility (activity) of the friction arrow. This arrow will become inactive when the cube hits the ground.
                   Along with the rest of the arrows, it can be turned on and off by touching the frictionSnap UI button, or can be 
                   turned off by holding it close to the frictionSnap box.
frictionSnap.cs - Toggles the color of the frictionSnap box based on if the friction arrow is in the scene. It will be solid when the
                  arrow is active and foggy otherwise.
                  (it will remain solid when the friction arrow is destroyed after the cube hits the ground, because the friction arrow
                   is still deployed in the scene)
frictionUI.cs - Signals when the UI buttons are pressed to increase/decrease the dynamic or static coefficient of friction on the cube.
launchEM.cs - Signals when the "Launch" and "reset" buttons are pressed in the UI to launch the cube or return it to its starting position.
normalArrow.cs - Handles the position, orientation, and scaling of the normal, xGravity, yGravity, and friction arrows.
                 It uses a raycast pointed at the center of the cube in order to know the normal vector at that position.
normalArrowChange.cs - Toggles the visibility (activity) of the normal arrow.
                       Along with the rest of the arrows, it can be turned on and off by touching the normalSnap UI button, or can be 
                       turned off by holding it close to the normalSnap box.
normalSnapColor.cs - Toggles the color of the normalSnap box based on if the normal arrow is in the scene. It will be solid when the
                     arrow is active and foggy otherwise.
staticFrictionText.cs - Changes the text in the UI for the static coefficient of friction.
velocityArrow.cs - Toggles the visibility (activity) of the velocity arrow. This arrow will become inactive when the cube hits the ground.
                   Along with the rest of the arrows, it can be turned on and off by touching the velocitySnap UI button.
velSnap.cs - Toggles the color of the velocitySnap box based on if the velocity arrow is in the scene. It will be solid when the
             arrow is active and foggy otherwise.
             (it will remain solid when the velocity arrow is destroyed after the cube hits the ground, because the velocity arrow
              is still deployed in the scene)
visibleUI.cs - Signals when the UI buttons and pushed to turn the block and board visibility on/off.
xGravityArrow.cs - Toggles the visibility (activity) of the xGravity arrow. This arrow will become inactive when the cube hits the ground.
                   Along with the rest of the arrows, it can be turned on and off by touching the xGravitySnap UI button, or can be 
                   turned off by holding it close to the xGravitySnap box.
xGravSnap.cs - Toggles the color of the xGravitySnap box based on if the xGravity arrow is in the scene. It will be solid when the
               arrow is active and foggy otherwise.
               (it will remain solid when the xGravity arrow is destroyed after the cube hits the ground, because the xGravity arrow
                is still deployed in the scene)
yGravityArrow.cs - Toggles the visibility (activity) of the yGravity arrow. 
                   Along with the rest of the arrows, it can be turned on and off by touching the yGravitySnap UI button, or can be 
                   turned off by holding it close to the yGravitySnap box.
yGravSnap.cs - Toggles the color of the yGravitySnap box based on if the yGravity arrow is in the scene. It will be solid when the
               arrow is active and foggy otherwise.