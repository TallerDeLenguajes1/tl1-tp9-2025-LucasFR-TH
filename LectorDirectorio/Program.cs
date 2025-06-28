// See https://aka.ms/new-console-template for more information
using System.IO;

Console.WriteLine("--------------------------------------");
Console.WriteLine("......ANALIZADOR DE DIRECTORIOS.......");
Console.WriteLine("--------------------------------------");
// Al iniciar, la aplicación deberá solicitar al usuario que ingrese el path de un directorio que desea analizar
Console.WriteLine("Ingrese el directorio a analizar:");
string path = Console.ReadLine();

// El programa debe validar si el directorio ingresado existe. Si no existe, deberá notificar al usuario y solicitarle que ingrese un path válido nuevamente.
if (!Directory.Exists(path))
{
    Console.WriteLine("La ruta ingresada es incorrecta");
    Console.WriteLine("Por favor, ingrese una ruta válida:");
    path = Console.ReadLine();
}
else
{
    // mostrar Todas las carpetas que se encuentran en ese path
    Console.WriteLine("La ruta contiene los siguientes directorios:");
    string[] directorios = Directory.GetDirectories(path);
    foreach (string dir in directorios)
    {
        Console.WriteLine($"{dir}");
    }

    // mostrar Todos los archivos que se encuentran directamente en esa carpeta
    Console.WriteLine("La ruta contiene los siguientes archivos:");
    string[] archivos = Directory.GetFiles(path);

    // lista de lineas
    List<string> lineasCSV = new List<string>();
    lineasCSV.Add("Nombre; Tamaño (KB); Fecha ultima Modificacion");

    foreach (string arch in archivos)
    {
        // informacion del archivo por cada acrchivo
        FileInfo infoArchivo = new FileInfo(arch);

        // Junto a cada nombre de archivo, se deberá mostrar su tamaño en kilobytes (KB).
        Console.WriteLine($"{Path.GetFileName(arch)}");
        Console.WriteLine($"Tamaño: {infoArchivo.Length / 1024} KB");
        // Después de listar los archivos, el programa creará un archivo con extensión csv, 
        // llamado "reporte_archivos.csv" en el mismo directorio que se está analizando (use ruta relativa para el path del mismo).
        // Este archivo CSV deberá contener la siguiente información en columnas separadas:
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