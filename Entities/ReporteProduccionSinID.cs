using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaKPI_API.Entities
{
    public class ReporteProduccionSinID
    {
        //CODIGO NUEVO,PRESENTACION,DIA,MES,AÑO ,SEMANA,FAMILIA,CAPACIDAD,CLIENTE,MAQUINA,TOTAL DE CAVIDADES,
        //CANTIDAD BOLSAS,PIEZAS POR BOLSA,CANTIDAD PIEZAS,
        [Index(0)]
        public string CodigoNuevo { get; set; }
        [Index(1)]
        public string Presentacion { get; set; }
        [Index(2)]
        public string Dia { get; set; }
        [Index(3)]
        public string Mes { get; set; }
        [Index(4)]
        public string Anho { get; set; }
        [Index(5)]
        public string Semana { get; set; }
        [Index(6)]
        public string Familia { get; set; }
        [Index(7)]
        public string Capacidad { get; set; }
        [Index(8)]
        public string Cliente { get; set; }
        [Index(9)]
        public string Maquina { get; set; }
        [Index(10)]
        public string TotalDeCavidades { get; set; }
        [Index(11)]
        public string CantidadBolsas { get; set; }
        //PESO DE ENVASE gr,PESO DE ETIQUETA gr,PESO DE LAS BOLSAS gr,PESO TOTAL INDIVIDUAL gr,
        //PESO TOTAL KG,COSTO RESINA POR c/gr (MN),IMPORTE SCRAP DE RESINA (MN),IMPORTE TOTAL RESINA (MN),
        //IMPORTE TOTAL DE ETIQUETAS (MN),IMPORTE TOTAL DE  BOLSAS (MN) ,IMPORTE DE MANO DE OBRA INDIRECTA (MN),
        //IMPORTE TOTAL DE PRODUCCION (MN) ,COSTO PRIMO / PIEZA,OPERADOR,
        [Index(12)]
        public string PiezasXBolza { get; set; }
        [Index(13)]
        public string CantidadPiezas { get; set; }
        [Index(14)]
        public string PesoEnvaseGr { get; set; }
        [Index(15)]
        public string PesoEtiquetaGr { get; set; }
        [Index(16)]
        public string PesoBolsaGr { get; set; }
        [Index(17)]
        public string PesoTotalIndividualGr { get; set; }
        [Index(18)]
        public string PesoTotalKg { get; set; }
        [Index(19)]
        public string CostoResinaCGr { get; set; }
        [Index(20)]
        public string ImporteScrapResina { get; set; }
        [Index(21)]
        public string ImporteTotalResina { get; set; }
        [Index(22)]
        public string ImporteTotalEtiquetas { get; set; }
        [Index(23)]
        public string ImporteTotalBolsas { get; set; }
        [Index(24)]
        public string ImporteManoDeObraIndirecta { get; set; }
        [Index(25)]
        public string ImporteTotalProduccion { get; set; }
        [Index(26)]
        public string CostoPrimoXPieza { get; set; }
        //TURNO,SUPERVISOR,HR USADAS, MINUTOS USADOS,
        //TIEMPO DECIMAL,SCRAP ETIQUETA,SCRAP BOLSA,SCRAP POLETILENO gr, POLETILENO , PRODUCCION ESPERADA pza ,EFICIENCIA %,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,
        [Index(27)]
        public string Operador { get; set; }
        [Index(28)]
        public string Turno { get; set; }
        [Index(29)]
        public string Supervisor { get; set; }
        [Index(30)]
        public string HRUsadas { get; set; }
        [Index(31)]
        public string MinutosUsados { get; set; }
        [Index(32)]
        public string TiempoDecimal { get; set; }
        [Index(33)]
        public string ScrapEtiqueta { get; set; }
        [Index(34)]
        public string ScrapBolsa { get; set; }
        [Index(35)]
        public string ScrapPolietilenoGr { get; set; }
        [Index(36)]
        public string Poletileno { get; set; }
        [Index(37)]
        public string ProduccionEsperadaPza { get; set; }
        [Index(38)]
        public string Eficiencia { get; set; }
    }
}
