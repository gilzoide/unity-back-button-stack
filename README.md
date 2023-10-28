# Back Button Stack
Easily manage a stack of objects that respond to the ESC button / Android Back button in Unity, so that only the top object handles the event.

Check out the [Popup Stack](Samples~/PopupStack) sample scene for some usage example.


## Features
- Only the last object in the stack will be called when the ESC/Back button is pressed.
- Inherit [ABackButtonHandler](Runtime/ABackButtonHandler.cs) to have scripts that handle the ESC/Back button be inserted/removed from the singleton stack automatically in their `OnEnable` / `OnDisable` methods.
- Supports pure C# classes as well, just implement the [IBackButtonHandler](Runtime/IBackButtonHandler.cs) interface and call `AddToBackButtonStack` and `RemoveFromBackButtonStack` to add / remove it from the singleton stack.
- Custom inspector for debugging which objects are currently in the stack, just select the `BackButtonStack` object in the `DontDestroyOnLoad` scene while in Play Mode.


## How to install
Either:
- Install using the [Unity Package Manager](https://docs.unity3d.com/Manual/upm-ui-giturl.html) with the following URL:
  ```
  https://github.com/gilzoide/unity-back-button-stack.git#1.0.0-preview1
  ```
- Clone this repository or download a snapshot of it directly inside your project's `Assets` or `Packages` folder.
