using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Personajes;

List<FabricaDePersonajes> PersonajesEnPie = new List<FabricaDePersonajes>();
PersonajesJson json = new PersonajesJson();
int i=0;
string archivo = "Personajes.json";

Console.WriteLine("MENU PRINCIPAL");
if(json.Existe(archivo))
{
    Console.WriteLine("Archivo de personajes encontrado");
    PersonajesEnPie = json.LeerPersonajes(archivo);
    foreach(FabricaDePersonajes personaje in PersonajesEnPie)
    {
        Console.WriteLine("\nPERSONAJE " + ++i);
        personaje.mostrarPersonaje();
        Console.WriteLine("\n");
    }
}
else
{
    for(i=1; i<=10; i++)
    {
        FabricaDePersonajes character = new FabricaDePersonajes();
        character.CrearPersonaje();
        Console.WriteLine("\nPERSONAJE " + i);
        character.mostrarPersonaje();
        PersonajesEnPie.Add(character);
        Console.WriteLine("\n");
    }
    json.GuardarPersonajes(PersonajesEnPie, archivo);
}