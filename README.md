# MHEdit

Generic Monster Hunter Equipment Modding Tool using .NET Core 6.0

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

# Supported Games - Roadmap

| Game | Code | Blademaster Weapons | Gunner Weapons | Armors |
| --- | --- | --- | --- | --- |
| P2G/FU | P2G, NAFU, EUFU | Yes | Yes | Yes |
| MH1 | 1J, 1U | Yes | Yes | Yes |
| MHG | MHGJ, MHGK, GWII | TBD | TBD | TBD |
| P1/F1 | P1, NAF1, EUF1 | TBD | TBD | TBD |
| P2/F2 | P2, NAF2, EUF2 | TBD | TBD | TBD |
| MH2 | DOS | TBD | TBD | TBD |
| MH3 | NATRI, EUTRI, JPTRI | TBD | TBD | TBD |

## Notes
Support for the European version of MH1 is not currently planned as the game keeps copies of all the necessary data on a per-language basis.

Support for the Wii version of G may not be implemented until Tri support, as the games require handling of Big Endian data.

# Future Support

| Feature | Likelyhood |
| --- | --- |
| Weapon Tree Editing | Will |
| Adding New Data | Wont |
| String Editing | Wont |
| Carve Editing | Mid |
| Gather Editing | Mid |

# FAQ

## Which file do I have to use?
* PSP games: EBOOT.BIN (Decrypted).
* MH1 (Japanese): SLPM_654.95.

Not yet supported:

* MH1 (USA): sub_main.bin (Decrypted).
* MH1 (EUR): [language].bin (Decrypted).
* MHG (PS2): sub_main.bin (Decrypted).
* MHG (Wii): main.dol (Decrypted).

## I got an error, what do?
Make sure you're using a decrypted eboot (PSP games), you can dump decrypted eboots with PPSSPP.

## Can I edit the names of weapons or armor pieces with THIS tool?
No.

## Can I add new weapon or equipment pieces?
No.
