using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.DG
{
    public class Etiquetas
    {
        private short etiqueta;
        private string valor;

        public Etiquetas()
        {
        }

        public Etiquetas(short Etiqueta, string Valor)
        {
            etiqueta = Etiqueta;
            valor = Valor;
        }

        public short Etiqueta
        {
            get
            {
                return etiqueta;
            }
            set
            {
                etiqueta = value;
            }
        }

        public string Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }
    }
}