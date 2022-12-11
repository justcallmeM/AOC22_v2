namespace AOC22.Days
{
    using Constants;
    using Library;

    public static class Day7
    {
        public static void Execute()
        {
            List<string> commands = ReadMethods.ReadFileIntoList(InputPath.DAY7_INPUT_PATH);

            Directory fileSystem = new("/", "/"); //create file system

            for (int i = 1; i < commands.Count - 1; i++)
            {
                string[] commandSplit = commands[i].Split(' ');

                string command = commandSplit[0];
                string[] parameters = commandSplit.Skip(1).ToArray();

                FileSystem.ExecuteCommand(fileSystem, command, parameters);
            }
        }
    }

    public static class FileSystem
    {
        public static void ExecuteCommand(Directory directory, string command, string[] parameters)
        {
            switch(command)
            {
                case "$":
                    switch (parameters.First())
                    {
                        case "ls":
                            break;
                        case "cd":
                            GoToDirectory(ref directory, parameters.Last());
                            break;
                        default:
                            break;
                    }
                    break;
                case "dir":
                    directory.CreateDirectory(parameters.First(), directory.Path);
                    break;
                default:
                    if(int.TryParse(command, out int result))
                    {
                        directory.CreateFile(parameters.First(), result);
                    }
                    break;
            }
        }

        private static void GoToDirectory(ref Directory currentDirectory, string name)
        {
            if(name == "..")
            {
                var dirList = currentDirectory.Path.Split('/').SkipLast(1);

                string directoryName = !dirList.Any() ? "/" : dirList.Last();

                currentDirectory = currentDirectory.Directories.Where(x => x.Name == directoryName).First();
            }
            else
            {
                currentDirectory = currentDirectory.Directories.Where(x => x.Name == name).First();
            }
        }

    }

    public class Directory
    {
        public Directory(
            string name,
            string path)
        {
            path = path.Equals("/") && name.Equals("/") ? string.Empty : path;

            Name = name;
            Path = path + $"{name}";
        }

        public string Name { get; }

        public string Path { get; }

        public List<Directory> Directories { get; } = new();

        public List<File> Files { get; } = new();

        public void CreateDirectory(string name, string path)
        {
            Directories.Add(new Directory(name, path));
        }

        public void CreateFile(string name, int size)
        {
            Files.Add(new File(name, size));
        }
    }

    public class File
    {
        public File(
            string name,
            int size)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; }

        public int Size { get; }
    }
}
