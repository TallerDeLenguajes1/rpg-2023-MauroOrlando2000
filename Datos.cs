namespace Personajes;

public class Datos
{
    public enum Tipo {Saber, Archer, Lancer, Rider, Caster, Assassin, Berserker}
    private Tipo afinidad;
    private string? Nombre;
    private string? Apodo;
    private DateTime Nacimiento;
    private int Edad;

    public Tipo affinity { get => afinidad; set => afinidad = value; }
    public string Name { get => Nombre; set => Nombre = value; }
    public string Alias { get => Apodo; set => Apodo = value; }
    public DateTime Birth { get => Nacimiento; set => Nacimiento = value; }
    public int Age { get => Edad; set => Edad = value; }
    public int intAfinidad {get; set;}
}