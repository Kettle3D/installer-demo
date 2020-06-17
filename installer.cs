using System.Runtime.InteropServices;
using System.IO.Compression;
using System.Diagnostics;
using System.Net;
using System.IO;
using System;

class Program
{
        static string username = "Kettle3D";
        static string repository = "installer-demo";

        static void DeleteFolder(string name)
        {
            foreach (var folder in Directory.GetDirectories(name))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // Check if this is my computer
                    if (!(folder == Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}\~dev~"))
                        DeleteFolder(folder);
                    else
                        Console.WriteLine("I'm just going to ignore that folder...");
                else
                    DeleteFolder(folder);
            }
            foreach (var file in Directory.GetFiles(name))
            {
                File.Delete(file);
            }
            try
            {
                Directory.Delete(name);
            } catch
            {
                Console.WriteLine($"The folder at {name} couldn't be deleted.");
            }
        }

        static void Main(string[] args)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.WriteLine("Starting Process...");
                if (!File.Exists(Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}\version.txt"))
                {
                    // Install Completely
                    Directory.CreateDirectory(Environment.GetEnvironmentVariable("localappdata") + $@"\{username}");
                    WebClient client = new WebClient();
                    client.DownloadFile($"https://github.com/{username}/{repository}/raw/master/installer/package.zip", Environment.GetEnvironmentVariable("localappdata") + @"\{username}\pkgtemp");
                    if (Directory.Exists(Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}"))
                    {
                        DeleteFolder(Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}");
                    }

                    ZipFile.ExtractToDirectory(Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\pkgtemp", Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}");
                    client.DownloadFile($"https://github.com/{username}/{repository}/raw/master/version.txt", Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}\version.txt");
                    // Launch with Python. You'll need to change this in order to use it with a different app.
                    Process.Start("python", $"{Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}\main.py"}");
                } else
                {
                    WebClient client = new WebClient();
                    if (client.DownloadString($"https://github.com/{username}/{repository}/raw/master/version.txt") == File.ReadAllText(Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}\version.txt"))
                    {
                        // Launch with Python. You'll need to change this in order to use it with a different app.
                        Process.Start("python", Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}\main.py");
                    } else
                    {
                        Directory.CreateDirectory(Environment.GetEnvironmentVariable("localappdata") + $@"\{username}");
                        client.DownloadFile($"https://github.com/{username}/{repository}/raw/master/installer/package.zip", Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\pkgtemp");
                        if (Directory.Exists(Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}"))
                        {
                            DeleteFolder(Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}");
                        }

                        ZipFile.ExtractToDirectory(Environment.GetEnvironmentVariable("localappdata") + @"\{username}\pkgtemp", Environment.GetEnvironmentVariable("localappdata") + @"\{username}\{repository}");
                        client.DownloadFile($"https://github.com/{username}/{repository}/raw/master/version.txt", Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}\version.txt");
                        // Launch with Python. You'll need to change this in order to use it with a different app.
                        Process.Start("python", Environment.GetEnvironmentVariable("localappdata") + $@"\{username}\{repository}\main.py");
                    }
                }
            } else
            {
                Console.WriteLine("Starting Process...");
                if (!File.Exists($"/Library/Application Support/{username}/{repository}/version.txt"))
                {
                    // Install Completely
                    Directory.CreateDirectory($"/Library/Application Support/{username}");
                    WebClient client = new WebClient();
                    client.DownloadFile($"https://github.com/{username}/{repository}/raw/master/installer/package.zip", $"/Library/Application Support/{username}/pkgtemp");
                    if (Directory.Exists($"/Library/Application Support/{username}/{repository}"))
                    {
                        DeleteFolder($"/Library/Application Support/{username}/{repository}");
                    }

                    ZipFile.ExtractToDirectory($"/Library/Application Support/{username}/pkgtemp", $"/Library/Application Support/{username}/{repository}");
                    client.DownloadFile($"https://github.com/{username}/{repository}/raw/master/version.txt", $"/Library/Application Support/{username}/{repository}/version.txt");
                    // Launch with Python. You'll need to change this in order to use it with a different app.
                    Process.Start("python3", $"/Library/Application Support/{username}/{repository}/main.py");
                }
                else
                {
                    WebClient client = new WebClient();
                    if (client.DownloadString($"https://github.com/{username}/{repository}/raw/master/version.txt") == File.ReadAllText($"/Library/Application Support/{username}/{repository}/version.txt"))
                    {
                        // Launch with Python. You'll need to change this in order to use it with a different app.
                        Process.Start("python3", $"/Library/Application Support/{username}/{repository}/main.py");
                    }
                    else
                    {
                        Directory.CreateDirectory($"/Library/Application Support/{username}");
                        client.DownloadFile($"https://github.com/{username}/{repository}/raw/master/installer/package.zip", $"/Library/Application Support/{username}/pkgtemp");
                        if (Directory.Exists($"/Library/Application Support/{username}/{repository}/"))
                        {
                            DeleteFolder($"/Library/Application Support/{username}/{repository}/");
                        }

                        ZipFile.ExtractToDirectory($"/Library/Application Support/{username}/pkgtemp", $"/Library/Application Support/{username}/{repository}/");
                        client.DownloadFile($"https://github.com/{username}/{repository}/raw/master/version.txt", $"/Library/Application Support/{username}/{repository}/version.txt");
                        // Launch with Python. You'll need to change this in order to use it with a different app.
                        Process.Start("python3", $"/Library/Application Support/{username}/{repository}/main.py");
                    }
                }
            }
        }
}