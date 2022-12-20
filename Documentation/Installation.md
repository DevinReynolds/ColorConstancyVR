# Installation 

1. Install Unity (https://unity.com)
2. See Project Set-Up
3. See Scene Set-Up

### Project Set-Up

1. Clone repo
2. Disable Texture Compression on Import
	* Under Preferences / Asset Pipeline
3. In the Assets folder:
	* Create folders if not already there: "Editor", "Resources", and "Materials"
	* Add files to Assests folder: "Correct.wav", "Incorrect.wav", "Main.cs", and "Manage.cs"
4. Add "runAquisitionBySubjectName.cs" to the Editor folder
5. Add "Black.png", "Green.png" and "Red.png" to the Resources folder
5. In the Resources folder:
	* Add "Black.png", "Green.png" and "Red.png"
	* Create folder called conditions
		* Add folders for each condition
			* Add images to these folders
6. Create three materials in the Materials folder named: "leftMat", "rightMat", and "dotMat"
	* For each: change shader to Unlit>Texture
	* For leftMat and rightMat: select texture as "Black.png" from the Assets>Resources folder
	* For dotMat: select texture as "green.png" from the Assets>Resources folder
  
### Scene Set-Up

1. Install Oculus Integration Package
2. Delete Camera and Directional Light
3. Add OVRCameraRig from Assets>Oculus>VR>Prefabs to the scene
4. Go to Layers, Edit Layers
	* Under Tags
		* Add tag "LeftEyeImage"
		* Add tag "RightEyeImage"
		* Add tag "Scripts"
		* Add tag "CorrectSound"
		* Add tag "IncorrectSound"
		* Add tag "Dot"
	* Under Layers:
		* Name User Layer 6 to "Left"
		* Name User Layer 7 to "Right"
		* Name User Layer 7 to "Both"
5. On the LeftEyeAnchor, deselect everything from the culling mask and select Left and Both.
	* On the RightEyeAnchor, deselect everything from the culling mask and select Right and Both.
6. Create a plane and attach it to LeftEyeAnchor. Rename the plane to "LeftEye". Change Layer from Default to Left. Select tag LeftEyeImage.
 	* Create a plane and attach it to RightEyeAnchor. Rename the plane to "RightEye". Change Layer from Default to Right. Select tag RightEyeImage.
7. For both LeftEye and RightEye planes:
	* Adjust position to 0, 0, 0.7
	* Adjust rotation to 90, 180, 0
	* Adjust scale to 0.1, 0.1, 0.1
	* Apply leftMat and rightMat respectively
8. For the LeftEye plane: Adjust x position to -0.0315
	* For the RightEye plane: Adjust x position to 0.0315
9. Create a cylinder and attach it to the CenterEyeAnchor
	* Adjust position to 0, 0, 0.698
	* Adjust rotation to 90, 0, 0
	* Adjust scale to 0.1, 0.001, 0.1
	* Change tag to Dot
	* Apply dotMat
10. Create 3 empty objects and name them: "ScriptObject", "CorrectSound", and "IncorrectSound"
	* Add main and manage to ScriptObject and change tag to Scripts
	* Add Unity Component Audio Source to CorrectSound, attach Correct.wav, and change tag to CorrectSound
	* Add Unity Component Audio Source to IncorrectSound, attach Incorrect.wav, and change tag to IncorrectSound
