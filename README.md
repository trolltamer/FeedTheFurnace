# FeedTheFurnace
A game for mobile and desktop developed in Unity using C#


C# files can be found in Assets->Scripts

The game is built in the Unity engine, all classes not derived directly from Object are derived from either MonoBehavior,
the engine's physics/in-game base class which gives call backs to the Update() method that is called every frame along with other in-engine
methods, or ScriptableObject, which are essentially basic Objects which can be instantiated and bound to asset files to contain data or 
functions that are contained outside of the physical mono-behaviour space. 

The game consists of objects spawning near the top of the screen which fall towards a furnace at the bottom of the screen. Spawned objects 
can be either stick or bomb, sticks gives points and increase combo when they enter the furnace, bombs cause a gameover if they enter the 
furnace. In addition there is a main menu, pause menu, ui for all game states, and other systems to extend functionality. 

The GameManager class is a static singleton which contains references to all of the games sub-managers as well as the GameData class 
that holds important data which should be centrally accessible such as the score, combo, and more.
