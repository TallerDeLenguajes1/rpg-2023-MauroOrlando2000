namespace Personajes;

public class caracteristicas
{
    private double velocidad;
    private double agilidad;
    private double fuerza;
    private double armadura;
    private double nivel;
    private double salud;

    public double speed { get => velocidad; set => velocidad = value; }
    public double agility { get => agilidad; set => agilidad = value; }
    public double attack { get => fuerza; set => fuerza = value; }
    public double armor { get => armadura; set => armadura = value; }
    public double level { get => nivel; set => nivel = value; }
    public double HP { get => salud; set => salud = value; }
}