using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Contributivo : LiquidacionCuotaModeradora
    {
       const decimal SalarioMinimo=900000;

        public override void CalcularCuotaModeradora()
        {
            if (SalarioDeVengado < (2 * SalarioMinimo))
            {
                Tarifa = 15 / 100;
                TopeMaximo = 250000;
                CuotaModeradora = ValorDelServicio * Tarifa;
                if (CuotaModeradora > TopeMaximo)
                {
                    TopeMaximo = 250000;
                }
                else
                {
                    TopeMaximo = CuotaModeradora;
                }
            }
            if (SalarioDeVengado >= (2 * SalarioMinimo) && SalarioDeVengado <= (5 * SalarioMinimo))
            {
                Tarifa = 20 / 100;
                TopeMaximo = 900000;
                CuotaModeradora = ValorDelServicio * Tarifa;
                if (CuotaModeradora > TopeMaximo)
                {
                    TopeMaximo = 900000;
                }
                else
                {
                    TopeMaximo = CuotaModeradora;
                }
            }
            if (SalarioDeVengado > (5 * SalarioMinimo))
            {
                Tarifa = 25 / 100;
                TopeMaximo = 1500000;
                CuotaModeradora = ValorDelServicio * Tarifa;
                if (CuotaModeradora > TopeMaximo)
                {
                    TopeMaximo = 1500000;
                }
                else
                {
                    TopeMaximo = CuotaModeradora;
                }
            }

            
        }
       
        
	

	}


    
}
