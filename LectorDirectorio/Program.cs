// See https://aka.ms/new-console-template for more information
using System.IO;

Console.WriteLine("--------------------------------------");
Console.WriteLine("......ANALIZADOR DE DIRECTORIOS.......");
Console.WriteLine("--------------------------------------");

Console.WriteLine("Ingrese el directorio a analizar:");
string path = Console.ReadLine();

if (!Directory.Exists(path))
{
    Console.WriteLine("La ruta ingresada es incorrecta");
}
else
{
    // mostrar los directorios
    Console.WriteLine("La ruta contiene los siguientes directorios:");
    string[] directorios = Directory.GetDirectories(path);
    foreach (string dir in directorios)
    {
        Console.WriteLine($"{dir}");
    }

    // mostrar losarchivos contenidos
    Console.WriteLine("La ruta contiene los siguientes archivos:");
    string[] archivos = Directory.GetFiles(path);

    // lista de lineas
    List<string> lineasCSV = new List<string>();
    lineasCSV.Add("Nombre; Tamaño (KB); Fecha ultima Modificacion");

    foreach (string arch in archivos)
    {
        // informacion del archivo por cada acrchivo
        FileInfo infoArchivo = new FileInfo(arch);

        Console.WriteLine($"{Path.GetFileName(arch)}");
        string nombre = infoArchivo.Name;
        double tam = infoArchivo.Length / 1024;
        DateTime fechault = infoArchivo.LastWriteTime;

        lineasCSV.Add($"{nombre};{tam};{fechault}");
    }

    string rutaCSV = path + "\\reporte_archivos.csv";

    // crear el archivo con con los archivos contenidos
    Console.WriteLine("El archivos esta siendo creado...");
    File.WriteAllLines(rutaCSV, lineasCSV);
}