using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.IO;
namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {
       
        private List<LiquidacionCuotaModeradora> liquidaciones;
        public LiquidacionCuotaModeradoraRepository()
        {
            liquidaciones = new List<LiquidacionCuotaModeradora>();
        }
        private readonly string fileName = @"Liquidacion.txt";

        public void Guardar(LiquidacionCuotaModeradora liquidacionCuotaModeradora)
        {
            FileStream file = new FileStream(fileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(liquidacionCuotaModeradora.ToString());
            writer.Close();
            file.Close();
        }
        public LiquidacionCuotaModeradora Buscar(string numeroLiquidacion)
        {
             liquidaciones = Consultar();
            foreach (var item in liquidaciones)
            {
                if (Encontrado(item.NumeroDeLiquidacion, numeroLiquidacion))
                {
                    return item;
                }
            }
            return null;
        }
        private bool Encontrado(string idPacienteRegistrado, string idPacienteBuscado)
        {
            return idPacienteRegistrado == idPacienteBuscado;

        }
        public List<LiquidacionCuotaModeradora> Consultar()
        {
            
            FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {
                LiquidacionCuotaModeradora liquidacionCuotaModeradora = Mapear(linea);
                liquidaciones.Add(liquidacionCuotaModeradora);
            }
            reader.Close();
            file.Close();
            return liquidaciones;

        }
        private LiquidacionCuotaModeradora Mapear(string linea)
        {
            LiquidacionCuotaModeradora liquidacionCuotaModeradora;
            char token = ';';
            string[] VectorLiquidacion = linea.Split(token);

            if (VectorLiquidacion[2] == "C"  )
            {
                liquidacionCuotaModeradora = new Contributivo();

            }

            else
            {

                liquidacionCuotaModeradora = new Subsidiado();
            }
                 liquidacionCuotaModeradora.NumeroDeLiquidacion = VectorLiquidacion[0];
                liquidacionCuotaModeradora.IdentificacionDePaciente = VectorLiquidacion[1];
                liquidacionCuotaModeradora.TipoDeAfiliacion = VectorLiquidacion[2];
                liquidacionCuotaModeradora.SalarioDeVengado = decimal.Parse(VectorLiquidacion[3]);
                liquidacionCuotaModeradora.ValorDelServicio = decimal.Parse(VectorLiquidacion[4]);
                liquidacionCuotaModeradora.Tarifa = decimal.Parse(VectorLiquidacion[5]);
                liquidacionCuotaModeradora.TopeMaximo = decimal.Parse(VectorLiquidacion[6]);
                liquidacionCuotaModeradora.CuotaModeradora = decimal.Parse(VectorLiquidacion[7]);
            return liquidacionCuotaModeradora;
        }

        public void Eliminar(String idPaciente)
        {
           
            liquidaciones = Consultar();
            FileStream file = new FileStream(fileName, FileMode.Create);
            file.Close();
            foreach (var item in liquidaciones)
            {
                if (!Encontrado(item.IdentificacionDePaciente, idPaciente))
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar(LiquidacionCuotaModeradora liquidacionAnterior, LiquidacionCuotaModeradora liquidacionNueva)
        {
           
            liquidaciones = Consultar();
            FileStream file = new FileStream(fileName, FileMode.Create);
            file.Close();
            foreach (var item in liquidaciones)
            {
                if (!Encontrado(item.IdentificacionDePaciente, liquidacionAnterior.IdentificacionDePaciente))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(liquidacionNueva);
                }
            }
        }




    }
}
