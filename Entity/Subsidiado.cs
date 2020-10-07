using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Subsidiado : LiquidacionCuotaModeradora
    {
        public override void CalcularCuotaModeradora()
        {
            CuotaModeradora = ValorDelServicio * (5 / 100);
            if (CuotaModeradora > 200000)
            {
                TopeMaximo = 200000;
            }
            else
            {
                TopeMaximo = CuotaModeradora;
            }
        }

       
    }
}
