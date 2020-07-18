/**
 compte :

* id : string  pas de setter mais getter  
* numero de compte : 1 à N 
* individu (not mutable) get pas de setter
* solde : float 
* debit_max : float  (set get)

methode :

* deposit(int somme) 
* withdraw (float somme) :  n’est possible que si opn a pas depasé le découvert 
* virement (Compte *compte)


 
 */


using System;
using System.Collections.Generic;

namespace Bank_project
{
    enum BankType
    {
        Deposit,
        Vault
    }
    
   abstract public class  Account
    {
        protected Guid _id;
        protected int _number;
        protected Client _client;
        protected double _solde;
        protected List<Operation> _operations;

        public Account(int number, Client client, double solde)
        {
            _id = Guid.NewGuid();
            _number = number;
            _client = client;
            _solde = solde;
            _operations =  new List<Operation>();
        }

        public int Number
        {
            get => _number;
            set => _number = value;
        }

        public Client Client
        {
            get => _client;
            set => _client = value;
        }

        public double Solde
        {
            get => _solde;
            set => _solde = value;
        }

        public Guid Id
        {
            get => _id;
        }

        public List<Operation> Operations
        {
            get => _operations;
            set => _operations = value;
        }


        protected abstract bool _canWithdraw(double amount);

         public abstract bool makeOperation(Operation operation);

         abstract public void displayInfos();
         

         public void showHistory()
         {
             for (int index = 0; index < _operations.Count; index++)
             {
                 //_operations[index].Label;
             }
         }

    }
}

