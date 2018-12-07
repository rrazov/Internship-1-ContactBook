using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();

            var inputNumber = "";

            do
                       
            {  
                System.Console.WriteLine("\n------- address book -------");         
                System.Console.WriteLine("Input the following number for the desired changes: ");                
                System.Console.WriteLine("(1) Add a new value to the address book");
                System.Console.WriteLine("(2) Change the name, address or phone number");
                System.Console.WriteLine("(3) Delete a value from the address book");
                System.Console.WriteLine("(4) Search by phone number");
                System.Console.WriteLine("(5) Search by first name / last name");
                System.Console.WriteLine("(6) Exit");
                System.Console.WriteLine("-----------------------------");         
                System.Console.Write("Input the number: "); inputNumber = RemoveSpace(Console.ReadLine());

                if (inputNumber == "1")
                {
                    myDictionary = AddingInDictionary(myDictionary);
                }
                
                else if (inputNumber == "2")
                { 
                    System.Console.Write("Input the phone number of the person you want to change: "); string checkPhone = RemoveSpace(Console.ReadLine());

                    if (!myDictionary.Keys.Contains(checkPhone))
                    {
                        System.Console.WriteLine("The phone number doesn't exists");
                        
                    }
                    else{
                        System.Console.WriteLine("Input the following number for the desired changes:"); 
                        System.Console.WriteLine("(0) First name"); 
                        System.Console.WriteLine("(1) Last name"); 
                        System.Console.WriteLine("(2) Address"); 
                        System.Console.WriteLine("(3) Phone number: ");
                        System.Console.Write("Input the number: ");string input_value_2 = RemoveSpace(Console.ReadLine());

                        myDictionary = changeInDictionary(myDictionary,input_value_2, checkPhone);
                  
                    }
                    
                }
                 
                 else if (inputNumber == "3")
                {
                    System.Console.Write("Input the phone number of the person you want to change: "); string checkPhone = RemoveSpace(Console.ReadLine());

                    if (!myDictionary.Keys.Contains(checkPhone))
                    {
                        System.Console.WriteLine("The phone number doesn't exists");        
                    }
                    else{
                        myDictionary.Remove(checkPhone);
                    }
                }
                 else if (inputNumber == "4")
                {
                    System.Console.Write("Input the phone number of the person you want to search: "); string checkPhone = RemoveSpace(Console.ReadLine());

                    if (!myDictionary.Keys.Contains(checkPhone))
                    {
                        System.Console.WriteLine("The phone number doesn't exists");
                        
                    }
                    else{
                        System.Console.WriteLine("-----------------------");
                        System.Console.WriteLine(" First name: {0}\n Lastname: {1}\n Adress: {2}\n Phone number: {3}", myDictionary[checkPhone][0], myDictionary[checkPhone][1],myDictionary[checkPhone][2], checkPhone);
                        System.Console.WriteLine("-----------------------");
                    } 
                        
                }

                else if (inputNumber == "5")
                {
                    System.Console.WriteLine("Input the first name of person:"); var firstNameSearch = RemoveSpace(Console.ReadLine());
                    System.Console.WriteLine("Input the last name of person:"); var lastNameSearch = RemoveSpace(Console.ReadLine());

                    foreach (var key in myDictionary.Keys)
                    {
                        if(myDictionary[key][0] == firstNameSearch ||myDictionary[key][1] == lastNameSearch)
                        {   
                            System.Console.WriteLine("\n First name: {0}\n Lastname: {1}\n Adress: {2}\n Phone number: {3}\n ", myDictionary[key][0], myDictionary[key][1],myDictionary[key][2], key);
                            System.Console.WriteLine("-----------------------");
                            
                        }
                    }
                }

                
            } while (inputNumber != "6");
           

        }

        static string RemoveSpace(string inputValue)
        {
            var newValue = "";
            foreach (var item in inputValue)
            {
                if (item.Equals(' ')){}
                else{
                    newValue += item;
                }
            }
            return newValue;
        }

        static Dictionary<string, List<string>> AddingInDictionary(Dictionary<string, List<string>> newDictionary)
        {
            System.Console.Write("First name: "); var firstName = Console.ReadLine();
            System.Console.Write("Last name: "); var lastName = Console.ReadLine();
            System.Console.Write("Address: "); var address = Console.ReadLine();
            System.Console.Write("Phone numer: "); var phoneNumber = RemoveSpace(Console.ReadLine());
            
            var confirmPhoneNumber = "";
            
            do
            {
                if (newDictionary.Keys.Contains(phoneNumber))
                {
                    System.Console.WriteLine("That number already exists!");
                    System.Console.WriteLine("Input a new phone number or Exit to return to the main menu");
                    System.Console.Write("Phone number: "); phoneNumber = RemoveSpace(Console.ReadLine());
                }
                else if(phoneNumber.ToLower() == "exit" || confirmPhoneNumber.ToLower() == "exit"){
                    break;
                }
                else{
                    System.Console.WriteLine("Confirm you phone number: "); confirmPhoneNumber = RemoveSpace(Console.ReadLine());

                    while (phoneNumber != confirmPhoneNumber)
                    {

                        System.Console.WriteLine("The numbers disagree!");
                        System.Console.Write("Input a new phone number or Exit to return to the main menu: "); phoneNumber = RemoveSpace(Console.ReadLine());
                        if(phoneNumber.ToLower() == "exit"){break;}
                        System.Console.Write("Confirm you phone number: "); confirmPhoneNumber = RemoveSpace(Console.ReadLine()); 
                        if(confirmPhoneNumber.ToLower() == "exit"){break;}         
                    };
                    break;
                }
                    
            } while (phoneNumber.ToLower() != "exit");

            if (phoneNumber.ToLower() != "exit"){
                newDictionary.Add(phoneNumber, new List<string>(){firstName,lastName,address});
                return newDictionary;
            }
            else{
                return newDictionary;

            }     
            
        }
        
          static Dictionary<string,List<string>> changeInDictionary(Dictionary<string, List<string>> newDictionary,string choice, string phoneNumber){

            int i = int.Parse(choice);
            var key = phoneNumber;
            switch (choice)
            {
                case "0":
                {

                    System.Console.Write("New first name: "); var newItem = Console.ReadLine();
                    newDictionary[phoneNumber][i] = newItem;
                    break;       
                        
                }
                case "1":
                {

                    System.Console.Write("New last name: "); var newItem = Console.ReadLine();
                    newDictionary[phoneNumber][i] = newItem;
                    break;    
                }
                case "2":
                {
                    System.Console.Write("New address: "); var newItem = Console.ReadLine();
                    newDictionary[phoneNumber][i] = newItem;
                    break;
                        
                }
                case "3":
                {   
                    var confirmPhoneNumber = "";
                    do
                    {
                        if (newDictionary.Keys.Contains(phoneNumber))
                        {

                            System.Console.WriteLine("That number already exists!");
                            System.Console.WriteLine("Input a new phone number or Exit to return to the main menu");
                            System.Console.Write("Phone number: "); phoneNumber = RemoveSpace(Console.ReadLine());
                        }
                        else if(phoneNumber.ToLower() == "exit" || confirmPhoneNumber.ToLower() == "exit"){
                            break;
                        }
                        else{
                            System.Console.WriteLine("Confirm you phone number: "); confirmPhoneNumber = RemoveSpace(Console.ReadLine());

                            while (phoneNumber != confirmPhoneNumber)
                             {
                                System.Console.WriteLine("The numbers disagree!");
                                System.Console.Write("Input a new phone number or Exit to return to the main menu: "); phoneNumber = RemoveSpace(Console.ReadLine());
                                if(phoneNumber.ToLower() == "exit"){break;}
                                System.Console.Write("Confirm you phone number: "); confirmPhoneNumber = RemoveSpace(Console.ReadLine()); 
                                if(confirmPhoneNumber.ToLower() == "exit"){break;}         
                                };
                                break;
                        }
                    
                    } while (phoneNumber.ToLower() != "exit");


                if (phoneNumber != "exit"){
                    newDictionary.Add(phoneNumber, new List<string>(){ newDictionary[key][0],newDictionary[key][1],newDictionary[key][2]});
                    newDictionary.Remove(key);
                     return newDictionary;
                    }
                    else{
                        return newDictionary;

                    }
                }      
            }

            return newDictionary;
            
          }        

    }
}

