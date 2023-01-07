using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ProiectSincretic.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProiectSincretic
{
    public partial class MainPageViewModel:ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> list = new ObservableCollection<string>();
        [ObservableProperty]
        bool isBussy = false;
        DatabaseService service = null;


        [RelayCommand]
        async void StartTest()
        {
            if (IsBussy) { return; }
            IsBussy=true;
            try
            {
                await Task.Run(async() => {
                  

                    if (List.Count>0) { List.Clear(); }

                    //identificam daca exista bazele de date
                    string p1 = Path.Combine(AppSettings.MainFolder, AppSettings.DB1000);
                    string p2 = Path.Combine(AppSettings.MainFolder, AppSettings.DB10000);
                    string p3 = Path.Combine(AppSettings.MainFolder, AppSettings.DB100000);

                    string p4 = Path.Combine(AppSettings.MainFolder, AppSettings.DBnr1000);
                    string p5 = Path.Combine(AppSettings.MainFolder, AppSettings.DBnr10000);
                    string p6 = Path.Combine(AppSettings.MainFolder, AppSettings.DBnr100000);

                    string p7 = Path.Combine(AppSettings.MainFolder, AppSettings.DBhibrid1000);
                    string p8 = Path.Combine(AppSettings.MainFolder, AppSettings.DBhibrid10000);
                    string p9 = Path.Combine(AppSettings.MainFolder, AppSettings.DBhibrid100000);

                    if (File.Exists(p1)) { File.Delete(p1); }
                    if (File.Exists(p2)) { File.Delete(p2); }
                    if (File.Exists(p3)) { File.Delete(p3); }
                    if (File.Exists(p4)) { File.Delete(p4); }
                    if (File.Exists(p5)) { File.Delete(p5); }
                    if (File.Exists(p6)) { File.Delete(p6); }
                    if (File.Exists(p7)) { File.Delete(p7); }
                    if (File.Exists(p8)) { File.Delete(p8); }
                    if (File.Exists(p9)) { File.Delete(p9); }



                    List.Add($"Insert 1000 produese db traditional = {InsertDb1000(p1)} s");
                    List.Add($"Insert 10000 produese db traditional = {InsertDb10000(p2)} s");
                    List.Add($"Insert 100000 produese db traditional = {InsertDb100000(p3)} s");

                    if (File.Exists(p1)) { File.Delete(p1); }
                    if (File.Exists(p2)) { File.Delete(p2); }
                    if (File.Exists(p3)) { File.Delete(p3); }

                    List.Add($"InsertAll 1000 produese db traditional = {InsertAllDb1000(p1)} s");
                    List.Add($"InsertAll 10000 produese db traditional = {InsertAllDb10000(p2)} s");
                    List.Add($"InsertAll 100000 produese db traditional = {InsertAllDb100000(p3)} s");

                    List.Add($"Read 1000 produese db traditional = {ReadDb1000(p1)} s");
                    List.Add($"Read 10000 produese db traditional = {ReadDb10000(p2)} s");
                    List.Add($"Read 100000 produese db traditional = {ReadDb100000(p3)} s");

                    List.Add($"ReadAll 1000 produese db traditional = {ReadAllDb1000(p1)} s");
                    List.Add($"ReadAll 10000 produese db traditional = {ReadAllDb10000(p2)} s");
                    List.Add($"ReadAll 100000 produese db traditional = {ReadAllDb100000(p3)} s");


                    List.Add($"Insert 1000 produese db Hibrid = {InsertDbhybrid1000(p7)} s");
                    List.Add($"Insert 10000 produese db Hibrid = {InsertDbhybrid10000(p8)} s");
                    List.Add($"Insert 100000 produese db Hibrid = {InsertDbhybrid100000(p9)} s");

                    if (File.Exists(p7)) { File.Delete(p7); }
                    if (File.Exists(p8)) { File.Delete(p8); }
                    if (File.Exists(p9)) { File.Delete(p9); }

                    List.Add($"InsertAll 1000 produese db Hibrid = {InsertAllDbhybrid1000(p7)} s");
                    List.Add($"InsertAll 10000 produese db Hibrid = {InsertAllDbhybrid10000(p8)} s");
                    List.Add($"InsertAll 100000 produese db Hibrid = {InsertAllDbhybrid100000(p9)} s");


                    List.Add($"Read 1000 produese db hybrid = {ReadhybridDb1000(p7)} s");
                    List.Add($"Read 10000 produese db hybrid = {ReadhybridDb10000(p8)} s");
                    List.Add($"Read 100000 produese db hybrid = {ReadhybridDb100000(p9)} s");

                    List.Add($"ReadAll 1000 produese db hybrid = {ReadAllHybridDb1000(p7)} s");
                    List.Add($"ReadAll 10000 produese db hybrid = {ReadAllHybridDb10000(p8)} s");
                    List.Add($"ReadAll 100000 produese db hybrid = {ReadAllHybridDb100000(p9)} s");


                    if (File.Exists(p4)) { File.Delete(p4); }
                    if (File.Exists(p5)) { File.Delete(p5); }
                    if (File.Exists(p6)) { File.Delete(p6); }

                    double i1000 = InsertNrDb1000(p4);
                    double i10000 = InsertNrDb10000(p5);
                    double i100000 = InsertNrDb100000(p6);

                    List.Add($"Insert 1000 produese db nonrelational = {i1000.ToString("0.00")} s");
                    List.Add($"Insert 10000 produese db nonrelational = {i10000.ToString("0.00")} s");
                    List.Add($"Insert 100000 produese db nonrelational = {i100000.ToString("0.00")} s");

                    List.Add($"Read 1000 produese db nonrelational = {ReadNrDb1000(p4).ToString("0.00")} s");
                    List.Add($"Read 10000 produese db nonrelational = {ReadNrDb10000(p5).ToString("0.00")} s");
                    List.Add($"Read 100000 produese db nonrelational = {ReadNrDb100000(p6).ToString("0.00")} s");

                    if (File.Exists(p4)) { File.Delete(p4); }
                    if (File.Exists(p5)) { File.Delete(p5); }
                    if (File.Exists(p6)) { File.Delete(p6); }

                    double ia1000 = InsertAllNrDb1000(p4);
                    double ia10000 = InsertAllNrDb10000(p5);
                    double ia100000 = InsertAllNrDb100000(p6);


                    List.Add($"InsertAll 1000 produese db nonrelational = {ia1000.ToString("0.00")} s");
                    List.Add($"InsertAll 10000 produese db nonrelational = {ia10000.ToString("0.00")} s");
                    List.Add($"InsertAll 100000 produese db nonrelational = {ia100000.ToString("0.00")} s");

                    double ra1000 = ReadAllNrDb1000(p4);
                    double ra10000 = ReadAllNrDb10000(p5);
                    double ra100000 = ReadAllNrDb100000(p6);

                    List.Add($"ReadAll 1000 produese db nonrelational = {ra1000.ToString("0.00")} s");
                    List.Add($"ReadAll 10000 produese db nonrelational = {ra10000.ToString("0.00")} s");
                    List.Add($"ReadAll 100000 produese db nonrelational = {ra100000.ToString("0.00")} s");

                   
           

                });
                

              



            }
            catch ( Exception ex)
            {
                ;
            }
            finally { IsBussy = false; }
        }


        private double InsertDb1000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 1001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = i.ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            foreach (Product p in products)
            {
                service.Inser(p) ;
                
            }

            timer.Stop();

           return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertDb10000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 10001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = i.ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            foreach (Product p in products)
            {
                service.Inser(p);

            }

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertDb100000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 100001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = i.ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            foreach (Product p in products)
            {
                service.Inser(p);

            }

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }

        private double InsertAllDb1000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 1001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = i.ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            service.BulkInser(products);

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertAllDb10000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 10001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = i.ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            service.BulkInser(products);

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertAllDb100000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 100001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = i.ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            service.BulkInser(products);
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }

        private double InsertDbhybrid1000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<LiteTable> products = new List<LiteTable>();
            for (int i = 1; i < 1001; i++)
            {
                Product p = new Product()
                {
                    Id = i.ToString(),
                    CotaTva = 0.19m,
                    Denumire = $"Produs Tset {i}",
                    Descriere = $"Descriere Produs Test {i}",
                    Pret = 0.00m + i
                };
                products.Add(
                    new LiteTable()
                    {
                        IdObject = p.Id,
                        ObjectSource=JsonConvert.SerializeObject(p) ,
                        ObjectType=1,
                        RecordId=p.Id
                    }
                  

                    );

            }


            timer.Start();
            foreach (LiteTable p in products)
            {
                service.Inser(p);

            }

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertDbhybrid10000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<LiteTable> products = new List<LiteTable>();
            for (int i = 1; i < 10001; i++)
            {
                Product p = new Product()
                {
                    Id = i.ToString(),
                    CotaTva = 0.19m,
                    Denumire = $"Produs Tset {i}",
                    Descriere = $"Descriere Produs Test {i}",
                    Pret = 0.00m + i
                };
                products.Add(
                    new LiteTable()
                    {
                        IdObject =p.Id,
                        ObjectSource = JsonConvert.SerializeObject(p),
                        ObjectType = 1,
                        RecordId = p.Id
                    }


                    );

            }


            timer.Start();
            foreach (LiteTable p in products)
            {
                service.Inser(p);

            }

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertDbhybrid100000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<LiteTable> products = new List<LiteTable>();
            for (int i = 1; i < 100001; i++)
            {
                Product p = new Product()
                {
                    Id = i.ToString(),
                    CotaTva = 0.19m,
                    Denumire = $"Produs Tset {i}",
                    Descriere = $"Descriere Produs Test {i}",
                    Pret = 0.00m + i
                };
                products.Add(
                    new LiteTable()
                    {
                        IdObject = p.Id,
                        ObjectSource = JsonConvert.SerializeObject(p),
                        ObjectType = 1,
                        RecordId = p.Id
                    }


                    );

            }


            timer.Start();
            foreach (LiteTable p in products)
            {
                service.Inser(p);

            }

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }

        private double InsertAllDbhybrid1000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<LiteTable> products = new List<LiteTable>();
            for (int i = 1; i < 1001; i++)
            {
                Product p = new Product()
                {
                    Id = i.ToString(),
                    CotaTva = 0.19m,
                    Denumire = $"Produs Tset {i}",
                    Descriere = $"Descriere Produs Test {i}",
                    Pret = 0.00m + i
                };
                products.Add(
                    new LiteTable()
                    {
                        IdObject = p.Id,
                        ObjectSource = JsonConvert.SerializeObject(p),
                        ObjectType = 1,
                        RecordId = p.Id
                    }


                    );

            }


            timer.Start();
            service.BulkInser(products);
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertAllDbhybrid10000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<LiteTable> products = new List<LiteTable>();
            for (int i = 1; i < 10001; i++)
            {
                Product p = new Product()
                {
                    Id = i.ToString(),
                    CotaTva = 0.19m,
                    Denumire = $"Produs Tset {i}",
                    Descriere = $"Descriere Produs Test {i}",
                    Pret = 0.00m + i
                };
                products.Add(
                    new LiteTable()
                    {
                        IdObject = p.Id,
                        ObjectSource = JsonConvert.SerializeObject(p),
                        ObjectType = 1,
                        RecordId = p.Id
                    }


                    );

            }


            timer.Start();
            service.BulkInser(products);
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertAllDbhybrid100000(string dbPath)
        {
            service = new DatabaseService(dbPath);
            Stopwatch timer = new Stopwatch();
            List<LiteTable> products = new List<LiteTable>();
            for (int i = 1; i < 100001; i++)
            {
                Product p = new Product()
                {
                    Id = i.ToString(),
                    CotaTva = 0.19m,
                    Denumire = $"Produs Tset {i}",
                    Descriere = $"Descriere Produs Test {i}",
                    Pret = 0.00m + i
                };
                products.Add(
                    new LiteTable()
                    {
                        IdObject = p.Id,
                        ObjectSource = JsonConvert.SerializeObject(p),
                        ObjectType = 1,
                        RecordId = p.Id
                    }


                    );

            }


            timer.Start();
            service.BulkInser(products);

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }

        private double InsertNrDb1000(string dbPath)
        {
           
            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 1001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            foreach (Product p in products)
            {
                File.AppendAllText(dbPath,JsonConvert.SerializeObject(p)+"\n");

            }

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertNrDb10000(string dbPath)
        {
           
            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 10001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            foreach (Product p in products)
            {
                File.AppendAllText(dbPath, JsonConvert.SerializeObject(p) + "\n");

            }

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertNrDb100000(string dbPath)
        {
            
            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 100001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            foreach (Product p in products)
            {
                File.AppendAllText(dbPath, JsonConvert.SerializeObject(p) + "\n");

            }

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }

        private double InsertAllNrDb1000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 1001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
          
                File.AppendAllText(dbPath, JsonConvert.SerializeObject(products));


            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertAllNrDb10000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 10001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            File.AppendAllText(dbPath, JsonConvert.SerializeObject(products));
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double InsertAllNrDb100000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            for (int i = 1; i < 100001; i++)
            {
                products.Add(
                    new Product()
                    {
                        Id = Guid.NewGuid().ToString(),
                        CotaTva = 0.19m,
                        Denumire = $"Produs Tset {i}",
                        Descriere = $"Descriere Produs Test {i}",
                        Pret = 0.00m + i
                    }

                    );

            }


            timer.Start();
            File.AppendAllText(dbPath, JsonConvert.SerializeObject(products));

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }


        private double ReadDb1000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            for (int i = 1; i < 1001; i++)
            {
                products.Add((Product)service.Read(i,typeof(Product)));

            }


            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadDb10000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            for (int i = 1; i < 10001; i++)
            {
                products.Add((Product)service.Read(i, typeof(Product)));

            }


            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadDb100000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            for (int i = 1; i < 100001; i++)
            {
                products.Add((Product)service.Read(i, typeof(Product)));

            }


            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }

        private double ReadhybridDb1000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            for (int i = 1; i < 1001; i++)
            {
                products.Add(JsonConvert.DeserializeObject<Product>(((LiteTable)service.Read(i, typeof(LiteTable))).ObjectSource));

            }


            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadhybridDb10000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            for (int i = 1; i < 10001; i++)
            {
                products.Add(JsonConvert.DeserializeObject<Product>(((LiteTable)service.Read(i, typeof(LiteTable))).ObjectSource));

            }


            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadhybridDb100000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            for (int i = 1; i < 100001; i++)
            {
                products.Add(JsonConvert.DeserializeObject<Product>(((LiteTable)service.Read(i, typeof(LiteTable))).ObjectSource));

            }


            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }


        private double ReadAllDb1000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();
            products = (List<Product>)service.ReadAllProduct();
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadAllDb10000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            products = (List<Product>)service.ReadAllProduct();

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadAllDb100000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            products = (List<Product>)service.ReadAllProduct();

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }

        private double ReadAllHybridDb1000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();
            products = (List<Product>)service.ReadAllLiteTable();
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadAllHybridDb10000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            products = (List<Product>)service.ReadAllLiteTable();

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadAllHybridDb100000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
            service = new DatabaseService(dbPath);

            timer.Start();

            products = (List<Product>)service.ReadAllLiteTable();

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }

        private double ReadNrDb1000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
          
            List<string> productNames = System.IO.File.ReadLines(dbPath).ToList();

            timer.Start();
            foreach (string line in productNames)
            {
               products.Add(JsonConvert.DeserializeObject<Product>(line));
               
            }

            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadNrDb10000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
       
            timer.Start();
            foreach (string line in System.IO.File.ReadLines(dbPath))
            {
                products.Add(JsonConvert.DeserializeObject<Product>(line));

            }
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadNrDb100000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();
          
            timer.Start();
            foreach (string line in System.IO.File.ReadLines(dbPath))
            {
                products.Add(JsonConvert.DeserializeObject<Product>(line));

            }
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }


        private double ReadAllNrDb1000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();



            timer.Start();
            products = JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadLines(dbPath).FirstOrDefault());
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadAllNrDb10000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();

            timer.Start();
            products = JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadLines(dbPath).FirstOrDefault());
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
        private double ReadAllNrDb100000(string dbPath)
        {

            Stopwatch timer = new Stopwatch();
            List<Product> products = new List<Product>();

            timer.Start();
            products = JsonConvert.DeserializeObject<List<Product>>(System.IO.File.ReadLines(dbPath).FirstOrDefault());
            timer.Stop();

            return Math.Round(timer.Elapsed.TotalSeconds,2);

        }
    }
}
