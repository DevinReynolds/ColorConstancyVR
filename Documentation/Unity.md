# Unity
Unity is a software that is used to make interactive experiences, of which, the most common are video games. Using unity, virtual worlds can be created that can then 
be displayed to a VR headset. Unity provides a framework that can develop psychophysical experiments and display stereoscopic pairs for VR.

To use Unity with VR, two cameras corresponding to the left and right displays of the headset are needed. The method of creating the cameras for the headsets are 
different depending on which VR headset is used. For the Meta Quest 2, the 
[Oculus Integration package](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022) should be installed from the asset store. The Oculus 
Integration package contains tools and assets, including a VR camera object, specifically designed for use with Meta’s VR devices. The camera, called 
OVRCameraRig, can be placed within a 3D scene along side two 2D planes for the 2D stereoscopic images that were rendered. These planes are blank square 
objects that can be used to display images to the camera. The planes that are placed inside of the scene need to be the only thing that is rendered by the camera. 
This can be done using some built-in Unity tools. 

The Layers tool assigns a layer, which is a label, to each object in the scene. It can then be chosen how these objects, in a specific layer, interact with objects in 
other layers. Another unity tool, the culling mask is used to control which objects in a scene are visible to a camera. The culling mask, used in tandem with the layers 
tool, can render selective parts the scene by layers. These tools can be used to display the images in a stereoscopic pair to their corresponding cameras, i.e., the 
left image is displayed only to the left camera and the right camera is only displayed to the right camera. 

Images must first be imported to unity before use, however, by default imported images are compressed. Compressing the images changes how the images appear, i.e. makes 
them blurry, which is detrimental to a color based experiment. The import compression can be disabled in Unity’s settings. Afterwards, the images can be moved directly 
into the Unity project directory and the PNG images will be automatically imported. 

The 2D planes placed in the scene are still blank objects. Before the images can be placed in the scene, a material needs to be created for the images. A material is a 
file that contains the information about how an object is rendered. Materials determine the object's appearance by specifying its color, texture, transparency, and 
other visual properties. Two materials need to be created, one for the left eye image and one for the right eye image. These materials can then be applied to the 
two planes, which changes the appearance of the planes to the rendered images. Now that a method for displaying stereoscopic images has been created, the task 
can be defined. 
