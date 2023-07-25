namespace Personajes
{
    public class FabricaDePersonajes
    {
        private Datos Datos = new Datos();
        private caracteristicas caracteristicas = new caracteristicas();
        public Datos CharaInfo {get => Datos; set => Datos = value;}
        public caracteristicas CharaStats {get => caracteristicas;  set => caracteristicas = value;}
        public void CrearPersonajeOnline(FabricaDePersonajes personaje)
        {
            CharaInfo = personaje.CharaInfo;
            CharaStats = personaje.CharaStats;
            switch(CharaInfo.intAfinidad)
            {
                case 0: CharaInfo.affinity = Datos.Tipo.Saber; break;
                case 1: CharaInfo.affinity = Datos.Tipo.Lancer; break;
                case 2: CharaInfo.affinity = Datos.Tipo.Archer; break;
                case 3: CharaInfo.affinity = Datos.Tipo.Rider; break;
                case 4: CharaInfo.affinity = Datos.Tipo.Caster; break;
                case 5: CharaInfo.affinity = Datos.Tipo.Assassin; break;
                case 6: CharaInfo.affinity = Datos.Tipo.Berserker; break;
            }

        }

        public void CrearPersonajeOffline()
        {
            Random rnd = new Random();
            string[] Nombres = {"Tristan","Arthur","Gawain","Lancelot","Agravain","Kay","Mordred","Gareth","Galahad","Perceval"};
            string[] Apodos = {"El barbudo","El bárbaro","El noble","El imparable", "El gigante", "El impalador"};
            int intNum = rnd.Next(7);
            switch(intNum)
            {
                case 0: CharaInfo.affinity = Datos.Tipo.Saber; break;
                case 1: CharaInfo.affinity = Datos.Tipo.Lancer; break;
                case 2: CharaInfo.affinity = Datos.Tipo.Archer; break;
                case 3: CharaInfo.affinity = Datos.Tipo.Rider; break;
                case 4: CharaInfo.affinity = Datos.Tipo.Caster; break;
                case 5: CharaInfo.affinity = Datos.Tipo.Assassin; break;
                case 6: CharaInfo.affinity = Datos.Tipo.Berserker; break;
            }
            intNum = rnd.Next(10);
            CharaInfo.Name = Nombres[intNum];
            intNum = rnd.Next(6);
            CharaInfo.Alias = Apodos[intNum];
            DateTime start = new DateTime(1980, 1, 1), end = new DateTime(2003, 1, 1);
            int range = (end - start).Days;
            CharaInfo.Birth = start.AddDays(rnd.Next(range));
            CharaInfo.Age = calcularEdad(CharaInfo.Birth);

            CharaStats.level = rnd.Next(1,11);
            switch(CharaInfo.affinity)
            {
                case Datos.Tipo.Saber: CharaStats.speed = rnd.Next(8,12);
                CharaStats.agility = rnd.Next(6,12);
                CharaStats.attack = rnd.Next(8,12);
                CharaStats.armor = rnd.Next(9,13);
                break;

                case Datos.Tipo.Lancer: CharaStats.speed = rnd.Next(10,14);
                CharaStats.agility = rnd.Next(8,14);
                CharaStats.attack = rnd.Next(7,11);
                CharaStats.armor = rnd.Next(8,13);
                break;

                case Datos.Tipo.Archer: CharaStats.speed = rnd.Next(9,13);
                CharaStats.agility = rnd.Next(2,11);
                CharaStats.attack = rnd.Next(7,12);
                CharaStats.armor = rnd.Next(8,13);
                break;

                case Datos.Tipo.Rider: CharaStats.speed = rnd.Next(8,12);
                CharaStats.agility = rnd.Next(7,12);
                CharaStats.attack = rnd.Next(8,12);
                CharaStats.armor = rnd.Next(9,13);
                break;

                case Datos.Tipo.Caster: CharaStats.speed = rnd.Next(6,10);
                CharaStats.agility = rnd.Next(5,11);
                CharaStats.attack = rnd.Next(7,11);
                CharaStats.armor = rnd.Next(8,13);
                break;

                case Datos.Tipo.Assassin: CharaStats.speed = rnd.Next(11,16);
                CharaStats.agility = rnd.Next(11,16);
                CharaStats.attack = rnd.Next(7,11);
                CharaStats.armor = rnd.Next(5,9);
                break;

                case Datos.Tipo.Berserker: CharaStats.speed = rnd.Next(5,10);
                CharaStats.agility = rnd.Next(1,7);
                CharaStats.attack = rnd.Next(11,16);
                CharaStats.armor = rnd.Next(11,16);
                break;
            }
            if(CharaInfo.affinity == Datos.Tipo.Berserker)
            {
                CharaStats.HP = 125;
            }
            else
            {
                CharaStats.HP = 100;
            }
        }

        public void mostrarPersonaje()
        {
            Console.WriteLine("DATOS");
            Console.WriteLine($"Nombre/Apodo: {CharaInfo.Name}, {CharaInfo.Alias}");
            Console.WriteLine($"Fecha de Nacimiento: {CharaInfo.Birth.Day}/{CharaInfo.Birth.Month}/{CharaInfo.Birth.Year} - {CharaInfo.Age} años");
            Console.WriteLine("Clase: " + CharaInfo.affinity);
            Console.WriteLine("\nESTADISTICAS");
            Console.WriteLine("Nivel: " + CharaStats.level);
            Console.WriteLine("Ataque: " + CharaStats.attack);
            Console.WriteLine("Defensa: " + CharaStats.armor);
            Console.WriteLine("Velocidad: " + CharaStats.speed);
            Console.WriteLine("Agilidad: " + CharaStats.agility);
            Console.WriteLine("Vida: " + CharaStats.HP);
        }

        public int calcularEdad(DateTime nacimiento)
        {
            int anio = DateTime.Today.Year - nacimiento.Year;
            int mes = DateTime.Today.Month - nacimiento.Month;
            if(mes < 0) 
            { 
                anio -= 1; 
                mes += 12; 
            }
            int dia = DateTime.Today.Day - nacimiento.Day;
            if(dia < 0)
            {
                mes -= 1;
                if(mes < 0)
                {
                    anio -= 1;
                    mes += 12;
                }
                dia += 30; 
            }
            return anio;
        }
    }
}