using System;

namespace Bank_project
{
    public class Epargne : Account
    {
        private double _rate;
        
        public Epargne(int number, Client client, double solde,  double rate) : base(number, client, solde)
        {
            _rate = rate; 
        }


        protected override bool _canWithdraw(double amount)
        {
            if (_solde < amount)
            {
                return false;
            }

            return true;
        }

        public override bool makeOperation(Operation operation)
        {
            switch (operation.Type)
            {
                case OperationType.Deposit:
                    _solde += operation.Amount;
                    _operations.Add(operation);
                    return true; 
                    break;
                case OperationType.Transfert:
                    if (_canWithdraw(operation.Amount))
                    {
                        _solde -= operation.Amount;
                        _operations.Add(operation);
                        return true; 
                    }
                    else
                    {
                        Console.WriteLine("Solde insuffisant. Opération impossible");
                        return false;
                    }

                    break;
                case OperationType.Withdraw:
                    if (_canWithdraw(operation.Amount))
                    {
                        _solde -= operation.Amount;
                        _operations.Add(operation);
                        return true; 
                    }
                    else
                    {
                        Console.WriteLine("Solde insuffisant. Opération impossible");
                        return false;
                    }

                    break;
                default:
                    return false;
            }
        }
        
        public override void displayInfos()
        {
            Console.WriteLine("___________________________________Account__________________________________");
            Console.WriteLine("ID : " + _id.ToString());
            Console.WriteLine("Number : " + _number);
            Console.WriteLine("ClientID : " + _client.IdNumber);
            Console.WriteLine("Solde : " + _solde + " €");
            Console.WriteLine("Taux d'intéret : " + _rate);
            Console.WriteLine("_____________________________________________________________________________");
        }
    }
}