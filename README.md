# Moofetch

Moofetch is a small CLI tool written in C#.
It's purpose is to get a limited amount of information about your system and hardware in one place.

## Installation

Go to https://github.com/Cuber01/Moofetch/releases/tag/major-release and get the newest release.

Executable version is recommended, flatpak is pretty much just for flatpak fans. Both of them don't require any outside dependencies to run. They do require, however, few basic commands installed on every Unix-like system. See dependencies and support for details.

Extract the zip file.

Run the installation script (make sure you're in the same folder as the script):
```
./install.sh
```

Restart your terminal session and you should be able to run moofetch now:
```
moofetch
```

And you're done!

If you get a permission denied error before running the script, do:
```
chmod+x install.sh
```

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

## Dependencies and support

### Support

This 'script' is intended to run on Linux platforms, however there's theoretically nothing stopping it from running on both MacOS, BSD or other Unix-like systems.

Linux is the only platform I can support, as I have access and use only a Linux machine. I also don't plan to build official builds to other platforms unless someone wills to do this as a maintainer (it's not like I'll get more than 1 original visitor on this page though, so don't get your, err... mine hopes up). 

### Build Dependencies

MSBuild, Dotnet Core, Mono

### Run dependencies

Only standard packages need to be installed, so unless you have some little monster Linux distro you should be fine:

- uname
- echo
- whoami
- uptime
- lspci
- grep
- bash (if you run install scripts with other bash-like shell/install it manually you're fine, so it's not a hard dependency)
- any CLI shell

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
