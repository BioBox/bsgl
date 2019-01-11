# Baileysoft Game Loader

The Baileysoft game loader is a program that keeps track of your play time for any game, but will also work with any executable file.

## Requirements

Since this is written in **C#**, it is required that you have the .NET framework on your system,
but this program will also work on Mac, Linux, and pretty much anything with a working
[Mono](https://www.mono-project.com/) implementation.

## Compiling

For Windows:
```
msbuild /p:DefineConstants=WIN_32
```

For MacOS:
```
msbuild /p:DefineConstants=MAC_OS
```

For Linux (or anything that uses
[.desktop files](https://www.freedesktop.org/wiki/Specifications/desktop-entry-spec/)):
```
msbuild /p:DefineConstants=LINUX
```

## Basic Usage

Checkout the [quick-start guide](QuickStart.pdf).

There's also a [youtube video](https://youtu.be/WRSY0bcxuX0) that shows you how to use it.

## TODO

* Enable support for desktop shortcuts on Mac
* Allow launching games from the configuration menu on Linux

## Special Thanks

Special thanks goes to Neal Bailey for providing me with his excellent code.
