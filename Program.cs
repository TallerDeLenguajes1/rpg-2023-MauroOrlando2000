using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Personajes;

List<FabricaDePersonajes> PersonajesEnPie = new List<FabricaDePersonajes>();
var PersonajesPeleando = new List<FabricaDePersonajes>();
var ganadores = new List<FabricaDePersonajes>();
PersonajesJson json = new PersonajesJson();
Random rnd = new Random();
int i=0, aux;
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

Console.WriteLine("Advertencia: Dos luchadores serán descalificados para mantener una llave de 8");
for(int j=0; j<2; j++)
{
    int num = rnd.Next(i);
    i--;
    FabricaDePersonajes seleccionado = PersonajesEnPie[num];
    PersonajesEnPie.Remove(seleccionado);
    Console.WriteLine($"{seleccionado.CharaInfo.Name}, {seleccionado.CharaInfo.Alias} eliminado");
}

for(int k=1; k<=4; k++)
{
    Console.WriteLine("\n\nCUARTOS DE FINAL " + k);
    for(int j=0; j<2; j++)
    {
        int num = rnd.Next(i);
        FabricaDePersonajes seleccionado = PersonajesEnPie[num];
        PersonajesPeleando.Add(seleccionado);
        PersonajesEnPie.Remove(seleccionado);
        i--;
    }
    Pelea Pelea = new Pelea();
    Console.WriteLine($"{PersonajesPeleando[0].CharaInfo.Name} , {PersonajesPeleando[0].CharaInfo.Alias} VS {PersonajesPeleando[1].CharaInfo.Name} , {PersonajesPeleando[1].CharaInfo.Alias}");
    FabricaDePersonajes ganador = Pelea.Accion(PersonajesPeleando[0], PersonajesPeleando[1]);
    Console.WriteLine($"GANADOR: {ganador.CharaInfo.Name}, {ganador.CharaInfo.Alias}");
    int intAux = rnd.Next(4);
    switch(intAux)
    {
        case 0:
            Console.WriteLine("RECOMPENSA: +25 de Salud");
            ganador.CharaStats.HP += 25;
        break;
        case 1:
            Console.WriteLine("RECOMPENSA: +10 defensa");
            ganador.CharaStats.armor += 10;
        break;
        case 2:
            Console.WriteLine("RECOMPENSA: +10 ataque");
            ganador.CharaStats.attack += 10;
        break;
        case 3:
            Console.WriteLine("RECOMPENSA: +5 velocidad y +10 agilidad");
            ganador.CharaStats.agility += 10;
            ganador.CharaStats.speed += 5;
        break;
    }
    ganadores.Add(ganador);
    PersonajesPeleando.Clear();
    Console.ReadKey();
}
aux = i = ganadores.Count - 1;
while(aux >= 0)
{
    FabricaDePersonajes seleccionado = ganadores[aux];
    PersonajesEnPie.Add(seleccionado);
    aux--;
}
ganadores.Clear();

for(int k=1; k<=2; k++)
{
    Console.WriteLine("\n\nSEMIFINAL " + k);
    for(int j=0; j<2; j++)
    {
        int num = rnd.Next(i);
        FabricaDePersonajes seleccionado = PersonajesEnPie[num];
        PersonajesPeleando.Add(seleccionado);
        PersonajesEnPie.Remove(seleccionado);
        i--;
    }
    Pelea Pelea = new Pelea();
    Console.WriteLine($"{PersonajesPeleando[0].CharaInfo.Name} , {PersonajesPeleando[0].CharaInfo.Alias} VS {PersonajesPeleando[1].CharaInfo.Name} , {PersonajesPeleando[1].CharaInfo.Alias}");
    FabricaDePersonajes ganador = Pelea.Accion(PersonajesPeleando[0], PersonajesPeleando[1]);
    Console.WriteLine($"GANADOR: {ganador.CharaInfo.Name}, {ganador.CharaInfo.Alias}");
    int intAux = rnd.Next(4);
    switch(intAux)
    {
        case 0:
            Console.WriteLine("RECOMPENSA: +25 de Salud");
            ganador.CharaStats.HP += 25;
        break;
        case 1:
            Console.WriteLine("RECOMPENSA: +10 defensa");
            ganador.CharaStats.armor += 10;
        break;
        case 2:
            Console.WriteLine("RECOMPENSA: +10 ataque");
            ganador.CharaStats.attack += 10;
        break;
        case 3:
            Console.WriteLine("RECOMPENSA: +5 velocidad y +10 agilidad");
            ganador.CharaStats.agility += 10;
            ganador.CharaStats.speed += 5;
        break;
    }
    ganadores.Add(ganador);
    PersonajesPeleando.Clear();
    Console.ReadKey();
}
aux = i = ganadores.Count - 1;
while(aux >= 0)
{
    FabricaDePersonajes seleccionado = ganadores[aux];
    PersonajesEnPie.Add(seleccionado);
    aux--;
}
ganadores.Clear();

Console.WriteLine("\n\nFINAL");
for(int j=0; j<2; j++)
{
    int num = rnd.Next(i);
    FabricaDePersonajes seleccionado = PersonajesEnPie[num];
    PersonajesPeleando.Add(seleccionado);
    PersonajesEnPie.Remove(seleccionado);
    i--;
}
Pelea Final = new Pelea();
Console.WriteLine($"{PersonajesPeleando[0].CharaInfo.Name} , {PersonajesPeleando[0].CharaInfo.Alias} VS {PersonajesPeleando[1].CharaInfo.Name} , {PersonajesPeleando[1].CharaInfo.Alias}");
FabricaDePersonajes GranGanador = Final.Accion(PersonajesPeleando[0], PersonajesPeleando[1]);
Console.WriteLine($"GANADOR: {GranGanador.CharaInfo.Name}, {GranGanador.CharaInfo.Alias}");
PersonajesPeleando.Clear();

Console.WriteLine($"ENHORABUENA {GranGanador.CharaInfo.Name}, {GranGanador.CharaInfo.Alias}");
Console.WriteLine("ESTADISTICAS FINALES");
GranGanador.mostrarPersonaje();