
using System.IO;

public sealed class SystemProperties
{
    private static readonly Lazy<SystemProperties> _instance =
        new Lazy<SystemProperties>(() => new SystemProperties());

    public static SystemProperties Property => _instance.Value;

    private SystemProperties() { }

    public void ChangeWorkingDirectory(string newPath)
    {
        if (!Path.IsPathFullyQualified(newPath))
            newPath = Path.Combine(Environment.CurrentDirectory, newPath);

        if (!Directory.Exists(newPath))
            throw new DirectoryNotFoundException($"Directory not found: {newPath}");
        
        Environment.CurrentDirectory = newPath;
       
    }

    public string GetCurrentDirectory()
    {
        return Environment.CurrentDirectory;
    }

}