# OatsUtil

OatsUtil is a Unity package with a collection of different utilities for Unity scripting. It mostly consists of things I've rewritten multiple times in different projects so I'm putting it all in one package that can be imported into future projects.

Contains:
* <b>ComponentExtensions</b> class which gives Unity components methods for getting references to components and GameObjects with null checks and exception logging.
* <b>CollectionExtensions</b> class which gives Arrays and Lists methods for getting random elements and shuffling their elements.
* <b>NumberUtils</b> class with methods for various numerical operations like mapping a value from one range to another, wrapping a value in a range, and checking if a value is within a range.
* <b>MissingGameObjectException</b> an exception type for when a Unity GameObject is missing

## Examples
### Getting a reference to an attached component.
Before, using GetComponent:
```C#
LineRenderer lineRenderer = GetComponent<LineRenderer>();
if (lineRenderer == null)
{
    Debug.LogException(
      throw new MissingComponentException("A LineRenderer is needed"),
      this;
    );
}
```
After, using RequireComponent from OatsUtil:
```C#
LineRenderer lineRenderer = this.RequireComponent<LineRenderer>();
```
The RequireComponent<>() method will check for the component and log the exception if the component is missing.

### Getting a reference to a child GameObject by name
Before, using FindChild(name):
```C#
Transform pivotPoint = transform.FindChild("pivot");
if (pivotPoint == null)
{
    Debug.LogException(
      throw new System.InvalidOperationException("A child name \"pivot\" is needed"),
      this;
    ); 
}
```

After, using RequireChildGameObject from OatsUtil:
```C#
Transform pivotPoint = this.RequireChildGameObject("pivot");
```
The RequireChildGameObject() method will check for the child and log an exception if it doesn't exist.

### Getting a component in a child object
Just do:
```C#
this.RequireChildGameObject("Door").RequireComponent<HingeJoint>();
```

### Shuffling an array or list
```C#
myList.Shuffle();
```
You can also pass in a System.Random object to the shuffle method
```C#
System.Random myRandom = new System.Random(rngSeed);
myList.Shuffle(myRandom);
```

### Getting a random element from an array or list
```C#
int randomElement = myList.Random();
```

### Mapping a value from one numeric range to another
```C#
float throttleForce = NumberUtils.MapRange(
  minimumLeverRotation,
  minimumLeverRotation,
  minimumForce,
  maximumForce,
  currentLeverRotation
);
```

## Setup
Import the package file into Unity. To use the utilities, only the OatsUtil folder is required, the Editor folder contains unit tests and is optional.

Add `using OatsUtil;` at the top of any of your scripts to use the methods and classes in this asset package. The extensions will be compiled in automatically so if you don't want them you have to delete the extension files individually.

### Running the unit tests
* Import the package and make sure to import all the folders including /Editor/UnitTests. 
* In Unity do Window -> General -> Test Runner
* In the Test Runner window, select the EditMode tab
* Click "Run"
