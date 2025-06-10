// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Text;

Console.WriteLine("--------------------------------------");
Console.WriteLine(".............ANALIZAR MP3.............");
Console.WriteLine("--------------------------------------");

Console.WriteLine("Ingrese el tag a analizar:");
Stream fs = new Stream();

if ()
{
    // verfiicar que los primeros 3 bits tienen TAG
    // verificar la cantidad totla de bytes del arhcivoy le resto 128 para poderusar el seek
    fs.Seek(-128, SeekOrigin.End);
}

byte[] buffer = new byte[128];

int bytesleidos = fs.Read(buffer, 0, 128);

Encoding.Latin1.GetString(buffer, 0, 3);