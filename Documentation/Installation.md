# Installation 

1. Install Unity (https://unity.com)
3. See Project Set-Up
4. See Scene Set-Up

### Project Set-Up

1. Create new project 
 	* select 3D as template
2. Disable Texture Compression on Import
	* Under Preferences / Asset Pipeline
3. Clone repo
4. Move assets folder repo to project directory
5. Import custom package: UnityColorConstancyVR.unitypackage
6. Install Oculus Integration Package
	* Download from asset store (https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022)
8. Install XR Pulg-in Management in project settings
	* Enable Oculus
  
### Scene Set-Up

1. Delete Camera and Directional Light
2. Add OVRCameraRig from Assets>Oculus>VR>Prefabs to the scene
	* Attach LeftEye, from Assets>Prefabs, to LeftEyeAnchor
	* Attach RightEye, from Assets>Prefabs, to RightEyeAnchor
3. Add Empty from Assets>Prefabs
 	* Unpack prefab completely
4. Go to Layers, Edit Layers
	* Under Tags
		* Add tag "LeftEyeImage", apply to LeftEye
		* Add tag "RightEyeImage", apply to RightEye
		* Add tag "Scripts", Apply to Scripts
		* Add tag "CorrectSound", Apply to Correct Sound Source
		* Add tag "IncorrectSound", Apply to Inorrect Sound Source
	* Under Layers:
		* Name User Layer 6 to "Left", apply to LeftEye
		* Name User Layer 7 to "Right", apply to RightEye
7. On the LeftEyeAnchor, deselect everything from the culling mask and select Left
	* On the RightEyeAnchor, deselect everything from the culling mask and select Right
