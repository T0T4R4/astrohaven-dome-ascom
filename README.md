# ASCOM Driver for AstroHaven clamshell domes

## Summary 

This is my implementation of an **[ASCOM](https://ascom-standards.org/) Driver** which can interact with the console of your **[AstroHaven dome](https://astrohaven.com/)** via its serial connection. The driver is built in C# using the open-source *ASCOM Driver Visual Studio template*  , provided by the *ASCOM Initiative*.

## Requirements

In order to **use** this driver you will need to install the [ASCOM Platform](https://github.com/ASCOMInitiative/ASCOMPlatform/releases) and the [.NET Framework 4](https://www.microsoft.com/en-au/download/details.aspx?id=17851) (which may already come with the ASCOM Installer).

If you want to **modify** this driver, you will  also need to install the *ASCOM Platform 64bit Developer package* available on the same release page (ASCOMPlatform64Developer.exe).

I aimed at building a generic driver, but if you notice some differences of behaviour with your particular version of the *AstroHaven* dome, please raise an issue or propose a code change via a pull-request.

## Compiling and building

Just a reminder that in order to successfully build the project, it is preferrable to run Visual Studio as an administrator.

In order to build the installer, you will need to install [**Inno Setup**](http://www.jrsoftware.org/isdl.php#stable), the free installer for Windows programs by *Jordan Russell* and *Martijn Laan*. Open the file `AstroHaven.Dome Setup.iss` with *Inno Setup* and press the *run* button to build and launch the installer.

For more information, please refer to the guidelines provided as part of the [ASCOM Driver development guide](https://ascom-standards.org/Developer/DriverImpl.htm).

## Installation

Pre-built binaries for windows can be downloaded from the [releases]() page.

As for all third-party drivers, it will be installed under the following directory :

`C:\Program Files (x86)\Common Files\ASCOM\Dome`

The installer will create the following elements :

- ASCOM.AstroHaven.Dome.dll, the main driver library, which is automatically registered in the ASCOM registry upon installation,

- ASCOM.AstroHaven.DomeController folder, which contains the Test app (ASCOM.AstroHaven.Test.exe). I strongly recommend this app to control your dome. Create a shortcut of it on your desktop for quicker access.

## How does it works ?

As you might know, *AstroHaven* clamshell domes are non-moving domes which have four shutters running in pairs (considered as two shutters by the driver). Thus the only functionality provided by the dome driver are open shutter and close shutter. 

However you will notice that we have added some interesting features like partial, synchronised or independant shutter control. 

We recommend to use test application provided with the dome driver if you require a nice user interface. It is available at the following location :

`C:\Program Files (x86)\Common Files\ASCOM\Dome\ASCOM.AstroHaven.DomeController\ASCOM.AstroHaven.Test.exe`

## Driver setup

As for every ASCOM Driver, this driver has a few parameters that must be setup the first time you use it either programmatically or via the Test application.

- Com port and speed : these should correspond to the serial port on the computer which is bound to the dome console
- Anti-loose belt protection : this is for domes suffering of the said issue where belts  can be loose when the motor is unwinding due to top panels rubbing too hard on bottom panels. The AstroHaven manual contains some recommendations for this issue but we also found that pausing shortly upon opening shutters sometimes re-tighten the belt.
- Minimum delay between commands, which is to regulate the flow of commands sent by the driver to the dome serial interface. Beware to not drop the value too low as you might end up flooding the dome console.

## Feedback

Please give me your feedback, positive or negative, raise any issue that occurs with your dome when controlling it via this driver, so we can together enhance this program as a community.



