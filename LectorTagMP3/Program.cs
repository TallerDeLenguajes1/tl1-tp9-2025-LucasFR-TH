// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Text;
using EspacioId3V1Tag;

// Dentro de su repositorio cree una carpeta que se llame “LectorTagMP3” en ella crear una 
// aplicación de consola en C# para leer el tag de un archivo MP3.
Console.WriteLine("--------------------------------------");
Console.WriteLine(".............ANALIZAR MP3.............");
Console.WriteLine("--------------------------------------");

byte[] buffer = new byte[128];
string RutaArchivo = @"F:\PROGRAMACION\TALLER LENGUAJE\tp9\tl1-tp9-2025-LucasFR-TH\LectorTagMP3\vacio.mp3";

if (File.Exists(RutaArchivo))
{
    FileStream MiArchivo = new FileStream("vacio.mp3", FileMode.Open);

    MiArchivo.Seek(-128, SeekOrigin.End);

    MiArchivo.Read(buffer, 0, 128);

    string header = Encoding.GetEncoding("latin1").GetString(buffer, 0, 3);
    if (header != "TAG") {
        Console.WriteLine("NO HAY TAG");
    } else {
        Console.WriteLine("HAY TAG");
    }
}
