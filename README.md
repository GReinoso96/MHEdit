# MHEdit

Generic Monster Hunter Equipment Modding Tool using .NET Core 5.0

# Usage
MHEdit is a command line tool, it exports editable JSON files that can then be reinserted into the game.

```
MHEdit.exe [Code] [Function] [In] [Out]
```

## Dump
```
MHEdit.exe [Code] -d eboot.bin [Out Folder]
```

```
MHEdit.exe P2G -d EBOOT.BIN p2
```

## Insert
```
MHEdit.exe [Code] -i [Out Folder] eboot.bin
```
```
MHEdit.exe P2G -i p2 EBOOT.BIN
```

# Supported Games

| Game | Code | Blademaster Weapons | Gunner Weapons | Armors |
| --- | --- | --- | --- | --- |
| P2G | P2G | Yes | Yes | Yes |
| FU | NAFU, EUFU | TBD | TBD | TBD |
| P2/F2 | P2, NAF2, EUF2 | TBD | TBD | TBD |
| P1/F1 | P1, NAF1, EUF1 | TBD | TBD | TBD |
| MHG | PS2G, WIIG | TBD | TBD | TBD |
| MH1 | NA1, EU1, JP1 | TBD | TBD | TBD |
| MH2 | DOS | TBD | TBD | TBD |
| MH3 | NATRI, EUTRI, JPTRI | TBD | TBD | TBD |

# Future Support

| Feature | Likelyhood |
| --- | --- |
| Weapon Tree Editing | Will |
| Adding New Data | Wont |
| String Editing | Wont |
| Carve Editing | Mid |
| Gather Editing | Mid |

# FAQ

## I got an error, what do?
Make sure you're using a decrypted eboot (PSP games), you can dump decrypted eboots with PPSSPP.

## Can I edit the names of weapons or armor pieces with THIS tool?
No.

## Can I add new weapon or equipment pieces?
No.
