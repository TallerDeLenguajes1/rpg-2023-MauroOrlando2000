namespace Personajes
{
    public class Pelea
    {
        private double Balanceo = 40;
        public double Balance { get => Balanceo; }
        public FabricaDePersonajes Accion(FabricaDePersonajes uno, FabricaDePersonajes dos)
        {
            int i=0, intNum=0;
            double armor1=uno.CharaStats.armor, armor2=dos.CharaStats.armor;
            bool anda = false;
            string stringNum;
            uno.CharaStats.skill = dos.CharaStats.skill = false;
            if(uno.CharaInfo.affinity == Datos.Tipo.Caster)
            {
                uno.CharaStats.Aux = 0;
            }
            if(dos.CharaInfo.affinity == Datos.Tipo.Caster)
            {
                dos.CharaStats.Aux = 0;
            }
            if(uno.CharaInfo.affinity == Datos.Tipo.Assassin)
            {
                uno.CharaStats.Aux = uno.CharaStats.agility;
            }
            if(dos.CharaInfo.affinity == Datos.Tipo.Assassin)
            {
                dos.CharaStats.Aux = dos.CharaStats.agility;
            }
            while(!anda || intNum > 1 || intNum < 0)
            {
                Console.WriteLine("Desea participar de la pelea?\n0. No\n1. Si");
                stringNum = Console.ReadLine();
                anda = int.TryParse(stringNum, out intNum);
                if(!anda || intNum > 1 || intNum < 0)
                {
                    Console.WriteLine("Valor inválido");
                }
            }
            if(intNum == 1)
            {
                anda = false;
                while(!anda || intNum > 2 || intNum < 0)
                {
                    Console.WriteLine($"Que luchador desea elegir?\n");
                    Console.WriteLine($"1. {uno.CharaInfo.Name}, {uno.CharaInfo.Alias}");
                    Console.WriteLine($"2. {dos.CharaInfo.Name}, {dos.CharaInfo.Alias}");
                    Console.WriteLine("0. Cancelar");
                    stringNum = Console.ReadLine();
                    anda = int.TryParse(stringNum, out intNum);
                    if(!anda || intNum > 2 || intNum < 0)
                    {
                        Console.WriteLine("Valor inválido");
                    }
                }
            }
            while(uno.CharaStats.HP > 0 && dos.CharaStats.HP > 0)
            {
                Console.WriteLine("\nTurno "+ ++i);
                if(uno.CharaStats.speed > dos.CharaStats.speed)
                {
                    if(intNum == 1)
                    {
                        Ataque(uno, dos, intNum);
                    }
                    else
                    {
                        Ataque(uno, dos, 0);
                    }
                    Console.ReadKey();
                    if(dos.CharaStats.HP == 0)
                    {
                        Console.WriteLine($"{dos.CharaInfo.Name}, {dos.CharaInfo.Alias} ha caido");
                        if(uno.CharaInfo.affinity == Datos.Tipo.Assassin)
                        {
                            uno.CharaStats.agility = uno.CharaStats.Aux;
                        }
                        uno.CharaStats.armor = armor1;
                    }
                    else
                    {
                        if(intNum == 2)
                        {
                            Ataque(dos, uno, intNum);
                        }
                        else
                        {
                            Ataque(dos, uno, 0);
                        }
                        if(uno.CharaStats.HP == 0)
                        {
                            Console.WriteLine($"{uno.CharaInfo.Name}, {uno.CharaInfo.Alias} ha caido");
                            if(dos.CharaInfo.affinity == Datos.Tipo.Assassin)
                            {
                                dos.CharaStats.agility = dos.CharaStats.Aux;
                            }
                            dos.CharaStats.armor = armor2;
                        }
                    }
                    Console.ReadKey();
                }
                else
                {
                    if(intNum == 2)
                    {
                        Ataque(dos, uno, intNum);
                    }
                    else
                    {
                        Ataque(dos, uno, 0);
                    }
                    Console.ReadKey();
                    if(uno.CharaStats.HP == 0)
                    {
                        Console.WriteLine($"{uno.CharaInfo.Name}, {uno.CharaInfo.Alias} ha caido");
                        if(dos.CharaInfo.affinity == Datos.Tipo.Assassin)
                        {
                            dos.CharaStats.agility = dos.CharaStats.Aux;
                        }
                        dos.CharaStats.armor = armor2;
                    }
                    else
                    {
                        if(intNum == 1)
                        {
                            Ataque(uno, dos, intNum);
                        }
                        else
                        {
                            Ataque(uno, dos, 0);
                        }
                        if(dos.CharaStats.HP == 0)
                        {
                            Console.WriteLine($"{dos.CharaInfo.Name}, {dos.CharaInfo.Alias} ha caido");
                            if(uno.CharaInfo.affinity == Datos.Tipo.Assassin)
                            {
                                uno.CharaStats.agility = uno.CharaStats.Aux;
                            }
                            uno.CharaStats.armor = armor1;
                        }
                    }
                    Console.ReadKey();
                }
            }
            if(uno.CharaStats.HP == 0)
            {
                return dos;
            }
            else
            {
                return uno;
            }
        }
        public double afinidad(FabricaDePersonajes atacante, FabricaDePersonajes defensor)
        {
            double efectividad = 1;
            switch(atacante.CharaInfo.affinity)
            {
                case Datos.Tipo.Saber: 
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Lancer) { efectividad = 2; }
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Archer) { efectividad = 0.5; }
                    break;
                case Datos.Tipo.Lancer: 
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Archer) { efectividad = 2; }
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Saber) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Archer: 
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Saber) { efectividad = 2; }
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Lancer) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Rider: 
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Caster) { efectividad = 2; }
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Assassin) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Caster:
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Assassin) { efectividad = 2; }
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Rider) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Assassin: 
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Rider) { efectividad = 2; }
                    if(defensor.CharaInfo.affinity == Datos.Tipo.Caster) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Berserker: 
                    efectividad = 1.5;
                break;
            }
            if(defensor.CharaInfo.affinity == Datos.Tipo.Berserker && atacante.CharaInfo.affinity != Datos.Tipo.Berserker)
            { 
                efectividad = 2; 
            }
            if(defensor.CharaInfo.affinity == Datos.Tipo.Caster && defensor.CharaStats.Aux > 0)
            {
                efectividad = 1;
                defensor.CharaStats.Aux -= 1;
            }
            return efectividad;
        }

        public void Ataque(FabricaDePersonajes atacante, FabricaDePersonajes defensor, int aux)
        {
            Random rnd = new Random();
            int evadir = rnd.Next(1,101), intNum=0;
            bool anda = true;
            string stringNum;
            Console.WriteLine($"{atacante.CharaInfo.Name}, {atacante.CharaInfo.Alias} ataca");
            if(aux != 0)
            {
                while(!anda || intNum > 2 || intNum < 1)
                {
                    Console.WriteLine("Que desea hacer?\n1. Usar ataque basico\n2. Usar habilidad");
                    stringNum = Console.ReadLine();
                    anda = int.TryParse(stringNum, out intNum);
                    if(!anda || intNum > 2 || intNum < 1)
                    {
                        Console.WriteLine("Valor inválido");
                    }
                }
                if(intNum == 1)
                {
                    if(Fallar(defensor))
                    {
                        Console.WriteLine("El ataque falló\n");
                    }
                    else
                    {
                        basicAttack(atacante, defensor);
                    }
                }
                else
                {
                    if(atacante.CharaInfo.affinity == Datos.Tipo.Caster)
                    {
                        if(atacante.CharaStats.HP < 50)
                        {
                            skill(atacante, defensor);
                        }
                        else
                        {
                            Console.WriteLine("La habilidad falló");
                        }
                    }
                    else
                    {
                        skill(atacante, defensor);
                    }
                }
            }
            else
            {
                if(atacante.CharaStats.HP < 50 && !atacante.CharaStats.skill)
                {
                    if(atacante.CharaInfo.affinity == Datos.Tipo.Caster)
                    {
                        if(atacante.CharaStats.HP < 50)
                        {
                            skill(atacante, defensor);
                        }
                        else
                        {
                            Console.WriteLine("La habilidad falló");
                        }
                    }
                    else
                    {
                        skill(atacante, defensor);
                    }
                    atacante.CharaStats.skill = true;
                }
                else
                {
                    if(Fallar(defensor))
                    {
                        Console.WriteLine("El ataque falló");
                    }
                    else
                    {
                        basicAttack(atacante, defensor);
                    }
                }
            }
        }
        public void basicAttack(FabricaDePersonajes atacante, FabricaDePersonajes defensor)
        {
            Random rnd = new Random();
            double RNG, ataque, efectividad, damage;
            RNG = rnd.Next(70, 101);
            ataque = atacante.CharaStats.attack * atacante.CharaStats.level * RNG / defensor.CharaStats.armor;
            efectividad = afinidad(atacante, defensor);
            damage = Math.Round((ataque * efectividad) / Balance);
            defensor.CharaStats.HP -= damage;
            Console.WriteLine($"{defensor.CharaInfo.Name}, {defensor.CharaInfo.Alias} recibe {damage} de daño");
            if(defensor.CharaStats.HP < 0)
            {
                defensor.CharaStats.HP = 0;
            }
            Console.WriteLine("Vida restante: " + defensor.CharaStats.HP + "\n");
        }

        public void skill(FabricaDePersonajes atacante, FabricaDePersonajes defensor)
        {
            Random rnd = new Random();
            double RNG, ataque, efectividad, damage;
            RNG = rnd.Next(70, 101);
            efectividad = afinidad(atacante, defensor);
            switch(atacante.CharaInfo.affinity)
            {
                case Datos.Tipo.Lancer:
                case Datos.Tipo.Archer:
                case Datos.Tipo.Saber: ataque = atacante.CharaStats.attack * atacante.CharaStats.level * RNG * 1.5 / defensor.CharaStats.armor;
                    damage = Math.Round((ataque * efectividad) / Balance);
                    Console.WriteLine($"{atacante.CharaInfo.Name}, {atacante.CharaInfo.Alias} usa su habilidad");
                    defensor.CharaStats.HP -= damage;
                    Console.WriteLine($"{defensor.CharaInfo.Name}, {defensor.CharaInfo.Alias} recibe {damage} de daño");
                    if(defensor.CharaStats.HP < 0)
                    {
                        defensor.CharaStats.HP = 0;
                    }
                    Console.WriteLine("Vida restante: " + defensor.CharaStats.HP + "\n");
                break;

                case Datos.Tipo.Rider: ataque = atacante.CharaStats.attack * atacante.CharaStats.level * RNG / defensor.CharaStats.armor;
                    damage = Math.Round((ataque * efectividad) / Balance);
                    Console.WriteLine($"{atacante.CharaInfo.Name}, {atacante.CharaInfo.Alias} usa su habilidad");
                    defensor.CharaStats.HP -= damage;
                    Console.WriteLine($"{defensor.CharaInfo.Name}, {defensor.CharaInfo.Alias} recibe {damage} de daño");
                    if(defensor.CharaStats.HP < 0)
                    {
                        defensor.CharaStats.HP = 0;
                    }
                    Console.WriteLine("Vida restante: " + defensor.CharaStats.HP + "\n");
                    defensor.CharaStats.armor *= 0.85;
                    Console.WriteLine($"La armadura del defensor se vió reducida");
                break;

                case Datos.Tipo.Caster: Console.WriteLine($"{atacante.CharaInfo.Name}, {atacante.CharaInfo.Alias} usa su habilidad");
                    atacante.CharaStats.Aux = 3;
                    Console.WriteLine("Afinidad defensiva de atacante alterada por los proximos 3 turnos(recibe daño neutro de todos los tipos)");
                    atacante.CharaStats.HP += 15;
                    Console.WriteLine("Vida curada");
                    if(atacante.CharaStats.HP > 50)
                    {
                        atacante.CharaStats.HP = 50;
                        Console.WriteLine("Alcanzo limite de curacion");
                    }
                    atacante.CharaStats.armor += 4;
                    Console.WriteLine("Armadura aumentada\n");
                    if(atacante.CharaStats.armor > 25)
                    {
                        atacante.CharaStats.armor = 25;
                        Console.WriteLine("Limite de armadura alcanzado\n");
                    }
                break;

                case Datos.Tipo.Assassin: ataque = atacante.CharaStats.attack * atacante.CharaStats.level * RNG / defensor.CharaStats.armor;
                    damage = Math.Round((ataque * efectividad) / Balance);
                    Console.WriteLine($"{atacante.CharaInfo.Name}, {atacante.CharaInfo.Alias} usa su habilidad");
                    defensor.CharaStats.HP -= damage;
                    Console.WriteLine($"{defensor.CharaInfo.Name}, {defensor.CharaInfo.Alias} recibe {damage} de daño");
                    if(defensor.CharaStats.HP < 0)
                    {
                        defensor.CharaStats.HP = 0;
                    }
                    Console.WriteLine("Vida restante: " + defensor.CharaStats.HP + "\n");
                    if(atacante.CharaStats.agility == 40)
                    {
                        Console.WriteLine("No puede subir mas la agilidad\n");
                    }
                    else
                    {
                        atacante.CharaStats.agility += 5;
                        if(atacante.CharaStats.agility > 40)
                        {
                            atacante.CharaStats.agility = 40;
                        }
                        Console.WriteLine("Subió la agilidad del atacante\n");
                    }
                break;

                case Datos.Tipo.Berserker: ataque = (atacante.CharaStats.attack * atacante.CharaStats.level * RNG * 1.8) / defensor.CharaStats.armor;
                    damage = Math.Round((ataque * efectividad) / Balance);
                    Console.WriteLine($"{atacante.CharaInfo.Name}, {atacante.CharaInfo.Alias} usa su habilidad");
                    defensor.CharaStats.HP -= damage;
                    Console.WriteLine($"{defensor.CharaInfo.Name}, {defensor.CharaInfo.Alias} recibe {damage} de daño");
                    if(defensor.CharaStats.HP < 0)
                    {
                        defensor.CharaStats.HP = 0;
                    }
                    Console.WriteLine("Vida restante: " + defensor.CharaStats.HP + "\n");
                    atacante.CharaStats.HP -= Math.Round(damage * 0.25);
                    if(atacante.CharaStats.HP <= 0)
                    {
                        atacante.CharaStats.HP = 1;
                    }
                    Console.WriteLine($"El atacante recibió {Math.Round(damage * 0.25)} daño de retroceso");
                    Console.WriteLine("Vida restante: " + atacante.CharaStats.HP + "\n");
                break;
            }
        }

        public bool Fallar(FabricaDePersonajes defensor)
        {
            Random rnd = new Random();
            bool fallo = false;
            int num = rnd.Next(1,101);
            if(defensor.CharaStats.agility > num)
            {
                fallo = true;
            }
            return fallo;
        }

        public void recompensa(FabricaDePersonajes personaje)
        {
            Random rnd = new Random();
            int intAux = rnd.Next(4);
            switch(intAux)
            {
                case 0:
                    Console.WriteLine("RECOMPENSA: +25 de Salud");
                    personaje.CharaStats.HP += 40;
                break;
                case 1:
                    Console.WriteLine("RECOMPENSA: +10 defensa");
                    personaje.CharaStats.armor += 10;
                break;
                case 2:
                    Console.WriteLine("RECOMPENSA: +10 ataque");
                    personaje.CharaStats.attack += 10;
                break;
                case 3:
                    Console.WriteLine("RECOMPENSA: +5 velocidad y +10 agilidad");
                    personaje.CharaStats.agility += 10;
                    personaje.CharaStats.speed += 5;
                break;
            }
        }
    }
}