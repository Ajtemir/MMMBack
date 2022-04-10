using System;

namespace MegaMarketMall.TestData
{
    public class WeatherForecast
    {
        public static readonly string Salt =
            "0x48003F78417BF98DC9979CCF002CDF26BE61CE33953D7E800B74B5C49BA8D5E796CA127E1BB1B027E9A16366519F293B56914F4B5ECFD69B899623F56D3FDC19787B36A974444E875C67AB50FE41FE20F2C9D8C1328E79899EA288A680A2DC27A0A30355106767A87E80A659093FF457DFE17E07DF8D30B8A406F2AB1682F72A";

        public static readonly string Hash = "0x1C57A70DD86E40390035281239B9027D61EED6F303EB53CAA2484C050CC53BC812A6E551274DDE40810F2B473624CEA1EF6BBA9A0D4F2D6BDBB6FBFF279A56FF";
        public static readonly string Password = "Qwerty-2001";
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
/*
   public enum Mechanism 
    {
         Quartz=1,
         Kinetic,
         Mechanical,
         Electronic
    }

    public enum Gender
    {
        Child=1,
        Women,
        Men,
        Unisex
    }

    public enum Type
    {
        Smart=1,
        Army,
        Classic,
        Sport
    }
    
    public enum Type
    {
        OuterBlock,
        InnerBlock,
        MonoBlock,
        MultiSplitSystem,
        SplitSystem
    }

    public enum MountingTheIndoorUnit
    {
        Mobile,
        Ceil
    }

    public enum TypeCompressor
    {
        Inverter,
        Classic
    }
    
    
    
    public enum TypeOfDownload
        {
            Vertical=1,
            Frontal
        }

        public enum Type
        {
            Automatic=1,
            SemiAutomatic
        }
        
        public enum Size
        {
            FullSize=1,
            Narrow
        }
 */

/*
 * null != string.Empty
 * "" == string.Empty
 * [Required] == not null
 * [Required] != "" 
 * [Required] == ""
 * null! == null
 */


// [Required] public int SellerId { get; set; }
// [Required] public int CategoryId { get; set; }
// public bool IsNew { get; set; } = true;
// public string Description { get; set; } = null; // null отсуствует описание
// public uint? Price { get; set; } = null; // null договорная
// public bool? IsDelivered { get; set; } = null; //TODO => подумать об доставке null=самовызов true=беслатная false=платная

//TODO LIST
//TODO change password
//guid
//set role

