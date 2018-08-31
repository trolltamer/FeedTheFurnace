# FeedTheFurnace
A game for mobile and desktop developed in Unity using C#


C# files can be found in Assets->Scripts

The game is built in the Unity engine, all classes contained in this project not derived directly from Object are derived from one of two Unity classes MonoBehavior, or ScriptableObject. Classes that inherit from MonoBehavior get call backs to several methods including the Update() method that is called every frame and can be attached as components to GameObjects that are instantiated in Scenes or stored in Prefabs. ScriptableObject derived classes can be instantiated through engine menus or scripts and are bound to asset files to contain data or functions, but cannot be placed in scenes. 

The core gameplay loop consists of objects spawning near the top of the screen which fall towards a furnace at the bottom of the screen. Spawned objects can be either stick or bomb, sticks gives points and increase combo when they enter the furnace, bombs cause a gameover if they enter the furnace. Player input is captured and interpretted in the PlayerManager class, which allows the user to drag and drop the spawned objects. In addition there is a main menu, pause menu, ui for all game states, and other systems to extend functionality. 

The GameManager class is a static singleton which contains references to all of the games sub-managers as well as the GameData class 
that holds important data which should be centrally accessible such as the score, combo, and more. The GameManager contains a few functions related to abstract game functions such as pausing and resetting the score values but is primarily used to inject references into dependent classes, particularly sub-managers.

Many variables and data are contained in scriptable object class instances, including the event/pub+sub system.
