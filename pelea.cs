namespace Personajes
{
    public class Pelea
    {
        private double Balanceo = 25;
        public double Balance { get => Balanceo; }
        public FabricaDePersonajes Accion(FabricaDePersonajes uno, FabricaDePersonajes dos)
        {
            Random rnd = new Random();
            int i=0;
            double RNG, ataque, damage, evadir, efectividad;
            while(uno.CharaStats.HP > 0 && dos.CharaStats.HP > 0)
            {
                Console.WriteLine("\nTurno "+ ++i);
                if(uno.CharaStats.speed > dos.CharaStats.speed)
                {
                    evadir = rnd.Next(1,101);
                    RNG = rnd.Next(70, 101);
                    ataque = uno.CharaStats.attack * uno.CharaStats.level * RNG;
                    efectividad = afinidad(uno.CharaInfo.affinity, dos.CharaInfo.affinity);
                    damage = ataque * efectividad / dos.CharaStats.armor;
                    damage /= Balance;
                    damage = Math.Round(damage);
                    Console.WriteLine($"{uno.CharaInfo.Name}, {uno.CharaInfo.Alias} ataca");
                    if(evadir < dos.CharaStats.agility)
                    {
                        Console.WriteLine("El ataque ha fallado");
                    }
                    else
                    {
                        dos.CharaStats.HP -= damage;
                        Console.WriteLine($"{dos.CharaInfo.Name}, {dos.CharaInfo.Alias} recibe {damage} de daño");
                        if(dos.CharaStats.HP < 0)
                        {
                            dos.CharaStats.HP = 0;
                        }
                        Console.WriteLine("Vida restante: " + dos.CharaStats.HP);
                    }
                    Console.ReadKey();
                    if(dos.CharaStats.HP <= 0)
                    {
                        Console.WriteLine($"{dos.CharaInfo.Name}, {dos.CharaInfo.Alias} ha caido");
                    }
                    else
                    {
                        evadir = rnd.Next(1,101);
                        RNG = rnd.Next(70, 101);
                        ataque = dos.CharaStats.attack * dos.CharaStats.level * RNG;
                        efectividad = afinidad(dos.CharaInfo.affinity, uno.CharaInfo.affinity);
                        damage = ataque * efectividad / uno.CharaStats.armor;
                        damage /= Balance;
                        damage = Math.Round(damage);
                        Console.WriteLine($"\n{dos.CharaInfo.Name}, {dos.CharaInfo.Alias} ataca");
                        if(evadir < uno.CharaStats.agility)
                        {
                            Console.WriteLine("El ataque ha fallado");
                        }
                        else
                        {
                            uno.CharaStats.HP -= damage;
                            Console.WriteLine($"{uno.CharaInfo.Name}, {uno.CharaInfo.Alias} recibe {damage} de daño");
                            if(uno.CharaStats.HP < 0)
                            {
                                uno.CharaStats.HP = 0;
                            }
                            Console.WriteLine("Vida restante: " + uno.CharaStats.HP);
                        }
                        if(uno.CharaStats.HP <= 0)
                        {
                            Console.WriteLine($"{uno.CharaInfo.Name}, {uno.CharaInfo.Alias} ha caido");
                        }
                    }
                    Console.ReadKey();
                }
                else
                {
                    evadir = rnd.Next(1,101);
                    RNG = rnd.Next(70, 101);
                    ataque = dos.CharaStats.attack * dos.CharaStats.level * RNG;
                    efectividad = afinidad(dos.CharaInfo.affinity, uno.CharaInfo.affinity);
                    damage = ataque * efectividad / uno.CharaStats.armor;
                    damage /= Balance;
                    damage = Math.Round(damage);
                    Console.WriteLine($"{dos.CharaInfo.Name}, {dos.CharaInfo.Alias} ataca");
                    if(evadir < uno.CharaStats.agility)
                    {
                        Console.WriteLine("El ataque ha fallado");
                    }
                    else
                    {
                        uno.CharaStats.HP -= damage;
                        Console.WriteLine($"{uno.CharaInfo.Name}, {uno.CharaInfo.Alias} recibe {damage} de daño");
                        if(uno.CharaStats.HP < 0)
                        {
                            uno.CharaStats.HP = 0;
                        }
                        Console.WriteLine("Vida restante: " + uno.CharaStats.HP);
                    }
                    Console.ReadKey();
                    if(uno.CharaStats.HP <= 0)
                    {
                        Console.WriteLine($"{uno.CharaInfo.Name}, {uno.CharaInfo.Alias} ha caido");
                    }
                    else
                    {
                        evadir = rnd.Next(1,101);
                        RNG = rnd.Next(70, 101);
                        ataque = uno.CharaStats.attack * uno.CharaStats.level * RNG;
                        efectividad = afinidad(uno.CharaInfo.affinity, dos.CharaInfo.affinity);
                        damage = ataque * efectividad / dos.CharaStats.armor;
                        damage /= Balance;
                        damage = Math.Round(damage);
                        Console.WriteLine($"\n{uno.CharaInfo.Name}, {uno.CharaInfo.Alias} ataca");
                        if(evadir < dos.CharaStats.agility)
                        {
                            Console.WriteLine("El ataque ha fallado");
                        }
                        else
                        {
                            dos.CharaStats.HP -= damage;
                            Console.WriteLine($"{dos.CharaInfo.Name}, {dos.CharaInfo.Alias} recibe {damage} de daño");
                            if(dos.CharaStats.HP < 0)
                            {
                                dos.CharaStats.HP = 0;
                            }
                            Console.WriteLine("Vida restante: " + dos.CharaStats.HP);
                        }
                        if(dos.CharaStats.HP <= 0)
                        {
                            Console.WriteLine($"{dos.CharaInfo.Name}, {dos.CharaInfo.Alias} ha caido");
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
        public double afinidad(Datos.Tipo atacante, Datos.Tipo defensor)
        {
            double efectividad = 1;
            switch(atacante)
            {
                case Datos.Tipo.Saber: 
                    if(defensor == Datos.Tipo.Lancer) { efectividad = 2; }
                    if(defensor == Datos.Tipo.Archer) { efectividad = 0.5; }
                    break;
                case Datos.Tipo.Lancer: 
                    if(defensor == Datos.Tipo.Archer) { efectividad = 2; }
                    if(defensor == Datos.Tipo.Saber) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Archer: 
                    if(defensor == Datos.Tipo.Saber) { efectividad = 2; }
                    if(defensor == Datos.Tipo.Lancer) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Rider: 
                    if(defensor == Datos.Tipo.Caster) { efectividad = 2; }
                    if(defensor == Datos.Tipo.Assassin) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Caster: 
                    if(defensor == Datos.Tipo.Assassin) { efectividad = 2; }
                    if(defensor == Datos.Tipo.Rider) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Assassin: 
                    if(defensor == Datos.Tipo.Rider) { efectividad = 2; }
                    if(defensor == Datos.Tipo.Caster) { efectividad = 0.5; }
                break;
                case Datos.Tipo.Berserker: 
                    efectividad = 1.5;
                break;
            }
            if(defensor == Datos.Tipo.Berserker && atacante != Datos.Tipo.Berserker)
            { 
                efectividad = 2; 
            }
            return efectividad;
        }
    }
}