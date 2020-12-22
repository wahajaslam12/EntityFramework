using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UBITIPT
{
    public class StudentHelperCustomer
    {
        public void Insert(string Name, String Address, String Email, String PhoneNumber)
        {
            Customer customer = new Customer();

            customer.Name = Name;
            customer.Address = Address;
            customer.Email = Email;
            customer.PhoneNumber = PhoneNumber;

            var db = new IPTEntities();
            db.Customers.Add(customer);
            db.SaveChanges();
            db.Dispose();
        }
    }

    internal class IPTEntities
    {
        internal object Customers;

        public IPTEntities()
        {
        }
    }

    public class StudentHelperBranch
    {
        public void Insert(string BranchName, String BranchManager, String BranchAddress, String BranchContact)
        {
            Branch branch = new Branch();

            branch.BranchName = BranchName;
            branch.BranchAddress = BranchAddress;
            branch.BranchManager = BranchManager;
            branch.BranchContact = BranchContact;

            var db = new IPTEntities();
            db.Branches.Add(branch);
            db.SaveChanges();
            db.Dispose();
        }
    }

    public class StudentHelperProduct
    {
        public void Insert(string ProductName, String ProductWeight, String ProductPrice)
        {
            Product product = new Product();

            product.ProductName = ProductName;
            product.ProductWeight = ProductWeight;
            product.ProductPrice = ProductPrice;

            var db = new IPTEntities();
            db.Products.Add(product);
            db.SaveChanges();
            db.Dispose();
        }
    }

    public class StudentHelperOrder
    {
        public void Insert(string Status,int CustomerId, int ProductId, int BranchId)
        {
            IPTEntities db = new IPTEntities();
            {
                if (db.Customers.Any(o => o.Id == CustomerId) &&
                    db.Products.Any(p => p.Id == ProductId) &&
                    db.Branches.Any(b => b.Id == BranchId))
                {
                    OrderStatu orderStatu = new OrderStatu();

                    orderStatu.Status = Status;
                    orderStatu.CustomerId = CustomerId;
                    orderStatu.ProductId = ProductId;
                    orderStatu.BranchId = BranchId;

                    var db1 = new IPTEntities();
                    db1.OrderStatus.Add(orderStatu);
                    db1.SaveChanges();
                    db1.Dispose();
                }
                 
               else
                {
                    Console.WriteLine("One of the value is not in the table");
                }

            }
          
        }
    }
}
