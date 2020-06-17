# Installer Demo
A demonstration of how to create a simple but efficient C# application installer, with an example Unity program.

## How to use it for yourself
There are a few things you'll need to change before you can get started.

### 1) The package
Inside the repository, there's a file called `package.zip`, this is a zip folder containing the files that get generated when Unity build the project. If you're not using Unity, this is a zip folder with your program's files. You could, alternatively, make an archive called `static.zip`, which is another zipped folder containing all the stuff that doesn't change when you update the app. Which one you use is not important, but you can save a lot of update time by using the static archive. With the regular archive, when a new version is released the program will re-install. With the static archive, the program will leave the static files alone and only update the files stored in `dynamic.txt`.
 > **Note: If you're using Unity, the only dynamic file you'll need is the .exe file in the main directory, the other files don't need to be updated. You can speed the update process up a lot by telling it to only update the app itself and not the 106 other files that go with it. In order to use the static-dynamic method, you'll need to change the code so that it downloads the static files on install, and the dynamic ones on update.**
### 2) The installer
At the start of `installer.cs` there are two string fields, `username` and `repository`. These are here so that the installer can find the files for your app. It assumes a locaion of `https://github.com/{username}/{repository}/win.zip`. The installer puts the files for your app in `C:\Users\<current username>\AppData\Local\<github username>\<repo name>` on Windows, and `/Library/Application Support/<github username>/<repo name>` on Mac and Linux.
### 3) The launcher
This program will attempt to launch your program. This repository is all set up to run a Python program - This assumes your package contains a file called `main.py` and that the user has Python installed. There are 6 commented lines that point out where you'll need to change.
