# OatsUtil

OatsUtil is a Unity package with a collection of different utilities for Unity scripting. It mostly consists of things I've rewritten multiple times in different projects so I'm putting it all in one package that can be imported into future projects.

Contains:
* <b>ComponentExtensions</b> class which gives Unity components methods for getting references to components and GameObjects with null checks and exception logging.
* <b>InBetweening</b> classes to easily make tweening coroutines
* <b>CollectionExtensions</b> class which gives Arrays and Lists methods for getting random elements and shuffling their elements.
* <b>StringExtensions</b> class which gives strings methods for formatting, including pluralizing, adding quotes and adding formatting tags.
* <b>IEnumeratorExtensions</b> class which gives IEnumerators the .Then() method, allowing Enumerators to be strung together in a sequence.
* <b>NumberUtils</b> class with methods for various numerical operations like mapping a value from one range to another, wrapping a value in a range, and checking if a value is within a range.
* <b>SceneUtils</b> class with methods for accessing GameObjects in the current scene.
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
Use both RequireChildGameObject and RequireComponent:
```C#
this.RequireChildGameObject("Door").RequireComponent<HingeJoint>();
```

### Getting references to a GameObjects in the scene
```C#
player1 = SceneUtils.FindComponentInScene<PlayerController>("Player1");
player2 = SceneUtils.FindComponentInScene<PlayerController>("Player2");
```

### Using InBetweening to tween values over time
```C#
var MovementTween = new InBetween<Vector3>()
    .LerpWith(Vector3.Lerp)                             // lerp function for the type of value being tweened 
    .From(transform.position)                           // starting value of tween
    .To(transform.position + Vector3.right)             // ending value of tween
    .For(2f)                                            // how long in seconds the tween is
    .Curve(InBetweenCurves.EaseInAndOut)                // specify an easing funcion. Either a float => float function or AnimationCurve
    .OnFrame(vector => transform.position = vector);    // function that runs on each frame of the tween

StartCoroutine(MovementTween.ToEnumerator());
```
Above code moves the object one unit to the right over 2 seconds with an ease-in-and-out easing function.

You can also make some of the variables editable in the inspector by using a InBetweenConfig object:
```C#
[SerializeField] private InBetweenConfig MovementTweenConfig;

public void Move()
{
    var MovementTween = new InBetween<Vector3>()
        .LerpWith(Vector3.Lerp)
        .From(transform.position)
        .To(transform.position + Vector3.right)
        .OnFrame(vector => transform.position = vector)
        .WithConfig(MovementTweenConfig);               // pass config object to specify time, curve and steps

    StartCoroutine(MovementTween.ToEnumerator());
}
```
### Making a sequence of IEnumerators to run in a coroutine
This code connects four IEnumerators so that when they run in a coroutine they will run one after the other in sequence.
```C#
var AttackSequence = LookAtPlayer()
    .Then(Shoot())
    .Then(ResetPosition())
    .Then(Reload());

StartCoroutine(AttackSequence);
```

You can also pass in an Action to run after a coroutine completes
```C#
StartCoroutine(AttackSequence
    .Then(() => {
        Debug.Log("Done attack sequence");
    })
);
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
### Foramtting a string
```C#
"Hey!".Bold() + " She said " + "Go over there".Quote() + " to find the " + "stanted".Italic() + " sign."
```
When put into a rich text UI element, it will appear as: <b>Hey!</b> She said "Go over there" to find the <i>slanted</i> sign.

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
Download the latest release from the [Releases](https://github.com/thomasnakagawa/OatsUtil/releases) page. Import the package file into Unity. To use the utilities, only the OatsUtil folder is required, the Editor folder contains unit tests and is optional.

Add `using OatsUtil;` at the top of any of your scripts to use the methods and classes in this asset package.

### Running the unit tests
* Import the package and make sure to import all the folders including /Editor/UnitTests. 
* In Unity do Window -> General -> Test Runner
* In the Test Runner window, select the EditMode tab
* Click "Run"
