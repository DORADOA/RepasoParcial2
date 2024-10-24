using TiendaVideojuegos.Enums;

namespace TiendaVideojuegos.Models
{
    public class Juego
    {
            public string Nombre { get; set; }
            public int Stock { get; set; }
            public double Precio { get; set; }
            public TipoPlataforma Plataforma { get; set; }

            public Juego(string nombre, int stock, double precio, TipoPlataforma plataforma)
            {
                Nombre = nombre;
                Stock = stock;
                Precio = precio;
                Plataforma = plataforma;
            }

            public override string ToString()
            {
                return $"Nombre: {Nombre}, Cantidad en Stock: {Stock}, Precio: {Precio}";
            }
        
    }
}

