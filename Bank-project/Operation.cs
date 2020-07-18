/**
     Operation :
    * numero 
    * somme 
    * date : string 
    * libellé
 */

using System;
using System.Xml;

namespace Bank_project
{
    public enum OperationType
    {
        Deposit,
        Withdraw,
        Transfert
    }
    
    public class Operation
    {
        protected double _amount;
        protected OperationType _type;
        protected Guid _id;
        protected string _date;
        protected string _label; // libellé 

        public double Amount
        {
            get => _amount;
            set => _amount = value;
        }

        public OperationType Type
        {
            get => _type;
            set => _type = value;
        }

        public string Date
        {
            get => _date;
            set => _date = value;
        }

        public string Label
        {
            get => _label;
            set => _label = value;
        }

        public Guid Id
        {
            get => _id;
        }

        public Operation(double amount, OperationType type, string date, string label)
        {
            _amount = amount;
            _type = type;
            _id = Guid.NewGuid();
            _date = date;
            _label = label;
        }


        public void DisplayOperation()
        {
            Console.WriteLine("______________________________Operation___________________________");
            Console.WriteLine("Montant : " + _amount);
            Console.WriteLine("Type : " + _type.ToString());
            Console.WriteLine("id : " + _id.ToString());
            Console.WriteLine("date : " + _date);
            Console.WriteLine("Libellé : " + _label);
            Console.WriteLine("____________________________________________________________________");
        }
    }
}