# Image Rendering

The images are generated using a software called Virtual World Color Constancy (VWCC) (https://github.com/BrainardLab/VirtualWorldColorConstancy). VWCC is written 
using Matlab and uses the Mitsuba renderer to render images. Before rendering the image, the scene must be created. The 3D geometry and light sources can be inserted 
in user specified locations using the software, Blender. As in previous works, the shape and position of the 3D geometry and light sources are fixed. 

The reflectance spectra of the objects are generated using random sampling from a statistical model of surface reflectances, derived from datasets of natural world 
objects, as described in Singh et. al. (2018). The natural datasets are approximated using principal component analysis (PCA). The dataset is then projected along the 
PCA directions with the largest 6 eigenvalues. The resulting distribution is then approximated as a multivariate normal distribution as described in 
Singh et. al. (2018). The reflectance spectra for the background objects are randomly sampled from this distribution.

For the spectra of the light source, CIE standard illuminant D65, which corresponds to the average midday light in western Europe, is used. Standard illuminant 
D65 is normalized by its mean to get the shape of the spectra. The normalized D65 spectra is used for the spectra of the light sources.

The object reflectance spectra and the light source illumination spectra, acquired from above, are applied to the objects and the light source in the scene. Then 
a stereoscopic pair of 2D multispectral images of the scene are rendered using the Mitsuba renderer at 31 wavelengths linearly spaced between 400 nm and 700 nm. 
These two images are rendered at two camera positions that are 63mm apart to represent the average interpupillary distance (Figure 1).

To present these multispectral stereoscopic images, they are first converted to PNG images. The PNG images can then be displayed using 
virtual reality. 
