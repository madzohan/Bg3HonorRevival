# HonorRevival

This console application automatize changing of `profile 8.lsf` to make your failed `Honour Mode` campaign shine again!

## FAQ
Q: How it works in general?

A: It rewrites `%USERPROFILE%\AppData\Local\Larian Studios\Baldur's Gate 3\PlayerProfiles\Public\profile8.lsf` skiping `DisabledSingleSaveSessions` subnodes (thats where the game stores info about failed `Honour Mode` campaigns)

Q: So what I have to do when getting this screen?
![Honour Mode Game over screen](/HonorRevival/assets/game_over_popup.jpg)

A: First of all press `Alt+F4` or kill `bg3.exe` process ... i.e. close the game. Then [download the latest release && unpack && run `HonorRevival.exe`](https://github.com/madzohan/Bg3HonorRevival/releases/latest) . Thats it, launch the game, `Honour Mode` campaign will be available and you can load your previous (before game over) save state

### Read Next only if you want to build from sources by yourself:

#### Build Requirements

To build the tools you'll need to get the following dependencies:

 - Download GPLex 1.2.2 [from here](https://s3.eu-central-1.amazonaws.com/nb-stor/dos/ExportTool/gplex-distro-1_2_2.zip) and extract it to the `External\gplex\` directory
 - Download GPPG 1.5.2 [from here](https://s3.eu-central-1.amazonaws.com/nb-stor/dos/ExportTool/gppg-distro-1_5_2.zip) and extract it to the `External\gppg\` directory
 - Protocol Buffers 3.6.1 compiler [from here](https://github.com/protocolbuffers/protobuf/releases/download/v3.6.1/protoc-3.6.1-win32.zip) and extract it to the `External\protoc\` directory

#### How to build
1) build `LSLibNative`
2) build `LSLib`
3) build `HonorRevival`
