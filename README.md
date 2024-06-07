TestOne Binary Reader is a Windows Forms application that reads binary values from predefined device's logs file.

### Objective

The main aim is to design approach that can be changed easily and reconfigured without massive code modification through using a set of custom APIs and Types which facilitate the repeated operations of reading and manipulating byte values

Main Components

**IAllocation** : an allocation represent a predefined area of bytes in a file or a device, an allocation uses a strategy to resolve its value depending on each allocation implementation

**IStrategy** : a strategy defines what options are defined for each type of allocation to have interchangeable behaviors when reading different allocations

**Section** : a section hold a set of allocations to define a stage of reading, with a set of allocation methods to help build a map with more scalability, flexibility, and maintainability

**Map** : a map describes how the bytes in the files are located, determining how sections, allocations, and strategies interact to read values.

### Installation

To install and run the application, you can download the Installation.rar from the repo, decompress it and run **TestOne.BinaryReader.exe**

or you can run the code directly in VisualStudio

![image](https://github.com/Ziad17/testone-binary-reader/assets/36865821/02092323-569c-4a62-a4d8-19c69d170e31)

