﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workshop.Core.Entity;
using Workshop.Core.Utility;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Workshop.Core.Data
{
    public class CustomerDataSource
    {
        private readonly string path = ".\\Customer.json";

        /// <summary>
        /// Метод чтения в формате JSON и их десериализация
        /// </summary>

        public List<Customer> Get()
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string data = reader.ReadToEnd();
                    var tmp = DataSerializer.Deserialize<List<Customer>>(data) ?? [];
                    Customer._idCounter = tmp.Count > 0 ? tmp.Select(x => x.Id).Max() + 1 : 0;
                    return tmp;
                }

            }
            return [];
        }

        /// <summary>
        /// Метод записи в формате JSON и их сериализация
        /// </summary>

        public void Write(List<Customer> data)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(DataSerializer.Serialize(data));
            }
        }



        /// <summary>
        /// Принимает не лист, а один экземпляр класса.
        /// </summary>
        /// <returns></returns>
        //public Customer Get()
        //{
        //    if (File.Exists(path))
        //    {
        //        string customerF = File.ReadAllText(path);
        //        return DataSerializer.Deserialize<Customer>(customerF);
        //    }
        //    return null;
        //}

        ///// <summary>
        ///// Метод записи в формате JSON и их сериализация
        ///// </summary>

        //public void Write(Customer customerF)
        //{
        //    File.WriteAllText(path, DataSerializer.Serialize(customerF));
        //}
    }
}