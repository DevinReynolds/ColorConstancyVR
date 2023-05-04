# Introduction
The human visual system provides a relatively constant representation of the color of an object despite changes in properties that are irrelevant to the object 
(Brainard, 2009). However, this constancy is not always preserved (Brainard, 2009). Understanding and quantifying the visual system’s ability to retain this 
constancy despite variation in object irrelevant properties is a goal of vision science. In 
[previous works](https://github.com/BrainardLab/VirtualWorldPsychophysics), human observers viewed rendered images of a monochromatic 
sphere within a three-dimensional (3D) scene containing naturalistic background objects and reported the image that contained the lighter sphere. These images were 
displayed to observers as two-dimensional (2D) images on a color calibrated monitor. This, however, is not representative of natural human vision. In this work, virtual 
reality (VR) and Unity are used to view the rendered images under more naturalistic conditions. 

In natural vision, humans perceive the world in three dimensions, of which, distance from the observer is not present in the 2D images displayed on monitors. The 
images taken by human eyes remain 2D yet humans can still perceive the third dimension (McCoun and Reeves, 2010). This third dimension information is normally 
provided to humans from a combination of monocular (one eye) and binocular (two eye) depth cues. Here, two binocular cues will be exploited to provide distance 
information to rendered 2D images which are stereopsis and convergence. 

Humans use two frontal eyes to obtain two different images of the same scene from slightly different angles. In stereopsis, the natural disparity between 
these two images allows humans to accurately triangulate the distance of objects (McCoun and Reeves, 2010). This disparity is inversely dependent on the distance 
of an object from the observer (McCoun and Reeves, 2010). As an object is moved further away from an observer, the disparity decreases, and as an object is moved 
closer to an observer, the disparity increases. During stereopsis, the eyes focus on the same point, and in doing so, will stretch the extrinsic muscles of the human 
eye when viewing objects at close distances (<10m) (Cassin and Solomon, 1990). This is called convergence. The sensations of stretching the extrinsic muscles during 
convergence provide distance information. Stereopsis of far objects provides distance information of objects relative to one another and gives an illusion of distance. 
Convergence provides absolute distance information of an object from an observer.

When displaying images on a monitor, the same visual stimuli is presented as a single 2D image to both eyes. From the binocular cues, a second image is needed to 
provide distance information to an observer. To simulate natural vision, a second image, of the same scene, can be rendered at a slightly different 
position (63mm apart) to represent the distance between the two human eyes. The disparity of these two images is representative of the natural disparity between 
the two eyes in vision. These two 2D images form a pair called stereoscopic pairs. These pairs represent what the human eyes see. The stereoscopic pairs can be 
displayed to their corresponding eyes to give an accurate perception of distance within the rendered scene.

## References
Brainard D. H. (2009). Color constancy. In Goldstein B. (Ed.), The Sage encyclopedia of perception (pp. 253–257). Los Angeles: SAGE Publications.

Cassin, B. & Solomon, S. (1990). Dictionary of Eye Terminology. Gainesville, Florida: Triad Publishing Company.

McCoun, J., & Reeves, L. (Eds.). (2010). Binocular vision : Development, depth perception and disorders : development, depth perception and disorders. 
Nova Science Publishers, Incorporated.
