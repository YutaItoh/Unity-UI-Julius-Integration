# Unity-UI-Julius-Integration
This is a small Unity 3D package which adds a voice-control functionarity.

Its stand-alone unity package is available from: https://github.com/YutaItoh/Unity-UI-Julius-Integration/releases/tag/v1.0

A UI button that can be "pressed" by speaking out a predefined command:<br>
![home_screen](https://cloud.githubusercontent.com/assets/7195124/11270962/4c5cecb8-8ec3-11e5-9a3e-4b110f2e6d67.png)<br>
One can tune the command on Inspector:<br>
![component-view](https://cloud.githubusercontent.com/assets/7195124/11271032/b6da0c88-8ec3-11e5-95e9-be7fcdc07d3a.png)


This package is modified from another project which supports Japanese speach:
"Julius Client for Unity" 
https://github.com/SavantCat/Julius-Client-for-Unity
Based on that project, we replaced language model by using 
- An open-source English voice corpus from VoxForge, http://www.voxforge.org/
and added a 
- A UI buttun prefab which has a pressing-by-speach function

## Requirements:
- Windows due to our Julius server. However, other OSs should be able to use our package if ones install Julius client for each OS and modify our script little bit (remove hard-coded ".exe").
- Unity 4 or higher for using Unity UI buttons

## How to use it:
See Assets/scene/juliusx for a minimal exapmle of how to use the buttun asset with the Julius engine.
Currently, the Julius server accepts mainly those commands used in the buttuns in the example scene.
To add a new 

<b>IMPORTANT</b>:
Whenever you put the buttun gameobject prefab, DO SET its Tag to "Button" at the Inspector pannel to use our voice control function.

The basic structure of the implementation and dataflow are as follows:
![asset-structure-and-dataflow](https://cloud.githubusercontent.com/assets/7195124/11271977/d82ece72-8ec9-11e5-8a44-9e975b7490ae.png)

## Adding a new grammar rule to the julius system
In Assets\julius\core\grammar, you can find
- sample.voca
- sample.grammar
They determine what sentences our Julius server accepts, i.e., only sentences matches to a pattern defined the files can be set to the Unity buttun prefab.
See a VoxForge tutorial to lean how to edit the files:
http://www.voxforge.org/home/dev/acousticmodels/linux/create/htkjulius/how-to/data-prep/step-1

After editted the two files, one needs to update the database by running a perl script in the folder:
```linux
>> perl  mkdfa.pl sample
```

