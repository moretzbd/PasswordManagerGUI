# PasswordManagerGUI

A simple local password manager I made for my personal use and decided to upload.

## Description

Encrypts login and password using AES and Argon2 key derivation. Each file is named in plaintext and the encrypted information is loaded upon clicking the file in a list generated from the filenames in the "Passwords" folder. Importing and exporting to CSV files is supported.

## Getting Started

### Dependencies

.NET Framework 4.8

### Building

Clone repo, restore Nuget packages, build release. 
Building debug first gave Fody error, but works after release build in Visual Studio 2017.

### Installing

Place into folder, run once to generate "Passwords" folder and salt file that will be used for that install.

## Requirements

8 threads, 2GB of ram for default build.

### Executing program

Launch, enter master password, manage password files.
Only "Login" and "Password" fields will be encrypted, "Name" will be the filename.
Passwords will not be able to be decrypted if the generated salt file is missing

## Help

[Generate]
* Generates random password of set length with characters: a-z A-Z 0-9 !@#$%^&*

[Copy Login/Password]
* Copies current login or password to the clipboard

[Clear]
* Clears name, login, and password fields

[Save]
* Encrypts and saves current login/password with name as the filename

[Delete]
* Deletes currently selected entry (and associated file)

[Import/Export]
* Imports/Exports a CSV file formatted as "Name,Login,Password"

## Authors

Benjamin Moretz  
[@moretzbd]

## Version History

* 1.0.0.4
    * Initial Release

## License

This project is licensed under the GNU GPL 3.0 License - see LICENSE for details

## Acknowledgments

* [.NET Core Crypto Extensions](https://github.com/kmaragon/Konscious.Security.Cryptography)
* [CSVHelper](https://joshclose.github.io/CsvHelper/)
* [Costura](https://github.com/Fody/Costura)
* [C# Exmaples Inputbox](https://www.csharp-examples.net/inputbox/)
