# Installer Demo
A demonstration of how to create a simple but efficient C# application installer, with an example Unity program.

## How to use it for yourself
There are a few things you'll need to change before you can get started.

### 1) The package
Inside the repository, there's a file called `win.zip`, this is a zip folder containing the files that get generated when Unity build the project. If you're not using Unity, this is a zip folder with your program's files. There is also an archive called `static.zip`, which is another zipped folder containing all the stuff that doesn't change when you update the app. Which one you use is not important, but you can save a lot of update time by using the static archive. With the regular archive, when a new version is released the program will re-install. With the static archive, the program will leave the static files alone and only update the files stored in `dynamic.txt`.
 > **Note: If you're using Unity, the only dynamic file you'll need is the .exe file in the main directory, the other files don't need to be updated. You can speed the update process up a lot by telling it to only update the app itself and not the 106 other files that go with it.**
 ### 2) The installer
At the start of `installer.cs` there are two string fields, `github_username` and `repo_name`. These are here so that the installer can find the files for your app. It assumes a locaion of `https://github.com/{github_username}/{repo_name}/win.zip`. The installer puts the files for your app in `C:\Users\<current username>\AppData\Local\<github username>\<repo name>` on Windows, and `/Library/Application Support/<github username>/<repo name>` on Mac and Linux.
