using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BLL;
using System.Security.Cryptography.X509Certificates;

namespace IPSMasSaludYVida
{
    class Program
    {
        static void Main(string[] args)
        {
            LiquidacionCuotaModeradoraService service = new LiquidacionCuotaModeradoraService();
            string numeroLiquidacion;
            string idPaciente;
            string tipoAfiliacion;
            decimal salarioPaciente;
            decimal valorServicio;
           

            Console.WriteLine("Digite numero de liquidacion:");
            numeroLiquidacion = Console.ReadLine();
            Console.WriteLine("Digite su identificacion:");
            idPaciente = Console.ReadLine();
            Console.WriteLine("Digite tipo de afiliación: S=> para regimen Subsidiado y C=>Contribitivo");
            tipoAfiliacion = Console.ReadLine();
            Console.WriteLine("Digite su salario devengado:");
            salarioPaciente = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Digite el valor del servicio prestado");
            valorServicio = decimal.Parse(Console.ReadLine());
           

            if (tipoAfiliacion == "C" || tipoAfiliacion == "c")
            {
                LiquidacionCuotaModeradora liquidacion = new Contributivo()
                {
                    NumeroDeLiquidacion = numeroLiquidacion,
                    IdentificacionDePaciente = idPaciente,
                    TipoDeAfiliacion = tipoAfiliacion,
                    SalarioDeVengado = salarioPaciente,
                    ValorDelServicio = valorServicio

                };
                liquidacion.CalcularCuotaModeradora();
                string message = service.Guardar(liquidacion);
                Console.WriteLine(message);
                

            }
       
            if (tipoAfiliacion == "S" || tipoAfiliacion == "s")
            
            {
                LiquidacionCuotaModeradora liquidacion = new Subsidiado()
                {
                    NumeroDeLiquidacion = numeroLiquidacion,
                    IdentificacionDePaciente = idPaciente,
                    TipoDeAfiliacion = tipoAfiliacion,
                    SalarioDeVengado = salarioPaciente,
                    ValorDelServicio = valorServicio
                };
                liquidacion.CalcularCuotaModeradora();
                service.Guardar(liquidacion);
            }

           
            Console.ReadKey();

        }

            
    }
}
