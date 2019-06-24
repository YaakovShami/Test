using AlignTest.Order_Folder;
using AlignTest.Pet_Folder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace AlignTest
{
    class Store
    {   
        List<Pet> pets = new List<Pet>();
        string path = "path_to_json";
        public void UpdatePet (int id, Category cat, string name, List<Tag> tags, status stat)
        {
            foreach (Pet pet in this.pets)
            {
                if (pet.id == id)
                {
                    pet.Update(cat, name, tags, stat);
                }
            }
        }
        public bool UpdatePet(Pet p)
        {
            foreach (Pet pet in this.pets)
            {
                if (pet.id == p.id)
                {
                    pet.Update(p);
                    return true;
                }
            }
            return false;
        }
        public void AddPet(int id, Category cat, List<string> photoUrls, string name, List<Tag> tagList, status stat)
        {
            this.pets.Add(new Pet(id, cat, name, photoUrls, tagList, stat));
        }
        public void FindByStatus(status[] arr)
        {
            foreach (Pet pet in this.pets)
            {
                if (arr.Contains(pet.stat))
                {
                    Console.WriteLine(pet.ToString());
                }
            }
        }
        public Pet GetPet(int id)
        {
            foreach (Pet pet in this.pets)
            {
                if (pet.id == id)
                {
                    Console.WriteLine(pet.ToString());
                    return pet;
                }
            }
            return null;
        }
        public void DeletePet (int id)
        {
            this.pets.RemoveAll(pet => pet.id == id);
        }
        public void GetInventory()
        {
            string path = "path_to_xml";
            using (XmlWriter writer = XmlWriter.Create(path))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Pets");
                Dictionary<Category, int> categories = new Dictionary<Category, int>();
                foreach (Pet pet in pets)
                {
                    categories[pet.cat] += 1;
                }
                foreach (var item in categories)
                {
                    writer.WriteAttributeString(item.Key.ToString() , item.Value.ToString());
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        public void CreateOrder(int id, int petID, int quantity, string shipDate, OrderStatus status, bool complete)
        {
            Order order = new Order(id, petID, quantity, shipDate, status, complete);
            string json = System.IO.File.ReadAllText(path) + JsonConvert.SerializeObject(order);
            System.IO.File.WriteAllText(path, json);
        }
        public string FindOrder(int id)
        {
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(System.IO.File.ReadAllText(path));
            foreach (Order order in orders)
            {
                if (order.id == id)
                {
                    return JsonConvert.SerializeObject(order);
                }
            }
            return null;
        }
        public void DeleteOrder(int id)
        {
            List<Order> orders = JsonConvert.DeserializeObject<List<Order>>(System.IO.File.ReadAllText(path));
            orders.RemoveAll(order => order.id == id);
        }


    }
}
