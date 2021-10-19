![cover_logo](https://github.com/haseeb-heaven/IGI-Injector/blob/master/IGI-Injector/resources/injector_main.png?raw=true "")

_IGI-**Injector**_ is [DLL Injector](https://en.wikipedia.org/wiki/DLL_injection) to inject **DLL** into game process, It supports both _IGI 1_ and _IGI 2_ game and is built for **x86(32bit)** process because of game compatibility.

**NOTE** : This is not general injector it only works for _IGI_ games.
 
## Features: <br/>
**[+]** Support for both **IGI 1 & IGI 2** games.<br/>
**[+]** Injector with _.INI_ configuration to easily edit configs.<br/>
**[+]** Injector with **Automatic injection** and supports mutiple **DLL** files.<br/>
**[+]** Injector with custom delay between injection.<br/>
**[+]** Injector with Inject/Eject options [Thread Safe].<br/>
**[+]** Support Game level start for both games in _window_ or _full-screen_ modes .<br/>

# Main Components :

## Setting Game Path: 

Use  **Set Game Path** to set your path for game.

![game_path](https://github.com/haseeb-heaven/IGI-Injector/blob/master/IGI-Injector/resources/setting_game_path.png?raw=true "")

Or make changes in config file.</br>
_**[PATH]**_</br>
`game_path='your game path' `

## Selecting DLL file: 

Use  **Browse file** to select Single/Multiple DLL's to inject.

![selecting_dll](https://github.com/haseeb-heaven/IGI-Injector/blob/master/IGI-Injector/resources/selecting_dll.png?raw=true "")

Or make changes in config file.</br>
_**[PATH]**_</br>
`dll_path='your dll path' `

## Injecting DLL with Options: 

Use  **Inject DLL** to inject DLL's into game.<br/>
You can select **Auto-Inject** to automatically inject Dll into game after delay.<br/>
And you can select **Multi-DLL** to select multiple _DLL_ into the game process.<br/>

![dll_options](https://github.com/haseeb-heaven/IGI-Injector/blob/master/IGI-Injector/resources/dll_options.png?raw=true "")

Or make changes in config file.</br>
_**[DLL]**_</br>
`auto_inject=True`<br/>
`multi_dll=True`


## Setting Delay for DLL: 

Use  **Delay** to set delay for your DLL - **Delay in seconds - MAX 100s**.

![delay_dll](https://github.com/haseeb-heaven/IGI-Injector/blob/master/IGI-Injector/resources/delay_dll.png?raw=true "")

Or make changes in config file.</br>
_**[DLL]**_</br>
`delay=10` **Delay of 10 seconds**


## Selecting Game: 

Use  **Game Select Dropdown** select your IGI game.

![game_selection](https://github.com/haseeb-heaven/IGI-Injector/blob/master/IGI-Injector/resources/game_selection.png?raw=true "")

Or make changes in config file.</br>
_**[GAME]**_</br>
`game=igi` _Project IGI 1 selected_</br>
`game=igi2` _Project IGI 2 selected_</br>

## Starting Game Level: 

Use  **Start level** to select your IGI game level to run in _window_ or _full-screen_ modes.

![game_modes](https://github.com/haseeb-heaven/IGI-Injector/blob/master/IGI-Injector/resources/game_modes.png?raw=true "")

Or make changes in config file.</br>
_**[GAME]**_</br>
`level=5`_Level 5 selected_</br>
`mode=windowed` _window mode selected_</br>
`mode=full` _full-screen mode selected_</br>

## Injector configuration: 
Injector uses _INI_ configuration as **_IGI-Injector.ini_** to save data of application, you can use them to edit preferences as per your needs.

![game_config](https://github.com/haseeb-heaven/IGI-Injector/blob/master/IGI-Injector/resources/game_config.png?raw=true "")

# IGI-Injector Tutorial on YouTube :
[![GTLibPy Demo](https://img.youtube.com/vi/JWqiNjbk7D4/0.jpg)](https://www.youtube.com/watch?v=JWqiNjbk7D4)

written and maintained by _Haseeb_ _Mir_ (haseebmir.hm@gmail.com)</br>
