namespace Personajes
{
    public class FabricaDePersonajes
    {
        private Datos Datos = new Datos();
        private caracteristicas caracteristicas = new caracteristicas();
        public Datos CharaInfo {get => Datos; set => Datos = value;}
        public caracteristicas CharaStats {get => caracteristicas;  set => caracteristicas = value;}
        public void CrearPersonaje(FabricaDePersonajes personaje)
        {
            Random rnd = new Random();
            CharaInfo = personaje.CharaInfo;
            CharaStats = personaje.CharaStats;
            switch(CharaInfo.intAfinidad)
            {
                case 0: CharaInfo.affinity = Datos.Tipo.Saber; break;
                case 1: CharaInfo.affinity = Datos.Tipo.Archer; break;
                case 2: CharaInfo.affinity = Datos.Tipo.Lancer; break;
                case 3: CharaInfo.affinity = Datos.Tipo.Rider; break;
                case 4: CharaInfo.affinity = Datos.Tipo.Caster; break;
                case 5: CharaInfo.affinity = Datos.Tipo.Assassin; break;
                case 6: CharaInfo.affinity = Datos.Tipo.Berserker; break;
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