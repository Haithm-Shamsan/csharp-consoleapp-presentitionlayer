using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ContactsBusinessLayer;
using CountryBuisnessLayer;

namespace ConsoleApp_PresentitionLayer
{
    internal class Program
    {
       public static void TestFindMethod(int ID)
        {
            clsContact Contact1= clsContact.Find(ID);

           if( Contact1!=null)

            { 
            
                Console.WriteLine(Contact1.FirstName+" "+ Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
                }
            else



                Console.WriteLine($"Could'nt found {ID}  Contact!");


        }

       public static void TestAddNew()
        {
            clsContact Contact1 = new clsContact();


            Contact1.FirstName = "Maria";
            Contact1.LastName = "Ziad";
            Contact1.Email = "marue12222@icloud.com";
            Contact1.Phone = "0543690171";
            Contact1.Address = "Makkah";
            Contact1.DateOfBirth = DateTime.UtcNow;
            Contact1.ImagePath = "C:ldfk";
            Contact1.CountryID = 1;

            if(Contact1.Save())
            {
                Console.WriteLine("Contact Saved Seccussfully");
            }else
            {
                Console.WriteLine("Error");
            }


        }

       public static void TestUpdate()
        {
            clsContact Contact1 = clsContact.Find(2010);

            Contact1.FirstName = "Maria";
            Contact1.LastName = "Ziad";
            Contact1.Email = "marue12222@icloud.com";
            Contact1.Phone = "0543690171";
            Contact1.Address = "Makkah";
            Contact1.DateOfBirth = DateTime.UtcNow;
            Contact1.ImagePath = "Hello";
            Contact1.CountryID = 1;

            if (Contact1.Save())
            {
                Console.WriteLine("Contact Saved Seccussfully");
            }
            else
            {
                Console.WriteLine("Error");
            }

        }



static void TestDelete(int ContactID)
        {
            if (clsContact.Delete(ContactID))
            {
                Console.WriteLine("Contact Delete Seccussfully");

            }else
            {
                Console.WriteLine("Error");
            }
            
            






        }


      static void TestLoadData()
        {
            DataTable Dt = clsContact.ContactsList();


          foreach(DataRow row in Dt.Rows)
            {
                Console.WriteLine($"______________{row["ContactID"]}_________________");
                Console.WriteLine($"ContactID   : {row["ContactID"]}");
                Console.WriteLine($"FirstName   : {row["FirstName"]}");
                Console.WriteLine($"LastName    : {row["LastName"]}");
                Console.WriteLine($"Email       : {row["Email"]}");
                Console.WriteLine($"Phone       : {row["Phone"]}");
                Console.WriteLine($"Address     : {row["Address"]}");
                Console.WriteLine($"DateOfBirth : {row["DateOfBirth"]}");
                Console.WriteLine($"CountryID   : {row["CountryID"]}");
                Console.WriteLine($"ImagePath   : {row["ImagePath"]}");
                Console.WriteLine($"___________________________________");

                Console.WriteLine("\n\n");


            }









        }

        static void  TestIsExist(int ContactID)
        {
            if(clsContact.IsExist(ContactID))
            {
                Console.WriteLine("This Contact Exist");
            }else
            {
                Console.WriteLine("Error");
            }


        }



        static void TestFindCountryByCountryID(int CountryID)
        {
            clsCountry Country = clsCountry.FindCountry(CountryID);
            if (clsCountry.FindCountry(CountryID) != null)
            {
                Console.WriteLine(" Founded In ID Number " + Country.ID);
                Console.WriteLine("Country Name :" + Country.CountryName);
                Console.WriteLine("Code :" + Country.Code);

                Console.WriteLine("PhoneCode :" + Country.PhoneCode);



            }
            else
            {
                Console.WriteLine("CountryNotFound");
            }
        }

        static void TestFindCountryByCountryID(string CountryName)
        {
            clsCountry Country = clsCountry.FindCountry(CountryName);
            if (clsCountry.FindCountry(CountryName) != null)
            {
                Console.WriteLine(" Founded In ID Number " + Country.ID);
                Console.WriteLine("Country Name :" + CountryName);
                Console.WriteLine("Code :" + Country.Code);

                Console.WriteLine("PhoneCode :" + Country.PhoneCode);
            }
            else
            {
                Console.WriteLine("Country Not Found");
            }
        }
        static void TestUpdateCountry(int ID)
        {
            clsCountry Country = clsCountry.FindCountry(ID);

            Country.CountryName = "United States";
            Country.Code = "1";
            Country.PhoneCode = "1";

            if (Country.Save())
            {
                Console.WriteLine("Country Updated Seccussfully");
            }
            else
            {
                Console.WriteLine("Filed Update Country");
            }
        }

        //}

        static void TestAddNewCountry()
        {
            clsCountry country = new clsCountry();

            country.CountryName = "Netharland ";
            country.Code = "";
            country.PhoneCode = "41";

            if (country.Save())
            {
                Console.WriteLine("New Country Saved");
            }
            else
            {
                Console.WriteLine("Fuck");
            }
        }

        static  void TestDeleteCountry(int ID)
        {
            

            if (clsCountry.Delete(ID))
            {
                Console.WriteLine("Delete Complate");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
        }



        //}

        static void TestCountryExistens(int ID)
        {

            if (clsCountry.IsCountryExist(ID))
            {
                Console.WriteLine("Yes Country Exist");
            }
            else
            {
                Console.WriteLine("No Country Does'nt Exist");
            }
        }


        static void TestCountryExistensByName(string CountryName)
        {

            if (clsCountry.IsCountryExist(CountryName))
            {
                Console.WriteLine($"Yes, {CountryName}  Exist");
            }
            else
            {
                Console.WriteLine("No Country Does'nt Exist");
            }
        }





        static void Main(string[] args)
        {

           // TestFindMethod(1);
         //  TestAddNew();
            //TestUpdate();
            //TestDelete(2010);
           //  TestLoadData();
            //TestIsExist(1);
           // TestFindCountryByCountryID(1);
           // TestFindCountryByCountryID("United States");
            //TestFindCountryByCountryID(1);
             //TestUpdateCountry(1);
            //TestAddNewCountry();
           //  TestDeleteCountry(1008);
            //TestCountryList();
            TestCountryExistens(1);
            TestCountryExistensByName("Yemen");




            Console.ReadKey();
        }
    }
}
