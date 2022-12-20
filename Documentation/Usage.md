# Usage

## Experimentor Usage
Before using the project:
1. [Install](/Documentation/Installation.md) the project
2. Add the images to the project's directory
	* Add a folder for each of the conditions in the Resources\Conditions folder
		* Add the images rendered for each condition to the corresponding folders
3. Modify Manage.Installation() for the experiment. Ensure that:
	* numberOfConditions match the number of conditions of the experiment 
	* conditionNames[] match the folder name for each condition

To use this project:
1. Connect a virtual reality headset to Unity. 
	* For the Meta Quest 2, connect the headset to the computer via usb-C and launch Quest Link
2. Run Start>'Run Aquisition' and enter the subject's name
3. Have the subject put the headset on and start the experiment

## Subject Usage
To start the experiment, the subject must press either 'Left Alt' or 'Space' on the keyboard. 

Sets of stereo-pair images will be displayed sequentially through the virtual reality headset. 

After the images are displayed, the subject will select the image they believe to contain the lighter sphere. 

Subjects will be given as much time as they desire to make a selection. 

To make selections, 'Left Alt' corresponds to the first displayed image and 'Space' corresponds to the second displayed image. 

After making a selection, the next set of images will be displayed.  

At one third and two thirds complete, a forced break will occur. 

To continue after the break, press either 'Left Alt' or 'Space' once the red dot has turned green.
