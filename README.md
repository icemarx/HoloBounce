# HoloBounce
Project for learning how to work with Microsoft HoloLens, by making a simplistic MR videogame


## Link to Microsoft HoloLens device configurations and other setup:
https://docs.microsoft.com/en-us/hololens/hololens1-hardware

## Link to Microsoft HoloLens Origami tutorial:
https://docs.microsoft.com/en-us/windows/mixed-reality/develop/unity/tutorials/holograms-101e

## Testing the project:
How to test the project on the HoloLens through Unity editor:
  0. Make sure Holographic Remoting Player is installed on the HoloLens first.
  1. On your HoloLens, run the Holographic Remoting Player, available from the Windows Store. Launch the application on the device, and it will enter a waiting state and show the IP address of the device. Note down the IP.
  2. In Unity editor: Open Window > XR > Holographic Emulation.
  3. Change Emulation Mode from None to Remote to Device.
  4. In Remote Machine, enter the IP address of your HoloLens noted earlier.
  5. Click Connect.
  6. Ensure the Connection Status changes to green Connected.
  7. Now you can now click Play in the Unity editor.

## TODO: How to build the project and deploy it to device

## TODO: How to use the game on the device

## How to charge the device (based on our experience):
To charge:
  1. plug it into an outlet (micro usb)
  2. turn off the device
  3. check if the device is still turned off (after a minute or two)
  4. charge for about 10h

After charging:
  1. wait a minute
  2. Turn off the device

Notes: DO NOT have the device on while charging, as the battery depletes faster than it charges.

## How to stream the game (livestream):
To stream the game, have the HoloLens paired with the computer, and have the Microsoft HoloLens application installed (you can download it from Microsoft Store).
Connect to device by inputing it's IP into the Microsoft HoloLens application.
You can stream the live feed from there.
