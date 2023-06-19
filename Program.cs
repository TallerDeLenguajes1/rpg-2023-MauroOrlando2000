using System;
using System.IO;
using System.Collections.Generic;
using Personajes;

List<FabricaDePersonajes> PersonajesEnPie = new List<FabricaDePersonajes>();
var PersonajesPeleando = new List<FabricaDePersonajes>();
var PersonajesDerrotados = new List<FabricaDePersonajes>();
bool anda;
int num = 0;
string? stringNum = "";

for(int i=0; i<2; i++)
{
    anda = false;
    FabricaDePersonajes character = new FabricaDePersonajes();
    while(!anda || num < 0 || num > 1)
    {
        character.CrearPersonaje();
        character.mostrarPersonaje();
        Console.WriteLine("Quiere generar otro personaje? (0=No, 1=Si)");
        stringNum = Console.ReadLine();
        anda = int.TryParse(stringNum, out num);
        if(!anda || num < 0 || num > 1)
        {
            Console.WriteLine("Valor invalido");
        }
        anda = num == 0? true : false; 
    }
}

foreach(FabricaDePersonajes personaje in PersonajesEnPie)
{
    Console.WriteLine("\n\n");
    personaje.mostrarPersonaje();
}
