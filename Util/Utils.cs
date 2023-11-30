using CRUD_MVC.Models;

namespace CRUD_MVC.Util
{
    public class Utils
    {
        public static List<Producto> ListaProducto = new List<Producto>()
        {
            new Producto
                {
                    IdProducto=1,
                    Nombre = "A Court of Thorns and Roses",
                    Descripcion= "Cuando la cazadora de diecinueve años de edad, Feyre, mata a un lobo el el bosque, una criatura parecida a una bestia llega para exigir venganza. Arrastrada a una traicionera tierra mágica que solo conoce de leyendas, Feyre descubre que su captor no es un animal, sino Tamlin, una de las letales e inmortales hadas que una vez gobernaron su mundo.\nA medida que ella vive en su estado, sus sentimientos por Tamlin se transforman de una hostilidad helada a una pasión que quema a pesar de todas las mentiras y las advertencias que se le han hecho sobre el hermoso y peligroso mundo de las hadas. Pero una antigua y malvada sombre crece sobre las tierras feéricas, y Feyre debe encontrar la manera de detenerla... o condenará a Tamlin, y su mundo, para siempre.",
                    Cantidad=20,
                    Autor="Sarah J. Maas",
                    Costo=19.50,
                    Genero="Fantasia"
                },

                new Producto
                {
                    IdProducto = 2,
                    Nombre = "A Court of Mist and Fury",
                    Descripcion = "Tras haber superado más pruebas de lo que un corazón humano puede soportar, Feyre regresa a la Corte Primavera con los poderes de una alta fae. Sin embargo, no consigue olvidar los crímenes que debió cometer para salvar a Tamlin y a su pueblo, ni el perverso pacto que cerró con Rhysand, el alto lord de la temible Corte Noche. \\nMientras Feyre es arrastrada hacia el interior de la oscura red política y pasional de Rhysand, una guerra inminente acecha y un mal mucho más peligroso que cualquier reina amenaza con destruir todo lo que Feyre alguna vez intentó proteger. Ella podría ser la clave para detenerlo, pero solo si consigue dominar sus nuevos dones, sanar su alma partida en dos y decidir su futuro y el de todo un mundo en crisis. \\nLa autora número uno en ventas en The New York Times y USA Today, Sarah J. Maas, lleva esta saga más que adictiva a un nivel impensado.\",",
                    Cantidad = 20,
                    Autor = "Sarah J. Maas",
                    Costo=19.50,
                    Genero="Fantasia"

                },
                new Producto
                {
                    IdProducto = 3,
                    Nombre = "A Court of Wings And Ruin",
                    Descripcion = "Feyre regresa a la Corte Primavera, decidida a reunir información sobre los planes de Tamlin y del rey invasor que amenaza con destruir Prythian. Para esto deberá someterse a un letal y peligroso juego de engaño, en el que un simple error podría condenar no solo a Feyre, sino también a todo el mundo a su alrededor.\\nA medida que la guerra avanza sin tregua, Feyre deberá posicionarse como una alta fae y luchar por dominar sus dones mágicos; tendrá que determinar en cuáles de los deslumbrantes altos lores puede confiar y salir a buscar aliados en los lugares más inesperados.\\nEn este apasionante tercer volumen de la serie de Una corte de rosas y espinas de la exitosísima autora Sarah J. Maas, la tierra se teñirá de rojo mientras majestuosos ejércitos luchan por apoderarse del único objeto que podría destruirlos a todos. \",",
                    Cantidad = 20,
                    Autor = "Sarah J. Maas",
                    Costo=19.50,
                    Genero="Fantasia"
                }
        };
        public static List<Vendedor> ListaVendedor = new List<Vendedor>()
        {
            new Vendedor
               {
                   Cedula=1600014789,
                   Nombres="Silvia Rosa",
                   Apellidos="Coronel Tapia",
                   CantidadVentas=0,
                   EsActivo="Si"
               },
               new Vendedor
               {
                   Cedula = 1726884552,
                   Nombres = "Alejandra Ivonne",
                   Apellidos = "Tapia Ortega",
                   CantidadVentas = 100,
                   EsActivo = "No"
               }
        };
    }
}
