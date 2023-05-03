# Data

## Input

Subject selection is collected using two inputs: FirstImageSelectionButton and SecondImageSelectionButton. 
The inputs can be changed within the main.cs file. The defaults for these inputs are the space-bar and enter respectively. 

## Data Collection

Data will be saved in an XML file. In an XML file, data is organized into a structured format of elements. Each element has a name and can contain attributes and or child elements. Elements can also have values, which are the actual data being stored.

The first time a session for a particular subject is ran, an XML file for said subject will be created. When the file is created, the StandardOrder, ComparisonOrder, and ComparisonImageChosen child nodes will be created. The StandardOrder and ComparisonOrder will be filled with a random order of conditions and random order of images displayed. ComparisonOrder will be populated as ‘lightness|image|lightness|image|…’, where lightness is one of the 11 values of the comparison image target object and image is the number of the image from the library generated. StandardOrder will be populated as ‘image|image|image|…’ as each standard image uses the same lightness values of 0.40 and doesn’t need to record which lightness values each time. The ComparisonImageChosen will be filled as sessions are completed with either ‘YES’ or ‘NO’ depending on whether or not the comparison image was chosen. The date and time a session was completed will be added on to the ComparisonImageChosen after the data.

![alt text](https://github.com/DevinReynolds/ColorConstancyVR/blob/main/Documentation/SampleXML.png?raw=true)
*Sample XML file for a subject that has completed all sessions of a pilot experiment*


