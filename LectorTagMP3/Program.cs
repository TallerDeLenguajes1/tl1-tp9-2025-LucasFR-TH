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
    // El programa deberá leer esta información
    FileStream MiArchivo = new FileStream("vacio.mp3", FileMode.Open);

    MiArchivo.Seek(-128, SeekOrigin.End);

    MiArchivo.Read(buffer, 0, 128);

    string header = Encoding.GetEncoding("latin1").GetString(buffer, 0, 3);
    // CONTROL PARA SABER QUE HAY TAG VALIDO
    if (header != "TAG")
    {
        Console.WriteLine("NO HAY TAG");
    }

    // cargar en una instancia de una clase Id3v1Tag
    Id3v1Tag tag = new Id3v1Tag
    {
        Titulo = Encoding.GetEncoding("latin1").GetString(buffer, 3, 30).TrimEnd('\0', ' '),
        Artista = Encoding.GetEncoding("latin1").GetString(buffer, 33, 30).TrimEnd('\0', ' '),
        Album = Encoding.GetEncoding("latin1").GetString(buffer, 63, 30).TrimEnd('\0', ' '),
        Año = Encoding.GetEncoding("latin1").GetString(buffer, 93, 4).TrimEnd('\0', ' ')
    };
    
    // y luego mostrar por consola el título, artista, álbum y año de la canción.
    Console.WriteLine("Información del Tag ID3v1:");
    Console.WriteLine($"Título: {tag.Titulo}");
    Console.WriteLine($"Artista: {tag.Artista}");
    Console.WriteLine($"Álbum: {tag.Album}");
    Console.WriteLine($"Año: {tag.Año}");

}
    

