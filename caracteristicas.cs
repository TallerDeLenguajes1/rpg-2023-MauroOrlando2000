namespace Personajes;

public class caracteristicas
{
    private double velocidad;
    private int agilidad;
    private double fuerza;
    private double armadura;
    private double nivel;
    private double salud;

    public double speed { get => velocidad; set => velocidad = value; }
    public int agility { get => agilidad; set => agilidad = value; }
    public double attack { get => fuerza; set => fuerza = value; }
    public double armor { get => armadura; set => armadura = value; }
    public double level { get => nivel; set => nivel = value; }
    public double HP { get => salud; set => salud = value; }
    public int Aux { get; set; }
    public bool skill { get; set; }
}