# Moofetch

Moofetch is a small CLI tool written in C#.
It's purpose is to get a limited amount of information about your system and hardware in one place.

## Installation

TBA

## Usage

```
moofetch <optional flags>
```

![](/readme_img/cow_say.png)

To turn off the `Cow says:` dialog run ``moofetch --nocowsay``

![](/readme_img/cow.png)

And to turn it back on: ``moofetch --yescowsay``

![](/readme_img/cow_say.png)

To display the cow in a box: ``moofetch --box``

![](/readme_img/cow_box.png)

## Building

```sh
git clone https://github.com/Cuber01/Moofetch # clone the repo
cd Moofetch # go into repo folder
nuget restore # restore packages
msbuild . # build
```

### Building a self-contained executable

```sh
dotnet tool install -g dotnet-warp
dotnet-warp
```

## Contributing, Goals and Future

If you'd like to contribute, feel free to hit me up with an Issue or a Pull Request.

The goal of this app is to make a nice tool that can grant you only the most important information in once place.
I'd like to add the ability to gather more info about (mostly) hardware through optional flags like moofetch --cpu.

This app isn't supposed to be fast, but rather expandable and maintainable. The current main printing code is a good example of how *not* to make expandable and maintainable code.

##
