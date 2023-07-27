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
int i=0, aux, intNum=1;
string archivo = "Personajes.json", stringNum="";
bool anda=false;

Console.WriteLine("MENU PRINCIPAL");
if(json.Existe(archivo))
{
    Console.WriteLine("Archivo de personajes encontrado");
    while(!anda || intNum > 2 || intNum < 1)
    {
        Console.WriteLine("Que desea hacer?\n1. Crear personajees nuevos\n2. Leer personajes guardados");
        stringNum = Console.ReadLine();
        anda = int.TryParse(stringNum, out intNum);
        if(!anda || intNum > 2 || intNum < 1)
        {
            Console.WriteLine("Valor inválido");
        }
    }
    if(intNum == 2)
    {
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
        anda = false;
        while(!anda || intNum > 2 || intNum < 1)
        {
            Console.WriteLine("Desea crear personajes con el offline o online?\n1.Online\n2.Offline");
            stringNum = Console.ReadLine();
            anda = int.TryParse(stringNum, out intNum);
            if(!anda || intNum > 2 || intNum < 1)
            {
                Console.WriteLine("Valor inválido");
            }
        }
        if(intNum == 1)
        {
            Console.WriteLine("Se crearan personajes nuevos de manera online\n");
            string url = "https://randomapi.com/api/e9a3b0d847609bbda960c8a85c1fd3c7";
            for(i=1; i<=10; i++)
            {
                cargaHttp cliente = new cargaHttp();
                FabricaDePersonajes character = await cliente.cargarApi(url);
                character.CrearPersonajeOnline(character);
                Console.WriteLine("\nPERSONAJE " + i);
                character.mostrarPersonaje();
                PersonajesEnPie.Add(character);
                Console.WriteLine("\n");
            }
            json.GuardarPersonajes(PersonajesEnPie, archivo);
        }
        else
        {
            Console.WriteLine("Se crearan personajes usando el algoritmo integrado\n");
            for(i=1; i<=10; i++)
            {
                FabricaDePersonajes character = new FabricaDePersonajes();
                character.CrearPersonajeOffline();
                Console.WriteLine("\nPERSONAJE " + i);
                character.mostrarPersonaje();
                PersonajesEnPie.Add(character);
                Console.WriteLine("\n");
            }
            json.GuardarPersonajes(PersonajesEnPie, archivo);
        }
    }
}
else
{
    anda = false;
    while(!anda || intNum > 2 || intNum < 1)
    {
        Console.WriteLine("Desea crear personajes con el offline o online?\n1.Online\n2.Offline");
        stringNum = Console.ReadLine();
        anda = int.TryParse(stringNum, out intNum);
        if(!anda || intNum > 2 || intNum < 1)
        {
            Console.WriteLine("Valor inválido");
        }
    }
    if(intNum == 1)
    {
        Console.WriteLine("Se crearan personajes nuevos de manera online\n");
        string url = "https://randomapi.com/api/e9a3b0d847609bbda960c8a85c1fd3c7";
        for(i=1; i<=10; i++)
        {
            cargaHttp cliente = new cargaHttp();
            FabricaDePersonajes character = await cliente.cargarApi(url);
            character.CrearPersonajeOnline(character);
            Console.WriteLine("\nPERSONAJE " + i);
            character.mostrarPersonaje();
            PersonajesEnPie.Add(character);
            Console.WriteLine("\n");
        }
        json.GuardarPersonajes(PersonajesEnPie, archivo);
    }
    else
    {
        Console.WriteLine("Se crearan personajes usando el algoritmo integrado\n");
        for(i=1; i<=10; i++)
        {
            FabricaDePersonajes character = new FabricaDePersonajes();
            character.CrearPersonajeOffline();
            Console.WriteLine("\nPERSONAJE " + i);
            character.mostrarPersonaje();
            PersonajesEnPie.Add(character);
            Console.WriteLine("\n");
        }
        json.GuardarPersonajes(PersonajesEnPie, archivo);
    }
}

i--;
Console.WriteLine("Advertencia: Seis luchadores de manera aleatoria pasaran a cuartos para mantener una llave de 8");
for(int j=0; j<6; j++)
{
    int num = rnd.Next(i);
    i--;
    FabricaDePersonajes seleccionado = PersonajesEnPie[num];
    ganadores.Add(seleccionado);
    PersonajesEnPie.Remove(seleccionado);
    Console.WriteLine($"{seleccionado.CharaInfo.Name}, {seleccionado.CharaInfo.Alias} pasa a cuartos");
}

for(int k=1; k<=2; k++)
{
    Console.WriteLine("\n\nOCTAVOS DE FINAL " + k);
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
    Pelea.recompensa(ganador);
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
    Pelea.recompensa(ganador);
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
    Pelea.recompensa(ganador);
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

Console.WriteLine($"GANADOR DEL TORNEO: {GranGanador.CharaInfo.Name}, {GranGanador.CharaInfo.Alias}");
Console.WriteLine("ENHORABUENA");
Console.WriteLine("Es usted el merecedor del trono de hierro");
Console.WriteLine("ESTADISTICAS FINALES");
GranGanador.mostrarPersonaje();