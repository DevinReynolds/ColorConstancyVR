# Abstract
The human visual system provides a relatively constant representation of the color of an object despite changes in properties that are irrelevant to the object. Understanding and quantifying the visual system’s ability to retain this constancy despite variation in object irrelevant properties is a goal of vision science. In previous works, color constancy experimentation involved presenting visual stimuli on a monitor. This method of presenting visual stimuli is not representative of natural viewing conditions. In natural vision, humans use two frontal eyes to obtain two different images of the same scene from slightly different angles. The natural disparity between these two images allows animals to accurately judge the distance of objects. When displaying on a monitor, the same visual stimuli is presented as a single 2D image to both eyes. These 2D image lack the perception of the third dimension. To simulate natural vision, sets of two images, stereoscopic pairs, are rendered of the same scene from two slightly different positions. The disparity of these two images is representative of the natural disparity between the two eyes in vision. The stereoscopic pairs can then be displayed to their corresponding eyes to give an accurate perception of distance within the rendered image. Virtual Reality (VR) can be used control what is displayed to each eye. Game engines like Unity are a popular choice when working with VR. Unity provides a framework that can develop psychophysical experiments and display stereoscopic pairs. Unity provides a 3D scene where rendered objects can be displayed. The stereoscopic pairs can be placed inside the Unity scene as 2D planes alongside two cameras corresponding to the left and right eyes of the VR headset. The rendering of the cameras must then be limited to only their corresponding image. Viewing the scene through a VR headset should now provide accurate information of the third dimension in the images. 

## About
[Introduction](/Documentation/Introduction.md)

[Image Rendering](/Documentation/Image%20Rendering.md)

[Virtual Reality](/Documentation/Virtual%20Reality.md)

[Unity](/Documentation/Unity.md)

[Lightness Discrimination Task](Documentation/Lightness%20Discrimination%20Task.md)

## Acknowledgments
Chibuike Okekeogbu, Joel Oluyole, and Jonathan Rinaldi helped in the beginning in designing the VR set-up.

## Further Readings
Singh, V., Cottaris, N. P., Heasly, B. S., Brainard, D. H., & Burge, J. (2018). Computational luminance constancy from naturalistic images. Journal of Vision

Singh, V., Burge, J., & Brainard, D. H. (2022). Equivalent noise characterization of human lightness constancy. Journal of Vision, 22(5). https://doi.org/10.1167/jov.22.5.2 

## References
Brainard D. H. (2009). Color constancy. In Goldstein B. (Ed.), The Sage encyclopedia of perception (pp. 253–257). Los Angeles: SAGE Publications.

Cassin, B. & Solomon, S. (1990). Dictionary of Eye Terminology. Gainesville, Florida: Triad Publishing Company.

McCoun, J., & Reeves, L. (Eds.). (2010). Binocular vision : Development, depth perception and disorders : development, depth perception and disorders. Nova Science Publishers, Incorporated.
