using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
     public abstract class LiquidacionCuotaModeradora
    {
        public string NumeroDeLiquidacion { get; set; }
        public string IdentificacionDePaciente { get; set; }
        public string TipoDeAfiliacion { get; set; }
        public decimal SalarioDeVengado { get; set; }
        public decimal ValorDelServicio { get; set; }
        public decimal Tarifa { get; set; }
        public decimal TopeMaximo { get; set; }
        public decimal CuotaModeradora { get; set; }
        public abstract void CalcularCuotaModeradora();
        public override string ToString()
        {
            return $"{NumeroDeLiquidacion};{IdentificacionDePaciente};{TipoDeAfiliacion};{SalarioDeVengado};{ValorDelServicio};{Tarifa};{TopeMaximo};{CuotaModeradora}";
        }
    }
}
