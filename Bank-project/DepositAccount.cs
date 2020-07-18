using System;

namespace Bank_project
{
    public class DepositAccount : Account
    {
        
        private double _overdraft;
        private double _maxWithdraw;
        private double _withdrawCounter;
        private bool _isOverdrafted;
        
        public DepositAccount(int number, Client client, double solde, double overdraft,  double maxWithdraw) : base(number, client, solde)
        {
            _maxWithdraw = maxWithdraw;
            _overdraft = overdraft;
        }


        public bool  _isOverDrafted()
        {
            if (_solde < 0)
                return true;

            return false; 
        }

        override public bool makeOperation(Operation operation) 
        {
            switch (operation.Type)
            {
                case OperationType.Deposit:
                    _solde += operation.Amount;
                    // add the operation to the history 
                    _operations.Add(operation);
                    
                    return true;
                case OperationType.Transfert:
                    if (_haveEnoughMoney(operation.Amount) == true)
                    {
                        _solde -= operation.Amount;
                        // add the operation to the history 
                        _operations.Add(operation);
                        return true; 
                    }
                    else
                    {
                        Console.WriteLine("Impossible de faire un transfert. Votre solde est insufisant.");
                        return false; 
                    }
                case OperationType.Withdraw:
                    if (_haveEnoughMoney(operation.Amount)  && _canWithdraw(operation.Amount))
                    {
                        _solde -= operation.Amount;
                        _withdrawCounter += operation.Amount; // update the counter; 
                        // add the operation to the history 
                        _operations.Add(operation);
                        return true; 
                    }
                    else
                    {
                        Console.WriteLine("Impossible de faire un retrait. Votre solde est insufisant.");
                        return false; 
                    }
                default:
                    return false;
            }

        } // end make deposit 

        private bool _haveEnoughMoney(double amount)
        {
            double trueAmount = _solde + _overdraft;

            if (amount > trueAmount)
                return false;
            return true; 
        }

        override protected bool _canWithdraw(double amount)
        {
            double futureWithdrawValue = _withdrawCounter + amount;
            if (_maxWithdraw < futureWithdrawValue)
                return false;
            return true; 
        }

        public override void displayInfos()
        {
            Console.WriteLine("___________________________________Account__________________________________");
            Console.WriteLine("ID : " + _id.ToString());
            Console.WriteLine("Number : " + _number);
            Console.WriteLine("ClientID : " + _client.IdNumber);
            Console.WriteLine("Solde : " + _solde + " €");
            Console.WriteLine("A découvert : " + _isOverDrafted().ToString());
            Console.WriteLine("Découvert authorisé : " + _overdraft.ToString());
            Console.WriteLine("Retrait compteur : " + _withdrawCounter + " €");
            Console.WriteLine("Limite de retrait : " + _maxWithdraw + " €");
            Console.WriteLine("_____________________________________________________________________________");
        }

    }
}