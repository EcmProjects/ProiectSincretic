using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProiectSincretic.Models;

public partial class Product
{

    [PrimaryKey]
    public string Id {get;set;}
    public string Denumire { get; set; }
    public string Descriere { get; set; }
    public decimal Pret { get; set; }
    public decimal CotaTva { get; set; }

}
