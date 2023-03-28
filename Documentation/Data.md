![alt text]([http://url/to/img.png](https://github.com/DevinReynolds/ColorConstancyVR/blob/main/Documentation/SampleXML.png?raw=true)

Subject selection is collected using two inputs: FirstImageSelectionButton and SecondImageSelectionButton. 
The inputs can be changed within the main.cs file. The defaults for these inputs are the space-bar and enter respectively. 

Data will be saved in an XML file. The first time a session for a particular subject is ran, an XML file for said subject will be created. 
When the file is created, the StandardOrder, ComparisonOrder, and ComparisonImageChosen child nodes will be created. The StandardOrder and ComparisonOrder 
will be filled with a random order of conditions and random order of images displayed. 

The ComparisonImageChosen will be filled as sessions are completed with either ‘YES’ or ‘NO’ depending on whether or not the comparison image was chosen. 
The date and time a session was completed will be added on to the ComparisonImageChosen after the data. 
