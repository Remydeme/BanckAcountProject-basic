/*
 Individu : 

* Nom 
* Prenom
* numero de carte id
    * Adresss:
        * rue 
        * numero 
        * code postal 
* compte : array (1 à N)


Method 

* getCompte(id, type)
* displayCompteEpargne()
* 

 */

using System;
using System.Collections.Generic;

namespace Bank_project
{
    public class Client
    {
        public Client(string nom, string prenom, string idNumber, string adress)
        {
            _nom = nom;
            _prenom = prenom;
            _id_number = idNumber;
            _adress = adress;
        }

      
        public List<Account> Account
        {
            get => _account;
            set => _account = value;
        }

        public string Nom
        {
            get => _nom;
            set => _nom = value;
        }

        public string Prenom
        {
            get => _prenom;
            set => _prenom = value;
        }

        public string IdNumber
        {
            get => _id_number;
            set => _id_number = value;
        }

        public string Adress
        {
            get => _adress;
            set => _adress = value;
        }


        public void GetUserId()
        {
            Console.Write("L'Id de l'utilisateur est  : %s", _id_number);
        }

        public void DisplayUserIdentity()
        {
            Console.Write("Le client s'appel : " + _nom + " " + _prenom);
        }

        public void DisplayUserInfo()
        {
            Console.WriteLine("____________________________ Client ___________________________");
            Console.WriteLine("Nom : " + _nom + " " + "Prénom : " + _prenom);
            Console.WriteLine("ID : " + _id_number );
            Console.WriteLine("Adress : " + _adress);
            Console.WriteLine("________________________________________________________________");
        }


        private string _nom;
        private string _prenom;
        private string _id_number;
        private string _adress;
        private List<Account> _account = new List<Account>();
    }
    
    
}