using Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Product {
    public class ProductData {
        public string id { get; set; }
        public string name { get; set; }
        public BaseType type { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
    }

    public class BaseType
    {
        private int baseTax = 5;
        protected string name = "L0";

        public virtual int getTax() { 
            return baseTax; 
        }

        public string getName() { 
            return name;
        }
    }

    public class TypeOne : BaseType {
        public TypeOne()
        {
            name = "L1";
        }
        public override int getTax()
        {
            return base.getTax() + 10;
        }
    }

    public class ProductManager : ProductAction {
        List<ProductData> products = new List<ProductData>();

        public List<ProductData> getProducts()
        {
            return products;
        }

        private void insertProduct(ProductData product)
        {
            products.Add(product);
        }

        private void removeProductByIndex(int index)
        {
            products.RemoveAt(index);
        }

        private void editProduct(ProductData newData, int productIndex)
        {
            products[productIndex] = newData;
        }

        public int findProduct(string id)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].id == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public int findIndex(string id)
        {
            return findProduct(id);
        }

        public bool add(ProductData data)
        {
            Console.WriteLine("add");
            insertProduct(data);
            return true;
        }

        public bool edit(ProductData data, string id)
        {
            editProduct(data, findProduct(id));
            return true;
        }

        public bool remove(string id)
        {
            if (findProduct(id) == -1)
            {
                return false;
            }

            removeProductByIndex(findProduct(id));
            return true;
        }
    }
}
