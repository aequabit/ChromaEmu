# ChromaEmu - ChromaCheats Server Emulator (unreleased, 4th crack)

## Demonstration

[![Demonstration](https://i.imgur.com/DJ6Kxol.png)](https://youtu.be/BpIEBuHRgmU)

## Development
This emulator was developed by me and @imi-tat0r in mid-2017 after having already released three analyses and emulators.

High-Minded Threads (German, Google Translate is accurate):
- First analysis + emulator research: https://hm.cx/threads/57508
- Second analysis + emulator: https://hm.cx/threads/57553
- Third analysis + emulator: https://hm.cx/threads/57961

## Release (or not)
The emulator was never released due to a bug in the Windows 10 API at the time that resulted in not being able to set the DNS servers. It was working fine on Windows 7, but most had already switched to Windows 10 by then, so it would have been a release to laugh at.

## Information
The included binaries might shut down your computer or force a bluescreen if a debugger is attached to the loader process or one of these processes is running: [process_blacklist.txt](https://github.com/aequabit/ChromaEmu/blob/master/process_blacklist.txt)

The encryption keys used by the binaries included in this repository are:
- Key: `BlcZ496fTZFH42KefU1GsoDOFipI1dQz`
- IV: `GnzlGN3UlwtjEc19vdrNgd42PGLkxytx`

32 random alphanumeric characters.

The exchange keys are:
- Key: `H8vixq8IKlKdem39KWY9+Uu92/PeI8nbpwtwd95iOzI=`
- IV: `To1w3uRk0heLJFsCGSnNSgJneVIGR5+CIiUM7PhzFsI=`

32 random bytes, Base 64 encoded. Only used for the initial exchange (not sure)

## What is this for?
Nothing.

Maybe learn from it, there already aren't many resources on Cheat Loader development, nontheless on how to crack them. So see this as at least an example on how to do it (under the right circumstances).

## Code quality

No.

## Credits
- [@aequabit](https://github.com/aequabit) for most of the work
- [@imi-tat0r](https://github.com/imi-tat0r) for looking over my shoulder the entire night and some help with research
- [@sapphyrus](https://github.com/sapphyrus) for suggesting using a DNS server to intercept requests (legendary to this day)
