namespace Personajes
{
    public class FabricaDePersonajes
    {
        public void CrearPersonaje()
        {
            Datos DNuevo = new Datos();
            Random rnd = new Random();
            string[] Nombres = {"Phil","Siegfried"};
            int azar = rnd.Next(7);
            switch(azar)
            {
                case 0: DNuevo.affinity = Datos.Tipo.Saber; break;
                case 1: DNuevo.affinity = Datos.Tipo.Archer; break;
                case 2: DNuevo.affinity = Datos.Tipo.Lancer; break;
                case 3: DNuevo.affinity = Datos.Tipo.Rider; break;
                case 4: DNuevo.affinity = Datos.Tipo.Caster; break;
                case 5: DNuevo.affinity = Datos.Tipo.Assassin; break;
                case 6: DNuevo.affinity = Datos.Tipo.Berserker; break;
            }
            azar = rnd.Next(2);
            DNuevo.Name = Nombres[azar];
            DateTime MaximaEdad = new DateTime(1980, 1, 1), Aux; 
            int range = (new DateTime(2001, 1, 1) - MaximaEdad).Days;
            DNuevo.Birth = Aux = MaximaEdad.AddDays(rnd.Next(range));
            DNuevo.Age = new DateTime(0, 0, 0);
            while(Aux < DateTime.Today)
            {
                Aux.AddDays(1);
                DNuevo.Age.AddDays(1);
            }

            caracteristicas CNuevo = new caracteristicas();
            switch(DNuevo.affinity)
            {
                case 0: CNuevo.speed = rnd.Next(8,12);
                        CNuevo.agility = rnd.Next(5,9);
                        CNuevo.attack = rnd.Next(8,12);
                        CNuevo.armor = rnd.Next(8,12);
                        CNuevo.level = rnd.Next(10,20);
                        CNuevo.HP = 100;
                break;
            }
        }
    }
}