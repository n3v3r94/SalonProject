﻿

namespace Salon.Services
{
    using Salon.Data.Models;
    using Salon.Services.Models;
    using System;
    using System.Collections.Generic;
    public interface ISalonServices
    {
        IEnumerable<SalonViewModel> AllSalon();

        void  Create(Salons salon ,string name);

        Salons FindSalon(int  id);

        void Edit(Salons Salon, int id);

        void Delete(int id);

        void Delete(int id, string str);

        Salons Details(int id);

        void AddProduct(AddProductView product, int id);

        IEnumerable<SalonViewModel> MySalons(string name );

        List<SearchByProductViewModel> SearchProduct(string product);

        ProductWithWorkers GetProductWithWorkers(int id);

        ProductDetails ProductDetails(int id);

        SearchByUser SearchByUser(string email, int id);
        
         DateTime Book();

        void AddWorker(string id, string role);
    }
}
